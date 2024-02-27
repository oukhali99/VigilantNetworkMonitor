using PacketDotNet;
using SharpPcap;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.PacketFilter.Service;

namespace VigilantNetworkMonitor {
    public class PacketsDataGridView : DataGridView {

        private IPacketFilterService? _packetFilterService;
        private IGeneralOptions? _generalOptions;
        private IColumnOptions? _columnOptions;
        private IPacketSnifferService? _packetSnifferService;

        public void Load(
            IPacketFilterService packetFilterService,
            IGeneralOptions generalOptions,
            IColumnOptions columnOptions,
            IPacketSnifferService packetSnifferService
        ) {
            _packetFilterService = packetFilterService;
            _generalOptions = generalOptions;
            _packetFilterService.AddChangedFilterStringEventHandler(onFilterChanged);
            _columnOptions = columnOptions;
            _packetSnifferService = packetSnifferService;

            _packetSnifferService.AddPacketSniffedEventHandler(onPacketSniffed);

            // Add the columns to the column options list
            foreach (DataGridViewColumn column in Columns) {
                _columnOptions.AddColumn(column);
            }
            refreshDisplayedColumns();
            _columnOptions.AddChangedEnabledColumnsEventHandler(handleEnabledColumnsChangedEvent);
        }

        private void addPacket(MyPacketWrapper myPacketWrapper) {
            if (_packetFilterService == null) {
                return;
            }
            if (!_packetFilterService.Filter(myPacketWrapper)) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action(() => addPacket(myPacketWrapper)));
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
                myPacketWrapper.GetPayloadHexadecimal(),
                myPacketWrapper.GetPayloadBase64()
            );

            if (_generalOptions != null && _generalOptions.IsAutoScrollEnabled()) {
                ScrollToBottom();
            }
        }

        private void onFilterChanged(object? sender, IPacketFilterService.FilterStringEventArgs e) {
            if (_packetFilterService == null || _packetSnifferService == null) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action(() => onFilterChanged(sender, e)));
                return;
            }
            Rows.Clear();
            foreach (MyPacketWrapper myPacketWrapper in _packetSnifferService.GetPackets()) {
                if (!_packetFilterService.Filter(myPacketWrapper)) {
                    continue;
                }

                addPacket(myPacketWrapper);
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

        private void onPacketSniffed(object sender, IPacketSnifferService.PacketSniffedEventArgs e) {
            addPacket(e.Packet);
        }

    }
}
