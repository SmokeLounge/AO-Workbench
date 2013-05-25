// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessCreatedEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessCreatedEventHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DomainEventHandlers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Facade;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AOWorkbench.Components.Services;
    using SmokeLounge.AOWorkbench.ViewModels.Domain;

    [Export(typeof(IHandleMessage))]
    public class RemoteProcessCreatedEventHandler : IHandleMessage<RemoteProcessCreatedEvent>
    {
        #region Fields

        private readonly RemoteProcessFactory remoteProcessFactory;

        private readonly IRemoteProcessQueryService remoteProcessQueryService;

        private readonly IRemoteProcessService remoteProcessService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessCreatedEventHandler(
            IRemoteProcessService remoteProcessService, 
            RemoteProcessFactory remoteProcessFactory, 
            IRemoteProcessQueryService remoteProcessQueryService)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);
            Contract.Requires<ArgumentNullException>(remoteProcessFactory != null);
            Contract.Requires<ArgumentNullException>(remoteProcessQueryService != null);

            this.remoteProcessService = remoteProcessService;
            this.remoteProcessFactory = remoteProcessFactory;
            this.remoteProcessQueryService = remoteProcessQueryService;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(RemoteProcessCreatedEvent message)
        {
            var remoteProcessDto = this.remoteProcessQueryService.Get(message.RemoteProcessId);
            if (remoteProcessDto == null)
            {
                return;
            }

            var remoteProcess = this.remoteProcessFactory.Create(remoteProcessDto);
            this.remoteProcessService.Add(remoteProcess);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessService != null);
            Contract.Invariant(this.remoteProcessFactory != null);
            Contract.Invariant(this.remoteProcessQueryService != null);
        }

        #endregion
    }
}