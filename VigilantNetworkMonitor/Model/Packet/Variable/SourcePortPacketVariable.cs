using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Packet.Variable.Base;

namespace VigilantNetworkMonitor.Packet.Variable {
    internal class SourcePortPacketVariable : BasePacketVariable {
        internal const string VARIABLE_NAME = "src_port";

        public override MyQuantifiableValueWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            ushort? sourcePort = myPacketWrapper.GetSourcePort();
            if (sourcePort == null) {
                return null;
            }
            return new MyQuantifiableValueWrapper(sourcePort.Value);
        }

        public override Type GetValueType() {
            return typeof(MyQuantifiableValueWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
