using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPOLaba2
{
    public partial class StudentEditForm : Form
    {
        private MainForm _mainForm;
        private List<KeyValuePair<int, string>> groups = new List<KeyValuePair<int, string>>();
        public StudentEditForm(MainForm mainForm, int id)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.studentsTableAdapter.Fill(this.universityDataSet.Students);
            studentsBindingSource.Position = id;
        }

        public StudentEditForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.studentsTableAdapter.Fill(this.universityDataSet.Students);
            studentsBindingSource.AddNew();
        }

        private void StudentEditForm_Load(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void LoadGroups()
        {
            RefreshGroup();
            group_IDComboBox.Items.Clear();
            groups.Clear();
            foreach (var group in _mainForm.Groups)
            {
                group_IDComboBox.Items.Add(group.Value);
                groups.Add(group);
            }
        }

        private void RefreshGroup()
        {
            int x;
            if (int.TryParse(group_IDComboBox.Text, out x))
                group_IDComboBox.Text = _mainForm.Groups[x];
        }

        private void UnloadGroups()
        {
            try
            {
                group_IDComboBox.Text = groups[group_IDComboBox.SelectedIndex].Key.ToString();
            }
            catch (Exception e)
            {
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            UnloadGroups();
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                UnloadGroups();
                this.Validate();
                this.studentsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.universityDataSet);
                Close();
            }
            catch (System.Data.NoNullAllowedException exception)
            {
                RefreshGroup();
                MessageBox.Show("Некоторые поля, в которые невведены данные, должны содержать данные","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void group_IDComboBox_Leave(object sender, EventArgs e)
        {
            UnloadGroups();
        }

        private void group_IDComboBox_Enter(object sender, EventArgs e)
        {
            RefreshGroup();
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            RefreshGroup();
        }

        private void surnameTextBox_Enter(object sender, EventArgs e)
        {
            RefreshGroup();
        }

        private void middle_nameTextBox_Enter(object sender, EventArgs e)
        {
            RefreshGroup();
        }
    }
}
