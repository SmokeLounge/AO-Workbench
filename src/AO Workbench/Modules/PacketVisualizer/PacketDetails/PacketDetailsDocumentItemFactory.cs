// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketDetailsDocumentItemFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketDetailsDocumentItemFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    [Export]
    public class PacketDetailsDocumentItemFactory
    {
        #region Fields

        private readonly IEventAggregator events;

        private readonly PacketDetailsFactory packetDetailsFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketDetailsDocumentItemFactory(PacketDetailsFactory packetDetailsFactory, IEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(packetDetailsFactory != null);
            Contract.Requires<ArgumentNullException>(events != null);

            this.packetDetailsFactory = packetDetailsFactory;
            this.events = events;
        }

        #endregion

        #region Public Methods and Operators

        public PacketDetailsDocumentItemViewModel Create(PacketViewModel packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            var packetDetails = this.packetDetailsFactory.Create();
            packetDetails.Packet = packet;
            return new PacketDetailsDocumentItemViewModel(packetDetails, this.events);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.events != null);
            Contract.Invariant(this.packetDetailsFactory != null);
        }

        #endregion
    }
}