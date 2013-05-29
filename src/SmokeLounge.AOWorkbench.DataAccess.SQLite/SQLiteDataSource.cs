// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SQLiteDataSource.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SQLiteDataSource type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess.SQLite
{
    using System;
    using System.ComponentModel.Composition;
    using System.Data.SQLite;
    using System.Diagnostics.Contracts;
    using System.IO;

    public sealed class SQLiteDataSource : IDataSource
    {
        #region Fields

        private readonly IDataFormatterResolver dataFormatterResolver;

        private readonly SQLiteConnection sqLiteConnection;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public SQLiteDataSource(string filePath, IDataFormatterResolver dataFormatterResolver)
        {
            Contract.Requires<ArgumentNullException>(filePath != null);
            Contract.Requires<ArgumentNullException>(dataFormatterResolver != null);

            this.dataFormatterResolver = dataFormatterResolver;
            if (File.Exists(filePath) == false)
            {
                SQLiteConnection.CreateFile(filePath);
            }

            this.sqLiteConnection = new SQLiteConnection("Data Source=" + filePath + ";Version=3;");
            this.sqLiteConnection.Open();
        }

        #endregion

        #region Public Methods and Operators

        public void Dispose()
        {
            this.sqLiteConnection.Dispose();
        }

        public IDataAdapter<T> GetDataAdapter<T>() where T : class
        {
            var sql =
                string.Format(
                    "CREATE TABLE IF NOT EXISTS [{0}] ([Id] guid NOT NULL PRIMARY KEY, [Content] blob NOT NULL)", 
                    typeof(T).Name);
            var command = new SQLiteCommand(sql, this.sqLiteConnection);
            command.ExecuteNonQuery();
            return new SQLiteDataAdapter<T>(this.sqLiteConnection, this.dataFormatterResolver.GetDataFormatter<T>());
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.dataFormatterResolver != null);
            Contract.Invariant(this.sqLiteConnection != null);
        }

        #endregion
    }
}