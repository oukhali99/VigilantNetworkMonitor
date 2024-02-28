using PacketDotNet;
using VigilantNetworkMonitor.Packet.Filter.Base;

namespace VigilantNetworkMonitor.Packet.Filter
{
    internal class TcpPacketFilter : BasePacketFilter
    {
        public override bool Filter(MyPacketWrapper packet)
        {
            return packet.GetTransportPacket() is TcpPacket;
        }
        public override string GetFilterString()
        {
            return "tcp";
        }
    }
}
