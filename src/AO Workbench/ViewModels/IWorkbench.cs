// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWorkbench.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IWorkbench type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels
{
    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.ViewModels.Workbench;

    public interface IWorkbench : IScreen
    {
        #region Public Properties

        IItem ActiveContent { get; set; }

        IObservableCollection<IAnchorableItem> Anchorables { get; }

        IObservableCollection<IDocumentItem> Documents { get; }

        #endregion
    }
}