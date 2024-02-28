using VigilantNetworkMonitor.Packet.Filter.Service;

namespace VigilantNetworkMonitor
{
    public partial class SavedFiltersControl : UserControl {
        private IPacketFilterService? _packetFilterService;

        public SavedFiltersControl() {
            InitializeComponent();
        }

        public void Init(IPacketFilterService packetFilterService) {
            _packetFilterService = packetFilterService;

            foreach (KeyValuePair<string, string> filterPair in packetFilterService.GetSavedFilters()) {
                string filterName = filterPair.Key;
                string filterString = filterPair.Value;
                dataGridView.Rows.Add(filterName, filterString);
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (_packetFilterService == null) {
                return;
            }

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            string? filterString = row.Cells["value"].Value.ToString();

            if (filterString == null) {
                return;
            }

            _packetFilterService.SetActiveFilter(filterString);
        }
    }
}
