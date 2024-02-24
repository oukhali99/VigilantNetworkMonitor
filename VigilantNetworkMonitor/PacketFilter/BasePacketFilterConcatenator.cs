

namespace VigilantNetworkMonitor.PacketFilter {
    internal abstract class BasePacketFilterConcatenator : IPacketFilter {
        protected IPacketFilter[] _filters { get; }

        protected BasePacketFilterConcatenator(params IPacketFilter[] filters) {
            _filters = filters;
        }

        public abstract bool Filter(MyPacketWrapper packet);
        public abstract override string ToString();
    }
}
