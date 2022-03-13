using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KPOLaba2
{
    public partial class MainForm : Form
    {
        private string cs =
            @"Data Source=HPVICTUS16\SQLEXPRESS; Initial Catalog=University; Integrated Security=true";

        public Dictionary<int, string> Faculties
        {
            get { return _faculties; }
        }
        private Dictionary<int, string> _faculties = new Dictionary<int, string>();
        private List<int> facultyIDs = new List<int>();

        public Dictionary<int, string> Groups
        {
            get { return _groups; }
        }
        private Dictionary<int, string> _groups = new Dictionary<int, string>();
        private List<int> groupIDs = new List<int>();

        public Dictionary<int, string> Students
        {
            get { return _students; }
        }
        private Dictionary<int, string> _students = new Dictionary<int, string>();
        private List<int> studentIDs = new List<int>();

        public Dictionary<int, string> Specializations
        {
            get { return _specializations; }
        }
        private Dictionary<int, string> _specializations;

        public MainForm()
        {
            InitializeComponent();
            _specializations = new Dictionary<int, string>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    @"Select * from Specializations", connection);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _specializations.Add((int)dr["ID"], dr["Name"].ToString());
                }
            }
        }
        
        private void Specializations_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTree();
        }

        public void LoadTree()
        {
            LoadFaculties();
            int i = 0;
            int j = 0;
            foreach (TreeNode treeNode in treeView1.Nodes)
            {
                LoadGroups(facultyIDs[i], treeNode);
                i++;
                foreach (TreeNode treeNodeNode in treeNode.Nodes)
                {
                    LoadStudents(groupIDs[j], treeNodeNode);
                    j++;
                }
            }
        }

        private void LoadFaculties()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    @"Select * from Faculties", connection);
                var dr = cmd.ExecuteReader();
                treeView1.Nodes.Clear();
                _faculties = new Dictionary<int, string>();
                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    int id = (int) dr["ID"];
                    TreeNode tn = new TreeNode(name);
                    treeView1.Nodes.Add(tn);
                    _faculties.Add(id, name);
                    facultyIDs.Add(id);
                }
            }
        }

        private void LoadGroups(int facultyID, TreeNode parentTreeNode)
        { 
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    @"Select g.Name, g.[Specialization ID], g.ID from Groups as g 
                      where g.[Faculty ID] = @facultyID", connection);
                cmd.Parameters.AddWithValue("@facultyID", facultyID);
                var dr = cmd.ExecuteReader();
                parentTreeNode.Nodes.Clear();
                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    int id = (int)dr["ID"];
                    TreeNode tn = new TreeNode(name + ", " + Specializations[(int)dr["Specialization ID"]]);
                    parentTreeNode.Nodes.Add(tn);
                    _groups.Add(id, name);
                    groupIDs.Add(id);
                }
            }
        }

        private void LoadStudents(int groupID, TreeNode parentTreeNode)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    @"Select s.Name, s.Surname, s.[Middle name], s.ID from Students as s
                      where s.[Group ID] = @groupID", connection);
                cmd.Parameters.AddWithValue("@groupID", groupID);
                var dr = cmd.ExecuteReader();
                parentTreeNode.Nodes.Clear();
                while (dr.Read())
                {
                    object middleName = dr["Middle name"];
                    string name;
                    if (middleName != null)
                        name = dr["Name"].ToString() + " " +  dr["Surname"].ToString() + " " + middleName;
                    else
                        name = dr["Name"].ToString() + " " + dr["Surname"].ToString();
                    int id = (int)dr["ID"];
                    TreeNode tn = new TreeNode(name);
                    parentTreeNode.Nodes.Add(tn);
                    _students.Add(id, name);
                    studentIDs.Add(id);
                }
            }
        }
    }
}
