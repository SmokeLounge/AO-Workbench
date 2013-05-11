﻿// --------------------------------------------------------------------------------------------------------------------
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

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Services;
    using SmokeLounge.AoWorkbench.ViewModels.Domain;

    public class AttachToProcessViewModel : Screen
    {
        #region Fields

        private readonly IRemoteProcessService remoteProcessService;

        private readonly IObservableCollection<IRemoteProcess> remoteProcesses;

        #endregion

        #region Constructors and Destructors

        public AttachToProcessViewModel(IRemoteProcessService remoteProcessService)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);

            this.remoteProcessService = remoteProcessService;
            this.remoteProcesses = this.remoteProcessService.GetAll();
        }

        #endregion

        #region Public Properties

        public IObservableCollection<IRemoteProcess> RemoteProcesses
        {
            get
            {
                return this.remoteProcesses;
            }
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
            Contract.Invariant(this.remoteProcessService != null);
            Contract.Invariant(this.remoteProcesses != null);
        }

        #endregion
    }
}