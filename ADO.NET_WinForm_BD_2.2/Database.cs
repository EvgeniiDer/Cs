using System;
using System.Data;
using System.Runtime.InteropServices;
using ADO.NET_WinForm_BD_2._2;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DataBase
{
   
    public DataBase(IConnector connector)
	{
		if(connector == null)
		{
			throw new ArgumentNullException(nameof(connector));
		}
		else
			_connector = connector;
			
    }
	public DataTable Select(string columns, string tables, string condition = "", string group_by = "")
	{
		DataTable dataTable = null;
		string cmd = $"SELECT {columns} FROM {tables}";
		if (!string.IsNullOrWhiteSpace(condition))
			cmd += $" WHERE {condition}";
		if (!string.IsNullOrWhiteSpace(group_by))
			cmd += $" GROUP BY {group_by}";
        _connection = _connector.GetConnection();
		_connection.Open();
		if(_connection.State == ConnectionState.Open)
		{
			Console.WriteLine("Connection is successfully");
			Console.WriteLine($"cmd is: {cmd}");
		}
		else
		{
			Console.WriteLine("Connection is not successfully");
		}
		
        SqlCommand command = new SqlCommand(cmd, _connection);
		Console.WriteLine($"- CommandText: {command.CommandText}");		
		SqlDataReader reader = command.ExecuteReader();
		try
		{ 
			dataTable = new DataTable();
			for(int i = 0; i < reader.FieldCount; i++)
			{
				dataTable.Columns.Add(reader.GetName(i));
			}
			while(reader.Read())
			{
				DataRow row = dataTable.NewRow();
				for(int i = 0; i < reader.FieldCount; i++)
				{
					row[i] = reader[i];
				}
				dataTable.Rows.Add(row);
			}
			reader.Close();
			_connection.Close();
			return dataTable;
		}
		catch(SqlException sqlExp)
		{
			Console.WriteLine($"Sql Error: {sqlExp.Message}");
		}
		catch(Exception ex)
		{
			Console.WriteLine($"An error occurred: {ex.Message}"); 
		}
		finally
		{
            reader.Close();
            _connection.Close();
            
        }
		return dataTable;
	}
	private SqlConnection _connection;
	private IConnector _connector;
	

    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();
    [DllImport("kernel32.dll")]
    public static extern bool FreeConsole();

}
