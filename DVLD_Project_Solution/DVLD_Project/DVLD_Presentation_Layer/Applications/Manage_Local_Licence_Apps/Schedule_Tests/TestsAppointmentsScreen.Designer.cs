namespace DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Screens
{
    partial class frmManageTestsAppointmentsScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsStreetTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalAppointmentsCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvTestsApointmentsTable = new GlobalCustomControls.MyGridView();
            this.ctrlDataGridPagesMoving2 = new DVLD_Presentation_Layer.Global_Controls.ctrlDataGridPagesMoving();
            this.ctrlActualDateTime1 = new DVLD_Presentation_Layer.Global_Controls.ctrlActualDateTime();
            this.ctrlLastUpdatedAppointments2 = new DVLD_Presentation_Layer.Global_Controls.Appointments_User_Controls.ctrlLastUpdatedAppointments();
            this.ctrlUnlockedAppointments1 = new DVLD_Presentation_Layer.Global_Controls.Appointments_User_Controls.ctrlTotalUnlockedAppointments();
            this.ctrlLockedAppointments1 = new DVLD_Presentation_Layer.Global_Controls.Appointments_User_Controls.ctrlTotalLockedAppointments();
            this.ctrlDrivingLicenseApplicationInfo2 = new DVLD_Presentation_Layer.LocalDrivingLicence.Local_Driving_License_User_Controles.ctrlDrivingLicenseApplicationInfo();
            this.ctrlTotalAppointments1 = new DVLD_Presentation_Layer.Global_Controls.ctrlTotalAppointments();
            this.ctrlDataGridPagesMoving1 = new DVLD_Presentation_Layer.Global_Controls.ctrlDataGridPagesMoving();
            this.ctrlLastUpdatedAppointments1 = new DVLD_Presentation_Layer.Global_Controls.Appointments_User_Controls.ctrlLastUpdatedAppointments();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            this.cmsStreetTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsApointmentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsStreetTest
            // 
            this.cmsStreetTest.BackColor = System.Drawing.Color.White;
            this.cmsStreetTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsStreetTest.Name = "cmsStreetTest";
            this.cmsStreetTest.Size = new System.Drawing.Size(169, 48);
            this.cmsStreetTest.Opening += new System.ComponentModel.CancelEventHandler(this.cmsStreetTest_Opening);
            // 
            // editTestToolStripMenuItem
            // 
            this.editTestToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.editTestToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editTestToolStripMenuItem.Name = "editTestToolStripMenuItem";
            this.editTestToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.editTestToolStripMenuItem.Text = "Edit Appointment";
            this.editTestToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.takeTestToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(78, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 31);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "Manage Test Appointments";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Blue;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(99, 44);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(325, 18);
            this.guna2HtmlLabel2.TabIndex = 53;
            this.guna2HtmlLabel2.Text = "View, add, edit, and manage test appointments";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(50, 19);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(154, 22);
            this.guna2HtmlLabel3.TabIndex = 55;
            this.guna2HtmlLabel3.Text = "Test Appointments";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.AutoRoundedCorners = true;
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.Cyan;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Blue;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.Aqua;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientButton1.Image = global::DVLD_Presentation_Layer.Properties.Resources.add__1_;
            this.guna2GradientButton1.Location = new System.Drawing.Point(267, 12);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(131, 33);
            this.guna2GradientButton1.TabIndex = 57;
            this.guna2GradientButton1.Text = "Add New";
            this.guna2GradientButton1.UseTransparentBackground = true;
            this.guna2GradientButton1.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(430, 19);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(149, 22);
            this.guna2HtmlLabel4.TabIndex = 58;
            this.guna2HtmlLabel4.Text = "Total Appointments : ";
            // 
            // lblTotalAppointmentsCount
            // 
            this.lblTotalAppointmentsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAppointmentsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblTotalAppointmentsCount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAppointmentsCount.Location = new System.Drawing.Point(584, 19);
            this.lblTotalAppointmentsCount.Name = "lblTotalAppointmentsCount";
            this.lblTotalAppointmentsCount.Size = new System.Drawing.Size(12, 22);
            this.lblTotalAppointmentsCount.TabIndex = 59;
            this.lblTotalAppointmentsCount.Text = "0";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::DVLD_Presentation_Layer.Properties.Resources.cleaning_time;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(13, 12);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(42, 29);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 56;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.time_management;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(15, 15);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(57, 45);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 52;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationInterval = 0;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox2.BorderRadius = 10;
            this.guna2GroupBox2.Controls.Add(this.dgvTestsApointmentsTable);
            this.guna2GroupBox2.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GroupBox2.Controls.Add(this.ctrlDataGridPagesMoving2);
            this.guna2GroupBox2.Controls.Add(this.guna2GradientButton1);
            this.guna2GroupBox2.Controls.Add(this.guna2PictureBox2);
            this.guna2GroupBox2.Controls.Add(this.guna2HtmlLabel4);
            this.guna2GroupBox2.Controls.Add(this.lblTotalAppointmentsCount);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(553, 222);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(655, 359);
            this.guna2GroupBox2.TabIndex = 74;
            // 
            // dgvTestsApointmentsTable
            // 
            this.dgvTestsApointmentsTable.AllowUserToAddRows = false;
            this.dgvTestsApointmentsTable.AllowUserToDeleteRows = false;
            this.dgvTestsApointmentsTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTestsApointmentsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestsApointmentsTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvTestsApointmentsTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTestsApointmentsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvTestsApointmentsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsApointmentsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTestsApointmentsTable.ColumnHeadersHeight = 40;
            this.dgvTestsApointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTestsApointmentsTable.ContextMenuStrip = this.cmsStreetTest;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestsApointmentsTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTestsApointmentsTable.GridColor = System.Drawing.Color.Blue;
            this.dgvTestsApointmentsTable.Location = new System.Drawing.Point(13, 51);
            this.dgvTestsApointmentsTable.Name = "dgvTestsApointmentsTable";
            this.dgvTestsApointmentsTable.ReadOnly = true;
            this.dgvTestsApointmentsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsApointmentsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTestsApointmentsTable.Size = new System.Drawing.Size(625, 256);
            this.dgvTestsApointmentsTable.TabIndex = 62;
            this.dgvTestsApointmentsTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.dgvTestsApointmentsTable.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dgvTestsApointmentsTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTestsApointmentsTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvTestsApointmentsTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTestsApointmentsTable.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvTestsApointmentsTable.ThemeStyle.GridColor = System.Drawing.Color.Blue;
            this.dgvTestsApointmentsTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.dgvTestsApointmentsTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTestsApointmentsTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTestsApointmentsTable.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTestsApointmentsTable.ThemeStyle.ReadOnly = true;
            this.dgvTestsApointmentsTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvTestsApointmentsTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvTestsApointmentsTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTestsApointmentsTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvTestsApointmentsTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvTestsApointmentsTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // ctrlDataGridPagesMoving2
            // 
            this.ctrlDataGridPagesMoving2.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDataGridPagesMoving2.CurrentPage = 1;
            this.ctrlDataGridPagesMoving2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ctrlDataGridPagesMoving2.ItemsPerPage = ((short)(10));
            this.ctrlDataGridPagesMoving2.Location = new System.Drawing.Point(13, 313);
            this.ctrlDataGridPagesMoving2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlDataGridPagesMoving2.Name = "ctrlDataGridPagesMoving2";
            this.ctrlDataGridPagesMoving2.Size = new System.Drawing.Size(638, 43);
            this.ctrlDataGridPagesMoving2.TabIndex = 61;
            this.ctrlDataGridPagesMoving2.OnButtonClicked += new System.Action(this.ctrlDataGridPagesMoving2_OnButtonClicked);
            // 
            // ctrlActualDateTime1
            // 
            this.ctrlActualDateTime1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlActualDateTime1.Location = new System.Drawing.Point(843, 3);
            this.ctrlActualDateTime1.Name = "ctrlActualDateTime1";
            this.ctrlActualDateTime1.Size = new System.Drawing.Size(214, 56);
            this.ctrlActualDateTime1.TabIndex = 75;
            // 
            // ctrlLastUpdatedAppointments2
            // 
            this.ctrlLastUpdatedAppointments2.BackColor = System.Drawing.Color.Transparent;
            this.ctrlLastUpdatedAppointments2.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlLastUpdatedAppointments2.Location = new System.Drawing.Point(905, 90);
            this.ctrlLastUpdatedAppointments2.Name = "ctrlLastUpdatedAppointments2";
            this.ctrlLastUpdatedAppointments2.Size = new System.Drawing.Size(286, 127);
            this.ctrlLastUpdatedAppointments2.TabIndex = 70;
            // 
            // ctrlUnlockedAppointments1
            // 
            this.ctrlUnlockedAppointments1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlUnlockedAppointments1.Location = new System.Drawing.Point(603, 92);
            this.ctrlUnlockedAppointments1.Name = "ctrlUnlockedAppointments1";
            this.ctrlUnlockedAppointments1.Size = new System.Drawing.Size(284, 126);
            this.ctrlUnlockedAppointments1.TabIndex = 68;
            // 
            // ctrlLockedAppointments1
            // 
            this.ctrlLockedAppointments1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlLockedAppointments1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlLockedAppointments1.Location = new System.Drawing.Point(312, 91);
            this.ctrlLockedAppointments1.Name = "ctrlLockedAppointments1";
            this.ctrlLockedAppointments1.Size = new System.Drawing.Size(285, 127);
            this.ctrlLockedAppointments1.TabIndex = 67;
            // 
            // ctrlDrivingLicenseApplicationInfo2
            // 
            this.ctrlDrivingLicenseApplicationInfo2.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDrivingLicenseApplicationInfo2.Location = new System.Drawing.Point(15, 222);
            this.ctrlDrivingLicenseApplicationInfo2.Name = "ctrlDrivingLicenseApplicationInfo2";
            this.ctrlDrivingLicenseApplicationInfo2.Size = new System.Drawing.Size(540, 372);
            this.ctrlDrivingLicenseApplicationInfo2.TabIndex = 66;
            // 
            // ctrlTotalAppointments1
            // 
            this.ctrlTotalAppointments1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalAppointments1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalAppointments1.Location = new System.Drawing.Point(15, 90);
            this.ctrlTotalAppointments1.Name = "ctrlTotalAppointments1";
            this.ctrlTotalAppointments1.Size = new System.Drawing.Size(284, 126);
            this.ctrlTotalAppointments1.TabIndex = 69;
            // 
            // ctrlDataGridPagesMoving1
            // 
            this.ctrlDataGridPagesMoving1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDataGridPagesMoving1.CurrentPage = 1;
            this.ctrlDataGridPagesMoving1.ItemsPerPage = ((short)(10));
            this.ctrlDataGridPagesMoving1.Location = new System.Drawing.Point(10, 388);
            this.ctrlDataGridPagesMoving1.Name = "ctrlDataGridPagesMoving1";
            this.ctrlDataGridPagesMoving1.Size = new System.Drawing.Size(875, 39);
            this.ctrlDataGridPagesMoving1.TabIndex = 61;
            // 
            // ctrlLastUpdatedAppointments1
            // 
            this.ctrlLastUpdatedAppointments1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlLastUpdatedAppointments1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlLastUpdatedAppointments1.Location = new System.Drawing.Point(1059, 601);
            this.ctrlLastUpdatedAppointments1.Name = "ctrlLastUpdatedAppointments1";
            this.ctrlLastUpdatedAppointments1.Size = new System.Drawing.Size(254, 147);
            this.ctrlLastUpdatedAppointments1.TabIndex = 70;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 5;
            this.guna2ControlBox1.BorderThickness = 1;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1188, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 77;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderRadius = 5;
            this.btnMinimize.BorderThickness = 1;
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1085, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 79;
            // 
            // btnMaximaze
            // 
            this.btnMaximaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximaze.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderRadius = 5;
            this.btnMaximaze.BorderThickness = 1;
            this.btnMaximaze.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximaze.Enabled = false;
            this.btnMaximaze.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMaximaze.IconColor = System.Drawing.Color.White;
            this.btnMaximaze.Location = new System.Drawing.Point(1137, 3);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 78;
            // 
            // frmManageTestsAppointmentsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1237, 661);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.ctrlActualDateTime1);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.ctrlLastUpdatedAppointments2);
            this.Controls.Add(this.ctrlUnlockedAppointments1);
            this.Controls.Add(this.ctrlLockedAppointments1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo2);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.ctrlTotalAppointments1);
            this.Controls.Add(this.guna2PictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageTestsAppointmentsScreen";
            this.Text = "ManageScheduleTestsScreen";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            this.cmsStreetTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsApointmentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsStreetTest;
        private System.Windows.Forms.ToolStripMenuItem editTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalAppointmentsCount;
        private Global_Controls.ctrlDataGridPagesMoving ctrlDataGridPagesMoving1;
        private LocalDrivingLicence.Local_Driving_License_User_Controles.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo2;
        private Global_Controls.Appointments_User_Controls.ctrlTotalLockedAppointments ctrlLockedAppointments1;
        private Global_Controls.ctrlDataGridPagesMoving ctrlDataGridPagesMoving2;
        private Global_Controls.ctrlTotalAppointments ctrlTotalAppointments1;
        private Global_Controls.Appointments_User_Controls.ctrlLastUpdatedAppointments ctrlLastUpdatedAppointments1;
        private Global_Controls.Appointments_User_Controls.ctrlLastUpdatedAppointments ctrlLastUpdatedAppointments2;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler2;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Global_Controls.Appointments_User_Controls.ctrlTotalUnlockedAppointments ctrlUnlockedAppointments1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private GlobalCustomControls.MyGridView dgvTestsApointmentsTable;
        private Global_Controls.ctrlActualDateTime ctrlActualDateTime1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
    }
}