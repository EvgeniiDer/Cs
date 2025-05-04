
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace DataBaseConnector
{
    public interface IConnector
    {
        public string ConnectionString { get; }
        public SqlConnection GetConnection();
    }
    public class Connector : IConnector
    {
        private string _connectionString;
        public Connector(IConfiguration configuration)
        {
            try
            {
                _connectionString = configuration.GetConnectionString("VPD_311_Import");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException Error: " + ex.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Main Error: " + ex.ToString);
            }
            
        }
        public string ConnectionString
        {
            get { return _connectionString; }
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
