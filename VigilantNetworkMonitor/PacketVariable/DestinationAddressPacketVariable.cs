using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class DestinationAddressPacketVariable : BasePacketVariable {
        public const string VARIABLE_NAME = "dst_addr";

        public override MyNumberWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            IPAddress? destinationAddress = myPacketWrapper.GetDestinationAddress();
            if (destinationAddress == null) {
                return null;
            }
            return new MyNumberWrapper(destinationAddress);
        }

        public override Type GetValueType() {
            return typeof(MyNumberWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
