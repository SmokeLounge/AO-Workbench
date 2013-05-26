// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShell.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IShell type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    [ContractClass(typeof(IShellContract))]
    public interface IShell : IScreen
    {
        #region Public Properties

        IToolbar Toolbar { get; }

        IWorkbench Workbench { get; }

        #endregion
    }

    [ContractClassFor(typeof(IShell))]
    internal abstract class IShellContract : IShell
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

        public IToolbar Toolbar
        {
            get
            {
                Contract.Ensures(Contract.Result<IToolbar>() != null);

                throw new NotImplementedException();
            }
        }

        public IWorkbench Workbench
        {
            get
            {
                Contract.Ensures(Contract.Result<IWorkbench>() != null);

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

        IToolbar IShell.Toolbar
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IWorkbench IShell.Workbench
        {
            get
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