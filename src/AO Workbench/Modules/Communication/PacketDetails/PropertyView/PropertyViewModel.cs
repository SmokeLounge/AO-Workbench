// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PropertyViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.PropertyView
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;

    using Caliburn.Micro;

    public class PropertyViewModel : PropertyChangedBase, IProperty
    {
        #region Fields

        private readonly ArraySegment<byte> bytes;

        private readonly int endOffset;

        private readonly string hexValue;

        private readonly int length;

        private readonly int offset;

        private readonly IList<IProperty> properties;

        private readonly PropertyInfo property;

        private readonly object value;

        private readonly string valueString;

        private bool isHighlighted;

        private bool isSelected;

        #endregion

        #region Constructors and Destructors

        public PropertyViewModel(PropertyInfo property, int offset, int length, object value, ArraySegment<byte> bytes)
        {
            this.property = property;
            this.offset = offset;
            this.length = length;
            this.value = value;
            this.bytes = bytes;

            this.endOffset = offset + length - 1;
            this.hexValue = this.GetHexValue();
            this.properties = new List<IProperty>();
            this.valueString = this.GetValueString();
        }

        #endregion

        #region Public Properties

        public ArraySegment<byte> Bytes
        {
            get
            {
                return this.bytes;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.Property.Name;
            }
        }

        public int EndOffset
        {
            get
            {
                return this.endOffset;
            }
        }

        public string HexValue
        {
            get
            {
                return this.hexValue;
            }
        }

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

        public int Length
        {
            get
            {
                return this.length;
            }
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
        }

        public IReadOnlyCollection<IProperty> Properties
        {
            get
            {
                return this.properties.ToArray();
            }
        }

        public PropertyInfo Property
        {
            get
            {
                return this.property;
            }
        }

        public string Value
        {
            get
            {
                return this.valueString;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddProperty(IProperty property)
        {
            this.properties.Add(property);
        }

        #endregion

        #region Methods

        private string GetHexValue()
        {
            var stringBuilder = new StringBuilder();
            foreach (var hexDigit in this.bytes)
            {
                stringBuilder.Append(hexDigit.ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        private string GetValueString()
        {
            if (this.value == null)
            {
                return string.Empty;
            }

            if (this.value is IPAddress)
            {
                return this.value.ToString();
            }

            var type = this.value.GetType();
            if (type.IsValueType && type.IsPrimitive == false && type.IsEnum == false)
            {
                return string.Empty;
            }

            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            {
                return this.value.ToString();
            }

            return string.Empty;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.bytes != null);
            Contract.Invariant(this.hexValue != null);
            Contract.Invariant(this.length >= 0);
            Contract.Invariant(this.offset >= 0);
            Contract.Invariant(this.properties != null);
            Contract.Invariant(this.property != null);
            Contract.Invariant(this.valueString != null);
        }

        #endregion
    }
}