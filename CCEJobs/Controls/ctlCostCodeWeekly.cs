using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using System.Threading.Tasks;

namespace CCEJobs.Controls
{
    public partial class ctlCostCodeWeekly : UserControl
    {
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private bool upgradeable = false;
        private string jobID;
        DataSet jobCodeWeeklyDataSet;
        private bool isUpdated = false;
        protected bool bColumnWidthChanged = false;

        public ctlCostCodeWeekly()
        {
            InitializeComponent();
        }
        //
        public Security.Security.JobCaller JobCaller
        {
            set
            {
                jobCaller = value;
            }
        }
        public string JobID
        {
            set 
            { 
                jobID = value;
                GetCostCodesWeeklyDates();
                GetCostCodesWeekly();
                SetControlAccess();
            }
        }
        //
        public bool IsUpdated
        {
            get { return isUpdated; }
        }
        //
        public bool Updateable
        {
            set
            {
                upgradeable = value;
            }
        }
        //
        public string SelectedWeek
        {
            get { return cboCostCodesWeekly.Text;}
        }
        //
        public DataSet SelectedData
        {
            get { return jobCodeWeeklyDataSet; }
        }
        //
        private  void GetCostCodesWeeklyDates()
        {
            try
            {
                DataTable table = JobCostTimeSheet.GetCostCodeWeeklyDates(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    cboCostCodesWeekly.Properties.DataSource = JobCostTimeSheet.GetCostCodeWeeklyDates(jobID).Tables[0];
                    cboCostCodesWeekly.Properties.DisplayMember = "WeekEnd";
                    cboCostCodesWeekly.Properties.ShowHeader = false;
                    cboCostCodesWeekly.EditValue = table.Rows[0]["WeekEnd"].ToString();
                    cboCostCodesWeekly.EditValue = cboCostCodesWeekly.EditValue.ToString().Substring(0,10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void cboCostCodesWeekly_EditValueChanged(object sender, EventArgs e)
        {
            if (btnUpdateTimeSheet.Enabled)
            {
                UpdateSheet();
            }
            GetCostCodesWeekly();
        }
        //
        private void GetCostCodesWeekly()
        {
            string id;
            if (jobID == "")// || String.IsNullOrEmpty(cboCostCodesWeekly.Text))
                id = "0";
            else
                id = jobID;
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdCostCodesWeeklyView, "ctlCostCodeWeekly");
                }

                jobCodeWeeklyDataSet = JobCostTimeSheet.GetCostCodeWeekly(id, cboCostCodesWeekly.Text);

                this.grdCostCodesWeekly.DataSource = jobCodeWeeklyDataSet.Tables[0].DefaultView;

                grdCostCodesWeeklyView.Columns["Phase"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Code"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Title"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Title"].Visible = false;
                grdCostCodesWeeklyView.Columns["Description"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Description"].Caption = "User Description";
                grdCostCodesWeeklyView.Columns["Unit"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Unit"].Caption = "UOM";
                grdCostCodesWeeklyView.Columns["Committed Quantity"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["Committed Quantity"].Caption = "Actual Qty";
                grdCostCodesWeeklyView.Columns["CommittedHours"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["CommittedHours"].Caption = "Actual Hrs";
                grdCostCodesWeeklyView.Columns["TotalBudgetQuantity"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["TotalBudgetQuantity"].Caption = "Total Budget Qty";
                grdCostCodesWeeklyView.Columns["TotalBudgetHours"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["TotalBudgetHours"].Caption = "Total Budget Hrs";
                grdCostCodesWeeklyView.Columns["Hours"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["JobCostCodeWeeklyID"].Visible = false;
                grdCostCodesWeeklyView.Columns["JobCostCodePhaseID"].Visible = false;
                grdCostCodesWeeklyView.Columns["Selected"].Visible = false;
                grdCostCodesWeeklyView.Columns["Unit"].Visible = true;
                grdCostCodesWeeklyView.Columns["Quantity"].Caption = "Selected Week Qty";
                grdCostCodesWeeklyView.Columns["Hours"].Caption = "Selected Week Hrs";
                grdCostCodesWeeklyView.Columns["Quantity"].OptionsColumn.AllowEdit = true;
                grdCostCodesWeeklyView.Columns["Hours"].OptionsColumn.AllowEdit = false;
                grdCostCodesWeeklyView.Columns["TotalBudgetQuantity"].AppearanceCell.BackColor = Color.LightBlue;
                grdCostCodesWeeklyView.Columns["TotalBudgetHours"].AppearanceCell.BackColor = Color.LightBlue;
                grdCostCodesWeeklyView.Columns["Committed Quantity"].DisplayFormat.FormatString = "{0:n0}";
                grdCostCodesWeeklyView.Columns["Committed Quantity"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdCostCodesWeeklyView.Columns["Quantity"].DisplayFormat.FormatString = "{0:n0}";
                grdCostCodesWeeklyView.Columns["Quantity"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdCostCodesWeeklyView.Columns["Hours"].DisplayFormat.FormatString = "{0:n0}";
                grdCostCodesWeeklyView.Columns["Hours"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdCostCodesWeeklyView.Columns["CommittedHours"].DisplayFormat.FormatString = "{0:n0}";
                grdCostCodesWeeklyView.Columns["CommittedHours"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdCostCodesWeeklyView.Columns["TotalBudgetQuantity"].DisplayFormat.FormatString = "{0:n0}";
                grdCostCodesWeeklyView.Columns["TotalBudgetQuantity"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdCostCodesWeeklyView.Columns["TotalBudgetHours"].DisplayFormat.FormatString = "{0:n0}";
                grdCostCodesWeeklyView.Columns["TotalBudgetHours"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdCostCodesWeeklyView.Columns["Hours"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdCostCodesWeeklyView.Columns["Hours"].SummaryItem.DisplayFormat = "{0:n0}";
                grdCostCodesWeeklyView.Columns["CommittedHours"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdCostCodesWeeklyView.Columns["CommittedHours"].SummaryItem.DisplayFormat = "{0:n0}";
                grdCostCodesWeeklyView.Columns["TotalBudgetHours"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdCostCodesWeeklyView.Columns["TotalBudgetHours"].SummaryItem.DisplayFormat = "{0:n0}";
                grdCostCodesWeeklyView.BestFitColumns();
                grdCostCodesWeeklyView.Columns["Description"].Width = 150;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdCostCodesWeeklyView, "ctlCostCodeWeekly");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void btnAddNewWeek_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(jobID))
            {
                try
                {
                    MessageBox.Show(JobCostTimeSheet.CreateTimeSheet(jobID).Tables[0].Rows[0][0].ToString(), CCEApplication.ApplicationName);
                    GetCostCodesWeeklyDates();
                    GetCostCodesWeekly();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }
        //
        private void btnUpdateTimeSheet_Click(object sender, EventArgs e)
        {
            UpdateSheet();
        }
        //
        private void UpdateSheet()
        {
            SaveChanges(true);
        }
        //
        public void SaveChanges(bool save)
        {
            if (save)
            {
                try
                {
                    JobCostTimeSheet jobCostTimeSheet;
                    foreach (DataRow r in jobCodeWeeklyDataSet.Tables[0].Rows)
                    {
                        jobCostTimeSheet = new JobCostTimeSheet(r["JobCostCodeWeeklyID"].ToString(),
                                                        r["JobCostCodePhaseID"].ToString(),
                                                        cboCostCodesWeekly.Text,
                                                        r["Quantity"].ToString(),
                                                        r["Hours"].ToString());
                        jobCostTimeSheet.Save();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
                GetCostCodesWeekly();
            }
            btnUpdateTimeSheet.Enabled = false;
            btnUpdateTimeSheet.Visible = false;
            isUpdated = false;
        }
        //
        private void grdCostCodesWeeklyView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnUpdateTimeSheet.Enabled = true;
            btnUpdateTimeSheet.Visible = true;
            isUpdated = true;
        }
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly
                )
            {
                grdCostCodesWeeklyView.OptionsBehavior.Editable = false;
                grdCostCodesWeeklyView.Columns["Quantity"].AppearanceCell.BackColor = Color.White;
            }
            else
            {
                grdCostCodesWeeklyView.OptionsBehavior.Editable = true;
                grdCostCodesWeeklyView.Columns["Quantity"].AppearanceCell.BackColor = Color.LightSalmon;

            }
        }

        private void grdCostCodesWeeklyView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
