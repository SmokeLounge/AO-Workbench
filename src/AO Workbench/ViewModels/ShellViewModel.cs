// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ShellViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    [Export(typeof(IShell))]
    public class ShellViewModel : Screen, IShell
    {
        #region Fields

        private readonly IToolbar toolbar;

        private readonly IWorkbench workbench;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ShellViewModel(IToolbar toolbar, IWorkbench workbench)
        {
            Contract.Requires(toolbar != null);
            Contract.Requires(workbench != null);

            this.toolbar = toolbar;
            this.workbench = workbench;
        }

        #endregion

        #region Public Properties

        public IToolbar Toolbar
        {
            get
            {
                return this.toolbar;
            }
        }

        public IWorkbench Workbench
        {
            get
            {
                return this.workbench;
            }
        }

        #endregion

        #region Methods

        protected override void OnInitialize()
        {
            this.DisplayName = "AO Workbench";

            this.toolbar.ConductWith(this);
            this.workbench.ConductWith(this);

            base.OnInitialize();
        }

        #endregion
    }
}