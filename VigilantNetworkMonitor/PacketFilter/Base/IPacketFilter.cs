namespace VigilantNetworkMonitor.PacketFilter.Base
{
    public interface IPacketFilter
    {
        bool Filter(MyPacketWrapper packet);
        string GetFilterString();
    }
}
