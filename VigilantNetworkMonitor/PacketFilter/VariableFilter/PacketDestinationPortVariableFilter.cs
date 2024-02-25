using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.Comparison.Base;
using VigilantNetworkMonitor.PacketFilter.VariableFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableFilter {
    internal class PacketDestinationPortVariableFilter : BasePacketVariableFilter<ushort> {

        public new const string VARIABLE_NAME = "dst_port";

        public PacketDestinationPortVariableFilter(IComparison<ushort> comparison) : base(comparison) {
        }

        public override bool Filter(MyPacketWrapper packet) {
            ushort? destinationPort = packet.GetDestinationPort();
            if (destinationPort == null) {
                return false;
            }
            return _comparison.GetResult(destinationPort.Value);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
