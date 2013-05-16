// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketVisualizerModuleFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketVisualizerModuleFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Models.Modules;

    [Export(typeof(IModuleFactory))]
    public class PacketVisualizerModuleFactory : IModuleFactory
    {
        #region Fields

        private readonly Uri iconSource;

        private readonly string name;

        private readonly PacketVisualizerFactory packetVisualizerFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketVisualizerModuleFactory(PacketVisualizerFactory packetVisualizerFactory)
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

        public IModule Create(IProcess process)
        {
            return new PacketVisualizerModule(process, this.packetVisualizerFactory);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packetVisualizerFactory != null);
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
        }

        #endregion
    }
}