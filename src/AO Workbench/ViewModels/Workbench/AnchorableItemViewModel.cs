// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnchorableItemViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AnchorableItemViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Workbench
{
    using System.Windows.Input;

    public abstract class AnchorableItemViewModel : ItemViewModel, IAnchorableItem
    {
        #region Fields

        private bool canHide;

        #endregion

        #region Public Properties

        public ICommand AutoHideCommand { get; private set; }

        public bool CanHide
        {
            get
            {
                return this.canHide;
            }

            set
            {
                if (value.Equals(this.canHide))
                {
                    return;
                }

                this.canHide = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand DockCommand { get; private set; }

        public ICommand HideCommand { get; private set; }

        #endregion
    }
}