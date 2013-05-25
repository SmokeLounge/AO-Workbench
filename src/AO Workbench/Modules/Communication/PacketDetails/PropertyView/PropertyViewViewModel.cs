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
    using System.ComponentModel.Composition;
    using System.Linq;

    using Caliburn.Micro;

    public class PropertyViewViewModel : PropertyChangedBase
    {
        #region Fields

        private IProperty[] properties;

        private IProperty selectedProperty;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PropertyViewViewModel()
        {
        }

        #endregion

        #region Public Properties

        public IReadOnlyCollection<IProperty> Properties
        {
            get
            {
                return this.properties;
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

        #region Public Methods and Operators

        public void SetProperties(IEnumerable<IProperty> properties)
        {
            if (properties == null)
            {
                this.properties = null;
                this.NotifyOfPropertyChange(() => this.Properties);
                return;
            }

            this.properties = properties.ToArray();
            this.NotifyOfPropertyChange(() => this.Properties);
        }

        #endregion
    }
}