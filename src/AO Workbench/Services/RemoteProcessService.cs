// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Services
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AOtomation.Domain.Facade;
    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AoWorkbench.ViewModels.Domain;

    [Export(typeof(IRemoteProcessService))]
    public class RemoteProcessService : IRemoteProcessService, IHandleDomainEvent<RemoteProcessCreatedEvent>
    {
        #region Fields

        private readonly IDomainEventAggregator domainEvents;

        private readonly RemoteProcessFactory remoteProcessFactory;

        private readonly IRemoteProcessQueryService remoteProcessQueryService;

        private readonly Lazy<IObservableCollection<IRemoteProcess>> remoteProcesses;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessService(
            IRemoteProcessQueryService remoteProcessQueryService, 
            RemoteProcessFactory remoteProcessFactory, 
            IDomainEventAggregator domainEvents)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessQueryService != null);
            Contract.Requires<ArgumentNullException>(remoteProcessFactory != null);
            Contract.Requires<ArgumentNullException>(domainEvents != null);

            this.remoteProcessQueryService = remoteProcessQueryService;
            this.remoteProcessFactory = remoteProcessFactory;
            this.domainEvents = domainEvents;

            this.remoteProcesses = new Lazy<IObservableCollection<IRemoteProcess>>(this.InitializeCollection);
        }

        #endregion

        #region Public Methods and Operators

        public IObservableCollection<IRemoteProcess> GetAll()
        {
            Contract.Assume(this.remoteProcesses.Value != null);
            return this.remoteProcesses.Value;
        }

        public void Handle(RemoteProcessCreatedEvent message)
        {
        }

        #endregion

        #region Methods

        private IObservableCollection<IRemoteProcess> InitializeCollection()
        {
            this.domainEvents.Subscribe(this);
            var remoteProcessDtos = this.remoteProcessQueryService.GetAll();

            var collection = new BindableCollection<IRemoteProcess>();

            foreach (var remoteProcessDto in remoteProcessDtos)
            {
                Contract.Assume(remoteProcessDto != null);
                var remoteProcess = this.remoteProcessFactory.Create(remoteProcessDto);
                collection.Add(remoteProcess);
            }

            return collection;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessQueryService != null);
            Contract.Invariant(this.remoteProcessFactory != null);
            Contract.Invariant(this.domainEvents != null);
            Contract.Invariant(this.remoteProcesses != null);
        }

        #endregion
    }
}