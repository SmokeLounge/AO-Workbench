// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowManager.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the WindowManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Windows;

    using Caliburn.Micro;

    using MahApps.Metro.Controls;

    using SmokeLounge.AoWorkbench.Controls;

    [Export(typeof(IWindowManager))]
    public class WindowManager : Caliburn.Micro.WindowManager
    {
        #region Fields

        private readonly IThemeManager themeManager;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public WindowManager(IThemeManager themeManager)
        {
            Contract.Requires<ArgumentNullException>(themeManager != null);

            this.themeManager = themeManager;
        }

        #endregion

        #region Methods

        protected override Window CreateWindow(
            object rootModel, bool isDialog, object context, IDictionary<string, object> settings)
        {
            var window = base.CreateWindow(rootModel, isDialog, context, settings);

            if (Math.Abs(window.MinHeight - 0) > double.Epsilon && double.IsNaN(window.Height))
            {
                window.Height = window.MinHeight;
            }

            if (Math.Abs(window.MinWidth - 0) > double.Epsilon && double.IsNaN(window.Width))
            {
                window.Width = window.MinWidth;
            }

            return window;
        }

        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            var window = view as MetroWindow;
            if (window == null)
            {
                window = new MetroWindow { Content = view, };
                window.SetValue(View.IsGeneratedProperty, true);
                window.Resources.MergedDictionaries.Add(this.themeManager.GetThemeResources());

                var owner = this.InferOwnerOf(window);
                if (owner != null)
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    window.Owner = owner;
                }
                else
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }
            }
            else
            {
                var owner2 = this.InferOwnerOf(window);
                if (owner2 != null && isDialog)
                {
                    window.Owner = owner2;
                }
            }

            return window;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.themeManager != null);
        }

        #endregion
    }
}