using System.Text;

namespace VigilantNetworkMonitor.PacketFilter {
    internal class PacketFilterOrConcatenator : BasePacketFilterConcatenator {
        internal PacketFilterOrConcatenator(params IPacketFilter[] filters) : base(filters) {
        }

        public override bool Filter(MyPacketWrapper packet) {
            foreach (IPacketFilter filter in _filters) {
                if (filter.Filter(packet)) {
                    return true;
                }
            }
            return false;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            foreach (IPacketFilter filter in _filters) {
                if (sb.Length > 1) {
                    sb.Append(" or ");
                }
                sb.Append(filter.ToString());
            }
            sb.Append(')');
            return sb.ToString();
        }
    }
}
