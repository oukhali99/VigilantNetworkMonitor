using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable {
    internal class ConstantPacketVariable : BasePacketVariable {
        private readonly IComparable _value;

        public ConstantPacketVariable(IComparable value)
        {
            _value = value;
        }

        public override IComparable? GetValue(MyPacketWrapper myPacketWrapper) {
            return _value;
        }

        public override string GetVariableName() {
            return _value.ToString();
        }
    }
}
