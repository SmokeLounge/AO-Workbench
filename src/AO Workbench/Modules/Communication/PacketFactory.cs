// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Components.Services;

    [Export]
    public class PacketFactory
    {
        #region Fields

        private readonly IPacketInspectorService packetInspectorService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketFactory(IPacketInspectorService packetInspectorService)
        {
            Contract.Requires<ArgumentNullException>(packetInspectorService != null);

            this.packetInspectorService = packetInspectorService;
        }

        #endregion

        #region Public Methods and Operators

        public PacketViewModel Create(PacketDirection packetDirection, byte[] packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);
            Contract.Requires<ArgumentNullException>(packet.Length >= 16);
            Contract.Ensures(Contract.Result<PacketViewModel>() != null);

            var packetType = this.packetInspectorService.FindType(packet);
            return new PacketViewModel(packetDirection, packet, packetType);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packetInspectorService != null);
        }

        #endregion
    }
}