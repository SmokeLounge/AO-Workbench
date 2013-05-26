// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcess.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IProcess type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Domain
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.AutoFactory;

    [ContractClass(typeof(IProcessContract))]
    public interface IProcess : INotifyPropertyChanged
    {
        #region Public Properties

        Guid ClientId { get; set; }

        string DisplayName { get; }

        Guid Id { get; }

        bool IsAttached { get; }

        IPlayer Player { get; set; }

        IMiniIoC ServiceLocator { get; }

        #endregion
    }

    [ContractClassFor(typeof(IProcess))]
    internal abstract class IProcessContract : IProcess
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

        public Guid ClientId
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

        public string DisplayName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAttached
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPlayer Player
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

        public IMiniIoC ServiceLocator
        {
            get
            {
                Contract.Ensures(Contract.Result<IMiniIoC>() != null);

                throw new NotImplementedException();
            }
        }

        #endregion
    }
}