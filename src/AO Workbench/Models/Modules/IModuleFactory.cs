// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModuleFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IModuleFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Models.Modules
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Domain;

    [ContractClass(typeof(IModuleFactoryContract))]
    public interface IModuleFactory
    {
        #region Public Properties

        Uri IconSource { get; }

        string Name { get; }

        #endregion

        #region Public Methods and Operators

        IModule Create(IProcess process);

        #endregion
    }

    [ContractClassFor(typeof(IModuleFactory))]
    internal abstract class IModuleFactoryContract : IModuleFactory
    {
        #region Public Properties

        public Uri IconSource
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                Contract.Ensures(string.IsNullOrWhiteSpace(Contract.Result<string>()) == false);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public IModule Create(IProcess process)
        {
            Contract.Requires<ArgumentNullException>(process != null);
            Contract.Ensures(Contract.Result<IModule>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}