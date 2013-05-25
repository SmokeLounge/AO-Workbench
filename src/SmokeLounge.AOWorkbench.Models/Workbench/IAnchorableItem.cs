// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnchorableItem.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IAnchorableItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Workbench
{
    using System.Windows.Input;

    public interface IAnchorableItem : IItem
    {
        #region Public Properties

        ICommand AutoHideCommand { get; }

        bool CanHide { get; set; }

        ICommand DockCommand { get; }

        ICommand HideCommand { get; }

        #endregion
    }
}