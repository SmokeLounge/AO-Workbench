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

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.HexView;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.PropertyView;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree;

    public class PacketDetailsViewModel : PropertyChangedBase
    {
        #region Fields

        private readonly HexViewViewModel hexView;

        private readonly PropertyViewViewModel propertyView;

        private readonly VisualTreeFactory visualTreeFactory;

        private PacketViewModel packet;

        #endregion

        #region Constructors and Destructors

        public PacketDetailsViewModel(
            PropertyViewViewModel propertyView, HexViewViewModel hexView, VisualTreeFactory visualTreeFactory)
        {
            Contract.Requires<ArgumentNullException>(propertyView != null);
            Contract.Requires<ArgumentNullException>(hexView != null);
            Contract.Requires<ArgumentNullException>(visualTreeFactory != null);

            this.propertyView = propertyView;
            this.hexView = hexView;
            this.visualTreeFactory = visualTreeFactory;

            PropertyChangedEventManager.AddHandler(
                this.propertyView, (sender, args) => { this.PropertyViewSelectedPropertyChanged(); }, "SelectedProperty");
        }

        #endregion

        #region Public Properties

        public HexViewViewModel HexView
        {
            get
            {
                return this.hexView;
            }
        }

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
                this.OnPacketChanged();
                this.NotifyOfPropertyChange();
            }
        }

        public PropertyViewViewModel PropertyView
        {
            get
            {
                return this.propertyView;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.hexView != null);
            Contract.Invariant(this.propertyView != null);
            Contract.Invariant(this.visualTreeFactory != null);
        }

        private void OnPacketChanged()
        {
            if (this.packet == null || this.packet.Packet.Length < 16)
            {
                this.hexView.HexDigits = null;
                this.propertyView.Properties = null;
                return;
            }

            var visualTree = this.visualTreeFactory.Create(this.packet);
            this.hexView.HexDigits = visualTree.HexDigits;
            this.propertyView.Properties = visualTree.Properties;
        }

        private void PropertyViewSelectedPropertyChanged()
        {
            if (this.propertyView.SelectedProperty == null)
            {
                this.hexView.SetSelectedItems(null);
                return;
            }

            this.hexView.SetSelectedItems(this.propertyView.SelectedProperty.HexDigits);
        }

        #endregion
    }
}