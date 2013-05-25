// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Domain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Facade.Dtos;
    using SmokeLounge.AoWorkbench.Models.Domain;

    [Export]
    public class RemoteProcessFactory
    {
        #region Fields

        private readonly IBus bus;

        private readonly PlayerFactory playerFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessFactory(PlayerFactory playerFactory, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(playerFactory != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.playerFactory = playerFactory;
            this.bus = bus;
        }

        #endregion

        #region Public Methods and Operators

        public IRemoteProcess Create(RemoteProcess remoteProcessDto)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessDto != null);

            IPlayer player = null;
            if (remoteProcessDto.Player != null)
            {
                if (string.IsNullOrWhiteSpace(remoteProcessDto.Player.Name))
                {
                    throw new InvalidOperationException();
                }

                player = this.playerFactory.Create(remoteProcessDto.Player);
            }

            var remoteProcess = new RemoteProcessViewModel(remoteProcessDto.Id, remoteProcessDto.RemoteId, player);
            return remoteProcess;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.playerFactory != null);
            Contract.Invariant(this.bus != null);
        }

        #endregion
    }
}