// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Services
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Domain.Facade;
    using SmokeLounge.AOWorkbench.Models.Domain;
    using SmokeLounge.AOWorkbench.ViewModels.Domain;

    [Export(typeof(IRemoteProcessService))]
    public class RemoteProcessService : IRemoteProcessService
    {
        #region Fields

        private readonly RemoteProcessFactory remoteProcessFactory;

        private readonly IRemoteProcessQueryService remoteProcessQueryService;

        private readonly BindableCollection<IRemoteProcess> remoteProcesses;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessService(
            IRemoteProcessQueryService remoteProcessQueryService, RemoteProcessFactory remoteProcessFactory)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessQueryService != null);
            Contract.Requires<ArgumentNullException>(remoteProcessFactory != null);

            this.remoteProcessQueryService = remoteProcessQueryService;
            this.remoteProcessFactory = remoteProcessFactory;

            this.remoteProcesses = new BindableCollection<IRemoteProcess>();
        }

        #endregion

        #region Public Methods and Operators

        public void Add(IRemoteProcess remoteProcess)
        {
            this.remoteProcesses.Add(remoteProcess);
        }

        public IRemoteProcess Get(Guid id)
        {
            return this.remoteProcesses.FirstOrDefault(p => p.Id == id);
        }

        public IReadOnlyObservableCollection<IRemoteProcess> GetAll()
        {
            return new ReadOnlyBindableCollection<IRemoteProcess>(this.remoteProcesses);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessQueryService != null);
            Contract.Invariant(this.remoteProcessFactory != null);
            Contract.Invariant(this.remoteProcesses != null);
        }

        #endregion
    }
}