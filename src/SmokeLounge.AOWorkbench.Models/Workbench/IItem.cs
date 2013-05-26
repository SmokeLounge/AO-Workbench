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

namespace SmokeLounge.AOWorkbench.Models.Workbench
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Input;

    [ContractClass(typeof(IItemContract))]
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

    [ContractClassFor(typeof(IItem))]
    internal abstract class IItemContract : IItem
    {
        #region Public Properties

        public ICommand ActivateCommand { get; private set; }

        public bool CanClose { get; set; }

        public bool CanFloat { get; set; }

        public ICommand CloseAllButThisCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public string ContentId { get; set; }

        public ICommand DockAsDocumentCommand { get; private set; }

        public ICommand FloatCommand { get; private set; }

        public Uri IconSource { get; set; }

        public bool IsActive { get; set; }

        public bool IsSelected { get; set; }

        public ICommand MoveToNextTabGroupCommand { get; private set; }

        public ICommand MoveToPreviousTabGroupCommand { get; private set; }

        public ICommand NewHorizontalTabGroupCommand { get; private set; }

        public ICommand NewVerticalTabGroupCommand { get; private set; }

        public string Title { get; set; }

        public string ToolTip { get; set; }

        #endregion
    }
}