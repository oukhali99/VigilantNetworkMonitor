
namespace VigilantNetworkMonitor {
    public partial class OptionsForm : Form {

        private readonly INetworkOptions _networkOptions;

        public OptionsForm(INetworkOptions networkOptions) {
            _networkOptions = networkOptions;
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e) {
            networkInterfacesDataGridView.Load(_networkOptions);
        }

        internal NetworkInterfacesDataGridView GetNetworkInterfacesDataGridView() {
            return networkInterfacesDataGridView;
        }

        private void networkInterfacesDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e) {
            networkInterfacesDataGridView.OnClickedRow(e.RowIndex);
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
            Dispose();
        }

    }
}
