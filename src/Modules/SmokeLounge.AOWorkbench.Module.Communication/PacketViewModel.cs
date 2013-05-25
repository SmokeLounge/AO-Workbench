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

namespace SmokeLounge.AOWorkbench.Module.Communication
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    public class PacketViewModel : PropertyChangedBase
    {
        #region Fields

        private readonly byte[] packet;

        private readonly PacketDirection packetDirection;

        private readonly Type packetType;

        private readonly DateTime timeStamp;

        #endregion

        #region Constructors and Destructors

        public PacketViewModel(PacketDirection packetDirection, byte[] packet, Type packetType)
        {
            Contract.Requires<ArgumentNullException>(packet != null);
            Contract.Requires<ArgumentNullException>(packet.Length >= 16);

            this.packetDirection = packetDirection;
            this.packet = packet;
            this.packetType = packetType;
            this.timeStamp = DateTime.Now;
        }

        #endregion

        #region Public Properties

        public byte[] Packet
        {
            get
            {
                Contract.Ensures(Contract.Result<byte[]>().Length >= 16);

                return this.packet;
            }
        }

        public PacketDirection PacketDirection
        {
            get
            {
                return this.packetDirection;
            }
        }

        public string PacketDirectionText
        {
            get
            {
                switch (this.packetDirection)
                {
                    case PacketDirection.Sent:
                        return "Sent";
                    case PacketDirection.Received:
                        return "Received";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string PacketTypeText
        {
            get
            {
                return this.packetType == null ? "(Unknown)" : this.packetType.Name;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
        }

        public string TimeStampText
        {
            get
            {
                return string.Format("{0}.{1}", this.timeStamp.ToLongTimeString(), this.timeStamp.Millisecond);
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packet != null);
            Contract.Invariant(this.packet.Length >= 16);
        }

        #endregion
    }
}