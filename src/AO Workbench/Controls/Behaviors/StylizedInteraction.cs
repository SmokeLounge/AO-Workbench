// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StylizedInteraction.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   http://stackoverflow.com/questions/1647815/how-to-add-a-blend-behavior-in-a-style-setter
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls.Behaviors
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows;
    using System.Windows.Interactivity;

    /// <summary>
    ///     http://stackoverflow.com/questions/1647815/how-to-add-a-blend-behavior-in-a-style-setter
    /// </summary>
    public static class StylizedInteraction
    {
        #region Static Fields

        public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.RegisterAttached(
            "Behaviors", 
            typeof(Behaviors), 
            typeof(StylizedInteraction), 
            new UIPropertyMetadata(null, OnPropertyBehaviorsChanged));

        public static readonly DependencyProperty TriggersProperty = DependencyProperty.RegisterAttached(
            "Triggers", 
            typeof(Triggers), 
            typeof(StylizedInteraction), 
            new UIPropertyMetadata(null, OnPropertyTriggersChanged));

        #endregion

        #region Public Methods and Operators

        public static Behaviors GetBehaviors(DependencyObject obj)
        {
            Contract.Requires<ArgumentNullException>(obj != null);

            return (Behaviors)obj.GetValue(BehaviorsProperty);
        }

        public static Triggers GetTriggers(DependencyObject obj)
        {
            Contract.Requires<ArgumentNullException>(obj != null);

            return (Triggers)obj.GetValue(TriggersProperty);
        }

        public static void SetBehaviors(DependencyObject obj, Behaviors value)
        {
            Contract.Requires<ArgumentNullException>(obj != null);

            obj.SetValue(BehaviorsProperty, value);
        }

        public static void SetTriggers(DependencyObject obj, Triggers value)
        {
            Contract.Requires<ArgumentNullException>(obj != null);

            obj.SetValue(TriggersProperty, value);
        }

        #endregion

        #region Methods

        private static void OnPropertyBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var styleBehaviors = e.NewValue as Behaviors;
            if (styleBehaviors == null)
            {
                return;
            }

            var behaviors = Interaction.GetBehaviors(d);
            if (behaviors == null)
            {
                return;
            }

            foreach (var behavior in styleBehaviors)
            {
                behaviors.Add(behavior);
            }
        }

        private static void OnPropertyTriggersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var styleTriggers = e.NewValue as Triggers;
            if (styleTriggers == null)
            {
                return;
            }

            var triggers = Interaction.GetTriggers(d);
            if (triggers == null)
            {
                return;
            }

            foreach (var trigger in styleTriggers)
            {
                triggers.Add(trigger);
            }
        }

        #endregion
    }
}