using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
namespace WPFSqlCleint
{
    public interface IConnector
    {
        string GetConnectionString { get;  }
        SqlConnection GetConnection { get; }
        bool isConnectionValid(); // Check Connection
    }
    internal class Connector : IConnector
    {
       
        private readonly string _connectionString;
        public Connector(string connectionString)
        {
            if(string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException("Wrong connection String: ", (nameof(connectionString)));
            _connectionString = connectionString;
        }

        public string GetConnectionString
        {
            get { return _connectionString; }
        }
        public SqlConnection GetConnection
        {
            get { return new SqlConnection(_connectionString); }
        }
        public bool isConnectionValid()
        {
            using(SqlConnection connection = this.GetConnection)
            {
                Console.WriteLine("Check connection.....");
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully");
                    return true;
                }
                catch(SqlException ex)
                {
                    Console.WriteLine("Connection failed SqlError: " + ex.ToString());
                    return false;
                }
                finally
                {
                    if(connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

    }
}
