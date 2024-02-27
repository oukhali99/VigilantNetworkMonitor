namespace VigilantNetworkMonitor {
    partial class SaveFilterForm {
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
            saveButton = new Button();
            cancelButton = new Button();
            filterNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            filterTextBox = new TextBox();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(160, 70);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(241, 70);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // filterNameTextBox
            // 
            filterNameTextBox.Location = new Point(57, 41);
            filterNameTextBox.Name = "filterNameTextBox";
            filterNameTextBox.Size = new Size(259, 23);
            filterNameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 15);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 4;
            label2.Text = "Filter";
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(57, 12);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(259, 23);
            filterTextBox.TabIndex = 5;
            // 
            // SaveFilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 104);
            Controls.Add(filterTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(filterNameTextBox);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Name = "SaveFilterForm";
            Text = "SaveFilterForm";
            FormClosing += SaveFilterForm_FormClosing;
            Load += SaveFilterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private Button cancelButton;
        private TextBox filterNameTextBox;
        private Label label1;
        private Label label2;
        private TextBox filterTextBox;
    }
}