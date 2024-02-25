using VigilantNetworkMonitor.PacketFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableFilter.Base {
    internal interface IPacketVariableFilter<E> : IPacketFilter where E : IComparable {
    }
}
