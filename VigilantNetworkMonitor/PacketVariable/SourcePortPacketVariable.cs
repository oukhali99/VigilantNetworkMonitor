using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class SourcePortPacketVariable : BasePacketVariable {
        internal const string VARIABLE_NAME = "src_port";

        public override IComparable? GetValue(MyPacketWrapper myPacketWrapper) {
            return myPacketWrapper.GetSourcePort();
        }

        public override string GetVariableName() {
            return VARIABLE_NAME;
        }
    }
}
