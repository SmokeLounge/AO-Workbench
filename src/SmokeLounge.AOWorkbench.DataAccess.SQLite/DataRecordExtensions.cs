// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataRecordExtensions.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DataRecordExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess.SQLite
{
    using System;
    using System.Data;
    using System.Diagnostics.Contracts;
    using System.IO;

    public static class DataRecordExtensions
    {
        #region Public Methods and Operators

        public static byte[] GetBytes(this IDataRecord source, int i)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            using (var stream = GetMemoryStream(source, i))
            {
                return stream.ToArray();
            }
        }

        public static Stream GetStream(this IDataRecord source, int i)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return GetMemoryStream(source, i);
        }

        #endregion

        #region Methods

        private static MemoryStream GetMemoryStream(IDataRecord dataRecord, int i)
        {
            Contract.Requires(dataRecord != null);

            const int ChunkSize = 2 * 1024;
            var buffer = new byte[ChunkSize];
            long fieldOffset = 0;
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream();
                long bytesRead;
                while ((bytesRead = dataRecord.GetBytes(i, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }

                stream.Position = 0;
                return stream;
            }
            catch
            {
                if (stream != null)
                {
                    stream.Dispose();
                }

                throw;
            }
        }

        #endregion
    }
}