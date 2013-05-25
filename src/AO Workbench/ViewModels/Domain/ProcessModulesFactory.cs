// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessModulesFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ProcessModulesFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.ViewModels.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.AutoFactory;
    using SmokeLounge.AOWorkbench.Models.Domain;
    using SmokeLounge.AOWorkbench.Models.Modules;
    using SmokeLounge.AOWorkbench.ViewModels.Workbench.Documents;

    [Export]
    public class ProcessModulesFactory
    {
        #region Fields

        private readonly IEnumerable<IModuleFactory> moduleFactories;

        private readonly IAutoFactory<ProcessDetailsViewModel> processDetailsVMFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ProcessModulesFactory(
            [ImportMany] IEnumerable<IModuleFactory> moduleFactories, 
            IAutoFactory<ProcessDetailsViewModel> processDetailsVMFactory)
        {
            Contract.Requires<ArgumentNullException>(moduleFactories != null);
            Contract.Requires<ArgumentNullException>(processDetailsVMFactory != null);

            this.moduleFactories = moduleFactories.OrderBy(m => m.Name);
            this.processDetailsVMFactory = processDetailsVMFactory;
        }

        #endregion

        #region Public Methods and Operators

        public IProcessModules Create(IRemoteProcess remoteProcess)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);

            return new ProcessModulesViewModel(
                remoteProcess, 
                this.processDetailsVMFactory.Create(), 
                this.moduleFactories.Select(o => o.Create(remoteProcess)));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.moduleFactories != null);
            Contract.Invariant(this.processDetailsVMFactory != null);
        }

        #endregion
    }
}