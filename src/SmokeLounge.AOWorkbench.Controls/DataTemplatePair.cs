// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTemplatePair.cs" company="SmokeLounge">
//   Copyright � 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DataTemplatePair type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Controls
{
    using System;
    using System.Windows;

    public class DataTemplatePair
    {
        #region Public Properties

        public DataTemplate DataTemplate { get; set; }

        public Type DataType { get; set; }

        #endregion
    }
}