using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigilantNetworkMonitor {
    public partial class OptionsForm : Form {
        public OptionsForm() {
            InitializeComponent();
            networkInterfacesDataGridView.Load();
        }

        private void OptionsForm_Load(object sender, EventArgs e) {
        }

        internal NetworkInterfacesDataGridView GetNetworkInterfacesDataGridView() {
            return networkInterfacesDataGridView;
        }
    }
}
