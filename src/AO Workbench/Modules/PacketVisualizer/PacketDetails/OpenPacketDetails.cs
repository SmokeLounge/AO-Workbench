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

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Events.Workbench;

    [Export(typeof(IOpenPacketDetails))]
    public class OpenPacketDetails : IOpenPacketDetails
    {
        #region Fields

        private readonly IEventAggregator events;

        private readonly PacketDetailsDocumentItemFactory packetDetailsDocumentItemFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public OpenPacketDetails(
            PacketDetailsDocumentItemFactory packetDetailsDocumentItemFactory, IEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(packetDetailsDocumentItemFactory != null);
            Contract.Requires<ArgumentNullException>(events != null);

            this.packetDetailsDocumentItemFactory = packetDetailsDocumentItemFactory;
            this.events = events;
        }

        #endregion

        #region Public Methods and Operators

        public void OpenDetailsInNewTab(PacketViewModel packet)
        {
            var packetDetailsDocumentItem = this.packetDetailsDocumentItemFactory.Create(packet);
            this.events.Publish(new ItemOpenedEvent(packetDetailsDocumentItem));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packetDetailsDocumentItemFactory != null);
            Contract.Invariant(this.events != null);
        }

        #endregion
    }
}