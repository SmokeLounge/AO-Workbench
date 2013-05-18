// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketDetailsViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketDetailsViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Components.Services;

    public class PacketDetailsViewModel : PropertyChangedBase
    {
        #region Fields

        private readonly ITextSerializerService textSerializerService;

        private PacketViewModel packet;

        #endregion

        #region Constructors and Destructors

        public PacketDetailsViewModel(ITextSerializerService textSerializerService)
        {
            Contract.Requires<ArgumentNullException>(textSerializerService != null);

            this.textSerializerService = textSerializerService;
        }

        #endregion

        #region Public Properties

        public PacketViewModel Packet
        {
            get
            {
                return this.packet;
            }

            set
            {
                if (Equals(value, this.packet))
                {
                    return;
                }

                this.packet = value;
                this.NotifyOfPropertyChange();
                this.NotifyOfPropertyChange(() => this.MessageText);
            }
        }

        public string MessageText
        {
            get
            {
                if (this.packet == null || this.packet.Message == null)
                {
                    return null;
                }

                return this.textSerializerService.Serialize(this.packet.Message);
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.textSerializerService != null);
        }

        #endregion
    }
}