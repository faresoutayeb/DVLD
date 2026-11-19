namespace DVLD_Presentation_Layer.Person.PersonControles
{
    partial class ctrlFilterPersonInformation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilterBy = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbPersonFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddNewPerson = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSearch = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtbFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrPersonInfoCard = new DVLD_Presentation_Layer.ctrlPersonInfo();
            this.gbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilterBy
            // 
            this.gbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.gbFilterBy.BorderColor = System.Drawing.Color.Blue;
            this.gbFilterBy.BorderRadius = 10;
            this.gbFilterBy.Controls.Add(this.cbPersonFilter);
            this.gbFilterBy.Controls.Add(this.btnAddNewPerson);
            this.gbFilterBy.Controls.Add(this.btnSearch);
            this.gbFilterBy.Controls.Add(this.txtbFilter);
            this.gbFilterBy.CustomBorderColor = System.Drawing.Color.Blue;
            this.gbFilterBy.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.gbFilterBy.FillColor = System.Drawing.Color.Transparent;
            this.gbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbFilterBy.ForeColor = System.Drawing.Color.White;
            this.gbFilterBy.Location = new System.Drawing.Point(3, 3);
            this.gbFilterBy.Name = "gbFilterBy";
            this.gbFilterBy.Size = new System.Drawing.Size(652, 47);
            this.gbFilterBy.TabIndex = 12;
            // 
            // cbPersonFilter
            // 
            this.cbPersonFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbPersonFilter.BorderColor = System.Drawing.Color.Blue;
            this.cbPersonFilter.BorderRadius = 10;
            this.cbPersonFilter.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.cbPersonFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbPersonFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPersonFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbPersonFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPersonFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPersonFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPersonFilter.ForeColor = System.Drawing.Color.White;
            this.cbPersonFilter.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.cbPersonFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbPersonFilter.HoverState.ForeColor = System.Drawing.Color.White;
            this.cbPersonFilter.ItemHeight = 30;
            this.cbPersonFilter.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.cbPersonFilter.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbPersonFilter.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbPersonFilter.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbPersonFilter.Location = new System.Drawing.Point(8, 6);
            this.cbPersonFilter.Name = "cbPersonFilter";
            this.cbPersonFilter.ShadowDecoration.BorderRadius = 15;
            this.cbPersonFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbPersonFilter.ShadowDecoration.Depth = 45;
            this.cbPersonFilter.ShadowDecoration.Enabled = true;
            this.cbPersonFilter.Size = new System.Drawing.Size(165, 36);
            this.cbPersonFilter.StartIndex = 0;
            this.cbPersonFilter.TabIndex = 60;
            this.cbPersonFilter.SelectedIndexChanged += new System.EventHandler(this.cbPersonFilter_SelectedIndexChanged);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Animated = true;
            this.btnAddNewPerson.AutoRoundedCorners = true;
            this.btnAddNewPerson.BorderColor = System.Drawing.Color.Cyan;
            this.btnAddNewPerson.BorderRadius = 16;
            this.btnAddNewPerson.BorderThickness = 1;
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPerson.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.btnAddNewPerson.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddNewPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddNewPerson.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddNewPerson.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPerson.FillColor = System.Drawing.Color.Blue;
            this.btnAddNewPerson.FillColor2 = System.Drawing.Color.Aqua;
            this.btnAddNewPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPerson.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnAddNewPerson.Image = global::DVLD_Presentation_Layer.Properties.Resources.add__1_;
            this.btnAddNewPerson.IndicateFocus = true;
            this.btnAddNewPerson.Location = new System.Drawing.Point(518, 4);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(121, 35);
            this.btnAddNewPerson.TabIndex = 14;
            this.btnAddNewPerson.Text = "Add New";
            this.btnAddNewPerson.UseTransparentBackground = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.pbAddNewPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Animated = true;
            this.btnSearch.AutoRoundedCorners = true;
            this.btnSearch.BorderColor = System.Drawing.Color.Cyan;
            this.btnSearch.BorderRadius = 16;
            this.btnSearch.BorderThickness = 1;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FillColor = System.Drawing.Color.Blue;
            this.btnSearch.FillColor2 = System.Drawing.Color.Aqua;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSearch.IndicateFocus = true;
            this.btnSearch.Location = new System.Drawing.Point(408, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 34);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseTransparentBackground = true;
            this.btnSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // txtbFilter
            // 
            this.txtbFilter.Animated = true;
            this.txtbFilter.BorderColor = System.Drawing.Color.Blue;
            this.txtbFilter.BorderRadius = 10;
            this.txtbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbFilter.DefaultText = "";
            this.txtbFilter.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.txtbFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtbFilter.DisabledState.ForeColor = System.Drawing.Color.White;
            this.txtbFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbFilter.ForeColor = System.Drawing.Color.White;
            this.txtbFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbFilter.Location = new System.Drawing.Point(179, 5);
            this.txtbFilter.Name = "txtbFilter";
            this.txtbFilter.PlaceholderText = "Type here ....";
            this.txtbFilter.SelectedText = "";
            this.txtbFilter.Size = new System.Drawing.Size(223, 36);
            this.txtbFilter.TabIndex = 11;
            this.txtbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilter_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrPersonInfoCard
            // 
            this.ctrPersonInfoCard.BackColor = System.Drawing.Color.Transparent;
            this.ctrPersonInfoCard.Location = new System.Drawing.Point(0, 56);
            this.ctrPersonInfoCard.Name = "ctrPersonInfoCard";
            this.ctrPersonInfoCard.Size = new System.Drawing.Size(658, 203);
            this.ctrPersonInfoCard.TabIndex = 1;
            this.ctrPersonInfoCard.OnNoPersonFound += new System.Action(this.ctrlCurrentPersonInfoControl_OnNoPersonFound);
            this.ctrPersonInfoCard.OnPersonFound += new System.Action(this.ctrlCurrentPersonInfoControl_OnPersonFound);
            // 
            // ctrlFilterPersonInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gbFilterBy);
            this.Controls.Add(this.ctrPersonInfoCard);
            this.Name = "ctrlFilterPersonInformation";
            this.Size = new System.Drawing.Size(658, 257);
            this.Load += new System.EventHandler(this.ctrlFilterPersonInformation_Load);
            this.gbFilterBy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ctrlPersonInfo ctrPersonInfoCard;
        public Guna.UI2.WinForms.Guna2GroupBox gbFilterBy;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddNewPerson;
        public Guna.UI2.WinForms.Guna2TextBox txtbFilter;
        public Guna.UI2.WinForms.Guna2GradientButton btnSearch;
        public Guna.UI2.WinForms.Guna2ComboBox cbPersonFilter;
    }
}
