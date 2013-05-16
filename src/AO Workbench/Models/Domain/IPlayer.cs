// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IPlayer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Models.Domain
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Messaging.GameData;

    [ContractClass(typeof(IPlayerContract))]
    public interface IPlayer : INotifyPropertyChanged
    {
        #region Public Properties

        Guid Id { get; }

        string Name { get; }

        Identity RemoteId { get; }

        #endregion
    }

    [ContractClassFor(typeof(IPlayer))]
    internal abstract class IPlayerContract : IPlayer
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

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                Contract.Ensures(string.IsNullOrWhiteSpace(Contract.Result<string>()) == false);

                throw new NotImplementedException();
            }
        }

        public Identity RemoteId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}