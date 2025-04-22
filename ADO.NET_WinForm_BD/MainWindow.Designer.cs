using System.Drawing;

namespace ADO.NET_WinForm_BD
{
    
    partial class MainWindow
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
            this.enterDataBaseNameLabel = new System.Windows.Forms.Label();
            this.enterDbName = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.closeButtonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enterDataBaseNameLabel
            // 
            this.enterDataBaseNameLabel.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterDataBaseNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.enterDataBaseNameLabel.Location = new System.Drawing.Point(7, 13);
            this.enterDataBaseNameLabel.Name = "enterDataBaseNameLabel";
            this.enterDataBaseNameLabel.Size = new System.Drawing.Size(325, 29);
            this.enterDataBaseNameLabel.TabIndex = 1;
            this.enterDataBaseNameLabel.Text = "Please   Enter   Data   Base    Name";
            // 
            // enterDbName
            // 
            this.enterDbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(173)))), ((int)(((byte)(134)))));
            this.enterDbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterDbName.Location = new System.Drawing.Point(12, 58);
            this.enterDbName.Name = "enterDbName";
            this.enterDbName.Size = new System.Drawing.Size(320, 35);
            this.enterDbName.TabIndex = 2;
            this.enterDbName.Enter += new System.EventHandler(this.enterDbName_Enter);
            this.enterDbName.Leave += new System.EventHandler(this.enterDbName_Leave);
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(173)))), ((int)(((byte)(134)))));
            this.connectButton.Location = new System.Drawing.Point(12, 99);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(320, 43);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            this.connectButton.MouseLeave += new System.EventHandler(this.connectButton_MouseLeave);
            this.connectButton.MouseHover += new System.EventHandler(this.connectButton_MouseHover);
            // 
            // closeButtonLabel
            // 
            this.closeButtonLabel.AutoSize = true;
            this.closeButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButtonLabel.ForeColor = System.Drawing.Color.White;
            this.closeButtonLabel.Location = new System.Drawing.Point(320, -2);
            this.closeButtonLabel.Name = "closeButtonLabel";
            this.closeButtonLabel.Size = new System.Drawing.Size(24, 24);
            this.closeButtonLabel.TabIndex = 3;
            this.closeButtonLabel.Text = "X";
            this.closeButtonLabel.Click += new System.EventHandler(this.closeButtonLabel_Click);
            this.closeButtonLabel.MouseLeave += new System.EventHandler(this.closeButtonLabel_MouseLeave);
            this.closeButtonLabel.MouseHover += new System.EventHandler(this.closeButtonLabel_MouseHover);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(344, 153);
            this.Controls.Add(this.closeButtonLabel);
            this.Controls.Add(this.enterDbName);
            this.Controls.Add(this.enterDataBaseNameLabel);
            this.Controls.Add(this.connectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterDataBaseNameLabel;
        private System.Windows.Forms.TextBox enterDbName;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label closeButtonLabel;
    }
}