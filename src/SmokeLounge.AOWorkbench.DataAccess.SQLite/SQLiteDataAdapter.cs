// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SQLiteDataAdapter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SQLiteDataAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess.SQLite
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SQLite;
    using System.Diagnostics.Contracts;
    using System.IO;

    public class SQLiteDataAdapter<T> : IDataAdapter<T>
        where T : class
    {
        #region Fields

        private readonly string countSql = string.Format("SELECT COUNT(*) FROM [{0}]", typeof(T).Name);

        private readonly IDataFormatter<T> dataFormatter;

        private readonly string deleteSql = string.Format("DELETE FROM [{0}] WHERE [Id] = @id", typeof(T).Name);

        private readonly string getAllSql = string.Format(
            "SELECT [Id], [Content] FROM [{0}] ORDER BY [Id] ASC", typeof(T).Name);

        private readonly string getRangeSql =
            string.Format("SELECT [Id], [Content] FROM [{0}] ORDER BY [Id] ASC LIMIT @offset, @count", typeof(T).Name);

        private readonly string getSql = string.Format(
            "SELECT [Id], [Content] FROM [{0}] WHERE [Id] = @id", typeof(T).Name);

        private readonly string insertSql = string.Format(
            "INSERT INTO [{0}] ([Id], [Content]) VALUES (@id, @content)", typeof(T).Name);

        private readonly SQLiteConnection sqLiteConnection;

        private readonly string updateSql = string.Format(
            "UPDATE [{0}] SET [Content] = @content WHERE [Id] = @id", typeof(T).Name);

        #endregion

        #region Constructors and Destructors

        public SQLiteDataAdapter(SQLiteConnection sqLiteConnection, IDataFormatter<T> dataFormatter)
        {
            Contract.Requires<ArgumentNullException>(sqLiteConnection != null);
            Contract.Requires<ArgumentNullException>(dataFormatter != null);

            this.sqLiteConnection = sqLiteConnection;
            this.dataFormatter = dataFormatter;
        }

        #endregion

        #region Public Methods and Operators

        public int Count()
        {
            var command = new SQLiteCommand(this.countSql, this.sqLiteConnection);

            var count = command.ExecuteScalar() as int?;
            if (count.HasValue == false || count.Value < 0)
            {
                throw new InvalidOperationException();
            }

            return count.Value;
        }

        public void Delete(IData<T> data)
        {
            var command = new SQLiteCommand(this.deleteSql, this.sqLiteConnection);
            command.Parameters.AddWithValue("@id", data.Id);

            var rows = command.ExecuteNonQuery();
            if (rows != 1)
            {
                throw new InvalidOperationException();
            }
        }

        public IData<T> Get(Guid id)
        {
            var command = new SQLiteCommand(this.getSql, this.sqLiteConnection);
            command.Parameters.AddWithValue("@id", id);

            using (var dataReader = command.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.SequentialAccess))
            {
                if (dataReader.FieldCount != 1)
                {
                    return null;
                }

                var content = this.dataFormatter.Deserialize(dataReader.GetStream(1));
                var data = new Data<T>(id, content);
                return data;
            }
        }

        public IEnumerable<IData<T>> GetAll()
        {
            var command = new SQLiteCommand(this.getAllSql, this.sqLiteConnection);

            using (
                var dataReader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SequentialAccess))
            {
                while (dataReader.Read())
                {
                    var id = dataReader.GetGuid(0);
                    var content = this.dataFormatter.Deserialize(dataReader.GetStream(1));
                    var data = new Data<T>(id, content);
                    yield return data;
                }
            }
        }

        public IEnumerable<IData<T>> GetRange(int offset, int count)
        {
            var command = new SQLiteCommand(this.getRangeSql, this.sqLiteConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.Parameters.AddWithValue("@count", count);

            using (
                var dataReader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SequentialAccess))
            {
                while (dataReader.Read())
                {
                    var id = dataReader.GetGuid(0);
                    var content = this.dataFormatter.Deserialize(dataReader.GetStream(1));
                    var data = new Data<T>(id, content);
                    yield return data;
                }
            }
        }

        public void Save(IData<T> data)
        {
            byte[] content;
            using (var stream = new MemoryStream())
            {
                this.dataFormatter.Serialize(stream, data.Content);
                content = stream.ToArray();
            }

            if (content.Length <= 0)
            {
                throw new InvalidOperationException();
            }

            var command = new SQLiteCommand(this.insertSql, this.sqLiteConnection);
            command.Parameters.AddWithValue("@id", data.Id);
            command.Parameters.AddWithValue("@content", content);

            var rows = command.ExecuteNonQuery();
            if (rows != 1)
            {
                throw new InvalidOperationException();
            }
        }

        public void Update(IData<T> data)
        {
            byte[] content;
            using (var stream = new MemoryStream())
            {
                this.dataFormatter.Serialize(stream, data.Content);
                content = stream.ToArray();
            }

            if (content.Length <= 0)
            {
                throw new InvalidOperationException();
            }

            var command = new SQLiteCommand(this.updateSql, this.sqLiteConnection);
            command.Parameters.AddWithValue("@id", data.Id);
            command.Parameters.AddWithValue("@content", content);

            var rows = command.ExecuteNonQuery();
            if (rows != 1)
            {
                throw new InvalidOperationException();
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.dataFormatter != null);
            Contract.Invariant(this.sqLiteConnection != null);
        }

        #endregion
    }
}