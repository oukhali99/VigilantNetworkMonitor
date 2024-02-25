using System.Text;
using VigilantNetworkMonitor.PacketFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter {
    internal class PacketFilterAndConcatenator : BasePacketFilterConcatenator {

        internal PacketFilterAndConcatenator(params IPacketFilter[] filters) : base(filters) {
        }

        public override bool Filter(MyPacketWrapper packet) {
            foreach (IPacketFilter filter in _filters) {
                if (!filter.Filter(packet)) {
                    return false;
                }
            }
            return true;
        }

        public override string GetFilterString() {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            foreach (IPacketFilter filter in _filters) {
                if (sb.Length > 1) {
                    sb.Append(" and ");
                }
                sb.Append(filter.GetFilterString());
            }
            sb.Append(')');
            return sb.ToString();
        }
    }
}
