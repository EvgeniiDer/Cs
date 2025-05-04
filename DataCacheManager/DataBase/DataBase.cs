using DataBaseConnector;
using DataSetCache;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
namespace DataAccess
{
    public class DataBase
    {
        private readonly IConnector _connector;
        public DataBase(IConfiguration configuration)
        {
            _connector = new Connector(configuration);
                try
                {
                    using(SqlConnection connection = _connector.GetConnection())
                        {
                            connection.Open();
                        }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Sql Exception occurred: " + ex.Message);
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Try to open connection that is already open");
                }
            
        }
    }
}
