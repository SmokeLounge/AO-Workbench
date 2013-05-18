// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   http://stackoverflow.com/questions/8480252/is-there-a-simple-way-to-have-a-listview-automatically-scroll-to-the-most-recent
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls.Behaviors
{
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    /// <summary>
    ///     http://stackoverflow.com/questions/8480252/is-there-a-simple-way-to-have-a-listview-automatically-scroll-to-the-most-recent
    /// </summary>
    public class AutoScrollToLastItemBehavior : Behavior<ListBox>
    {
        #region Static Fields

        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register(
            "IsEnabled", 
            typeof(bool), 
            typeof(AutoScrollToLastItemBehavior), 
            new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #region Public Properties

        public bool IsEnabled
        {
            get
            {
                return (bool)this.GetValue(IsEnabledProperty);
            }

            set
            {
                this.SetValue(IsEnabledProperty, value);
            }
        }

        #endregion

        #region Methods

        protected override void OnAttached()
        {
            base.OnAttached();
            var collection = this.AssociatedObject.Items.SourceCollection as INotifyCollectionChanged;
            if (collection != null)
            {
                collection.CollectionChanged += this.OnCollectionChanged;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            var collection = this.AssociatedObject.Items.SourceCollection as INotifyCollectionChanged;
            if (collection != null)
            {
                collection.CollectionChanged -= this.OnCollectionChanged;
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.IsEnabled == false)
            {
                return;
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                this.ScrollToLastItem();
            }
        }

        private void ScrollToLastItem()
        {
            var count = this.AssociatedObject.Items.Count;
            if (count > 0)
            {
                var last = this.AssociatedObject.Items[count - 1];
                this.AssociatedObject.ScrollIntoView(last);
            }
        }

        #endregion
    }
}