using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using DevExpress.XtraCharts;
namespace CCEJobs.Controls
{
    public partial class ctlLaborPerformanceFactor : UserControl
    {
        DataTable myTable;

        private string jobID;
        public ctlLaborPerformanceFactor()
        {
            InitializeComponent();
            chartLaborPerformanceback.DataSource = grdLaborPerformanceback;
            chartLaborPerformanceback.SeriesDataMember = "Series";
            chartLaborPerformanceback.SeriesTemplate.ArgumentDataMember = "Arguments";
            chartLaborPerformanceback.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
            chartLaborPerformanceback.SeriesTemplate.Label.Visible = false;
            chartLaborPerformanceback.SeriesTemplate.Label.Antialiasing = true;
            chartLaborPerformanceback.Series[0].LegendText = "Label Perf.";
            chartLaborPerformanceback.Series[0].Label.Visible = false;

            chartLaborPerformanceback.PaletteName = "Apex";
            chartLaborPerformanceback.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            chartLaborPerformanceback.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 2;
            //
            DevExpress.XtraCharts.XYDiagram diag = (DevExpress.XtraCharts.XYDiagram)chartLaborPerformanceback.Diagram;
          //  diag.AxisX.Range.SetInternalMinMaxValues(0, 10);
            diag.AxisX.Label.Angle = 50;
            diag.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            diag.AxisY.NumericOptions.Precision = 2; 
        }

        public string JobID
        {
            set
            {
                jobID = value;
                GetLaborFeedback();
            }
        }
        //
        public DevExpress.XtraPivotGrid.PivotGridControl LaborPerformanceFactorGrid
        {
            get { return grdLaborPerformanceback; }
        }
        public DevExpress.XtraCharts.ChartControl LaborPerformanceFactorChart
        {
            get { return chartLaborPerformanceback; }
        }
        //
        private void GetLaborFeedback()
        {
            string id;
            if ( String.IsNullOrEmpty(jobID) || jobID == "" )
                jobID = "0";
            try
            {
                myTable = Job.GetJobPeformanceFactorHistory(jobID).Tables[0];
                grdLaborPerformanceback.DataSource = myTable;   //Job.GetJobPeformanceFactorHistory(jobID).Tables[0];
                grdLaborPerformanceback.RetrieveFields();

                grdLaborPerformanceback.Fields["Weekend"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                grdLaborPerformanceback.Fields["Weekend"].CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                grdLaborPerformanceback.Fields["Weekend"].CellFormat.FormatString = "d";
                grdLaborPerformanceback.Fields["JobLaborPerformanceFactorWeekly"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborPerformanceback.Fields["JobLaborPerformanceFactorWeekly"].CellFormat.FormatString = "n2";
                grdLaborPerformanceback.Fields["JobLaborPerformanceFactorWeekly"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                grdLaborPerformanceback.Fields["JobLaborPerformanceFactorWeekly"].GrandTotalText = "Labor Perf.";
                grdLaborPerformanceback.Fields["JobLaborPerformanceFactorWeekly"].Options.ShowGrandTotal = false;
                grdLaborPerformanceback.Fields["Weekend"].ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                grdLaborPerformanceback.Fields["Weekend"].ValueFormat.FormatString = "MM/dd/yy";
                grdLaborPerformanceback.BestFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void cboLaborFeedback_EditValueChanged(object sender, EventArgs e)
        {
            GetLaborFeedback();
        }
    }
}
