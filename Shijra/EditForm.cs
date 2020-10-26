using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shijra
{
    public partial class EditForm : Form
    {

        public EditForm()
        {
            InitializeComponent();
            LoadParents();
            this.AcceptButton = btnNext;
        }

        public Model.Person PersonToEdit
        {
            get;
            set;
        }

        private void LoadParents()
        {
            List<Model.Person> fathers = ShijraContext.entities.Persons.OrderBy(x => x.FirstName).ToList();

            //fathers.ForEach(x => x.Name = x.FirstName.Trim() + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : " " + x.MiddleName.Trim()) + (string.IsNullOrEmpty(x.LastName) ? string.Empty : " " + x.LastName.Trim()));

            ddlFathers.DataSource = fathers;
            ddlFathers.DisplayMember = "Name";
            ddlFathers.ValueMember = "Id";

            ddlFathers.SelectedIndex = -1;
        }

        private void LoadData()
        {
            if (PersonToEdit != null)
            {
                ddlFathers.SelectedValue = PersonToEdit.FatherId;
                txtFname.Text = PersonToEdit.FirstName;
                txtMName.Text = string.IsNullOrEmpty(PersonToEdit.MiddleName) ? string.Empty : PersonToEdit.MiddleName;
                txtLName.Text = string.IsNullOrEmpty(PersonToEdit.LastName) ? string.Empty : PersonToEdit.LastName;
                txtUrduName.Text = string.IsNullOrEmpty(PersonToEdit.UrduName) ? string.Empty : PersonToEdit.UrduName;
                if (PersonToEdit.Gender)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;

                if (PersonToEdit.Persondetail != null)
                {
                    txtEducation.Text = string.IsNullOrEmpty(PersonToEdit.Persondetail.Education) ? string.Empty : PersonToEdit.Persondetail.Education;
                    txtOccupation.Text = string.IsNullOrEmpty(PersonToEdit.Persondetail.Occupation) ? string.Empty : PersonToEdit.Persondetail.Occupation;
                }
                List<Model.Person> childs = PersonToEdit.Childs.OrderBy(c => c.Id).ToList();
                //childs.ForEach(x => x.Name = x.FirstName.Trim() + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : " " + x.MiddleName.Trim()) + (string.IsNullOrEmpty(x.LastName) ? string.Empty : " " + x.LastName.Trim()));

                chkLstChilds.DataSource = childs;
                chkLstChilds.DisplayMember = "Name";

            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Record Updated Successfully");
                this.DialogResult = DialogResult.OK;
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

        private bool Save()
        {
            if (!ValidateData())
            {
                MessageBox.Show("Given Data is not complete or valid");
                return false;
            }

            Model.Person updatedPerson = ShijraContext.entities.Persons.First(e => e.Id == PersonToEdit.Id);
            updatedPerson.FirstName = txtFname.Text.Trim();
            if (!string.IsNullOrEmpty(txtMName.Text))
                updatedPerson.MiddleName = txtMName.Text.Trim();
            else
                updatedPerson.MiddleName = null;
            if (!string.IsNullOrEmpty(txtLName.Text))
                updatedPerson.LastName = txtLName.Text.Trim();
            else
                updatedPerson.LastName = null;
            if (!string.IsNullOrEmpty(txtUrduName.Text))
                updatedPerson.UrduName = txtUrduName.Text.Trim();
            else
                updatedPerson.UrduName = null;

            updatedPerson.FatherId = Convert.ToInt64(ddlFathers.SelectedValue);
            updatedPerson.Gender = rbMale.Checked;

            if (!string.IsNullOrEmpty(txtEducation.Text.Trim()) || !string.IsNullOrEmpty(txtOccupation.Text.Trim()))
            {
                updatedPerson.Persondetail = new Model.PersonDetail();
                updatedPerson.Persondetail.Occupation = string.IsNullOrEmpty(txtOccupation.Text.Trim()) ? string.Empty : txtOccupation.Text.Trim();
                updatedPerson.Persondetail.Education = string.IsNullOrEmpty(txtEducation.Text.Trim()) ? string.Empty : txtEducation.Text.Trim();
            }

            if (chkLstChilds.CheckedItems.Count > 0)
            {
                List<string> names = new List<string>();
                foreach (object obj in chkLstChilds.CheckedItems)
                {
                    names.Add(((Model.Person)obj).Name);
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + string.Join(", ", names.ToArray()) + " and" + (chkLstChilds.CheckedItems.Count == 1 ? " his" : " their") + " childs?", "Confirm", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("Record not updated. If you dont want to delete childs then please uncheck them.");
                    return false;
                }
            }

            foreach (object obj in chkLstChilds.CheckedItems)
            {
                //ShijraContext.entities.Persons.First(e => e.Id == ((Model.Person)obj).Id);
                Model.Person deletedPerson = (Model.Person)obj;

                DeleteChild(deletedPerson);
            }

            ShijraContext.entities.SaveChanges();

            return true;

        }

        private void DeleteChild(Model.Person p)
        {
            ShijraContext.entities.Persons.DeleteObject(p);
        }

        private void ddlFathers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFathers.SelectedIndex >= 0)
            {
                Model.Person person = (Model.Person)ddlFathers.SelectedItem;

                txtGrandFather.Text = person.Father.FirstName.Trim() + (string.IsNullOrEmpty(person.Father.MiddleName) ? string.Empty : " " + person.Father.MiddleName.Trim()) + (string.IsNullOrEmpty(person.Father.LastName) ? string.Empty : " " + person.Father.LastName.Trim());

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                 List<Model.Person> persons = ShijraContext.entities.Persons.Where(p => p.Id == PersonToEdit.Id + 1).ToList();
                 if (persons != null && persons.Count > 0)
                 {
                     PersonToEdit = persons[0];
                     LoadParents();
                     LoadData();
                 }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                if (PersonToEdit.Id > 1)
                {
                    PersonToEdit = ShijraContext.entities.Persons.Where(p => p.Id == PersonToEdit.Id - 1).First();
                    LoadParents();
                    LoadData();
                }
            }
        }


    }
}
