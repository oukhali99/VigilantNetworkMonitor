namespace VigilantNetworkMonitor.Packet.Variable.Base
{

    public interface IPacketVariable
    {
        IComparable? GetValue(MyPacketWrapper myPacketWrapper);
        string GetVariableName();
        Type GetValueType();
    }
}
