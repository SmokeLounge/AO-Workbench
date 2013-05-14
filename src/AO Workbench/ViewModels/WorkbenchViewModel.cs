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
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Events.Workbench;
    using SmokeLounge.AoWorkbench.Models;
    using SmokeLounge.AoWorkbench.Models.Workbench;
    using SmokeLounge.AoWorkbench.Modules.PacketVisualizer;
    using SmokeLounge.AoWorkbench.ViewModels.Workbench.Anchorables;
    using SmokeLounge.AoWorkbench.ViewModels.Workbench.Documents;

    [Export(typeof(IWorkbench))]
    public class WorkbenchViewModel : Screen, IWorkbench, IHandle<ItemClosedEvent>
    {
        #region Fields

        private readonly IObservableCollection<IAnchorableItem> anchorables;

        private readonly IObservableCollection<IDocumentItem> documents;

        private readonly IEventAggregator events;

        private IItem activeContent;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public WorkbenchViewModel(IEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(events != null);

            this.events = events;
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

        #region Public Methods and Operators

        public void Handle(ItemClosedEvent message)
        {
            Contract.Assume(message != null);

            var document = message.Item as IDocumentItem;
            if (document != null)
            {
                this.documents.Remove(document);
                return;
            }

            var anchorable = message.Item as IAnchorableItem;
            if (anchorable != null)
            {
                this.anchorables.Remove(anchorable);
            }
        }

        #endregion

        #region Methods

        protected override void OnInitialize()
        {
            this.events.Subscribe(this);

            var start = new StartViewModel(this.events);
            this.documents.Add(start);
            this.documents.Add(new PacketVisualizerViewModel(this.events));

            var configurationLoaded = this.LoadConfiguration();
            if (configurationLoaded == false)
            {
                this.anchorables.Add(new ProcessListViewModel(this.events));
                this.anchorables.Add(new PropertiesViewModel(this.events));
            }

            this.ActiveContent = start;

            base.OnInitialize();
        }

        private bool LoadConfiguration()
        {
            return false;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.anchorables != null);
            Contract.Invariant(this.documents != null);
            Contract.Invariant(this.events != null);
        }

        #endregion
    }
}