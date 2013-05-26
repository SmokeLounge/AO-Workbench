// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWorkbench.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IWorkbench type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOWorkbench.Models.Workbench;

    [ContractClass(typeof(IWorkbenchContract))]
    public interface IWorkbench : IScreen
    {
        #region Public Properties

        IItem ActiveContent { get; set; }

        IObservableCollection<IAnchorableItem> Anchorables { get; }

        IObservableCollection<IDocumentItem> Documents { get; }

        #endregion
    }

    [ContractClassFor(typeof(IWorkbench))]
    internal abstract class IWorkbenchContract : IWorkbench
    {
        #region Explicit Interface Events

        event EventHandler<ActivationEventArgs> IActivate.Activated
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<DeactivationEventArgs> IDeactivate.AttemptingDeactivation
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<DeactivationEventArgs> IDeactivate.Deactivated
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Properties

        public IItem ActiveContent
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IObservableCollection<IAnchorableItem> Anchorables
        {
            get
            {
                Contract.Ensures(Contract.Result<IObservableCollection<IAnchorableItem>>() != null);

                throw new NotImplementedException();
            }
        }

        public IObservableCollection<IDocumentItem> Documents
        {
            get
            {
                Contract.Ensures(Contract.Result<IObservableCollection<IDocumentItem>>() != null);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Properties

        string IHaveDisplayName.DisplayName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        bool IActivate.IsActive
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool INotifyPropertyChangedEx.IsNotifying
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Methods

        void IActivate.Activate()
        {
            throw new NotImplementedException();
        }

        void IGuardClose.CanClose(Action<bool> callback)
        {
            throw new NotImplementedException();
        }

        void IDeactivate.Deactivate(bool close)
        {
            throw new NotImplementedException();
        }

        void INotifyPropertyChangedEx.NotifyOfPropertyChange(string propertyName)
        {
            throw new NotImplementedException();
        }

        void INotifyPropertyChangedEx.Refresh()
        {
            throw new NotImplementedException();
        }

        void IClose.TryClose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}