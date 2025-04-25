
using Microsoft.Extensions.Configuration;
using System.Configuration;
//using System.Configuration;

namespace ADO.NET_WinForm_BD_2._2
{

    public partial class MainWindow : Form
    {
 
        public MainWindow()
        {
            InitializeComponent();

            DataBase db = new DataBase(new Connector(Program.Configuration));
            dgvStudents.DataSource = db.Select("*","Students");
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void tabPageStudents_Click(object sender, EventArgs e)
        {

        }
    }
}
