using System;
using ADO.NET_WinForm_BD_2._2;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
public interface IConnector
{
	string ConnectionString { get; }
	SqlConnection GetConnection();
}
public class Connector : IConnector
{
	private readonly string _connectionString;

	public Connector(IConfiguration configuration)
	{
		_connectionString = Program.Configuration?.GetConnectionString("VPD_311_Import");
		if(string.IsNullOrWhiteSpace(_connectionString))
		{
			throw new InvalidOperationException("There is no 'VPD_311_Import");
		}
		AllocConsole();
		Console.WriteLine(_connectionString);
	}
	public string ConnectionString
	{
		get { return _connectionString; }
	}
	public SqlConnection GetConnection()
	{
		return new SqlConnection(_connectionString);
	}
	[DllImport("kernel32.dll")]
	public static extern bool AllocConsole();
	[DllImport("kernel32.dll")]
	public static extern bool FreeConsole();

}
