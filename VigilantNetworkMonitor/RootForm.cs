
using Microsoft.Extensions.DependencyInjection;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.Service;

namespace VigilantNetworkMonitor {
    public partial class RootForm : Form {

        private readonly INetworkOptions _networkOptions;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPacketFilterService _packetFilterService;
        private readonly IGeneralOptions _generalOptions;
        private readonly IColumnOptions _columnOptions;

        public RootForm(
            INetworkOptions networkOptions,
            IServiceProvider serviceProvider,
            IPacketFilterService packetFilterService,
            IGeneralOptions generalOptions,
            IColumnOptions columnOptions
        ) {
            _networkOptions = networkOptions;
            _serviceProvider = serviceProvider;
            _packetFilterService = packetFilterService;
            _generalOptions = generalOptions;
            _columnOptions = columnOptions;
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e) {
            packetDataGridView1.Load(_networkOptions, _packetFilterService, _generalOptions, _columnOptions);
            autoScrollCheckBox.Checked = _generalOptions.IsAutoScrollEnabled();
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

        private void autoScrollCheckBox_CheckedChanged(object sender, EventArgs e) {
            _generalOptions.SetAutoScrollEnabled(autoScrollCheckBox.Checked);

            if (autoScrollCheckBox.Checked) {
                packetDataGridView1.ScrollToBottom();
            }
        }
    }
}
