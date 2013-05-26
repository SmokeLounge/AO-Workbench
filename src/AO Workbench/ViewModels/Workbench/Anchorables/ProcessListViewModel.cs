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

namespace SmokeLounge.AOWorkbench.ViewModels.Workbench.Anchorables
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOWorkbench.Components.Events;
    using SmokeLounge.AOWorkbench.Components.Events.Workbench;
    using SmokeLounge.AOWorkbench.Components.Services;
    using SmokeLounge.AOWorkbench.Components.Workbench;
    using SmokeLounge.AOWorkbench.Models.Domain;
    using SmokeLounge.AOWorkbench.Models.Modules;

    public class ProcessListViewModel : AnchorableItemViewModel, IHandleMessage<ProcessLoadedEvent>
    {
        #region Fields

        private readonly IObservableCollection<IProcessModules> processModulesCollection;

        private readonly IRemoteProcessService processService;

        private IModule selectedItem;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ProcessListViewModel(IRemoteProcessService processService, IBus bus)
            : base(bus)
        {
            this.processService = processService;
            Contract.Requires<ArgumentNullException>(processService != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.processModulesCollection = new BindableCollection<IProcessModules>();
            this.processService.GetAll().Where(p => p.IsAttached).Apply(this.AddProcessModules);
            this.Title = "Processes";
            this.Bus.Subscribe(this);
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

        public void Handle(ProcessLoadedEvent message)
        {
            var process = this.processService.Get(message.ProcessId);
            if (process == null)
            {
                return;
            }

            this.AddProcessModules(process);
        }

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

        private void AddProcessModules(IProcess process)
        {
            Contract.Requires(process != null);

            var processModules = process.ServiceLocator.GetInstance<IProcessModules>();
            if (processModules == null)
            {
                return;
            }

            this.processModulesCollection.Add(processModules);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.processService != null);
            Contract.Invariant(this.processModulesCollection != null);
        }

        private void RemoveProcessModules(IProcess process)
        {
        }

        #endregion
    }
}