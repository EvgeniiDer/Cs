using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADO.NET_WinForm_BD
{
    internal class DataBase
    {
        public DataBase(Connector connector)
        {
            _connector  = connector?? throw new ArgumentNullException(nameof(connector));
            
        }
        //Method execute SELECT
        public DataTable ExecuteSelectQuery(string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = _connector.GetConnection())
            {
                using(SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                    }catch (SqlException sqlExp)
                    {
                        Console.WriteLine($"SQL Error executing query: {sqlExp.Message}");
                        throw;
                    }catch(Exception ex)
                    {
                        Console.WriteLine($"Sql General Error executing query: {ex.Message}");
                        throw;
                    }
                }
            }
            return dataTable;
            
        }
        //Method for execute INSERT, UPDATE, DELETE, CREATE, and so on
        public int ExecuteNonQuery(string sqlQuery)
        {
            int affectedRows = 0;
            using(SqlConnection connection = _connector.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error executing non-query: {ex.Message}");
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"General Error executing non-query: {ex.Message}");
                        throw;
                    }
                }
            }
            return affectedRows;
        }
        private readonly Connector _connector;
    }
}
