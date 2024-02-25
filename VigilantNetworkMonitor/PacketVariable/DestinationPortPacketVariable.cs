using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class DestinationPortPacketVariable : BasePacketVariable {
        internal const string VARIABLE_NAME = "dst_port";

        public override MyNumberWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            ushort? destinationPort = myPacketWrapper.GetDestinationPort();
            if (destinationPort == null) {
                return null;
            }
            return new MyNumberWrapper(destinationPort.Value);
        }

        public override Type GetValueType() {
            return typeof(MyNumberWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
