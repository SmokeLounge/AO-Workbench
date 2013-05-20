// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisualTree.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the VisualTree type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.HexView;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.PropertyView;

    public class VisualTree : IVisualTree
    {
        #region Fields

        private readonly IList<IHexDigit> hexDigits;

        private readonly IList<IProperty> properties;

        #endregion

        #region Constructors and Destructors

        public VisualTree(IList<IProperty> properties, IList<IHexDigit> hexDigits)
        {
            Contract.Requires<ArgumentNullException>(properties != null);
            Contract.Requires<ArgumentNullException>(hexDigits != null);

            this.properties = properties;
            this.hexDigits = hexDigits;
        }

        #endregion

        #region Public Properties

        public IReadOnlyCollection<IHexDigit> HexDigits
        {
            get
            {
                return this.hexDigits.ToArray();
            }
        }

        public IReadOnlyCollection<IProperty> Properties
        {
            get
            {
                return this.properties.ToArray();
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.hexDigits != null);
            Contract.Invariant(this.properties != null);
        }

        #endregion
    }
}