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
    public partial class GroupEditForm : Form
    {
        private MainForm _mainForm;
        private List<KeyValuePair<int, string>> faculties = new List<KeyValuePair<int, string>>();
        private List<KeyValuePair<int, string>> specializations = new List<KeyValuePair<int, string>>();
        public GroupEditForm(MainForm mainForm, int id)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.groupsTableAdapter.Fill(this.universityDataSet.Groups);
            groupsBindingSource.Position = id;
        }

        public GroupEditForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.groupsTableAdapter.Fill(this.universityDataSet.Groups);
            groupsBindingSource.AddNew();
        }

        private void LoadFaculties()
        {
            RefreshFaculties();
            faculty_IDComboBox.Items.Clear();
            faculties.Clear();
            foreach (var faculty in _mainForm.Faculties)
            {
                faculty_IDComboBox.Items.Add(faculty.Value);
                faculties.Add(faculty);
            }
        }

        private void RefreshFaculties()
        {
            int x;
            if (int.TryParse(faculty_IDComboBox.Text, out x))
                faculty_IDComboBox.Text = _mainForm.Faculties[x];
        }

        private void UnloadFaculties()
        {
            try
            {
                faculty_IDComboBox.Text = faculties[faculty_IDComboBox.SelectedIndex].Key.ToString();
            }
            catch (Exception e)
            {

            }
        }

        private void LoadSpecializations()
        {
            RefreshSpecializations();
            specialization_IDComboBox.Items.Clear();
            specializations.Clear();
            foreach (var specialization in _mainForm.Specializations)
            {
                specialization_IDComboBox.Items.Add(specialization.Value);
                specializations.Add(specialization);
            }
        }

        private void RefreshSpecializations()
        {
            int x;
            if (int.TryParse(specialization_IDComboBox.Text, out x))
                specialization_IDComboBox.Text = _mainForm.Specializations[x];
        }

        private void UnloadSpecializations()
        {
            try
            {
                specialization_IDComboBox.Text = specializations[specialization_IDComboBox.SelectedIndex].Key.ToString();
            }
            catch (Exception e)
            {

            }
        }


        private void GroupEditForm_Load(object sender, EventArgs e)
        {
            LoadFaculties();
            LoadSpecializations();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            UnloadSpecializations();
            UnloadFaculties();
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                UnloadFaculties();
                UnloadSpecializations();
                this.Validate();
                this.groupsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.universityDataSet);
                Close();
            }
            catch (System.Data.NoNullAllowedException exception)
            {
                RefreshFaculties();
                RefreshSpecializations();
                MessageBox.Show("Некоторые поля, в которые невведены данные, должны содержать данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void faculty_IDComboBox_Leave(object sender, EventArgs e)
        {
            UnloadFaculties();
            RefreshSpecializations();
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            RefreshFaculties();
            RefreshSpecializations();
        }

        private void specialization_IDComboBox_Enter(object sender, EventArgs e)
        {
            RefreshFaculties();
            RefreshSpecializations();
        }

        private void faculty_IDComboBox_Enter(object sender, EventArgs e)
        {
            RefreshFaculties();
            RefreshSpecializations();
        }

        private void specialization_IDComboBox_Leave(object sender, EventArgs e)
        {
            UnloadSpecializations();
        }
    }
}
