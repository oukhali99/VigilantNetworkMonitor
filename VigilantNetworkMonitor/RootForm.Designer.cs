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
            statusStrip1 = new StatusStrip();
            toolStripErrorLabel = new ToolStripStatusLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)packetDataGridView1).BeginInit();
            menuStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // packetDataGridView1
            // 
            packetDataGridView1.AllowUserToAddRows = false;
            packetDataGridView1.AllowUserToDeleteRows = false;
            packetDataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            packetDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            packetDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            packetDataGridView1.Columns.AddRange(new DataGridViewColumn[] { sourceIp, sourcePort, destinationIP, destinationPort, protocol });
            packetDataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            packetDataGridView1.Location = new Point(12, 62);
            packetDataGridView1.Name = "packetDataGridView1";
            packetDataGridView1.ReadOnly = true;
            packetDataGridView1.Size = new Size(778, 357);
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
            sniffButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sniffButton.Location = new Point(664, 3);
            sniffButton.Name = "sniffButton";
            sniffButton.Size = new Size(69, 23);
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
            menuStrip.Size = new Size(802, 24);
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
            filterTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            filterTextBox.Location = new Point(3, 3);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(582, 23);
            filterTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 5;
            label1.Text = "Filter";
            // 
            // applyFilterButton
            // 
            applyFilterButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            applyFilterButton.Location = new Point(591, 3);
            applyFilterButton.Name = "applyFilterButton";
            applyFilterButton.Size = new Size(67, 23);
            applyFilterButton.TabIndex = 6;
            applyFilterButton.Text = "Apply";
            applyFilterButton.UseVisualStyleBackColor = true;
            applyFilterButton.Click += applyFilterButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripErrorLabel });
            statusStrip1.Location = new Point(0, 409);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(802, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripErrorLabel
            // 
            toolStripErrorLabel.ForeColor = Color.Red;
            toolStripErrorLabel.Name = "toolStripErrorLabel";
            toolStripErrorLabel.Size = new Size(0, 17);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(applyFilterButton, 1, 0);
            tableLayoutPanel1.Controls.Add(filterTextBox, 0, 0);
            tableLayoutPanel1.Controls.Add(sniffButton, 2, 0);
            tableLayoutPanel1.Location = new Point(54, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(736, 29);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // RootForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 431);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            Controls.Add(packetDataGridView1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "RootForm";
            Text = "Vigilant";
            Load += RootForm_Load;
            ((System.ComponentModel.ISupportInitialize)packetDataGridView1).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripErrorLabel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
