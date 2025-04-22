using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 SELECT*
 FROM Directors;
 */
namespace ADO.NET_WinForm_BD
{
    public partial class DataBaseForm : Form
    {
        private readonly Connector _dbConnector;
        private readonly DataBase _dbExecuter;
        public DataBaseForm()
        {
            
            InitializeComponent();
            try
            {
                this._dbConnector = new Connector();
                this._dbExecuter = new DataBase(this._dbConnector);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Критическая ошибка при инициализации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // Важно: Возможно, здесь стоит заблокировать кнопку выполнения
                executeButton.Enabled = false;
            }
        }

        private void DataBaseForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            string sqlQuery = queryTextBox.Text;
            resultDataGridView.DataSource = null;
            resultDataGridView.Columns.Clear();
            if(statusLabel != null)
            {
                statusLabel.Text = "";
            }

            if(string.IsNullOrWhiteSpace(sqlQuery) )
            {
                statusLabel.Text = "Query cant be empty";
                return;
            }
            try
            {
                Console.WriteLine(sqlQuery);
                if(sqlQuery.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                {
                    DataTable dataTable = _dbExecuter.ExecuteSelectQuery(sqlQuery);
                    resultDataGridView.DataSource = dataTable;
                    if(statusLabel != null)
                    {
                        statusLabel.Text = $"Query SELECT Done. Get row: {dataTable.Rows.Count}";
                    }
                }else
                {
                    //Не Тестировал Пора здавать домашку
                    int affectedRows = _dbExecuter.ExecuteNonQuery(sqlQuery);
                    if (statusLabel != null) statusLabel.Text = $"Command executed successefully. Line affected: {affectedRows}";
                }
                

            }
            catch(Microsoft.Data.SqlClient.SqlException sqlEx)
            {
                statusLabel.Text = $"Error SQL: {sqlEx.Message}";            
            }
            catch(Exception ex)
            {
                statusLabel.Text = $"Common Error: {ex.Message}";
            }
        }
    }
}
