using PacketDotNet;
using SharpPcap;

namespace VigilantNetworkMonitor {
    public class PacketsDataGridView : DataGridView {

        private readonly INetworkOptions _networkOptions;

        public PacketsDataGridView(INetworkOptions networkOptions) {
            _networkOptions = networkOptions;
        }

        public void StartSniffing() {
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
            MyCaptureDeviceWrapper? myCaptureDeviceWrapper = _networkOptions.GetSelectedCaptureDeviceWrapper();
            if (myCaptureDeviceWrapper == null) {
                return;
            }

            myCaptureDeviceWrapper.StopCapture();
            myCaptureDeviceWrapper.Close();
        }

        public bool IsSniffing() {
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
