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

    using Message = SmokeLounge.AOtomation.Messaging.Messages.Message;

    public class PacketViewModel : PropertyChangedBase
    {
        #region Fields

        private readonly Message message;

        private readonly byte[] packet;

        private readonly PacketDirection packetDirection;

        private readonly DateTime timeStamp;

        #endregion

        #region Constructors and Destructors

        public PacketViewModel(PacketDirection packetDirection, byte[] packet, Message message)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            this.packetDirection = packetDirection;
            this.packet = packet;
            this.message = message;
            this.timeStamp = DateTime.Now;
        }

        #endregion

        #region Public Properties

        public Message Message
        {
            get
            {
                return this.message;
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
                if (this.message == null || this.message.Body == null)
                {
                    return "(Unknown)";
                }

                return this.message.Body.GetType().Name;
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
        }

        #endregion
    }
}