// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeListViewConverter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Represents a convert that can calculate the indentation of any element in a class derived from TreeView.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    ///     Represents a convert that can calculate the indentation of any element in a class derived from TreeView.
    /// </summary>
    public class TreeListViewConverter : IValueConverter
    {
        #region Constants

        public const double Indentation = 10;

        #endregion

        #region Public Methods and Operators

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If the value is null, don't return anything
            if (value == null)
            {
                return null;
            }

            // Convert the item to a double
            if (targetType == typeof(double) && value is DependencyObject)
            {
                // Cast the item as a DependencyObject
                var element = value as DependencyObject;

                // Create a level counter with value set to -1
                var level = -1;

                // Move up the visual tree and count the number of TreeViewItem's.
                for (; element != null; element = VisualTreeHelper.GetParent(element))
                {
                    // Check whether the current elemeent is a TreeViewItem
                    if (element is TreeViewItem)
                    {
                        // Increase the level counter
                        level++;
                    }
                }

                // Return the indentation as a double
                return Indentation * level;
            }

            // Type conversion is not supported
            throw new NotSupportedException(
                string.Format(
                    "Cannot convert from <{0}> to <{1}> using <TreeListViewConverter>.", value.GetType(), targetType));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("This method is not supported.");
        }

        #endregion
    }
}