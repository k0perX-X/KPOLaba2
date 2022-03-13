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
    public partial class SpecializationsEditForm : Form
    {
        public SpecializationsEditForm()
        {
            InitializeComponent();
        }

        private void SpecializationsEditForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "universityDataSet.Specializations". При необходимости она может быть перемещена или удалена.
            this.specializationsTableAdapter.Fill(this.universityDataSet.Specializations);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.specializationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.universityDataSet);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            specializationsBindingSource.RemoveCurrent();
        }
    }
}
