using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace CCEJobs.Controls
{
    public partial class ctlJobInvoicesNoPO : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataSet jobInvoiceDetailDataSet = new DataSet();
        private string jobID;
        private string filter = "";
        //

        public ctlJobInvoicesNoPO()
        {
            InitializeComponent();
        }
        //
        public string JobID
        {
            set
            {
                if (jobID != value)
                {
                    jobID = value;
                    GetJobInvoiceDetail();
                }
            }
        }
        //
        public string Filter
        {
            get { return filter; }
        }
        //
        public DataSet JobInvoiceDetailDataSet
        {
            get { return jobInvoiceDetailDataSet; }
        }
        //
        private void GetJobInvoiceDetail()
        {
            string id;
            if (jobID == "" )   
                id = "0";
            else
                id = jobID;
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdInvoicesNoPOView, "ctlJobInvoiceNoPO");
                }
                jobInvoiceDetailDataSet = JobCost.GetJobAPInvoiceDetail(jobID);
                grdInvoicesNoPO.DataSource = jobInvoiceDetailDataSet.Tables[0];
                grdInvoicesNoPOView.BestFitColumns();
                grdInvoicesNoPOView.Columns["Gross Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdInvoicesNoPOView.Columns["Gross Amt"].DisplayFormat.FormatString = "{0:c2}";
                grdInvoicesNoPOView.Columns["Gross Pay Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdInvoicesNoPOView.Columns["Gross Pay Amt"].DisplayFormat.FormatString = "{0:c2}";
                grdInvoicesNoPOView.Columns["Payment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdInvoicesNoPOView.Columns["Payment"].DisplayFormat.FormatString = "{0:c2}";
                grdInvoicesNoPOView.Columns["Variance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdInvoicesNoPOView.Columns["Variance"].DisplayFormat.FormatString = "{0:c2}";

                grdInvoicesNoPOView.Columns["Gross Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdInvoicesNoPOView.Columns["Gross Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                grdInvoicesNoPOView.Columns["Gross Pay Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdInvoicesNoPOView.Columns["Gross Pay Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                grdInvoicesNoPOView.Columns["Payment"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdInvoicesNoPOView.Columns["Payment"].SummaryItem.DisplayFormat = "{0:c2}";
                grdInvoicesNoPOView.Columns["Variance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdInvoicesNoPOView.Columns["Variance"].SummaryItem.DisplayFormat = "{0:c2}";
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdInvoicesNoPOView, "ctlJobInvoiceNoPO");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdBillSummaryView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                jobInvoiceDetailDataSet.Tables[0].DefaultView.RowFilter = grdInvoicesNoPOView.FilterPanelText.Replace("$","").Replace(",","").Replace("(","-").Replace(")","");
                filter = grdInvoicesNoPOView.FilterPanelText.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "");
            }
            catch (Exception ex)
            {
            }
        }
        //
        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetJobInvoiceDetail();
        }

        private void grdInvoicesNoPOView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
