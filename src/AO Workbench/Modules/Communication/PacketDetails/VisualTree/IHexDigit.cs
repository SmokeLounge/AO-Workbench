// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHexDigit.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
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

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree
{
    public interface IHexDigit
    {
        #region Public Properties

        bool IsHighlighted { get; set; }

        bool IsSelected { get; set; }

        IProperty Property { get; set; }

        byte Value { get; }

        #endregion
    }
}