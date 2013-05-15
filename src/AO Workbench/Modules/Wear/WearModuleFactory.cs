// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WearModuleFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the WearModuleFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Wear
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Models.Modules;

    [Export(typeof(IModuleFactory))]
    public class WearModuleFactory : IModuleFactory
    {
        #region Fields

        private readonly Uri iconSource;

        private readonly string name;

        private readonly WearFactory wearFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public WearModuleFactory(WearFactory wearFactory)
        {
            Contract.Requires<ArgumentNullException>(wearFactory != null);

            this.wearFactory = wearFactory;
            this.iconSource = null;
            this.name = "Wear";
        }

        #endregion

        #region Public Properties

        public Uri IconSource
        {
            get
            {
                return this.iconSource;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        #endregion

        #region Public Methods and Operators

        public IModule Create(IRemoteProcess remoteProcess)
        {
            return new WearModule(remoteProcess, this.wearFactory);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.wearFactory != null);
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
        }

        #endregion
    }
}