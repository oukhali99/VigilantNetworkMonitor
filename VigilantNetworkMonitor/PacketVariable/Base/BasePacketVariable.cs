using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor.PacketVariable.Base
{
    internal abstract class BasePacketVariable : IPacketVariable {
        public abstract IComparable? GetValue(MyPacketWrapper myPacketWrapper);
        public abstract string GetVariableName();
    }
}
