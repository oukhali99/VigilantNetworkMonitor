using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilantNetworkMonitor.PacketVariable.Base;

namespace VigilantNetworkMonitor.PacketVariable.Factory {
    public interface IPacketVariableFactory {
        IPacketVariable? Parse(string variableString);
    }

    internal class PacketVariableFactory : IPacketVariableFactory {
        public IPacketVariable? Parse(string variableString) {
            if (variableString.Equals(DestinationPortPacketVariable.VARIABLE_NAME)) {
                return new DestinationPortPacketVariable();
            }
            if (variableString.Equals(SourcePortPacketVariable.VARIABLE_NAME)) {
                return new SourcePortPacketVariable();
            }

            try {
                return new ConstantPacketVariable(ushort.Parse(variableString));
            }
            catch (Exception) {
            }

            try {
                return new ConstantPacketVariable(float.Parse(variableString));
            }
            catch (Exception) {
            }

            return null;
        }
    }
}
