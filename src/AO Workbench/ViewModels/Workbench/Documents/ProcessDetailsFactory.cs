using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeLounge.AoWorkbench.ViewModels.Workbench.Documents
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    [Export]
    public class ProcessDetailsFactory
    {
        private readonly IEventAggregator events;

        [ImportingConstructor]
        public ProcessDetailsFactory(IEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(events != null);

            this.events = events;
        }

        public ProcessDetailsViewModel Create()
        {
            return new ProcessDetailsViewModel(this.events);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.events != null);
        }
    }
}
