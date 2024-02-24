using PacketDotNet;
using SharpPcap;

namespace VigilantNetworkMonitor {
    public class PacketsDataGridView : DataGridView {

        private INetworkOptions? _networkOptions;

        public void Load(INetworkOptions networkOptions) {
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
                myPacketWrapper.GetDestinationPort()
            );
            FirstDisplayedScrollingRowIndex = Rows.Count - 1;
        }

    }
}
