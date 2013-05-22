// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunicationFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CommunicationFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.AutoFactory;
    using SmokeLounge.AoWorkbench.Components.Services;
    using SmokeLounge.AoWorkbench.Models.Modules;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketList;

    [Export]
    public class CommunicationFactory : IDocumentItemFactory<CommunicationViewModel>
    {
        #region Fields

        private readonly IEventAggregator events;

        private readonly IAutoFactory<PacketDetailsViewModel> packetDetailsVMFactory;

        private readonly PacketListFactory packetListFactory;

        private readonly IRemoteProcessService remoteProcessService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public CommunicationFactory(
            IRemoteProcessService remoteProcessService, 
            PacketListFactory packetListFactory, 
            IAutoFactory<PacketDetailsViewModel> packetDetailsVMFactory, 
            IEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);
            Contract.Requires<ArgumentNullException>(packetListFactory != null);
            Contract.Requires<ArgumentNullException>(packetDetailsVMFactory != null);
            Contract.Requires<ArgumentNullException>(events != null);

            this.remoteProcessService = remoteProcessService;
            this.packetListFactory = packetListFactory;
            this.packetDetailsVMFactory = packetDetailsVMFactory;
            this.events = events;
        }

        #endregion

        #region Public Methods and Operators

        public CommunicationViewModel CreateItem(Guid processId)
        {
            var process = this.remoteProcessService.Get(processId);
            if (process == null)
            {
                throw new InvalidOperationException();
            }

            return new CommunicationViewModel(
                process, this.packetListFactory.Create(process.Id), this.packetDetailsVMFactory.Create(), this.events);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.events != null);
            Contract.Invariant(this.packetDetailsVMFactory != null);
            Contract.Invariant(this.packetListFactory != null);
            Contract.Invariant(this.remoteProcessService != null);
        }

        #endregion
    }
}