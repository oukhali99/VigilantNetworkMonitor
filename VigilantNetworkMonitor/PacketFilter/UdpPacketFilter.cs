using PacketDotNet;
using VigilantNetworkMonitor.PacketFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter
{
    internal class UdpPacketFilter : BasePacketFilter {
        public override bool Filter(MyPacketWrapper packet) {
            return packet.GetTransportPacket() is UdpPacket;
        }
        public override string GetFilterString() {
            return "udp";
        }
    }
}
