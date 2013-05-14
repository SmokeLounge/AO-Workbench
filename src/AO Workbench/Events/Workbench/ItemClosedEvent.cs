// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemClosedEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ItemClosedEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Events.Workbench
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Workbench;

    public class ItemClosedEvent
    {
        #region Fields

        private readonly IItem item;

        #endregion

        #region Constructors and Destructors

        public ItemClosedEvent(IItem item)
        {
            Contract.Requires<ArgumentNullException>(item != null);

            this.item = item;
        }

        #endregion

        #region Public Properties

        public IItem Item
        {
            get
            {
                return this.item;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.item != null);
        }

        #endregion
    }
}