// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageSerializerService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessageSerializerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components.Services
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.IO;

    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    [Export(typeof(IMessageSerializerService))]
    public class MessageSerializerService : IMessageSerializerService
    {
        #region Fields

        private readonly MessageSerializer messageSerializer;

        #endregion

        #region Constructors and Destructors

        public MessageSerializerService()
        {
            this.messageSerializer = new MessageSerializer();
        }

        #endregion

        #region Public Methods and Operators

        public Message Deserialize(byte[] packet)
        {
            using (var memoryStream = new MemoryStream(packet))
            {
                var message = this.messageSerializer.Deserialize(memoryStream);
                if (message == null || message.Body == null || message.Header == null)
                {
                    throw new InvalidOperationException();
                }

                return message;
            }
        }

        public byte[] Serialize(Message message)
        {
            using (var memoryStream = new MemoryStream())
            {
                this.messageSerializer.Serialize(memoryStream, message);
                var buffer = memoryStream.GetBuffer();
                if (buffer == null || buffer.Length < 16)
                {
                    throw new InvalidOperationException();
                }

                return buffer;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.messageSerializer != null);
        }

        #endregion
    }
}