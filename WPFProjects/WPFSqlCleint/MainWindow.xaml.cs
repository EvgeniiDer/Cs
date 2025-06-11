using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSqlCleint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DataTable _table;
        private readonly DataBase _data;
        private bool _isFirstFocusSqlQueryTextBox = true;
        public MainWindow()
        {
            InitializeComponent();
            _data = new DataBase(UpdateConnectionStatus);
            foreach(var item in _data.GetTables())
            {
                TablesTreeView.Items.Add(item);
            }
           
            
        }
        private void UpdateConnectionStatus(bool isConnected)
        {
            if(isConnected)
            {
                SqlQueryTextBox.Text = $"Connection Successfully...... Enter Query!!";
            }
            else
            {
                SqlQueryTextBox.Text = "Connection Field";
            }
        }

        private void SqlQueryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(_isFirstFocusSqlQueryTextBox)
            {
                SqlQueryTextBox.Text = "";
                _isFirstFocusSqlQueryTextBox = false;
            }
        }
        private void LoadDataTable()
        {
            string selectedItem = TablesTreeView.SelectedItem.ToString();
            string sqlQuery = $"SELECT* FROM {selectedItem}";
            _table = new DataTable();
            using (SqlConnection connection = _data.GetConnection())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
                {
                    adapter.Fill(_table);
                }
            }
            ResultDataGrid.ItemsSource = _table.DefaultView;
        }
        private void ShowTableMenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
        }

        private void TablesTreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadDataTable();
        }

        private void SqlQueryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)//Надо Удерживать Контр
            {
                string sqlQuery = SqlQueryTextBox.Text;
                _table = new DataTable();
                try
                {

                    using (SqlConnection connection = _data.GetConnection())
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
                        {
                            adapter.Fill(_table);
                        }
                    }
                    ResultDataGrid.ItemsSource = _table.DefaultView;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("An error occurred while executing the SQL query: " + sqlEx.Message, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
    
}
