

namespace VigilantNetworkMonitor.PacketFilter {
    internal abstract class BasePacketFilter : IPacketFilter {
        public abstract bool Filter(MyPacketWrapper packet);
        public abstract override string ToString();
    }
}
