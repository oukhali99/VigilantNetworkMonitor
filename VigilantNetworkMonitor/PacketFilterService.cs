
using PacketDotNet;

namespace VigilantNetworkMonitor {
    public interface IPacketFilterService {
        bool Filter(MyPacketWrapper myPacketWrapper);
        void SetFilterString(string filterString);
    }

    public class PacketFilterService : IPacketFilterService {
        private string? _filterString;

        public bool Filter(MyPacketWrapper myPacketWrapper) {
            if (_filterString == null) {
                return true;
            }

            if (_filterString.Contains("udp")) {
                return myPacketWrapper.GetTransportPacket() is UdpPacket;
            }

            if (_filterString.Contains("tcp")) {
                return myPacketWrapper.GetTransportPacket() is TcpPacket;
            }

            return true;
        }

        public void SetFilterString(string filterString) {
            _filterString = filterString;
        }
    }
}
