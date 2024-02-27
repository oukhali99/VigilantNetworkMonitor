


namespace VigilantNetworkMonitor {
    partial class SavedFiltersControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dataGridView = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            value = new DataGridViewTextBoxColumn();
            Select = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { name, value, Select });
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(869, 437);
            dataGridView.TabIndex = 2;
            dataGridView.CellDoubleClick += this.dataGridView_CellDoubleClick;
            // 
            // name
            // 
            name.FillWeight = 20F;
            name.HeaderText = "Name";
            name.Name = "name";
            // 
            // value
            // 
            value.FillWeight = 60F;
            value.HeaderText = "Value";
            value.Name = "value";
            // 
            // Select
            // 
            Select.FillWeight = 20F;
            Select.HeaderText = "Select";
            Select.Name = "Select";
            // 
            // SavedFiltersControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Name = "SavedFiltersControl";
            Size = new Size(869, 437);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn value;
        private DataGridViewButtonColumn Select;
    }
}
