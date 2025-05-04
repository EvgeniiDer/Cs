using System.Data;
using Microsoft.Extensions.Logging;
using DataBaseConnector;
using Microsoft.Extensions.Primitives;
using System.Timers;
using Microsoft.Data.SqlClient;


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
        private readonly IConnector _connector;
        private readonly ILogger<DataCache> _logger;//Logging: Добавлен ILogger<DataCache> для логирования событий. Это необязательно, но настоятельно рекомендуется для отладки и мониторинга.
        private readonly string _directionQuery = "SELECT * FROM Directions";
        private readonly string _groupsQuery = "SELECT * FROM Groups";
        private bool _idDisposed = false;

        public DataCache(IConnector connector, double refreshIntervalMinutes = 5, ILogger<DataCache> logger = null)
        {
            _connector = connector ?? throw new ArgumentNullException(nameof(connector));// проверка если аргумент connecter будет Null вылезет исключение !!!
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

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
        public void Start()
        {
            _timer.Enabled = true;
            _logger?.LogInformation("Cache timer started.");
        }
        public void Stop()
        {
            _timer.Stop();
            _logger?.LogInformation("Cache timer stopped");
        }
        private void OnTimerElapsed(Object sender, ElapsedEventArgs e)
        {
            _logger?.LogInformation("Timer elapsed, refreshing data....");
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                _logger?.LogInformation("Loading data from database.....");

                _dataSet.Tables["Directions"].Clear(); //// Заменить  
                _dataSet.Tables["Groups"].Clear();// Заменить
                using(SqlConnection connection = new SqlConnection(_connector.ConnectionString))
                {
                    connection.Open();

                    FillTable(_dataSet.Tables["Directions"], _directionQuery, connection);//Заменить !!
                    FillTable(_dataSet.Tables["Groups"], _groupsQuery, connection);//Заменит 
                }
                _logger?.LogInformation("Data loaded successfully");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error loading data");
            }
        }
        private void FillTable(DataTable table, string query, SqlConnection connection)
        {
            try
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"Error filling table {table.TableName}");
            }
        }
        private void initializeDataSet()
        {
            _dataSet.Tables.Clear();//очищаем коллекцию(аналог контейнера с++) от таблиц которые там могу быть
            _dataSet.Relations.Clear();//очищаем связи менжду таблицами если они есть
            AddTable("Directions", "direction_id,direction_name", out var directionsTable);
            AddTable("Groups", "group_id, group_name,direction", out var groupsTable);
            //откдуа теперь переменные которые выше мы вставляли в метод AddTable можно использовать дальше 
            AddRelation("GroupsDirections", groupsTable, "direction", directionsTable, "direction_id");

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

                _logger?.LogInformation("DataCache disposed");
            }
        }
    }
}
