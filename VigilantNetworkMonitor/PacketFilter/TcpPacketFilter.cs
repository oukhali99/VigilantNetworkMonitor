using PacketDotNet;
using System.Reflection.Metadata.Ecma335;

namespace VigilantNetworkMonitor.PacketFilter {
    internal class TcpPacketFilter : BasePacketFilter {
        public override bool Filter(MyPacketWrapper packet) {
            return packet.GetTransportPacket() is TcpPacket;
        }
        public override string ToString() {
            return "tcp";
        }
    }
}
