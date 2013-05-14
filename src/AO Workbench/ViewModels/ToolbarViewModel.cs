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
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Dynamic;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Models;
    using SmokeLounge.AoWorkbench.ViewModels.Dialogs;

    [Export(typeof(IToolbar))]
    public class ToolbarViewModel : Screen, IToolbar
    {
        #region Fields

        private readonly AttachToProcessFactory attachToProcessFactory;

        private readonly IWindowManager windowManager;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ToolbarViewModel(IWindowManager windowManager, AttachToProcessFactory attachToProcessFactory)
        {
            Contract.Requires<ArgumentNullException>(windowManager != null);
            Contract.Requires<ArgumentNullException>(attachToProcessFactory != null);

            this.windowManager = windowManager;
            this.attachToProcessFactory = attachToProcessFactory;
        }

        #endregion

        #region Public Methods and Operators

        public void AttachToProcess()
        {
            dynamic settings = new ExpandoObject();
            settings.MinWidth = 600;
            settings.MinHeight = 300;
            this.windowManager.ShowDialog(this.attachToProcessFactory.Create(), null, settings);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.windowManager != null);
            Contract.Invariant(this.attachToProcessFactory != null);
        }

        #endregion
    }
}