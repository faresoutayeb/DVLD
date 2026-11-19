namespace DVLD_Presentation_Layer.LocalDrivingLicence
{
    partial class NewLocalDrivingLicensesApplicationsScreen
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpagePersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlFilterPersonInformation1 = new DVLD_Presentation_Layer.Person.PersonControles.ctrlFilterPersonInformation();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbpageApplicationInfo = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblAppIdValue = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbpagePersonalInfo.SuspendLayout();
            this.tbpageApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpagePersonalInfo);
            this.tabControl1.Controls.Add(this.tbpageApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(26, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(818, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpagePersonalInfo
            // 
            this.tbpagePersonalInfo.Controls.Add(this.ctrlFilterPersonInformation1);
            this.tbpagePersonalInfo.Controls.Add(this.btnNext);
            this.tbpagePersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpagePersonalInfo.Name = "tbpagePersonalInfo";
            this.tbpagePersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpagePersonalInfo.Size = new System.Drawing.Size(810, 371);
            this.tbpagePersonalInfo.TabIndex = 0;
            this.tbpagePersonalInfo.Text = "Personal Info";
            this.tbpagePersonalInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlFilterPersonInformation1
            // 
            this.ctrlFilterPersonInformation1.Location = new System.Drawing.Point(49, 17);
            this.ctrlFilterPersonInformation1.Name = "ctrlFilterPersonInformation1";
            this.ctrlFilterPersonInformation1.Size = new System.Drawing.Size(713, 275);
            this.ctrlFilterPersonInformation1.TabIndex = 3;
            this.ctrlFilterPersonInformation1.OnPersonWeSearchFor += new System.Action<int>(this.ctrlFilterPersonInformation1_OnPersonWeSearchFor);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(678, 311);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(110, 44);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbpageApplicationInfo
            // 
            this.tbpageApplicationInfo.Controls.Add(this.btnBack);
            this.tbpageApplicationInfo.Controls.Add(this.lblCurrentUser);
            this.tbpageApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tbpageApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tbpageApplicationInfo.Controls.Add(this.lblAppIdValue);
            this.tbpageApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tbpageApplicationInfo.Controls.Add(this.label5);
            this.tbpageApplicationInfo.Controls.Add(this.label4);
            this.tbpageApplicationInfo.Controls.Add(this.label3);
            this.tbpageApplicationInfo.Controls.Add(this.label2);
            this.tbpageApplicationInfo.Controls.Add(this.label1);
            this.tbpageApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpageApplicationInfo.Name = "tbpageApplicationInfo";
            this.tbpageApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpageApplicationInfo.Size = new System.Drawing.Size(810, 371);
            this.tbpageApplicationInfo.TabIndex = 1;
            this.tbpageApplicationInfo.Text = "Application Info";
            this.tbpageApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(25, 317);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 44);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblCurrentUser.Location = new System.Drawing.Point(371, 289);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(60, 25);
            this.lblCurrentUser.TabIndex = 9;
            this.lblCurrentUser.Text = "????";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblApplicationFees.Location = new System.Drawing.Point(371, 223);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(60, 25);
            this.lblApplicationFees.TabIndex = 8;
            this.lblApplicationFees.Text = "????";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblApplicationDate.Location = new System.Drawing.Point(371, 100);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(60, 25);
            this.lblApplicationDate.TabIndex = 7;
            this.lblApplicationDate.Text = "????";
            // 
            // lblAppIdValue
            // 
            this.lblAppIdValue.AutoSize = true;
            this.lblAppIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblAppIdValue.Location = new System.Drawing.Point(371, 42);
            this.lblAppIdValue.Name = "lblAppIdValue";
            this.lblAppIdValue.Size = new System.Drawing.Size(60, 25);
            this.lblAppIdValue.TabIndex = 6;
            this.lblAppIdValue.Text = "????";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(298, 153);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(238, 21);
            this.cbLicenseClasses.TabIndex = 5;
            this.cbLicenseClasses.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClasses_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label5.Location = new System.Drawing.Point(79, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Created By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label4.Location = new System.Drawing.Point(79, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Fees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(79, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "License Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(79, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(79, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License Id";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnClose.Location = new System.Drawing.Point(258, 522);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 53);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnSave.Location = new System.Drawing.Point(406, 522);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 53);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.label7.Location = new System.Drawing.Point(171, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(431, 36);
            this.label7.TabIndex = 3;
            this.label7.Text = "Add New Local Driving License";
            // 
            // NewLocalDrivingLicensesApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 616);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "NewLocalDrivingLicensesApplications";
            this.Text = "NewLocalDrivingLicensesApplications";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewLocalDrivingLicensesApplications_FormClosed);
            this.Load += new System.EventHandler(this.NewLocalDrivingLicensesApplications_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpagePersonalInfo.ResumeLayout(false);
            this.tbpageApplicationInfo.ResumeLayout(false);
            this.tbpageApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpagePersonalInfo;
        private System.Windows.Forms.TabPage tbpageApplicationInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblAppIdValue;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private Person.PersonControles.ctrlFilterPersonInformation ctrlFilterPersonInformation1;
    }
}