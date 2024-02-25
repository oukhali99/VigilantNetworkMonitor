namespace VigilantNetworkMonitor.PacketVariable.Base {

    public interface IPacketVariable {
        IComparable? GetValue(MyPacketWrapper myPacketWrapper);
        string GetVariableName();
    }
}
