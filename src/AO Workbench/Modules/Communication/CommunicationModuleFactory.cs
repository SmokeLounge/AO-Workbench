// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunicationModuleFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CommunicationModuleFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Models.Modules;

    [Export(typeof(IModuleFactory))]
    public class CommunicationModuleFactory : IModuleFactory
    {
        #region Fields

        private readonly CommunicationFactory communicationFactory;

        private readonly Uri iconSource;

        private readonly string name;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public CommunicationModuleFactory(CommunicationFactory communicationFactory)
        {
            Contract.Requires<ArgumentNullException>(communicationFactory != null);

            this.communicationFactory = communicationFactory;
            this.iconSource = null;
            this.name = "Communication";
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

        public IModule Create(IProcess process)
        {
            return new CommunicationModule(process, this.communicationFactory);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.communicationFactory != null);
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
        }

        #endregion
    }
}