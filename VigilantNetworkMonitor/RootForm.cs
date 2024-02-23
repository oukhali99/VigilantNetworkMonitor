using System.Windows.Forms;

namespace VigilantNetworkMonitor {
    public partial class RootForm : Form {

        public RootForm() {
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e) {
            networkInterfacesDataGridView.Load();
            packetDataGridView1.Load(networkInterfacesDataGridView);
        }

        private void networkInterfacesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            networkInterfacesDataGridView.OnClickedRow(e.RowIndex);
        }

        private void sniffButton_Click(object sender, EventArgs e) {
            if (packetDataGridView1.IsSniffing()) {
                networkInterfacesDataGridView.Enabled = true;
                packetDataGridView1.StopSniffing();
                sniffButton.Text = "Sniff";
            }
            else {
                networkInterfacesDataGridView.Enabled = false;
                packetDataGridView1.StartSniffing();
                sniffButton.Text = "Stop";
            }
        }
    }
}
