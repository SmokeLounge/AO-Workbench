// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataAdapter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDataAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IDataAdapterContract<>))]
    public interface IDataAdapter<T>
        where T : class
    {
        #region Public Methods and Operators

        int Count();

        void Delete(IData<T> data);

        IData<T> Get(Guid id);

        IEnumerable<IData<T>> GetAll();

        IEnumerable<IData<T>> GetRange(int offset, int count);

        void Save(IData<T> data);

        void Update(IData<T> data);

        #endregion
    }

    [ContractClassFor(typeof(IDataAdapter<>))]
    internal abstract class IDataAdapterContract<T> : IDataAdapter<T>
        where T : class
    {
        #region Public Methods and Operators

        public int Count()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);

            throw new NotImplementedException();
        }

        public void Delete(IData<T> data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            throw new NotImplementedException();
        }

        public IData<T> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IData<T>> GetAll()
        {
            Contract.Ensures(Contract.Result<IEnumerable<IData<T>>>() != null);

            throw new NotImplementedException();
        }

        public IEnumerable<IData<T>> GetRange(int offset, int count)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(count >= 0);
            Contract.Ensures(Contract.Result<IEnumerable<IData<T>>>() != null);

            throw new NotImplementedException();
        }

        public void Save(IData<T> data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            throw new NotImplementedException();
        }

        public void Update(IData<T> data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}