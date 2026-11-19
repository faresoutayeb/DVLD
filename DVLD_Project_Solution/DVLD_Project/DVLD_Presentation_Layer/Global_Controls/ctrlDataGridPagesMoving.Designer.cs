namespace DVLD_Presentation_Layer.Global_Controls
{
    partial class ctrlDataGridPagesMoving
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
            this.lblCurrentPageInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbItemsPerPage = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLastPage = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnFirstPage = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSecond = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnFirst = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // lblCurrentPageInfo
            // 
            this.lblCurrentPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblCurrentPageInfo.ForeColor = System.Drawing.Color.White;
            this.lblCurrentPageInfo.Location = new System.Drawing.Point(467, 12);
            this.lblCurrentPageInfo.Name = "lblCurrentPageInfo";
            this.lblCurrentPageInfo.Size = new System.Drawing.Size(3, 2);
            this.lblCurrentPageInfo.TabIndex = 77;
            this.lblCurrentPageInfo.Text = null;
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(303, 12);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(73, 15);
            this.guna2HtmlLabel9.TabIndex = 76;
            this.guna2HtmlLabel9.Text = "Items per page";
            // 
            // cbItemsPerPage
            // 
            this.cbItemsPerPage.BackColor = System.Drawing.Color.Transparent;
            this.cbItemsPerPage.BorderColor = System.Drawing.Color.Blue;
            this.cbItemsPerPage.BorderRadius = 10;
            this.cbItemsPerPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItemsPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemsPerPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbItemsPerPage.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbItemsPerPage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbItemsPerPage.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbItemsPerPage.ForeColor = System.Drawing.Color.White;
            this.cbItemsPerPage.ItemHeight = 30;
            this.cbItemsPerPage.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "100"});
            this.cbItemsPerPage.Location = new System.Drawing.Point(382, 3);
            this.cbItemsPerPage.Name = "cbItemsPerPage";
            this.cbItemsPerPage.Size = new System.Drawing.Size(76, 36);
            this.cbItemsPerPage.StartIndex = 0;
            this.cbItemsPerPage.TabIndex = 75;
            this.cbItemsPerPage.SelectedIndexChanged += new System.EventHandler(this.cbItemsPage_SelectedIndexChanged);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Animated = true;
            this.btnLastPage.BackColor = System.Drawing.Color.Transparent;
            this.btnLastPage.BorderColor = System.Drawing.Color.Cyan;
            this.btnLastPage.BorderRadius = 10;
            this.btnLastPage.BorderThickness = 1;
            this.btnLastPage.DisabledState.BorderColor = System.Drawing.Color.Cyan;
            this.btnLastPage.DisabledState.CustomBorderColor = System.Drawing.Color.Cyan;
            this.btnLastPage.DisabledState.FillColor = System.Drawing.Color.Blue;
            this.btnLastPage.DisabledState.FillColor2 = System.Drawing.Color.Blue;
            this.btnLastPage.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnLastPage.FillColor = System.Drawing.Color.Blue;
            this.btnLastPage.FillColor2 = System.Drawing.Color.Aqua;
            this.btnLastPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLastPage.ForeColor = System.Drawing.Color.White;
            this.btnLastPage.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnLastPage.IndicateFocus = true;
            this.btnLastPage.Location = new System.Drawing.Point(253, 3);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(44, 31);
            this.btnLastPage.TabIndex = 74;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.UseTransparentBackground = true;
            this.btnLastPage.Click += new System.EventHandler(this.GoToLastPageButton_Click);
            // 
            // btnNext
            // 
            this.btnNext.Animated = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderColor = System.Drawing.Color.Cyan;
            this.btnNext.BorderRadius = 10;
            this.btnNext.BorderThickness = 1;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.Cyan;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.Cyan;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.Blue;
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.Blue;
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnNext.FillColor = System.Drawing.Color.Blue;
            this.btnNext.FillColor2 = System.Drawing.Color.Aqua;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnNext.IndicateFocus = true;
            this.btnNext.Location = new System.Drawing.Point(203, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(44, 31);
            this.btnNext.TabIndex = 73;
            this.btnNext.Text = ">";
            this.btnNext.UseTransparentBackground = true;
            this.btnNext.Click += new System.EventHandler(this.PageNextButton_Click);
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderColor = System.Drawing.Color.Cyan;
            this.btnBack.BorderRadius = 10;
            this.btnBack.BorderThickness = 1;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.Cyan;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.Cyan;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.Blue;
            this.btnBack.DisabledState.FillColor2 = System.Drawing.Color.Blue;
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnBack.FillColor = System.Drawing.Color.Blue;
            this.btnBack.FillColor2 = System.Drawing.Color.Aqua;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.IndicateFocus = true;
            this.btnBack.Location = new System.Drawing.Point(53, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(44, 31);
            this.btnBack.TabIndex = 70;
            this.btnBack.Text = "<";
            this.btnBack.UseTransparentBackground = true;
            this.btnBack.Click += new System.EventHandler(this.PagePreviousButton_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Animated = true;
            this.btnFirstPage.BackColor = System.Drawing.Color.Transparent;
            this.btnFirstPage.BorderColor = System.Drawing.Color.Cyan;
            this.btnFirstPage.BorderRadius = 10;
            this.btnFirstPage.BorderThickness = 1;
            this.btnFirstPage.DisabledState.BorderColor = System.Drawing.Color.Cyan;
            this.btnFirstPage.DisabledState.CustomBorderColor = System.Drawing.Color.Cyan;
            this.btnFirstPage.DisabledState.FillColor = System.Drawing.Color.Blue;
            this.btnFirstPage.DisabledState.FillColor2 = System.Drawing.Color.Blue;
            this.btnFirstPage.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnFirstPage.FillColor = System.Drawing.Color.Blue;
            this.btnFirstPage.FillColor2 = System.Drawing.Color.Aqua;
            this.btnFirstPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFirstPage.ForeColor = System.Drawing.Color.White;
            this.btnFirstPage.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnFirstPage.IndicateFocus = true;
            this.btnFirstPage.Location = new System.Drawing.Point(3, 3);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(44, 31);
            this.btnFirstPage.TabIndex = 69;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseTransparentBackground = true;
            this.btnFirstPage.Click += new System.EventHandler(this.GoToFirstPageButton_Click);
            // 
            // btnSecond
            // 
            this.btnSecond.Animated = true;
            this.btnSecond.BackColor = System.Drawing.Color.Transparent;
            this.btnSecond.BorderColor = System.Drawing.Color.Cyan;
            this.btnSecond.BorderRadius = 10;
            this.btnSecond.BorderThickness = 1;
            this.btnSecond.DisabledState.BorderColor = System.Drawing.Color.Cyan;
            this.btnSecond.DisabledState.CustomBorderColor = System.Drawing.Color.Cyan;
            this.btnSecond.DisabledState.FillColor = System.Drawing.Color.Blue;
            this.btnSecond.DisabledState.FillColor2 = System.Drawing.Color.Blue;
            this.btnSecond.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnSecond.FillColor = System.Drawing.Color.Blue;
            this.btnSecond.FillColor2 = System.Drawing.Color.Aqua;
            this.btnSecond.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSecond.ForeColor = System.Drawing.Color.White;
            this.btnSecond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSecond.IndicateFocus = true;
            this.btnSecond.Location = new System.Drawing.Point(153, 3);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(44, 31);
            this.btnSecond.TabIndex = 79;
            this.btnSecond.Text = "2";
            this.btnSecond.UseTransparentBackground = true;
            this.btnSecond.Click += new System.EventHandler(this.btnSecond_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Animated = true;
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.BorderColor = System.Drawing.Color.Cyan;
            this.btnFirst.BorderRadius = 10;
            this.btnFirst.BorderThickness = 1;
            this.btnFirst.DisabledState.BorderColor = System.Drawing.Color.Cyan;
            this.btnFirst.DisabledState.CustomBorderColor = System.Drawing.Color.Cyan;
            this.btnFirst.DisabledState.FillColor = System.Drawing.Color.Blue;
            this.btnFirst.DisabledState.FillColor2 = System.Drawing.Color.Blue;
            this.btnFirst.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnFirst.FillColor = System.Drawing.Color.Blue;
            this.btnFirst.FillColor2 = System.Drawing.Color.Aqua;
            this.btnFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnFirst.IndicateFocus = true;
            this.btnFirst.Location = new System.Drawing.Point(103, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(44, 31);
            this.btnFirst.TabIndex = 78;
            this.btnFirst.Text = "1";
            this.btnFirst.UseTransparentBackground = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // ctrlDataGridPagesMoving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnSecond);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblCurrentPageInfo);
            this.Controls.Add(this.guna2HtmlLabel9);
            this.Controls.Add(this.cbItemsPerPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnFirstPage);
            this.Name = "ctrlDataGridPagesMoving";
            this.Size = new System.Drawing.Size(671, 43);
            this.Load += new System.EventHandler(this.ctrlDataGridPagesMoving_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCurrentPageInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2ComboBox cbItemsPerPage;
        public Guna.UI2.WinForms.Guna2GradientButton btnLastPage;
        public Guna.UI2.WinForms.Guna2GradientButton btnNext;
        public Guna.UI2.WinForms.Guna2GradientButton btnBack;
        public Guna.UI2.WinForms.Guna2GradientButton btnFirstPage;
        public Guna.UI2.WinForms.Guna2GradientButton btnSecond;
        public Guna.UI2.WinForms.Guna2GradientButton btnFirst;
    }
}
