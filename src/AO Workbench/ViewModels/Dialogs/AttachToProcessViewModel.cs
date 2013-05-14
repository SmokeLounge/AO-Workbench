// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachToProcessViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AttachToProcessViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Dialogs
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Domain.Facade;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;
    using SmokeLounge.AoWorkbench.Components.Services;
    using SmokeLounge.AoWorkbench.Models.Domain;

    public class AttachToProcessViewModel : Screen
    {
        #region Fields

        private readonly IRemoteProcessCommandService remoteProcessCommandService;

        private readonly IRemoteProcessService remoteProcessService;

        private readonly IObservableCollection<IRemoteProcess> remoteProcesses;

        private readonly IObservableCollection<IRemoteProcess> selectedItems;

        #endregion

        #region Constructors and Destructors

        public AttachToProcessViewModel(
            IRemoteProcessService remoteProcessService, IRemoteProcessCommandService remoteProcessCommandService)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);
            Contract.Requires<ArgumentNullException>(remoteProcessCommandService != null);

            this.remoteProcessService = remoteProcessService;
            this.remoteProcessCommandService = remoteProcessCommandService;
            this.remoteProcesses = this.remoteProcessService.GetAll();
            this.selectedItems = new BindableCollection<IRemoteProcess>();
            this.selectedItems.CollectionChanged += (sender, args) => this.NotifyOfPropertyChange(() => this.CanAttach);
        }

        #endregion

        #region Public Properties

        public bool CanAttach
        {
            get
            {
                return this.selectedItems.Any(i => i.IsAttached == false);
            }
        }

        public IObservableCollection<IRemoteProcess> RemoteProcesses
        {
            get
            {
                return this.remoteProcesses;
            }
        }

        public IObservableCollection<IRemoteProcess> SelectedItems
        {
            get
            {
                return this.selectedItems;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Attach()
        {
            if (this.CanAttach == false)
            {
                throw new InvalidOperationException();
            }

            foreach (var remoteProcess in this.selectedItems.Where(p => p.IsAttached == false))
            {
                Contract.Assume(remoteProcess != null);
                this.remoteProcessCommandService.AttachClientToRemoteProcess(
                    new AttachClientToRemoteProcessCommand(remoteProcess.Id));
            }

            this.TryClose();
        }

        public void Cancel()
        {
        }

        #endregion

        #region Methods

        protected override void OnInitialize()
        {
            this.DisplayName = "Attach to Process";
            base.OnInitialize();
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessCommandService != null);
            Contract.Invariant(this.remoteProcessService != null);
            Contract.Invariant(this.remoteProcesses != null);
            Contract.Invariant(this.selectedItems != null);
        }

        #endregion
    }
}