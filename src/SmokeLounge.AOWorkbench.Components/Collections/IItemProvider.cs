// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemProvider.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IItemProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IItemProviderContract<>))]
    public interface IItemProvider<T>
        where T : class
    {
        #region Public Events

        event EventHandler ItemAdded;

        #endregion

        #region Public Properties

        int Count { get; }

        #endregion

        #region Public Methods and Operators

        void AddItem(T item);

        IList<T> FetchRange(int startIndex, int count);

        #endregion
    }

    [ContractClassFor(typeof(IItemProvider<>))]
    internal abstract class IItemProviderContract<T> : IItemProvider<T>
        where T : class
    {
        #region Public Events

        public event EventHandler ItemAdded
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

        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddItem(T item)
        {
            Contract.Requires<ArgumentNullException>(item != null);

            throw new NotImplementedException();
        }

        public IList<T> FetchRange(int startIndex, int count)
        {
            Contract.Requires<ArgumentOutOfRangeException>(startIndex >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(count > 0);
            Contract.Ensures(Contract.Result<IList<T>>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}