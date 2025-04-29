using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Collections;

namespace Academy
{
    public partial class MainForm : Form
    {
        private Connector connector;
        private Query[] queries = new Query[]
        {
                new Query("*", "Students JOIN Groups ON([group]=group_id) JOIN Directions ON (direction=direction_id)"),
                new Query
                (
                    "group_id,group_name,COUNT(stud_id) AS students_count,direction_name",
                    "Students,Groups,Directions",
                    "direction=direction_id AND [group]=group_id",
                    "group_id,group_name,direction_name"
            ),
                new Query
                (
                    @"direction_name,
					COUNT(DISTINCT group_id)    AS  N'Количество групп',
					COUNT(DISTINCT stud_id)     AS  N'Количество студентов'",

                    @"Students
					JOIN			Groups		ON	([group]	=	group_id)
					RIGHT	JOIN	Directions	ON	(direction	=	direction_id)",	//tables
					"",	//WHERE
					"direction_name"
            ),
                new Query("*", "Disciplines"),
                new Query("*", "Teachers"),
            };
        private DataGridView[] tables;
        private string[] status_messages = new string[]
            {
                "Количество студентов: ",
                "Количество групп: ",
                "Количество направлений: ",
                "Количество дисциплин: ",
                "Количество преподавателей: ",
            };

        private Dictionary<string, int> _directions;
        private Dictionary<string, int> _groups;

        public IReadOnlyDictionary<string, int> Directions => _directions;
        public IReadOnlyDictionary<string, int> Groups => _groups;

        public MainForm()
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

            connector = new Connector(ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString);
            dgvStudents.DataSource = connector.Select("*", "Students");
            statusStripCountLabel.Text = $"Количество студентов: {dgvStudents.RowCount - 1}";

            _directions = connector.GetDictionary("Directions");
            _groups = connector.GetDictionary("Groups");
            cbStudentsGroup.Items.AddRange(_groups.Select(g => g.Key.ToString()).ToArray());
            cbStudentsDirection.Items.AddRange(_directions.Keys.ToArray());
            cbGroupsDirection.Items.AddRange(_directions.Keys.ToArray());
        }

        void LoadTab(Query query = null)
        {
            int i = tabControl.SelectedIndex;
            if (query == null) query = queries[i];
            tables[i].DataSource = connector.Select(query.Columns, query.Tables, query.Condition, query.GroupBy);
            statusStripCountLabel.Text = $"{status_messages[i]} {tables[i].RowCount - 1}";
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;
            Query query = new Query(queries[i]);
            string tab_name = (sender as ComboBox).Name;
            string field_name = tab_name.Substring(Array.FindLastIndex<char>(tab_name.ToCharArray(), Char.IsUpper));

            Dictionary<string, int> source = null;
            if (field_name.ToLower() == "direction")
            {
                source = _directions;
            }
            else if (field_name.ToLower() == "group")
            {
                source = _groups;
            }

            if (source != null)
            {
                if (query.Condition != "") query.Condition += " AND";
                query.Condition += $" [{field_name.ToLower()}] = {source[(sender as ComboBox).SelectedItem.ToString()]}";

                // Handle filtering of dependent combo boxes
                if (field_name == "Direction")
                {
                    UpdateDependentComboBoxes((sender as ComboBox).SelectedItem.ToString());
                }

                LoadTab(query);
            }
        }

        private void UpdateDependentComboBoxes(string selectedDirection)
        {
            // Check if the current tab contains the group combo box
            if (tabControl.SelectedTab.Controls.Contains(cbStudentsGroup))
            {
                // Filter groups based on the selected direction
                var filteredGroups = _groups.Where(g =>
                {
                    // Find the direction associated with the group
                    string sql = $"SELECT direction FROM Groups WHERE group_id = {g.Value}";
                    object groupDirectionId = connector.ExecuteScalar(sql);

                    if (groupDirectionId != null && groupDirectionId != DBNull.Value)
                    {
                        if (_directions.FirstOrDefault(d => d.Value == Convert.ToInt32(groupDirectionId)).Key == selectedDirection)
                            return true;
                    }

                    return false;
                }).ToDictionary(g => g.Key, g => g.Value);

                // Update the group combo box
                cbStudentsGroup.Items.Clear();
                cbStudentsGroup.Items.AddRange(filteredGroups.Keys.ToArray());
            }
        }
    }
}