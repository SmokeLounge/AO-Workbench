// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IThemeManager.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IThemeManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Controls
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows;

    [ContractClass(typeof(IThemeManagerContract))]
    public interface IThemeManager
    {
        #region Public Methods and Operators

        ResourceDictionary GetThemeResources();

        #endregion
    }

    [ContractClassFor(typeof(IThemeManager))]
    internal abstract class IThemeManagerContract : IThemeManager
    {
        #region Public Methods and Operators

        public ResourceDictionary GetThemeResources()
        {
            Contract.Ensures(Contract.Result<ResourceDictionary>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}