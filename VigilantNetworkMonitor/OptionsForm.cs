﻿
namespace VigilantNetworkMonitor {
    public partial class OptionsForm : Form {

        private readonly INetworkOptions _networkOptions;
        private readonly IColumnOptions _columnOptions;

        public OptionsForm(INetworkOptions networkOptions, IColumnOptions columnOptions) {
            _networkOptions = networkOptions;
            _columnOptions = columnOptions;
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e) {
            networkInterfacesDataGridView.Load(_networkOptions);
            foreach (DataGridViewColumn column in _columnOptions.GetColumns()) {
                bool enabled = _columnOptions.IsColumnEnabled(column.Name);
                columnsCheckedListBox.Items.Add(column.Name, enabled);
            }
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

        private void columnsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            string columnName = (string)columnsCheckedListBox.Items[e.Index];            
            if (e.CurrentValue == CheckState.Checked) {
                _columnOptions.DisableColumn(columnName);
            }
            else {
                _columnOptions.EnableColumn(columnName);
            }
        }
    }
}
