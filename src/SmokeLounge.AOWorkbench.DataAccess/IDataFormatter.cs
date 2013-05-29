// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataFormatter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDataFormatter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;

    [ContractClass(typeof(IDataFormatterContract<>))]
    public interface IDataFormatter<T>
        where T : class
    {
        #region Public Methods and Operators

        T Deserialize(Stream stream);

        void Serialize(Stream stream, T obj);

        #endregion
    }

    [ContractClassFor(typeof(IDataFormatter<>))]
    internal abstract class IDataFormatterContract<T> : IDataFormatter<T>
        where T : class
    {
        #region Public Methods and Operators

        public T Deserialize(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null);
            Contract.Ensures(Contract.Result<T>() != null);

            throw new NotImplementedException();
        }

        public void Serialize(Stream stream, T obj)
        {
            Contract.Requires<ArgumentNullException>(obj != null);
            Contract.Requires<ArgumentNullException>(stream != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}