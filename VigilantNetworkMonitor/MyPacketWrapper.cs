using PacketDotNet;
using System.Net;

namespace VigilantNetworkMonitor {
    public class MyPacketWrapper {

        private Packet innerPacket;

        public MyPacketWrapper(Packet innerPacket) {
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

        public MyNumberWrapper? GetSourcePort() {
            TransportPacket? transportPacket = GetTransportPacket();
            if (transportPacket == null) {
                return null;
            }
            return new MyNumberWrapper(transportPacket.SourcePort);
        }

        public MyNumberWrapper? GetDestinationPort() {
            TransportPacket? transportPacket = GetTransportPacket();
            if (transportPacket == null) {
                return null;
            }
            return new MyNumberWrapper(transportPacket.DestinationPort);
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
    }
}
