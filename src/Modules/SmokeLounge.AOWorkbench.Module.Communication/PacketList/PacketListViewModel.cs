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

namespace SmokeLounge.AOWorkbench.Module.Communication.PacketList
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AOWorkbench.DataAccess;
    using SmokeLounge.AOWorkbench.Module.Communication.PacketDetails.Document;

    public class PacketListViewModel : PropertyChangedBase, 
                                       IHandleMessage<PacketReceivedEvent>, 
                                       IHandleMessage<PacketSentEvent>
    {
        #region Fields

        private readonly IDataSource dataSource;

        private readonly IOpenPacketDetails openPacketDetails;

        private readonly PacketFactory packetFactory;

        private readonly IObservableCollection<PacketViewModel> packets;

        private readonly Guid processId;

        private bool autoScroll;

        private PacketViewModel selectedPacket;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketListViewModel(
            Guid processId, PacketFactory packetFactory, IOpenPacketDetails openPacketDetails, IDataSource dataSource)
        {
            Contract.Requires<ArgumentNullException>(packetFactory != null);
            Contract.Requires<ArgumentNullException>(openPacketDetails != null);
            Contract.Requires<ArgumentNullException>(dataSource != null);

            this.processId = processId;
            this.packetFactory = packetFactory;
            this.openPacketDetails = openPacketDetails;
            this.dataSource = dataSource;

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

            var packetData = new PacketData
                                 {
                                     Packet = messagePacket, 
                                     PacketDirection = packetDirection, 
                                     Timestamp = DateTime.Now
                                 };
            var dataAdapter = this.dataSource.GetDataAdapter<PacketData>();
            dataAdapter.Save(new Data<PacketData>(packetData));
            var packet = this.packetFactory.Create(packetDirection, messagePacket);
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
            Contract.Invariant(this.dataSource != null);
            Contract.Invariant(this.openPacketDetails != null);
            Contract.Invariant(this.packetFactory != null);
            Contract.Invariant(this.packets != null);
        }

        #endregion
    }
}