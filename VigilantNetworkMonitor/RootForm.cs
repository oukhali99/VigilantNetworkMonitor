using System.Windows.Forms;

namespace VigilantNetworkMonitor {
    public partial class RootForm : Form {

        private OptionsForm optionsForm;

        public RootForm() {
            InitializeComponent();
            optionsForm = new OptionsForm();
        }

        private void RootForm_Load(object sender, EventArgs e) {
            packetDataGridView1.Load(optionsForm.GetNetworkInterfacesDataGridView());
        }

        private void sniffButton_Click(object sender, EventArgs e) {
            MyCaptureDeviceWrapper? selectedCaptureDeviceWrapper =
                optionsForm.GetNetworkInterfacesDataGridView().SelectedCaptureDeviceWrapper;
            if (selectedCaptureDeviceWrapper == null) {
                optionsForm.ShowDialog();
                return;
            }

            if (packetDataGridView1.IsSniffing()) {
                packetDataGridView1.StopSniffing();
            }
            else {
                packetDataGridView1.StartSniffing();
            }

            optionsForm.GetNetworkInterfacesDataGridView().Enabled = !packetDataGridView1.IsSniffing();
            sniffButton.Text = packetDataGridView1.IsSniffing() ? "Stop" : "Sniff";
        }

        private void toolStripExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void options_Click(object sender, EventArgs e) {
            optionsForm.ShowDialog();
        }
    }
}
