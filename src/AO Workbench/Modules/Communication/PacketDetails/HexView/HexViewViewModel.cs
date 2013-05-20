// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HexViewViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the HexViewViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.HexView
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Caliburn.Micro;

    public class HexViewViewModel : PropertyChangedBase
    {
        #region Fields

        private IReadOnlyCollection<IHexDigit> hexDigits;

        #endregion

        #region Public Properties

        public IReadOnlyCollection<IHexDigit> HexDigits
        {
            get
            {
                return this.hexDigits;
            }

            set
            {
                if (Equals(value, this.hexDigits))
                {
                    return;
                }

                this.hexDigits = value;
                this.NotifyOfPropertyChange();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void SelectRange(int offset, int length)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(length >= 0);

            if (this.hexDigits == null)
            {
                return;
            }

            foreach (var hexDigit in this.hexDigits.Take(offset))
            {
                hexDigit.IsSelected = false;
            }

            foreach (var hexDigit in this.hexDigits.Skip(offset).Take(length))
            {
                hexDigit.IsSelected = true;
            }

            foreach (var hexDigit in this.hexDigits.Skip(offset + length))
            {
                hexDigit.IsSelected = false;
            }
        }

        #endregion
    }
}