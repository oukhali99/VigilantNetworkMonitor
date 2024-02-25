using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor.PacketVariable.Base {

    public interface IPacketVariable {
        IComparable? GetValue(MyPacketWrapper myPacketWrapper);
        string GetVariableName();
    }
}
