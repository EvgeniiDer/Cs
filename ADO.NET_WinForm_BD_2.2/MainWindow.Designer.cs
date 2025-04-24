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
            statusStrip = new StatusStrip();
            tabControl = new TabControl();
            tabPageStudents = new TabPage();
            tabPageGroups = new TabPage();
            tabPageDirections = new TabPage();
            tabPageDisciplines = new TabPage();
            tabPageTeachers = new TabPage();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Location = new Point(0, 490);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(872, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
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
            // 
            // tabPageStudents
            // 
            tabPageStudents.Location = new Point(4, 24);
            tabPageStudents.Name = "tabPageStudents";
            tabPageStudents.Padding = new Padding(3);
            tabPageStudents.Size = new Size(864, 462);
            tabPageStudents.TabIndex = 0;
            tabPageStudents.Text = "Studenyts";
            tabPageStudents.UseVisualStyleBackColor = true;
            // 
            // tabPageGroups
            // 
            tabPageGroups.Location = new Point(4, 24);
            tabPageGroups.Name = "tabPageGroups";
            tabPageGroups.Padding = new Padding(3);
            tabPageGroups.Size = new Size(864, 462);
            tabPageGroups.TabIndex = 1;
            tabPageGroups.Text = "Groups";
            tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // tabPageDirections
            // 
            tabPageDirections.Location = new Point(4, 24);
            tabPageDirections.Name = "tabPageDirections";
            tabPageDirections.Padding = new Padding(3);
            tabPageDirections.Size = new Size(864, 462);
            tabPageDirections.TabIndex = 2;
            tabPageDirections.Text = "Directions";
            tabPageDirections.UseVisualStyleBackColor = true;
            // 
            // tabPageDisciplines
            // 
            tabPageDisciplines.Location = new Point(4, 24);
            tabPageDisciplines.Name = "tabPageDisciplines";
            tabPageDisciplines.Padding = new Padding(3);
            tabPageDisciplines.Size = new Size(864, 462);
            tabPageDisciplines.TabIndex = 3;
            tabPageDisciplines.Text = "Disciplines";
            tabPageDisciplines.UseVisualStyleBackColor = true;
            // 
            // tabPageTeachers
            // 
            tabPageTeachers.Location = new Point(4, 24);
            tabPageTeachers.Name = "tabPageTeachers";
            tabPageTeachers.Padding = new Padding(3);
            tabPageTeachers.Size = new Size(864, 462);
            tabPageTeachers.TabIndex = 4;
            tabPageTeachers.Text = "Teachers";
            tabPageTeachers.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 512);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            Name = "MainWindow";
            Text = "Academy";
            Load += MainWindow_Load;
            tabControl.ResumeLayout(false);
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
    }
}
