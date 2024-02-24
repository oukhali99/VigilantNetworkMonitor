
namespace VigilantNetworkMonitor.PacketFilter {
    public interface IPacketFilter {
        bool Filter(MyPacketWrapper packet);
    }
}
