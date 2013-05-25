﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DialogWindow.xaml.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DialogWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Controls
{
    using System;

    public partial class DialogWindow
    {
        #region Constructors and Destructors

        public DialogWindow()
        {
            this.InitializeComponent();
            this.Activated += this.OnActivated;
        }

        #endregion

        #region Methods

        private void OnActivated(object sender, EventArgs eventArgs)
        {
            this.Activated -= this.OnActivated;
            this.InvalidateArrange();
        }

        #endregion
    }
}