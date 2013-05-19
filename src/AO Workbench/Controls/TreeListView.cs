// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeListView.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Represents a control that displays hierarchical data in a tree structure
//   that has items that can expand and collapse.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    ///     Represents a control that displays hierarchical data in a tree structure
    ///     that has items that can expand and collapse.
    /// </summary>
    public class TreeListView : TreeView
    {
        // Using a DependencyProperty as the backing store for AllowsColumnReorder.  This enables animation, styling, binding, etc...
        #region Static Fields

        public static readonly DependencyProperty AllowsColumnReorderProperty =
            DependencyProperty.Register(
                "AllowsColumnReorder", typeof(bool), typeof(TreeListView), new UIPropertyMetadata(null));

        // Using a DependencyProperty as the backing store for Columns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
            "Columns", typeof(GridViewColumnCollection), typeof(TreeListView), new UIPropertyMetadata(null));

        #endregion

        #region Constructors and Destructors

        static TreeListView()
        {
            // Override the default style and the default control template
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TreeListView" /> class.
        ///     Initialize a new instance of TreeListView.
        /// </summary>
        public TreeListView()
        {
            this.Columns = new GridViewColumnCollection();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets whether columns in a TreeListView can be
        ///     reordered by a drag-and-drop operation. This is a dependency property.
        /// </summary>
        public bool AllowsColumnReorder
        {
            get
            {
                return (bool)this.GetValue(AllowsColumnReorderProperty);
            }

            set
            {
                this.SetValue(AllowsColumnReorderProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the collection of System.Windows.Controls.GridViewColumn
        ///     objects that is defined for this TreeListView.
        /// </summary>
        public GridViewColumnCollection Columns
        {
            get
            {
                return (GridViewColumnCollection)this.GetValue(ColumnsProperty);
            }

            set
            {
                this.SetValue(ColumnsProperty, value);
            }
        }

        #endregion
    }
}