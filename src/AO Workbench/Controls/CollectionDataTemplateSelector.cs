// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionDataTemplateSelector.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CollectionDataTemplateSelector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public class CollectionDataTemplateSelector : DataTemplateSelector
    {
        #region Public Properties

        public DataTemplatePairCollection Templates { get; set; }

        #endregion

        #region Public Methods and Operators

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (this.Templates == null)
            {
                return base.SelectTemplate(item, container);
            }

            var dataTemplatePair = this.Templates.FirstOrDefault(d => d.DataType.IsInstanceOfType(item));
            return dataTemplatePair != null ? dataTemplatePair.DataTemplate : base.SelectTemplate(item, container);
        }

        #endregion
    }
}