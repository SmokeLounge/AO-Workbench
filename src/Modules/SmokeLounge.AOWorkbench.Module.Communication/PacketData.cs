// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketData.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Module.Communication
{
    using System;

    public class PacketData
    {
        #region Public Properties

        public byte[] Packet { get; set; }

        public PacketDirection PacketDirection { get; set; }

        public DateTime Timestamp { get; set; }

        #endregion
    }
}