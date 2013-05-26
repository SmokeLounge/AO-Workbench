// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRemoteProcess.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IRemoteProcess type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Domain
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.AutoFactory;

    [ContractClass(typeof(IRemoteProcessContract))]
    public interface IRemoteProcess : IProcess
    {
        #region Public Properties

        int RemoteId { get; }

        #endregion
    }

    [ContractClassFor(typeof(IRemoteProcess))]
    internal abstract class IRemoteProcessContract : IRemoteProcess
    {
        #region Explicit Interface Events

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

        public int RemoteId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Properties

        Guid IProcess.ClientId
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

        string IProcess.DisplayName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        Guid IProcess.Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IProcess.IsAttached
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IPlayer IProcess.Player
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

        int IRemoteProcess.RemoteId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IMiniIoC IProcess.ServiceLocator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}