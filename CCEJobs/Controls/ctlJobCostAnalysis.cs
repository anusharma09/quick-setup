using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;

namespace CCEJobs.Controls
{
    public partial class ctlJobCostAnalysis : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable costAnalysisTable = new DataTable();
        private string jobID;
        private string filter;
        private bool isFourDigit = false;
        //
        public enum CostAnalysisView
        {
            List,
            App,
            Phase,
            Code,
            Name,
            Date 
        }
        //
        public enum ReportTypeView
        {
            Detail,
            Summary
        }
        //
        public ctlJobCostAnalysis()
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
                    GetJobCostAnalysis();
                }
            }
        }
        //
        public bool IsFourDigit
        {
            set
            {
                isFourDigit = value;
            }
        }
        //
        public string Filter
        {
            get { return filter; }
        }
        public ReportTypeView ReportType
        {
            get { return(ReportTypeView)radioType.SelectedIndex; }
        }
        //
        public DataTable CostAnalysisTable
        {
            get { return costAnalysisTable; }
        }
        //
        public CostAnalysisView CostView
        {
            get { return (CostAnalysisView)radioGroup.SelectedIndex; }
        }
        //
        private void GetJobCostAnalysis()
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
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobCostAnalysisView, "ctlJobCostAnalysis");
                }




                if (isFourDigit)
                    costAnalysisTable = JobCost.GetCostAnalysisFourDigit(jobID).Tables[0];
                else
                    costAnalysisTable = JobCost.GetCostAnalysis(jobID).Tables[0];
                grdJobCostAnalysis.DataSource = costAnalysisTable;
                grdJobCostAnalysisView.BestFitColumns();
                grdJobCostAnalysisView.Columns["Trans Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobCostAnalysisView.Columns["Trans Amt"].DisplayFormat.FormatString = "{0:c2}";
                grdJobCostAnalysisView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Trans Amt", grdJobCostAnalysisView.Columns["Trans Amt"], "{0:c2}");
                grdJobCostAnalysisView.Columns["Trans Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobCostAnalysisView.Columns["Trans Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                
                grdJobCostAnalysisView.Columns["Burden"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobCostAnalysisView.Columns["Burden"].DisplayFormat.FormatString = "{0:c2}";
                grdJobCostAnalysisView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Burden", grdJobCostAnalysisView.Columns["Burden"], "{0:c2}");
                grdJobCostAnalysisView.Columns["Burden"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobCostAnalysisView.Columns["Burden"].SummaryItem.DisplayFormat = "{0:c2}";
                grdJobCostAnalysisView.Columns["JobNumber"].Visible = false;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobCostAnalysisView, "ctlJobCostAnalysis");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void GroupCostAnalysis(CostAnalysisView group)
        {
            if (grdJobCostAnalysisView.Columns["App"].GroupIndex > -1)
                grdJobCostAnalysisView.Columns["App"].UnGroup();

            if (grdJobCostAnalysisView.Columns["Phase"].GroupIndex > -1)
                grdJobCostAnalysisView.Columns["Phase"].UnGroup();
            if (grdJobCostAnalysisView.Columns["Code"].GroupIndex > -1)
                grdJobCostAnalysisView.Columns["Code"].UnGroup();
            if (grdJobCostAnalysisView.Columns["Name"].GroupIndex > -1)
                grdJobCostAnalysisView.Columns["Name"].UnGroup();
            if (grdJobCostAnalysisView.Columns["Trans Date"].GroupIndex > -1)
                grdJobCostAnalysisView.Columns["Trans Date"].UnGroup();
            switch (group)
            {
                case CostAnalysisView.App:
                    grdJobCostAnalysisView.Columns["App"].Group();
                    break;

                case CostAnalysisView.Code:
                    grdJobCostAnalysisView.Columns["Code"].Group();
                    break;
                case CostAnalysisView.Phase:
                    grdJobCostAnalysisView.Columns["Phase"].Group();
                    break;
                case CostAnalysisView.Name:
                    grdJobCostAnalysisView.Columns["Name"].Group();
                    break;
                case CostAnalysisView.Date:
                    grdJobCostAnalysisView.Columns["Trans Date"].Group();
                    break;
            } 
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupCostAnalysis((CostAnalysisView)radioGroup.SelectedIndex);
        }

        private void grdLaborAnalysisView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                
                costAnalysisTable.DefaultView.RowFilter = grdJobCostAnalysisView.FilterPanelText.ToString().Replace("$","").Replace(",","").Replace("(","-").Replace(")","");
                filter = grdJobCostAnalysisView.FilterPanelText.ToString().Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "");
            }
            catch (Exception ex)
            {
            }
        }

        private void grdJobCostAnalysisView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
  
    }
}
