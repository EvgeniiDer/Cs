using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace WPFSqlCleint
{
    internal class DataBase
    {
        private readonly IConnector connector;
        private readonly Action<bool> _connectionStatusCallBack;
        private List<string> _tables;
        


        public DataBase(Action<bool> connectionStatusCallBack)
        {
            connector = new Connector(ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString);
            _connectionStatusCallBack = connectionStatusCallBack;
            if (connector.isConnectionValid())
            {
                _connectionStatusCallBack(true);
            }
            else
            {
                _connectionStatusCallBack(false);
            }  
        }
        public string GetDatabaseName()
        {
            try
            {
                return new SqlConnectionStringBuilder(connector.GetConnectionString).InitialCatalog.ToString();
            }
            catch
            {
                return "Unknown DataBase";
            }
        }
        public SqlConnection GetConnection()
        {
            return connector.GetConnection;
        }
        public List<string>GetTables()
        {
            _tables = new List<string>();
            using (SqlConnection connection = connector.GetConnection)
            {
                connection.Open();
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _tables.Add(reader.GetString(0));
                    }
                }
            }
            return _tables;;
        }
    }
}
