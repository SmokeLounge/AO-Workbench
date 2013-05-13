// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DockingManagerLayoutItemContainerStyleSelector.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DockingManagerLayoutItemContainerStyleSelector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public class DockingManagerLayoutItemContainerStyleSelector : StyleSelector
    {
        #region Public Properties

        public Style AnchorableStyle { get; set; }

        public Type AnchorableType { get; set; }

        public Style DocumentStyle { get; set; }

        public Type DocumentType { get; set; }

        #endregion

        #region Public Methods and Operators

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item == null)
            {
                return null;
            }

            if (this.DocumentType != null)
            {
                if (this.DocumentType.IsInstanceOfType(item))
                {
                    return this.DocumentStyle;
                }
            }

            if (this.AnchorableType != null)
            {
                if (this.AnchorableType.IsInstanceOfType(item))
                {
                    return this.AnchorableStyle;
                }
            }

            return base.SelectStyle(item, container);
        }

        #endregion
    }
}