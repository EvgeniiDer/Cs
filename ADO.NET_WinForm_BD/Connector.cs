using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace ADO.NET_WinForm_BD
{
    internal class Connector
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        public void OpenConnection()
        {
             _connection = GetConnection(); ;
            try
            {
                Console.WriteLine($"Connection to {GetInitialCatalog(_connectionString)} database..");
                _connection.Open();
                Console.WriteLine($"Connection to {GetInitialCatalog(_connectionString)} was successfully");
            }catch(Exception ex)
            {
                Console.WriteLine($"Connection to {GetInitialCatalog(_connectionString)} Failed");
                Console.WriteLine(ex.Message);
                
            }

        }
        private string GetInitialCatalog(string connectionString)
        {
            string[] parts = connectionString.Split(';');
            
            foreach(string part in parts)
            {
                if(part.Trim().StartsWith("Initial Catalog=", StringComparison.OrdinalIgnoreCase))
                {
                    return part.Substring(part.IndexOf('=') + 1).Trim();
                }
            }
            return null;
        }
   
        public void CloseConnection()
        {
            _connection.Close();
        }
        public Connector()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                             "Initial Catalog=Movies_VPD_311;" +
                             "Integrated Security=True;" +
                             "Connect Timeout=30;Encrypt=False;" +
                             "Trust Server Certificate=False;" +
                             "Application Intent=ReadWrite;" +
                             "Multi Subnet Failover=False;";
        }
        public Connector(string tableName)
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                             $"Initial Catalog={tableName};" +
                             "Integrated Security=True;" +
                             "Connect Timeout=30;Encrypt=False;" +
                             "Trust Server Certificate=False;" +
                             "Application Intent=ReadWrite;" +
                             "Multi Subnet Failover=False;";
            

        }
        public string GetDataBaseName()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(_connectionString);
                return builder.InitialCatalog;
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Warning: Could not parse datase name from connection string.");
                return null;
            }
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        
    }
}
