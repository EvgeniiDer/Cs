using System;
namespace ADO.NET_WinForm_BD_2._2;
public class Query
{
	public string Columns { get; set; }
	public string Tables { get; set; }
	public string Conditions { get; set; }
	public string GroupBy {  get; set; }
	public Query(string columns, string tables, string conditions = "", string group_by = "")
	{
		Columns = columns;
		Tables = tables;
		Conditions = conditions;
		GroupBy = group_by;
	}
}
