using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDataSet
{
    internal class DataBase
    {
        public DataBase(IConnector connector)
        {
            if (connector == null)
            {
                throw new ArgumentNullException(nameof(connector));
            }
            else
                _connector = connector;           
        }
        public bool GetConnected()
        {
            //Проврка на подключение если подключено возвращает True если нет то False 
            //с Ошибкой
            try
            {
                _connection = _connector.GetConnection();
                return true;
            }
            catch (SqlException ex)
            {
                AllocConsole();
                Console.WriteLine($"Connection fail: {ex.Message.ToString()}");
                return false;
            }
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
        private SqlConnection _connection;
        private IConnector _connector;
    }
}
