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
    using System.Windows;

    using Caliburn.Micro;

    using MahApps.Metro.Controls;

    public class WindowManager : Caliburn.Micro.WindowManager
    {
        #region Static Fields

        private static readonly ResourceDictionary[] Resources = InitializeResources();

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
                foreach (var resourceDictionary in Resources)
                {
                    window.Resources.MergedDictionaries.Add(resourceDictionary);
                }

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
                var owner2 = this.InferOwnerOf(window);
                if (owner2 != null && isDialog)
                {
                    window.Owner = owner2;
                }
            }

            return window;
        }

        private static ResourceDictionary[] InitializeResources()
        {
            var resources = new[]
                                {
                                    new ResourceDictionary
                                        {
                                            Source =
                                                new Uri(
                                                "pack://application:,,,/MahApps.Metro;component/Styles/Colours.xaml", 
                                                UriKind.RelativeOrAbsolute)
                                        }, 
                                    new ResourceDictionary
                                        {
                                            Source =
                                                new Uri(
                                                "pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml", 
                                                UriKind.RelativeOrAbsolute)
                                        }, 
                                    new ResourceDictionary
                                        {
                                            Source =
                                                new Uri(
                                                "pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml", 
                                                UriKind.RelativeOrAbsolute)
                                        }, 
                                    new ResourceDictionary
                                        {
                                            Source =
                                                new Uri(
                                                "pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml", 
                                                UriKind.RelativeOrAbsolute)
                                        }, 
                                    new ResourceDictionary
                                        {
                                            Source =
                                                new Uri(
                                                "pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml", 
                                                UriKind.RelativeOrAbsolute)
                                        }, 
                                    new ResourceDictionary
                                        {
                                            Source =
                                                new Uri(
                                                "pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedTabControl.xaml", 
                                                UriKind.RelativeOrAbsolute)
                                        }
                                };
            return resources;
        }

        #endregion
    }
}