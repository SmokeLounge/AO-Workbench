// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    public class PacketViewModel : PropertyChangedBase
    {
        #region Fields

        private readonly byte[] packet;

        private readonly PacketDirection packetDirection;

        #endregion

        #region Constructors and Destructors

        public PacketViewModel(PacketDirection packetDirection, byte[] packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            this.packetDirection = packetDirection;
            this.packet = packet;
        }

        #endregion
    }
}