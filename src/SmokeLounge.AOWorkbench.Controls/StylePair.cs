// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StylePair.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the StylePair type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Controls
{
    using System;
    using System.Windows;

    public class StylePair
    {
        #region Public Properties

        public Style Style { get; set; }

        public Type TargetType { get; set; }

        #endregion
    }
}