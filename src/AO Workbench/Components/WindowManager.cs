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
    using System.Windows;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Controls;

    public class WindowManager : Caliburn.Micro.WindowManager
    {
        #region Methods

        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            var window = view as Window;
            if (window == null)
            {
                window = new DialogWindow { Content = view, SizeToContent = SizeToContent.WidthAndHeight };
                window.SetValue(View.IsGeneratedProperty, true);
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
                var owner = this.InferOwnerOf(window);
                if (owner != null && isDialog)
                {
                    window.Owner = owner;
                }
            }

            return window;
        }

        #endregion
    }
}