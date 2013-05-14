// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NcuViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the NcuViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Ncu
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.ViewModels.Workbench;

    public class NcuViewModel : AnchorableItemViewModel
    {
        #region Constructors and Destructors

        public NcuViewModel(IEventAggregator events)
            : base(events)
        {
            Contract.Requires<ArgumentNullException>(events != null);

            this.Title = "NCU";
        }

        #endregion
    }
}