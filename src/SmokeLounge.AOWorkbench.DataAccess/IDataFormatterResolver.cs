// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataFormatterResolver.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDataFormatterResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IDataFormatterResolverContract))]
    public interface IDataFormatterResolver
    {
        #region Public Methods and Operators

        IDataFormatter<T> GetDataFormatter<T>() where T : class;

        #endregion
    }

    [ContractClassFor(typeof(IDataFormatterResolver))]
    internal abstract class IDataFormatterResolverContract : IDataFormatterResolver
    {
        #region Public Methods and Operators

        public IDataFormatter<T> GetDataFormatter<T>() where T : class
        {
            Contract.Ensures(Contract.Result<IDataFormatter<T>>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}