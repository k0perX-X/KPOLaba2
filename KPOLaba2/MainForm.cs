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
using System.Diagnostics;

namespace KPOLaba2
{
    public partial class MainForm : Form
    {
        private enum TableLevel
        {
            Faculties = 0,
            Groups = 1,
            Students = 2
        };

        private string cs =
            @"Data Source=HPVICTUS16\SQLEXPRESS; Initial Catalog=University; Integrated Security=true";

        public Dictionary<int, string> Faculties
        {
            get { return _faculties; }
        }

        private Dictionary<int, string> _faculties = new Dictionary<int, string>();
        private Dictionary<TreeNode, int> facultyIDs = new Dictionary<TreeNode, int>();

        public Dictionary<int, string> Groups
        {
            get { return _groups; }
        }

        private Dictionary<int, string> _groups = new Dictionary<int, string>();
        private Dictionary<TreeNode, int> groupIDs = new Dictionary<TreeNode, int>();

        public Dictionary<int, string> Students
        {
            get { return _students; }
        }

        private Dictionary<int, string> _students = new Dictionary<int, string>();
        private Dictionary<TreeNode, int> studentIDs = new Dictionary<TreeNode, int>();

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
                    _specializations.Add((int) dr["ID"], dr["Name"].ToString());
                }
            }

            LoadFaculties();
        }

        private void Specializations_Click(object sender, EventArgs e)
        {
            SpecializationsEditForm specializationsEditForm = new SpecializationsEditForm();
            specializationsEditForm.ShowDialog();
            LoadFaculties();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _faculties = new Dictionary<int, string>();
            facultyIDs = new Dictionary<TreeNode, int>();
            _students = new Dictionary<int, string>();
            studentIDs = new Dictionary<TreeNode, int>();
            _groups = new Dictionary<int, string>();
            groupIDs = new Dictionary<TreeNode, int>();
            LoadFaculties();
            foreach (TreeNode treeNode in treeView1.Nodes)
            {
                LoadGroups(facultyIDs[treeNode], treeNode);
                foreach (TreeNode treeNodeNode in treeNode.Nodes)
                {
                    LoadStudents(groupIDs[treeNodeNode], treeNodeNode);
                }
            }
            treeView1.ExpandAll();
        }

        public void LoadTree(TreeNode treeNode)
        {
            switch (treeNode.Level)
            {
                case (int)TableLevel.Faculties:
                    LoadFaculties();
                    break;
                case (int)TableLevel.Groups:
                    LoadFaculties();
                    LoadGroups(facultyIDs[treeNode.Parent], treeNode.Parent);
                    break;
                case (int)TableLevel.Students:
                    LoadFaculties();
                    LoadGroups(facultyIDs[treeNode.Parent.Parent], treeNode.Parent.Parent);
                    LoadStudents(groupIDs[treeNode.Parent], treeNode.Parent);
                    break;
            }
            TreeNode parent = treeNode.Parent;
            List<TreeNode> parents = new List<TreeNode>();
            while (parent != null)
            {
                parents.Add(parent);
                parent = parent.Parent;
                Debug.Print(parents.ToString());
            }

            parents.Reverse();
            foreach (TreeNode node in parents)
            {
                node.Expand();
                Debug.Print(node.ToString());
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
                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    int id = (int) dr["ID"];
                    TreeNode tn = new TreeNode(name);
                    tn.Nodes.Add("Загрузка...");
                    treeView1.Nodes.Add(tn);
                    if (!_faculties.ContainsKey(id))
                        _faculties.Add(id, name);
                    else
                        _faculties[id] = name;
                    facultyIDs.Add(tn, id);
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
                    int id = (int) dr["ID"];
                    TreeNode tn = new TreeNode(name + ", " + Specializations[(int) dr["Specialization ID"]]);
                    tn.Nodes.Add("Загрузка...");
                    parentTreeNode.Nodes.Add(tn);
                    if (!_groups.ContainsKey(id)) 
                        _groups.Add(id, name);
                    else
                        _groups[id] = name;
                    groupIDs.Add(tn, id);
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
                        name = dr["Surname"].ToString() + " " + dr["Name"].ToString() + " " + middleName;
                    else
                        name = dr["Surname"].ToString() + " " + dr["Name"].ToString();
                    int id = (int) dr["ID"];
                    TreeNode tn = new TreeNode(name);
                    parentTreeNode.Nodes.Add(tn);
                    if (!_students.ContainsKey(id))
                        _students.Add(id, name);
                    else
                        _students[id] = name;
                    studentIDs.Add(tn, id);
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {

                    switch (treeView1.SelectedNode.Level)
                    {
                        case (int) TableLevel.Faculties:
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(
                                @"Delete from Faculties where Faculties.ID = @facultyID", connection);
                            cmd.Parameters.AddWithValue("@facultyID", facultyIDs[treeView1.SelectedNode]);
                            var dr = cmd.ExecuteReader();
                            dr.Read();
                            Debug.Print(dr.ToString());
                            LoadTree(treeView1.SelectedNode);
                        }
                            break;
                        case (int) TableLevel.Groups:
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(
                                @"Delete from Groups where Groups.ID = @groupID", connection);
                            cmd.Parameters.AddWithValue("@groupID", groupIDs[treeView1.SelectedNode]);
                            var dr = cmd.ExecuteReader();
                            dr.Read();
                            Debug.Print(dr.ToString());
                            LoadTree(treeView1.SelectedNode);
                        }
                            break;
                        case (int) TableLevel.Students:
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(
                                @"Delete from Students where Students.ID = @studentID", connection);
                            cmd.Parameters.AddWithValue("@studentID", studentIDs[treeView1.SelectedNode]);
                            var dr = cmd.ExecuteReader();
                            dr.Read();
                            Debug.Print(dr.ToString());
                            LoadTree(treeView1.SelectedNode);
                        }
                            break;
                    }
                }
            }
            catch (NullReferenceException exception)
            {
            }
        }

        private void cтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentEditForm frm3 = new StudentEditForm(this);
            frm3.ShowDialog();
            LoadFaculties();
        }

        private void группуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupEditForm frm2 = new GroupEditForm(this);
            frm2.ShowDialog();
            LoadFaculties();
        }

        private void факультетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultyEditForm frm1 = new FacultyEditForm(this);
            frm1.ShowDialog();
            LoadFaculties();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //try
            //{
                switch (e.Node.Level)
                {
                    case (int) TableLevel.Faculties:
                        FacultyEditForm frm1 = new FacultyEditForm(this, facultyIDs[e.Node]);
                        frm1.ShowDialog();
                        LoadTree(e.Node);
                        break;
                    case (int) TableLevel.Groups:
                        GroupEditForm frm2 = new GroupEditForm(this, groupIDs[e.Node]);
                        frm2.ShowDialog();
                        LoadTree(e.Node);
                        break;
                    case (int) TableLevel.Students:
                        StudentEditForm frm3 = new StudentEditForm(this, studentIDs[e.Node]);
                        frm3.ShowDialog();
                        Debug.Print(e.Node.ToString())Tos                 LoadTree(e.Node);
                        break;
                }
            //}
            //catch (NullReferenceException exception)
            //{
            //}
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //try
            //{
                switch (e.Node.Level)
                {
                    case (int)TableLevel.Faculties:
                        LoadGroups(facultyIDs[e.Node], e.Node);
                        break;
                    case (int)TableLevel.Groups:
                        LoadStudents(groupIDs[e.Node], e.Node);
                        break;
                    //case (int)TableLevel.Students:
                    //    break;
                }
            //}
            //catch (NullReferenceException exception)
            //{
            //}
        }
    }
}
