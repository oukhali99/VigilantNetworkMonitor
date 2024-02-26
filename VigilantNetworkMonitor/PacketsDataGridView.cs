using PacketDotNet;
using SharpPcap;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.PacketFilter.Service;

namespace VigilantNetworkMonitor {
    public class PacketsDataGridView : DataGridView {

        private INetworkOptions? _networkOptions;
        private IPacketFilterService? _packetFilterService;
        private ICollection<MyPacketWrapper> packets;
        private IGeneralOptions? _generalOptions;
        private IColumnOptions? _columnOptions;

        public PacketsDataGridView() {
            packets = new LinkedList<MyPacketWrapper>();
        }

        public void Load(
            INetworkOptions networkOptions,
            IPacketFilterService packetFilterService,
            IGeneralOptions generalOptions,
            IColumnOptions columnOptions
        ) {
            _packetFilterService = packetFilterService;
            _networkOptions = networkOptions;
            _generalOptions = generalOptions;
            _packetFilterService.AddChangedFilterStringEventHandler(onFilterChanged);
            _columnOptions = columnOptions;

            // Add the columns to the column options list
            foreach (DataGridViewColumn column in Columns) {
                _columnOptions.AddColumn(column);
            }
            refreshDisplayedColumns();
            _columnOptions.AddChangedEnabledColumnsEventHandler(handleEnabledColumnsChangedEvent);
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
            if (_packetFilterService == null) {
                return;
            }

            Packet packet = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
            MyPacketWrapper myPacketWrapper = new MyPacketWrapper(packet);

            if (!_packetFilterService.Filter(myPacketWrapper)) {
                return;
            }

            packets.Add(myPacketWrapper);
            AddPacket(myPacketWrapper);
        }

        private void AddPacket(MyPacketWrapper myPacketWrapper) {
            if (InvokeRequired) {
                Invoke(new Action(() => AddPacket(myPacketWrapper)));
                return;
            }
            //Rows.Add();
            //DataGridViewRow newRow = Rows[Rows.Count - 1];
            //newRow.Cells["sourceIp"].Value = myPacketWrapper.GetSourceAddress();
            //newRow.Cells["destinationIp"].Value = myPacketWrapper.GetDestinationAddress();

            Rows.Add(
                myPacketWrapper.GetSourceAddress(),
                myPacketWrapper.GetSourcePort(),
                myPacketWrapper.GetDestinationAddress(),
                myPacketWrapper.GetDestinationPort(),
                myPacketWrapper.GetProtocol(),
                myPacketWrapper.GetPayloadHexadecimal()
            );

            if (_generalOptions != null && _generalOptions.IsAutoScrollEnabled()) {
                ScrollToBottom();
            }
        }

        private void onFilterChanged(object? sender, EventArgs e) {
            if (_packetFilterService == null) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action(() => onFilterChanged(sender, e)));
                return;
            }
            Rows.Clear();
            foreach (MyPacketWrapper myPacketWrapper in packets) {
                if (!_packetFilterService.Filter(myPacketWrapper)) {
                    continue;
                }

                AddPacket(myPacketWrapper);
            }
        }

        internal void ScrollToBottom() {
            if (Rows.Count == 0) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action(() => ScrollToBottom()));
                return;
            }

            FirstDisplayedScrollingRowIndex = Rows.Count - 1;
        }

        private void refreshDisplayedColumns() {
            if (_columnOptions == null) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action(() => refreshDisplayedColumns()));
                return;
            }
            foreach (DataGridViewColumn column in Columns) {
                column.Visible = _columnOptions.IsColumnEnabled(column.Name);
            }
        }

        private void handleEnabledColumnsChangedEvent(object? sender, EventArgs e) {
            refreshDisplayedColumns();
        }

    }
}
