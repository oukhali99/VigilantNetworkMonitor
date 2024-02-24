using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantNetworkMonitor {
    internal class MyCaptureDeviceWrapper {

        private ICaptureDevice captureDevice;

        public string FriendlyName { get; }
        public string IpAddress { get; }

        public MyCaptureDeviceWrapper(ICaptureDevice captureDevice) {
            this.captureDevice = captureDevice;

            string devInfo = captureDevice.ToString();
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
            return captureDevice.Started;
        }

        public void StopCapture() {
            captureDevice.StopCapture();
        }

        public void Open() {
            captureDevice.Open();
        }

        public void Close() {
            captureDevice.Close();
        }

        public void AddPacketArrivalHandler(PacketArrivalEventHandler handler) {
            captureDevice.OnPacketArrival += handler;
        }

        public void StartCapture() {
            captureDevice.StartCapture();
        }

        public string GetName() {
            return captureDevice.Name;
        }

    }
}
