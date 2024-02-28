using PacketDotNet;
using VigilantNetworkMonitor.Packet.Filter.Base;

namespace VigilantNetworkMonitor.Packet.Filter {
    internal class UdpPacketFilter : BasePacketFilter {
        public override bool Filter(MyPacketWrapper packet) {
            return packet.GetTransportPacket() is UdpPacket;
        }
        public override string GetFilterString() {
            return "udp";
        }
    }
}
