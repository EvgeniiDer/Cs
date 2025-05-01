using System;
using AcademyDataSet;
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
        if (string.IsNullOrWhiteSpace(_connectionString))
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
