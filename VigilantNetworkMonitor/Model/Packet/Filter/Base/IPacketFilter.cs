namespace VigilantNetworkMonitor.Packet.Filter.Base
{
    public interface IPacketFilter
    {
        bool Filter(MyPacketWrapper packet);
        string GetFilterString();
    }
}
