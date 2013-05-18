﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketListFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketListFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketList
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AoWorkbench.Components.Services;
    using SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails.Document;

    [Export]
    public class PacketListFactory
    {
        #region Fields

        private readonly IDomainEventAggregator domainEvents;

        private readonly IMessageSerializerService messageSerializerService;

        private readonly IOpenPacketDetails openPacketDetails;

        private readonly PacketFactory packetFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketListFactory(
            IMessageSerializerService messageSerializerService, 
            PacketFactory packetFactory, 
            IOpenPacketDetails openPacketDetails, 
            IDomainEventAggregator domainEvents)
        {
            Contract.Requires<ArgumentNullException>(messageSerializerService != null);
            Contract.Requires<ArgumentNullException>(packetFactory != null);
            Contract.Requires<ArgumentNullException>(openPacketDetails != null);
            Contract.Requires<ArgumentNullException>(domainEvents != null);

            this.messageSerializerService = messageSerializerService;
            this.packetFactory = packetFactory;
            this.openPacketDetails = openPacketDetails;
            this.domainEvents = domainEvents;
        }

        #endregion

        #region Public Methods and Operators

        public PacketListViewModel Create(Guid processId)
        {
            Contract.Ensures(Contract.Result<PacketListViewModel>() != null);

            var packetList = new PacketListViewModel(
                processId, this.messageSerializerService, this.packetFactory, this.openPacketDetails);
            this.domainEvents.Subscribe(packetList);
            return packetList;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.domainEvents != null);
            Contract.Invariant(this.messageSerializerService != null);
            Contract.Invariant(this.openPacketDetails != null);
            Contract.Invariant(this.packetFactory != null);
        }

        #endregion
    }
}