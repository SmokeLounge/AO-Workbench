// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketInspectorService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketInspectorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Services
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.IO;

    using SmokeLounge.AOtomation.Messaging.Serialization;

    using StreamReader = SmokeLounge.AOtomation.Messaging.Serialization.StreamReader;

    [Export(typeof(IPacketInspectorService))]
    public class PacketInspectorService : IPacketInspectorService
    {
        #region Fields

        private readonly PacketInspector packetInspector;

        #endregion

        #region Constructors and Destructors

        public PacketInspectorService()
        {
            this.packetInspector = new PacketInspector();
        }

        #endregion

        #region Public Methods and Operators

        public Type FindType(byte[] packet)
        {
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream(packet);
                using (var streamReader = new StreamReader(memoryStream))
                {
                    var typeInfo = this.packetInspector.FindSubType(streamReader);
                    memoryStream = null;
                    return typeInfo != null ? typeInfo.Type : null;
                }
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packetInspector != null);
        }

        #endregion
    }
}