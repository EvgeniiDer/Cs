
using DataSetCache;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Drawing.Text;
using DataAccess;

namespace DataCacheManager
{
    public partial class MainForm : Form
    {
        private DataCache _dc;
        public MainForm()
        {

            InitializeComponent();
            try
            {
                _dc = new DataCache(Program.Configuration);
                statusLabel.Text = "Connection: True";
                dgvStudents.DataSource = _dc.GetTable(2);
                LoadtDiectionComboBox();
                LoadGroupComboBox();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException error: " + ex.Message);
            }

        }
        private void LoadGroupComboBox(string directionName = null)
        {
            ComboBox targetComboBox = cbGroups;
            if (targetComboBox == null)
            {
                MessageBox.Show("Error: cbDirectionStudents for Students not found");
            }
            string condition = null;
            if (!string.IsNullOrWhiteSpace(directionName) && directionName != "All directions")
            {
                condition = $"SELECT group_name FROM Directions, Groups INNER JOIN Directions As Dir ON Dir.direction_id = direction WHERE Dir.direction_id = '{directionName}'GROUP BY group_name, Dir.direction_name";
                _dc.FillTable(_dc.GetTable(1), condition, _dc.GetConnection());
            }
            List<string> groupsName = new List<string>();
            string columnsToSelect = "group_name";
            DataTable result = _dc.GetData().Tables[1];
            foreach (DataRow row in result.Rows)
            {
                groupsName.Add(row[columnsToSelect].ToString());

            }
            foreach (string name in groupsName)
            {
                Console.WriteLine(name);
            }
            targetComboBox.Items.Clear();
            targetComboBox.Items.Add("All groups");
            targetComboBox.Items.AddRange(groupsName.ToArray());
            targetComboBox.SelectedIndex = 0;
            targetComboBox.Enabled = targetComboBox.Items.Count > 0;
        }
        private void LoadtDiectionComboBox()
        {
            ComboBox targetComboBox = cbDirection;
            if (targetComboBox == null)
            {
                MessageBox.Show("Error: cbDirectionStudents for Students not found");
            }
            List<string> directionsName = new List<string>();
            string columnsToSelect = "direction_name";
            DataTable result = _dc.GetData().Tables[0];
            if (result is DataTable dt && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    directionsName.Add(row[columnsToSelect].ToString());
                }
            }
            targetComboBox.Items.Clear();
            targetComboBox.Items.Add("All directions");
            targetComboBox.Items.AddRange(directionsName.ToArray());
            targetComboBox.SelectedIndex = 0;
            targetComboBox.Enabled = targetComboBox.Items.Count > 0;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbDirection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectionDirection = cbDirection.SelectedIndex.ToString();
            Console.WriteLine(selectionDirection);
            LoadGroupComboBox(selectionDirection);
            string condition = null;
            if (selectionDirection != "All directions")
            {
                //condition = $"SELECT stud_id,last_name,first_name,middle_name,birth_date,[group] FROM Students as St INNER JOIN Groups AS Gr ON Gr.group_id = St.[group]INNER JOIN Directions As Dir ON Dir.direction_id = Gr.direction WHERE direction_id = '{selectionDirection}'";
                condition = $@"
                            SELECT 
                                stud_id,
                                last_name,
                                first_name,
                                middle_name,
                                birth_date,
                                [group] 
                            FROM 
                                Students AS St 
                            INNER JOIN 
                                Groups AS Gr ON Gr.group_id = St.[group]
                            INNER JOIN 
                                Directions AS Dir ON Dir.direction_id = Gr.direction 
                            WHERE 
                                direction_id = '{selectionDirection}';
                        ";
            }
            _dc.FillTable(_dc.GetTable(2), condition, _dc.GetConnection());
            dgvStudents.DataSource = _dc.GetTable(2);
        }

        private void cbGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectionGroup = cbGroups.SelectedIndex.ToString();
            string condition = null;
            if(selectionGroup != "All groups")
            {
                condition = $@"
                            SELECT 
                                stud_id,
                                last_name,
                                first_name,
                                middle_name,
                                birth_date,
                                [group] 
                            FROM 
                                Students AS St 
                            INNER JOIN 
                                Groups AS Gr ON Gr.group_id = St.[group]
                            WHERE 
                                Gr.group_id = '{selectionGroup}';
                        ";

            }
            _dc.FillTable(_dc.GetTable(2), condition, _dc.GetConnection());
            dgvStudents.DataSource = _dc.GetTable(2);
        }
    }
}
