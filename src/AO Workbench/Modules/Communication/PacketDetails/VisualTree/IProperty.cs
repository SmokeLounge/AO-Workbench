// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProperty.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IProperty type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Reflection;

    [ContractClass(typeof(IPropertyContract))]
    public interface IProperty
    {
        #region Public Properties

        string DisplayName { get; }

        IReadOnlyCollection<IHexDigit> HexDigits { get; }

        string HexValue { get; }

        bool IsHighlighted { get; set; }

        bool IsSelected { get; set; }

        int Length { get; }

        int Offset { get; }

        IReadOnlyCollection<IProperty> Properties { get; }

        PropertyInfo Property { get; }

        string Value { get; }

        #endregion

        #region Public Methods and Operators

        void AddProperty(IProperty property);

        #endregion
    }

    [ContractClassFor(typeof(IProperty))]
    internal abstract class IPropertyContract : IProperty
    {
        #region Public Properties

        public string DisplayName
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);

                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<IHexDigit> HexDigits
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<IHexDigit>>() != null);

                throw new NotImplementedException();
            }
        }

        public string HexValue
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);

                throw new NotImplementedException();
            }
        }

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

        public int Length
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                throw new NotImplementedException();
            }
        }

        public int Offset
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<IProperty> Properties
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<IProperty>>() != null);

                throw new NotImplementedException();
            }
        }

        public PropertyInfo Property
        {
            get
            {
                Contract.Ensures(Contract.Result<PropertyInfo>() != null);

                throw new NotImplementedException();
            }
        }

        public string Value
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddProperty(IProperty property)
        {
            Contract.Requires<ArgumentNullException>(property != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}