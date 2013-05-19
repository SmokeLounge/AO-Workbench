// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HexViewFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the HexViewFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.HexView
{
    using System.ComponentModel.Composition;

    [Export]
    public class HexViewFactory
    {
        #region Public Methods and Operators

        public HexViewViewModel Create()
        {
            return new HexViewViewModel();
        }

        #endregion
    }
}