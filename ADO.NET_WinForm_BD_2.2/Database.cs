using System;
using ADO.NET_WinForm_BD_2._2;
using Microsoft.Data.SqlClient;
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
	

}
