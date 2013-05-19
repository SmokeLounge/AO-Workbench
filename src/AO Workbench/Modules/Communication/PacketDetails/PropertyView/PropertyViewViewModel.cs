// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyViewViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PropertyViewViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.PropertyView
{
    using System.Collections.Generic;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree;

    public class PropertyViewViewModel : PropertyChangedBase
    {
        #region Fields

        private IReadOnlyCollection<IProperty> properties;

        private IProperty selectedProperty;

        #endregion

        #region Public Properties

        public IReadOnlyCollection<IProperty> Properties
        {
            get
            {
                return this.properties;
            }

            set
            {
                if (Equals(value, this.properties))
                {
                    return;
                }

                this.properties = value;
                this.NotifyOfPropertyChange();
            }
        }

        public IProperty SelectedProperty
        {
            get
            {
                return this.selectedProperty;
            }

            set
            {
                if (Equals(value, this.selectedProperty))
                {
                    return;
                }

                this.selectedProperty = value;
                this.NotifyOfPropertyChange();
            }
        }

        #endregion
    }
}