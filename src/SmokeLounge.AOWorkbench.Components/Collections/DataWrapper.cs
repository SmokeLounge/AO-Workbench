// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataWrapper.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DataWrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class DataWrapper<T> : IDataWrapper<T>
        where T : class
    {
        #region Fields

        private readonly int index;

        private T data;

        private PropertyChangedEventHandler propertyChanged;

        private int useCount;

        #endregion

        #region Constructors and Destructors

        public DataWrapper(int index)
        {
            Contract.Requires<ArgumentException>(index >= 0);

            this.index = index;
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                var changedEventHandler = this.propertyChanged;
                PropertyChangedEventHandler comparand;
                do
                {
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange(
                        ref this.propertyChanged, comparand + value, comparand);
                }
                while (changedEventHandler != comparand);
                if (value == null || value.Target is IDataPage<T>)
                {
                    return;
                }

                Interlocked.Increment(ref this.useCount);
                this.OnPropertyChanged("IsInUse");
            }

            remove
            {
                var changedEventHandler = this.propertyChanged;
                PropertyChangedEventHandler comparand;
                do
                {
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange(
                        ref this.propertyChanged, comparand - value, comparand);
                }
                while (changedEventHandler != comparand);
                if (value == null || value.Target is IDataPage<T>)
                {
                    return;
                }

                Interlocked.Decrement(ref this.useCount);
                this.OnPropertyChanged("IsInUse");
            }
        }

        #endregion

        #region Public Properties

        public T Data
        {
            get
            {
                return this.data;
            }

            set
            {
                if (Equals(value, this.data))
                {
                    return;
                }

                this.data = value;
                this.OnPropertyChanged();
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
                return this.useCount > 0;
            }
        }

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.propertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.index >= 0);
        }

        #endregion
    }
}