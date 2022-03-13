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
    public partial class FacultyEditForm : Form
    {
        private MainForm _mainForm;
        public FacultyEditForm(MainForm mainForm, int id)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.facultiesTableAdapter.Fill(this.universityDataSet.Faculties);
            facultiesBindingSource.Position = id;
        }

        public FacultyEditForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.facultiesTableAdapter.Fill(this.universityDataSet.Faculties);
            facultiesBindingSource.AddNew();
        }



        private void FacultyEditForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.facultiesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.universityDataSet);
                Close();
            }
            catch (System.Data.NoNullAllowedException exception)
            {
                MessageBox.Show("Некоторые поля, в которые невведены данные, должны содержать данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
