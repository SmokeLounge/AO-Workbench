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
        #region Public Events

        public abstract event EventHandler<ActivationEventArgs> Activated;

        public abstract event EventHandler<DeactivationEventArgs> AttemptingDeactivation;

        public abstract event EventHandler<DeactivationEventArgs> Deactivated;

        public abstract event PropertyChangedEventHandler PropertyChanged;

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

        public string DisplayName
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

        public IObservableCollection<IDocumentItem> Documents
        {
            get
            {
                Contract.Ensures(Contract.Result<IObservableCollection<IDocumentItem>>() != null);

                throw new NotImplementedException();
            }
        }

        public bool IsActive
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsNotifying
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

        #region Public Methods and Operators

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void CanClose(Action<bool> callback)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(bool close)
        {
            throw new NotImplementedException();
        }

        public void NotifyOfPropertyChange(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void TryClose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}