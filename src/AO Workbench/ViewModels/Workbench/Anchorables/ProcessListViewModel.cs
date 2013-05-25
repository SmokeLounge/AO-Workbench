// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessListViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ProcessListViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Workbench.Anchorables
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AoWorkbench.Components.Services;
    using SmokeLounge.AoWorkbench.Events.Workbench;
    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Models.Modules;

    public class ProcessListViewModel : AnchorableItemViewModel
    {
        #region Fields

        private readonly IObservableCollection<IProcessModules> processModulesCollection;

        private readonly IProcessModulesService processModulesService;

        private IModule selectedItem;

        #endregion

        #region Constructors and Destructors

        public ProcessListViewModel(IProcessModulesService processModulesService, IBus bus)
            : base(bus)
        {
            Contract.Requires<ArgumentNullException>(processModulesService != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.processModulesService = processModulesService;
            this.processModulesCollection = this.processModulesService.GetAll();
            this.Title = "Processes";
        }

        #endregion

        #region Public Properties

        public IObservableCollection<IProcessModules> ProcessModulesCollection
        {
            get
            {
                return this.processModulesCollection;
            }
        }

        public IModule SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                if (Equals(value, this.selectedItem))
                {
                    return;
                }

                this.selectedItem = value;
                this.NotifyOfPropertyChange();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Open(object arg)
        {
            Contract.Requires<ArgumentNullException>(arg != null);

            if (arg != this.selectedItem)
            {
                return;
            }

            var module = arg as IModule;
            if (module == null)
            {
                throw new InvalidOperationException();
            }

            var item = module.CreateItem();
            this.Bus.Publish(new ItemOpenedEvent(item));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.processModulesCollection != null);
            Contract.Invariant(this.processModulesService != null);
        }

        #endregion
    }
}