using PacketDotNet;
using System.Net;
using System.Text;

namespace VigilantNetworkMonitor.Packet {
    public class MyPacketWrapper {

        private PacketDotNet.Packet innerPacket;

        public MyPacketWrapper(PacketDotNet.Packet innerPacket) {
            this.innerPacket = innerPacket;
        }

        public IPAddress? GetSourceAddress() {
            IPPacket? ipPacket = getIpPacket();
            if (ipPacket == null) {
                return null;
            }
            return ipPacket.SourceAddress;
        }

        public IPAddress? GetDestinationAddress() {
            IPPacket? ipPacket = getIpPacket();
            if (ipPacket == null) {
                return null;
            }
            return ipPacket.DestinationAddress;
        }

        public ushort? GetSourcePort() {
            TransportPacket? transportPacket = GetTransportPacket();
            if (transportPacket == null) {
                return null;
            }
            return transportPacket.SourcePort;
        }

        public ushort? GetDestinationPort() {
            TransportPacket? transportPacket = GetTransportPacket();
            if (transportPacket == null) {
                return null;
            }
            return transportPacket.DestinationPort;
        }

        private IPPacket? getIpPacket() {
            if (innerPacket.PayloadPacket is not IPPacket) {
                return null;
            }
            return (IPPacket)innerPacket.PayloadPacket;
        }

        public TransportPacket? GetTransportPacket() {
            IPPacket? iPPacket = getIpPacket();
            if (iPPacket == null) {
                return null;
            }
            if (iPPacket.PayloadPacket is not TransportPacket) {
                return null;
            }

            return (TransportPacket)iPPacket.PayloadPacket;
        }

        internal object GetProtocol() {
            if (GetTransportPacket() is UdpPacket) {
                return "UDP";
            }
            if (GetTransportPacket() is TcpPacket) {
                return "TCP";
            }


            return "Unknown";
        }

        internal byte[]? GetPayload() {
            TransportPacket? transportPacket = GetTransportPacket();
            if (transportPacket == null) {
                return null;
            }
            return transportPacket.PayloadData;
        }

        internal string? GetPayloadBase64() {
            byte[]? payload = GetPayload();
            if (payload == null) {
                return null;
            }
            return Convert.ToBase64String(payload);
        }

        internal string? GetPayloadHexadecimal() {
            byte[]? payload = GetPayload();
            if (payload == null) {
                return null;
            }
            return Convert.ToHexString(payload);
        }

        internal string? GetPayloadASCII() {
            byte[]? payload = GetPayload();
            if (payload == null) {
                return null;
            }
            return Encoding.ASCII.GetString(payload);
        }
    }
}
