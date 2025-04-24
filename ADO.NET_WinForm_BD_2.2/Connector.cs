using System;
using ADO.NET_WinForm_BD_2._2;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
