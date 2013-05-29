// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUniqueIdentityGenerator.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IUniqueIdentityGenerator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IUniqueIdentityGeneratorContract))]
    public interface IUniqueIdentityGenerator
    {
        #region Public Methods and Operators

        Guid CreateSequentialUuid();

        #endregion
    }

    [ContractClassFor(typeof(IUniqueIdentityGenerator))]
    internal abstract class IUniqueIdentityGeneratorContract : IUniqueIdentityGenerator
    {
        #region Public Methods and Operators

        public Guid CreateSequentialUuid()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}