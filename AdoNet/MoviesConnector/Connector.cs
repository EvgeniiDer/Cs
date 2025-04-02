
using Microsoft.Data.SqlClient;

namespace MoviesConnector;

public class Connector
{
    static readonly int PADDING = 24;
    readonly string CONNECTION_STRING = "";
    readonly SqlConnection connection;
    public Connector(string connection_string)
    {
        this.CONNECTION_STRING = connection_string;
        this.connection = new SqlConnection(CONNECTION_STRING);
        Console.WriteLine(CONNECTION_STRING);
    }
    public void Select(string cmd)
    {

        Console.WriteLine("Connect: " + cmd);
            try
            {
                connection.Open();
                Console.WriteLine("Подключение успешно!");
                SqlCommand command = new SqlCommand(cmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                
                if(reader.HasRows)
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader.GetName(i) + "\t");
                    Console.WriteLine();
                    while(reader.Read())
                    {
                       //Console.WriteLine($"{reader[0]}\t\t{reader[1]}\t\t{reader[2]}");
                       for(int i = 0; i < reader.FieldCount; i++)
                       {
                            Console.Write(reader[i] + "\t\t");
                       }
                        Console.WriteLine();


                    }
                }
                reader.Close();
                connection.Close();
                 
                // Здесь можно выполнять запросы к базе данных
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ошибка подключения: " + ex.Message);
            }
        }
        
    
}
