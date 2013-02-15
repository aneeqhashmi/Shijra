using System.Windows.Forms;
namespace Shijra
{
    partial class MainForm
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.dialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtUrduName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtGFather = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEducation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstChilds = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlFathers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFailureCount = new System.Windows.Forms.Label();
            this.lblSuccessCount = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblUrduName = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblFather = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.lblEducation = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstChildsView = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlFathersView = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(324, 53);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(30, 55);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(288, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 317);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.rbFemale);
            this.tabPage1.Controls.Add(this.rbMale);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.txtUrduName);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.txtGFather);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.txtOccupation);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtEducation);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lstChilds);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.txtLName);
            this.tabPage1.Controls.Add(this.txtMName);
            this.tabPage1.Controls.Add(this.txtFname);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ddlFathers);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Record";
            // 
            // txtUrduName
            // 
            this.txtUrduName.Location = new System.Drawing.Point(90, 153);
            this.txtUrduName.Name = "txtUrduName";
            this.txtUrduName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUrduName.Size = new System.Drawing.Size(267, 20);
            this.txtUrduName.TabIndex = 19;
            this.txtUrduName.Enter += new System.EventHandler(this.txtUrduName_Enter);
            this.txtUrduName.Leave += new System.EventHandler(this.txtUrduName_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Name (Urdu)";
            // 
            // txtGFather
            // 
            this.txtGFather.Location = new System.Drawing.Point(90, 21);
            this.txtGFather.Name = "txtGFather";
            this.txtGFather.ReadOnly = true;
            this.txtGFather.Size = new System.Drawing.Size(267, 20);
            this.txtGFather.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Grand Father";
            // 
            // txtOccupation
            // 
            this.txtOccupation.Location = new System.Drawing.Point(90, 207);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(267, 20);
            this.txtOccupation.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 210);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Occupation";
            // 
            // txtEducation
            // 
            this.txtEducation.Location = new System.Drawing.Point(90, 181);
            this.txtEducation.Name = "txtEducation";
            this.txtEducation.Size = new System.Drawing.Size(267, 20);
            this.txtEducation.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Education";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Children";
            // 
            // lstChilds
            // 
            this.lstChilds.FormattingEnabled = true;
            this.lstChilds.Location = new System.Drawing.Point(385, 25);
            this.lstChilds.Name = "lstChilds";
            this.lstChilds.Size = new System.Drawing.Size(241, 199);
            this.lstChilds.TabIndex = 10;
            this.lstChilds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstChilds_MouseDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(148, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Location = new System.Drawing.Point(229, 261);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(90, 127);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(267, 20);
            this.txtLName.TabIndex = 7;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(90, 101);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(267, 20);
            this.txtMName.TabIndex = 6;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(90, 74);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(267, 20);
            this.txtFname.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Middle Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name";
            // 
            // ddlFathers
            // 
            this.ddlFathers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ddlFathers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlFathers.FormattingEnabled = true;
            this.ddlFathers.Location = new System.Drawing.Point(90, 47);
            this.ddlFathers.Name = "ddlFathers";
            this.ddlFathers.Size = new System.Drawing.Size(267, 21);
            this.ddlFathers.TabIndex = 1;
            this.ddlFathers.SelectedIndexChanged += new System.EventHandler(this.ddlFathers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Father";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.lblFailureCount);
            this.tabPage2.Controls.Add(this.lblSuccessCount);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.btnImport);
            this.tabPage2.Controls.Add(this.btnBrowse);
            this.tabPage2.Controls.Add(this.txtFileName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 265);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            // 
            // lblFailureCount
            // 
            this.lblFailureCount.AutoSize = true;
            this.lblFailureCount.Location = new System.Drawing.Point(183, 192);
            this.lblFailureCount.Name = "lblFailureCount";
            this.lblFailureCount.Size = new System.Drawing.Size(10, 13);
            this.lblFailureCount.TabIndex = 7;
            this.lblFailureCount.Text = "-";
            // 
            // lblSuccessCount
            // 
            this.lblSuccessCount.AutoSize = true;
            this.lblSuccessCount.Location = new System.Drawing.Point(183, 164);
            this.lblSuccessCount.Name = "lblSuccessCount";
            this.lblSuccessCount.Size = new System.Drawing.Size(10, 13);
            this.lblSuccessCount.TabIndex = 6;
            this.lblSuccessCount.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(76, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Failure Import Count:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(55, 164);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Successful Import Count:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Select File to Import";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(138, 99);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(83, 27);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.lblGender);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.lblUrduName);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.btnDelete);
            this.tabPage3.Controls.Add(this.btnEdit);
            this.tabPage3.Controls.Add(this.lblFather);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.lblOccupation);
            this.tabPage3.Controls.Add(this.lblEducation);
            this.tabPage3.Controls.Add(this.lblName);
            this.tabPage3.Controls.Add(this.lblId);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.lstChildsView);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.ddlFathersView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 291);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "View";
            // 
            // lblUrduName
            // 
            this.lblUrduName.AutoSize = true;
            this.lblUrduName.Location = new System.Drawing.Point(85, 148);
            this.lblUrduName.Name = "lblUrduName";
            this.lblUrduName.Size = new System.Drawing.Size(10, 13);
            this.lblUrduName.TabIndex = 27;
            this.lblUrduName.Text = "-";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 148);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 26;
            this.label21.Text = "Name (Urdu)";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(215, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 255);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblFather
            // 
            this.lblFather.AutoSize = true;
            this.lblFather.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFather.Location = new System.Drawing.Point(85, 127);
            this.lblFather.Name = "lblFather";
            this.lblFather.Size = new System.Drawing.Size(10, 13);
            this.lblFather.TabIndex = 23;
            this.lblFather.Text = "-";
            this.lblFather.DoubleClick += new System.EventHandler(this.lblName_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Father";
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(85, 192);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(10, 13);
            this.lblOccupation.TabIndex = 21;
            this.lblOccupation.Text = "-";
            // 
            // lblEducation
            // 
            this.lblEducation.AutoSize = true;
            this.lblEducation.Location = new System.Drawing.Point(85, 170);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(10, 13);
            this.lblEducation.TabIndex = 20;
            this.lblEducation.Text = "-";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(85, 105);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(10, 13);
            this.lblName.TabIndex = 19;
            this.lblName.Text = "-";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(85, 83);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(10, 13);
            this.lblId.TabIndex = 18;
            this.lblId.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Occupation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Education";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Children";
            // 
            // lstChildsView
            // 
            this.lstChildsView.FormattingEnabled = true;
            this.lstChildsView.Location = new System.Drawing.Point(389, 42);
            this.lstChildsView.Name = "lstChildsView";
            this.lstChildsView.Size = new System.Drawing.Size(241, 186);
            this.lstChildsView.TabIndex = 12;
            this.lstChildsView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstChildsView_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Person";
            // 
            // ddlFathersView
            // 
            this.ddlFathersView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ddlFathersView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlFathersView.FormattingEnabled = true;
            this.ddlFathersView.Location = new System.Drawing.Point(88, 42);
            this.ddlFathersView.Name = "ddlFathersView";
            this.ddlFathersView.Size = new System.Drawing.Size(267, 21);
            this.ddlFathersView.TabIndex = 2;
            this.ddlFathersView.SelectedIndexChanged += new System.EventHandler(this.ddlFathersView_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(38, 237);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Gender";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(90, 236);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 21;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(148, 236);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 22;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(85, 213);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(10, 13);
            this.lblGender.TabIndex = 29;
            this.lblGender.Text = "-";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(33, 212);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 13);
            this.label23.TabIndex = 28;
            this.label23.Text = "Gender";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(646, 317);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Shijra";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.OpenFileDialog dialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlFathers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnImport;
        private ListBox lstChilds;
        private Label label5;
        private TabPage tabPage3;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label7;
        private ListBox lstChildsView;
        private Label label6;
        private ComboBox ddlFathersView;
        private Label lblOccupation;
        private Label lblEducation;
        private Label lblName;
        private Label lblId;
        private Label label11;
        private Label lblFather;
        private Label label13;
        private TextBox txtOccupation;
        private Label label14;
        private TextBox txtEducation;
        private Label label12;
        private Button btnDelete;
        private Button btnEdit;
        private Label label15;
        private Label lblFailureCount;
        private Label lblSuccessCount;
        private Label label17;
        private Label label16;
        private TextBox txtGFather;
        private Label label18;
        private TextBox txtUrduName;
        private Label label19;
        private Label lblUrduName;
        private Label label21;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private Label label20;
        private Label lblGender;
        private Label label23;


    }
}

