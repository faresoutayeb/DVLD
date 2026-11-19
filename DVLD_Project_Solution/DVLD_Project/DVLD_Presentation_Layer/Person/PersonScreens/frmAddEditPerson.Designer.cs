

namespace DVLD_Presentation_Layer
{
    partial class frmAddEditPerson
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPersonID;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pbAddEditScreen = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ctrlEditPersonInfo1 = new DVLD_Presentation_Layer.Person.PersonControles.ctrlEditPersonInfo();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddEditScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.BackColor = System.Drawing.Color.Transparent;
            this.lblPersonID.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPersonID.ForeColor = System.Drawing.Color.White;
            this.lblPersonID.Location = new System.Drawing.Point(123, 79);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(50, 25);
            this.lblPersonID.TabIndex = 2;
            this.lblPersonID.Text = "[???]";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(22, 79);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(95, 27);
            this.guna2HtmlLabel1.TabIndex = 6;
            this.guna2HtmlLabel1.Text = "Person ID:";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationInterval = 0;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(74, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(289, 31);
            this.lblTitle.TabIndex = 74;
            this.lblTitle.Text = "Update Person Information";
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblUserMessage.Location = new System.Drawing.Point(91, 40);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(296, 22);
            this.lblUserMessage.TabIndex = 76;
            this.lblUserMessage.Text = "Show, add, edit, manage person info";
            // 
            // pbAddEditScreen
            // 
            this.pbAddEditScreen.Image = global::DVLD_Presentation_Layer.Properties.Resources.search_survey;
            this.pbAddEditScreen.ImageRotate = 0F;
            this.pbAddEditScreen.Location = new System.Drawing.Point(10, 12);
            this.pbAddEditScreen.Name = "pbAddEditScreen";
            this.pbAddEditScreen.Size = new System.Drawing.Size(58, 41);
            this.pbAddEditScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddEditScreen.TabIndex = 75;
            this.pbAddEditScreen.TabStop = false;
            // 
            // ctrlEditPersonInfo1
            // 
            this.ctrlEditPersonInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlEditPersonInfo1.Location = new System.Drawing.Point(22, 135);
            this.ctrlEditPersonInfo1.Name = "ctrlEditPersonInfo1";
            this.ctrlEditPersonInfo1.PersonID = -1;
            this.ctrlEditPersonInfo1.Size = new System.Drawing.Size(848, 499);
            this.ctrlEditPersonInfo1.TabIndex = 8;
            this.ctrlEditPersonInfo1.DataBack += new DVLD_Presentation_Layer.Person.PersonControles.ctrlEditPersonInfo.DataBackEventHandler(this.ctrlEditPersonInfo1_DataBack_1);
            this.ctrlEditPersonInfo1.OnNoPersonFound += new System.Action(this.ctrlEditPersonInfo1_OnNoPersonFound_1);
            this.ctrlEditPersonInfo1.OnPersonUpdated += new System.Action<int>(this.ctrlEditPersonInfo1_OnPersonUpdated);
            this.ctrlEditPersonInfo1.OnPersonNotUpdated += new System.Action(this.ctrlEditPersonInfo1_OnPersonUpdated_1);
            this.ctrlEditPersonInfo1.OnNewPersonAdded += new System.Action<int>(this.ctrlEditPersonInfo1_OnNewPersonAdded);
            this.ctrlEditPersonInfo1.OnNewPersonNotAdded += new System.Action(this.ctrlEditPersonInfo1_OnNewPersonNotAdded);
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(859, 2);
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
            this.btnMinimize.Location = new System.Drawing.Point(756, 2);
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
            this.btnMaximaze.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMaximaze.IconColor = System.Drawing.Color.White;
            this.btnMaximaze.Location = new System.Drawing.Point(808, 2);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 78;
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(908, 637);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.pbAddEditScreen);
            this.Controls.Add(this.ctrlEditPersonInfo1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lblPersonID);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Person Information";
            this.Load += new System.EventHandler(this.frmAddEditPerson_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Add_EditPersonScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddEditScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
      // private DVLD_Presentation_Layer.Person.PersonControles.ctrlEditPersonInfo ctrlEditPersonInfo1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Person.PersonControles.ctrlEditPersonInfo ctrlEditPersonInfo1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserMessage;
        private Guna.UI2.WinForms.Guna2PictureBox pbAddEditScreen;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
    }
}


