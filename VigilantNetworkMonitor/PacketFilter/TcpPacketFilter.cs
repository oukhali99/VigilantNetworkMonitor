using PacketDotNet;
using System.Reflection.Metadata.Ecma335;
using VigilantNetworkMonitor.PacketFilter.Base;

namespace VigilantNetworkMonitor.PacketFilter
{
    internal class TcpPacketFilter : BasePacketFilter {
        public override bool Filter(MyPacketWrapper packet) {
            return packet.GetTransportPacket() is TcpPacket;
        }
        public override string GetFilterString() {
            return "tcp";
        }
    }
}
