using SharpPcap;
using VigilantNetworkMonitor.Model;

namespace VigilantNetworkMonitor.Service
{

    public interface INetworkOptions
    {

        MyCaptureDeviceWrapper? GetSelectedCaptureDeviceWrapper();
        void SetSelectedCaptureDeviceWrapper(MyCaptureDeviceWrapper selectedCaptureDeviceWrapper);
        ICollection<MyCaptureDeviceWrapper> GetDeviceList();

    }

    internal class NetworkOptions : INetworkOptions
    {

        private MyCaptureDeviceWrapper? selectedCaptureDeviceWrapper;

        public NetworkOptions()
        {
            CaptureDeviceList devices = CaptureDeviceList.Instance;
            foreach (ICaptureDevice dev in devices)
            {
                MyCaptureDeviceWrapper myCaptureDeviceWrapper = new MyCaptureDeviceWrapper(dev);
                if (myCaptureDeviceWrapper.IpAddress == null)
                {
                    continue;
                }

                if (myCaptureDeviceWrapper.GetName().Equals(Properties.Settings.Default.SelectedCaptureDeviceName))
                {
                    selectedCaptureDeviceWrapper = myCaptureDeviceWrapper;
                }
            }
        }

        public MyCaptureDeviceWrapper? GetSelectedCaptureDeviceWrapper()
        {
            return selectedCaptureDeviceWrapper;
        }

        public void SetSelectedCaptureDeviceWrapper(MyCaptureDeviceWrapper selectedCaptureDeviceWrapper)
        {
            this.selectedCaptureDeviceWrapper = selectedCaptureDeviceWrapper;
            Properties.Settings.Default.SelectedCaptureDeviceName = selectedCaptureDeviceWrapper.GetName();
            Properties.Settings.Default.Save();
        }

        public ICollection<MyCaptureDeviceWrapper> GetDeviceList()
        {
            ICollection<MyCaptureDeviceWrapper> deviceList = new LinkedList<MyCaptureDeviceWrapper>();
            CaptureDeviceList devices = CaptureDeviceList.Instance;
            foreach (ICaptureDevice dev in devices)
            {
                MyCaptureDeviceWrapper myCaptureDeviceWrapper = new MyCaptureDeviceWrapper(dev);
                if (myCaptureDeviceWrapper.IpAddress == null)
                {
                    continue;
                }

                deviceList.Add(myCaptureDeviceWrapper);
            }
            return deviceList;
        }

    }
}
