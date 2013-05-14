// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NanosFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the NanosFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Nanos
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Models.Modules;

    [Export]
    public class NanosFactory : IAnchorableItemFactory<NanosViewModel>
    {
        #region Fields

        private readonly IEventAggregator events;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public NanosFactory(IEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(events != null);

            this.events = events;
        }

        #endregion

        #region Public Methods and Operators

        public NanosViewModel CreateItem(Guid processId)
        {
            return new NanosViewModel(this.events);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.events != null);
        }

        #endregion
    }
}