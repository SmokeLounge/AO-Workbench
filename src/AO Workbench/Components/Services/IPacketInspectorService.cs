// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketInspectorService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IPacketInspectorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components.Services
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IPacketInspectorServiceContract))]
    public interface IPacketInspectorService
    {
        #region Public Methods and Operators

        Type FindType(byte[] packet);

        #endregion
    }

    [ContractClassFor(typeof(IPacketInspectorService))]
    internal abstract class IPacketInspectorServiceContract : IPacketInspectorService
    {
        #region Public Methods and Operators

        public Type FindType(byte[] packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}