namespace VigilantNetworkMonitor.PacketVariable.Base {
    internal abstract class BasePacketVariable : IPacketVariable {
        public abstract IComparable? GetValue(MyPacketWrapper myPacketWrapper);
        public abstract string GetVariableName();
    }
}
