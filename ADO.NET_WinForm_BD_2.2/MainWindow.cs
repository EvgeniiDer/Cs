
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
//using System.Configuration;

namespace ADO.NET_WinForm_BD_2._2
{

    public partial class MainWindow : Form
    {
        Query[] queries = new Query[]
        {
            new Query("*", "Students"),
            new Query(
                "group_id, group_name, COUNT(stud_id), direction_name",
                "Students, Groups, Directions",
                "direction = direction_id AND [group] = group_id",
                "direction_name, group_name, group_id"),
            new Query(
                "DIR.direction_name, COUNT(DISTINCT GR.group_id) AS N'Колличество Групп', COUNT(DISTINCT ST.stud_id) AS N'Колличество Студентов'",
                "\"DisciplinesDirectionsRelation\" AS DDR\r\n    LEFT OUTER JOIN \"Directions\" AS DIR ON DDR.direction = DIR.direction_id\r\n    LEFT OUTER JOIN \"Groups\" AS GR ON GR.direction = DIR.direction_id\r\n    LEFT OUTER JOIN \"Students\" AS ST ON ST.\"group\" = GR.group_id",
                "",
                "DIR.direction_name"),

            new Query("*", "Disciplines"),
            new Query("*", "Teachers"),
        };
        DataGridView[] tables;
        string[] status_message = new string[]
        {
            "Total Students: ",
            "Total Group: ",
            "Total Directions: ",
            "Total Disciplines: ",
            "Total Teachers: ",
        };
        DataBase db;

        public MainWindow()
        {
            InitializeComponent();

            tables = new DataGridView[]
            {
                dgvStudents,
                dgvGroups,
                dgvDirections,
                dgvDisciplines,
                dgvTeachers
            };

            db = new DataBase(new Connector(Program.Configuration));
            dgvStudents.DataSource = db.Select("*", "Students");
            dgvGroups.DataSource = db.Select("*", "Groups");
            dgvDirections.DataSource = db.Select("*", "Directions");
            dgvDisciplines.DataSource = db.Select("*", "Disciplines");
            dgvTeachers.DataSource = db.Select("*", "Teachers");
            statusStripCountLabel.Text = $"Total Students: {dgvStudents.Rows.Count - 1}";
        }
        private void LoadDisciplinesIntoComboBox()
        {
            ComboBox targetComboBox = cbGroups;
            if (targetComboBox == null)
            {
                MessageBox.Show("Error: cbGroups for disciplines not found");
            }
            List<string> disciplinesName = new List<string>();
            string columnsToSelect = "direction_name";
            string tableName = "Directions";
            DataTable result = db.Select(columnsToSelect, tableName);
            if (result is DataTable dt && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    disciplinesName.Add(row[columnsToSelect].ToString());
                }
            }
            for (int i = 0; i < disciplinesName.Count; i++)
            {
                cbGroups.Items.Add(disciplinesName[i]);
            }
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadDisciplinesIntoComboBox();
        }

        private void tabPageStudents_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;
            tables[i].DataSource = db.Select(queries[i].Columns, queries[i].Tables, queries[i].Conditions, queries[i].GroupBy);
            statusStripCountLabel.Text = $"{status_message[i]} {tables[i].RowCount - 1}";
        }

        private void cbGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbGroups.SelectedIndex == null)
            {
                try
                {
                    dgvGroups.DataSource = db.Select("*", "Groups");
                    UpdateGroupStatusLabel();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error DataBas: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvGroups.DataSource = null; // Очищаем при ошибке
                    statusStripCountLabel.Text = "Total Group: Loading Error";
                    
                }
            }
            string selectedDirectionName = cbGroups.SelectedItem.ToString();
            string columns = "G.group_id, G.group_name";
            string tables = "Groups AS G INNER JOIN Directions AS D ON G.direction = D.direction_id";
            string escapedDirectionName = selectedDirectionName.Replace("'", "''");
            string conditions = $"D.direction_name = '{escapedDirectionName}'";
            DataTable filteredGroups = db.Select(columns, tables, conditions);
            dgvGroups.DataSource = filteredGroups;
            UpdateGroupStatusLabel();
        }
        private void UpdateGroupStatusLabel()
        {
            if(dgvGroups.DataSource != null)
            {
                int rowCount = dgvGroups.AllowUserToAddRows ? dgvGroups.RowCount - 1 : dgvGroups.RowCount;
                statusStripCountLabel.Text = $"Total Group: {rowCount}";
            }
            else
            {
                statusStripCountLabel.Text = "Total Group: 0";
            }
        }
    }
}
