// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataWrapper.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDataWrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IDataWrapperContract<>))]
    public interface IDataWrapper<T> : INotifyPropertyChanged
        where T : class
    {
        #region Public Properties

        T Data { get; set; }

        int Index { get; }

        bool IsInUse { get; }

        #endregion
    }

    [ContractClassFor(typeof(IDataWrapper<>))]
    internal abstract class IDataWrapperContract<T> : IDataWrapper<T>
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

        public T Data
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

        #endregion
    }
}