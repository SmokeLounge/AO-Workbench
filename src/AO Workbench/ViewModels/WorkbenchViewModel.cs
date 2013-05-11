// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkbenchViewModel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the WorkbenchViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.ViewModels
{
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.ViewModels.Workbench;

    [Export(typeof(IWorkbench))]
    public class WorkbenchViewModel : Screen, IWorkbench
    {
        #region Fields

        private readonly IObservableCollection<IAnchorableItem> anchorables;

        private readonly IObservableCollection<IDocumentItem> documents;

        private IItem activeContent;

        #endregion

        #region Constructors and Destructors

        public WorkbenchViewModel()
        {
            this.anchorables = new BindableCollection<IAnchorableItem>();
            this.documents = new BindableCollection<IDocumentItem>();
        }

        #endregion

        #region Public Properties

        public IItem ActiveContent
        {
            get
            {
                return this.activeContent;
            }

            set
            {
                if (Equals(value, this.activeContent))
                {
                    return;
                }

                this.activeContent = value;
                this.NotifyOfPropertyChange();
            }
        }

        public IObservableCollection<IAnchorableItem> Anchorables
        {
            get
            {
                return this.anchorables;
            }
        }

        public IObservableCollection<IDocumentItem> Documents
        {
            get
            {
                return this.documents;
            }
        }

        #endregion
    }
}