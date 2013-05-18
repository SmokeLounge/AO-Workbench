// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketDetailsDocumentItemViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketDetailsDocumentItemViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.ViewModels.Workbench;

    public class PacketDetailsDocumentItemViewModel : DocumentItemViewModel
    {
        #region Fields

        private readonly PacketDetailsViewModel packetDetails;

        #endregion

        #region Constructors and Destructors

        public PacketDetailsDocumentItemViewModel(PacketDetailsViewModel packetDetails, IEventAggregator events)
            : base(events)
        {
            Contract.Requires<ArgumentNullException>(packetDetails != null);
            Contract.Requires<ArgumentNullException>(events != null);

            this.packetDetails = packetDetails;
            this.Title = "Packet Details";
        }

        #endregion

        #region Public Properties

        public PacketDetailsViewModel PacketDetails
        {
            get
            {
                return this.packetDetails;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packetDetails != null);
        }

        #endregion
    }
}