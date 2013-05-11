// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ToolbarViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels
{
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    [Export(typeof(IToolbar))]
    public class ToolbarViewModel : Screen, IToolbar
    {
        #region Public Methods and Operators

        public void AttachToProcess()
        {
        }

        #endregion
    }
}