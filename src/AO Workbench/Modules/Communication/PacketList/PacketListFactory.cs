// --------------------------------------------------------------------------------------------------------------------
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

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketList
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.Document;

    [Export]
    public class PacketListFactory
    {
        #region Fields

        private readonly IBus bus;

        private readonly IOpenPacketDetails openPacketDetails;

        private readonly PacketFactory packetFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketListFactory(PacketFactory packetFactory, IOpenPacketDetails openPacketDetails, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(packetFactory != null);
            Contract.Requires<ArgumentNullException>(openPacketDetails != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.packetFactory = packetFactory;
            this.openPacketDetails = openPacketDetails;
            this.bus = bus;
        }

        #endregion

        #region Public Methods and Operators

        public PacketListViewModel Create(Guid processId)
        {
            Contract.Ensures(Contract.Result<PacketListViewModel>() != null);

            var packetList = new PacketListViewModel(processId, this.packetFactory, this.openPacketDetails);
            this.bus.Subscribe(packetList);
            return packetList;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.bus != null);
            Contract.Invariant(this.openPacketDetails != null);
            Contract.Invariant(this.packetFactory != null);
        }

        #endregion
    }
}