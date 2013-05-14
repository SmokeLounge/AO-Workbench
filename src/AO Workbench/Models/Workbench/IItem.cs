// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItem.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Models.Workbench
{
    using System;
    using System.Windows.Input;

    public interface IItem
    {
        #region Public Properties

        ICommand ActivateCommand { get; }

        bool CanClose { get; set; }

        bool CanFloat { get; set; }

        ICommand CloseAllButThisCommand { get; }

        ICommand CloseCommand { get; }

        string ContentId { get; set; }

        ICommand DockAsDocumentCommand { get; }

        ICommand FloatCommand { get; }

        Uri IconSource { get; set; }

        bool IsActive { get; set; }

        bool IsSelected { get; set; }

        ICommand MoveToNextTabGroupCommand { get; }

        ICommand MoveToPreviousTabGroupCommand { get; }

        ICommand NewHorizontalTabGroupCommand { get; }

        ICommand NewVerticalTabGroupCommand { get; }

        string Title { get; set; }

        string ToolTip { get; set; }

        #endregion
    }
}