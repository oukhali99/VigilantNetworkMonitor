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
            sourceIp = new DataGridViewTextBoxColumn();
            sourcePort = new DataGridViewTextBoxColumn();
            destinationIP = new DataGridViewTextBoxColumn();
            destinationPort = new DataGridViewTextBoxColumn();
            protocol = new DataGridViewTextBoxColumn();
            sniffButton = new Button();
            menuStrip = new MenuStrip();
            file = new ToolStripMenuItem();
            toolStripExit = new ToolStripMenuItem();
            tools = new ToolStripMenuItem();
            options = new ToolStripMenuItem();
            filterTextBox = new TextBox();
            label1 = new Label();
            applyFilterButton = new Button();
            ((System.ComponentModel.ISupportInitialize)packetDataGridView1).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // packetDataGridView1
            // 
            packetDataGridView1.AllowUserToAddRows = false;
            packetDataGridView1.AllowUserToDeleteRows = false;
            packetDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            packetDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            packetDataGridView1.Columns.AddRange(new DataGridViewColumn[] { sourceIp, sourcePort, destinationIP, destinationPort, protocol });
            packetDataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            packetDataGridView1.Location = new Point(12, 56);
            packetDataGridView1.Name = "packetDataGridView1";
            packetDataGridView1.ReadOnly = true;
            packetDataGridView1.Size = new Size(776, 382);
            packetDataGridView1.TabIndex = 0;
            // 
            // sourceIp
            // 
            sourceIp.HeaderText = "Source IP";
            sourceIp.Name = "sourceIp";
            sourceIp.ReadOnly = true;
            // 
            // sourcePort
            // 
            sourcePort.HeaderText = "Source Port";
            sourcePort.Name = "sourcePort";
            sourcePort.ReadOnly = true;
            // 
            // destinationIP
            // 
            destinationIP.HeaderText = "DestinationIP";
            destinationIP.Name = "destinationIP";
            destinationIP.ReadOnly = true;
            // 
            // destinationPort
            // 
            destinationPort.HeaderText = "Destination Port";
            destinationPort.Name = "destinationPort";
            destinationPort.ReadOnly = true;
            // 
            // protocol
            // 
            protocol.HeaderText = "Protocol";
            protocol.Name = "protocol";
            protocol.ReadOnly = true;
            // 
            // sniffButton
            // 
            sniffButton.Location = new Point(733, 27);
            sniffButton.Name = "sniffButton";
            sniffButton.Size = new Size(55, 23);
            sniffButton.TabIndex = 2;
            sniffButton.Text = "Sniff";
            sniffButton.UseVisualStyleBackColor = true;
            sniffButton.Click += sniffButton_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { file, tools });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip1";
            // 
            // file
            // 
            file.DropDownItems.AddRange(new ToolStripItem[] { toolStripExit });
            file.Name = "file";
            file.ShortcutKeyDisplayString = "F";
            file.Size = new Size(37, 20);
            file.Text = "File";
            // 
            // toolStripExit
            // 
            toolStripExit.Name = "toolStripExit";
            toolStripExit.ShortcutKeys = Keys.Control | Keys.E;
            toolStripExit.Size = new Size(133, 22);
            toolStripExit.Text = "Exit";
            toolStripExit.Click += toolStripExit_Click;
            // 
            // tools
            // 
            tools.DropDownItems.AddRange(new ToolStripItem[] { options });
            tools.Name = "tools";
            tools.Size = new Size(46, 20);
            tools.Text = "Tools";
            // 
            // options
            // 
            options.Name = "options";
            options.Size = new Size(116, 22);
            options.Text = "Options";
            options.Click += options_Click;
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(51, 27);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(615, 23);
            filterTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 5;
            label1.Text = "Filter";
            // 
            // applyFilterButton
            // 
            applyFilterButton.Location = new Point(672, 27);
            applyFilterButton.Name = "applyFilterButton";
            applyFilterButton.Size = new Size(55, 23);
            applyFilterButton.TabIndex = 6;
            applyFilterButton.Text = "Apply";
            applyFilterButton.UseVisualStyleBackColor = true;
            applyFilterButton.Click += applyFilterButton_Click;
            // 
            // RootForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(applyFilterButton);
            Controls.Add(label1);
            Controls.Add(filterTextBox);
            Controls.Add(sniffButton);
            Controls.Add(packetDataGridView1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "RootForm";
            Text = "Vigilant";
            Load += RootForm_Load;
            ((System.ComponentModel.ISupportInitialize)packetDataGridView1).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PacketsDataGridView packetDataGridView1;
        private Button sniffButton;
        private MenuStrip menuStrip;
        private ToolStripMenuItem file;
        private ToolStripMenuItem toolStripExit;
        private ToolStripMenuItem tools;
        private ToolStripMenuItem options;
        private TextBox filterTextBox;
        private Label label1;
        private Button applyFilterButton;
        private DataGridViewTextBoxColumn sourceIp;
        private DataGridViewTextBoxColumn sourcePort;
        private DataGridViewTextBoxColumn destinationIP;
        private DataGridViewTextBoxColumn destinationPort;
        private DataGridViewTextBoxColumn protocol;
    }
}
