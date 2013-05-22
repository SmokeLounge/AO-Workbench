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

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.HexView;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.PropertyView;

    [Export]
    public class PacketDetailsFactory
    {
        #region Fields

        private readonly HexViewFactory hexViewFactory;

        private readonly PropertyViewFactory propertyViewFactory;

        private readonly VisualTreeFactory visualTreeFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PacketDetailsFactory(
            PropertyViewFactory propertyViewFactory, HexViewFactory hexViewFactory, VisualTreeFactory visualTreeFactory)
        {
            Contract.Requires<ArgumentNullException>(propertyViewFactory != null);
            Contract.Requires<ArgumentNullException>(hexViewFactory != null);
            Contract.Requires<ArgumentNullException>(visualTreeFactory != null);

            this.propertyViewFactory = propertyViewFactory;
            this.hexViewFactory = hexViewFactory;
            this.visualTreeFactory = visualTreeFactory;
        }

        #endregion

        #region Public Methods and Operators

        public PacketDetailsViewModel Create()
        {
            Contract.Ensures(Contract.Result<PacketDetailsViewModel>() != null);

            return new PacketDetailsViewModel(
                this.propertyViewFactory.Create(), this.hexViewFactory.Create(), this.visualTreeFactory);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.hexViewFactory != null);
            Contract.Invariant(this.propertyViewFactory != null);
            Contract.Invariant(this.visualTreeFactory != null);
        }

        #endregion
    }
}