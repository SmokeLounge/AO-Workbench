// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcessModulesService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IProcessModulesService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components.Services
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Models.Domain;

    [ContractClass(typeof(IProcessModulesServiceContract))]
    public interface IProcessModulesService
    {
        #region Public Methods and Operators

        void Add(IProcessModules processModules);

        IObservableCollection<IProcessModules> GetAll();

        #endregion
    }

    [ContractClassFor(typeof(IProcessModulesService))]
    internal abstract class IProcessModulesServiceContract : IProcessModulesService
    {
        #region Public Methods and Operators

        public void Add(IProcessModules processModules)
        {
            Contract.Requires<ArgumentNullException>(processModules != null);

            throw new NotImplementedException();
        }

        public IObservableCollection<IProcessModules> GetAll()
        {
            Contract.Ensures(Contract.Result<IObservableCollection<IProcessModules>>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}