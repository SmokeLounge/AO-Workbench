// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SQLiteDataService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SQLiteDataService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess.SQLite
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.AutoFactory;

    [Export(typeof(IDataService))]
    public class SQLiteDataService : IDataService
    {
        #region Fields

        private readonly IAutoFactory<SQLiteDataSource> sqLiteDataSourceFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public SQLiteDataService(IAutoFactory<SQLiteDataSource> sqLiteDataSourceFactory)
        {
            Contract.Requires<ArgumentNullException>(sqLiteDataSourceFactory != null);

            this.sqLiteDataSourceFactory = sqLiteDataSourceFactory;
        }

        #endregion

        #region Public Methods and Operators

        public IDataSource OpenDataSource(string dataSource)
        {
            return this.sqLiteDataSourceFactory.Create(dataSource);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.sqLiteDataSourceFactory != null);
        }

        #endregion
    }
}