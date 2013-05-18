// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketVisualizerFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketVisualizerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Components.Services;
    using SmokeLounge.AoWorkbench.Models.Modules;
    using SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails;
    using SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketList;

    [Export]
    public class PacketVisualizerFactory : IDocumentItemFactory<PacketVisualizerViewModel>
    {
        #region Fields

        private readonly IEventAggregator events;

        private readonly PacketDetailsFactory packetDetailsFactory;

        private readonly PacketListFactory packetListFactory;

        private readonly IRemoteProcessService remoteProcessService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketVisualizerFactory(
            IRemoteProcessService remoteProcessService, 
            PacketListFactory packetListFactory, 
            PacketDetailsFactory packetDetailsFactory, 
            IEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);
            Contract.Requires<ArgumentNullException>(packetListFactory != null);
            Contract.Requires<ArgumentNullException>(packetDetailsFactory != null);
            Contract.Requires<ArgumentNullException>(events != null);

            this.remoteProcessService = remoteProcessService;
            this.packetListFactory = packetListFactory;
            this.packetDetailsFactory = packetDetailsFactory;
            this.events = events;
        }

        #endregion

        #region Public Methods and Operators

        public PacketVisualizerViewModel CreateItem(Guid processId)
        {
            var process = this.remoteProcessService.Get(processId);
            if (process == null)
            {
                throw new InvalidOperationException();
            }

            return new PacketVisualizerViewModel(
                process, this.packetListFactory.Create(process.Id), this.packetDetailsFactory.Create(), this.events);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.events != null);
            Contract.Invariant(this.packetDetailsFactory != null);
            Contract.Invariant(this.packetListFactory != null);
            Contract.Invariant(this.remoteProcessService != null);
        }

        #endregion
    }
}