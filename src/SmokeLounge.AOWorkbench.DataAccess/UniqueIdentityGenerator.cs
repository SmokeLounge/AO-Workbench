// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UniqueIdentityGenerator.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   <see aref="http://ayende.com/blog/4643/createsequetialuuid-answer" />
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.DataAccess
{
    using System;
    using System.ComponentModel.Composition;
    using System.Threading;

    /// <summary>
    ///     <see aref="http://ayende.com/blog/4643/createsequetialuuid-answer" />
    /// </summary>
    [Export(typeof(IUniqueIdentityGenerator))]
    public class UniqueIdentityGenerator : IUniqueIdentityGenerator
    {
        #region Static Fields

        private static int sequentialUuidCounter;

        #endregion

        #region Public Methods and Operators

        public Guid CreateSequentialUuid()
        {
            var ticksAsBytes = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
            Array.Reverse(ticksAsBytes);
            var increment = Interlocked.Increment(ref sequentialUuidCounter);
            var currentAsBytes = BitConverter.GetBytes(increment);
            Array.Reverse(currentAsBytes);
            var bytes = new byte[16];
            Array.Copy(ticksAsBytes, 0, bytes, 0, ticksAsBytes.Length);
            Array.Copy(currentAsBytes, 0, bytes, 12, currentAsBytes.Length);
            return this.TransfromToGuidWithProperSorting(bytes);
        }

        #endregion

        #region Methods

        private Guid TransfromToGuidWithProperSorting(byte[] bytes)
        {
            var unnormalized = new byte[16];
            unnormalized[0] = bytes[10];
            unnormalized[1] = bytes[11];
            unnormalized[2] = bytes[12];
            unnormalized[3] = bytes[13];
            unnormalized[4] = bytes[14];
            unnormalized[5] = bytes[15];
            unnormalized[6] = bytes[8];
            unnormalized[7] = bytes[9];
            unnormalized[8] = bytes[6];
            unnormalized[9] = bytes[7];
            unnormalized[10] = bytes[4];
            unnormalized[11] = bytes[5];
            unnormalized[12] = bytes[0];
            unnormalized[13] = bytes[1];
            unnormalized[14] = bytes[2];
            unnormalized[15] = bytes[3];
            return new Guid(unnormalized);
        }

        #endregion
    }
}