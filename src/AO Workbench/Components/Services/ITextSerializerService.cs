// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextSerializerService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ITextSerializerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components.Services
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(ITextSerializerServiceContract))]
    public interface ITextSerializerService
    {
        #region Public Methods and Operators

        string Serialize<T>(T value);

        #endregion
    }

    [ContractClassFor(typeof(ITextSerializerService))]
    internal abstract class ITextSerializerServiceContract : ITextSerializerService
    {
        public string Serialize<T>(T value)
        {
            Contract.Requires<ArgumentNullException>(value.Equals(null) == false);
            Contract.Ensures(string.IsNullOrWhiteSpace(Contract.Result<string>()) == false);

            throw new NotImplementedException();
        }
    }
}