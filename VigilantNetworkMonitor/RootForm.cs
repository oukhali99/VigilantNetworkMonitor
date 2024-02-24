
using Microsoft.Extensions.DependencyInjection;

namespace VigilantNetworkMonitor {
    public partial class RootForm : Form {

        private readonly INetworkOptions _networkOptions;
        private readonly IServiceProvider _serviceProvider;

        public RootForm(INetworkOptions networkOptions, IServiceProvider serviceProvider) {
            _networkOptions = networkOptions;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e) {
            packetDataGridView1.Load(_networkOptions);
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
    }
}
