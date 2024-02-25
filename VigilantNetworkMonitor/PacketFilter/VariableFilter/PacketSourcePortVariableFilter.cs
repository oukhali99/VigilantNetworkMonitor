using VigilantNetworkMonitor.Comparison.Base;
using VigilantNetworkMonitor.PacketFilter.VariableFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter.VariableFilter {
    internal class PacketSourcePortVariableFilter : BasePacketVariableFilter<ushort> {

        public new const string VARIABLE_NAME = "src_port";

        public PacketSourcePortVariableFilter(IComparison<ushort> comparison) : base(comparison) {
        }

        public override bool Filter(MyPacketWrapper packet) {
            ushort? sourcePort = packet.GetSourcePort();
            if (sourcePort == null) {
                return false;
            }
            return _comparison.GetResult(sourcePort.Value);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
