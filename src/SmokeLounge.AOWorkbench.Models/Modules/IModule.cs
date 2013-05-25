// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModule.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Modules
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOWorkbench.Models.Workbench;

    [ContractClass(typeof(IModuleContract))]
    public interface IModule
    {
        #region Public Properties

        Uri IconSource { get; }

        string Name { get; }

        #endregion

        #region Public Methods and Operators

        IItem CreateItem();

        #endregion
    }

    [ContractClassFor(typeof(IModule))]
    internal abstract class IModuleContract : IModule
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

        public IItem CreateItem()
        {
            Contract.Ensures(Contract.Result<IItem>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}