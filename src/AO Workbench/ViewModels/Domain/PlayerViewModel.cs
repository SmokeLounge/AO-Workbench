// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PlayerViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.ViewModels.Domain
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOWorkbench.Models.Domain;

    public class PlayerViewModel : PropertyChangedBase, IPlayer
    {
        #region Fields

        private readonly Guid id;

        private readonly string name;

        private readonly Identity remoteId;

        #endregion

        #region Constructors and Destructors

        public PlayerViewModel(Guid id, Identity remoteId, string name)
        {
            Contract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(name) == false);

            this.id = id;
            this.remoteId = remoteId;
            this.name = name;
        }

        #endregion

        #region Public Properties

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Identity RemoteId
        {
            get
            {
                return this.remoteId;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
        }

        #endregion
    }
}