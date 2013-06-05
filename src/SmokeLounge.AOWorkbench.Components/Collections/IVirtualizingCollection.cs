// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVirtualizingCollection.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IVirtualizingCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    [ContractClass(typeof(IVirtualizingCollectionContract<>))]
    public interface IVirtualizingCollection<T> : IObservableCollection<IDataWrapper<T>>, IList
        where T : class
    {
        #region Public Properties

        int PageSize { get; }

        long PageTimeout { get; }

        #endregion
    }

    [ContractClassFor(typeof(IVirtualizingCollection<>))]
    internal abstract class IVirtualizingCollectionContract<T> : IVirtualizingCollection<T>
        where T : class
    {
        #region Explicit Interface Events

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Properties

        public int PageSize
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() > 0);

                throw new NotImplementedException();
            }
        }

        public long PageTimeout
        {
            get
            {
                Contract.Ensures(Contract.Result<long>() >= 0);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Properties

        int ICollection.Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        int ICollection<IDataWrapper<T>>.Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool INotifyPropertyChangedEx.IsNotifying
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool ICollection<IDataWrapper<T>>.IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Indexers

        object IList.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IDataWrapper<T> IList<IDataWrapper<T>>.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Methods

        void ICollection<IDataWrapper<T>>.Add(IDataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        int IList.Add(object value)
        {
            throw new NotImplementedException();
        }

        void IObservableCollection<IDataWrapper<T>>.AddRange(IEnumerable<IDataWrapper<T>> items)
        {
            throw new NotImplementedException();
        }

        void IList.Clear()
        {
            throw new NotImplementedException();
        }

        void ICollection<IDataWrapper<T>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool IList.Contains(object value)
        {
            throw new NotImplementedException();
        }

        bool ICollection<IDataWrapper<T>>.Contains(IDataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<IDataWrapper<T>>.CopyTo(IDataWrapper<T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator<IDataWrapper<T>> IEnumerable<IDataWrapper<T>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        int IList.IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        int IList<IDataWrapper<T>>.IndexOf(IDataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        void IList.Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        void IList<IDataWrapper<T>>.Insert(int index, IDataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        void INotifyPropertyChangedEx.NotifyOfPropertyChange(string propertyName)
        {
            throw new NotImplementedException();
        }

        void INotifyPropertyChangedEx.Refresh()
        {
            throw new NotImplementedException();
        }

        void IList.Remove(object value)
        {
            throw new NotImplementedException();
        }

        bool ICollection<IDataWrapper<T>>.Remove(IDataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        void IList.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void IList<IDataWrapper<T>>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void IObservableCollection<IDataWrapper<T>>.RemoveRange(IEnumerable<IDataWrapper<T>> items)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}