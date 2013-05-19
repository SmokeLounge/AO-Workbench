// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenPacketDetails.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IOpenPacketDetails type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.Document
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IOpenPacketDetailsContract))]
    public interface IOpenPacketDetails
    {
        #region Public Methods and Operators

        void OpenDetailsInNewTab(PacketViewModel packet);

        #endregion
    }

    [ContractClassFor(typeof(IOpenPacketDetails))]
    internal abstract class IOpenPacketDetailsContract : IOpenPacketDetails
    {
        #region Public Methods and Operators

        public void OpenDetailsInNewTab(PacketViewModel packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}