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

    public class Data<T> : IData<T>
        where T : class
    {
        #region Fields

        private readonly Guid id;

        private T content;

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

            this.id = CreateGuidComb();
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

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        #endregion

        #region Methods

        private static Guid CreateGuidComb()
        {
            var guidArray = Guid.NewGuid().ToByteArray();

            var baseDate = new DateTime(1900, 1, 1);
            var now = DateTime.Now;

            var days = new TimeSpan(now.Ticks - baseDate.Ticks);
            var msecs = now.TimeOfDay;

            var daysArray = BitConverter.GetBytes(days.Days);
            var msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.content != null);
        }

        #endregion
    }
}