// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessModulesViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ProcessModulesViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.ViewModels.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using Caliburn.Micro;

    using SmokeLounge.AOWorkbench.Models.Domain;
    using SmokeLounge.AOWorkbench.Models.Modules;
    using SmokeLounge.AOWorkbench.Models.Workbench;

    public class ProcessModulesViewModel : PropertyChangedBase, IProcessModules
    {
        #region Fields

        private readonly Uri iconSource;

        private readonly IObservableCollection<IModule> modules;

        private readonly IItem processDetails;

        private readonly IRemoteProcess remoteProcess;

        #endregion

        #region Constructors and Destructors

        public ProcessModulesViewModel(IRemoteProcess remoteProcess, IItem processDetails, IEnumerable<IModule> modules)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(processDetails != null);
            Contract.Requires<ArgumentNullException>(modules != null);

            this.remoteProcess = remoteProcess;
            this.processDetails = processDetails;
            this.iconSource = null;
            this.modules = new BindableCollection<IModule>(modules);

            var inpc = remoteProcess as INotifyPropertyChanged;
            if (inpc == null)
            {
                return;
            }

            PropertyChangedEventManager.AddHandler(
                inpc, (sender, args) => this.NotifyOfPropertyChange(() => this.Name), string.Empty);
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

        public IObservableCollection<IModule> Modules
        {
            get
            {
                return this.modules;
            }
        }

        public string Name
        {
            get
            {
                var name = "Process ID: " + this.remoteProcess.RemoteId.ToString(CultureInfo.InvariantCulture);

                if (this.remoteProcess.Player != null)
                {
                    name = string.Format("{0} ({1})", this.remoteProcess.Player.Name, name);
                }

                Contract.Assume(string.IsNullOrWhiteSpace(name) == false);
                return name;
            }
        }

        #endregion

        #region Public Methods and Operators

        public IItem CreateItem()
        {
            return this.processDetails;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.modules != null);
            Contract.Invariant(this.processDetails != null);
            Contract.Invariant(this.remoteProcess != null);
        }

        #endregion
    }
}