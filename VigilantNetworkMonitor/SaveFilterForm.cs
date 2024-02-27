using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.Service;

namespace VigilantNetworkMonitor {
    public partial class SaveFilterForm : Form {
        private readonly IPacketFilterService _packetFilterService;

        private string? _filterString;

        public SaveFilterForm(IPacketFilterService packetFilterService) {
            InitializeComponent();
            _packetFilterService = packetFilterService;
        }

        public void Init(string? filterString) {
            _filterString = filterString;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void SaveFilterForm_FormClosing(object sender, FormClosingEventArgs e) {
            //Dispose();
        }

        private void SaveFilterForm_Load(object sender, EventArgs e) {
            if (_filterString == null) {
                Close();
            }
            filterTextBox.Text = _filterString;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            string name = filterNameTextBox.Text;
            string filterString = filterTextBox.Text;

            if (name.Length == 0 || filterString.Length == 0) {
                return;
            }

            _packetFilterService.SaveFilter(name, filterString);
            Close();
        }
    }
}
