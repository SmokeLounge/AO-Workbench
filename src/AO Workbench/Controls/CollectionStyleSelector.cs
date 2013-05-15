// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionStyleSelector.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CollectionStyleSelector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public class CollectionStyleSelector : StyleSelector
    {
        #region Public Properties

        public StylePairCollection Styles { get; set; }

        #endregion

        #region Public Methods and Operators

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (this.Styles == null)
            {
                return base.SelectStyle(item, container);
            }

            var stylePair = this.Styles.FirstOrDefault(d => d.TargetType.IsInstanceOfType(item));
            return stylePair != null ? stylePair.Style : base.SelectStyle(item, container);
        }

        #endregion
    }
}