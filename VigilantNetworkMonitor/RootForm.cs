
using Microsoft.Extensions.DependencyInjection;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.Service;

namespace VigilantNetworkMonitor {
    public partial class RootForm : Form {

        private readonly INetworkOptions _networkOptions;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPacketFilterService _packetFilterService;

        public RootForm(
            INetworkOptions networkOptions,
            IServiceProvider serviceProvider,
            IPacketFilterService packetFilterService
        ) {
            _networkOptions = networkOptions;
            _serviceProvider = serviceProvider;
            _packetFilterService = packetFilterService;
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e) {
            packetDataGridView1.Load(_networkOptions, _packetFilterService);
        }

        private void sniffButton_Click(object sender, EventArgs e) {
            MyCaptureDeviceWrapper? selectedCaptureDeviceWrapper = _networkOptions.GetSelectedCaptureDeviceWrapper();
            if (selectedCaptureDeviceWrapper == null) {
                _serviceProvider.GetRequiredService<OptionsForm>().ShowDialog();
                return;
            }

            if (packetDataGridView1.IsSniffing()) {
                packetDataGridView1.StopSniffing();
            }
            else {
                packetDataGridView1.StartSniffing();
            }

            sniffButton.Text = packetDataGridView1.IsSniffing() ? "Stop" : "Sniff";
        }

        private void toolStripExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void options_Click(object sender, EventArgs e) {
            _serviceProvider.GetRequiredService<OptionsForm>().ShowDialog();
        }

        private void applyFilterButton_Click(object sender, EventArgs e) {
            _packetFilterService.SetFilterString(filterTextBox.Text);
            IPacketFilter? filter = _packetFilterService.GetFilter();
            if (filter == null) {
                toolStripErrorLabel.Text = "Invalid Filter";
                return;
            }
            toolStripErrorLabel.Text = "";
            //filterTextBox.Text = filter.GetFilterString();
        }
    }
}
