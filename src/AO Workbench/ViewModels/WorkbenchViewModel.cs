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

namespace SmokeLounge.AOWorkbench.ViewModels
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOWorkbench.Components.Events.Workbench;
    using SmokeLounge.AOWorkbench.Components.Services;
    using SmokeLounge.AOWorkbench.Models;
    using SmokeLounge.AOWorkbench.Models.Workbench;
    using SmokeLounge.AOWorkbench.ViewModels.Workbench.Anchorables;
    using SmokeLounge.AOWorkbench.ViewModels.Workbench.Documents;

    [Export(typeof(IWorkbench))]
    public class WorkbenchViewModel : Screen, 
                                      IWorkbench, 
                                      IHandleMessage<ItemClosedEvent>, 
                                      IHandleMessage<ItemOpenedEvent>
    {
        #region Fields

        private readonly IObservableCollection<IAnchorableItem> anchorables;

        private readonly IBus bus;

        private readonly IObservableCollection<IDocumentItem> documents;

        private readonly IProcessModulesService processModulesService;

        private IItem activeContent;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public WorkbenchViewModel(IProcessModulesService processModulesService, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(processModulesService != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.processModulesService = processModulesService;
            this.bus = bus;
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

        public void Handle(ItemOpenedEvent message)
        {
            Contract.Assume(message != null);

            var document = message.Item as IDocumentItem;
            if (document != null)
            {
                if (this.documents.Contains(document) == false)
                {
                    this.documents.Add(document);
                }

                this.ActiveContent = document;
                return;
            }

            var anchorable = message.Item as IAnchorableItem;
            if (anchorable != null)
            {
                if (this.anchorables.Contains(anchorable) == false)
                {
                    this.anchorables.Add(anchorable);
                }

                this.ActiveContent = anchorable;
            }
        }

        #endregion

        #region Methods

        protected override void OnInitialize()
        {
            this.bus.Subscribe(this);

            var start = new StartViewModel(this.bus);
            this.documents.Add(start);

            var configurationLoaded = this.LoadConfiguration();
            if (configurationLoaded == false)
            {
                this.anchorables.Add(new ProcessListViewModel(this.processModulesService, this.bus));
                this.anchorables.Add(new PropertiesViewModel(this.bus));
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
            Contract.Invariant(this.bus != null);
            Contract.Invariant(this.processModulesService != null);
        }

        #endregion
    }
}