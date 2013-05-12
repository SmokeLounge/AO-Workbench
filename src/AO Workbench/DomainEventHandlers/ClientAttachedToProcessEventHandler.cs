using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeLounge.AoWorkbench.DomainEventHandlers
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AoWorkbench.Components.Services;

    [Export(typeof(IHandleDomainEvent))]
    public class ClientAttachedToProcessEventHandler : IHandleDomainEvent<ClientAttachedToProcessEvent>
    {
        private readonly IRemoteProcessService remoteProcessService;

        [ImportingConstructor]
        public ClientAttachedToProcessEventHandler(IRemoteProcessService remoteProcessService)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessService != null);

            this.remoteProcessService = remoteProcessService;
        }

        public void Handle(ClientAttachedToProcessEvent message)
        {
            var remoteProcess = this.remoteProcessService.Get(message.RemoteProcessId);
            if (remoteProcess == null)
            {
                return;
            }

            remoteProcess.ClientId = message.ClientId;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcessService != null);
        }
    }
}
