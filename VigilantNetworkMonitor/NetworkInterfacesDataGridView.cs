using SharpPcap;

namespace VigilantNetworkMonitor {
    internal class NetworkInterfacesDataGridView : DataGridView {

        private ICollection<MyCaptureDeviceWrapper> deviceList;

        public MyCaptureDeviceWrapper? SelectedCaptureDeviceWrapper { get; private set; }

        public NetworkInterfacesDataGridView() {
            deviceList = new LinkedList<MyCaptureDeviceWrapper>();
            CaptureDeviceList devices = CaptureDeviceList.Instance;
            foreach (ICaptureDevice dev in devices) {
                MyCaptureDeviceWrapper myCaptureDeviceWrapper = new MyCaptureDeviceWrapper(dev);
                if (myCaptureDeviceWrapper.IpAddress == null) {
                    continue;
                }

                deviceList.Add(myCaptureDeviceWrapper);

                if (myCaptureDeviceWrapper.GetName().Equals(Properties.Settings.Default.SelectedCaptureDeviceName)) {
                    SelectedCaptureDeviceWrapper = myCaptureDeviceWrapper;
                }
            }
        }

        public void Load() {
            Rows.Clear();
            foreach (MyCaptureDeviceWrapper myCaptureDeviceWrapper in deviceList) {
                Rows.Add(myCaptureDeviceWrapper.FriendlyName, myCaptureDeviceWrapper.IpAddress);
            }
        }

        public void OnClickedRow(int rowIndex) {
            SelectedCaptureDeviceWrapper = deviceList.ElementAt(rowIndex);
            Properties.Settings.Default.SelectedCaptureDeviceName = SelectedCaptureDeviceWrapper.GetName();
            Properties.Settings.Default.Save();
        }

    }
}
