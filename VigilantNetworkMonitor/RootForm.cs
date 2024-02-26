
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
        private readonly IPacketSnifferService _packetSnifferService;

        public RootForm(
            INetworkOptions networkOptions,
            IServiceProvider serviceProvider,
            IPacketFilterService packetFilterService,
            IGeneralOptions generalOptions,
            IColumnOptions columnOptions,
            IPacketSnifferService packetSnifferService
        ) {
            _networkOptions = networkOptions;
            _serviceProvider = serviceProvider;
            _packetFilterService = packetFilterService;
            _generalOptions = generalOptions;
            _columnOptions = columnOptions;
            _packetSnifferService = packetSnifferService;
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e) {
            Point savedWindowLocation = Properties.Settings.Default.WindowLocation;
            Size savedWindowSize = Properties.Settings.Default.WindowSize;

            if (
                savedWindowLocation.X > Location.X &&
                savedWindowLocation.Y > Location.Y
            ) {
                Location = savedWindowLocation;
            }
            if (
                savedWindowSize.Width > Size.Width &&
                savedWindowSize.Height > Size.Height
            ) {
                Size = savedWindowSize;
            }

            packetDataGridView1.Load(_packetFilterService, _generalOptions, _columnOptions, _packetSnifferService);
            autoScrollCheckBox.Checked = _generalOptions.IsAutoScrollEnabled();
        }

        private void sniffButton_Click(object sender, EventArgs e) {
            MyCaptureDeviceWrapper? selectedCaptureDeviceWrapper = _networkOptions.GetSelectedCaptureDeviceWrapper();
            if (selectedCaptureDeviceWrapper == null) {
                _serviceProvider.GetRequiredService<OptionsForm>().ShowDialog();
                return;
            }

            if (_packetSnifferService.IsSniffing()) {
                _packetSnifferService.StopSniffing();
            }
            else {
                _packetSnifferService.StartSniffing();
            }

            sniffButton.Text = _packetSnifferService.IsSniffing() ? "Stop" : "Sniff";
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

        private void RootForm_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.WindowLocation = Location;
            Properties.Settings.Default.WindowSize = Size;
            Properties.Settings.Default.Save();
        }
    }
}
