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
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AoWorkbench.Components.Services;

    [Export]
    public class PacketFactory
    {
        #region Fields

        private readonly IMessageSerializerService messageSerializerService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketFactory(IMessageSerializerService messageSerializerService)
        {
            Contract.Requires<ArgumentNullException>(messageSerializerService != null);

            this.messageSerializerService = messageSerializerService;
        }

        #endregion

        #region Public Methods and Operators

        public PacketViewModel Create(PacketDirection packetDirection, byte[] packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);
            Contract.Ensures(Contract.Result<PacketViewModel>() != null);

            Message message = null;
            SerializationContext serializationContext = null;
            try
            {
                message = this.messageSerializerService.Deserialize(packet, out serializationContext);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new PacketViewModel(packetDirection, packet, message, serializationContext);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.messageSerializerService != null);
        }

        #endregion
    }
}