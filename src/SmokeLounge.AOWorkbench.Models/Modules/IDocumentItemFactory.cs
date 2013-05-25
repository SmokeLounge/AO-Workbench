// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentItemFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDocumentItemFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Modules
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOWorkbench.Models.Workbench;

    [ContractClass(typeof(IDocumentItemFactoryContract<>))]
    public interface IDocumentItemFactory<out T> : IItemFactory<T>
        where T : class, IDocumentItem
    {
    }

    [ContractClassFor(typeof(IDocumentItemFactory<>))]
    internal abstract class IDocumentItemFactoryContract<T> : IDocumentItemFactory<T>
        where T : class, IDocumentItem
    {
        #region Explicit Interface Methods

        T IItemFactory<T>.CreateItem(Guid processId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}