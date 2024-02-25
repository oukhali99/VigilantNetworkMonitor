using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class DestinationPortPacketVariable : BasePacketVariable {
        internal const string VARIABLE_NAME = "dst_port";

        public override MyQuantifiableValueWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            ushort? destinationPort = myPacketWrapper.GetDestinationPort();
            if (destinationPort == null) {
                return null;
            }
            return new MyQuantifiableValueWrapper(destinationPort.Value);
        }

        public override Type GetValueType() {
            return typeof(MyQuantifiableValueWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
