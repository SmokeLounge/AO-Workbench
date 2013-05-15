// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessModulesService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ProcessModulesService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components.Services
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Models.Domain;

    [Export(typeof(IProcessModulesService))]
    public class ProcessModulesService : IProcessModulesService
    {
        #region Fields

        private readonly BindableCollection<IProcessModules> processModulesCollection;

        #endregion

        #region Constructors and Destructors

        public ProcessModulesService()
        {
            this.processModulesCollection = new BindableCollection<IProcessModules>();
        }

        #endregion

        #region Public Methods and Operators

        public void Add(IProcessModules processModules)
        {
            this.processModulesCollection.Add(processModules);
        }

        public IObservableCollection<IProcessModules> GetAll()
        {
            return this.processModulesCollection;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.processModulesCollection != null);
        }

        #endregion
    }
}