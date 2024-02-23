using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor {
    internal class NetworkInterfacesDataGridView : DataGridView {

        private ICollection<MyCaptureDeviceWrapper> deviceList;

        public MyCaptureDeviceWrapper? SelectedCaptureDeviceWrapper { get; private set; }

        public NetworkInterfacesDataGridView() {
            deviceList = new LinkedList<MyCaptureDeviceWrapper>();
        }

        public void Load() {
            CaptureDeviceList devices = CaptureDeviceList.Instance;
            foreach (ICaptureDevice dev in devices) {
                MyCaptureDeviceWrapper myCaptureDeviceWrapper = new MyCaptureDeviceWrapper(dev);
                if (myCaptureDeviceWrapper.IpAddress == null) {
                    continue;
                }

                deviceList.Add(myCaptureDeviceWrapper);
                Rows.Add(myCaptureDeviceWrapper.FriendlyName, myCaptureDeviceWrapper.IpAddress);
            }

            SelectedCaptureDeviceWrapper = deviceList.ElementAt(0);
        }

        public void OnClickedRow(int rowIndex) {
            SelectedCaptureDeviceWrapper = deviceList.ElementAt(rowIndex);
        }

    }
}
