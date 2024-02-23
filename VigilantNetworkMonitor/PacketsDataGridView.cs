using PacketDotNet;
using PacketDotNet.Ieee80211;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor {
    internal class PacketsDataGridView : DataGridView {

        private NetworkInterfacesDataGridView? networkInterfacesDataGridView;

        public void Load(NetworkInterfacesDataGridView networkInterfacesDataGridView) {
            this.networkInterfacesDataGridView = networkInterfacesDataGridView;
        }

        public void StartSniffing() {
            if (networkInterfacesDataGridView == null) {
                return;
            }
            if (networkInterfacesDataGridView.SelectedCaptureDeviceWrapper == null) {
                return;
            }

            MyCaptureDeviceWrapper myCaptureDeviceWrapper = networkInterfacesDataGridView.SelectedCaptureDeviceWrapper;
            if (myCaptureDeviceWrapper.IsStarted()) {
                myCaptureDeviceWrapper.StopCapture();
            }

            myCaptureDeviceWrapper.Open();
            myCaptureDeviceWrapper.AddPacketArrivalHandler(handlePacket);
            myCaptureDeviceWrapper.StartCapture();
        }

        public void StopSniffing() {
            if (networkInterfacesDataGridView == null) {
                return;
            }

            MyCaptureDeviceWrapper? myCaptureDeviceWrapper = networkInterfacesDataGridView.SelectedCaptureDeviceWrapper;
            if (myCaptureDeviceWrapper == null) {
                return;
            }

            myCaptureDeviceWrapper.StopCapture();
            myCaptureDeviceWrapper.Close();
        }

        public bool IsSniffing() {
            if (networkInterfacesDataGridView == null) {
                return false;
            }
            if (networkInterfacesDataGridView.SelectedCaptureDeviceWrapper == null) {
                return false;
            }
            return networkInterfacesDataGridView.SelectedCaptureDeviceWrapper.IsStarted();
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
        }

    }
}
