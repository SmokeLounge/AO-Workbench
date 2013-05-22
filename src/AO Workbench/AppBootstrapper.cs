// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppBootstrapper.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AppBootstrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Domain.Facade;
    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AoWorkbench.Controls;
    using SmokeLounge.AoWorkbench.Models;

    public sealed class AppBootstrapper : Bootstrapper<IShell>, IDisposable
    {
        #region Fields

        private CompositionContainer container;

        #endregion

        #region Public Methods and Operators

        public void Dispose()
        {
            if (this.container == null)
            {
                return;
            }

            this.container.Dispose();
            this.container = null;
        }

        #endregion

        #region Methods

        protected override void BuildUp(object instance)
        {
            Contract.Assume(this.container != null);

            this.container.SatisfyImportsOnce(instance);
        }

        protected override void Configure()
        {
            Contract.Ensures(this.container != null);
            var catalog = new ApplicationCatalog();

            this.container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(this.container);
            batch.AddExportedValue(catalog);

            this.container.Compose(batch);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            Contract.Ensures(Contract.Result<IEnumerable<object>>() != null);
            Contract.Assume(this.container != null);

            return this.container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            Contract.Ensures(Contract.Result<object>() != null);
            Contract.Assume(this.container != null);

            var contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var export = this.container.GetExportedValues<object>(contract).FirstOrDefault();

            if (export != null)
            {
                return export;
            }

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            var domainEvents = (IDomainEventAggregator)this.GetInstance(typeof(IDomainEventAggregator), null);
            var domainEventHandlers = this.GetAllInstances(typeof(IHandleDomainEvent));
            domainEventHandlers.Apply(domainEvents.Unsubscribe);

            var domainBootstrapper = (IDomainBootstrapper)this.GetInstance(typeof(IDomainBootstrapper), null);
            domainBootstrapper.Shutdown();
            base.OnExit(sender, e);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            ViewLocator.GetOrCreateViewType = this.GetOrCreateViewType;

            var domainEvents = (IDomainEventAggregator)this.GetInstance(typeof(IDomainEventAggregator), null);
            var domainEventHandlers = this.GetAllInstances(typeof(IHandleDomainEvent));
            domainEventHandlers.Apply(domainEvents.Subscribe);

            var domainBootstrapper = (IDomainBootstrapper)this.GetInstance(typeof(IDomainBootstrapper), null);
            domainBootstrapper.Startup();
            base.OnStartup(sender, e);
        }

        private UIElement GetOrCreateViewType(Type viewType)
        {
            Contract.Requires(viewType != null);
            var cached = IoC.GetAllInstances(viewType).OfType<UIElement>().FirstOrDefault();
            if (cached != null)
            {
                ViewLocator.InitializeComponent(cached);
                return cached;
            }

            if (viewType.IsInterface || viewType.IsAbstract || !typeof(UIElement).IsAssignableFrom(viewType))
            {
                return new TextBlock { Text = string.Format("Cannot create {0}.", viewType.FullName) };
            }

            var newInstance = (UIElement)Activator.CreateInstance(viewType);
            var frameworkElement = newInstance as FrameworkElement;
            if (frameworkElement != null)
            {
                var themeManager = (IThemeManager)this.GetInstance(typeof(IThemeManager), null);
                frameworkElement.Resources.MergedDictionaries.Add(themeManager.GetThemeResources());
            }

            ViewLocator.InitializeComponent(newInstance);
            return newInstance;
        }

        #endregion
    }
}