// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PlayerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.ViewModels.Domain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Facade.Dtos;
    using SmokeLounge.AOWorkbench.Models.Domain;

    [Export]
    public class PlayerFactory
    {
        #region Public Methods and Operators

        public IPlayer Create(Player playerDto)
        {
            Contract.Requires<ArgumentNullException>(playerDto != null);
            Contract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(playerDto.Name) == false);
            Contract.Ensures(Contract.Result<IPlayer>() != null);

            var player = new PlayerViewModel(playerDto.Id, playerDto.RemoteId, playerDto.Name);
            return player;
        }

        #endregion
    }
}