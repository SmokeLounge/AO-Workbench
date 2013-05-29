// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessagePackDataFormatter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessagePackDataFormatter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;

    using MsgPack.Serialization;

    public class MessagePackDataFormatter<T> : IDataFormatter<T>
        where T : class
    {
        #region Fields

        private readonly Lazy<MessagePackSerializer<T>> lazySerializer;

        #endregion

        #region Constructors and Destructors

        public MessagePackDataFormatter()
        {
            this.lazySerializer = new Lazy<MessagePackSerializer<T>>(MessagePackSerializer.Create<T>);
        }

        #endregion

        #region Public Methods and Operators

        public T Deserialize(Stream stream)
        {
            if (this.lazySerializer.Value == null)
            {
                throw new InvalidOperationException();
            }

            var obj = this.lazySerializer.Value.Unpack(stream);
            return obj;
        }

        public void Serialize(Stream stream, T obj)
        {
            if (this.lazySerializer.Value == null)
            {
                throw new InvalidOperationException();
            }

            this.lazySerializer.Value.Pack(stream, obj);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.lazySerializer != null);
        }

        #endregion
    }
}