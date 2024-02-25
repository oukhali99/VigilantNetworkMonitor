using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class SourcePortPacketVariable : BasePacketVariable {
        internal const string VARIABLE_NAME = "src_port";

        public override MyNumberWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            ushort? sourcePort = myPacketWrapper.GetSourcePort();
            if (sourcePort == null) {
                return null;
            }
            return new MyNumberWrapper(sourcePort.Value);
        }

        public override Type GetValueType() {
            return typeof(MyNumberWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
