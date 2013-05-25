// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenPacketDetails.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the OpenPacketDetails type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.Document
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.AutoFactory;
    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AoWorkbench.Events.Workbench;

    [Export(typeof(IOpenPacketDetails))]
    public class OpenPacketDetails : IOpenPacketDetails
    {
        #region Fields

        private readonly IBus bus;

        private readonly IAutoFactory<PacketDetailsDocumentItemViewModel> packetDetailsDocumentItemVMFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public OpenPacketDetails(
            IAutoFactory<PacketDetailsDocumentItemViewModel> packetDetailsDocumentItemVMFactory, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(packetDetailsDocumentItemVMFactory != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.packetDetailsDocumentItemVMFactory = packetDetailsDocumentItemVMFactory;
            this.bus = bus;
        }

        #endregion

        #region Public Methods and Operators

        public void OpenDetailsInNewTab(PacketViewModel packet)
        {
            var packetDetailsDocumentItem = this.packetDetailsDocumentItemVMFactory.Create();
            packetDetailsDocumentItem.PacketDetails.Packet = packet;
            this.bus.Publish(new ItemOpenedEvent(packetDetailsDocumentItem));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packetDetailsDocumentItemVMFactory != null);
            Contract.Invariant(this.bus != null);
        }

        #endregion
    }
}