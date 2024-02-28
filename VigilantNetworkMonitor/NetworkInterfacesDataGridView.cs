using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Service;

namespace VigilantNetworkMonitor {
    public class NetworkInterfacesDataGridView : DataGridView {

        private INetworkOptions? _networkOptions;

        public void Load(INetworkOptions networkOptions) {
            _networkOptions = networkOptions;
            foreach (MyCaptureDeviceWrapper myCaptureDeviceWrapper in _networkOptions.GetDeviceList()) {
                Rows.Add(myCaptureDeviceWrapper.FriendlyName, myCaptureDeviceWrapper.IpAddress);
            }
        }

        public void OnClickedRow(int rowIndex) {
            if (_networkOptions == null) {
                return;
            }

            MyCaptureDeviceWrapper selectedCaptureDeviceWrapper = _networkOptions.GetDeviceList().ElementAt(rowIndex);
            _networkOptions.SetSelectedCaptureDeviceWrapper(selectedCaptureDeviceWrapper);
        }

    }
}
