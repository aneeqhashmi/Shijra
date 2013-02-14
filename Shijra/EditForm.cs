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
        }

        public Model.Person PersonToEdit
        {
            get;
            set;
        }

        private void LoadParents()
        {
            List<Model.Person> fathers = ShijraContext.entities.Persons.OrderBy(x => x.FirstName).ToList();

            fathers.ForEach(x => x.Name = x.FirstName.Trim() + " " + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : x.MiddleName.Trim() + " ") + x.LastName.Trim());

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
                txtLName.Text = PersonToEdit.LastName;
                if (PersonToEdit.Persondetail != null)
                {
                    txtEducation.Text = string.IsNullOrEmpty(PersonToEdit.Persondetail.Education) ? string.Empty : PersonToEdit.Persondetail.Education;
                    txtOccupation.Text = string.IsNullOrEmpty(PersonToEdit.Persondetail.Occupation) ? string.Empty : PersonToEdit.Persondetail.Occupation;
                }
                List<Model.Person> childs = PersonToEdit.Childs.OrderBy(c=> c.Id).ToList();
                childs.ForEach(x => x.Name = x.FirstName.Trim() + " " + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : x.MiddleName.Trim() + " ") + x.LastName.Trim());

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
            Save();
        }

        private bool ValidateData()
        {
            if (!string.IsNullOrEmpty(txtFname.Text.Trim())
                && !string.IsNullOrEmpty(txtLName.Text.Trim())
                && ddlFathers.SelectedIndex > 0)
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
            
            Model.Person updatedPerson = ShijraContext.entities.Persons.First(e => e.Id == PersonToEdit.Id);
            updatedPerson.FirstName = txtFname.Text.Trim();
            updatedPerson.MiddleName = txtMName.Text.Trim();
            updatedPerson.LastName = txtLName.Text.Trim();

            updatedPerson.FatherId = Convert.ToInt64(ddlFathers.SelectedValue);

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
                    return;
                }
            }

            foreach (object obj in chkLstChilds.CheckedItems)
            {
                //ShijraContext.entities.Persons.First(e => e.Id == ((Model.Person)obj).Id);
                Model.Person deletedPerson = (Model.Person)obj;

                DeleteChild(deletedPerson);
            }

            ShijraContext.entities.SaveChanges();

            MessageBox.Show("Record Updated Successfully");

            this.DialogResult = DialogResult.OK;
            
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
            //}
        }

    }
}
