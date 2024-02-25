using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.Comparison;
using VigilantNetworkMonitor.Comparison.Base;
using VigilantNetworkMonitor.PacketFilter.VariableFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableFilter {
    internal class PacketSourcePortVariableFilter : BasePacketVariableFilter<ushort> {
        public PacketSourcePortVariableFilter(IComparison<ushort> comparison) : base(comparison) {
        }

        public override bool Filter(MyPacketWrapper packet) {
            ushort? sourcePort = packet.GetSourcePort();
            if (sourcePort == null) {
                return false;
            }
            return _comparison.GetResult(sourcePort.Value);
        }

        public override string GetFilterString() {
            return "src_port comp" + _comparison.ToString();
        }
    }
}
