using DVLD.Classes;
using DVLD_Bussiness_Layer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;
using GlobalCustomControls;

namespace DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.New_Local_Driving_Licenses_Applications_Screen
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessManageLocalLicensesform;
        private IContainer components;
        private Guna2PictureBox guna2PictureBox1;
        private Guna2GradientButton btnNext;
        private Guna2GradientButton btnBack;
        private Guna2GradientButton btnSave;
        private Guna2ShadowPanel guna2ShadowPanel1;
        private Guna2GradientButton btnCurrentStep;
        private RoundedTabControl tabctrlApplicationInfo;
        private TabPage tbPersonlalInfo;
        private TabPage tpApplicationInfo;
        private Guna2ComboBox cbLicenseClass;
        private Guna2HtmlLabel guna2HtmlLabel2;
        private Guna2HtmlLabel guna2HtmlLabel6;
        private Guna2HtmlLabel guna2HtmlLabel5;
        private Guna2HtmlLabel guna2HtmlLabel4;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2HtmlLabel lblCreatedByUser;
        private Guna2HtmlLabel lblFees;
        private Guna2HtmlLabel lblApplicationDate;
        private Guna2HtmlLabel lblLocalDrivingLicebseApplicationID;
        private Person.PersonControles.ctrlFilterPersonInformation ctrlPersonCardWithFilter1;
        private Guna2ControlBox guna2ControlBox1;
        private Guna2ControlBox btnMaximaze;
        private Guna2ControlBox btnMinimize;
        private Guna2HtmlLabel lblTitle;


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateLocalDrivingLicesnseApplication));
            this.borderlessManageLocalLicensesform = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnCurrentStep = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabctrlApplicationInfo = new GlobalCustomControls.RoundedTabControl();
            this.tbPersonlalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new DVLD_Presentation_Layer.Person.PersonControles.ctrlFilterPersonInformation();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.lblCreatedByUser = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFees = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblApplicationDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLocalDrivingLicebseApplicationID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbLicenseClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ShadowPanel1.SuspendLayout();
            this.tabctrlApplicationInfo.SuspendLayout();
            this.tbPersonlalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // borderlessManageLocalLicensesform
            // 
            this.borderlessManageLocalLicensesform.AnimateWindow = true;
            this.borderlessManageLocalLicensesform.AnimationInterval = 0;
            this.borderlessManageLocalLicensesform.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.borderlessManageLocalLicensesform.BorderRadius = 20;
            this.borderlessManageLocalLicensesform.ContainerControl = this;
            this.borderlessManageLocalLicensesform.DockIndicatorColor = System.Drawing.Color.Indigo;
            this.borderlessManageLocalLicensesform.DockIndicatorTransparencyValue = 0.6D;
            this.borderlessManageLocalLicensesform.ShadowColor = System.Drawing.Color.Teal;
            this.borderlessManageLocalLicensesform.TransparentWhileDrag = true;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblTitle.Location = new System.Drawing.Point(65, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Add Edit Local Driving License Application";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.btnCurrentStep);
            this.guna2ShadowPanel1.Controls.Add(this.btnNext);
            this.guna2ShadowPanel1.Controls.Add(this.btnBack);
            this.guna2ShadowPanel1.Controls.Add(this.tabctrlApplicationInfo);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(24, 58);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(874, 490);
            this.guna2ShadowPanel1.TabIndex = 11;
            // 
            // btnCurrentStep
            // 
            this.btnCurrentStep.Animated = true;
            this.btnCurrentStep.AutoRoundedCorners = true;
            this.btnCurrentStep.BorderColor = System.Drawing.Color.Aqua;
            this.btnCurrentStep.BorderRadius = 18;
            this.btnCurrentStep.BorderThickness = 1;
            this.btnCurrentStep.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCurrentStep.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCurrentStep.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCurrentStep.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCurrentStep.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCurrentStep.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCurrentStep.FillColor2 = System.Drawing.Color.Navy;
            this.btnCurrentStep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCurrentStep.ForeColor = System.Drawing.Color.White;
            this.btnCurrentStep.Image = ((System.Drawing.Image)(resources.GetObject("btnCurrentStep.Image")));
            this.btnCurrentStep.IndicateFocus = true;
            this.btnCurrentStep.Location = new System.Drawing.Point(30, 435);
            this.btnCurrentStep.Name = "btnCurrentStep";
            this.btnCurrentStep.Size = new System.Drawing.Size(120, 39);
            this.btnCurrentStep.TabIndex = 11;
            this.btnCurrentStep.Text = "Step 1 Of 2";
            this.btnCurrentStep.UseTransparentBackground = true;
            // 
            // btnNext
            // 
            this.btnNext.Animated = true;
            this.btnNext.AutoRoundedCorners = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderColor = System.Drawing.Color.Cyan;
            this.btnNext.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnNext.BorderThickness = 1;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.Aqua;
            this.btnNext.FillColor2 = System.Drawing.Color.Blue;
            this.btnNext.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNext.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnNext.IndicateFocus = true;
            this.btnNext.Location = new System.Drawing.Point(748, 424);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 50);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseTransparentBackground = true;
            this.btnNext.Click += new System.EventHandler(this.btnApplicationInfoNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.AutoRoundedCorners = true;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderColor = System.Drawing.Color.Cyan;
            this.btnBack.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnBack.BorderThickness = 1;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.Blue;
            this.btnBack.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnBack.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.IndicateFocus = true;
            this.btnBack.Location = new System.Drawing.Point(613, 424);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(115, 50);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseTransparentBackground = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabctrlApplicationInfo
            // 
            this.tabctrlApplicationInfo.Controls.Add(this.tbPersonlalInfo);
            this.tabctrlApplicationInfo.Controls.Add(this.tpApplicationInfo);
            this.tabctrlApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tabctrlApplicationInfo.ItemSize = new System.Drawing.Size(200, 40);
            this.tabctrlApplicationInfo.Location = new System.Drawing.Point(16, 15);
            this.tabctrlApplicationInfo.Name = "tabctrlApplicationInfo";
            this.tabctrlApplicationInfo.SelectedIndex = 0;
            this.tabctrlApplicationInfo.Size = new System.Drawing.Size(851, 406);
            this.tabctrlApplicationInfo.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabctrlApplicationInfo.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(89)))), ((int)(((byte)(194)))));
            this.tabctrlApplicationInfo.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabctrlApplicationInfo.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabctrlApplicationInfo.TabButtonHoverState.InnerColor = System.Drawing.Color.Fuchsia;
            this.tabctrlApplicationInfo.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabctrlApplicationInfo.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tabctrlApplicationInfo.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabctrlApplicationInfo.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabctrlApplicationInfo.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabctrlApplicationInfo.TabButtonSelectedState.BorderColor = System.Drawing.Color.Cyan;
            this.tabctrlApplicationInfo.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabctrlApplicationInfo.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.tabctrlApplicationInfo.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabctrlApplicationInfo.TabButtonSelectedState.InnerColor = System.Drawing.Color.DodgerBlue;
            this.tabctrlApplicationInfo.TabButtonSize = new System.Drawing.Size(200, 40);
            this.tabctrlApplicationInfo.TabIndex = 7;
            this.tabctrlApplicationInfo.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tabctrlApplicationInfo.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tabctrlApplicationInfo.SelectedIndexChanged += new System.EventHandler(this.tabctrlApplicationInfo_SelectedIndexChanged);
            // 
            // tbPersonlalInfo
            // 
            this.tbPersonlalInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tbPersonlalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tbPersonlalInfo.Location = new System.Drawing.Point(4, 44);
            this.tbPersonlalInfo.Name = "tbPersonlalInfo";
            this.tbPersonlalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonlalInfo.Size = new System.Drawing.Size(843, 358);
            this.tbPersonlalInfo.TabIndex = 0;
            this.tbPersonlalInfo.Text = "Personal Info";
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCardWithFilter1.EnableAddNewButton = true;
            this.ctrlPersonCardWithFilter1.EnableFilter = true;
            this.ctrlPersonCardWithFilter1.ForeColor = System.Drawing.Color.Black;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(39, 19);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(768, 306);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            this.ctrlPersonCardWithFilter1.OnPersonSelectedByPersonID += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            this.ctrlPersonCardWithFilter1.OnPersonSelectedByNationalNo += new System.Action<string>(this.ctrlPersonCardWithFilter1_OnPersonSelectedByNationalNo);
            this.ctrlPersonCardWithFilter1.OnPersonSelectedNotFound += new System.Action(this.ctrlPersonCardWithFilter1_OnPersonSelectedNotFound);
            this.ctrlPersonCardWithFilter1.Load += new System.EventHandler(this.ctrlPersonCardWithFilter1_Load);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tpApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.tpApplicationInfo.Controls.Add(this.lblFees);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.lblLocalDrivingLicebseApplicationID);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel6);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel5);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel4);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel3);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel2);
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 204);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(843, 198);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblCreatedByUser.ForeColor = System.Drawing.Color.White;
            this.lblCreatedByUser.Location = new System.Drawing.Point(243, 263);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(39, 22);
            this.lblCreatedByUser.TabIndex = 9;
            this.lblCreatedByUser.Text = "????";
            // 
            // lblFees
            // 
            this.lblFees.BackColor = System.Drawing.Color.Transparent;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblFees.ForeColor = System.Drawing.Color.White;
            this.lblFees.Location = new System.Drawing.Point(243, 212);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(39, 22);
            this.lblFees.TabIndex = 8;
            this.lblFees.Text = "????";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.BackColor = System.Drawing.Color.Transparent;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblApplicationDate.ForeColor = System.Drawing.Color.White;
            this.lblApplicationDate.Location = new System.Drawing.Point(243, 96);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(108, 22);
            this.lblApplicationDate.TabIndex = 7;
            this.lblApplicationDate.Text = "?? / ?? / ?????";
            // 
            // lblLocalDrivingLicebseApplicationID
            // 
            this.lblLocalDrivingLicebseApplicationID.BackColor = System.Drawing.Color.Transparent;
            this.lblLocalDrivingLicebseApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblLocalDrivingLicebseApplicationID.ForeColor = System.Drawing.Color.White;
            this.lblLocalDrivingLicebseApplicationID.Location = new System.Drawing.Point(243, 48);
            this.lblLocalDrivingLicebseApplicationID.Name = "lblLocalDrivingLicebseApplicationID";
            this.lblLocalDrivingLicebseApplicationID.Size = new System.Drawing.Size(39, 22);
            this.lblLocalDrivingLicebseApplicationID.TabIndex = 6;
            this.lblLocalDrivingLicebseApplicationID.Text = "????";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(77, 263);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(86, 22);
            this.guna2HtmlLabel6.TabIndex = 5;
            this.guna2HtmlLabel6.Text = "Created By:";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(77, 212);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(125, 22);
            this.guna2HtmlLabel5.TabIndex = 4;
            this.guna2HtmlLabel5.Text = "Application Fees:";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(77, 152);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(105, 22);
            this.guna2HtmlLabel4.TabIndex = 3;
            this.guna2HtmlLabel4.Text = "License Class:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(77, 96);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(124, 22);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Application Date:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(77, 48);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(135, 22);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "D.L.Application ID:";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.BackColor = System.Drawing.Color.Transparent;
            this.cbLicenseClass.BorderColor = System.Drawing.Color.Blue;
            this.cbLicenseClass.BorderRadius = 10;
            this.cbLicenseClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbLicenseClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLicenseClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLicenseClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbLicenseClass.ForeColor = System.Drawing.Color.White;
            this.cbLicenseClass.ItemHeight = 30;
            this.cbLicenseClass.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbLicenseClass.Location = new System.Drawing.Point(243, 152);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(389, 36);
            this.cbLicenseClass.TabIndex = 0;
            this.cbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClass_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.Cyan;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.Blue;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.Blue;
            this.btnSave.FillColor2 = System.Drawing.Color.Aqua;
            this.btnSave.Font = new System.Drawing.Font("Elephant", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.IndicateFocus = true;
            this.btnSave.Location = new System.Drawing.Point(377, 563);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 51);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(24, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(35, 32);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 5;
            this.guna2ControlBox1.BorderThickness = 1;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(874, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 74;
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
            this.btnMaximaze.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.btnMaximaze.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMaximaze.IconColor = System.Drawing.Color.White;
            this.btnMaximaze.Location = new System.Drawing.Point(823, 2);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 75;
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
            this.btnMinimize.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(771, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 76;
            // 
            // frmAddUpdateLocalDrivingLicesnseApplication
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(932, 635);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddUpdateLocalDrivingLicesnseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddUpdateLocalDrivingLicesnseApplication_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.tabctrlApplicationInfo.ResumeLayout(false);
            this.tbPersonlalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

        }

        //------------------------ Local Functions ------------------------------ 

        private async Task _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses =await clsLicenseClass.GetAllLicenseClassesNamesAsync();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        private async void LoadinfoinAddNewMode()
        {
            //this will initialize the reset the defaule values
            //await _FillLicenseClassesInComoboBox();
            tpApplicationInfo.Enabled = false;

            DataTable dtLicenseClasses = await clsLicenseClass.GetAllLicenseClassesNamesAsync();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }

            lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

            ctrlPersonCardWithFilter1.Enabled = true;
            ctrlPersonCardWithFilter1.EnableFilter = true;
            ctrlPersonCardWithFilter1.EnableAddNewButton = true;
                tpApplicationInfo.Enabled = false;
                btnNext.Visible = false;
                btnBack.Visible = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text =(await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.NewInternationalLicense)).ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobalUserInfo.CurrentLogInUser.UserName;


        }

        private async void _LoadDataInUpdateMode()
        {
            await _FillLicenseClassesInComoboBox();

            lblTitle.Text = "Update Current Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                btnNext.Visible = true;
                btnBack.Visible = false;

            _LocalDrivingLicenseApplication =await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(_LocalDrivingLicenseApplicationID);
            
 

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            ctrlPersonCardWithFilter1.txtbFilter.Text = _LocalDrivingLicenseApplication.ApplicantPersonID
                .ToString();
            ctrlPersonCardWithFilter1.cbPersonFilter.SelectedIndex= 0;
            ctrlPersonCardWithFilter1.btnSearch.PerformClick();

            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = (await clsUser.FindByUserIDAsync(_LocalDrivingLicenseApplication.CreatedByUserID))?.UserName ?? "";
            btnNext.Visible = true;
            btnBack.Visible = false;
        
        }


        //------------------------ Controls events  ------------------------------ 

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            if(_Mode==enMode.AddNew)
            {
                LoadinfoinAddNewMode();

            }

            if (_Mode == enMode.Update)
            {
                _LoadDataInUpdateMode();
            }

        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {
            if(!btnBack.Visible)
                btnBack.Visible = true;
            btnNext.Visible = false;

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tabctrlApplicationInfo.SelectedTab = tabctrlApplicationInfo.TabPages[tpApplicationInfo.Name];
                btnCurrentStep.Text = "Step 2 of 2";
                return;
            }


            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonId != -1)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tabctrlApplicationInfo.SelectedTab = tabctrlApplicationInfo.TabPages[tpApplicationInfo.Name];
                btnCurrentStep.Text = "Step 2 of 2";
                return;
            }

            else

            {
                MessageBox.Show("No Person Selected! Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void _WhenDataSaved(int _LocalDrivingLicenseApplication)
        {
            MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void _WhenDataNotSaved()
        {
            MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //------------------------ person card with filter events fired ------------------------------ 
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
            this.tabctrlApplicationInfo.Enabled = true;
            btnSave.Enabled = true;

            btnNext.Visible = true;
            btnBack.Visible = false;

        }

        private  async void ctrlPersonCardWithFilter1_OnPersonSelectedByNationalNo(string obj)
        {
            _SelectedPersonID = await clsPerson.GetPersonIDAsync(obj);
            ctrlPersonCardWithFilter1_OnPersonSelected(_SelectedPersonID);
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelectedNotFound()
        {
            MessageBox.Show("Person Not Exist", "Person Not Found",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            btnNext.Visible=!btnNext.Visible;

            
            btnBack.Visible=false;

            if(tabctrlApplicationInfo.SelectedIndex== 1)
            {
                tabctrlApplicationInfo.SelectedTab = tabctrlApplicationInfo.TabPages[tbPersonlalInfo.Name];
                btnCurrentStep.Text = "Step 1 of 2";

            }
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = (int)await clsLicenseClass.GetLicenseCLassIDAsync(cbLicenseClass.Text);

            int ActiveApplicationID = await clsLocalDrivingLicenseApplication.GetActiveApplicationIDForLicenseClassAsync(_SelectedPersonID, clsApplicationType.enApplicationType.NewLocalDrivingLicenseService, LicenseClassID);

            if (!await clsLocalDrivingLicenseApplication.IsHasMinimumAgeForLicenseClassAsync(_SelectedPersonID, (clsLicenseClass.enLicenseClasses)LicenseClassID))
            {
                MessageBox.Show("Person has no mimimaum age require for this class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }


            //check if user already have issued license of the same driving  class.
            if (await clsLicense.IsLicenseExistAsync(ctrlPersonCardWithFilter1.PersonId, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonId; ;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobalUserInfo.CurrentLogInUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (await _LocalDrivingLicenseApplication.SaveLocalDrivingAppAsync())
            {
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                _WhenDataSaved(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            }
            else
            {
                _WhenDataNotSaved();
            }
        }

        private void tabctrlApplicationInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabctrlApplicationInfo.SelectedIndex==0)
            {
                btnBack.Visible=false;
                btnNext.Visible=true;
                btnCurrentStep.Text = "Step 1 of 2";
            }
            else
            {
                btnBack.Visible = true;
                btnNext.Visible = false;
                btnCurrentStep.Text = "Step 2 of 2";

            }


        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
