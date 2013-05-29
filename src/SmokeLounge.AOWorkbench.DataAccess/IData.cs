// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IData.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IDataContract<>))]
    public interface IData<T>
        where T : class
    {
        #region Public Properties

        T Content { get; set; }

        Guid Id { get; set; }

        #endregion
    }

    [ContractClassFor(typeof(IData<>))]
    internal abstract class IDataContract<T> : IData<T>
        where T : class
    {
        #region Public Properties

        public T Content
        {
            get
            {
                Contract.Ensures(Contract.Result<T>() != null);

                throw new NotImplementedException();
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);

                throw new NotImplementedException();
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);

                throw new NotImplementedException();
            }
        }

        #endregion
    }
}