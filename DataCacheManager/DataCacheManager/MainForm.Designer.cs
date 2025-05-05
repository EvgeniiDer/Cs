namespace DataCacheManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusLabel = new Label();
            dgvStudents = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            cbDirection = new ComboBox();
            cbGroups = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.BackColor = Color.LightYellow;
            statusLabel.Location = new Point(700, 9);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(100, 15);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "Connection: Faild";
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Bottom;
            dgvStudents.Location = new Point(0, 75);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(800, 375);
            dgvStudents.TabIndex = 1;
            dgvStudents.CellContentClick += dataGridView1_CellContentClick;
            // 
            // cbDirection
            // 
            cbDirection.FormattingEnabled = true;
            cbDirection.Location = new Point(12, 31);
            cbDirection.Name = "cbDirection";
            cbDirection.Size = new Size(310, 23);
            cbDirection.TabIndex = 2;
            cbDirection.SelectionChangeCommitted += cbDirection_SelectionChangeCommitted;
            // 
            // cbGroups
            // 
            cbGroups.FormattingEnabled = true;
            cbGroups.Location = new Point(443, 31);
            cbGroups.Name = "cbGroups";
            cbGroups.Size = new Size(327, 23);
            cbGroups.TabIndex = 3;
            cbGroups.SelectionChangeCommitted += cbGroups_SelectionChangeCommitted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbGroups);
            Controls.Add(cbDirection);
            Controls.Add(dgvStudents);
            Controls.Add(statusLabel);
            Name = "MainForm";
            Text = "Academy";
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusLabel;
        private DataGridView dgvStudents;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox cbDirection;
        private ComboBox cbGroups;
    }
}
