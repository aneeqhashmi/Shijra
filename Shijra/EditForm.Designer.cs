﻿namespace Shijra
{
    partial class EditForm
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
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEducation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlFathers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLstChilds = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrandFather = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOccupation
            // 
            this.txtOccupation.Location = new System.Drawing.Point(80, 203);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(267, 20);
            this.txtOccupation.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Occupation";
            // 
            // txtEducation
            // 
            this.txtEducation.Location = new System.Drawing.Point(80, 177);
            this.txtEducation.Name = "txtEducation";
            this.txtEducation.Size = new System.Drawing.Size(267, 20);
            this.txtEducation.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Education";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(80, 151);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(267, 20);
            this.txtLName.TabIndex = 23;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(80, 125);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(267, 20);
            this.txtMName.TabIndex = 22;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(80, 98);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(267, 20);
            this.txtFname.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Middle Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "First Name";
            // 
            // ddlFathers
            // 
            this.ddlFathers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ddlFathers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlFathers.FormattingEnabled = true;
            this.ddlFathers.Location = new System.Drawing.Point(80, 71);
            this.ddlFathers.Name = "ddlFathers";
            this.ddlFathers.Size = new System.Drawing.Size(267, 21);
            this.ddlFathers.TabIndex = 17;
            this.ddlFathers.SelectedIndexChanged += new System.EventHandler(this.ddlFathers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Father";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Edit";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(165, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Children";
            // 
            // chkLstChilds
            // 
            this.chkLstChilds.FormattingEnabled = true;
            this.chkLstChilds.Location = new System.Drawing.Point(367, 52);
            this.chkLstChilds.Name = "chkLstChilds";
            this.chkLstChilds.Size = new System.Drawing.Size(247, 154);
            this.chkLstChilds.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(364, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Mark checkbox for the child you want to delete";
            // 
            // txtGrandFather
            // 
            this.txtGrandFather.Location = new System.Drawing.Point(80, 45);
            this.txtGrandFather.Name = "txtGrandFather";
            this.txtGrandFather.ReadOnly = true;
            this.txtGrandFather.Size = new System.Drawing.Size(267, 20);
            this.txtGrandFather.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Grand Father";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 258);
            this.Controls.Add(this.txtGrandFather);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkLstChilds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOccupation);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtEducation);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlFathers);
            this.Controls.Add(this.label1);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOccupation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEducation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlFathers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox chkLstChilds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrandFather;
        private System.Windows.Forms.Label label8;
    }
}