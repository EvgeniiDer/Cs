using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
class AdoNet
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        const string connectionString = "Server=.;" +
                                        "TrustServerCertificate=True;" +
                                         "Database=Movies_VPD_311;" +
                                         "User Id= sa;" +
                                         "Password= Zimbo34513451;";
        string cmd = "SELECT* FROM Movies";
        //SqlCommand command = new SqlCommand(cmd, connection);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
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
}