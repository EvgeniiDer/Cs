using System.Data;
using Microsoft.Extensions.Logging;
using DataAccess;
using Microsoft.Extensions.Primitives;
using System.Timers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;


namespace DataSetCache
{
    public interface IDataCache : IDisposable // интерфейс IDisposable нжен для освобождения ресурсов которые не управляються сборщиком муссора иначе будет позже Предупреждения задолбают
    {
        DataSet GetData();
        void Start(); // явно управлять таймером
        void Stop();  // явно управлять таймером
    }

    public class DataCache : IDataCache
    {
        private DataSet _dataSet;
        private readonly System.Timers.Timer _timer;
        private readonly IDataBase _dataBase;
        //private readonly ILogger<DataCache> _logger;//Logging: Добавлен ILogger<DataCache> для логирования событий. Это необязательно, но настоятельно рекомендуется для отладки и мониторинга.
        private bool _idDisposed = false;

        public DataCache(IConfiguration configuration, double refreshIntervalMinutes = 5/*, ILogger<DataCache> logger = null*/)
        {
            AllocConsole();
            _dataBase = new DataBase(configuration);
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dataSet = new DataSet();

            initializeDataSet();

            _timer = new System.Timers.Timer(refreshIntervalMinutes * 60 * 1000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;

        }
        public DataSet GetData()
        {
            return _dataSet;
        }
        public SqlConnection GetConnection()
        {
            return _dataBase.GetConnection();
        }
        public void Start()
        {
            _timer.Enabled = true;
            Console.WriteLine("Cache timer starte");
           // _logger?.LogInformation("Cache timer started.");
        }
        public void Stop()
        {
            _timer.Stop();
            Console.WriteLine("Cache timer stopped");
            //_logger?.LogInformation("Cache timer stopped");
        }
        private void OnTimerElapsed(Object sender, ElapsedEventArgs e)
        {
            //_logger?.LogInformation("Timer elapsed, refreshing data....");
            Console.WriteLine("Timer elapsed, elapsed, refreshing data.....");
            LoadData();
        }
        private void LoadData()
        {
            try
            {

                // Обновление таблицы Directions
                _dataSet.Tables[0].Clear();
                FillTable(_dataSet.Tables[0], "SELECT * FROM Directions", _dataBase.GetConnection());

                // Обновление таблицы Groups
                _dataSet.Tables[1].Clear();
                FillTable(_dataSet.Tables[2], "SELECT * FROM Groups", _dataBase.GetConnection());

                // Обновление таблицы Students
                _dataSet.Tables[2].Clear();
                FillTable(_dataSet.Tables[2], "SELECT stud_id, last_name, first_name, middle_name, birth_date, [group] " +
                    "FROM Students AS St INNER JOIN Groups AS Gr ON Gr.group_id = St.[group]", _dataBase.GetConnection());





                //_logger?.LogInformation("Data loaded successfully");
                Console.WriteLine("Data loaded successfully");
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error loading data");
                Console.WriteLine("Error loading data" + ex);
            }
        }
        public DataTable GetTable(int index)
        {
            return _dataSet.Tables[index];
        }
        public void FillTable(DataTable table, string query, SqlConnection connection)
        {
            try
            {
                table.Clear();
                using(SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, $"Error filling table {table.TableName}");
                Console.WriteLine("Error filling table " + table.TableName);
            }
        }
        public void initializeDataSet()
        {
            _dataSet.Tables.Clear();//очищаем коллекцию(аналог контейнера с++) от таблиц которые там могу быть
            _dataSet.Relations.Clear();//очищаем связи менжду таблицами если они есть
            AddTable("Directions", "direction_name", out var directionsTable);
            FillTable(directionsTable, "SELECT* FROM Directions", _dataBase.GetConnection());

            AddTable("Groups", "group_name", out var groupsTable);
            string GroupsDirection = "SELECT* FROM Groups";
            FillTable(groupsTable, GroupsDirection, _dataBase.GetConnection());

            string studentsTableQueryb = "SELECT stud_id,last_name,first_name,middle_name,birth_date,[group] FROM Students as St INNER JOIN Groups AS Gr ON Gr.group_id = St.[group]";
            AddTable("Students", "stud_id,last_name,first_name,middle_name,birth_date", out var studentsTable);
            FillTable(studentsTable, studentsTableQueryb, _dataBase.GetConnection());
            //AddRelation("GroupsDirections", groupsTable, "direction", directionsTable, "direction_id");

        }

        private void AddTable(string tableName, string columns, out DataTable dataTable)// out Говорит о том что этот класс не надо создавать и передавать как аргуемент он будет создан внутри метода
        {
            //TypeKeyType
            dataTable = new DataTable();// что метод будет инициализировать этот параметр, и он должен быть передан в метод без предварительной инициализации.
            string[] columnsName = columns.Split(',');
            foreach(string columnName in columnsName)
            {
                dataTable.Columns.Add(columnName.Trim());
            }
            dataTable.PrimaryKey = new DataColumn[] {dataTable.Columns[0]};
            _dataSet.Tables.Add(dataTable);
        }
        private void AddRelation(string relationName, DataTable childTable, string childColumn, DataTable parentTable, string parentColumn)
        {
            DataRelation relation = new DataRelation
                (
                    relationName,
                    parentTable.Columns[parentColumn],
                    childTable.Columns[childColumn]
                );
        }
        public void Dispose()
        {
            if(!_idDisposed)
            {
                _timer.Stop();
                _timer.Dispose();
                _idDisposed = true;

                //_logger?.LogInformation("DataCache disposed");
                Console.WriteLine("DataCahe disposed");
            }
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }

}
