namespace ADO.NET_WinForm_BD
{
    partial class DataBaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Split = new System.Windows.Forms.SplitContainer();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Split
            // 
            this.Split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split.Location = new System.Drawing.Point(0, 0);
            this.Split.Name = "Split";
            this.Split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Split.Panel1
            // 
            this.Split.Panel1.Controls.Add(this.statusLabel);
            this.Split.Panel1.Controls.Add(this.executeButton);
            this.Split.Panel1.Controls.Add(this.queryTextBox);
            // 
            // Split.Panel2
            // 
            this.Split.Panel2.Controls.Add(this.resultDataGridView);
            this.Split.Size = new System.Drawing.Size(921, 495);
            this.Split.SplitterDistance = 308;
            this.Split.TabIndex = 0;
            // 
            // queryTextBox
            // 
            this.queryTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(173)))), ((int)(((byte)(134)))));
            this.queryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.queryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryTextBox.Location = new System.Drawing.Point(0, 0);
            this.queryTextBox.Multiline = true;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.queryTextBox.Size = new System.Drawing.Size(921, 308);
            this.queryTextBox.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // executeButton
            // 
            this.executeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(173)))), ((int)(((byte)(134)))));
            this.executeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executeButton.ForeColor = System.Drawing.Color.Black;
            this.executeButton.Location = new System.Drawing.Point(780, 265);
            this.executeButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(114, 29);
            this.executeButton.TabIndex = 1;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(173)))), ((int)(((byte)(134)))));
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(0, 292);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 16);
            this.statusLabel.TabIndex = 2;
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.AllowUserToAddRows = false;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGridView.Location = new System.Drawing.Point(0, 0);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.ReadOnly = true;
            this.resultDataGridView.Size = new System.Drawing.Size(921, 183);
            this.resultDataGridView.TabIndex = 0;
            this.resultDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(921, 495);
            this.Controls.Add(this.Split);
            this.Name = "DataBaseForm";
            this.Text = "DataBaseForm";
            this.Load += new System.EventHandler(this.DataBaseForm_Load);
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel1.PerformLayout();
            this.Split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Split;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridView resultDataGridView;
    }
}