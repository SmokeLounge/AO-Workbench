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

namespace SmokeLounge.AOWorkbench.Components.Workbench
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Input;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOWorkbench.Components.Events.Workbench;
    using SmokeLounge.AOWorkbench.Models.Workbench;

    public abstract class ItemViewModel : PropertyChangedBase, IItem
    {
        #region Fields

        private readonly IBus bus;

        private ICommand activateCommand;

        private bool canClose = true;

        private bool canFloat = true;

        private ICommand closeAllButThisCommand;

        private ICommand closeCommand;

        private string contentId;

        private ICommand dockAsDocumentCommand;

        private ICommand floatCommand;

        private Uri iconSource;

        private bool isActive;

        private bool isSelected;

        private ICommand moveToNextTabGroupCommand;

        private ICommand moveToPreviousTabGroupCommand;

        private ICommand newHorizontalTabGroupCommand;

        private ICommand newVerticalTabGroupCommand;

        private string title;

        private string toolTip;

        #endregion

        #region Constructors and Destructors

        protected ItemViewModel(IBus bus)
        {
            Contract.Requires<ArgumentNullException>(bus != null);

            this.bus = bus;

            this.closeCommand = new RelayCommand(_ => this.OnClose(), _ => this.CanClose);
        }

        #endregion

        #region Public Properties

        public ICommand ActivateCommand
        {
            get
            {
                return this.activateCommand;
            }

            protected set
            {
                if (Equals(value, this.activateCommand))
                {
                    return;
                }

                this.activateCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

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

        public ICommand CloseAllButThisCommand
        {
            get
            {
                return this.closeAllButThisCommand;
            }

            protected set
            {
                if (Equals(value, this.closeAllButThisCommand))
                {
                    return;
                }

                this.closeAllButThisCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return this.closeCommand;
            }

            protected set
            {
                if (Equals(value, this.closeCommand))
                {
                    return;
                }

                this.closeCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

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

        public ICommand DockAsDocumentCommand
        {
            get
            {
                return this.dockAsDocumentCommand;
            }

            protected set
            {
                if (Equals(value, this.dockAsDocumentCommand))
                {
                    return;
                }

                this.dockAsDocumentCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand FloatCommand
        {
            get
            {
                return this.floatCommand;
            }

            protected set
            {
                if (Equals(value, this.floatCommand))
                {
                    return;
                }

                this.floatCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

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

        public ICommand MoveToNextTabGroupCommand
        {
            get
            {
                return this.moveToNextTabGroupCommand;
            }

            protected set
            {
                if (Equals(value, this.moveToNextTabGroupCommand))
                {
                    return;
                }

                this.moveToNextTabGroupCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand MoveToPreviousTabGroupCommand
        {
            get
            {
                return this.moveToPreviousTabGroupCommand;
            }

            protected set
            {
                if (Equals(value, this.moveToPreviousTabGroupCommand))
                {
                    return;
                }

                this.moveToPreviousTabGroupCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand NewHorizontalTabGroupCommand
        {
            get
            {
                return this.newHorizontalTabGroupCommand;
            }

            protected set
            {
                if (Equals(value, this.newHorizontalTabGroupCommand))
                {
                    return;
                }

                this.newHorizontalTabGroupCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

        public ICommand NewVerticalTabGroupCommand
        {
            get
            {
                return this.newVerticalTabGroupCommand;
            }

            protected set
            {
                if (Equals(value, this.newVerticalTabGroupCommand))
                {
                    return;
                }

                this.newVerticalTabGroupCommand = value;
                this.NotifyOfPropertyChange();
            }
        }

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

        public string ToolTip
        {
            get
            {
                return this.toolTip;
            }

            set
            {
                if (value == this.toolTip)
                {
                    return;
                }

                this.toolTip = value;
                this.NotifyOfPropertyChange();
            }
        }

        #endregion

        #region Properties

        protected IBus Bus
        {
            get
            {
                Contract.Ensures(Contract.Result<IBus>() != null);

                return this.bus;
            }
        }

        #endregion

        #region Methods

        protected virtual void OnClose()
        {
            this.Bus.Publish(new ItemClosedEvent(this));
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.bus != null);
        }

        #endregion
    }
}