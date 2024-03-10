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
    public partial class ctlLaborAnalysis : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable laborAnalysisTable = new DataTable();
        private string filter = "";
        private string jobID;
        private bool isFourDigit = false;
        //
        public enum LaborAnalysisView
        {
            List,
            Phase,
            Code,
            Employee,
            Week, 
            HoursType,
            Craft
        }
        //
        public enum ReportTypeView
        {
            Detail,
            Summary
        }
        //
        public ctlLaborAnalysis()
        {
            InitializeComponent();
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
        public string JobID
        {
            set
            {
                if (jobID != value)
                {
                    jobID = value;
                    GetLaborAnalysis();
                }
            }
        }
        public string Filter
        {
            get { return filter; }
        }
        public ReportTypeView ReportType
        {
            get { return(ReportTypeView)radioType.SelectedIndex; }
        }
        //
        public DataTable LaborAnalysisTable
        {
            get { return laborAnalysisTable; }
        }
        //
        public LaborAnalysisView LaborView
        {
            get { return (LaborAnalysisView)radioGroup.SelectedIndex; }
        }
        //
        private void GetLaborAnalysis()
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
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLaborAnalysisView, "ctlLaborAnalysis");
                }

                if (isFourDigit)
                    laborAnalysisTable = JobCost.GetLaborAnalysisFourDigit(jobID).Tables[0];
                else
                    laborAnalysisTable = JobCost.GetLaborAnalysis(jobID).Tables[0];
                grdLaborAnalysis.DataSource = laborAnalysisTable;
                grdLaborAnalysisView.BestFitColumns();
                grdLaborAnalysisView.Columns["Hours"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Hours"].DisplayFormat.FormatString = "{0:n2}";
                grdLaborAnalysisView.Columns["Day1"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Day1"].DisplayFormat.FormatString = "{0:n2}";
                grdLaborAnalysisView.Columns["Day2"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Day2"].DisplayFormat.FormatString = "{0:n2}";
                grdLaborAnalysisView.Columns["Day3"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Day3"].DisplayFormat.FormatString = "{0:n2}";
                grdLaborAnalysisView.Columns["Day4"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Day4"].DisplayFormat.FormatString = "{0:n2}";
                grdLaborAnalysisView.Columns["Day5"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Day5"].DisplayFormat.FormatString = "{0:n2}";
                grdLaborAnalysisView.Columns["Day6"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Day6"].DisplayFormat.FormatString = "{0:n2}";
                grdLaborAnalysisView.Columns["Day7"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborAnalysisView.Columns["Day7"].DisplayFormat.FormatString = "{0:n2}";

                grdLaborAnalysisView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Hours", grdLaborAnalysisView.Columns["Hours"], "{0:n2}");
                grdLaborAnalysisView.Columns["Hours"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Hours"].SummaryItem.DisplayFormat = "{0:n2}";
                grdLaborAnalysisView.Columns["Day1"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Day1"].SummaryItem.DisplayFormat = "{0:n2}";
                grdLaborAnalysisView.Columns["Day2"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Day2"].SummaryItem.DisplayFormat = "{0:n2}";
                grdLaborAnalysisView.Columns["Day3"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Day3"].SummaryItem.DisplayFormat = "{0:n2}";
                grdLaborAnalysisView.Columns["Day4"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Day4"].SummaryItem.DisplayFormat = "{0:n2}";
                grdLaborAnalysisView.Columns["Day5"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Day5"].SummaryItem.DisplayFormat = "{0:n2}";
                grdLaborAnalysisView.Columns["Day6"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Day6"].SummaryItem.DisplayFormat = "{0:n2}";
                grdLaborAnalysisView.Columns["Day7"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLaborAnalysisView.Columns["Day7"].SummaryItem.DisplayFormat = "{0:n2}";

                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdLaborAnalysisView, "ctlLaborAnalysis");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void GroupLaborAnalysis(LaborAnalysisView group)
        {
            if (grdLaborAnalysisView.Columns["Phase"].GroupIndex > -1)
                grdLaborAnalysisView.Columns["Phase"].UnGroup();
            if (grdLaborAnalysisView.Columns["Code"].GroupIndex > -1)
                grdLaborAnalysisView.Columns["Code"].UnGroup();
            if (grdLaborAnalysisView.Columns["Emp Name"].GroupIndex > -1)
                grdLaborAnalysisView.Columns["Emp Name"].UnGroup();
            if (grdLaborAnalysisView.Columns["Weekend"].GroupIndex > -1)
                grdLaborAnalysisView.Columns["Weekend"].UnGroup();
            if (grdLaborAnalysisView.Columns["Hours Type"].GroupIndex > -1)
                grdLaborAnalysisView.Columns["Hours Type"].UnGroup();
            if (grdLaborAnalysisView.Columns["Craft"].GroupIndex > -1)
                grdLaborAnalysisView.Columns["Craft"].UnGroup();
            switch (group)
            {
                case LaborAnalysisView.Code:
                    grdLaborAnalysisView.Columns["Code"].Group();
                    break;
                case LaborAnalysisView.Phase:
                    grdLaborAnalysisView.Columns["Phase"].Group();
                    break;
                case LaborAnalysisView.Employee:
                    grdLaborAnalysisView.Columns["Emp Name"].Group();
                    break;
                case LaborAnalysisView.Week:
                    grdLaborAnalysisView.Columns["Weekend"].Group();
                    break;
                case LaborAnalysisView.HoursType:
                    grdLaborAnalysisView.Columns["Hours Type"].Group();
                    break;
                case LaborAnalysisView.Craft:
                    grdLaborAnalysisView.Columns["Craft"].Group();
                    break;
            } 
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupLaborAnalysis((LaborAnalysisView)radioGroup.SelectedIndex);
        }

        private void grdLaborAnalysisView_ColumnFilterChanged(object sender, EventArgs e)
        {
            laborAnalysisTable.DefaultView.RowFilter = grdLaborAnalysisView.FilterPanelText;
            filter = grdLaborAnalysisView.FilterPanelText;
        }

        private void grdLaborAnalysisView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
  
    }
}
