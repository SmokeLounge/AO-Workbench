// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketVisualizerViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketVisualizerViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.ViewModels.Workbench;

    public class PacketVisualizerViewModel : DocumentItemViewModel, 
                                             IHandleDomainEvent<PacketReceivedEvent>, 
                                             IHandleDomainEvent<PacketSentEvent>
    {
        #region Fields

        private readonly IObservableCollection<PacketViewModel> packets;

        private readonly IProcess process;

        #endregion

        #region Constructors and Destructors

        public PacketVisualizerViewModel(IProcess process, IEventAggregator events)
            : base(events)
        {
            this.process = process;
            Contract.Requires<ArgumentNullException>(process != null);
            Contract.Requires<ArgumentNullException>(events != null);

            this.packets = new BindableCollection<PacketViewModel>();

            Func<string> getTitle =
                () => "Packets: " + (this.process.Player != null ? this.process.Player.Name : this.process.DisplayName);
            this.Title = getTitle();
            PropertyChangedEventManager.AddHandler(
                this.process, (sender, args) => this.Title = getTitle(), string.Empty);
        }

        #endregion

        #region Public Properties

        public IObservableCollection<PacketViewModel> Packets
        {
            get
            {
                return this.packets;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(PacketReceivedEvent message)
        {
            if (message.ProcessId.Equals(this.process.Id) == false)
            {
                return;
            }

            var packet = new PacketViewModel(PacketDirection.Received, message.Packet);
            this.packets.Add(packet);
        }

        public void Handle(PacketSentEvent message)
        {
            if (message.ProcessId.Equals(this.process.Id) == false)
            {
                return;
            }

            var packet = new PacketViewModel(PacketDirection.Sent, message.Packet);
            this.packets.Add(packet);
        }

        #endregion
    }
}