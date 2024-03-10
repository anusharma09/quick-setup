using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;

namespace CCEJobs.Subcontracts
{
    public partial class ctlSubcontractBudget : UserControl
    {
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private string subcontractID;
        private string subcontractChangeOrderID = "0";
        private string subcontractChangeOrderNumber;
        private bool isUpdated = false;
        private DataTable subcontractChangeOrders; 
        private bool originalContract = false; 
        private bool pendingStatus = false;
        private DataSet subcontractCodeDataSet;
        string subcontractChangeOrderStatus = "";
        //
        public ctlSubcontractBudget()
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
        //
        public string SubcontractID
        {
            set
            {
                subcontractID = value;
                if (subcontractID == "")
                    subcontractID = "0";
                GetSubcontractDetail();
                GetCurrentChangeOrderDetail();
                isUpdated = false;
                SetControlAccess();

            }
        }
        //
        public bool IsUpdated
        {
            get { return isUpdated; }
        }
        //
        public string SubcontractChangeOrderID
        {
            get
            {
                return subcontractChangeOrderID;
            }
        }
        //
        private void ctlSubcontractBudget_Load(object sender, EventArgs e)
        {
            if( String.IsNullOrEmpty(subcontractID))
                subcontractID = "0";
            GetSubcontractChangeOrders();

        }

     
         private void GetSubcontractDetail()
        {
            GetSubcontractChangeOrders();
            if (grdChangeOrderView.RowCount > 0)
                grdChangeOrderView.Focus();
            isUpdated = false;           
        }

        private void GetSubcontractChangeOrders()
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                subcontractChangeOrders = SubcontractChangeOrder.GetSubcontractChangeOrders(subcontractID).Tables[0];
                if (subcontractChangeOrders.Rows.Count > 0)
                {

                    grdChangeOrder.DataSource = subcontractChangeOrders.DefaultView;
                    grdChangeOrderView.Columns["SubcontractChangeOrderID"].Visible = false;
                    grdChangeOrderView.Columns["SubcontractID"].Visible = false;
                    grdChangeOrderView.Columns["SubcontractChangeOrderNumber"].Caption = "CO #";
                    grdChangeOrderView.Columns["SubcontractChangeOrderNumber"].ColumnEdit = repChangeOrderNumber;
                    grdChangeOrderView.Columns["SubcontractChangeOrderRequestDate"].Caption = "Requested Date";
                    grdChangeOrderView.Columns["SubcontractChangeOrderRequestedAmount"].Caption = "Requested Amount";
                    grdChangeOrderView.Columns["SubcontractChangeOrderRequestedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["SubcontractChangeOrderRequestedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].Caption = "Approved Date";
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].Caption = "Approved Amount";
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].Caption = "Status";
                    grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].ColumnEdit = repDescription;
                    grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].VisibleIndex = 1;
                    grdChangeOrderView.Columns["SubcontractChangeOrderUserDescription"].Caption = "Description";
                    grdChangeOrderView.Columns["SubcontractChangeOrderUserDescription"].ColumnEdit = repUserDescription;
                    grdChangeOrderView.Columns["SubcontractChangeOrderUserDescription"].VisibleIndex = 2;
                    grdChangeOrderView.Columns["SubcontractChangeOrderUpdateFlag"].Caption = "Update Flag";
                    grdChangeOrderView.Columns["SubcontractChangeOrderUpdateFlag"].Visible = false;
                    grdChangeOrderView.Columns["SubcontractChangeOrderUpdateFlag"].ColumnEdit = repUpdateFlag;
                    grdChangeOrderView.Columns["SubcontractChangeOrderLastUpdate"].Caption = "Last Update";
                    grdChangeOrderView.Columns["SubcontractChangeOrderLastUpdate"].ColumnEdit = repLastUpdate;
                    grdChangeOrderView.Columns["SubcontractChangeOrderOwnerNumber"].Caption = "Owner C/O No";
                    grdChangeOrderView.Columns["SubcontractChangeOrderOwnerNumber"].VisibleIndex = 3;
                    grdChangeOrderView.Columns["SubcontractChangeOrderOwnerNumber"].ColumnEdit = repOwnerChangerOrderNumber;
                    grdChangeOrderView.Columns["SubcontractChangeOrderStatus"].Caption = "Status";
                    grdChangeOrderView.Columns["SubcontractChangeOrderStatus"].VisibleIndex = 6;
                    grdChangeOrderView.Columns["SubcontractChangeOrderStatus"].ColumnEdit = repStatus;
                    grdChangeOrderView.Columns["SubcontractChangeOrderRequestedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["SubcontractChangeOrderRequestedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].DisplayFormat.FormatString = "{0:c2}";
                    grdChangeOrderView.Columns["SubcontractChangeOrderNumber"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    grdChangeOrderView.Columns["SubcontractChangeOrderNumber"].SummaryItem.DisplayFormat = "Total: {0:n0}";
                    grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].ColumnEdit = JCCBusinessLayer.RepositoryItems.changeOrderDescription;
                    grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].Width = 200;
                    grdChangeOrderView.BestFitColumns();
                }
                GetSubcontractSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
            }
        }
        private void GetSubcontractSummary()
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                // Subcontract Summary
                DataTable table = Subcontract.GetSubcontractSummary(subcontractID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    txtOriginalContractAmount.Text = table.Rows[0]["OriginalContract"].ToString();
                    txtApprovedCOAmount.Text = table.Rows[0]["ApprovedChanges"].ToString();
                    txtPendingCOWithProceedAmount.Text = table.Rows[0]["PendingChanges"].ToString();
                    txtCurrentContractAmount.Text = table.Rows[0]["CurrentContract"].ToString();
                    txtOriginalContractCost.Text = table.Rows[0]["TotalOriginalContractCost"].ToString();
                    txtTotalApprovedCost.Text = table.Rows[0]["TotalApprovalCost"].ToString();
                    txtTotalPendingCost.Text = table.Rows[0]["TotalPendingCost"].ToString();
                    txtTotalInvoice.Text = table.Rows[0]["TotalInvoice"].ToString();
                    txtTotalRetainage.Text = table.Rows[0]["TotalRetainage"].ToString();
                    txtTotalAmountPaid.Text = table.Rows[0]["TotalAmountPaid"].ToString();
                    txtTotalBackChanges.Text = table.Rows[0]["TotalBackCharges"].ToString();
                    txtLastBilledDate.Text =  table.Rows[0]["LastBilledDate"] == DBNull.Value ? "" :   table.Rows[0]["LastBilledDate"].ToString().Substring(0, 10);
                    txtLastPaymentDate.Text = table.Rows[0]["LastPaymentDate"] == DBNull.Value ? "" : table.Rows[0]["LastPaymentDate"].ToString().Substring(0, 10);
                }
                else
                {
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }


        }

        private void grdChangeOrderView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentChangeOrderDetail();
            if (jobCaller == Security.Security.JobCaller.JCCDashboard || Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                return;
            if (grdChangeOrderView.Columns.Count == 0)
                return;
            if (subcontractChangeOrderNumber.Trim() == "0")
                grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].OptionsColumn.AllowEdit = false;
            else
                grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].OptionsColumn.AllowEdit = true;

            DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
            if (r != null && r["SubcontractChangeOrderStatus"].ToString() == "APPROVED")
            {
                grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["SubcontractChangeOrderRequestDate"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["SubcontractChangeOrderRequestedAmount"].OptionsColumn.AllowEdit = false;
            }
            else
            {
                grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["SubcontractChangeOrderRequestDate"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["SubcontractChangeOrderRequestedAmount"].OptionsColumn.AllowEdit = true;
            }
            if (r == null)
            {
                grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].OptionsColumn.AllowEdit = true;
                grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
            }
        }

        private void GetCurrentChangeOrderDetail()
        {
            if (isUpdated)
            {
                SaveSubcontractCostCodes();
                isUpdated = false;
            }


            DataRow r;
            chkSelected.Visible = false;
            if (grdChangeOrderView.SelectedRowsCount != 0)
            {
                r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);

                if (r == null)
                {
                    pendingStatus = false;
                    chkSelected.Visible = false;
                    grdChangeOrderView.OptionsBehavior.Editable = true;
                    GetSubcontractCostCodes("9999", subcontractID);
                    grdChangeOrderView.UpdateCurrentRow();
                }
                else     
                {
                    subcontractChangeOrderStatus = r["SubcontractChangeOrderStatus"].ToString().Trim();
                    GetSubcontractCostCodes(r["SubcontractChangeOrderID"].ToString(), subcontractID);
                    subcontractChangeOrderNumber = r["SubcontractChangeOrderNumber"].ToString().Trim();
                    gridView1.Columns["Selected"].Visible = false;
                    if (r["SubcontractChangeOrderNumber"].ToString().Trim() == "0")
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
                GetSubcontractCostCodes("0", "0");
                originalContract = false;
            }
            isUpdated = false;
        }

        private void grdChangeOrderView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SubcontractChangeOrderDescription")
            {
                if (subcontractChangeOrderNumber.Trim() == "0")
                    grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].OptionsColumn.AllowEdit = false;
                else
                    grdChangeOrderView.Columns["SubcontractChangeOrderDescription"].OptionsColumn.AllowEdit = true;
            }
            if (e.Column.FieldName == "SubcontractChangeOrderStatus")
            {

                DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                if (r["SubcontractChangeOrderStatus"].ToString() == "APPROVED")
                {
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].OptionsColumn.AllowEdit = true;
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = true;
                    if (r["SubcontractChangeOrderRequestDate"] == DBNull.Value)
                        r["SubcontractChangeOrderRequestDate"] = r["SubcontractChangeOrderApprovedDate"];
                    if (r["SubcontractChangeOrderRequestedAmount"] == DBNull.Value)
                        r["SubcontractChangeOrderRequestedAmount"] = r["SubcontractChangeOrderApprovedAmount"];
                }
                else
                {
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
                    r["SubcontractChangeOrderApprovedDate"] = DBNull.Value;
                    r["SubcontractChangeOrderApprovedAmount"] = DBNull.Value;
                }
            }
        }

        private void grdChangeOrderView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SubcontractChangeOrderStatus")
            {

                DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                if (r["SubcontractChangeOrderStatus"].ToString() == "APPROVED")
                {
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].OptionsColumn.AllowEdit = true;
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = true;
                    if (r["SubcontractChangeOrderRequestDate"] == DBNull.Value)
                        r["SubcontractChangeOrderRequestDate"] = r["SubcontractChangeOrderApprovedDate"];
                    if (r["SubcontractChangeOrderRequestedAmount"] == DBNull.Value)
                        r["SubcontractChangeOrderRequestedAmount"] = r["SubcontractChangeOrderApprovedAmount"];
                }
                else
                {
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedDate"].OptionsColumn.AllowEdit = false;
                    grdChangeOrderView.Columns["SubcontractChangeOrderApprovedAmount"].OptionsColumn.AllowEdit = false;
                    r["SubcontractChangeOrderApprovedDate"] = DBNull.Value;
                    r["SubcontractChangeOrderApprovedAmount"] = DBNull.Value;
                }
            }
        }

        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (subcontractCodeDataSet != null)
            {
                if (chkSelected.Checked.ToString() == "True")
                    subcontractCodeDataSet.Tables[0].DefaultView.RowFilter = "Selected = True";
                else
                    subcontractCodeDataSet.Tables[0].DefaultView.RowFilter = "";
            }
        }

        private void grdChangeOrderView_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (isUpdated)
                e.Allow = SaveSubcontractCostCodes();
        }

        private void grdChangeOrderView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdChangeOrderView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DialogResult result;



            DataRow r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);

            result = MessageBox.Show("Save Change Order?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

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
                    // Validate Fields
                    if (r["SubcontractChangeOrderDescription"] == DBNull.Value)
                    {
                        message = "Changer Order Description is Required ..\n";
                        valid = false;
                    }
                    if (r["SubcontractChangeOrderStatus"].ToString() == "APPROVED")
                    {
                        if (r["SubcontractChangeOrderApprovedDate"] == DBNull.Value)
                        {
                            message = message + "Approved Date is Required ..\n";
                            valid = false;
                        }
                        if (r["SubcontractChangeOrderApprovedAmount"] == DBNull.Value)
                        {
                            message = message + "Approved Amount is Required ..\n";
                            valid = false;
                        }
                    }
                    if (r["SubcontractChangeOrderStatus"].ToString() == "PENDING")
                    {
                        if (r["SubcontractChangeOrderRequestDate"] == DBNull.Value)
                        {
                            message = message + "Requested Date is Required ..\n";
                            valid = false;
                        }
                        if (r["SubcontractChangeOrderRequestedAmount"] == DBNull.Value)
                        {
                            message = message + "Requested Amount is Required ..\n";
                            valid = false;
                        }
                    }
                    if (r["SubcontractChangeOrderStatus"] == DBNull.Value)
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
                        MessageBox.Show(message,  CCEApplication.ApplicationName);
                        e.Valid = false;
                    }
                    break;

            }
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
                        SubcontractChangeOrder subcontractChangeOrder = new SubcontractChangeOrder(r["SubcontractChangeOrderID"].ToString(),
                                                                         subcontractID,
                                                                         r["SubcontractChangeOrderNumber"].ToString(),
                                                                         r["SubcontractChangeOrderRequestDate"].ToString(),
                                                                         r["SubcontractChangeOrderRequestedAmount"].ToString(),
                                                                         r["SubcontractChangeOrderApprovedDate"].ToString(),
                                                                         r["SubcontractChangeOrderApprovedAmount"].ToString(),
                                                                         r["SubcontractChangeOrderStatus"].ToString(),
                                                                         r["SubcontractChangeOrderDescription"].ToString(),
                                                                         r["SubcontractChangeOrderOwnerNumber"].ToString(),
                                                                         r["SubcontractChangeOrderUserDescription"].ToString());
                        subcontractChangeOrder.Save();

                        subcontractChangeOrderID = subcontractChangeOrder.SubcontractChangeOrderID;
    
                        subcontractChangeOrderNumber = subcontractChangeOrder.SubcontractChangeOrderNumber;
                        r["SubcontractChangeOrderID"] = subcontractChangeOrderID;
                        r["SubcontractChangeOrderNumber"] = subcontractChangeOrderNumber;
                        // /////////////////////////
                        // Starbuilder
                        // ///////////////////////////
                        SubcontractChangeOrder.UpdateChangeOrder(subcontractID, subcontractChangeOrderID);
                        //
                        Subcontract.UpdateSubcontractBalance(subcontractID);
                       
                        GetSubcontractSummary();
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                }
            }
        }

        

        private void GetSubcontractCostCodes(string subcontractChangeOrderID, string subcontractID)
        {
            try
            {
                subcontractCodeDataSet = SubcontractChangeOrder.GetCostCode(subcontractChangeOrderID, subcontractID);

                this.grdCostCode.DataSource = subcontractCodeDataSet.Tables[0].DefaultView;
                if (chkSelected.Checked)
                subcontractCodeDataSet.Tables[0].DefaultView.RowFilter = "Selected = True";
                gridView1.Columns["Type"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Phase"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Code"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Title"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Description"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["SubcontractCostCodeID"].Visible = false;
                gridView1.Columns["SubcontractChangeOrderID"].Visible = false;
                gridView1.Columns["SubcontractCostCodePhaseID"].Visible = false;
                gridView1.Columns["Cost $"].ColumnEdit = txtMaterialCost;
                gridView1.Columns["Cost $"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Cost $"].SummaryItem.DisplayFormat = "{0:c2}";
                this.subcontractChangeOrderID = subcontractChangeOrderID;
                //
                DataRow r;

                if (grdChangeOrderView.SelectedRowsCount > 0)
                {
                    r = grdChangeOrderView.GetDataRow(grdChangeOrderView.GetSelectedRows()[0]);
                    if (r != null)
                    {
                        //txtContractAmount.Text = gridView1.Columns["Cost $"].SummaryItem.SummaryValue.ToString();
                        if (r["SubcontractChangeOrderApprovedAmount"].ToString().Length > 0
                                && Convert.ToDouble(r["SubcontractChangeOrderApprovedAmount"].ToString().Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) > 0)
                            txtContractAmount.Text = r["SubcontractChangeOrderApprovedAmount"].ToString();
                        else
                            txtContractAmount.Text = r["SubcontractChangeOrderRequestedAmount"].ToString();
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
        }


        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly )
          
            {
                gridView1.OptionsBehavior.Editable = false;
                grdChangeOrderView.OptionsBehavior.Editable = false;
                chkSelected.Visible = false;
                grdChangeOrderView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                chkSelected.Visible = false;
                chkSelected.Checked = true;
                grdChangeOrderView.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Selected"].Visible = false;

            }
            else
            {
                gridView1.OptionsBehavior.Editable = true;
                grdChangeOrderView.OptionsBehavior.Editable = true;
                chkSelected.Visible = true;
                grdChangeOrderView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

                chkSelected.Visible = true;
                chkSelected.Checked = true;
                grdChangeOrderView.OptionsBehavior.Editable = true;
                gridView1.OptionsBehavior.Editable = true;
                gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Selected"].Visible = true;

            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Selected")
            {
                try
                {
                    DataRow dataRow = null;
                    dataRow = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);

                    if (dataRow["Selected"].ToString() == "True")
                    {
                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                        if (dataRow["User Description"].ToString() == "")
                        {
                            dataRow["User Description"] = dataRow["Description"];
                        }
                    }
                    else
                    {
                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                    }

                }
                catch (Exception ex) { }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
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

                if (gridView1.Columns.Count > 0)
                {
                    if (dataRow["Selected"].ToString() == "True")
                    {

                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                        if (dataRow["User Description"].ToString() == "")
                        {
                            dataRow["User Description"] = dataRow["Description"];
                        }

                    }
                    else
                    {
                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                    }
                }

            }
            catch (Exception ex) { }

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            isUpdated = true;
        }

        public bool SaveSubcontractCostCodes()
        {

            if (!isUpdated)
                return true;
            DialogResult result;
            bool ret = true;
            result = MessageBox.Show("Save Subcontract Cost Code Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    ret = false;
                    break;
                case DialogResult.No:
                    isUpdated = false;
                    GetSubcontractCostCodes(subcontractChangeOrderID, subcontractID);
                    ret = true;
                    break;
                case DialogResult.Yes:
                    try
                    {
                        this.Cursor = Cursors.AppStarting;
                        // Atef

                        SubcontractCost subcontractCost;
                        foreach (DataRow r in subcontractCodeDataSet.Tables[0].Rows)
                        {
                            if (r.RowState != DataRowState.Unchanged)
                            {
                                if (r["Selected"].ToString() == "True" && r["SubcontractCostCodeID"].ToString() != "")
                                {
                                    subcontractCost = new SubcontractCost(r["SubcontractCostCodeID"].ToString(),
                                                                            subcontractChangeOrderID,
                                                                            subcontractChangeOrderNumber,
                                                                            r["SubcontractCostCodePhaseID"].ToString(),
                                                                            r["User Description"].ToString(),
                                                                            r["Cost $"].ToString(),
                                                                            subcontractID,
                                                                            r["Type"].ToString(),
                                                                            r["Phase"].ToString(),
                                                                            r["Code"].ToString(),
                                                                            r["Title"].ToString(),
                                                                            r["Description"].ToString());
                                    subcontractCost.Save();
                                }
                                // Delete Record - Do Not Delete Just Zero Cost Out
                                if (r["Selected"].ToString() != "True" && r["SubcontractCostCodeID"].ToString() != "")
                                {
                                   
                                   // SubcontractCost.Remove(r["SubcontractCostCodeID"].ToString());

                                    subcontractCost = new SubcontractCost(r["SubcontractCostCodeID"].ToString(),
                                                                          subcontractChangeOrderID,
                                                                          subcontractChangeOrderNumber,
                                                                          r["SubcontractCostCodePhaseID"].ToString(),
                                                                          r["User Description"].ToString(),
                                                                          "0",             // r["Cost $"].ToString(),
                                                                          subcontractID,
                                                                          r["Type"].ToString(),
                                                                          r["Phase"].ToString(),
                                                                          r["Code"].ToString(),
                                                                          r["Title"].ToString(),
                                                                          r["Description"].ToString());
                                    subcontractCost.Save();
                                    r["Selected"] = "True";

                                }
                                // Insert Record
                                if (r["Selected"].ToString() == "True" && r["SubcontractCostCodeID"].ToString() == "")
                                {
                                    subcontractCost = new SubcontractCost(r["SubcontractCostCodeID"].ToString(),
                                                                             subcontractChangeOrderID,
                                                                             subcontractChangeOrderNumber,
                                                                             r["SubcontractCostCodePhaseID"].ToString(),
                                                                             r["User Description"].ToString(),
                                                                             r["Cost $"].ToString(),
                                                                             subcontractID,
                                                                             r["Type"].ToString(),
                                                                             r["Phase"].ToString(),
                                                                             r["Code"].ToString(),
                                                                             r["Title"].ToString(),
                                                                             r["Description"].ToString());
                                    subcontractCost.Save();
                                }
                            }
                        }
                        //
                        // Starbuilder
                        //

                        SubcontractChangeOrder.UpdateChangeOrderCostCodes(subcontractID, subcontractChangeOrderNumber);

                        Subcontract.UpdateSubcontractBalance(subcontractID);
                        GetSubcontractSummary();
                        this.Cursor = Cursors.Default;
                        ret = true;

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }

                    isUpdated = false;
                    break;
            }
            return ret;

        }
    }
}
