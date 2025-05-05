
    using Microsoft.Extensions.Configuration;
    using DataBaseConnector;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Logging;
    using System.Data;
// КЛАСС ОТВЕЧАЕТ ЗА ЗАПРОСЫ К ОБРАЩЕНИЮ К БАЗЕ ДАННЫХ
namespace DataAccess
    {
       public interface IDataBase
        {
            DataTable ExecuteQuery(string query);
            SqlConnection GetConnection();
        }
       public class DataBase : IDataBase
        {
            private IConnector _connector;
            //private readonly ILogger<DataBase> _logger;
            public DataBase(IConfiguration configuration/*, ILogger<DataBase> logger = null*/)
            {
                //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
                //_logger?.LogInformation("DataBase class constructor started....");
                _connector = new Connector(configuration);
                using (SqlConnection connection = new SqlConnection(_connector.ConnectionString))
                {
                    try
                    {
                       connection.Open();
                    }
                    catch(SqlException sqlex)
                    {
                    //_logger?.LogError(sqlex, "Error connection");
                    Console.WriteLine("Error connections: " + sqlex);
                    }
                }
            }
            public SqlConnection GetConnection()
            {
                return new SqlConnection(_connector.ConnectionString);
            }

            public DataTable ExecuteQuery(string query)
            {
                DataTable dataTable = new DataTable();
                try
            {
                using (SqlConnection connection = new SqlConnection(_connector.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }

            }
            catch (SqlException sqlex)
            {
                /*_logger?.LogError(sqlex, "Error executing query: {Query}", query);
                throw;*/
                Console.WriteLine("Error executing query: " + sqlex);
            }
            catch (Exception ex)
            {
                /*_logger?.LogError(ex, "Unexpected error executing query: {Query}", query);
                throw;*/
                Console.WriteLine("Unexpected error executing query: " + ex);
            }
                return dataTable;
            }
        }
    }
