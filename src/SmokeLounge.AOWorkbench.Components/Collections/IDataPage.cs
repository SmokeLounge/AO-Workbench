// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataPage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDataPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IDataPageContract<>))]
    public interface IDataPage<T> : INotifyPropertyChanged
        where T : class
    {
        #region Public Properties

        int Capacity { get; }

        int FirstIndex { get; }

        int Index { get; }

        bool IsInUse { get; }

        IList<IDataWrapper<T>> Items { get; }

        DateTime TouchTime { get; set; }

        #endregion

        #region Public Methods and Operators

        void Populate(IList<T> items);

        #endregion
    }

    [ContractClassFor(typeof(IDataPage<>))]
    internal abstract class IDataPageContract<T> : IDataPage<T>
        where T : class
    {
        #region Explicit Interface Events

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

        public int Capacity
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() > 0);

                throw new NotImplementedException();
            }
        }

        public int FirstIndex
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                throw new NotImplementedException();
            }
        }

        public int Index
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                throw new NotImplementedException();
            }
        }

        public bool IsInUse
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IDataWrapper<T>> Items
        {
            get
            {
                Contract.Ensures(Contract.Result<IList<IDataWrapper<T>>>() != null);

                throw new NotImplementedException();
            }
        }

        public DateTime TouchTime
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

        #region Public Methods and Operators

        public void Populate(IList<T> items)
        {
            Contract.Requires<ArgumentNullException>(items != null);
            Contract.Requires<ArgumentException>(items.Count > 0);

            throw new NotImplementedException();
        }

        #endregion
    }
}