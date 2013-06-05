// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataPage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DataPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class DataPage<T> : IDataPage<T>
        where T : class
    {
        #region Fields

        private readonly int firstIndex;

        private readonly int index;

        private readonly IList<IDataWrapper<T>> items;

        private int capacity;

        #endregion

        #region Constructors and Destructors

        public DataPage(int index, int capacity)
        {
            Contract.Requires<ArgumentException>(index >= 0);
            Contract.Requires<ArgumentException>(capacity > 0);

            this.firstIndex = index * capacity;
            this.index = index;
            this.capacity = capacity;

            this.items = new List<IDataWrapper<T>>();
            this.TouchTime = DateTime.Now;
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int FirstIndex
        {
            get
            {
                return this.firstIndex;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
        }

        public bool IsInUse
        {
            get
            {
                return this.Items.Any(wrapper => wrapper.IsInUse);
            }
        }

        public IList<IDataWrapper<T>> Items
        {
            get
            {
                return this.items;
            }
        }

        public DateTime TouchTime { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Populate(IList<T> newItems)
        {
            int i;
            var itemIndex = 0;
            for (i = 0; i < newItems.Count && i < this.items.Count; i++)
            {
                Contract.Assume(this.items[i] != null);
                this.items[i].Data = newItems[i];
                itemIndex = this.items[i].Index;
            }

            while (i < newItems.Count)
            {
                itemIndex++;
                var wrapper = new DataWrapper<T>(itemIndex) { Data = newItems[i] };
                this.items.Add(wrapper);
                wrapper.PropertyChanged += this.WrapperIsInUseChanged;
                i++;
            }

            while (i < this.items.Count)
            {
                this.items.RemoveAt(this.items.Count - 1);
            }

            Contract.Assume(this.items.Count > 0);
            this.capacity = this.items.Count;
        }

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.capacity > 0);
            Contract.Invariant(this.firstIndex >= 0);
            Contract.Invariant(this.index >= 0);
            Contract.Invariant(this.items != null);
        }

        private void WrapperIsInUseChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "IsInUse")
            {
                return;
            }

            this.OnPropertyChanged("IsInUse");
        }

        #endregion
    }
}