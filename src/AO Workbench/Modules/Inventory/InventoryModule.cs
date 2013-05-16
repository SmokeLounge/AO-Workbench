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

        private readonly InventoryFactory inventoryFactory;

        private readonly string name;

        private readonly IProcess process;

        #endregion

        #region Constructors and Destructors

        public InventoryModule(IProcess process, InventoryFactory inventoryFactory)
        {
            Contract.Requires<ArgumentNullException>(process != null);
            Contract.Requires<ArgumentNullException>(inventoryFactory != null);

            this.process = process;
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
            return this.inventoryFactory.CreateItem(this.process.Id);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
            Contract.Invariant(this.inventoryFactory != null);
            Contract.Invariant(this.process != null);
        }

        #endregion
    }
}