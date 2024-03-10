using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCPurchasing.BusinessLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace JCCPurchasing.Controls
{
    public enum POListView
    {
        Job,
        Category,
        Vendor,
        PurchasingAgent,
        projectManager,
        List
    }
    //
    public partial class ctlPOList : UserControl
    {
        private POListView poListView = POListView.List;
        DataTable poTable;
        private bool isAdHoc = false;
        string query;
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;
        public ctlPOList()
        {
            InitializeComponent();
            if (!StaticTables.isloaded)
                StaticTables.PopulateStaticTables();
            GetPOList(" Where j.JobNumber = '0' ");
            initialScreen = false;
        }
        //
        private void ctlPOList_Load(object sender, EventArgs e)
        {
            cboCategory.Properties.Items.Clear();
            cboCategory.Properties.Items.Add("");
            cboCategory.Properties.Items.Add("Automotive");
            cboCategory.Properties.Items.Add("Capital");
            cboCategory.Properties.Items.Add("Equipment");
            cboCategory.Properties.Items.Add("Instrument");
            cboCategory.Properties.Items.Add("Material");
            cboCategory.Properties.Items.Add("Other");
            cboCategory.Properties.Items.Add("Rental");
            cboCategory.Properties.Items.Add("Sub Contract");
            cboCategory.Properties.Items.Add("Tools");
            cboCategory.Properties.Items.Add("Wharehouse");
            cboPurchasingAgent.Properties.DataSource = StaticTables.PurchasingAgents;
            cboPurchasingAgent.Properties.DisplayMember = "PurchasingAgent";
            cboPurchasingAgent.Properties.ShowHeader = false;
            cboVendor.Properties.DataSource = StaticTables.Vendors;
            cboVendor.Properties.DisplayMember = "Name";
            cboVendor.Properties.ValueMember = "VendorID";
            cboVendor.Properties.PopulateColumns();
            cboVendor.Properties.ShowHeader = false;
            cboProjectManager.Properties.DataSource = StaticTables.ProjectManager;
            cboProjectManager.Properties.DisplayMember = "ProjectManager";
            cboProjectManager.Properties.ValueMember = "ProjectManagerID";
            cboProjectManager.Properties.PopulateColumns();
            cboProjectManager.Properties.ShowHeader = false;
            cboProjectManager.Properties.Columns[0].Visible = false;
            //
            cboReport.Properties.Items.Add("Ad Hoc");
            cboReport.Properties.Items.Add("Purchase Order");
            cboReport.Properties.Items.Add("Purchase Order Received Items");
            cboReport.Properties.Items.Add("Purchase Order Invoices");
            cboReport.Properties.Items.Add("Purchase Orders List By PO Type");
            cboReport.Properties.Items.Add("Purchase Orders List Greater or Equal $5,000");
            cboReport.Properties.Items.Add("Purchase Orders List By Work Order");
            cboReport.Properties.Items.Add("Purchase Orders List by Supplier");
            cboReport.Properties.Items.Add("POs Without Invoices");  
            cboReport.Properties.Items.Add("POs Invoices with Different Job Number");
            cboReport.Properties.Items.Add("Missing PO Numbers");
        }
        //
        private void GetPOList(string where)
        {
            if (!initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
            try
            {
                poTable = PO.GetPOList(where).Tables[0];
                grdPOList.DataSource = poTable;
                grdPOList.MainView.PopulateColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }

            finally
            {
                FormatGrid();
                RestoreCustomization();
                UpdateListView(poListView);
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (poTable.Rows.Count == 0)
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }
            }
        }
        //
        private void FormatGrid()
        {
            grdPOListView.Columns["PO"].Caption = "PO    ";
            grdPOListView.Columns["JobName"].Caption = "Job Name          ";
            grdPOListView.Columns["Freight"].Caption = "Freight   ";
            grdPOListView.Columns["Tax"].Caption = "Tax      ";
            grdPOListView.Columns["Category"].Caption = "Category   ";
            grdPOListView.Columns["Variance"].Caption = "Variance   ";
            grdPOListView.Columns["ProjectManager"].Caption = "Project Manager";
            grdPOListView.Columns["PurchasingAgent"].Caption = "Purchasing Agent";
            grdPOListView.Columns["Gross Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdPOListView.Columns["Gross Amt"].DisplayFormat.FormatString = "{0:c2}";
            grdPOListView.Columns["Net Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdPOListView.Columns["Net Amt"].DisplayFormat.FormatString = "{0:c2}";
            grdPOListView.Columns["Tax"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdPOListView.Columns["Tax"].DisplayFormat.FormatString = "{0:c2}";
            grdPOListView.Columns["Freight"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdPOListView.Columns["Freight"].DisplayFormat.FormatString = "{0:c2}";
            grdPOListView.Columns["Variance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdPOListView.Columns["Variance"].DisplayFormat.FormatString = "{0:c2}";
            grdPOListView.Columns["Remaining Balance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdPOListView.Columns["Remaining Balance"].DisplayFormat.FormatString = "{0:c2}";
            grdPOListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Gross Amt", grdPOListView.Columns["Gross Amt"], "{0:c2}");
            grdPOListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Net Amt", grdPOListView.Columns["Net Amt"], "{0:c2}");
            grdPOListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Tax", grdPOListView.Columns["Tax"], "{0:c2}");
            grdPOListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Variance", grdPOListView.Columns["Variance"], "{0:c2}");
            grdPOListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Remaining Balance", grdPOListView.Columns["Remaining Balance"], "{0:c2}");
            grdPOListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "PO", grdPOListView.Columns["PO"], "{0:n0}");
            grdPOListView.Columns["Gross Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPOListView.Columns["Gross Amt"].SummaryItem.DisplayFormat = "{0:c2}";
            grdPOListView.Columns["Net Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPOListView.Columns["Net Amt"].SummaryItem.DisplayFormat = "{0:c2}";
            grdPOListView.Columns["Tax"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPOListView.Columns["Tax"].SummaryItem.DisplayFormat = "{0:c2}";
            grdPOListView.Columns["Freight"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPOListView.Columns["Freight"].SummaryItem.DisplayFormat = "{0:c2}";
            grdPOListView.Columns["Variance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPOListView.Columns["Variance"].SummaryItem.DisplayFormat = "{0:c2}";
            grdPOListView.Columns["Remaining Balance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPOListView.Columns["Remaining Balance"].SummaryItem.DisplayFormat = "{0:c2}";
            grdPOListView.Columns["PO"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdPOListView.Columns["PO"].SummaryItem.DisplayFormat = "{0:n0}";

            grdPOListView.Columns["PO"].Caption = "PO    ";
            grdPOListView.Columns["Job Number"].Caption = "Job #     ";
            grdPOListView.Columns["JobName"].Caption = "Job Name          ";
            grdPOListView.Columns["Freight"].Caption = "Freight   ";
            grdPOListView.Columns["Tax"].Caption = "Tax      ";
            grdPOListView.Columns["Category"].Caption = "Category   ";
            grdPOListView.Columns["Variance"].Caption = "Variance   ";
            grdPOListView.Columns["ProjectManager"].Caption = "Project Manager    ";
            grdPOListView.Columns["PurchasingAgent"].Caption = "Purchasing Agent     ";
            //grdPOListView.Columns["PO Status"].Caption = "PO Status   ";
            //grdPOListView.Columns["Last Inv Date"].Caption = "Last Ins Date  ";
            //grdPOListView.Columns["Remaining Balance"].Caption = "Remaining Balance  ";
            //grdPOListView.Columns["Work Order"].Caption = "Work Order   ";

            //grdPOListView.BestFitColumns();
        }

        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            query = " WHERE p.PO NOT LIKE 'N/A%' AND  ";

            if( !String.IsNullOrEmpty(txtPONumber.Text) )
                query += " p.PO like '" + txtPONumber.Text.Trim().Replace("'","''") + "%' AND ";
            if ( !String.IsNullOrEmpty(txtJobNumber.Text))
                query += " p.JobNumber like '" + txtJobNumber.Text.Trim().Replace("'", "''") + "%' AND ";
            // Issue Date
            if (txtIssueDateFrom.Text.Length > 0 && txtIssueDateTo.Text.Length > 0)
                query += " ([Ship Date] BETWEEN '" + txtIssueDateFrom.Text + "' AND '" + txtIssueDateTo.Text + "') AND ";
            else
            {
                if (txtIssueDateFrom.Text.Length > 0)
                    query += " [Ship Date] = '" + txtIssueDateFrom.Text + "' AND ";
                if (txtIssueDateTo.Text.Length > 0)
                    query += " [Ship Date] = '" + txtIssueDateTo.Text + "' AND ";
            }
            // Amount
            if (txtAmountFrom.Text.Length > 0 && txtAmountTo.Text.Length > 0)
            {
                query += " ([Gross Amt] BETWEEN " + txtAmountFrom.Text.Replace("$", "").Replace(",", "") + " AND " + txtAmountTo.Text.Replace("$", "").Replace(",", "") + ") AND ";
            }
            else
            {
                if (txtAmountFrom.Text.Length > 0)
                {
                    query += " ( [Gross Amt] >= " + txtAmountFrom.Text.Replace("$", "").Replace(",", "") + " ) AND ";
                }
                if (txtAmountTo.Text.Length > 0)
                {
                    query += " ( [Gross Amt] >= " + txtAmountTo.Text.Replace("$", "").Replace(",", "") + " ) AND ";
                }
            }
            if (cboCategory.Text.Trim().Length > 0)
                query += " p.Category = '" + cboCategory.Text.Substring(0,1) + "' AND ";
            if (cboVendor.Text.Trim().Length > 0)
                query += " p.VendorID = '" + cboVendor.EditValue.ToString() + "' AND ";
            if (cboProjectManager.Text.Trim().Length > 0)
                query += " j.ProjectManagerID = '" + cboProjectManager.EditValue.ToString() + "' AND ";
            if (cboPurchasingAgent.Text.Trim().Length > 0)
                query += " p.PurchasingAgent = '" + cboPurchasingAgent.Text.Trim() + "' AND ";
            // Security - We Don't know yet this part
            // query += " [dbo].[GetUserJobAccess](b.JobID,'" + Security.Security.LoginID + "')  = 1 AND ";
            if (query.Length == 7)
                query = "";
            else
                query = query.Remove(query.Length - 5, 5);
            if (query.Length > 30)
            {
                GetPOList(query);
                lblWarning.Visible = false;
            }
            else
                lblWarning.Visible = true;
        }
        //
        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPONumber.Text = String.Empty;
            txtJobNumber.Text = String.Empty;
            txtIssueDateFrom.Text = String.Empty;
            txtIssueDateTo.Text = String.Empty;
            txtAmountFrom.EditValue = null;
            txtAmountTo.EditValue = null;
            cboCategory.EditValue = null;
            cboVendor.EditValue = null;
            cboPurchasingAgent.EditValue = null;
            cboProjectManager.EditValue = null;
            btnClear.Visible = false;
        }
        //
        public void UpdateListView( POListView poView)
        {
            if (grdPOListView.Columns["Job Number"].GroupIndex > -1)
                grdPOListView.Columns["Job Number"].UnGroup();
            if (grdPOListView.Columns["Category"].GroupIndex > -1)
                grdPOListView.Columns["Category"].UnGroup();
            if (grdPOListView.Columns["Vendor"].GroupIndex > -1)
                grdPOListView.Columns["Vendor"].UnGroup();
            if (grdPOListView.Columns["PurchasingAgent"].GroupIndex > -1)
                grdPOListView.Columns["PurchasingAgent"].UnGroup();
            if (grdPOListView.Columns["ProjectManager"].GroupIndex > -1)
                grdPOListView.Columns["ProjectManager"].UnGroup();

            switch (poView)
            {
                case POListView.Category:
                    grdPOListView.Columns["Category"].Group();
                    break;
                case POListView.Job:
                    grdPOListView.Columns["Job Number"].Group();
                    break;
                case POListView.PurchasingAgent:
                    grdPOListView.Columns["PurchasingAgent"].Group();
                    break;
                case POListView.Vendor:
                    grdPOListView.Columns["Vendor"].Group();
                    break;
                case POListView.projectManager:
                    grdPOListView.Columns["ProjectManager"].Group();
                    break;
            }
            poListView = poView;
            if (isAdHoc)
            {
                panReportParamters.Controls.Clear();
                panReportParamters.Controls.Add(new ctlAdHocReport(poTable, poListView, query, reportFilter, reportSort));
            }
        }
        //
        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Control ctlReport = new Control();
            panReportParamters.Controls.Clear();
            switch (cboReport.Text)
            {
                case "Ad Hoc":      
                    panReportParamters.Controls.Add(new ctlAdHocReport(poTable,poListView,query, reportFilter, reportSort));
                    isAdHoc = true;
                    break;
                case "Purchase Order":
                    panReportParamters.Controls.Add(new ctlPurchaseOrderReport());
                    isAdHoc = false;
                    break;
                case "Purchase Order Received Items":
                    panReportParamters.Controls.Add(new ctlPurchaseOrderReceivedItemsReport());
                    isAdHoc = false;
                    break;
                case "Purchase Order Invoices":
                    panReportParamters.Controls.Add(new ctlPurchaseOrderInvoicesReport());
                    isAdHoc = false;
                    break;
                case "Purchase Orders List By PO Type":
                    panReportParamters.Controls.Add(new ctlPurchaseOrdersListByTypeReport());
                    isAdHoc = false;
                    break;
                case "Purchase Orders List Greater or Equal $5,000":
                    panReportParamters.Controls.Add(new ctlPurchaseOrdersListOver5000Report());
                    isAdHoc = false;
                    break;
                case "Purchase Orders List By Work Order":
                    panReportParamters.Controls.Add(new ctlPurchaseOrdersListByWorkOrderReport());
                    isAdHoc = false;
                    break;
                case "Purchase Orders List by Supplier":
                    panReportParamters.Controls.Add(new ctlPurchaseOrdersListBySupplierReport());
                    isAdHoc = false;
                    break;
                case "POs Without Invoices":
                    panReportParamters.Controls.Add(new ctlPOsWithNoInvoiceReport());
                    isAdHoc = false;
                    break;
                case "POs Invoices with Different Job Number":
                    panReportParamters.Controls.Add(new ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport());
                    isAdHoc = false;
                    break;
                case "Missing PO Numbers":
                    panReportParamters.Controls.Add(new ctlNotUsedPONumbersReport());
                    isAdHoc = false;
                    break;

                default:
                    break;
            }           
        }
        //
        private void dockManager1_StartDocking(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }
        //
        private void grdPOListView_DoubleClick(object sender, EventArgs e)
        {
            if (poTable.Rows.Count == 0)
                return;
            DataRow r = grdPOListView.GetDataRow(grdPOListView.GetSelectedRows()[0]);
            if (r != null)
            {
                if (grdPOListView.IsGroupRow(grdPOListView.GetSelectedRows()[0]))
                    return;
                JCCPurchasing.Reports.Reports.PurchaseOrder(r["Job Number"].ToString(), r["PO"].ToString());

            }
        }

        private void grdPOListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1)
                return;
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                ColumnSortOrder sort = info.Column.SortOrder;
                string command = info.Column.FieldName;
                if (info.Column.SortOrder == ColumnSortOrder.Ascending)
                {
                    command += " Desc ";
                    reportSort = info.Column.Caption + " Desc";
                }
                else
                {
                    command += " ASC ";
                    reportSort = info.Column.Caption + " ASC";
                }
                poTable.DefaultView.Sort = command;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(poTable, poListView, query, reportFilter, reportSort));
                }
            }
        }
        
        private void grdPOListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdPOListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdPOListView.Columns)
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
                poTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(poTable, poListView, query, reportFilter, reportSort));
                }
            }
            catch
            { }
        }
        //
        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdPOListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "POList", configuration);
                        config.Save();
                        grdPOListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdPOListView.CustomizationForm != null)
                            grdPOListView.CustomizationForm.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
                case "btnRestoreYourCustomization":
                    RestoreCustomization();
                    break;
                case "btnResetColumns":
                    try
                    {
                        if (grdPOListView.CustomizationForm != null)
                        {
                            grdPOListView.CustomizationForm.Enabled = false;
                            grdPOListView.OptionsCustomization.AllowColumnMoving = false;
                            grdPOListView.CustomizationForm.Controls.Clear();
                            grdPOListView.CustomizationForm.Close();
                        }
                        grdPOList.Refresh();
                        grdPOListView.PopulateColumns();
                        grdPOListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdPOListView.CustomizationForm != null)
                            grdPOListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdPOListView.OptionsCustomization.AllowColumnMoving = true;
                    grdPOListView.ColumnsCustomization();

                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdPOListView.RowCount == 0)
                            return;
                        string fileName = "POListAdHoc.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions();
                        grdPOListView.ExportToXls(tempLocation + "\\" + fileName, option);
                        // 
                        Excel.Application oXl;
                        Excel.Workbook oBook;
                        oXl = new Microsoft.Office.Interop.Excel.Application();
                        try
                        {
                            oBook = oXl.Workbooks._Open(tempLocation + "\\" + fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message, CCEApplication.ApplicationName);
                        }
                        oXl.Visible = true;
                        oXl.UserControl = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }

        }
        //
        private void RestoreCustomization()
        {
            try
            {
                string configuration = "";

                configuration = Security.BusinessLayer.UserConfiguration.GetConfiguration(
                    Security.Security.UserID.ToString(), "POList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdPOListView.RestoreLayoutFromStream(stream);
                grdPOListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdPOListView.CustomizationForm != null)
                    grdPOListView.CustomizationForm.Close();
                //FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdPOListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuPO.ShowPopup(ctlPOList.MousePosition);
        }
    }
}
