using SharpPcap;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Packet;

namespace VigilantNetworkMonitor.Service {
    public interface IPacketSnifferService {
        ICollection<MyPacketWrapper> GetPackets();
        bool IsSniffing();
        void StartSniffing();
        void StopSniffing();
        void AddPacketSniffedEventHandler(PacketSnifferEventHandler handler);
        delegate void PacketSnifferEventHandler(object sender, PacketSniffedEventArgs e);

        class PacketSniffedEventArgs : EventArgs {
            public MyPacketWrapper Packet { get; }

            public PacketSniffedEventArgs(MyPacketWrapper packet) {
                Packet = packet;
            }
        }
    }

    internal class PacketSnifferService : IPacketSnifferService {
        private INetworkOptions? _networkOptions;
        private ICollection<MyPacketWrapper> packets;
        private event IPacketSnifferService.PacketSnifferEventHandler? _packetSniffed;

        public PacketSnifferService(
            INetworkOptions networkOptions
        ) {
            packets = new LinkedList<MyPacketWrapper>();
            _networkOptions = networkOptions;
        }

        public void StartSniffing() {
            if (_networkOptions == null) {
                return;
            }

            MyCaptureDeviceWrapper? myCaptureDeviceWrapper = _networkOptions.GetSelectedCaptureDeviceWrapper();
            if (myCaptureDeviceWrapper == null) {
                return;
            }

            if (myCaptureDeviceWrapper.IsStarted()) {
                myCaptureDeviceWrapper.StopCapture();
            }

            myCaptureDeviceWrapper.Open();
            myCaptureDeviceWrapper.AddPacketArrivalHandler(handlePacket);
            myCaptureDeviceWrapper.StartCapture();
        }

        public void StopSniffing() {
            if (_networkOptions == null) {
                return;
            }

            MyCaptureDeviceWrapper? myCaptureDeviceWrapper = _networkOptions.GetSelectedCaptureDeviceWrapper();
            if (myCaptureDeviceWrapper == null) {
                return;
            }

            myCaptureDeviceWrapper.StopCapture();
            myCaptureDeviceWrapper.Close();
        }

        public bool IsSniffing() {
            if (_networkOptions == null) {
                return false;
            }

            MyCaptureDeviceWrapper? myCaptureDeviceWrapper = _networkOptions.GetSelectedCaptureDeviceWrapper();
            if (myCaptureDeviceWrapper == null) {
                return false; ;
            }
            return myCaptureDeviceWrapper.IsStarted();
        }

        public ICollection<MyPacketWrapper> GetPackets() {
            return new LinkedList<MyPacketWrapper>(packets);
        }

        private void handlePacket(object s, PacketCapture e) {
            PacketDotNet.Packet packet = PacketDotNet.Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
            MyPacketWrapper myPacketWrapper = new MyPacketWrapper(packet);

            packets.Add(myPacketWrapper);
            _packetSniffed?.Invoke(this, new IPacketSnifferService.PacketSniffedEventArgs(myPacketWrapper));
        }

        public void AddPacketSniffedEventHandler(IPacketSnifferService.PacketSnifferEventHandler handler) {
            _packetSniffed += handler;
        }
    }
}
