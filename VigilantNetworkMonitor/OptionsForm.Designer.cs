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
            ((System.ComponentModel.ISupportInitialize)networkInterfacesDataGridView).BeginInit();
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
            networkInterfacesDataGridView.Location = new Point(12, 12);
            networkInterfacesDataGridView.Name = "networkInterfacesDataGridView";
            networkInterfacesDataGridView.Size = new Size(776, 123);
            networkInterfacesDataGridView.TabIndex = 2;
            // 
            // nam
            // 
            nam.HeaderText = "Name";
            nam.Name = "nam";
            // 
            // description
            // 
            description.HeaderText = "Description";
            description.Name = "description";
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(networkInterfacesDataGridView);
            Name = "OptionsForm";
            Text = "OptionsForm";
            Load += OptionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)networkInterfacesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NetworkInterfacesDataGridView networkInterfacesDataGridView;
        private DataGridViewTextBoxColumn nam;
        private DataGridViewTextBoxColumn description;
    }
}