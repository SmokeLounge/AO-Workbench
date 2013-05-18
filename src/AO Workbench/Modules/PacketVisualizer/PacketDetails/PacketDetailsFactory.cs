// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketDetailsFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketDetailsFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Components.Services;

    [Export]
    public class PacketDetailsFactory
    {
        #region Fields

        private readonly ITextSerializerService textSerializerService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketDetailsFactory(ITextSerializerService textSerializerService)
        {
            Contract.Requires<ArgumentNullException>(textSerializerService != null);

            this.textSerializerService = textSerializerService;
        }

        #endregion

        #region Public Methods and Operators

        public PacketDetailsViewModel Create()
        {
            Contract.Ensures(Contract.Result<PacketDetailsViewModel>() != null);

            return new PacketDetailsViewModel(this.textSerializerService);
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