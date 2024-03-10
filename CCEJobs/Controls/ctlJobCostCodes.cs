using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;

using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
namespace CCEJobs.Controls
{
    public delegate void StarbuilderEventHandler(object sender, StarbuilderEventArgs e);


    public partial class ctlJobCostCodes : UserControl
    {
        public event StarbuilderEventHandler Starbuilder;

        protected virtual void OnStarbuiler(StarbuilderEventArgs e)
        {
            if (Starbuilder != null)
            {
                // Invoice The delecate
                Starbuilder(this, e);
            }
        }
        //
        protected bool bColumnWidthChanged = false;
        protected bool bColumnWidthChangedd = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private bool upgradeable = false;
        private DataSet jobCodeDataSet;
        private DataSet jobCodeDataSetB;
        private string jobID;
        private string jobChangeOrderID = "0";
        private string jobChangeOrderNumber = "";
        private string jobChangeOrderStatus = "";
        private bool isUpdated = false;
        private bool isUpdatedChangeOrder = false;
        private string jobNumber;
        private DataTable jobChangeOrders;
        private bool trackChangeOrder = false;
        private bool trachChangeOrderForStarbuilder = false;
        private string contractType;
        private bool isWarning = false;
        private bool isClosed = false;
        private string reportFilter = "";
        private string reportSort = "";

        protected BindingSource bindingSource = new BindingSource();
        //
        public ctlJobCostCodes()
        {
            InitializeComponent();
            panTemplate.Visible = false;
        }
        public string ReportFilter
        {
            get { return reportFilter; }
        }
        //
        public string ReportSort
        {
            get { return reportSort; }
        }
        //
        public DataTable ReportTable
        {
            get { return jobChangeOrders; }
        }
        //
        public Security.Security.JobCaller JobCaller
        {
            set
            {
                jobCaller = value;
            }
        }
        //
        public bool IsClosed
        {
            set
            {
                isClosed = value;
            }
        }
        //
        public string ContractType
        {
            set
            {
                contractType = value;
                SetContractType();
            }
        }
        //
        public bool TrackChangeOrder
        {
            set
            {
                trackChangeOrder = value;
                SetContractType();

            }
        }
        //
        private void SetContractType()
        {
            // "TIME AND MATERIAL" IS for DYNA
            if (contractType == "GUARANTEED MAXIMUM" || contractType == "TIME & MATERIAL" || contractType == "COST PLUS" || contractType == "TIME AND MATERIAL")
                isWarning = true;


            switch (contractType)
            {
                case "TIME & MATERIAL":
                case "TIME AND MATERIAL":
                case "GUARANTEED MAXIMUM":
                case "COST PLUS":
                case "UNIT PRICE":
                    if (trackChangeOrder)
                    {
                        panTimeJob.Visible = false;
                        panFixedJob.Visible = true;
                        panFixedJob.Dock = DockStyle.Fill;
                        trachChangeOrderForStarbuilder = true;
                    }
                    else
                    {
                        panFixedJob.Visible = false;
                        panTimeJob.Visible = true;
                        panTimeJob.Dock = DockStyle.Fill;
                        trachChangeOrderForStarbuilder = false;
                        txtPercent.Text = "";
                        txtRecommendedContractAmount.Text = "";
                        txtCalculatedStarbuilder.Text = "";
                    }
                    break;
                default:
                    panTimeJob.Visible = false;
                    panFixedJob.Visible = true;
                    panFixedJob.Dock = DockStyle.Fill;
                    trachChangeOrderForStarbuilder = true;
                    break;
            }
        }
        //
        public string JobID
        {
            set
            {
                jobID = value;
                if (jobID == "")
                    jobID = "0";
                GetJobDetail();
                GetCurrnetChangeOrderDetail();
                GetJobSummary();
                isUpdated = false;
                SetControlAccess();
                CheckTemplate();
            }
        }
        //
        public string JobNumber
        {
            set
            {
                jobNumber = value;
            }
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
        public bool IsUpdated
        {
            get { return isUpdated; }
        }
        //
        public bool IsUpdatedChangeOrder
        {
            get { return isUpdatedChangeOrder; }
        }
        //
        public string JobChangeOrderID
        {
            get
            {
                return jobChangeOrderID;
            }
        }
        //
        private void CheckTemplate()
        {
            if (jobChangeOrders.Rows.Count > 1) //|| gridView1.RowCount != 0)
            {
                panTemplate.Visible = false;
                return;
            }
            /*
            panTemplate.Visible = true;
            if (cboSelect.Properties.DataSource == null)
            {
                cboSelect.Properties.DataSource = StaticTables.JobsList;
                cboSelect.Properties.DisplayMember = "Job Name";
                cboSelect.Properties.ValueMember = "Job Number";
                cboSelect.Properties.PopulateColumns();
                cboSelect.Refresh();
            } */

        }
        //
        private void GetJobDetail()
        {
            GetJobChangeOrders();
            CheckTemplate();
            if (grdChangeOrderView.RowCount > 0)
                grdChangeOrderView.Focus();
            isUpdated = false;
            isUpdatedChangeOrder = false;
        }
        //
        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (jobCodeDataSet != null)
            {
                if (chkSelected.Checked.ToString() == "True")
                    jobCodeDataSet.Tables[0].DefaultView.RowFilter = "Selected = True ";
                else
                    jobCodeDataSet.Tables[0].DefaultView.RowFilter = "";
            }
        }
        //
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            return;
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
               Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                return;

            string selected = "";
            if (gridView1.SelectedRowsCount <= 0)
                return;

            try
            {
                DataRow dataRow = null;
                dataRow = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);

                if (dataRow["Selected"].ToString() == "True")
                {
                    gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Hours"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                    if (dataRow["User Description"].ToString() == "")
                    {
                        dataRow["User Description"] = dataRow["Description"];
                    }
                }
                else
                {
                    gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                }

            }
            catch (Exception ex) { }
        }
        //
        private void GetJobCostCodes(string jobChangeOrderID, string jobID)
        {
            try
            {
                jobCodeDataSet = JobCost.GetCostCode(jobChangeOrderID, jobID);

                if (bColumnWidthChangedd)
                {
                    bColumnWidthChangedd = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridView1, "ctlJobCostCodesDetail");
                }


                this.grdCostCode.DataSource = jobCodeDataSet.Tables[0].DefaultView;
                if (chkSelected.CheckState == CheckState.Checked)
                    jobCodeDataSet.Tables[0].DefaultView.RowFilter = "Selected = True";
                gridView1.Columns["Type"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Phase"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Code"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Title"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Description"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["User Description"].ColumnEdit = txtUserDescription1;
                gridView1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Unit"].ColumnEdit = RepositoryItems.unitOfMeasurements;
                gridView1.Columns["Unit"].Caption = "UOM";
                gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["JobCostCodeID"].Visible = false;
                gridView1.Columns["JobChangeOrderID"].Visible = false;
                gridView1.Columns["JobCostCodePhaseID"].Visible = false;
                gridView1.Columns["Cost $"].ColumnEdit = txtMaterialCost;
                gridView1.Columns["Cost $"].Width = 200;
                gridView1.Columns["Quantity"].ColumnEdit = txtQuantity;
                gridView1.Columns["Hours"].ColumnEdit = txtHours;
                // DevExpress.XtraGrid.GridColumnSummaryItem totalHours = new DevExpress.XtraGrid.GridColumnSummaryItem(gridView1.Columns["Hours"]);
                // totalHours.DisplayFormat = "n0";
                gridView1.Columns["Hours"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Hours"].SummaryItem.DisplayFormat = "{0:n0}";
                gridView1.Columns["Cost $"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Cost $"].SummaryItem.DisplayFormat = "{0:c2}";
                this.jobChangeOrderID = jobChangeOrderID;
                //
                DataRow r;

                if (grdChangeOrderView.SelectedRowsCount > 0)
                {
                    r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                    if (r != null)
                    {
                        //txtContractAmount.Text = gridView1.Columns["Cost $"].SummaryItem.SummaryValue.ToString();
                        if (r["JobChangeOrderApprovedAmount"].ToString().Length > 0
                                && Convert.ToDouble(r["JobChangeOrderApprovedAmount"].ToString().Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) > 0)
                            txtContractAmount.Text = r["JobChangeOrderApprovedAmount"].ToString();
                        else
                            txtContractAmount.Text = r["JobChangeOrderRequestedAmount"].ToString();
                        // TotalOverHead
                        txtTotalOverHead.Text = (Convert.ToDouble(txtContractAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) -
                                                 Convert.ToDouble(gridView1.Columns["Cost $"].SummaryItem.SummaryValue.ToString().Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", ""))).ToString();
                        // TotalPercentOverHead       
                        if (Convert.ToDouble(txtContractAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) > 0)
                            txtPercentOverHead.Text =
                                (Convert.ToDouble(txtTotalOverHead.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) /
                                Convert.ToDouble(txtContractAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", ""))).ToString();
                        else
                            txtPercentOverHead.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            gridView1.BestFitColumns();
            gridView1.Columns["Title"].Width = 150;
            gridView1.Columns["Description"].Width = 150;
            gridView1.Columns["User Description"].Width = 150;
            gridView1.Columns["Cost $"].Width = 100;
            Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridView1, "ctlJobCostCodesDetail");


        }

        public bool SaveJobCostCodes()
        {

            if (!isUpdated)
                return true;
            DialogResult result;
            bool ret = true;
            result = MessageBox.Show("Save Cost Code Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    ret = false;
                    break;
                case DialogResult.No:
                    isUpdated = false;
                    GetJobCostCodes(jobChangeOrderID, jobID);
                    ret = true;
                    break;
                case DialogResult.Yes:
                    try
                    {
                        this.Cursor = Cursors.AppStarting;
                        JobCost jobCost;
                        foreach (DataRow r in jobCodeDataSet.Tables[0].Rows)
                        {
                            // Update Record

                            if (r["Selected"].ToString() == "True" && r["JobCostCodeID"].ToString() != "")
                            {
                                jobCost = new JobCost(r["JobCostCodeID"].ToString(),
                                                                        jobChangeOrderID,
                                                                        jobChangeOrderNumber,
                                                                        r["JobCostCodePhaseID"].ToString(),
                                                                        r["User Description"].ToString(),
                                                                        r["Unit"].ToString().Trim(),
                                                                        r["Quantity"].ToString(),
                                                                        r["Hours"].ToString(),
                                                                        r["Cost $"].ToString(),
                                                                        jobID,
                                                                        r["Type"].ToString(),
                                                                        r["Phase"].ToString(),
                                                                        r["Code"].ToString(),
                                                                        r["Title"].ToString(),
                                                                        r["Description"].ToString());
                                jobCost.Save();
                            }
                            // Delete Record
                            if (r["Selected"].ToString() != "True" && r["JobCostCodeID"].ToString() != "")
                            {
                                JobCost.Remove(r["JobCostCodeID"].ToString());
                            }
                            // Insert Record
                            if (r["Selected"].ToString() == "True" && r["JobCostCodeID"].ToString() == "")
                            {
                                jobCost = new JobCost(r["JobCostCodeID"].ToString(),
                                                                         jobChangeOrderID,
                                                                         jobChangeOrderNumber,
                                                                         r["JobCostCodePhaseID"].ToString(),
                                                                          r["User Description"].ToString(),
                                                                          r["Unit"].ToString().Trim(),
                                                                         r["Quantity"].ToString(),
                                                                         r["Hours"].ToString(),
                                                                         r["Cost $"].ToString(),
                                                                         jobID,
                                                                         r["Type"].ToString(),
                                                                         r["Phase"].ToString(),
                                                                         r["Code"].ToString(),
                                                                         r["Title"].ToString(),
                                                                         r["Description"].ToString());
                                jobCost.Save();
                            }
                        }
                        // Starbuilder
                        if (Convert.ToInt32(jobChangeOrderNumber) == 0)
                        {
                            JobChangeOrder.UpdatePrimaryContractCostCodes(jobID);
                        }
                        else
                        {
                            if (trachChangeOrderForStarbuilder)
                                JobChangeOrder.UpdateChangeOrderCostCodes(jobID, jobChangeOrderNumber);
                        }

                        this.Cursor = Cursors.Default;
                        ret = true;
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }

                    isUpdated = false;
                    isUpdatedChangeOrder = false;
                    break;
            }
            return ret;

        }

        private void GetJobChangeOrders()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdChangeOrderView, "ctlJobCostCodesChangeOrder");
                }

                this.Cursor = Cursors.AppStarting;

                jobChangeOrders = JobChangeOrderContract.GetJobChangeOrders(jobID).Tables[0];
                bindingSource.DataSource = jobChangeOrders;
                grdChangeOrder.DataSource = bindingSource;
                if (jobChangeOrders.Rows.Count > 0)
                {
                    grdChangeOrderView.Columns["JobChangeOrderID"].Visible = false;
                    grdChangeOrderView.Columns["JobID"].Visible = false;
                    grdChangeOrderView.Columns["JobChangeOrderNumber"].Caption = "CO #";
                    grdChangeOrderView.Columns["JobChangeOrderNumber"].ColumnEdit = repChangeOrderNumber;
                    grdChangeOrderView.Columns["JobChangeOrderRequestDate"].Caption = "Requested Date";
                    grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].Caption = "Requested Amount";
                    grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].ColumnEdit = txtMaterialCost;
                    grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].Caption = "Approved Date";
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].Caption = "Approved Amount";
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].ColumnEdit = txtMaterialCost;

                    grdChangeOrderView.Columns["JobChangeOrderDescription"].Caption = "Status";
                    grdChangeOrderView.Columns["JobChangeOrderDescription"].ColumnEdit = repDescription;
                    grdChangeOrderView.Columns["JobChangeOrderDescription"].VisibleIndex = 1;
                    //
                    grdChangeOrderView.Columns["JobChangeOrderUserDescription"].Caption = "Description";
                    grdChangeOrderView.Columns["JobChangeOrderUserDescription"].ColumnEdit = repUserDescription;
                    grdChangeOrderView.Columns["JobChangeOrderUserDescription"].VisibleIndex = 2;
                    //
                    grdChangeOrderView.Columns["JobChangeOrderUpdateFlag"].Caption = "Update Flag";
                    grdChangeOrderView.Columns["JobChangeOrderUpdateFlag"].Visible = false;
                    grdChangeOrderView.Columns["JobChangeOrderUpdateFlag"].ColumnEdit = repUpdateFlag;
                    grdChangeOrderView.Columns["JobChangeOrderLastUpdate"].Caption = "Last Update";
                    grdChangeOrderView.Columns["JobChangeOrderLastUpdate"].ColumnEdit = repLastUpdate;
                    grdChangeOrderView.Columns["JobChangeOrderOwnerNumber"].Caption = "GC #";
                    grdChangeOrderView.Columns["JobChangeOrderOwnerNumber"].VisibleIndex = 3;
                    grdChangeOrderView.Columns["JobChangeOrderOwnerNumber"].ColumnEdit = repOwnerChangerOrderNumber;
                    grdChangeOrderView.Columns["JobChangeOrderCCENumber"].Caption = "Owner #";
                    grdChangeOrderView.Columns["JobChangeOrderCCENumber"].VisibleIndex = 4;
                    grdChangeOrderView.Columns["JobChangeOrderCCENumber"].ColumnEdit = repCCEChangeOrder;

                    grdChangeOrderView.Columns["JobChangeOrderStatus"].Caption = "Status";
                    grdChangeOrderView.Columns["JobChangeOrderStatus"].VisibleIndex = 7;
                    grdChangeOrderView.Columns["JobChangeOrderStatus"].ColumnEdit = repStatus;
                    grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    //
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    grdChangeOrderView.Columns["JobChangeOrderNumber"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    grdChangeOrderView.Columns["JobChangeOrderNumber"].SummaryItem.DisplayFormat = "Total: {0:n0}";
                    grdChangeOrderView.Columns["JobChangeOrderDescription"].ColumnEdit = RepositoryItems.changeOrderDescription;
                    grdChangeOrderView.Columns["JobChangeOrderDescription"].Width = 200;
                    grdChangeOrderView.BestFitColumns();
                    grdChangeOrderView.Columns["JobChangeOrderStatus"].Width = 100;
                }

                GetJobSummary();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdChangeOrderView, "ctlJobCostCodesChangeOrder");

                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ctlJobCostCodes_Load(object sender, EventArgs e)
        {
            GetJobChangeOrders();
        }
        //
        private void grdChangeOrderView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrnetChangeOrderDetail();
            return;
            if (jobCaller == Security.Security.JobCaller.JCCDashboard || Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                return;
            if (jobChangeOrderNumber.Trim() == "0")
                grdChangeOrderView.Columns["JobChangeOrderDescription"].OptionsColumn.AllowEdit = false;
            else
                grdChangeOrderView.Columns["JobChangeOrderDescription"].OptionsColumn.AllowEdit = true;

            DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
            if (r != null && r["JobChangeOrderStatus"].ToString() == "APPROVED")
            {
                grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["JobChangeOrderRequestDate"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].OptionsColumn.AllowEdit = false;
            }
            else
            {
                grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["JobChangeOrderRequestDate"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["JobChangeOrderRequestedAmount"].OptionsColumn.AllowEdit = true;
            }

            if (r == null)
            {
                grdChangeOrderView.Columns["JobChangeOrderDescription"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
            }
        }
        //
        private void GetJobSummary()
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                // Job Summary
                DataTable table = Job.GetJobSummary(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    double originalContractAmount = 0;
                    double origilanContractCost = 0;
                    double approvedCOAmount = 0;
                    double approvedCOCost = 0;
                    double pendingCOWithProceedAmount = 0;
                    double pendingCOWithProceedCost = 0;
                    double pendingCOWithNoProceedAmount = 0;
                    double pendingCOWithNoProceedCost = 0;
                    double currentContract = 0;
                    double currentBudget = 0;
                    double originalContractProfit = 0;
                    double approvedCOProfit = 0;
                    double pendingCOWithProceedProfit = 0;
                    double pendingCOWithNoProceedProfit = 0;
                    double currentContractProfit = 0;
                    double committedCost = 0;

                    // Time & Material
                    float amountBilled = 0;
                    float amountPaid = 0;
                    float actualToDate = 0;
                    float recommendedContractAmount = 0;
                    float precent = 0;

                    float tmRecommendedAmount = 0;

                    committedCost = Convert.ToDouble(table.Rows[0]["CommittedCostToDate"].ToString());
                    currentContract = Convert.ToDouble(table.Rows[0]["CurrentContract"].ToString());
                    if (currentContract > 0 && ((committedCost / currentContract) > .80) && isWarning == true)
                        lblWarning.Visible = true;
                    else
                        lblWarning.Visible = false;


                    // The changes were made here
                    txtAmountBilled.Text = table.Rows[0]["AmountBilled"].ToString();
                    txtAmountPaid.Text = table.Rows[0]["AmountPaid"].ToString();
                    txtActualToDate.Text = table.Rows[0]["CommittedCostToDate"].ToString();
                    if (table.Rows[0]["CommittedCostToDate"] != DBNull.Value)
                        actualToDate = float.Parse(table.Rows[0]["CommittedCostToDate"].ToString());
                    if (actualToDate > 0)
                        tmRecommendedAmount = Job.TMRecommendedAmount(actualToDate.ToString());
                    // precent = actualToDate * (float).1;
                    precent = actualToDate * tmRecommendedAmount;

                    // recommendedContractAmount = actualToDate + precent + tmRecommendedAmount;
                    recommendedContractAmount = actualToDate + precent;

                    // txtRecommendedContractAmount.Text = String.Format("{0:c2}", recommendedContractAmount);
                    txtStarbuilderAmount.Text = table.Rows[0]["Originalcontract"].ToString();
                    //
                    // Changes up to this point
                    //



                    // Original Contract
                    if (table.Rows[0]["OriginalContract"] != DBNull.Value)
                        originalContractAmount = float.Parse(table.Rows[0]["OriginalContract"].ToString());
                    if (table.Rows[0]["OriginalContractCost"] != DBNull.Value)
                        origilanContractCost = float.Parse(table.Rows[0]["OriginalContractCost"].ToString());
                    // Approved CO Amount
                    if (table.Rows[0]["ApprovedCO"] != DBNull.Value)
                        approvedCOAmount = float.Parse(table.Rows[0]["ApprovedCO"].ToString());
                    if (table.Rows[0]["ApprovedCOCost"] != DBNull.Value)
                        approvedCOCost = float.Parse(table.Rows[0]["ApprovedCOCost"].ToString());
                    // Pending with Proceed
                    if (table.Rows[0]["PendingCO"] != DBNull.Value)
                        pendingCOWithProceedAmount = float.Parse(table.Rows[0]["PendingCO"].ToString());
                    if (table.Rows[0]["PendingWithProceedCost"] != DBNull.Value)
                        pendingCOWithProceedCost = float.Parse(table.Rows[0]["PendingWithProceedCost"].ToString());
                    // Pending No Proceed
                    if (table.Rows[0]["NotApprovedCO"] != DBNull.Value)
                        pendingCOWithNoProceedAmount = float.Parse(table.Rows[0]["NotApprovedCO"].ToString());
                    if (table.Rows[0]["PendingNoProceedCost"] != DBNull.Value)
                        pendingCOWithNoProceedCost = float.Parse(table.Rows[0]["PendingNoProceedCost"].ToString());
                    if (table.Rows[0]["CurrentContract"] != DBNull.Value)
                        currentContract = float.Parse(table.Rows[0]["CurrentContract"].ToString());
                    if (table.Rows[0]["CurrentBudget"] != DBNull.Value)
                        currentBudget = float.Parse(table.Rows[0]["CurrentBudget"].ToString());

                    originalContractProfit = originalContractAmount - origilanContractCost;
                    approvedCOProfit = approvedCOAmount - approvedCOCost;
                    pendingCOWithProceedProfit = pendingCOWithProceedAmount - pendingCOWithProceedCost;
                    pendingCOWithNoProceedProfit = pendingCOWithNoProceedAmount - pendingCOWithNoProceedCost;

                    currentContractProfit = currentContract - currentBudget;

                    txtOriginalContractAmount.Text = table.Rows[0]["OriginalContract"].ToString();
                    txtOriginalContractCost.Text = table.Rows[0]["OriginalContractCost"].ToString();
                    txtOriginalContractProfit.Text = originalContractProfit.ToString();
                    if (originalContractProfit != 0)
                        txtOriginalContractOHP.Text = Convert.ToString(originalContractProfit / originalContractAmount);
                    else
                        txtOriginalContractOHP.Text = "0";


                    txtApprovedCOAmount.Text = table.Rows[0]["ApprovedCO"].ToString();
                    txtApprovedCOCost.Text = table.Rows[0]["ApprovedCOCost"].ToString();
                    txtApprovedCOProfit.Text = approvedCOProfit.ToString();
                    if (approvedCOProfit != 0)
                        txtApprovedCOOHP.Text = Convert.ToString(approvedCOProfit / approvedCOAmount);
                    else
                        txtApprovedCOOHP.Text = "0";


                    txtPendingCOWithProceedAmount.Text = table.Rows[0]["PendingCO"].ToString();
                    txtPendingCOWithProceedCost.Text = table.Rows[0]["PendingWithProceedCost"].ToString();
                    txtPendingCOWithProceedProfit.Text = pendingCOWithProceedProfit.ToString();
                    if (pendingCOWithProceedProfit != 0)
                        txtPendingCOWithProceedOHP.Text = Convert.ToString(pendingCOWithProceedProfit / pendingCOWithProceedAmount);
                    else
                        txtPendingCOWithProceedOHP.Text = "0";


                    txtPendingCOWithNoProceedAmount.Text = table.Rows[0]["NotApprovedCO"].ToString();
                    txtPendingCOWithNoProceedCost.Text = table.Rows[0]["PendingNoProceedCost"].ToString();
                    txtPendingCOWithNoProceedProfit.Text = pendingCOWithNoProceedProfit.ToString();
                    if (pendingCOWithNoProceedProfit != 0)
                        txtPendingCOWithNoProceedOHP.Text = Convert.ToString(pendingCOWithNoProceedProfit / pendingCOWithNoProceedAmount);
                    else
                        txtPendingCOWithNoProceedOHP.Text = "0";


                    txtCurrentContractAmount.Text = table.Rows[0]["CurrentContract"].ToString();
                    txtCurrentContractCost.Text = table.Rows[0]["CurrentBudget"].ToString();
                    txtCurrentContractProfit.Text = currentContractProfit.ToString();
                    if (currentContractProfit != 0)
                        txtCurrentContractOHP.Text = Convert.ToString(currentContractProfit / currentContract);
                    else
                        txtCurrentContractOHP.Text = "0";

                    btnUpdateStarBuilder.Visible = false;
                }
                else
                {
                    txtOriginalContractAmount.Text = "0";
                    txtOriginalContractCost.Text = "0";
                    txtOriginalContractProfit.Text = "0";
                    txtOriginalContractOHP.Text = "0";
                    //
                    txtApprovedCOAmount.Text = "0";
                    txtApprovedCOCost.Text = "0";
                    txtApprovedCOProfit.Text = "0";
                    txtApprovedCOOHP.Text = "0";
                    //
                    txtPendingCOWithProceedAmount.Text = "0";
                    txtPendingCOWithProceedCost.Text = "0";
                    txtPendingCOWithProceedProfit.Text = "0";
                    txtPendingCOWithProceedOHP.Text = "0";
                    //
                    txtPendingCOWithNoProceedAmount.Text = "0";
                    txtPendingCOWithNoProceedCost.Text = "0";
                    txtPendingCOWithNoProceedProfit.Text = "0";
                    txtPendingCOWithNoProceedOHP.Text = "0";
                    //
                    txtCurrentContractAmount.Text = "0";
                    txtCurrentContractCost.Text = "0";
                    txtCurrentContractProfit.Text = "0";
                    txtCurrentContractOHP.Text = "0";

                    txtAmountBilled.Text = "0";
                    txtAmountPaid.Text = "0";
                    txtActualToDate.Text = "0";
                    txtRecommendedContractAmount.Text = "0";
                    txtPercent.Text = "0";
                    btnUpdateStarBuilder.Visible = false;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void GetCurrnetChangeOrderDetail()
        {
            if (isUpdated)
            {
                SaveJobCostCodes();
                isUpdated = false;
            }

            //Atef Bakir

            DataRow r;
            bool originalContract = false; ;
            bool pendingStatus = false;
            panCostCodes.Visible = false;
            chkSelected.Visible = false;
            if (grdChangeOrderView.SelectedRowsCount != 0)
            {
                r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);

                // r = grdChangeOrderView.GetDataRow(grdChangeOrderView.FocusedRowHandle);

                if (r == null) // && grdChangeOrderView.FocusedRowHandle)
                {
                    if (jobChangeOrders.Rows.Count > 0 && grdChangeOrderView.FocusedRowHandle != -999998)
                    {
                        r = jobChangeOrders.Rows[0];
                    }
                }
                //grdChangeOrder.DefaultView.LevelName
                //grdChangeOrder.DefaultView.Name
                if (r == null)
                {
                    pendingStatus = false;
                    chkSelected.Visible = false;
                    panCostCodes.Visible = false;
                    grdChangeOrderView.OptionsBehavior.Editable = true;
                    GetJobCostCodes("9999", jobID);
                    grdChangeOrderView.UpdateCurrentRow();
                }
                else     // (r != null)
                {
                    jobChangeOrderStatus = r["JobChangeOrderStatus"].ToString().Trim();
                    GetJobCostCodes(r["JobChangeOrderID"].ToString(), jobID);
                    jobChangeOrderNumber = r["JobChangeOrderNumber"].ToString().Trim();
                    gridView1.Columns["Selected"].Visible = false;
                    if (r["JobChangeOrderNumber"].ToString().Trim() == "0")
                    {
                        lblAmount.Text = "Contract Amount:";
                        originalContract = true;
                    }
                    else
                    {
                        lblAmount.Text = "Change Order Amt.:";
                        originalContract = false;
                    }
                    pendingStatus = true;
                    SetControlAccess();
                }
            }
            else
            {
                GetJobCostCodes("0", "0");
                originalContract = false;
            }
            isUpdated = false;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            isUpdated = true;
        }

        private void grdChangeOrderView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isUpdatedChangeOrder = true;
            if (e.Column.FieldName == "JobChangeOrderDescription")
            {
                if (jobChangeOrderNumber.Trim() == "0")
                    grdChangeOrderView.Columns["JobChangeOrderDescription"].OptionsColumn.AllowEdit = false;
                else
                    grdChangeOrderView.Columns["JobChangeOrderDescription"].OptionsColumn.AllowEdit = true;
            }



            if (e.Column.FieldName == "JobChangeOrderStatus")
            {

                DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                if (r["JobChangeOrderStatus"].ToString() == "APPROVED")
                {
                    grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].OptionsColumn.AllowEdit = true;
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = true;
                    if (r["JobChangeOrderRequestDate"] == DBNull.Value)
                        r["JobChangeOrderRequestDate"] = r["JobChangeOrderApprovedDate"];
                    if (r["JobChangeOrderRequestedAmount"] == DBNull.Value)
                        r["JobChangeOrderRequestedAmount"] = r["JobChangeOrderApprovedAmount"];
                }
                else
                {
                    grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
                    r["JobChangeOrderApprovedDate"] = DBNull.Value;
                    r["JobChangeOrderApprovedAmount"] = DBNull.Value;
                }
            }
        }

        private void grdChangeOrderView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DialogResult result;


            // Save Job Change Order
            DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);

            result = MessageBox.Show("Save Change Order?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    e.Valid = false;
                    isUpdatedChangeOrder = false;
                    break;
                case DialogResult.No:
                    e.Valid = true;
                    r.CancelEdit();
                    isUpdatedChangeOrder = false;
                    grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]).Delete();
                    break;
                case DialogResult.Yes:
                    // Validate Fields
                    if (r["JobChangeOrderDescription"] == DBNull.Value)
                    {
                        message = "Changer Order Description is Required ..\n";
                        valid = false;
                    }
                    if (r["JobChangeOrderStatus"].ToString() == "APPROVED")
                    {
                        if (r["JobChangeOrderApprovedDate"] == DBNull.Value)
                        {
                            message = message + "Approved Date is Required ..\n";
                            valid = false;
                        }
                        if (r["JobChangeOrderApprovedAmount"] == DBNull.Value)
                        {
                            message = message + "Approved Amount is Required ..\n";
                            valid = false;
                        }
                    }
                    if (r["JobChangeOrderStatus"].ToString() == "PENDING")
                    {
                        if (r["JobChangeOrderRequestDate"] == DBNull.Value)
                        {
                            message = message + "Requested Date is Required ..\n";
                            valid = false;
                        }
                        if (r["JobChangeOrderRequestedAmount"] == DBNull.Value)
                        {
                            message = message + "Requested Amount is Required ..\n";
                            valid = false;
                        }
                    }
                    if (r["JobChangeOrderStatus"] == DBNull.Value)
                    {
                        message = message + "Change Order Status is Requred ..\n";
                        valid = false;
                    }

                    if (valid)
                    {
                        UpdateChangeOrder();
                    }
                    else
                    {
                        MessageBox.Show(message, CCEApplication.ApplicationName);
                        e.Valid = false;
                    }
                    break;

            }

        }

        public void SaveJobChangeOrdder()
        {
            grdChangeOrderView.MovePrev();
            grdChangeOrderView.MoveNext();
        }

        private void grdChangeOrderView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void UpdateChangeOrder()
        {
            // Update the row if Changed
            if (grdChangeOrderView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                this.Cursor = Cursors.AppStarting;
                if (r == null)
                    return;


                // if (!r.IsNull(0))
                {

                    // if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    // {
                    try
                    {
                        JobChangeOrder jobChangeOrder = new JobChangeOrder(r["JobChangeOrderID"].ToString(),
                                                                         jobID,
                                                                         r["JobChangeOrderNumber"].ToString(),
                                                                         r["JobChangeOrderRequestDate"].ToString(),
                                                                         r["JobChangeOrderRequestedAmount"].ToString(),
                                                                         r["JobChangeOrderApprovedDate"].ToString(),
                                                                         r["JobChangeOrderApprovedAmount"].ToString(),
                                                                         r["JobChangeOrderStatus"].ToString(),
                                                                         r["JobChangeOrderDescription"].ToString(),
                                                                         r["JobChangeOrderOwnerNumber"].ToString(),
                                                                         r["JobChangeOrderCCENumber"].ToString(),
                                                                         r["JobChangeOrderUserDescription"].ToString());
                        jobChangeOrder.Save();

                        jobChangeOrderID = jobChangeOrder.JobChangeOrderID;
                        jobChangeOrderNumber = jobChangeOrder.JobChangeOrderNumber;
                        r["JobChangeOrderID"] = jobChangeOrderID;
                        r["JobChangeOrderNumber"] = jobChangeOrderNumber;
                        // Starbuilder
                        if (Convert.ToInt32(jobChangeOrderNumber) == 0)
                        {
                            JobChangeOrder.UpdatePrimaryContract(jobID);
                            isUpdated = true;
                            SaveJobCostCodes();
                        }
                        else
                        {
                            if (trachChangeOrderForStarbuilder)
                                JobChangeOrder.UpdateChangeOrder(jobID, jobChangeOrderID);
                        }
                        //Job.UpdateJobBalance(jobNumber);
                        //GetJobSummary();
                        this.Cursor = Cursors.Default;
                        isUpdatedChangeOrder = false;
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                }
            }
        }

        private void grdChangeOrderView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isUpdatedChangeOrder = true;
            if (e.Column.FieldName == "JobChangeOrderStatus")
            {

                DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                if (r["JobChangeOrderStatus"].ToString() == "APPROVED")
                {
                    grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].OptionsColumn.AllowEdit = true;
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = true;
                    if (r["JobChangeOrderRequestDate"] == DBNull.Value)
                        r["JobChangeOrderRequestDate"] = r["JobChangeOrderApprovedDate"];
                    if (r["JobChangeOrderRequestedAmount"] == DBNull.Value)
                        r["JobChangeOrderRequestedAmount"] = r["JobChangeOrderApprovedAmount"];
                }
                else
                {
                    grdChangeOrderView.Columns["JobChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                    grdChangeOrderView.Columns["JobChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
                    r["JobChangeOrderApprovedDate"] = DBNull.Value;
                    r["JobChangeOrderApprovedAmount"] = DBNull.Value;
                }
            }

        }
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || isClosed || Security.Security.currentJobReadOnly)
            {
                panChangeOrder.Visible = false;
                txtStarbuilderAmount.Visible = false;
                lblStarbuilderAmount.Visible = false;
                txtPercent.Properties.ReadOnly = true;
                txtCalculatedStarbuilder.Properties.ReadOnly = true;
            }

            else
            {
                panChangeOrder.Visible = true;
                txtStarbuilderAmount.Visible = true;
                lblStarbuilderAmount.Visible = true;
                txtPercent.Properties.ReadOnly = false;
                txtCalculatedStarbuilder.Properties.ReadOnly = false;
            }
            {
                gridView1.OptionsBehavior.Editable = false;
                grdChangeOrderView.OptionsBehavior.Editable = false;
                chkSelected.Visible = false;
                panCostCodes.Visible = false;
                grdChangeOrderView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                grdChangeOrderView.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Selected"].Visible = false;
                //txtStarbuilderAmount.Visible = false;
                //lblStarbuilderAmount.Visible = false;
                //txtPercent.Properties.ReadOnly = true;
                //txtCalculatedStarbuilder.Properties.ReadOnly = true;
            }
            /*  else
              {
                  gridView1.OptionsBehavior.Editable = true;
                  grdChangeOrderView.OptionsBehavior.Editable = true;
                  chkSelected.Visible = true;
                  panCostCodes.Visible = true;
                  grdChangeOrderView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

                  grdChangeOrderView.OptionsBehavior.Editable = true;
                  gridView1.OptionsBehavior.Editable = true;
                  gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                  gridView1.Columns["Hours"].OptionsColumn.AllowEdit = true;
                  gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = true;
                  gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                  gridView1.Columns["Unit"].OptionsColumn.AllowEdit = true;
                  gridView1.Columns["Selected"].Visible = true;
                  txtStarbuilderAmount.Visible = true;
                  lblStarbuilderAmount.Visible = true;
                  txtPercent.Properties.ReadOnly = false;
                  txtCalculatedStarbuilder.Properties.ReadOnly = false;
                  if (!phaseIsLoaded)
                  {
                      phaseIsLoaded = true;
                      GetPhaseList();
                  }
              }*/
        }
        //
        private void GetPhaseList()
        {
            if (jobID != "0" && jobID != "")
            {
                cboPhase.Properties.DataSource = StaticTables.PhaseList;
                cboPhase.Properties.DisplayMember = "PhaseDesc";
                cboPhase.Properties.ValueMember = "PhaseID";
                cboPhase.Properties.PopulateColumns();
                cboPhase.Properties.ShowHeader = false;
                cboPhase.Properties.Columns[0].Visible = false;
                cboPhase.Properties.Columns[0].Width = 0;
            }

        }
        //
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataRow r;

                r = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);

                if (r != null)
                {
                    if ((r["Type"].ToString() == "L" || r["Type"].ToString() == "S" || r["Type"].ToString() == "O") && (chkSelected.Visible))
                    {
                        if (SaveJobCostCodes())
                        {
                            frmPhase f = new frmPhase(r["Type"].ToString(), r["Code"].ToString(), r["Title"].ToString(), jobID, r["Phase"].ToString());
                            GetJobCostCodes(jobChangeOrderID, jobID);
                        }
                    }
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isUpdated = true;
            if (e.Column.Caption == "Selected")
            {
                try
                {
                    DataRow dataRow = null;
                    dataRow = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);

                    if (dataRow["Phase"].ToString() == "200" || dataRow["Phase"].ToString() == "300")
                        return;
                    if (dataRow["Phase"].ToString() == "100" && dataRow["Code"].ToString() == "005")
                        return;
                    if (dataRow["Phase"].ToString() == "800" && (dataRow["Code"].ToString() == "093" || dataRow["Code"].ToString() == "288" || dataRow["Code"].ToString() == "299"))
                        return;

                    if (dataRow["Selected"].ToString() == "True")
                    {
                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Hours"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Unit"].OptionsColumn.AllowEdit = true;
                        if (dataRow["User Description"].ToString() == "")
                        {
                            dataRow["User Description"] = dataRow["Description"];
                        }
                    }
                    else
                    {
                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        private void grdChangeOrderView_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (isUpdated)
                e.Allow = SaveJobCostCodes();
        }

        private void cboSelect_EditValueChanged(object sender, EventArgs e)
        {
            string jobNumber = cboSelect.EditValue == null ? String.Empty : cboSelect.EditValue.ToString();
            PopuldateUsingTempate(jobNumber);
            isUpdated = true;
        }

        private void PopuldateUsingTempate(string jobNumber)
        {
            //
            // Backup the original codes
            //
            if (jobCodeDataSet != null)
            {
                if (jobCodeDataSetB != null)
                    jobCodeDataSetB.Tables[0].Rows.Clear();
                else
                {
                    jobCodeDataSetB = jobCodeDataSet.Clone();
                }

                if (jobCodeDataSet != null)
                {
                    DataRow row;
                    for (int i = 0; i < jobCodeDataSet.Tables[0].Rows.Count; i++)
                    {
                        row = jobCodeDataSetB.Tables[0].NewRow();
                        for (int j = 0; j < jobCodeDataSet.Tables[0].Columns.Count; j++)
                            row[j] = jobCodeDataSet.Tables[0].Rows[i][j];
                        // row = jobCodeDataSet.Tables[0].Rows[i];
                        jobCodeDataSetB.Tables[0].Rows.Add(row);
                        row = null;
                    }
                }

                DataTable table = JobCost.GetJobTemplate(jobNumber).Tables[0];
                //
                // Temporaty Flagged not to update
                //  foreach (DataRow r in jobCodeDataSet.Tables[0].Rows)
                //      r["Selected"] = false;
                if (table.Rows.Count > 0)
                {

                    foreach (DataRow r in jobCodeDataSet.Tables[0].Rows)
                    {

                        string query = "JobCostCodeType = '" + r["Type"].ToString() + "' AND " +
                              " JobCostCodePhase = '" + r["Phase"].ToString() + "' AND " +
                              " CostCode = '" + r["Code"].ToString() + "' ";
                        DataRow[] m = table.Select(query);
                        if (m.Length > 0)
                        {
                            r["Selected"] = true;
                            r[9] = m[0]["UserDescription"];
                            r[10] = m[0]["Unit"];
                        }
                    }
                }
            }
        }
        private void RestoreDataset()
        {
            if (jobCodeDataSetB != null)
            {
                if (jobCodeDataSetB.Tables[0].Rows.Count > 0)
                {
                    jobCodeDataSet.Tables[0].Rows.Clear();

                    DataRow row;
                    for (int i = 0; i < jobCodeDataSetB.Tables[0].Rows.Count; i++)
                    {
                        row = jobCodeDataSet.Tables[0].NewRow();
                        for (int j = 0; j < jobCodeDataSetB.Tables[0].Columns.Count; j++)
                            row[j] = jobCodeDataSetB.Tables[0].Rows[i][j];
                        // row = jobCodeDataSet.Tables[0].Rows[i];
                        jobCodeDataSet.Tables[0].Rows.Add(row);
                        row = null;
                    }


                }
            }
        }
        //
        private void txtStarbuilderAmount_EditValueChanged(object sender, EventArgs e)
        {
            // btnUpdateStarBuilder.Visible = true;
        }
        //
        private void btnUpdateStarBuilder_Click(object sender, EventArgs e)
        {
            // Update Primaty Contract for TM
            // Update JobBalance Original Contract
            JobChangeOrder.UpdateTMContractAmount(jobID, txtCalculatedStarbuilder.Text.Replace("$", "").Replace(",", ""));
            JobChangeOrder.UpdatePrimaryContract(jobID);
            btnUpdateStarBuilder.Visible = false;
            StarbuilderEventArgs arg = new StarbuilderEventArgs(true);
            OnStarbuiler(arg);

        }


        //
        private void view_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void view_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DialogResult result;



            DataRowView r = (DataRowView)e.Row;

            result = MessageBox.Show("Save Comment?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    e.Valid = false;
                    break;
                case DialogResult.No:
                    e.Valid = true;
                    r.CancelEdit();
                    break;
                case DialogResult.Yes:
                    if (r["Comment"] == DBNull.Value)
                    {
                        message = message + "Comment is Requred ..\n";
                        valid = false;
                    }

                    if (valid)
                    {
                        UpdateChangeOrderComment(r);
                        e.Valid = true;

                    }
                    else
                    {
                        MessageBox.Show(message, CCEApplication.ApplicationName);
                        e.Valid = false;
                    }
                    break;


            }
        }
        //
        void UpdateChangeOrderComment(DataRowView r)
        {
            DataRow row = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);

            r["LastUpdateDate"] = DateTime.Today.Date;
            r["UserID"] = Security.Security.LoginID;

            ChangeOrderComment comment = new ChangeOrderComment(r["JobChangeOrderCommentID"].ToString(),
                                    row["JobChangeOrderID"].ToString(),
                                    r["Comment"].ToString(),
                                    r["LastUpdateDate"].ToString(),
                                    r["UserID"].ToString());
            comment.Save();
            r["JobChangeOrderCommentID"] = comment.JobChangeOrderCommentID;
            r["JobChangeOrderID"] = row["JobChangeOrderID"].ToString();

        }
        //
        private void cboSelect_Properties_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (e.DisplayValue.ToString() == "")
            {
                e.Handled = true;
                RestoreDataset();
                this.grdCostCode.DataSource = jobCodeDataSet.Tables[0].DefaultView;
                gridView1.RefreshData();
            }
        }

        private void txtPercent_EditValueChanged(object sender, EventArgs e)
        {
            btnUpdateStarBuilder.Visible = true;
            CalculateActualStarbuilder();
        }
        //
        private void txtCalculatedStarbuilder_EditValueChanged(object sender, EventArgs e)
        {
            btnUpdateStarBuilder.Visible = true;
            //CalculateActualStarbuilder();
        }
        //
        private void CalculateActualStarbuilder()
        {
            double actualToDate = 0;
            double percent = 0;
            double recommendedContractAmount = 0;
            double calculatedStarbuilder = 0;

            if (txtActualToDate.Text.Trim().Length > 0 &&
               Convert.ToDouble(txtActualToDate.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) > 0)
                actualToDate = Convert.ToDouble(txtActualToDate.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", ""));
            if (txtPercent.Text.Trim().Length > 0 &&
                Convert.ToDouble(txtPercent.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) > 0)
                percent = Convert.ToDouble(txtPercent.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", ""));

            if (actualToDate > 0 || percent > 0)
                calculatedStarbuilder = (actualToDate / (1 - percent / 100));
            else
                calculatedStarbuilder = 0;
            recommendedContractAmount = calculatedStarbuilder - actualToDate;
            txtRecommendedContractAmount.Text = recommendedContractAmount.ToString();
            txtCalculatedStarbuilder.Text = calculatedStarbuilder.ToString();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (cboPhase.EditValue != null)
            {
              //  var jobid = cboPhase.GetColumnValue("job");
                var phase = cboPhase.GetColumnValue("phase").ToString();
                DataTable t = JobCost.GetPhaseCodes(cboPhase.EditValue.ToString(), jobID, phase).Tables[0];

                foreach (DataRow r in t.Rows)
                {

                    string query = "Type = '" + r["Type"].ToString() + "' AND " +
                          " Phase = '" + r["Phase"].ToString() + "' AND " +
                          " Code = '" + r["Code"].ToString() + "' ";
                    DataRow[] m = jobCodeDataSet.Tables[0].Select(query);
                    if (m.Length == 0)
                    {
                        jobCodeDataSet.Tables[0].ImportRow(r);

                    }
                }
                cboPhase.EditValue = null;
            }
        }

        private void grdChangeOrderView_DoubleClick(object sender, EventArgs e)
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
            Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || isClosed)
            {
            }
            else
            {
                try
                {
                    DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                    if (r == null)
                        return;
                    frmChangeOrder f = new frmChangeOrder(r[0].ToString(), jobID, bindingSource,false);
                    f.ShowDialog();
                    GetJobDetail();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmChangeOrder f = new frmChangeOrder("0", jobID, bindingSource,true);
            f.ShowDialog();
            GetJobDetail();
        }

        private void grdChangeOrderView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdChangeOrderView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdChangeOrderView.Columns)
                {
                    if (col.FilterInfo.FilterCriteria != null)
                    {
                        if (col.FilterInfo.FilterCriteria.ToString().Length > 0)
                        {
                            criteria += col.FilterInfo.FilterCriteria.ToString();
                            criteria += " AND ";
                        }
                    }
                }
                if (criteria.Length > 0)
                    criteria = criteria.Substring(0, criteria.Length - 4);
                jobChangeOrders.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
            }
            catch
            {
            }
        }

        private void grdChangeOrderView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1) return;
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                ColumnSortOrder sort = info.Column.SortOrder;
                string command = info.Column.FieldName;
                if (info.Column.SortOrder == ColumnSortOrder.Ascending)
                {
                    command += " DESC";
                    reportSort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    reportSort = info.Column.Caption + " ASC";
                }
                jobChangeOrders.DefaultView.Sort = command;
            }
        }

        private void grdChangeOrderView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void gridView1_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedd = true;
        }
    }
    //
    public class StarbuilderEventArgs : EventArgs
    {
        private bool starbuilderButtonPressed;

        public StarbuilderEventArgs(bool starbuilderButtonPressed)
        {
            this.starbuilderButtonPressed = starbuilderButtonPressed;
        }
    }
}
