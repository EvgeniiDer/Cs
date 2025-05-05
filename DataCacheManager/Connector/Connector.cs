using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
namespace DataBaseConnector
    // КЛАСС ОТВЕЧАЕТ ЗА ПОДКЛЮЧЕНИЕ К БАЗЕ ДЕННАХЫ
{
    public interface IConnector
    {
        public string ConnectionString { get; }
    }
    public class Connector : IConnector
    {
        private string _connectionString;
        //private readonly ILogger<Connector> _logger;
        public Connector(IConfiguration configuration/*, ILogger<Connector>logger = null*/)
        {
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                //_logger?.LogError(ex, "Error loading connection string");
                Console.WriteLine("Error loading connection string" + ex);
            }
            
        }
        public string ConnectionString
        {
            get { return _connectionString; }
        }

    }

}
