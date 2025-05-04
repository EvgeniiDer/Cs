using DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataCacheManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            try
            {
                DataBase db = new DataBase(Program.Configuration);
                statusLabel.Text = "Connection: True";
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException error: " + ex.Message);
            }

        }


    }
}
