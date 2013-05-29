// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientAttachedToProcessEventHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ClientAttachedToProcessEventHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DomainEventHandlers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.IO;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AOWorkbench.Components.Services;
    using SmokeLounge.AOWorkbench.DataAccess;
    using SmokeLounge.AOWorkbench.ViewModels.Domain;

    [Export(typeof(IHandleMessage))]
    public class ClientAttachedToProcessEventHandler : IHandleMessage<ClientAttachedToProcessEvent>
    {
        #region Fields

        private readonly ProcessModulesFactory processModulesFactory;

        private readonly IDataService dataService;

        private readonly IRemoteProcessService remoteProcessService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ClientAttachedToProcessEventHandler(
            IRemoteProcessService remoteProcessService, ProcessModulesFactory processModulesFactory, IDataService dataService)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);
            Contract.Requires<ArgumentNullException>(processModulesFactory != null);
            Contract.Requires<ArgumentNullException>(dataService != null);

            this.remoteProcessService = remoteProcessService;
            this.processModulesFactory = processModulesFactory;
            this.dataService = dataService;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(ClientAttachedToProcessEvent message)
        {
            var remoteProcess = this.remoteProcessService.Get(message.RemoteProcessId);
            if (remoteProcess == null)
            {
                return;
            }


            var processModules = this.processModulesFactory.Create(remoteProcess);
            remoteProcess.ServiceLocator.AddInstance(processModules);
            var dataSource = this.dataService.OpenDataSource(Path.GetTempFileName());
            if (dataSource != null)
            {
                remoteProcess.ServiceLocator.AddInstance(dataSource);
            }

            remoteProcess.ClientId = message.ClientId;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessService != null);
            Contract.Invariant(this.processModulesFactory != null);
            Contract.Invariant(this.dataService != null);
        }

        #endregion
    }
}