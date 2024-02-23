namespace VigilantNetworkMonitor {
    partial class RootForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            packetDataGridView1 = new PacketsDataGridView();
            networkInterfacesDataGridView = new NetworkInterfacesDataGridView();
            nam = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            sniffButton = new Button();
            sourceIp = new DataGridViewTextBoxColumn();
            sourcePort = new DataGridViewTextBoxColumn();
            destinationIP = new DataGridViewTextBoxColumn();
            destinationPort = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)packetDataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)networkInterfacesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // packetDataGridView1
            // 
            packetDataGridView1.AllowUserToAddRows = false;
            packetDataGridView1.AllowUserToDeleteRows = false;
            packetDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            packetDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            packetDataGridView1.Columns.AddRange(new DataGridViewColumn[] { sourceIp, sourcePort, destinationIP, destinationPort });
            packetDataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            packetDataGridView1.Location = new Point(12, 208);
            packetDataGridView1.Name = "packetDataGridView1";
            packetDataGridView1.Size = new Size(776, 230);
            packetDataGridView1.TabIndex = 0;
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
            networkInterfacesDataGridView.Size = new Size(776, 143);
            networkInterfacesDataGridView.TabIndex = 1;
            networkInterfacesDataGridView.CellClick += networkInterfacesDataGridView_CellClick;
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
            // sniffButton
            // 
            sniffButton.Location = new Point(733, 170);
            sniffButton.Name = "sniffButton";
            sniffButton.Size = new Size(55, 23);
            sniffButton.TabIndex = 2;
            sniffButton.Text = "Sniff";
            sniffButton.UseVisualStyleBackColor = true;
            sniffButton.Click += sniffButton_Click;
            // 
            // sourceIp
            // 
            sourceIp.HeaderText = "Source IP";
            sourceIp.Name = "sourceIp";
            // 
            // sourcePort
            // 
            sourcePort.HeaderText = "Source Port";
            sourcePort.Name = "sourcePort";
            // 
            // destinationIP
            // 
            destinationIP.HeaderText = "DestinationIP";
            destinationIP.Name = "destinationIP";
            // 
            // destinationPort
            // 
            destinationPort.HeaderText = "Destination Port";
            destinationPort.Name = "destinationPort";
            // 
            // RootForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sniffButton);
            Controls.Add(networkInterfacesDataGridView);
            Controls.Add(packetDataGridView1);
            Name = "RootForm";
            Text = "Vigilant";
            Load += RootForm_Load;
            ((System.ComponentModel.ISupportInitialize)packetDataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)networkInterfacesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PacketsDataGridView packetDataGridView1;
        private NetworkInterfacesDataGridView networkInterfacesDataGridView;
        private DataGridViewTextBoxColumn nam;
        private DataGridViewTextBoxColumn description;
        private Button sniffButton;
        private DataGridViewTextBoxColumn sourceIp;
        private DataGridViewTextBoxColumn sourcePort;
        private DataGridViewTextBoxColumn destinationIP;
        private DataGridViewTextBoxColumn destinationPort;
    }
}
