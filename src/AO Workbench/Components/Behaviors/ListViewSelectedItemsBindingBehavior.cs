// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewSelectedItemsBindingBehavior.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ListBoxSelectedItemsBindingBehavior type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components.Behaviors
{
    using System.Collections;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    public class ListBoxSelectedItemsBindingBehavior : Behavior<ListBox>
    {
        // Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        #region Static Fields

        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
            "SelectedItems", 
            typeof(INotifyCollectionChanged), 
            typeof(ListBoxSelectedItemsBindingBehavior), 
            new PropertyMetadata(OnSelectedItemsPropertyChanged));

        #endregion

        #region Fields

        private bool syncing;

        #endregion

        #region Public Properties

        public INotifyCollectionChanged SelectedItems
        {
            get
            {
                return (INotifyCollectionChanged)this.GetValue(SelectedItemsProperty);
            }

            set
            {
                this.SetValue(SelectedItemsProperty, value);
            }
        }

        #endregion

        #region Methods

        protected override void OnAttached()
        {
            base.OnAttached();

            if (this.AssociatedObject == null)
            {
                return;
            }

            var selectedItems = this.AssociatedObject.SelectedItems as INotifyCollectionChanged;
            if (selectedItems == null)
            {
                return;
            }

            selectedItems.CollectionChanged += this.ListBoxSelectedItemsCollectionChanged;
        }

        protected override void OnDetaching()
        {
            if (this.AssociatedObject == null)
            {
                return;
            }

            var selectedItems = this.AssociatedObject.SelectedItems as INotifyCollectionChanged;
            if (selectedItems != null)
            {
                selectedItems.CollectionChanged -= this.ListBoxSelectedItemsCollectionChanged;
            }

            base.OnDetaching();
        }

        private static void OnSelectedItemsPropertyChanged(
            DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var behavior = (ListBoxSelectedItemsBindingBehavior)target;
            var newValue = args.NewValue as INotifyCollectionChanged;
            if (newValue != null)
            {
                newValue.CollectionChanged += behavior.BehaviorSelectedItemsCollectionChanged;
            }

            var oldValue = args.OldValue as INotifyCollectionChanged;
            if (oldValue != null)
            {
                oldValue.CollectionChanged -= behavior.BehaviorSelectedItemsCollectionChanged;
            }
        }

        private void BehaviorSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.syncing)
            {
                return;
            }

            if (this.AssociatedObject == null)
            {
                return;
            }

            this.syncing = true;

            if (e.OldItems != null)
            {
                foreach (var oldItem in e.OldItems)
                {
                    Contract.Assume(this.AssociatedObject != null);
                    this.AssociatedObject.SelectedItems.Remove(oldItem);
                }
            }

            if (e.NewItems != null)
            {
                foreach (var newItem in e.NewItems)
                {
                    Contract.Assume(this.AssociatedObject != null);
                    this.AssociatedObject.SelectedItems.Add(newItem);
                }
            }

            this.syncing = false;
        }

        private void ListBoxSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.syncing)
            {
                return;
            }

            this.syncing = true;

            var behaviorSelectedItems = this.SelectedItems as IList;
            if (behaviorSelectedItems == null)
            {
                return;
            }

            if (e.OldItems != null)
            {
                foreach (var oldItem in e.OldItems)
                {
                    behaviorSelectedItems.Remove(oldItem);
                }
            }

            if (e.NewItems != null)
            {
                foreach (var newItem in e.NewItems)
                {
                    behaviorSelectedItems.Add(newItem);
                }
            }

            this.syncing = false;
        }

        #endregion
    }
}