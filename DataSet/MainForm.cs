using System.Runtime.InteropServices;
using Microsoft.Data;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
namespace AcademyDataSet
{
    public partial class MainForm : Form
    {
        DataSet dSet;
        DataBase db;
        Connector _connections;
        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
            _connections = new Connector(Program.Configuration);
            db = new DataBase(_connections);
            if(db.GetConnected())
            {
                statusLabel.Text = "Connected";
                //1)Создаем DataSet:
                dSet = new DataSet();
                //LoadGroupsRelatedData();
                AddTable("Directions", "direction_id, direction_name");
                AddTable("Groups", "group_id,group_name,direction");
                AddRelation("GroupsDirections", "Groups,direction", "Directions,direction_id");
                //PrintGroup();
                Print("Groups");
            }
            else
            {
                statusLabel.Text = "Disconnected";
            }

        }
        private void AddTableWithDataTable(string table, string columns)
        {
            DataTable dataTable = new DataTable(table);
            string[] ArrayColumns = columns.Split(',');
            foreach (string column in ArrayColumns)
            {
                dataTable.Columns.Add(column);
            }
            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = dataTable.Columns[0];
            dataTable.PrimaryKey = primaryKey;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT* FROM {table}", _connections.ConnectionString);
            sqlDataAdapter.Fill(dataTable);
            dSet.Tables.Add(dataTable);
        }
        public void AddTable(string table, string columns)
        {
            //2.1) Добавляем таблицу в DataSet:
            dSet.Tables.Add(table);
            //2.2) Добавляем поля в DataSet:
            string[] a_columns = columns.Split(',');
            for(int i =0; i < a_columns.Length; i++)
            {
                dSet.Tables[table].Columns.Add(a_columns[i]);
            }
            //2.3) Определяем какое поле будет первичным ключем:
            dSet.Tables[table].PrimaryKey =
                new DataColumn[] { dSet.Tables[table].Columns[0] };

            string cmd = $"SELECT {columns} FROM {table}";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, _connections.ConnectionString);
            adapter.Fill(dSet.Tables[table]);
            
        }
        public void AddRelation(string relation_name, string child, string parent)
        {
            dSet.Relations.Add
                (
                    relation_name,
                    dSet.Tables[parent.Split(',')[0]].Columns[parent.Split(',')[1]],
                    dSet.Tables[child.Split(',')[0]].Columns[child.Split(',')[1]]
                );
        }
        void LoadGroupsRelatedData()
        {
            
            //2)Добавляем таблицы в DataSet
            const string dsTable_Directions = "Directions";
            const string dst_col_direction_id = "direction_id";
            const string dst_col_directions_name = "direction_name";
            //2.1) Добавляем таблицу в DataSet:
            dSet.Tables.Add(dsTable_Directions);
            //2.2) Добавляем поля в DataSet:
            dSet.Tables[dsTable_Directions].Columns.Add(dst_col_direction_id, typeof(byte));
            dSet.Tables[dsTable_Directions].Columns.Add(dst_col_directions_name, typeof(string));
            //2.3) Определяем какое поле будет первичным ключем:
            dSet.Tables[dsTable_Directions].PrimaryKey =
                new DataColumn[] { dSet.Tables[dsTable_Directions].Columns[dst_col_direction_id] };

            const string dsTable_Groups = "Groups";
            const string dst_Groups_col_group_id = "group_id";
            const string dst_Groups_col_group_name = "group_name";
            const string dst_Groups_col_group_direction = "direction";
            dSet.Tables.Add(dsTable_Groups);
            dSet.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_id, typeof(int));
            dSet.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_name, typeof(string));
            dSet.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_direction, typeof(byte));
            dSet.Tables[dsTable_Groups].PrimaryKey =
                new DataColumn[] { dSet.Tables[dsTable_Groups].Columns[0] };

            //3) Строим связи между таблицами
            dSet.Relations.Add
                (
                    "GroupsDirections",
                    dSet.Tables[dsTable_Directions].Columns[dst_col_direction_id],//Parent field  первичнй ключ дургой таблицы
                    dSet.Tables[dsTable_Groups].Columns[dst_Groups_col_group_direction] //Child field - внешний ключ
                );
            //4 Загрузка данных в DataSet
            string directionsCmd =  "SELECT * FROM Directions";
            string groupsCmd = "SELECT * FROM Groups";

            SqlDataAdapter directionsAdapter = new SqlDataAdapter(directionsCmd, _connections.ConnectionString);
            SqlDataAdapter groupsAdapter = new SqlDataAdapter(groupsCmd, _connections.ConnectionString);

            directionsAdapter.Fill(dSet.Tables[dsTable_Directions]);
            groupsAdapter.Fill(dSet.Tables[dsTable_Groups]);


            Print("Directions");
            Print("Groups");

            

        }
        private void Print(string table)
        {
            Console.WriteLine(table);
            Console.WriteLine("\n===========================================================\n");
            Console.WriteLine("dSet.Tables.Count: " + dSet.Tables.Count);
            Console.WriteLine("dSet.Tables[table].ParentRelation.Count: " + dSet.Tables[table].ParentRelations.Count);
            Console.WriteLine();
            for(int i = 0; i <  dSet.Tables.Count; i++)
            {
                Console.Write(dSet.Tables[table].Columns[i].Caption + "\t");
                
            }
            if (dSet.Tables[table].ParentRelations.Count > 0)
            {
                DataRelation relation = dSet.Tables[table].ParentRelations[0];
                Console.Write(relation.ParentTable.TableName + "." + relation.ParentColumns[0].ColumnName + "\t");
            }
            Console.WriteLine("\n===========================================================\n");
            for(int i = 0; i < dSet.Tables[table].Rows.Count; i++)
            {
                for(int j = 0; j < dSet.Tables[table].Columns.Count - 1; j++)
                {
                    Console.Write(dSet.Tables[table].Rows[i][j] + "\t");
                }

                if (dSet.Tables[table].ParentRelations.Count > 0)
                {
                    DataRelation relation = dSet.Tables[table].ParentRelations[0];
                    DataRow parentRow = dSet.Tables[table].Rows[i].GetParentRow(relation);
                    if(parentRow != null)
                    {
                        //Console.WriteLine(dSet.Tables[table].Rows[i].GetParentRow("GroupsDirections")["direction_name"] + "\t");
                        for (int k = 0; k < relation.ParentTable.Columns.Count; k++)
                        {
                            Console.Write(parentRow[relation.ParentTable.Columns[k].ColumnName] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine();
                }
                
            }
            /*Console.WriteLine(table);
            Console.WriteLine("\n===========================================================\n");
            for(int i = 0; i < dSet.Tables[table].Columns.Count;i++)
            {
                Console.Write(dSet.Tables[table].Columns[i].Caption + "\t"); 
            }
            Console.WriteLine("\n-----------------------------------------------------------\n");
            for (int i = 0; i < dSet.Tables[table].Rows.Count; i++)
            {
                //Console.Write(GroupsRelatedData.Tables[table].Rows[i] + ":\t");
                for (int j = 0; j < dSet.Tables[table].Columns.Count; j++)
                {
                    Console.Write(dSet.Tables[table].Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }*/

        }
        void PrintGroup()
        {
            Console.WriteLine("\n===========================================================\n");
            string table = "Groups";
            for(int i = 0; i < dSet.Tables[table].Rows.Count; i++)
            {
                for(int j = 0; j < dSet.Tables[table].Columns.Count; j++)
                {
                    Console.Write(dSet.Tables[table].Rows[i][j] + "\t");
                    
                }
                Console.WriteLine(dSet.Tables[table].Rows[i].GetParentRow("GroupsDirections")["direction_name"]);
                Console.WriteLine();
            }
            Console.WriteLine("\n===========================================================\n");
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}
