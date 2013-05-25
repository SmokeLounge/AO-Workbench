// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HexDigitViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the HexDigitViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Module.Communication.PacketDetails.HexView
{
    using Caliburn.Micro;

    public class HexDigitViewModel : PropertyChangedBase, IHexDigit
    {
        #region Fields

        private readonly byte value;

        private bool isHighlighted;

        private bool isSelected;

        #endregion

        #region Constructors and Destructors

        public HexDigitViewModel(byte value)
        {
            this.value = value;
        }

        #endregion

        #region Public Properties

        public bool IsHighlighted
        {
            get
            {
                return this.isHighlighted;
            }

            set
            {
                if (value.Equals(this.isHighlighted))
                {
                    return;
                }

                this.isHighlighted = value;
                this.NotifyOfPropertyChange();
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (value.Equals(this.isSelected))
                {
                    return;
                }

                this.isSelected = value;
                this.NotifyOfPropertyChange();
            }
        }

        public byte Value
        {
            get
            {
                return this.value;
            }
        }

        #endregion
    }
}