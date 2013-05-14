// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StartViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the StartViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Workbench.Documents
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    public class StartViewModel : DocumentItemViewModel
    {
        #region Constructors and Destructors

        public StartViewModel(IEventAggregator events)
            : base(events)
        {
            Contract.Requires<ArgumentNullException>(events != null);

            this.Title = "Start";
        }

        #endregion
    }
}