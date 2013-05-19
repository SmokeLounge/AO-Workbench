namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree
{
    using System.Collections.Generic;
    using System.Reflection;

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
}