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
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree;

    public class HexViewViewModel : PropertyChangedBase
    {
        #region Fields

        private readonly IObservableCollection<IHexDigit> selectedHexDigits;

        private IReadOnlyCollection<IHexDigit> hexDigits;

        #endregion

        #region Constructors and Destructors

        public HexViewViewModel()
        {
            this.selectedHexDigits = new BindableCollection<IHexDigit>();
        }

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
                this.OnHexDigitsChanged();
                this.NotifyOfPropertyChange();
            }
        }

        public IObservableCollection<IHexDigit> SelectedHexDigits
        {
            get
            {
                return this.selectedHexDigits;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void SetSelectedItems(IEnumerable<IHexDigit> hexDigits)
        {
            this.selectedHexDigits.Clear();
            if (hexDigits == null)
            {
                return;
            }

            hexDigits.Apply(this.selectedHexDigits.Add);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.selectedHexDigits != null);
        }

        private void OnHexDigitsChanged()
        {
            this.selectedHexDigits.Clear();
        }

        #endregion
    }
}