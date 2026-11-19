
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls
{
    public partial class ctrlDataGridPagesMoving : UserControl
    {
        public ctrlDataGridPagesMoving()
        {
            InitializeComponent();
        }

        //--------------------------- local variables -----------------------------

        public short ItemsPerPage { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;

        private DataView _FullView { get; set; }

        private Guna2GradientButton _CurrentClickedButton { get; set; }

        //----------------------------- Local events ----------------------

        public event Action OnButtonClicked;

        protected void ButtonClicked()
        {
            OnButtonClicked?.Invoke();
        }

        //-------------------------- Local functions -------------------------

        public DataTable RefreshCurrentTablePage(DataView FullView)
        {
            DataTable TempTable = FullView.Table.Clone();

            int From = GetFrom();
            int To = Math.Min(From + ItemsPerPage, FullView.Count);

            for (int i = From; i < To; i++)
            {
                TempTable.ImportRow(FullView[i].Row);
            }

            return TempTable;
        }

        private int GetFrom()
        {
            return (CurrentPage - 1) * ItemsPerPage;
        }

        private int GetTotalPages()
        {
            if (_FullView == null || ItemsPerPage <= 0)
                return 0;

            return (int)Math.Ceiling(
                (double)_FullView.Count / ItemsPerPage);
        }

        private void RefreshCurrentPageLableInfo()
        {
            int From = GetFrom();
            int To = Math.Min(From + ItemsPerPage, _FullView.Count);

            if (_FullView.Count == 0)
            {
                lblCurrentPageInfo.Text = "0 - 0 of 0 Items";
                return;
            }

            lblCurrentPageInfo.Text =
                $"{From + 1} - {To} of {_FullView.Count} Items";
        }

        private void RefreshPageButtons()
        {
            int TotalPages = GetTotalPages();

            btnFirst.Text = CurrentPage.ToString();
            btnSecond.Text = (CurrentPage + 1).ToString();

            btnSecond.Enabled = CurrentPage < TotalPages;

            btnFirstPage.Enabled = CurrentPage > 1;
            btnBack.Enabled = CurrentPage > 1;

            btnNext.Enabled = CurrentPage < TotalPages;
            btnLastPage.Enabled = CurrentPage < TotalPages;
        }

        //-------------------------- Controls events --------------------------

        public DataTable GetUpdateTable(DataView FullView)
        {
            _FullView = FullView;

            if (FullView == null || ItemsPerPage <= 0)
                return new DataTable();

            int TotalPages = GetTotalPages();

            if (TotalPages == 0)
            {
                CurrentPage = 1;
                RefreshCurrentPageLableInfo();
                RefreshPageButtons();

                return FullView.Table.Clone();
            }

            switch (_CurrentClickedButton?.Name)
            {
                case "btnFirst":
                    if (int.TryParse(btnFirst.Text, out int FirstPage))
                        CurrentPage = FirstPage;
                    break;

                case "btnSecond":
                    if (int.TryParse(btnSecond.Text, out int SecondPage))
                        CurrentPage = SecondPage;
                    break;

                case "btnNext":
                    CurrentPage++;
                    break;

                case "btnBack":
                    CurrentPage--;
                    break;

                case "btnFirstPage":
                    CurrentPage = 1;
                    break;

                case "btnLastPage":
                    CurrentPage = TotalPages;
                    break;
            }

            CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages));

            DataTable CurrentTable = RefreshCurrentTablePage(FullView);

            RefreshCurrentPageLableInfo();
            RefreshPageButtons();

            return CurrentTable;
        }

        //--------------------------- Button click events -------------------------

        private void PageNextButton_Click(object sender, EventArgs e)
        {
            _CurrentClickedButton = (Guna2GradientButton)sender;
            ButtonClicked();
        }

        private void PagePreviousButton_Click(object sender, EventArgs e)
        {
            _CurrentClickedButton = (Guna2GradientButton)sender;
            ButtonClicked();
        }

        private void SecondButton_Click(object sender, EventArgs e)
        {
            _CurrentClickedButton = (Guna2GradientButton)sender;
            ButtonClicked();
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            _CurrentClickedButton = (Guna2GradientButton)sender;
            ButtonClicked();
        }

        private void GoToFirstPageButton_Click(object sender, EventArgs e)
        {
            _CurrentClickedButton = (Guna2GradientButton)sender;
            ButtonClicked();
        }

        private void GoToLastPageButton_Click(object sender, EventArgs e)
        {
            _CurrentClickedButton = (Guna2GradientButton)sender;
            ButtonClicked();
        }

        //------------------------------------------------------------------

        private void cbItemsPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (short.TryParse(cbItemsPerPage.Text, out short ParsedValue))
            {
                ItemsPerPage = ParsedValue;
            }

            CurrentPage = 1;

            btnFirst.PerformClick();
        }

        private void ctrlDataGridPagesMoving_Load(object sender, EventArgs e)
        {
            CurrentPage = 1;

            if (short.TryParse(cbItemsPerPage.Text, out short ParsedValue))
            {
                ItemsPerPage = ParsedValue;
            }
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            PageNextButton_Click(sender, e);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            PageNextButton_Click(sender, e);
        }
    }
}
