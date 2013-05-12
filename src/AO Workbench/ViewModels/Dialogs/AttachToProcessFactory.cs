// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachToProcessFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AttachToProcessFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Dialogs
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Components.Services;

    [Export]
    public class AttachToProcessFactory
    {
        #region Fields

        private readonly IRemoteProcessService remoteProcessService;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public AttachToProcessFactory(IRemoteProcessService remoteProcessService)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);

            this.remoteProcessService = remoteProcessService;
        }

        #endregion

        #region Public Methods and Operators

        public AttachToProcessViewModel Create()
        {
            var attachToProcess = new AttachToProcessViewModel(this.remoteProcessService);
            return attachToProcess;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessService != null);
        }

        #endregion
    }
}