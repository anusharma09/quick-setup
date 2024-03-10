using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCMaterialOrder.BusinessLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using JCCMaterialOrder;
using JCCMaterialOrder.PresentationLayer;
namespace JCCMaterialOrder.Controls
{
    public enum MaterialOrderListView
    {
        Job,
        List
    }
    //
    public partial class ctlMaterialOrderList : UserControl
    {
        private MaterialOrderListView materialOrderListView = MaterialOrderListView.List;
        private BindingSource materialOrderSourceBinding = new BindingSource();
        DataTable materialOrderTable;
        private bool isAdHoc = false;
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;
        
        frmMaterialOrder materialOrder;
       
        public ctlMaterialOrderList()
        {
            InitializeComponent();
            if (Security.Security.UserJCCEquipmentRentalAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                panelControlNewMaterialOrder.Visible = false;
            try
            {
                StaticTables.PopulateStaticTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            GetMaterialOrderList(" Where JobMaterialOrderID = 0 ");
            initialScreen = false;
        } 
        //
        private void ctlMaterialOrderList_Load(object sender, EventArgs e)
        {
            cboReport.Properties.Items.Add("Ad Hoc");
            //cboReport.Properties.Items.Add("additional reports");
            PopulatePulldownLists();
        }
        //
        private void GetMaterialOrderList(string where)
        {
            if (!initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");

            try
            {
                // Change the data source
                materialOrderTable = MaterialOrder.GetMaterialOrderList(where).Tables[0];
                materialOrderSourceBinding.DataSource = materialOrderTable.DefaultView;
                grdMaterialOrderList.DataSource = materialOrderSourceBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }  
            finally
            {
                grdMaterialOrderList.MainView.PopulateColumns();
                FormatGrid();
                RestoreCustomization();
                UpdateListView(materialOrderListView);
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (materialOrderTable.Rows.Count == 0)
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }
            }          
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {


            string query = " WHERE ";
            try
            {
                if (txtJobNumber.Text.Trim().Length > 0)
                {
                    query += " JobNumber LIKE '" + txtJobNumber.Text.Trim() + "%' AND ";
                }
                //
                if (txtOrderNumber.Text.Trim().Length > 0)
                {
                    query += " OrderNumber LIKE '" + txtOrderNumber.Text.Trim() + "%' AND ";
                }
                //
                if (txtCreatedDateFrom.Text.Trim().Length > 0 && txtCreatedDateTo.Text.Trim().Length > 0)
                {
                    query += " (CreatedDate BETWEEN '" + txtCreatedDateFrom.Text + "' AND '" + txtCreatedDateTo.Text + "') AND ";
                }
                else
                {
                    if (txtCreatedDateFrom.Text.Trim().Length > 0)
                        query += " CreatedDate = '" + txtCreatedDateFrom.Text + "' AND ";

                    if (txtCreatedDateTo.Text.Trim().Length > 0)
                        query += " CreatedDate = '" + txtCreatedDateTo.Text + "' AND ";
                }
                //
                if (txtCreatedBy.Text.Trim().Length > 0)
                    query += " UserName LIKE '" + txtCreatedBy.Text.Trim() + "%' AND ";
                //
                if (Security.Security.UserJCCEquipmentRentalAccess == Security.Security.Access.JCCEquipmentRentalUser)
                    query += " [dbo].[GetUserJobAccess](j.JobID,'" + Security.Security.LoginID + "')  = 1 AND ";

                if (query.Length == 7)
                    query = "";
                else
                    query = query.Remove(query.Length - 4, 4);

                GetMaterialOrderList(query);
                
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(materialOrderTable, materialOrderListView,reportSort, reportFilter));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearchCriteria();
        }
        private void ClearSearchCriteria()
        {
            txtJobNumber.Text = "";
            txtOrderNumber.Text = "";
            txtCreatedDateFrom.Text = "";
            txtCreatedDateTo.Text = "";
            txtCreatedBy.Text = "";
            btnClear.Visible = false;
        }
        //
        public void UpdateListView( MaterialOrderListView materialView)
        {
            try
            {
                if (grdMaterialOrderListView.Columns["Job"].GroupIndex > -1)
                    grdMaterialOrderListView.Columns["Job"].UnGroup();
                switch (materialView)
                {
                    case MaterialOrderListView.Job:
                        grdMaterialOrderListView.Columns["Job"].Group();
                        break;
                }
                materialOrderListView = materialView;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(materialOrderTable, materialOrderListView, reportSort, reportFilter));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Control ctlReport = new Control();
                panReportParamters.Controls.Clear();
                switch (cboReport.Text)
                {
                    case "Ad Hoc":
                        panReportParamters.Controls.Add(new ctlAdHocReport(materialOrderTable, materialOrderListView, reportSort, reportFilter));
                        isAdHoc = true;
                        break;
                  //  case "Other Reports":
                  //      panReportParamters.Controls.Add(new ctlTransferDetailReport());
                  //      isAdHoc = false;
                  //      break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void dockManager1_StartDocking(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }
       //
        private void grdMaterialOrderListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1) return;
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column  )
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
                materialOrderTable.DefaultView.Sort = command;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(materialOrderTable, materialOrderListView, reportSort, reportFilter));
                }   
            }
        }
        //
        private void grdMaterialOrderListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdMaterialOrderListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdMaterialOrderListView.Columns)
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
                materialOrderTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(materialOrderTable, materialOrderListView, reportSort, reportFilter));
                }
            }
            catch
            {
            }
        }
        //
        private void PopulatePulldownLists()
        {
            try
            {
                //   
                //if (!StaticTables.IsLoaded)
                //    StaticTables.PopulateStaticTables();
                //
                //cboVendor.Properties.DataSource = StaticTables.Vendor;
                //cboVendor.Properties.PopulateColumns();
                //cboVendor.Properties.DisplayMember = "Name";
                //cboVendor.Properties.ValueMember = "VendorID";
                //cboVendor.Properties.ShowHeader = false;
                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void RestoreCustomization()
        {
            try
            {
                string configuration = "";

                configuration = Security.BusinessLayer.UserConfiguration.GetConfiguration(
                    Security.Security.UserID.ToString(), "MaterialOrderList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdMaterialOrderListView.RestoreLayoutFromStream(stream);
                grdMaterialOrderListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdMaterialOrderListView.CustomizationForm != null)
                    grdMaterialOrderListView.CustomizationForm.Close();
                //FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void FormatGrid()
        {
            grdMaterialOrderListView.Columns["JobMaterialOrderID"].Visible = false;
            grdMaterialOrderListView.Columns["Job"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdMaterialOrderListView.Columns["Job"].SummaryItem.DisplayFormat = "Total Count: {0:n0}";
        }
        //
        private void grdMaterialOrderListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuToolWatch.ShowPopup(ctlMaterialOrderList.MousePosition);
        }

        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdMaterialOrderListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "MaterialOrderList", configuration);
                        config.Save();
                        grdMaterialOrderListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdMaterialOrderListView.CustomizationForm != null)
                            grdMaterialOrderListView.CustomizationForm.Close();
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
                        if (grdMaterialOrderListView.CustomizationForm != null)
                        {
                            grdMaterialOrderListView.CustomizationForm.Enabled = false;
                            grdMaterialOrderListView.OptionsCustomization.AllowColumnMoving = false;
                            grdMaterialOrderListView.CustomizationForm.Controls.Clear();
                            grdMaterialOrderListView.CustomizationForm.Close();
                        }
                        grdMaterialOrderList.Refresh();
                        grdMaterialOrderListView.PopulateColumns();
                        grdMaterialOrderListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdMaterialOrderListView.CustomizationForm != null)
                            grdMaterialOrderListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdMaterialOrderListView.OptionsCustomization.AllowColumnMoving = true;
                    grdMaterialOrderListView.ColumnsCustomization();

                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdMaterialOrderListView.RowCount == 0)
                            return;
                        string fileName = "MaterialOrderList.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions();
                        grdMaterialOrderListView.ExportToXls(tempLocation + "\\" + fileName, option);
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
        private void grdMaterialOrderList_DoubleClick(object sender, EventArgs e)
        {
            if (grdMaterialOrderListView.RowCount == 0)
                return;
            DataRow dataRow;
            dataRow = this.grdMaterialOrderListView.GetDataRow(grdMaterialOrderListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                if (materialOrder != null)
                {
                    materialOrder.Close();
                    materialOrder.Dispose();
                }
                materialOrder = new frmMaterialOrder(dataRow[0].ToString(), "0", materialOrderSourceBinding, true);
                try
                {
                    materialOrder.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //
        private void btnNewContact_Click(object sender, EventArgs e)
        {
            materialOrder  = new frmMaterialOrder("0", "0", materialOrderSourceBinding, true);
            materialOrder.ShowDialog();
        }
        //
    }
}
