using System;
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
	private IConnector _connector;
    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();
    [DllImport("kernel32.dll")]
    public static extern bool FreeConsole();

}
