// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IItemFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Modules
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOWorkbench.Models.Workbench;

    [ContractClass(typeof(IItemFactoryContract<>))]
    public interface IItemFactory<out T>
        where T : class, IItem
    {
        #region Public Methods and Operators

        T CreateItem(Guid processId);

        #endregion
    }

    [ContractClassFor(typeof(IItemFactory<>))]
    internal abstract class IItemFactoryContract<T> : IItemFactory<T>
        where T : class, IItem
    {
        #region Public Methods and Operators

        public T CreateItem(Guid processId)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}