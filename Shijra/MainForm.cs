using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using Shijra.Helpers;
using Visio = Microsoft.Office.Interop.Visio;

namespace Shijra
{
    public partial class MainForm : Form
    {
        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Methods

        private void DatabaseBackup(string ExeLocation, string DBName, string filename)
        {
            try
            {
                string tmestr = "";
                tmestr = DBName + (string.IsNullOrEmpty(filename) ? string.Empty : "_Before_" + Path.GetFileNameWithoutExtension(filename)) + "-" + DateTime.Now.ToShortDateString() + ".sql";
                tmestr = tmestr.Replace("/", "-");
                tmestr = Path.Combine(Application.StartupPath, tmestr);
                StreamWriter file = new StreamWriter(tmestr);
                ProcessStartInfo proc = new ProcessStartInfo();
                string cmd = string.Format(@"-u{0} -p{1} -h{2} {3}", "root", "root", "localhost", DBName);
                proc.FileName = ExeLocation;
                proc.RedirectStandardInput = false;
                proc.RedirectStandardOutput = true;
                proc.Arguments = cmd;
                proc.UseShellExecute = false;
                Process p = Process.Start(proc);
                string res;
                res = p.StandardOutput.ReadToEnd();
                file.WriteLine(res);
                p.WaitForExit();
                file.Close();
                //MessageBox.Show("Backup Completed");
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private bool ValidateData()
        {
            if (!string.IsNullOrEmpty(txtFname.Text.Trim())
                && ddlFathers.SelectedIndex >= 0)
                return true;
            else
                return false;
        }

        private void Save()
        {
            if (!ValidateData())
            {
                MessageBox.Show("Given Data is not complete or valid");
                return;
            }

            Model.Person child = new Model.Person();
            child.FirstName = txtFname.Text.Trim();

            if (!string.IsNullOrEmpty(txtMName.Text.Trim()))
                child.MiddleName = txtMName.Text.Trim();

            if (!string.IsNullOrEmpty(txtLName.Text.Trim()))
                child.LastName = txtLName.Text.Trim();
            
            if (!string.IsNullOrEmpty(txtUrduName.Text.Trim()))
                child.UrduName = txtUrduName.Text.Trim();

            child.FatherId = Convert.ToInt64(ddlFathers.SelectedValue);

            child.Gender = rbMale.Checked;

            if (!string.IsNullOrEmpty(txtEducation.Text.Trim()) || !string.IsNullOrEmpty(txtOccupation.Text.Trim()))
            {
                child.Persondetail = new Model.PersonDetail();
                child.Persondetail.Occupation = string.IsNullOrEmpty(txtOccupation.Text.Trim()) ? string.Empty : txtOccupation.Text.Trim();
                child.Persondetail.Education = string.IsNullOrEmpty(txtEducation.Text.Trim()) ? string.Empty : txtEducation.Text.Trim();
            }

            if (!ShijraContext.entities.Persons.ToList().Contains(child, new Helpers.PersonComparer()))
            {
                ShijraContext.entities.Persons.AddObject(child);
                ShijraContext.entities.SaveChanges();
                btnReset_Click(this, EventArgs.Empty);
                ddlFathers.SelectedValue = child.FatherId;
                MessageBox.Show("Record Added Successfully");
            }
            else
            {
                MessageBox.Show("Record already exist");
            }
        }

        private void Import(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show("file doesnot exist");
                return;
            }
            else
            {
                DatabaseBackup(@"C:\wamp\bin\mysql\mysql5.5.24\bin\mysqldump.exe", "shijra", filename);
            }

            int errorCount = 0, successfulCount = 0;
            StreamReader sr = new StreamReader(filename);

            while (!sr.EndOfStream)
            {
                string recordLine = sr.ReadLine();
                string[] recordArr = recordLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] fatherName = recordArr[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Model.Person father = new Model.Person();
                father.FirstName = fatherName[0];

                if (fatherName.Length > 2)
                {
                    father.MiddleName = fatherName[1].Trim();
                    father.LastName = fatherName[2].Trim();
                }
                else
                    father.LastName = fatherName[1].Trim();

                List<Model.Person> fathers = ShijraContext.entities.Persons.Where(e => e.FirstName.Trim() == father.FirstName && e.LastName.Trim() == father.LastName
                    && (string.IsNullOrEmpty(father.MiddleName) || e.MiddleName.Trim() == father.MiddleName)).ToList();

                if (fathers.Count == 1)
                {
                    for (int count = 1; count < recordArr.Length; count++)
                    {
                        Model.Person child = new Model.Person();
                        string[] record = recordArr[count].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        child.FirstName = record[0].Trim();

                        if (record.Length > 2)
                        {
                            child.MiddleName = record[1].Trim();
                            child.LastName = record[2].Trim();
                        }
                        else
                            child.LastName = record[1].Trim();

                        child.FatherId = fathers[0].Id;

                        if (!ShijraContext.entities.Persons.ToList().Contains(child, new Helpers.PersonComparer()))
                        {
                            ShijraContext.entities.Persons.AddObject(child);
                            successfulCount++;
                        }
                        else
                        {
                            MoveToErrorFile(filename, "Child Already exist", child.FirstName + (string.IsNullOrEmpty(child.MiddleName) ? string.Empty : " " + child.MiddleName) + " " + child.LastName);
                            errorCount++;
                        }
                    }

                    ShijraContext.entities.SaveChanges();
                }
                else
                {
                    if (fathers.Count == 0)
                        MoveToErrorFile(filename, "Father's Record Not Found", recordLine);
                    else
                        MoveToErrorFile(filename, "Multiple Fathers found", recordLine);

                    errorCount++;
                }

            }

            sr.Close();

            lblSuccessCount.Text = successfulCount.ToString();
            lblFailureCount.Text = errorCount.ToString();

            MessageBox.Show("Import Completed. If there is any error count mentioned below then please review error file.");

        }

        private void LoadParents()
        {
            
            List<Model.Person> fathers = ShijraContext.entities.Persons.OrderBy(x => x.FirstName).ToList();

            fathers.ForEach(x => x.Name = x.FirstName.Trim() + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : " " + x.MiddleName.Trim()) + (string.IsNullOrEmpty(x.LastName) ? string.Empty : " " + x.LastName.Trim()));

            ddlFathersView.DataSource = ddlFathers.DataSource = fathers;
            ddlFathersView.DisplayMember = ddlFathers.DisplayMember = "Name";
            ddlFathersView.ValueMember = ddlFathers.ValueMember = "Id";

            ddlFathersView.SelectedIndex = ddlFathers.SelectedIndex = -1;
            txtGFather.Clear();
        }

        private void MoveToErrorFile(string filename, string errorType, string recordLine)
        {
            StreamWriter sw = new StreamWriter(filename.Substring(0, filename.Length - 4) + "_error.txt", true);
            sw.WriteLine(errorType + ": " + recordLine);
            sw.Close();
        }

        private void ResetView()
        {
            lstChildsView.DataSource = null;
            lstChildsView.Items.Clear();
            lblId.Text = "-";
            lblName.Text = "-";
            lblFather.Text = "-";
            lblOccupation.Text = "-";
            lblEducation.Text = "-";
            lblUrduName.Text = "-";
            lblGender.Text = "-";
        }

        private void DeleteChild(Model.Person p)
        {
            //if (p.Childs != null && p.Childs.Count > 0)
            //{
            //    DeleteChild(p);
            //}
            //else
            //{
                ShijraContext.entities.Persons.DeleteObject(p);
            //
        }


        #endregion

        #region EventHandler

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dialog.ShowDialog();
            this.txtFileName.Text = dialog.FileName;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (File.Exists(dialog.FileName))
            {
                Import(dialog.FileName);

                this.LoadParents();

                dialog.Reset();
                this.txtFileName.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadParents();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadParents();
            ddlFathers.SelectedIndex = -1;
            txtGFather.Clear();
            txtFname.Clear();
            txtMName.Clear();
            txtLName.Clear();
            txtEducation.Clear();
            txtOccupation.Clear();
            txtUrduName.Clear();
            txtFname.Focus();
            //rbMale.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void ddlFathers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstChilds.DataSource = null;
            lstChilds.Items.Clear();
            if (ddlFathers.SelectedIndex >= 0)
            {
                Model.Person person = (Model.Person)ddlFathers.SelectedItem;

                txtGFather.Text = person.Father.FirstName.Trim() + (string.IsNullOrEmpty(person.Father.MiddleName) ? string.Empty : " " + person.Father.MiddleName.Trim()) + (string.IsNullOrEmpty(person.Father.LastName) ? string.Empty : " " + person.Father.LastName.Trim());

                List<Model.Person> childs = person.Childs.ToList();

                childs.RemoveAll(c => c.Id == person.Id);

                childs.ForEach(x => x.Name = x.FirstName.Trim() + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : " " + x.MiddleName.Trim()) + (string.IsNullOrEmpty(x.LastName) ? string.Empty : " " + x.LastName.Trim()));

                lstChilds.DataSource = childs;
                lstChilds.DisplayMember = "Name";
                lstChilds.ValueMember = "Id";
            }
        }

        private void ddlFathersView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetView();
            if (ddlFathersView.SelectedIndex >= 0)
            {
                Model.Person person = (Model.Person)ddlFathersView.SelectedItem;
                
                List<Model.Person> childs = person.Childs.OrderBy(c=> c.Id).ToList();

                childs.RemoveAll(c => c.Id == person.Id);

                if (childs.Count > 0)
                {
                    childs.ForEach(x => x.Name = x.FirstName.Trim() + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : " " + x.MiddleName.Trim()) + (string.IsNullOrEmpty(x.LastName) ? string.Empty : " " + x.LastName.Trim()));

                    lstChildsView.DataSource = childs;
                    lstChildsView.DisplayMember = "Name";
                    lstChildsView.ValueMember = "Id";
                }
                else
                {
                    lstChildsView.Items.Add("No Child");
                }

                lblId.Text = person.Id.ToString();
                lblName.Text = person.FirstName + (string.IsNullOrEmpty(person.MiddleName) ? string.Empty : " " + person.MiddleName) + (string.IsNullOrEmpty(person.LastName) ? string.Empty : " " + person.LastName);
                lblFather.Text = person.Father.FirstName + (string.IsNullOrEmpty(person.Father.MiddleName) ? string.Empty : " " + person.Father.MiddleName) + (string.IsNullOrEmpty(person.Father.LastName) ? string.Empty : " " + person.Father.LastName);
                lblUrduName.Text = person.UrduName;
                lblGender.Text = person.Gender ? "Male" : "Female";
                if (person.Persondetail != null)
                {
                    lblEducation.Text = string.IsNullOrEmpty(person.Persondetail.Education) ? "-" : person.Persondetail.Education;
                    lblOccupation.Text = string.IsNullOrEmpty(person.Persondetail.Occupation) ? "-" : person.Persondetail.Occupation;
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm();
            edit.PersonToEdit = (Model.Person)ddlFathersView.SelectedItem;
            edit.ShowDialog();

            this.LoadParents();
            this.ResetView();
            ddlFathersView.SelectedValue = edit.PersonToEdit.Id;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Model.Person p = (Model.Person)ddlFathersView.SelectedItem;
            DialogResult result = MessageBox.Show("Are you sure you want to delete " + p.Name + " and his childs?", "Confirm", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            DeleteChild(p);

            ShijraContext.entities.SaveChanges();

            this.LoadParents();
            this.ResetView();

            MessageBox.Show("Record Deleted Successfully");
        }

        private void lstChildsView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lstChildsView.SelectedItem is Model.Person)
                ddlFathersView.SelectedValue = ((Model.Person)lstChildsView.SelectedItem).Id;
        }

        private void lstChilds_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstChilds.SelectedItem is Model.Person)
                ddlFathers.SelectedValue = ((Model.Person)lstChilds.SelectedItem).Id;
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblName.Text) && lblName.Text.Trim() != "-")
            {
                ddlFathersView.SelectedValue = ((Model.Person)ddlFathersView.SelectedItem).FatherId;
            }
        }

        private void txtUrduName_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ur-PK");
            System.Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(ci);

        }

        private void txtUrduName_Leave(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en");
            System.Windows.Forms.InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(ci);
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            int id = 36;
            Model.Person person = ShijraContext.entities.Persons.Where(p => p.Id == id).First();

            //create the object that will do the drawing
            VisioDrawer Drawer = new VisioDrawer();

            Drawer.DropShape(person.Id.ToString(), 0, 0);

            DrawPersons(person, Drawer);

            //// drop some shapes
            //Drawer.DropShape("sample1", 4, 4);
            //Drawer.DropShape("sample2", 4, 7);

            ////  get the two shapes we just drew 
            //Visio.Shape Sample1 = Drawer.GetShapeByName("sample1");
            //Sample1.Text = "Aneeq" + Environment.NewLine + "انیق";

            //Visio.Shape Sample2 = Drawer.GetShapeByName("sample2");

            //// now connect the shapes together
            //Drawer.ConnectShapes(Sample1, Sample2);

            MessageBox.Show("Graph Generated");
        }

        private void DrawPersons(Model.Person p, VisioDrawer d)
        {
            
            Visio.Shape personShape = d.GetShapeByName(p.Id.ToString());
            personShape.Text = p.Name + Environment.NewLine + p.UrduName;

            foreach (Model.Person child in p.Childs)
            {
                if (p.Id == child.Id)
                    continue;
                d.DropShape(child.Id.ToString(), 4, 4);
                Visio.Shape childShape = d.GetShapeByName(child.Id.ToString());
                //string[] urduarr = child.UrduName.Split(new char[] { ' ' }).Reverse().ToArray();
                //string urduName = string.Join(" ",urduarr); 
                childShape.Text = child.Name + Environment.NewLine + child.UrduName;
                d.ConnectShapes(personShape, childShape);
                if(child.Id < 50)
                    DrawPersons(child, d);
            }

        }

        #endregion

       
  

        

    }
}
