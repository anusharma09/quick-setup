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
    public partial class ctlCostCodeTimeCard : UserControl
    {
        private string jobID;
        DataSet jobCodeWeeklyDataSet;
        protected bool bColumnWidthChanged = false;
        public ctlCostCodeTimeCard()
        {
            InitializeComponent();
            SetDateToNextSunday();  
        }

        public string JobID
        {
            set
            {
                jobID = value;
                GetCostCodesTimeCard();
            }
        }

        public string SelectedDate
        {
            get {return txtSelectedDate.Text;}
        }

        public DataSet SelectedData
        {
            get { return jobCodeWeeklyDataSet; }
        }

        private void GetCostCodesTimeCard()
        {
            string id;
            if (jobID == "")
                id = "0";
            else
                id = jobID;
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdCostCodesWeeklyView, "ctlCostCodeTimeCard");
                }
                jobCodeWeeklyDataSet = JobCostTimeSheet.GetTimeCard(id);
                this.grdCostCodesWeekly.DataSource = jobCodeWeeklyDataSet.Tables[0].DefaultView;
                grdCostCodesWeeklyView.Columns["Phase"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Code"].OptionsColumn.AllowEdit = false;
                //grdCostCodesWeeklyView.Columns["Title"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Description"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Description"].Caption = "User Description";
                grdCostCodesWeeklyView.Columns["Unit"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Unit"].Caption = "UOM";
                grdCostCodesWeeklyView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdCostCodesWeeklyView, "ctlCostCodeTimeCard");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            bool checkStatus;

            if (jobCodeWeeklyDataSet != null)
            {
                if (chkSelected.Checked.ToString() == "True")
                    checkStatus = true;
                else
                    checkStatus = false;
                foreach (DataRow r in jobCodeWeeklyDataSet.Tables[0].Rows)
                    r["Selected"] = checkStatus;
            }
        }
        // Set The date To Next Sunday
        private void SetDateToNextSunday()
        {
            double days = 0;
            switch (DateTime.Now.DayOfWeek.ToString())
            {
                case "Saturday":
                    days = 1;
                    break;
                case "Friday":
                    days = 2;
                    break;
                case "Thursday":
                    days = 3;
                    break;
                case "Wednesday":
                    days = 4;
                    break;
                case "Tuesday":
                    days = 5;
                    break;
                case "Monday":
                    days = 6;
                    break;
                default:
                    days = 0;
                    break;
            }
            txtSelectedDate.Text = DateTime.Now.AddDays(days).ToString();
        }

        private void grdCostCodesWeeklyView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            grdCostCodesWeeklyView.MoveNext();
        }

        private void grdCostCodesWeeklyView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            DataRow r = grdCostCodesWeeklyView.GetDataRow(e.RowHandle);
            if (r["Selected"].ToString() == "False")
                r["Selected"] = "True";
            else
                r["Selected"] = "False";
            grdCostCodesWeeklyView.MoveNext();
           
        }

        private void grdCostCodesWeeklyView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

    
    }
}
