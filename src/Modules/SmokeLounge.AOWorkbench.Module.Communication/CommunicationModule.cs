// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunicationModule.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CommunicationModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Module.Communication
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOWorkbench.Models.Domain;
    using SmokeLounge.AOWorkbench.Models.Modules;
    using SmokeLounge.AOWorkbench.Models.Workbench;

    public class CommunicationModule : IModule
    {
        #region Fields

        private readonly CommunicationViewModel communication;

        private readonly CommunicationFactory communicationFactory;

        private readonly Uri iconSource;

        private readonly string name;

        private readonly IProcess process;

        #endregion

        #region Constructors and Destructors

        public CommunicationModule(IProcess process, CommunicationFactory communicationFactory)
        {
            Contract.Requires<ArgumentNullException>(process != null);
            Contract.Requires<ArgumentNullException>(communicationFactory != null);

            this.process = process;
            this.communicationFactory = communicationFactory;
            this.iconSource = null;
            this.name = "Communication";
            this.communication = this.communicationFactory.CreateItem(this.process.Id);
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

        public IItem CreateItem()
        {
            return this.communication;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
            Contract.Invariant(this.communication != null);
            Contract.Invariant(this.communicationFactory != null);
            Contract.Invariant(this.process != null);
        }

        #endregion
    }
}