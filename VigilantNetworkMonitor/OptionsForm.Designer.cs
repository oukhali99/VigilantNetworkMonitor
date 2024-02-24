namespace VigilantNetworkMonitor {
    partial class OptionsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            networkInterfacesDataGridView = new NetworkInterfacesDataGridView();
            nam = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            networkInterfaces = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)networkInterfacesDataGridView).BeginInit();
            tabControl1.SuspendLayout();
            networkInterfaces.SuspendLayout();
            SuspendLayout();
            // 
            // networkInterfacesDataGridView
            // 
            networkInterfacesDataGridView.AllowUserToAddRows = false;
            networkInterfacesDataGridView.AllowUserToDeleteRows = false;
            networkInterfacesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            networkInterfacesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            networkInterfacesDataGridView.Columns.AddRange(new DataGridViewColumn[] { nam, description });
            networkInterfacesDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            networkInterfacesDataGridView.Location = new Point(6, 6);
            networkInterfacesDataGridView.Name = "networkInterfacesDataGridView";
            networkInterfacesDataGridView.ReadOnly = true;
            networkInterfacesDataGridView.Size = new Size(756, 224);
            networkInterfacesDataGridView.TabIndex = 2;
            networkInterfacesDataGridView.CellEnter += networkInterfacesDataGridView_CellEnter;
            // 
            // nam
            // 
            nam.HeaderText = "Name";
            nam.Name = "nam";
            nam.ReadOnly = true;
            // 
            // description
            // 
            description.HeaderText = "Description";
            description.Name = "description";
            description.ReadOnly = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(networkInterfaces);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 264);
            tabControl1.TabIndex = 3;
            // 
            // networkInterfaces
            // 
            networkInterfaces.Controls.Add(networkInterfacesDataGridView);
            networkInterfaces.Location = new Point(4, 24);
            networkInterfaces.Name = "networkInterfaces";
            networkInterfaces.Padding = new Padding(3);
            networkInterfaces.Size = new Size(768, 236);
            networkInterfaces.TabIndex = 0;
            networkInterfaces.Text = "Network Interfaces";
            networkInterfaces.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 236);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 288);
            Controls.Add(tabControl1);
            Name = "OptionsForm";
            Text = "OptionsForm";
            Load += OptionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)networkInterfacesDataGridView).EndInit();
            tabControl1.ResumeLayout(false);
            networkInterfaces.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NetworkInterfacesDataGridView networkInterfacesDataGridView;
        private DataGridViewTextBoxColumn nam;
        private DataGridViewTextBoxColumn description;
        private TabControl tabControl1;
        private TabPage networkInterfaces;
        private TabPage tabPage2;
    }
}