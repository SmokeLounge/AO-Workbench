// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentItemViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DocumentItemViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels.Workbench
{
    using System;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Models.Workbench;

    public abstract class DocumentItemViewModel : ItemViewModel, IDocumentItem
    {
        #region Fields

        private string description;

        #endregion

        #region Constructors and Destructors

        protected DocumentItemViewModel(IEventAggregator events)
            : base(events)
        {
            Contract.Requires<ArgumentNullException>(events != null);
        }

        #endregion

        #region Public Properties

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (value == this.description)
                {
                    return;
                }

                this.description = value;
                this.NotifyOfPropertyChange();
            }
        }

        #endregion
    }
}