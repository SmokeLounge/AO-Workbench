// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessagePackDataFormatterResolver.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessagePackDataFormatterResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    [Export(typeof(IDataFormatterResolver))]
    public class MessagePackDataFormatterResolver : IDataFormatterResolver
    {
        #region Fields

        private readonly ConcurrentDictionary<Type, object> dataFormatters = new ConcurrentDictionary<Type, object>();

        #endregion

        #region Public Methods and Operators

        public IDataFormatter<T> GetDataFormatter<T>() where T : class
        {
            var dataFormatter =
                (IDataFormatter<T>)this.dataFormatters.GetOrAdd(typeof(T), type => new MessagePackDataFormatter<T>());
            if (dataFormatter == null)
            {
                throw new InvalidOperationException();
            }

            return dataFormatter;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.dataFormatters != null);
        }

        #endregion
    }
}