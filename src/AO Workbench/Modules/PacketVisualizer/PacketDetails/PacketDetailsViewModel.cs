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

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails.HexView;
    using SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails.PropertyView;

    public class PacketDetailsViewModel : PropertyChangedBase
    {
        #region Fields

        private readonly HexViewViewModel hexViewViewV;

        private readonly PropertyViewViewModel propertyView;

        private PacketViewModel packet;

        #endregion

        #region Constructors and Destructors

        public PacketDetailsViewModel(PropertyViewViewModel propertyView, HexViewViewModel hexViewViewV)
        {
            Contract.Requires<ArgumentNullException>(propertyView != null);
            Contract.Requires<ArgumentNullException>(hexViewViewV != null);

            this.propertyView = propertyView;
            this.hexViewViewV = hexViewViewV;
        }

        #endregion

        #region Public Properties

        public HexViewViewModel HexView
        {
            get
            {
                return this.hexViewViewV;
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
            Contract.Invariant(this.hexViewViewV != null);
            Contract.Invariant(this.propertyView != null);
        }

        #endregion
    }
}