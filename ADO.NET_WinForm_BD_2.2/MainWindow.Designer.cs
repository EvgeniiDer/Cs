namespace ADO.NET_WinForm_BD_2._2
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            statusStrip = new StatusStrip();
            statusStripCountLabel = new ToolStripStatusLabel();
            tabControl = new TabControl();
            tabPageStudents = new TabPage();
            dgvStudents = new DataGridView();
            tabPageGroups = new TabPage();
            cbGroups = new ComboBox();
            dgvGroups = new DataGridView();
            tabPageDirections = new TabPage();
            dgvDirections = new DataGridView();
            tabPageDisciplines = new TabPage();
            dgvDisciplines = new DataGridView();
            tabPageTeachers = new TabPage();
            dgvTeachers = new DataGridView();
            statusStrip.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            tabPageGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGroups).BeginInit();
            tabPageDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDirections).BeginInit();
            tabPageDisciplines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDisciplines).BeginInit();
            tabPageTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusStripCountLabel });
            statusStrip.Location = new Point(0, 490);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(872, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // statusStripCountLabel
            // 
            statusStripCountLabel.Name = "statusStripCountLabel";
            statusStripCountLabel.Size = new Size(123, 17);
            statusStripCountLabel.Text = "statusStripCountLabel";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageStudents);
            tabControl.Controls.Add(tabPageGroups);
            tabControl.Controls.Add(tabPageDirections);
            tabControl.Controls.Add(tabPageDisciplines);
            tabControl.Controls.Add(tabPageTeachers);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(872, 490);
            tabControl.TabIndex = 1;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabPageStudents
            // 
            tabPageStudents.Controls.Add(dgvStudents);
            tabPageStudents.Location = new Point(4, 24);
            tabPageStudents.Name = "tabPageStudents";
            tabPageStudents.Padding = new Padding(3);
            tabPageStudents.Size = new Size(864, 462);
            tabPageStudents.TabIndex = 0;
            tabPageStudents.Text = "Studenyts";
            tabPageStudents.UseVisualStyleBackColor = true;
            tabPageStudents.Click += tabPageStudents_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(3, 67);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(858, 392);
            dgvStudents.TabIndex = 0;
            // 
            // tabPageGroups
            // 
            tabPageGroups.Controls.Add(cbGroups);
            tabPageGroups.Controls.Add(dgvGroups);
            tabPageGroups.Location = new Point(4, 24);
            tabPageGroups.Name = "tabPageGroups";
            tabPageGroups.Padding = new Padding(3);
            tabPageGroups.Size = new Size(864, 462);
            tabPageGroups.TabIndex = 1;
            tabPageGroups.Text = "Groups";
            tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // cbGroups
            // 
            cbGroups.FormattingEnabled = true;
            cbGroups.Location = new Point(6, 0);
            cbGroups.Name = "cbGroups";
            cbGroups.Size = new Size(121, 23);
            cbGroups.TabIndex = 1;
            cbGroups.SelectionChangeCommitted += cbGroups_SelectionChangeCommitted;
            // 
            // dgvGroups
            // 
            dgvGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroups.Location = new Point(3, 67);
            dgvGroups.Name = "dgvGroups";
            dgvGroups.Size = new Size(858, 392);
            dgvGroups.TabIndex = 0;
            // 
            // tabPageDirections
            // 
            tabPageDirections.Controls.Add(dgvDirections);
            tabPageDirections.Location = new Point(4, 24);
            tabPageDirections.Name = "tabPageDirections";
            tabPageDirections.Padding = new Padding(3);
            tabPageDirections.Size = new Size(864, 462);
            tabPageDirections.TabIndex = 2;
            tabPageDirections.Text = "Directions";
            tabPageDirections.UseVisualStyleBackColor = true;
            // 
            // dgvDirections
            // 
            dgvDirections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDirections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDirections.Location = new Point(3, 67);
            dgvDirections.Name = "dgvDirections";
            dgvDirections.Size = new Size(858, 392);
            dgvDirections.TabIndex = 0;
            // 
            // tabPageDisciplines
            // 
            tabPageDisciplines.Controls.Add(dgvDisciplines);
            tabPageDisciplines.Location = new Point(4, 24);
            tabPageDisciplines.Name = "tabPageDisciplines";
            tabPageDisciplines.Padding = new Padding(3);
            tabPageDisciplines.Size = new Size(864, 462);
            tabPageDisciplines.TabIndex = 3;
            tabPageDisciplines.Text = "Disciplines";
            tabPageDisciplines.UseVisualStyleBackColor = true;
            // 
            // dgvDisciplines
            // 
            dgvDisciplines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDisciplines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDisciplines.Location = new Point(3, 67);
            dgvDisciplines.Name = "dgvDisciplines";
            dgvDisciplines.Size = new Size(858, 392);
            dgvDisciplines.TabIndex = 0;
            // 
            // tabPageTeachers
            // 
            tabPageTeachers.Controls.Add(dgvTeachers);
            tabPageTeachers.Location = new Point(4, 24);
            tabPageTeachers.Name = "tabPageTeachers";
            tabPageTeachers.Padding = new Padding(3);
            tabPageTeachers.Size = new Size(864, 462);
            tabPageTeachers.TabIndex = 4;
            tabPageTeachers.Text = "Teachers";
            tabPageTeachers.UseVisualStyleBackColor = true;
            // 
            // dgvTeachers
            // 
            dgvTeachers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeachers.Location = new Point(3, 67);
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.Size = new Size(858, 392);
            dgvTeachers.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 512);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            Text = "Academy";
            Load += MainWindow_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            tabPageGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGroups).EndInit();
            tabPageDirections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDirections).EndInit();
            tabPageDisciplines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDisciplines).EndInit();
            tabPageTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Connector connector;
        private StatusStrip statusStrip;
        private TabControl tabControl;
        private TabPage tabPageStudents;
        private TabPage tabPageGroups;
        private TabPage tabPageDirections;
        private TabPage tabPageDisciplines;
        private TabPage tabPageTeachers;
        private DataGridView dgvStudents;
        private DataGridView dgvGroups;
        private DataGridView dgvDirections;
        private DataGridView dgvDisciplines;
        private DataGridView dgvTeachers;
        private ToolStripStatusLabel statusStripCountLabel;
        private ComboBox cbGroups;
    }
}
