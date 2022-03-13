namespace KPOLaba2
{
    partial class GroupEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label specialization_IDLabel;
            System.Windows.Forms.Label faculty_IDLabel;
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.iDLabel1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.specialization_IDComboBox = new System.Windows.Forms.ComboBox();
            this.faculty_IDComboBox = new System.Windows.Forms.ComboBox();
            this.groupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.universityDataSet = new KPOLaba2.UniversityDataSet();
            this.groupsTableAdapter = new KPOLaba2.UniversityDataSetTableAdapters.GroupsTableAdapter();
            this.tableAdapterManager = new KPOLaba2.UniversityDataSetTableAdapters.TableAdapterManager();
            iDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            specialization_IDLabel = new System.Windows.Forms.Label();
            faculty_IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.universityDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(116, 115);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(197, 115);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(12, 9);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(21, 13);
            iDLabel.TabIndex = 9;
            iDLabel.Text = "ID:";
            // 
            // iDLabel1
            // 
            this.iDLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.groupsBindingSource, "ID", true));
            this.iDLabel1.Location = new System.Drawing.Point(96, 9);
            this.iDLabel1.Name = "iDLabel1";
            this.iDLabel1.Size = new System.Drawing.Size(176, 23);
            this.iDLabel1.TabIndex = 10;
            this.iDLabel1.Text = "label1";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 38);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(60, 13);
            nameLabel.TabIndex = 11;
            nameLabel.Text = "Название:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.groupsBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(96, 35);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(176, 20);
            this.nameTextBox.TabIndex = 12;
            this.nameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            // 
            // specialization_IDLabel
            // 
            specialization_IDLabel.AutoSize = true;
            specialization_IDLabel.Location = new System.Drawing.Point(12, 64);
            specialization_IDLabel.Name = "specialization_IDLabel";
            specialization_IDLabel.Size = new System.Drawing.Size(78, 13);
            specialization_IDLabel.TabIndex = 13;
            specialization_IDLabel.Text = "Направление:";
            // 
            // specialization_IDComboBox
            // 
            this.specialization_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.groupsBindingSource, "Specialization ID", true));
            this.specialization_IDComboBox.FormattingEnabled = true;
            this.specialization_IDComboBox.Location = new System.Drawing.Point(96, 61);
            this.specialization_IDComboBox.Name = "specialization_IDComboBox";
            this.specialization_IDComboBox.Size = new System.Drawing.Size(176, 21);
            this.specialization_IDComboBox.TabIndex = 14;
            this.specialization_IDComboBox.Enter += new System.EventHandler(this.specialization_IDComboBox_Enter);
            this.specialization_IDComboBox.Leave += new System.EventHandler(this.specialization_IDComboBox_Leave);
            // 
            // faculty_IDLabel
            // 
            faculty_IDLabel.AutoSize = true;
            faculty_IDLabel.Location = new System.Drawing.Point(12, 91);
            faculty_IDLabel.Name = "faculty_IDLabel";
            faculty_IDLabel.Size = new System.Drawing.Size(66, 13);
            faculty_IDLabel.TabIndex = 15;
            faculty_IDLabel.Text = "Факультет:";
            // 
            // faculty_IDComboBox
            // 
            this.faculty_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.groupsBindingSource, "Faculty ID", true));
            this.faculty_IDComboBox.FormattingEnabled = true;
            this.faculty_IDComboBox.Location = new System.Drawing.Point(96, 88);
            this.faculty_IDComboBox.Name = "faculty_IDComboBox";
            this.faculty_IDComboBox.Size = new System.Drawing.Size(176, 21);
            this.faculty_IDComboBox.TabIndex = 16;
            this.faculty_IDComboBox.Enter += new System.EventHandler(this.faculty_IDComboBox_Enter);
            this.faculty_IDComboBox.Leave += new System.EventHandler(this.faculty_IDComboBox_Leave);
            // 
            // groupsBindingSource
            // 
            this.groupsBindingSource.DataMember = "Groups";
            this.groupsBindingSource.DataSource = this.universityDataSet;
            // 
            // universityDataSet
            // 
            this.universityDataSet.DataSetName = "UniversityDataSet";
            this.universityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupsTableAdapter
            // 
            this.groupsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.FacultiesTableAdapter = null;
            this.tableAdapterManager.GroupsTableAdapter = this.groupsTableAdapter;
            this.tableAdapterManager.SpecializationsTableAdapter = null;
            this.tableAdapterManager.StudentsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = KPOLaba2.UniversityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // GroupEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 149);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDLabel1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(specialization_IDLabel);
            this.Controls.Add(this.specialization_IDComboBox);
            this.Controls.Add(faculty_IDLabel);
            this.Controls.Add(this.faculty_IDComboBox);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "GroupEditForm";
            this.Text = "Группа";
            this.Load += new System.EventHandler(this.GroupEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.universityDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private UniversityDataSet universityDataSet;
        private System.Windows.Forms.BindingSource groupsBindingSource;
        private UniversityDataSetTableAdapters.GroupsTableAdapter groupsTableAdapter;
        private UniversityDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label iDLabel1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox specialization_IDComboBox;
        private System.Windows.Forms.ComboBox faculty_IDComboBox;
    }
}