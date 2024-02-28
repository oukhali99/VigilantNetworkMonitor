
using Microsoft.Extensions.DependencyInjection;
using VigilantNetworkMonitor.Model;
using VigilantNetworkMonitor.Packet.Filter.Base;
using VigilantNetworkMonitor.Packet.Filter.Factory;
using VigilantNetworkMonitor.Packet.Filter.Service;
using VigilantNetworkMonitor.Service;
using static VigilantNetworkMonitor.Packet.Filter.Service.IPacketFilterService;

namespace VigilantNetworkMonitor
{
    public partial class RootForm : Form {

        private readonly INetworkOptions _networkOptions;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPacketFilterService _packetFilterService;
        private readonly IGeneralOptions _generalOptions;
        private readonly IColumnOptions _columnOptions;
        private readonly IPacketSnifferService _packetSnifferService;
        private readonly IPacketFilterFactory _packetFilterFactory;

        public RootForm(
            INetworkOptions networkOptions,
            IServiceProvider serviceProvider,
            IPacketFilterService packetFilterService,
            IGeneralOptions generalOptions,
            IColumnOptions columnOptions,
            IPacketSnifferService packetSnifferService,
            IPacketFilterFactory packetFilterFactory
        ) {
            _networkOptions = networkOptions;
            _serviceProvider = serviceProvider;
            _packetFilterService = packetFilterService;
            _generalOptions = generalOptions;
            _columnOptions = columnOptions;
            _packetSnifferService = packetSnifferService;
            _packetFilterFactory = packetFilterFactory;
            _packetFilterService.AddChangedActiveFilterEventHandler(handleChangedFilterStringEvent);

            InitializeComponent();
        }

        private void handleChangedFilterStringEvent(object sender, ChangedActiveFilterEventArgs e) {
            filterTextBox.Text = e.FilterString;
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
            applyFilter(filterTextBox.Text);
        }

        private void applyFilter(string filterString) {
            _packetFilterService.SetActiveFilter(filterString);
            IPacketFilter? filter = _packetFilterService.GetActiveFilter();
            if (filter == null) {
                toolStripErrorLabel.Text = "Invalid Filter";
                return;
            }
            toolStripErrorLabel.Text = "";
            //filterString = filter.GetFilterString();
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

        private void saveFilterButton_Click(object sender, EventArgs e) {
            string filterString = filterTextBox.Text;
            applyFilter(filterString);

            IPacketFilter? packetFilter = _packetFilterFactory.ParseString(filterString);
            if (packetFilter == null) {
                return;
            }

            SaveFilterForm saveFilterForm = _serviceProvider.GetRequiredService<SaveFilterForm>();
            saveFilterForm.Init(filterString);
            saveFilterForm.ShowDialog();
        }
    }
}
