// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisualTreeFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the VisualTreeFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Module.Communication.PacketDetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Reflection;

    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization;
    using SmokeLounge.AOWorkbench.Components.Services;
    using SmokeLounge.AOWorkbench.Module.Communication.PacketDetails.PropertyView;

    [Export]
    public class VisualTreeFactory
    {
        #region Fields

        private readonly PropertyInfo[] headerPropertyInfos;

        private readonly PropertyInfo[] messagePropertyInfos;

        private readonly IMessageSerializerService messageSerializerService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public VisualTreeFactory(IMessageSerializerService messageSerializerService)
        {
            Contract.Requires<ArgumentNullException>(messageSerializerService != null);

            this.messageSerializerService = messageSerializerService;

            this.headerPropertyInfos = new PropertyInfo[6];
            var headerType = typeof(Header);
            this.headerPropertyInfos[0] = headerType.GetProperty("MessageId");
            this.headerPropertyInfos[1] = headerType.GetProperty("PacketType");
            this.headerPropertyInfos[2] = headerType.GetProperty("Unknown");
            this.headerPropertyInfos[3] = headerType.GetProperty("Size");
            this.headerPropertyInfos[4] = headerType.GetProperty("Sender");
            this.headerPropertyInfos[5] = headerType.GetProperty("Receiver");

            this.messagePropertyInfos = new PropertyInfo[2];
            var messageType = typeof(Message);
            this.messagePropertyInfos[0] = messageType.GetProperty("Header");
            this.messagePropertyInfos[1] = messageType.GetProperty("Body");
        }

        #endregion

        #region Public Methods and Operators

        public IEnumerable<IProperty> Create(PacketViewModel packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            Message message = null;
            SerializationContext serializationContext = null;
            try
            {
                message = this.messageSerializerService.Deserialize(packet.Packet, out serializationContext);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("bork: Deserialization fail!: " + ex.Message);
            }

            var list = new List<IProperty>();
            if (message != null)
            {
                var headerProperties = this.CreateHeaderProperties(message, packet.Packet);
                var bodyProperties = this.CreateProperties(serializationContext, packet.Packet);

                var headerRoot = new PropertyViewModel(
                    this.messagePropertyInfos[0], 0, 16, message, new ArraySegment<byte>(packet.Packet, 0, 16));
                foreach (var property in headerProperties)
                {
                    headerRoot.AddProperty(property);
                }

                var bodyRoot = new PropertyViewModel(
                    this.messagePropertyInfos[1], 
                    16, 
                    packet.Packet.Length - 16, 
                    message, 
                    new ArraySegment<byte>(packet.Packet, 16, packet.Packet.Length - 16));
                foreach (var property in bodyProperties)
                {
                    bodyRoot.AddProperty(property);
                }

                list.Add(headerRoot);
                list.Add(bodyRoot);
            }

            return list;
        }

        #endregion

        #region Methods

        private IEnumerable<IProperty> CreateHeaderProperties(Message message, byte[] packet)
        {
            var list = new List<IProperty>();
            if (message == null || message.Header == null || packet == null)
            {
                return list;
            }

            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[0], 0, 2, message.Header.MessageId, new ArraySegment<byte>(packet, 0, 2)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[1], 2, 2, message.Header.PacketType, new ArraySegment<byte>(packet, 2, 2)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[2], 4, 2, message.Header.Unknown, new ArraySegment<byte>(packet, 4, 2)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[3], 6, 2, message.Header.Size, new ArraySegment<byte>(packet, 6, 2)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[4], 8, 4, message.Header.Sender, new ArraySegment<byte>(packet, 8, 4)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[5], 12, 4, message.Header.Receiver, new ArraySegment<byte>(packet, 12, 4)));

            return list;
        }

        private IEnumerable<IProperty> CreateProperties(SerializationContext serializationContext, byte[] packet)
        {
            var list = new List<IProperty>();
            if (serializationContext == null || serializationContext.DiagnosticInfos == null)
            {
                return list;
            }

            foreach (var diagnosticInfo in serializationContext.DiagnosticInfos)
            {
                Contract.Assume(diagnosticInfo != null);
                Contract.Assume(diagnosticInfo.PropertyMetaData != null);
                var current = Tuple.Create(diagnosticInfo, this.CreateProperty(diagnosticInfo, packet));
                list.Add(current.Item2);
                var queue = new Queue<Tuple<DiagnosticInfo, IProperty>>();
                do
                {
                    foreach (var di in current.Item1.DiagnosticInfos)
                    {
                        var p = Tuple.Create(di, this.CreateProperty(di, packet));
                        current.Item2.AddProperty(p.Item2);
                        queue.Enqueue(p);
                    }

                    current = queue.Count > 0 ? queue.Dequeue() : null;
                }
                while (current != null);
            }

            return list;
        }

        private IProperty CreateProperty(DiagnosticInfo diagnosticInfo, byte[] packet)
        {
            Contract.Requires(diagnosticInfo != null);
            Contract.Requires(diagnosticInfo.PropertyMetaData != null);

            var propertyHexDigits = new ArraySegment<byte>(
                packet, (int)diagnosticInfo.Offset, (int)diagnosticInfo.Length);
            var property = new PropertyViewModel(
                diagnosticInfo.PropertyMetaData.Property, 
                (int)diagnosticInfo.Offset, 
                (int)diagnosticInfo.Length, 
                diagnosticInfo.Value, 
                propertyHexDigits);
            return property;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.headerPropertyInfos != null);
            Contract.Invariant(this.headerPropertyInfos.Length == 6);
            Contract.Invariant(this.messagePropertyInfos != null);
            Contract.Invariant(this.messagePropertyInfos.Length == 2);
            Contract.Invariant(this.messageSerializerService != null);
        }

        #endregion
    }
}