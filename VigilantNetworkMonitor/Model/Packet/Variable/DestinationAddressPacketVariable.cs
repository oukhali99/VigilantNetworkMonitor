using System.Net;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Packet.Variable.Base;

namespace VigilantNetworkMonitor.Packet.Variable {
    internal class DestinationAddressPacketVariable : BasePacketVariable {
        public const string VARIABLE_NAME = "dst_addr";

        public override MyQuantifiableValueWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            IPAddress? destinationAddress = myPacketWrapper.GetDestinationAddress();
            if (destinationAddress == null) {
                return null;
            }
            return new MyQuantifiableValueWrapper(destinationAddress);
        }

        public override Type GetValueType() {
            return typeof(MyQuantifiableValueWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
