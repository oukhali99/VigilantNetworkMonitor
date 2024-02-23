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

        private void networkInterfacesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            optionsForm.GetNetworkInterfacesDataGridView().OnClickedRow(e.RowIndex);
        }

        private void sniffButton_Click(object sender, EventArgs e) {
            if (packetDataGridView1.IsSniffing()) {
                optionsForm.GetNetworkInterfacesDataGridView().Enabled = true;
                packetDataGridView1.StopSniffing();
            }
            else {
                optionsForm.GetNetworkInterfacesDataGridView().Enabled = false;
                packetDataGridView1.StartSniffing();
            }

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
