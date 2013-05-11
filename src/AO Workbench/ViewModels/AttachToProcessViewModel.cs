// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachToProcessViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AttachToProcessViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels
{
    using Caliburn.Micro;

    public class AttachToProcessViewModel : Screen
    {
        #region Methods

        protected override void OnInitialize()
        {
            this.DisplayName = "Attach to Process";

            base.OnInitialize();
        }

        #endregion
    }
}