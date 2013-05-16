// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NanosModuleFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the NanosModuleFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Nanos
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Models.Modules;

    [Export(typeof(IModuleFactory))]
    public class NanosModuleFactory : IModuleFactory
    {
        #region Fields

        private readonly Uri iconSource;

        private readonly string name;

        private readonly NanosFactory nanosFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public NanosModuleFactory(NanosFactory nanosFactory)
        {
            Contract.Requires<ArgumentNullException>(nanosFactory != null);

            this.nanosFactory = nanosFactory;
            this.iconSource = null;
            this.name = "Nanos";
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
            return new NanosModule(process, this.nanosFactory);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.nanosFactory != null);
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
        }

        #endregion
    }
}