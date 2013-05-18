// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageSerializerService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IMessageSerializerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components.Services
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Messaging.Messages;

    [ContractClass(typeof(IMessageSerializerServiceContract))]
    public interface IMessageSerializerService
    {
        #region Public Methods and Operators

        Message Deserialize(byte[] packet);

        byte[] Serialize(Message message);

        #endregion
    }

    [ContractClassFor(typeof(IMessageSerializerService))]
    internal abstract class IMessageSerializerServiceContract : IMessageSerializerService
    {
        #region Public Methods and Operators

        public Message Deserialize(byte[] packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);
            Contract.Requires<ArgumentNullException>(packet.Length >= 16);
            Contract.Ensures(Contract.Result<Message>() != null);
            Contract.Ensures(Contract.Result<Message>().Header != null);
            Contract.Ensures(Contract.Result<Message>().Body != null);

            throw new NotImplementedException();
        }

        public byte[] Serialize(Message message)
        {
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(message.Header != null);
            Contract.Requires<ArgumentNullException>(message.Body != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            Contract.Ensures(Contract.Result<byte[]>().Length >= 16);

            throw new NotImplementedException();
        }

        #endregion
    }
}