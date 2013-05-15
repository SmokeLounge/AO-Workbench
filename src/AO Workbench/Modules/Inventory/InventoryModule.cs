// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryModule.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the InventoryModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Inventory
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Models.Modules;
    using SmokeLounge.AoWorkbench.Models.Workbench;

    public class InventoryModule : IModule
    {
        #region Fields

        private readonly Uri iconSource;

        private readonly IRemoteProcess remoteProcess;

        private readonly InventoryFactory inventoryFactory;

        private readonly string name;

        #endregion

        #region Constructors and Destructors

        public InventoryModule(IRemoteProcess remoteProcess, InventoryFactory inventoryFactory)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(inventoryFactory != null);

            this.remoteProcess = remoteProcess;
            this.inventoryFactory = inventoryFactory;
            this.iconSource = null;
            this.name = "Inventory";
        }

        #endregion

        #region Public Properties

        public Uri IconSource
        {
            get
            {
                return this.iconSource;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        #endregion

        #region Public Methods and Operators

        public IItem CreateItem()
        {
            return this.inventoryFactory.CreateItem(this.remoteProcess.Id);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
            Contract.Invariant(this.inventoryFactory != null);
            Contract.Invariant(this.remoteProcess != null);
        }

        #endregion
    }
}