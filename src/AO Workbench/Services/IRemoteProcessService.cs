﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRemoteProcessService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IRemoteProcessService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Services
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.ViewModels.Domain;

    [ContractClass(typeof(IRemoteProcessServiceContract))]
    public interface IRemoteProcessService
    {
        #region Public Methods and Operators

        IObservableCollection<IRemoteProcess> GetAll();

        #endregion
    }

    [ContractClassFor(typeof(IRemoteProcessService))]
    internal abstract class IRemoteProcessServiceContract : IRemoteProcessService
    {
        #region Public Methods and Operators

        public IObservableCollection<IRemoteProcess> GetAll()
        {
            Contract.Ensures(Contract.Result<IObservableCollection<IRemoteProcess>>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}