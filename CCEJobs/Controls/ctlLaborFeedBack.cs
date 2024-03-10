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
    public partial class ctlLaborFeedBack : UserControl
    {
        private Int64 used;
        private Int64 earned;
        private Double laborPerformanceFactor;
        private string jobID;
        private DataTable dataTable;
        public ctlLaborFeedBack()
        {
            InitializeComponent();
            chartLaborFeedback.DataSource = grdLaborFeedback;
            chartLaborFeedback.SeriesDataMember = "Series";
            chartLaborFeedback.SeriesTemplate.ArgumentDataMember = "Arguments";
            chartLaborFeedback.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
            chartLaborFeedback.SeriesTemplate.Label.Visible = false;
            chartLaborFeedback.SeriesTemplate.Label.Antialiasing = true;

            chartLaborFeedback.PaletteName = "Apex";
            chartLaborFeedback.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            chartLaborFeedback.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 0;
            //
            DevExpress.XtraCharts.XYDiagram diag = (DevExpress.XtraCharts.XYDiagram)chartLaborFeedback.Diagram;
          //  diag.AxisX.Range.SetInternalMinMaxValues(0, 10);
            diag.AxisX.Label.Angle = 50;
            diag.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            diag.AxisY.NumericOptions.Precision = 0; 
        }

        public string JobID
        {
            set
            {
                jobID = value;
                GetLaborFeedbackDates();
                GetLaborFeedback();
            }
        }

        public string SelectedWeek
        {
            get { return cboLaborFeedback.Text; }
        }
        public string EmployeeName
        {
            get { return cboEmployee.Text; }
        }

        public DevExpress.XtraPivotGrid.PivotGridControl LaborFeedbackGrid
        {
            get { return grdLaborFeedback; }
        }
        public DevExpress.XtraCharts.ChartControl LaborFeedbackChart
        {
            get { return chartLaborFeedback; }
        }

        private void UpdateEmployeeList()
        {
            cboEmployee.Properties.Items.Clear();
            DataTable emp = JobCostTimeSheet.GetCostCodeWeeklyEmployee(jobID, cboLaborFeedback.Text.Trim()).Tables[0];
            cboEmployee.Text = "";
            cboEmployee.Properties.Items.Add("");
            foreach (DataRow r in emp.Rows)
            {
                cboEmployee.Properties.Items.Add(r[0]);
            }
        }

        private void GetLaborFeedbackDates()
        {
            try
            {
                cboLaborFeedback.Properties.DataSource = JobCostTimeSheet.GetCostCodeWeeklyDates(jobID).Tables[0];
                cboLaborFeedback.Properties.DisplayMember = "WeekEnd";
                cboLaborFeedback.Properties.ShowHeader = false;
                grdLaborFeedback.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void GetLaborFeedback()
        {
            string id;
            if (jobID == "" || String.IsNullOrEmpty(cboLaborFeedback.Text))
                id = "0";
            else
                id = jobID;
            try
            {
                dataTable = JobCost.GetCostCodeLaborFeedback(jobID, cboLaborFeedback.Text).Tables[0];
                grdLaborFeedback.DataSource = dataTable;
                grdLaborFeedback.RetrieveFields();

                grdLaborFeedback.Fields["Phase"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                grdLaborFeedback.Fields["Code"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                grdLaborFeedback.Fields["Title"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                grdLaborFeedback.Fields["Title"].Caption = "User Description";
                //grdLaborFeedback.Fields["Emp Name"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;

                grdLaborFeedback.Fields["Budget"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborFeedback.Fields["Budget"].CellFormat.FormatString = "n0";
                grdLaborFeedback.Fields["Budget"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;

                grdLaborFeedback.Fields["Used"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborFeedback.Fields["Used"].CellFormat.FormatString = "n0";
                grdLaborFeedback.Fields["Used"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;

                grdLaborFeedback.Fields["Earned"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborFeedback.Fields["Earned"].CellFormat.FormatString = "n0";
                grdLaborFeedback.Fields["Earned"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;

                grdLaborFeedback.Fields["Labor Performance Factor"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLaborFeedback.Fields["Labor Performance Factor"].CellFormat.FormatString = "n2";
                grdLaborFeedback.Fields["Labor Performance Factor"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;

                grdLaborFeedback.BestFit();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }



        private void cboLaborFeedback_EditValueChanged(object sender, EventArgs e)
        {
            UpdateEmployeeList();
            GetLaborFeedback();
            chkWeek.CheckState = CheckState.Unchecked;

        }

        private void chartLaborFeedback_BoundDataChanged(object sender, EventArgs e)
        {
            if (chartLaborFeedback.Series.Count ==  4)
            {
                chartLaborFeedback.Series[0].View.Color = Color.Yellow;
                chartLaborFeedback.Series[1].View.Color = Color.Red;
                chartLaborFeedback.Series[2].View.Color = Color.Green;

                chartLaborFeedback.Series[0].LegendText = "Budget";
                chartLaborFeedback.Series[1].LegendText = "Used";
                chartLaborFeedback.Series[2].LegendText = "Earned";
                chartLaborFeedback.Series[3].Visible = false;
            }
             
        }

        private void chkShowGrandTotal_CheckedChanged(object sender, EventArgs e)
        {
            grdLaborFeedback.OptionsView.ShowRowGrandTotals = chkShowGrandTotal.Checked;
        }

        private void chkShowTotal_CheckedChanged(object sender, EventArgs e)
        {
            grdLaborFeedback.OptionsView.ShowRowTotals = chkShowTotal.Checked;
        }

        private void grdLaborFeedback_CustomCellDisplayText(object sender, DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs e)
        {
            // Calculate Labor Performance Factor
      
            switch (e.RowValueType)
            {
                case DevExpress.XtraPivotGrid.PivotGridValueType.Total:
                    if (e.DataField != null)
                    {
                        switch (e.DataField.Caption)
                        {
                            case "Used":
                                used = Convert.ToInt64(e.Value.ToString());
                                break;
                            case "Earned":
                                earned = Convert.ToInt64(Convert.ToDouble(e.Value.ToString()));
                                break;
                            case "Labor Performance Factor":
                                if (earned == 0 || used == 0)
                                    e.DisplayText = "1.00";
                                else
                                    laborPerformanceFactor = Convert.ToDouble(Convert.ToDouble(used) / Convert.ToDouble(earned));
                                e.DisplayText = String.Format("{0:n2}", laborPerformanceFactor);
                                break;
                        }
                    }
                    break;
                case DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal:
                    if (e.DataField != null)
                    {
                        switch (e.DataField.Caption)
                        {
                            case "Used":
                                used = Convert.ToInt64(e.Value.ToString());
                                break;
                            case "Earned":
                                earned = Convert.ToInt64(Convert.ToDouble(e.Value.ToString()));
                                break;
                            case "Labor Performance Factor":
                                if (earned == 0 || used == 0)
                                    e.DisplayText = "1.00";
                                else
                                    laborPerformanceFactor = Convert.ToDouble(Convert.ToDouble(used) / Convert.ToDouble(earned));
                                e.DisplayText = String.Format("{0:n2}", laborPerformanceFactor);
                                break;
                        }
                    }
                    break;
            }

        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void chkWeek_CheckedChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void SetFilter()
        {
            dataTable.DefaultView.RowFilter = "";
            if (cboEmployee.Text.Trim().Length > 0  && (chkWeek.CheckState == CheckState.Checked && cboLaborFeedback.Text.Trim().Length > 0 ))
                dataTable.DefaultView.RowFilter = "EmpName = '" + cboEmployee.Text + "' AND WeekEnd = '" + cboLaborFeedback.Text + "'" ;
            if (cboEmployee.Text.Trim().Length > 0)
                dataTable.DefaultView.RowFilter = "EmpName = '" + cboEmployee.Text + "' ";
            if (chkWeek.CheckState == CheckState.Checked && cboLaborFeedback.Text.Trim().Length > 0 )
                dataTable.DefaultView.RowFilter = " WeekEnd = '" + cboLaborFeedback.Text + "'";

        }
    }
}
