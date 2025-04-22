using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET_WinForm_BD
{
    public partial class MainWindow : Form
    {
        private Color originalTexBoxEnterDbNameColor;
        private bool isDragging;
        private Point dragStartPosition;

        public MainWindow()
        {

            InitializeComponent();
            originalTexBoxEnterDbNameColor = this.enterDbName.BackColor;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string enterDbName = this.enterDbName.Text;
            if (string.IsNullOrEmpty(enterDbName))
            {
                MessageBox.Show("Please Enter the name of Database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataBaseForm dataBaseForm = new DataBaseForm();
            dataBaseForm.Show();
            this.Hide();
            
        }

        private void closeButtonLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButtonLabel_MouseHover(object sender, EventArgs e)
        {
            this.closeButtonLabel.ForeColor = System.Drawing.Color.Red;
        }

        private void closeButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            this.closeButtonLabel.ForeColor = System.Drawing.Color.White;
        }

        private void connectButton_MouseHover(object sender, EventArgs e)
        {
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(8, 55, 16);
        }

        private void connectButton_MouseLeave(object sender, EventArgs e)
        {
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(126, 173, 134);
        }

        private void enterDbName_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.FromArgb(201, 224, 205);
        }

        private void enterDbName_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = originalTexBoxEnterDbNameColor;
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle) 
            {
                isDragging = true;
                dragStartPosition = new Point(e.X, e.Y);  
            }
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging)
            {
                Point currentScreenPosition = Control.MousePosition;
                Point newWindowLocation = new Point(currentScreenPosition.X - dragStartPosition.X,
                                                    currentScreenPosition.Y - dragStartPosition.Y);
                this.Location = newWindowLocation;
            }
        }

        private void MainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                isDragging = false;              
            }
        }
    }
}
