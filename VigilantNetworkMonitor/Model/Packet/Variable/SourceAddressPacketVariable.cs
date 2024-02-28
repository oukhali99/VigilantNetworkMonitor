using System.Net;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Packet.Variable.Base;

namespace VigilantNetworkMonitor.Packet.Variable {
    internal class SourceAddressPacketVariable : BasePacketVariable {
        public const string VARIABLE_NAME = "src_addr";

        public override MyQuantifiableValueWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            IPAddress? sourceAddress = myPacketWrapper.GetSourceAddress();
            if (sourceAddress == null) {
                return null;
            }
            return new MyQuantifiableValueWrapper(sourceAddress);
        }

        public override Type GetValueType() {
            return typeof(MyQuantifiableValueWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
