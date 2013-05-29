// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Data.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Data type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.Diagnostics.Contracts;

    public sealed class Data<T> : IData<T>
        where T : class
    {
        #region Fields

        private T content;

        private Guid id;

        #endregion

        #region Constructors and Destructors

        public Data(Guid id, T content)
        {
            Contract.Requires<ArgumentNullException>(content != null);

            this.id = id;
            this.content = content;
        }

        public Data(T content)
        {
            Contract.Requires<ArgumentNullException>(content != null);

            this.content = content;
        }

        #endregion

        #region Public Properties

        public T Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

        public Guid Id { get; set; }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.content != null);
        }

        #endregion
    }
}