// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcessModules.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IProcessModules type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Domain
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOWorkbench.Models.Modules;
    using SmokeLounge.AOWorkbench.Models.Workbench;

    [ContractClass(typeof(ProcessModulesContract))]
    public interface IProcessModules : IModule
    {
        #region Public Properties

        IObservableCollection<IModule> Modules { get; }

        #endregion
    }

    [ContractClassFor(typeof(IProcessModules))]
    internal abstract class ProcessModulesContract : IProcessModules
    {
        #region Public Properties

        public IObservableCollection<IModule> Modules
        {
            get
            {
                Contract.Ensures(Contract.Result<IObservableCollection<IModule>>() != null);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Properties

        Uri IModule.IconSource
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IModule.Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Methods

        IItem IModule.CreateItem()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}