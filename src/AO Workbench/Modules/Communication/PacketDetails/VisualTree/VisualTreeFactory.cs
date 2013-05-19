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

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;

    using SmokeLounge.AOtomation.Messaging.Messages;
    using SmokeLounge.AOtomation.Messaging.Serialization;

    using ExtensionMethods = Caliburn.Micro.ExtensionMethods;

    [Export]
    public class VisualTreeFactory
    {
        #region Fields

        private readonly PropertyInfo[] headerPropertyInfos;

        private readonly PropertyInfo[] messagePropertyInfos;

        #endregion

        #region Constructors and Destructors

        public VisualTreeFactory()
        {
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

        public IVisualTree Create(PacketViewModel packet)
        {
            var hexDigits = this.CreateHexDigits(packet.Packet);

            var list = new List<IProperty>();
            if (packet.Message != null)
            {
                var headerProperties = this.CreateHeaderProperties(packet.Message, hexDigits);
                var bodyProperties = this.CreateProperties(packet.SerializationContext, hexDigits);

                var headerRoot = new PropertyViewModel(
                    this.messagePropertyInfos[0], 0, 16, packet.Message, hexDigits.Take(16));
                ExtensionMethods.Apply(headerProperties, headerRoot.AddProperty);

                var bodyRoot = new PropertyViewModel(
                    this.messagePropertyInfos[1], 16, packet.Packet.Length - 16, packet.Message, hexDigits.Skip(16));
                ExtensionMethods.Apply(bodyProperties, bodyRoot.AddProperty);

                list.Add(headerRoot);
                list.Add(bodyRoot);
            }

            var visualTree = new VisualTree(list, hexDigits);
            return visualTree;
        }

        #endregion

        #region Methods

        private IList<IProperty> CreateHeaderProperties(Message message, IList<IHexDigit> hexDigits)
        {
            var list = new List<IProperty>();
            if (message == null)
            {
                return list;
            }

            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[0], 0, 2, message.Header.MessageId, hexDigits.Skip(0).Take(2)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[1], 2, 2, message.Header.PacketType, hexDigits.Skip(2).Take(2)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[2], 4, 2, message.Header.Unknown, hexDigits.Skip(4).Take(2)));
            list.Add(
                new PropertyViewModel(this.headerPropertyInfos[3], 6, 2, message.Header.Size, hexDigits.Skip(6).Take(2)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[4], 8, 4, message.Header.Sender, hexDigits.Skip(8).Take(4)));
            list.Add(
                new PropertyViewModel(
                    this.headerPropertyInfos[5], 12, 4, message.Header.Receiver, hexDigits.Skip(12).Take(4)));

            return list;
        }

        private IList<IHexDigit> CreateHexDigits(byte[] packet)
        {
            return packet.Select(p => new HexDigitViewModel(p)).Cast<IHexDigit>().ToList();
        }

        private IList<IProperty> CreateProperties(SerializationContext serializationContext, IList<IHexDigit> hexDigits)
        {
            var list = new List<IProperty>();
            if (serializationContext == null)
            {
                return list;
            }

            var flatList = new List<IProperty>();

            foreach (var debugInfo in serializationContext.DebugInfos)
            {
                var propertyHexDigits = hexDigits.Skip((int)debugInfo.Offset).Take((int)debugInfo.Length);
                var property = new PropertyViewModel(
                    debugInfo.PropertyMetaData.Property, 
                    (int)debugInfo.Offset, 
                    (int)debugInfo.Length, 
                    debugInfo.Value, 
                    propertyHexDigits);

                var parent = (from p in flatList
                              where
                                  property.Offset >= p.Offset
                                  && (property.Offset + property.Length <= p.Offset + p.Length)
                              select p).LastOrDefault();

                flatList.Add(property);

                if (parent != null)
                {
                    parent.AddProperty(property);
                    continue;
                }

                list.Add(property);
            }

            return list;
        }

        #endregion
    }
}