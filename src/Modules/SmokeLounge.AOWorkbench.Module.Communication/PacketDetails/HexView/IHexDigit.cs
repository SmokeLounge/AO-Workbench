// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHexDigit.cs" company="SmokeLounge">
//   Copyright � 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IHexDigit type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Module.Communication.PacketDetails.HexView
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IHexDigitContract))]
    public interface IHexDigit
    {
        #region Public Properties

        bool IsHighlighted { get; set; }

        bool IsSelected { get; set; }

        byte Value { get; }

        #endregion
    }

    [ContractClassFor(typeof(IHexDigit))]
    internal abstract class IHexDigitContract : IHexDigit
    {
        #region Public Properties

        public bool IsHighlighted
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSelected
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public byte Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}