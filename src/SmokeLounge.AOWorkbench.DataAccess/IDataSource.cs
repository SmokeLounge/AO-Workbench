// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataSource.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDataSource type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IDataSourceContract))]
    public interface IDataSource : IDisposable
    {
        #region Public Methods and Operators

        IDataAdapter<T> GetDataAdapter<T>() where T : class;

        #endregion
    }

    [ContractClassFor(typeof(IDataSource))]
    internal abstract class IDataSourceContract : IDataSource
    {
        #region Public Methods and Operators

        public IDataAdapter<T> GetDataAdapter<T>() where T : class
        {
            Contract.Ensures(Contract.Result<IDataAdapter<T>>() != null);

            throw new NotImplementedException();
        }

        #endregion

        #region Explicit Interface Methods

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}