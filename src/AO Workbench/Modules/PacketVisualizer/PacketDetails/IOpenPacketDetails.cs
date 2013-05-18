namespace SmokeLounge.AoWorkbench.Modules.PacketVisualizer.PacketDetails
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IOpenPacketDetailsContract))]
    public interface IOpenPacketDetails
    {
        void OpenDetailsInNewTab(PacketViewModel packet);
    }

    [ContractClassFor(typeof(IOpenPacketDetails))]
    internal abstract class IOpenPacketDetailsContract : IOpenPacketDetails
    {
        public void OpenDetailsInNewTab(PacketViewModel packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            throw new System.NotImplementedException();
        }
    }
}