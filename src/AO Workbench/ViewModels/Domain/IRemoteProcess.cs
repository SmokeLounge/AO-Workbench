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

namespace SmokeLounge.AoWorkbench.ViewModels.Domain
{
    using System;

    public interface IRemoteProcess
    {
        #region Public Properties

        string DisplayName { get; }

        Guid Id { get; }

        bool IsAttached { get; }

        IPlayer Player { get; }

        int RemoteId { get; }

        #endregion
    }
}