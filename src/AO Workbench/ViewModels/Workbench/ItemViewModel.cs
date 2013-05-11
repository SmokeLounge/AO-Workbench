// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ItemViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Workbench
{
    using System;
    using System.Windows.Input;

    using Caliburn.Micro;

    public abstract class ItemViewModel : PropertyChangedBase, IItem
    {
        #region Fields

        private bool canClose;

        private bool canFloat;

        private string contentId;

        private Uri iconSource;

        private bool isActive;

        private bool isSelected;

        private string title;

        #endregion

        #region Public Properties

        public ICommand ActivateCommand { get; private set; }

        public bool CanClose
        {
            get
            {
                return this.canClose;
            }

            set
            {
                if (value.Equals(this.canClose))
                {
                    return;
                }

                this.canClose = value;
                this.NotifyOfPropertyChange();
            }
        }

        public bool CanFloat
        {
            get
            {
                return this.canFloat;
            }

            set
            {
                if (value.Equals(this.canFloat))
                {
                    return;
                }

                this.canFloat = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand CloseAllButThisCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public string ContentId
        {
            get
            {
                return this.contentId;
            }

            set
            {
                if (value == this.contentId)
                {
                    return;
                }

                this.contentId = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand DockAsDocumentCommand { get; private set; }

        public ICommand FloatCommand { get; private set; }

        public Uri IconSource
        {
            get
            {
                return this.iconSource;
            }

            set
            {
                if (Equals(value, this.iconSource))
                {
                    return;
                }

                this.iconSource = value;
                this.NotifyOfPropertyChange();
            }
        }

        public bool IsActive
        {
            get
            {
                return this.isActive;
            }

            set
            {
                if (value.Equals(this.isActive))
                {
                    return;
                }

                this.isActive = value;
                this.NotifyOfPropertyChange();
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (value.Equals(this.isSelected))
                {
                    return;
                }

                this.isSelected = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand MoveToNextTabGroupCommand { get; private set; }

        public ICommand MoveToPreviousTabGroupCommand { get; private set; }

        public ICommand NewHorizontalTabGroupCommand { get; private set; }

        public ICommand NewVerticalTabGroupCommand { get; private set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value == this.title)
                {
                    return;
                }

                this.title = value;
                this.NotifyOfPropertyChange();
            }
        }

        #endregion
    }
}