using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Configuration;

namespace ADO_NET_DataSet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();



        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}
