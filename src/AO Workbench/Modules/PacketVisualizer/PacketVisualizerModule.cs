// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketVisualizerModule.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketVisualizerModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Modules;
    using SmokeLounge.AoWorkbench.Models.Workbench;

    [Export(typeof(IModule))]
    public class PacketVisualizerModule : IModule
    {
        #region Fields

        private readonly Uri iconSource;

        private readonly string name;

        private readonly PacketVisualizerFactory packetVisualizerFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketVisualizerModule(PacketVisualizerFactory packetVisualizerFactory)
        {
            Contract.Requires<ArgumentNullException>(packetVisualizerFactory != null);

            this.packetVisualizerFactory = packetVisualizerFactory;
            this.iconSource = null;
            this.name = "Packet Visualizer";
        }

        #endregion

        #region Public Properties

        public Uri IconSource
        {
            get
            {
                return this.iconSource;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        #endregion

        #region Public Methods and Operators

        public IItem CreateItem(Guid processId)
        {
            return this.packetVisualizerFactory.CreateItem(processId);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
            Contract.Invariant(this.packetVisualizerFactory != null);
        }

        #endregion
    }
}