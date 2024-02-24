using PacketDotNet;
using SharpPcap;

namespace VigilantNetworkMonitor {
    public class PacketsDataGridView : DataGridView {

        private INetworkOptions? _networkOptions;
        private IPacketFilterService _packetFilterService;

        public void Load(INetworkOptions networkOptions, IPacketFilterService packetFilterService) {
            _packetFilterService = packetFilterService;
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

        private void handlePacket(object s, PacketCapture e) {
            Packet packet = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
            MyPacketWrapper myPacketWrapper = new MyPacketWrapper(packet);

            if (!_packetFilterService.Filter(myPacketWrapper)) {
                return;
            }

            AddPacket(myPacketWrapper);
        }

        private void AddPacket(MyPacketWrapper myPacketWrapper) {
            if (InvokeRequired) {
                Invoke(new Action(() => AddPacket(myPacketWrapper)));
                return;
            }
            Rows.Add(
                myPacketWrapper.GetSourceAddress(),
                myPacketWrapper.GetSourcePort(),
                myPacketWrapper.GetDestinationAddress(),
                myPacketWrapper.GetDestinationPort(),
                myPacketWrapper.GetProtocol()
            );
            FirstDisplayedScrollingRowIndex = Rows.Count - 1;
        }

    }
}
