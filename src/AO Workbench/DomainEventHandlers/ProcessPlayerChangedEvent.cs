// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessPlayerChangedEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ProcessPlayerChangedEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.DomainEventHandlers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Facade;
    using SmokeLounge.AoWorkbench.Components.Services;
    using SmokeLounge.AoWorkbench.ViewModels.Domain;

    [Export(typeof(IHandleMessage))]
    public class ProcessPlayerChangedEvent :
        IHandleMessage<AOtomation.Domain.Interfaces.Events.ProcessPlayerChangedEvent>
    {
        #region Fields

        private readonly PlayerFactory playerFactory;

        private readonly IPlayerQueryService playerQueryService;

        private readonly IRemoteProcessService remoteProcessService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ProcessPlayerChangedEvent(
            IRemoteProcessService remoteProcessService, 
            PlayerFactory playerFactory, 
            IPlayerQueryService playerQueryService)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);
            Contract.Requires<ArgumentNullException>(playerFactory != null);
            Contract.Requires<ArgumentNullException>(playerQueryService != null);

            this.remoteProcessService = remoteProcessService;
            this.playerFactory = playerFactory;
            this.playerQueryService = playerQueryService;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(AOtomation.Domain.Interfaces.Events.ProcessPlayerChangedEvent message)
        {
            var remoteProcess = this.remoteProcessService.Get(message.RemoteProcessId);
            if (remoteProcess == null)
            {
                return;
            }

            var playerDto = this.playerQueryService.Get(message.PlayerId);
            if (playerDto == null || string.IsNullOrWhiteSpace(playerDto.Name))
            {
                return;
            }

            var player = this.playerFactory.Create(playerDto);
            remoteProcess.Player = player;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessService != null);
            Contract.Invariant(this.playerFactory != null);
            Contract.Invariant(this.playerQueryService != null);
        }

        #endregion
    }
}