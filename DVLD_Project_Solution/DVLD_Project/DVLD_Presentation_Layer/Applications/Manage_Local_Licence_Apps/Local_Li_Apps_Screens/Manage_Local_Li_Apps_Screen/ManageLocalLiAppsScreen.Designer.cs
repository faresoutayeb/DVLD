namespace DVLD_Presentation_Layer.Local_Driving_Licence
{
    partial class ManageLocalDrivingLicenseApplicationsScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLocalApplicationsLicenses = new System.Windows.Forms.DataGridView();
            this.ManageLocalDvLsContextMenueStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canselApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ishueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtbFilterByNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCounter = new System.Windows.Forms.Label();
            this.txtbFilterByString = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplicationsLicenses)).BeginInit();
            this.ManageLocalDvLsContextMenueStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocalApplicationsLicenses
            // 
            this.dgvLocalApplicationsLicenses.AllowUserToAddRows = false;
            this.dgvLocalApplicationsLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalApplicationsLicenses.AllowUserToOrderColumns = true;
            this.dgvLocalApplicationsLicenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalApplicationsLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalApplicationsLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalApplicationsLicenses.ContextMenuStrip = this.ManageLocalDvLsContextMenueStrip;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalApplicationsLicenses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalApplicationsLicenses.Location = new System.Drawing.Point(76, 194);
            this.dgvLocalApplicationsLicenses.Name = "dgvLocalApplicationsLicenses";
            this.dgvLocalApplicationsLicenses.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalApplicationsLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocalApplicationsLicenses.Size = new System.Drawing.Size(1232, 350);
            this.dgvLocalApplicationsLicenses.TabIndex = 0;
            this.dgvLocalApplicationsLicenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalApplicationsLicenses_CellContentClick);
            // 
            // ManageLocalDvLsContextMenueStrip
            // 
            this.ManageLocalDvLsContextMenueStrip.BackColor = System.Drawing.Color.White;
            this.ManageLocalDvLsContextMenueStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ManageLocalDvLsContextMenueStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageLocalDvLsContextMenueStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.ManageLocalDvLsContextMenueStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.deleteAppToolStripMenuItem,
            this.canselApplicationToolStripMenuItem,
            this.scheduleTestToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.ishueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.ManageLocalDvLsContextMenueStrip.Name = "ManageLocalDvLsContextMenueStrip";
            this.ManageLocalDvLsContextMenueStrip.Size = new System.Drawing.Size(280, 256);
            this.ManageLocalDvLsContextMenueStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ManageLocalDvLsContextMenueStrip_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD_Presentation_Layer.Properties.Resources.form;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // deleteAppToolStripMenuItem
            // 
            this.deleteAppToolStripMenuItem.Name = "deleteAppToolStripMenuItem";
            this.deleteAppToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.deleteAppToolStripMenuItem.Text = "Delete App";
            this.deleteAppToolStripMenuItem.Click += new System.EventHandler(this.deleteAppToolStripMenuItem_Click);
            // 
            // canselApplicationToolStripMenuItem
            // 
            this.canselApplicationToolStripMenuItem.Name = "canselApplicationToolStripMenuItem";
            this.canselApplicationToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.canselApplicationToolStripMenuItem.Text = "Cancel Application";
            this.canselApplicationToolStripMenuItem.Click += new System.EventHandler(this.canselApplicationToolStripMenuItem_Click);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.scheduleTestToolStripMenuItem.Text = "Schedule Test";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.showLicenseToolStripMenuItem.Text = "Show license";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // ishueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.ishueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            this.ishueDrivingLicenseFirstTimeToolStripMenuItem.Name = "ishueDrivingLicenseFirstTimeToolStripMenuItem";
            this.ishueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.ishueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Ishue Driving License (First Time)";
            this.ishueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.ishueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(276, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(802, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Local Driving Licenses Applications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(92, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.White;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Local Dv Ls App ID",
            "National no",
            "Full Name",
            "App Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(237, 144);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(225, 33);
            this.cbFilterBy.TabIndex = 3;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtbFilterByNumber
            // 
            this.txtbFilterByNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.txtbFilterByNumber.Location = new System.Drawing.Point(473, 146);
            this.txtbFilterByNumber.Name = "txtbFilterByNumber";
            this.txtbFilterByNumber.Size = new System.Drawing.Size(208, 31);
            this.txtbFilterByNumber.TabIndex = 4;
            this.txtbFilterByNumber.Visible = false;
            this.txtbFilterByNumber.TextChanged += new System.EventHandler(this.txtbFilterByNumber_TextChanged);
            this.txtbFilterByNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilterByNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(93, 572);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Records";
            // 
            // lblRecordsCounter
            // 
            this.lblRecordsCounter.AutoSize = true;
            this.lblRecordsCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblRecordsCounter.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCounter.Location = new System.Drawing.Point(232, 572);
            this.lblRecordsCounter.Name = "lblRecordsCounter";
            this.lblRecordsCounter.Size = new System.Drawing.Size(69, 29);
            this.lblRecordsCounter.TabIndex = 6;
            this.lblRecordsCounter.Text = "????";
            // 
            // txtbFilterByString
            // 
            this.txtbFilterByString.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.txtbFilterByString.Location = new System.Drawing.Point(473, 146);
            this.txtbFilterByString.Name = "txtbFilterByString";
            this.txtbFilterByString.Size = new System.Drawing.Size(208, 31);
            this.txtbFilterByString.TabIndex = 9;
            this.txtbFilterByString.Visible = false;
            this.txtbFilterByString.TextChanged += new System.EventHandler(this.txtbFilterByString_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.block_apps_add;
            this.pictureBox1.Location = new System.Drawing.Point(713, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ManageLocalDrivingLicenseApplicationsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 678);
            this.Controls.Add(this.txtbFilterByString);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecordsCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbFilterByNumber);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLocalApplicationsLicenses);
            this.Name = "ManageLocalDrivingLicenseApplicationsScreen";
            this.Text = "ManageLocalDrivingLicenses";
            this.Load += new System.EventHandler(this.ManageLocalDrivingLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplicationsLicenses)).EndInit();
            this.ManageLocalDvLsContextMenueStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalApplicationsLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtbFilterByNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCounter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtbFilterByString;
        private System.Windows.Forms.ContextMenuStrip ManageLocalDvLsContextMenueStrip;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canselApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ishueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}