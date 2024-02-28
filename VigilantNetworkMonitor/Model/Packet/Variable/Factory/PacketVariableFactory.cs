using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Packet.Variable.Base;

namespace VigilantNetworkMonitor.Packet.Variable.Factory {
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
            if (variableString.Equals(SourceAddressPacketVariable.VARIABLE_NAME)) {
                return new SourceAddressPacketVariable();
            }
            if (variableString.Equals(DestinationAddressPacketVariable.VARIABLE_NAME)) {
                return new DestinationAddressPacketVariable();
            }

            MyQuantifiableValueWrapper? myNumberWrapper = MyQuantifiableValueWrapper.Parse(variableString);
            if (myNumberWrapper != null) {
                return new ConstantPacketVariable(myNumberWrapper);
            }

            return null;
        }
    }
}
