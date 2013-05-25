// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertiesViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PropertiesViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.ViewModels.Workbench.Anchorables
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOWorkbench.Components.Workbench;

    public class PropertiesViewModel : AnchorableItemViewModel
    {
        #region Constructors and Destructors

        public PropertiesViewModel(IBus bus)
            : base(bus)
        {
            Contract.Requires<ArgumentNullException>(bus != null);

            this.Title = "Properties";
        }

        #endregion
    }
}