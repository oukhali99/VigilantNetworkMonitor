using SharpPcap;

namespace VigilantNetworkMonitor {
    public class MyCaptureDeviceWrapper {

        private ICaptureDevice _captureDevice;

        public string? FriendlyName { get; }
        public string? IpAddress { get; }

        public MyCaptureDeviceWrapper(ICaptureDevice captureDevice) {
            _captureDevice = captureDevice;

            string? devInfo = captureDevice.ToString();
            if (devInfo == null) {
                return;
            }

            string[] lines = devInfo.Split('\n');

            // Process each line to extract the desired information
            foreach (var line in lines) {
                if (line.StartsWith("FriendlyName:")) {
                    // Extract FriendlyName
                    FriendlyName = line.Split(':')[1].Trim();
                }
                else if (line.StartsWith("Addr:") && IpAddress == null) {
                    // Extract IP Address
                    IpAddress = line.Split(':')[1].Trim();
                }
            }
        }

        public bool IsStarted() {
            return _captureDevice.Started;
        }

        public void StopCapture() {
            _captureDevice.StopCapture();
        }

        public void Open() {
            _captureDevice.Open();
        }

        public void Close() {
            _captureDevice.Close();
        }

        public void AddPacketArrivalHandler(PacketArrivalEventHandler handler) {
            _captureDevice.OnPacketArrival += handler;
        }

        public void StartCapture() {
            _captureDevice.StartCapture();
        }

        public string GetName() {
            return _captureDevice.Name;
        }

    }
}
