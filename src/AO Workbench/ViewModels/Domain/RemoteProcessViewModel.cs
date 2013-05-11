// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Domain
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;

    public class RemoteProcessViewModel : PropertyChangedBase, 
                                          IRemoteProcess, 
                                          IHandleDomainEvent<PlayerForRemoteProcessFoundEvent>
    {
        #region Fields

        private readonly IDomainEventAggregator domainEvents;

        private readonly Guid id;

        private readonly PlayerFactory playerFactory;

        private readonly int remoteId;

        private bool isAttached;

        private IPlayer player;

        #endregion

        #region Constructors and Destructors

        public RemoteProcessViewModel(
            Guid id, int remoteId, IPlayer player, PlayerFactory playerFactory, IDomainEventAggregator domainEvents)
        {
            Contract.Requires<ArgumentNullException>(playerFactory != null);
            Contract.Requires<ArgumentNullException>(domainEvents != null);

            this.id = id;
            this.remoteId = remoteId;
            this.player = player;
            this.playerFactory = playerFactory;
            this.domainEvents = domainEvents;

            this.domainEvents.Subscribe(this);
        }

        #endregion

        #region Public Properties

        public string DisplayName
        {
            get
            {
                return this.player == null ? "(AnarchyOnline)" : this.player.Name;
            }
        }

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public bool IsAttached
        {
            get
            {
                return this.isAttached;
            }

            private set
            {
                if (value.Equals(this.isAttached))
                {
                    return;
                }

                this.isAttached = value;
                this.NotifyOfPropertyChange();
            }
        }

        public IPlayer Player
        {
            get
            {
                return this.player;
            }

            private set
            {
                if (Equals(value, this.player))
                {
                    return;
                }

                this.player = value;
                this.NotifyOfPropertyChange();
                this.NotifyOfPropertyChange(() => this.DisplayName);
            }
        }

        public int RemoteId
        {
            get
            {
                return this.remoteId;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(PlayerForRemoteProcessFoundEvent message)
        {
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.playerFactory != null);
            Contract.Invariant(this.domainEvents != null);
        }

        #endregion
    }
}