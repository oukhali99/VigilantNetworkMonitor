using SharpPcap;

namespace VigilantNetworkMonitor {
    public class NetworkInterfacesDataGridView : DataGridView {

        private readonly INetworkOptions _networkOptions;

        public NetworkInterfacesDataGridView(INetworkOptions networkOptions) {
            _networkOptions = networkOptions;
        }

        public void Load() {
            foreach (MyCaptureDeviceWrapper myCaptureDeviceWrapper in _networkOptions.GetDeviceList()) {
                Rows.Add(myCaptureDeviceWrapper.FriendlyName, myCaptureDeviceWrapper.IpAddress);
            }
        }

        public void OnClickedRow(int rowIndex) {
            MyCaptureDeviceWrapper selectedCaptureDeviceWrapper = _networkOptions.GetDeviceList().ElementAt(rowIndex);
            _networkOptions.SetSelectedCaptureDeviceWrapper(selectedCaptureDeviceWrapper);
        }

    }
}
