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

namespace SmokeLounge.AOWorkbench.Module.Communication.PacketDetails.HexView
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    public class HexViewViewModel : PropertyChangedBase
    {
        #region Fields

        private byte[] buffer;

        private IHexDigit[] hexDigits;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public HexViewViewModel()
        {
        }

        #endregion

        #region Public Properties

        public byte[] Buffer
        {
            get
            {
                return this.buffer;
            }

            set
            {
                this.buffer = value;
                this.OnBufferChanged();
            }
        }

        public IReadOnlyCollection<IHexDigit> HexDigits
        {
            get
            {
                return this.hexDigits;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void SelectRange(int offset, int length)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(length >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(offset + length <= this.HexDigits.Count);

            if (this.hexDigits == null)
            {
                return;
            }

            for (var i = 0; i < offset; i++)
            {
                this.hexDigits[i].IsSelected = false;
            }

            var toOffset = length + offset;
            for (var i = offset; i < toOffset; i++)
            {
                this.hexDigits[i].IsSelected = true;
            }

            for (var i = toOffset; i < this.hexDigits.Length; i++)
            {
                this.hexDigits[i].IsSelected = false;
            }
        }

        #endregion

        #region Methods

        private void OnBufferChanged()
        {
            if (this.buffer == null)
            {
                this.hexDigits = null;
                this.NotifyOfPropertyChange(() => this.HexDigits);
                return;
            }

            this.hexDigits = new IHexDigit[this.buffer.Length];
            for (var i = 0; i < this.buffer.Length; i++)
            {
                this.hexDigits[i] = new HexDigitViewModel(this.buffer[i]);
            }

            this.NotifyOfPropertyChange(() => this.HexDigits);
        }

        #endregion
    }
}