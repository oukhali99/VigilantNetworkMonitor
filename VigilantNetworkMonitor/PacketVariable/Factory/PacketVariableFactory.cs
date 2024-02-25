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
            if (variableString.Equals(SourceAddressPacketVariable.VARIABLE_NAME)) {
                return new SourceAddressPacketVariable();
            }
            if (variableString.Equals(DestinationAddressPacketVariable.VARIABLE_NAME)) {
                return new DestinationAddressPacketVariable();
            }

            MyNumberWrapper? myNumberWrapper = MyNumberWrapper.Parse(variableString);
            if (myNumberWrapper != null) {
                return new ConstantPacketVariable(myNumberWrapper);
            }

            return null;
        }
    }
}
