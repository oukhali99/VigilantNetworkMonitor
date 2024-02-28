using System.Text;
using VigilantNetworkMonitor.Packet.Filter.Base;

namespace VigilantNetworkMonitor.Packet.Filter {
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

        public override string GetFilterString() {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            foreach (IPacketFilter filter in _filters) {
                if (sb.Length > 1) {
                    sb.Append(" or ");
                }
                sb.Append(filter.GetFilterString());
            }
            sb.Append(')');
            return sb.ToString();
        }
    }
}
