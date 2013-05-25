// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnchorableItemFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IAnchorableItemFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Modules
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOWorkbench.Models.Workbench;

    [ContractClass(typeof(IAnchorableItemFactoryContract<>))]
    public interface IAnchorableItemFactory<out T> : IItemFactory<T>
        where T : class, IAnchorableItem
    {
    }

    [ContractClassFor(typeof(IAnchorableItemFactory<>))]
    internal abstract class IAnchorableItemFactoryContract<T> : IAnchorableItemFactory<T>
        where T : class, IAnchorableItem
    {
        #region Explicit Interface Methods

        T IItemFactory<T>.CreateItem(Guid processId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}