using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class ConstantPacketVariable : BasePacketVariable {
        private readonly MyNumberWrapper _value;

        public ConstantPacketVariable(MyNumberWrapper value) {
            _value = value;
        }

        public override MyNumberWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            return _value;
        }

        public override Type GetValueType() {
            return typeof(MyNumberWrapper);
        }

        public override string GetVariableName() {
            return _value.ToString();
        }
    }
}
