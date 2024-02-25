using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class SourceAddressPacketVariable : BasePacketVariable {
        public const string VARIABLE_NAME = "src_addr";

        public override MyNumberWrapper? GetValue(MyPacketWrapper myPacketWrapper) {
            IPAddress? sourceAddress = myPacketWrapper.GetSourceAddress();
            if (sourceAddress == null) {
                return null;
            }
            return new MyNumberWrapper(sourceAddress);
        }

        public override Type GetValueType() {
            return typeof(MyNumberWrapper);
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
