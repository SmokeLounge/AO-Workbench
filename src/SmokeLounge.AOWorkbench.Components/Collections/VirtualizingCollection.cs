// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VirtualizingCollection.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the VirtualizingCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Caliburn.Micro;

    public class VirtualizingCollection<T> : IVirtualizingCollection<T>
        where T : class
    {
        #region Fields

        private readonly IItemProvider<T> itemsProvider;

        private readonly int pageSize;

        private readonly long pageTimeout;

        private readonly ConcurrentDictionary<int, IDataPage<T>> pages;

        private int? count;

        #endregion

        #region Constructors and Destructors

        public VirtualizingCollection(IItemProvider<T> itemsProvider)
        {
            Contract.Requires<ArgumentNullException>(itemsProvider != null);

            this.itemsProvider = itemsProvider;
            this.itemsProvider.ItemAdded += (sender, args) => Execute.OnUIThread(
                () =>
                    {
                        this.LoadCount();
                        var lastItemIndex = this.count.Value - 1;
                        var lastItem = this[lastItemIndex];
                        this.OnCollectionChanged(
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Add, lastItem, lastItemIndex));
                    });

            this.count = -1;
            this.pageSize = 30;
            this.pageTimeout = 10000;
            this.pages = new ConcurrentDictionary<int, IDataPage<T>>();
        }

        #endregion

        #region Public Events

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        public int Count
        {
            get
            {
                if (this.count.HasValue == false)
                {
                    this.LoadCount();
                }

                return this.count.Value;
            }

            protected set
            {
                Contract.Requires(value >= 0);

                if (this.count.HasValue && Equals(value, this.count.Value))
                {
                    return;
                }

                this.count = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
        }

        public long PageTimeout
        {
            get
            {
                return this.pageTimeout;
            }
        }

        #endregion

        #region Explicit Interface Properties

        int ICollection.Count
        {
            get
            {
                return this.Count;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        bool INotifyPropertyChangedEx.IsNotifying
        {
            get
            {
                throw new NotSupportedException();
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        bool ICollection<IDataWrapper<T>>.IsReadOnly
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        int IVirtualizingCollection<T>.PageSize
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        long IVirtualizingCollection<T>.PageTimeout
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        #endregion

        #region Public Indexers

        public IDataWrapper<T> this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                // determine which page and offset within page
                var pageIndex = index / this.pageSize;
                var pageOffset = index % this.pageSize;

                // request primary page
                var page = this.RequestPage(pageIndex);
                var newItemCount = pageOffset - (page.Items.Count - 1);
                if (newItemCount > 0)
                {
                    var startIndex = (pageIndex * this.pageSize) + page.Items.Count;
                    var newItems = this.itemsProvider.FetchRange(startIndex, newItemCount);
                    var items = new List<T>();
                    items.AddRange(page.Items.Select(i => i.Data));
                    items.AddRange(newItems);
                    Contract.Assume(items.Count > 0);
                    page.Populate(items);
                }

                // if accessing upper 50% then request next page
                if (pageOffset > this.pageSize / 2 && pageIndex < this.Count / this.pageSize)
                {
                    this.RequestPage(pageIndex + 1);
                }

                // if accessing lower 50% then request prev page
                if (pageOffset < this.pageSize / 2 && pageIndex > 0)
                {
                    this.RequestPage(pageIndex - 1);
                }

                // return requested item
                var item = page.Items[pageOffset];

                // remove stale pages
                this.CleanUpPages();

                return item;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        #endregion

        #region Explicit Interface Indexers

        IDataWrapper<T> IList<IDataWrapper<T>>.this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public IEnumerator<IDataWrapper<T>> GetEnumerator()
        {
            for (var i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        public int IndexOf(IDataWrapper<T> item)
        {
            var values = this.pages.Values.ToArray();
            foreach (var page in values)
            {
                Contract.Assume(page != null);
                var indexWithinPage = page.Items.IndexOf(item);
                if (indexWithinPage != -1)
                {
                    return (this.PageSize * page.Index) + indexWithinPage;
                }
            }

            return -1;
        }

        public void NotifyOfPropertyChange(string propertyName)
        {
            this.OnPropertyChanged(propertyName);
        }

        #endregion

        #region Explicit Interface Methods

        void ICollection<IDataWrapper<T>>.Add(IDataWrapper<T> item)
        {
            throw new NotSupportedException();
        }

        int IList.Add(object value)
        {
            throw new NotSupportedException();
        }

        void IObservableCollection<IDataWrapper<T>>.AddRange(IEnumerable<IDataWrapper<T>> items)
        {
            throw new NotSupportedException();
        }

        void ICollection<IDataWrapper<T>>.Clear()
        {
            throw new NotSupportedException();
        }

        void IList.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<IDataWrapper<T>>.Contains(IDataWrapper<T> item)
        {
            throw new NotSupportedException();
        }

        bool IList.Contains(object value)
        {
            throw new NotSupportedException();
        }

        void ICollection<IDataWrapper<T>>.CopyTo(IDataWrapper<T>[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<IDataWrapper<T>> IEnumerable<IDataWrapper<T>>.GetEnumerator()
        {
            throw new NotSupportedException();
        }

        int IList.IndexOf(object value)
        {
            return this.IndexOf((DataWrapper<T>)value);
        }

        void IList<IDataWrapper<T>>.Insert(int index, IDataWrapper<T> item)
        {
            throw new NotSupportedException();
        }

        void IList.Insert(int index, object value)
        {
            throw new NotSupportedException();
        }

        void INotifyPropertyChangedEx.NotifyOfPropertyChange(string propertyName)
        {
            throw new NotSupportedException();
        }

        void INotifyPropertyChangedEx.Refresh()
        {
            throw new NotSupportedException();
        }

        bool ICollection<IDataWrapper<T>>.Remove(IDataWrapper<T> item)
        {
            throw new NotSupportedException();
        }

        void IList.Remove(object value)
        {
            throw new NotSupportedException();
        }

        void IList<IDataWrapper<T>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void IList.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void IObservableCollection<IDataWrapper<T>>.RemoveRange(IEnumerable<IDataWrapper<T>> items)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Methods

        protected int FetchCount()
        {
            return this.itemsProvider.Count;
        }

        protected IList<T> FetchPage(int pageIndex, int pageLength)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Requires(pageLength > 0);

            return this.itemsProvider.FetchRange(pageIndex * this.PageSize, pageLength);
        }

        protected virtual void LoadCount()
        {
            this.Count = this.FetchCount();
        }

        protected virtual void LoadPage(int pageIndex, int pageLength)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Requires(pageLength > 0);

            this.PopulatePage(pageIndex, this.FetchPage(pageIndex, pageLength));
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var handler = this.CollectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void PopulatePage(int pageIndex, IList<T> dataItems)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Requires(dataItems != null);
            Contract.Requires(dataItems.Count > 0);

            Trace.WriteLine("Page populated: " + pageIndex);
            IDataPage<T> page;
            this.pages.TryGetValue(pageIndex, out page);
            if (page == null)
            {
                return;
            }

            page.Populate(dataItems);
        }

        private void CleanUpPages()
        {
            var values = this.pages.Values.ToArray();
            foreach (var page in values)
            {
                Contract.Assume(page != null);

                // page 0 is a special case, since WPF ItemsControl access the first item frequently
                if (page.Index == 0 || !((DateTime.Now - page.TouchTime).TotalMilliseconds > this.PageTimeout))
                {
                    continue;
                }

                var removePage = !page.IsInUse;

                if (removePage)
                {
                    IDataPage<T> discard;
                    this.pages.TryRemove(page.Index, out discard);
                    Trace.WriteLine("Removed page: " + page.Index);
                }
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.itemsProvider != null);
            Contract.Invariant(this.pages != null);
            Contract.Invariant(this.pageSize > 0);
        }

        private void PageIsInUseChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "IsInUse")
            {
                return;
            }

            var page = sender as IDataPage<T>;
            if (page == null || page.IsInUse || page.Index == 0)
            {
                return;
            }

            IDataPage<T> discard;
            if (this.pages.TryRemove(page.Index, out discard))
            {
                page.PropertyChanged -= this.PageIsInUseChanged;
                Trace.WriteLine("Removed page: " + page.Index);
            }
        }

        private IDataPage<T> RequestPage(int pageIndex)
        {
            Contract.Requires(pageIndex >= 0);

            IDataPage<T> page;
            this.pages.TryGetValue(pageIndex, out page);
            if (page == null)
            {
                var pageLength = Math.Min(this.pageSize, this.Count - (pageIndex * this.pageSize));
                if ((pageLength > 0) == false)
                {
                    throw new InvalidOperationException();
                }

                page = new DataPage<T>(pageIndex, pageLength);
                this.pages.TryAdd(pageIndex, page);
                Trace.WriteLine("Added page: " + pageIndex);
                this.LoadPage(pageIndex, pageLength);
                page.PropertyChanged += this.PageIsInUseChanged;
            }
            else
            {
                page.TouchTime = DateTime.Now;
            }

            return page;
        }

        #endregion
    }
}