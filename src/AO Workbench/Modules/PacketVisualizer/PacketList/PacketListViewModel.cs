// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketListViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketListViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketList
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AoWorkbench.Components.Services;
    using SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails.Document;

    using Message = SmokeLounge.AOtomation.Messaging.Messages.Message;

    public class PacketListViewModel : PropertyChangedBase, 
                                       IHandleDomainEvent<PacketReceivedEvent>, 
                                       IHandleDomainEvent<PacketSentEvent>
    {
        #region Fields

        private readonly IMessageSerializerService messageSerializerService;

        private readonly IOpenPacketDetails openPacketDetails;

        private readonly PacketFactory packetFactory;

        private readonly IObservableCollection<PacketViewModel> packets;

        private readonly Guid processId;

        private bool autoScroll;

        private PacketViewModel selectedPacket;

        #endregion

        #region Constructors and Destructors

        public PacketListViewModel(
            Guid processId, 
            IMessageSerializerService messageSerializerService, 
            PacketFactory packetFactory, 
            IOpenPacketDetails openPacketDetails)
        {
            Contract.Requires<ArgumentNullException>(messageSerializerService != null);
            Contract.Requires<ArgumentNullException>(packetFactory != null);
            Contract.Requires<ArgumentNullException>(openPacketDetails != null);

            this.processId = processId;
            this.messageSerializerService = messageSerializerService;
            this.packetFactory = packetFactory;
            this.openPacketDetails = openPacketDetails;

            this.packets = new BindableCollection<PacketViewModel>();
        }

        #endregion

        #region Public Properties

        public bool AutoScroll
        {
            get
            {
                return this.autoScroll;
            }

            set
            {
                if (value.Equals(this.autoScroll))
                {
                    return;
                }

                this.autoScroll = value;
                this.NotifyOfPropertyChange();
            }
        }

        public IObservableCollection<PacketViewModel> Packets
        {
            get
            {
                return this.packets;
            }
        }

        public PacketViewModel SelectedPacket
        {
            get
            {
                return this.selectedPacket;
            }

            set
            {
                if (Equals(value, this.selectedPacket))
                {
                    return;
                }

                this.selectedPacket = value;
                this.NotifyOfPropertyChange();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Add(PacketDirection packetDirection, byte[] messagePacket)
        {
            Contract.Requires<ArgumentNullException>(messagePacket != null);

            if (messagePacket.Length < 16)
            {
                return;
            }

            Message message = null;
            try
            {
                message = this.messageSerializerService.Deserialize(messagePacket);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            var packet = this.packetFactory.Create(packetDirection, messagePacket, message);
            this.packets.Add(packet);
        }

        public void Clear()
        {
            this.packets.Clear();
        }

        public void Handle(PacketReceivedEvent message)
        {
            if (message.ProcessId.Equals(this.processId) == false)
            {
                return;
            }

            this.Add(PacketDirection.Received, message.Packet);
        }

        public void Handle(PacketSentEvent message)
        {
            if (message.ProcessId.Equals(this.processId) == false)
            {
                return;
            }

            this.Add(PacketDirection.Sent, message.Packet);
        }

        public void OpenDetails(PacketViewModel packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            this.openPacketDetails.OpenDetailsInNewTab(packet);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.messageSerializerService != null);
            Contract.Invariant(this.openPacketDetails != null);
            Contract.Invariant(this.packetFactory != null);
            Contract.Invariant(this.packets != null);
        }

        #endregion
    }
}