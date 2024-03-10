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
    public partial class ctlJobSubcontractsInvoices : UserControl
    {
        DataSet jobInvoiceDetailDataSet = new DataSet();
        private string jobID;
        private string filter = "";
        protected bool bColumnWidthChanged = false;
        //

        public ctlJobSubcontractsInvoices()
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
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSubcontractsInvoicesView, "ctlJobSubcontractsInvoices");
                }

                jobInvoiceDetailDataSet = JobCost.GetJobAPSubcontractsInvoices(jobID);
                grdSubcontractsInvoices.DataSource = jobInvoiceDetailDataSet.Tables[0];
                grdSubcontractsInvoicesView.BestFitColumns();
                grdSubcontractsInvoicesView.Columns["Gross Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSubcontractsInvoicesView.Columns["Gross Amt"].DisplayFormat.FormatString = "{0:c2}";
                grdSubcontractsInvoicesView.Columns["Gross Pay Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSubcontractsInvoicesView.Columns["Gross Pay Amt"].DisplayFormat.FormatString = "{0:c2}";
                grdSubcontractsInvoicesView.Columns["Payment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSubcontractsInvoicesView.Columns["Payment"].DisplayFormat.FormatString = "{0:c2}";
                grdSubcontractsInvoicesView.Columns["Variance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSubcontractsInvoicesView.Columns["Variance"].DisplayFormat.FormatString = "{0:c2}";

                grdSubcontractsInvoicesView.Columns["Gross Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSubcontractsInvoicesView.Columns["Gross Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                grdSubcontractsInvoicesView.Columns["Gross Pay Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSubcontractsInvoicesView.Columns["Gross Pay Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                grdSubcontractsInvoicesView.Columns["Payment"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSubcontractsInvoicesView.Columns["Payment"].SummaryItem.DisplayFormat = "{0:c2}";
                grdSubcontractsInvoicesView.Columns["Variance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSubcontractsInvoicesView.Columns["Variance"].SummaryItem.DisplayFormat = "{0:c2}";
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSubcontractsInvoicesView, "ctlJobSubcontractsInvoices");

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
                jobInvoiceDetailDataSet.Tables[0].DefaultView.RowFilter = grdSubcontractsInvoicesView.FilterPanelText.Replace("$","").Replace(",","").Replace("(","-").Replace(")","");
                filter = grdSubcontractsInvoicesView.FilterPanelText.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "");
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

        private void grdSubcontractsInvoicesView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
