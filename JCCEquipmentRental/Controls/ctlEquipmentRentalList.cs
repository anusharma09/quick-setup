using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCEquipmentRental.BusinessLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using JCCEquipmentRental;
using JCCEquipmentRental.PresentationLayer;
namespace JCCEquipmentRental.Controls
{
    public enum EquipmentRentalListView
    {
        Job,
        Vendor,
        Status,
        List
    }
    //
    public partial class ctlEquipmentRentalList : UserControl
    {
        private EquipmentRentalListView equipmentRentalListView = EquipmentRentalListView.List;
        private BindingSource equipmentRentalSourceBinding = new BindingSource();
        DataTable equipmentRentalTable;
        private bool isAdHoc = false;
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;
        frmEquipmentRental equipmentRental;
       
        public ctlEquipmentRentalList()
        {
            InitializeComponent();
            if (Security.Security.UserJCCEquipmentRentalAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                panelControlNewEquipmentRental.Visible = false;
            try
            {
                StaticTables.PopulateStaticTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            GetEquipmentRentalList(" Where JobEquipmentRentalID = 0 ");
            initialScreen = false;
        } 
        //
        private void ctlEquipmentRentalList_Load(object sender, EventArgs e)
        {
            cboReport.Properties.Items.Add("Ad Hoc");
            //cboReport.Properties.Items.Add("additional reports");
            PopulatePulldownLists();
        }
        //
        private void GetEquipmentRentalList(string where)
        {
            if (!initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");

            try
            {
                // Change the data source
                equipmentRentalTable = EquipmentRental.GetEquipmentRentalList(where).Tables[0];
                equipmentRentalSourceBinding.DataSource = equipmentRentalTable.DefaultView;
                grdEquipmentRentalList.DataSource = equipmentRentalSourceBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }   
            finally
            {
                grdEquipmentRentalList.MainView.PopulateColumns();
                FormatGrid();
                RestoreCustomization();
                UpdateListView(equipmentRentalListView);
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (equipmentRentalTable.Rows.Count == 0)
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
                if (txtRequestNumber.Text.Trim().Length > 0)
                {
                    query += " RequestNumber LIKE '" + txtRequestNumber.Text.Trim() + "%' AND ";
                }
                //
                if (txtPONumber.Text.Trim().Length > 0)
                {
                    query += " r.PONumber LIKE '" + txtPONumber.Text.Trim() + "%' AND ";
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
                if (txtDeliveryDateFrom.Text.Trim().Length > 0 && txtDeliveryDateTo.Text.Trim().Length > 0)
                {
                    query += " (DeliveryDate BETWEEN '" + txtDeliveryDateFrom.Text + "' AND '" + txtDeliveryDateTo.Text + "') AND ";
                }
                else
                {
                    if (txtDeliveryDateFrom.Text.Trim().Length > 0)
                        query += " DeliveryDate = '" + txtDeliveryDateFrom.Text + "' AND ";

                    if (txtDeliveryDateTo.Text.Trim().Length > 0)
                        query += " DeliveryDate = '" + txtDeliveryDateTo.Text + "' AND ";
                }
                //
                if (txtStartRentalDateFrom.Text.Trim().Length > 0 && txtStartRentalDateTo.Text.Trim().Length > 0)
                {
                    query += " (StartRentalDate BETWEEN '" + txtStartRentalDateFrom.Text + "' AND '" + txtStartRentalDateTo.Text + "') AND ";
                }
                else
                {
                    if (txtStartRentalDateFrom.Text.Trim().Length > 0)
                        query += " StartRentalDate = '" + txtStartRentalDateFrom.Text + "' AND ";

                    if (txtStartRentalDateTo.Text.Trim().Length > 0)
                        query += " StartRentalDate = '" + txtStartRentalDateTo.Text + "' AND ";
                }
                //
                if (txtOffRentalDateFrom.Text.Trim().Length > 0 && txtOffRentalDateTo.Text.Trim().Length > 0)
                {
                    query += " (OffRentalDate BETWEEN '" + txtOffRentalDateFrom.Text + "' AND '" + txtOffRentalDateTo.Text + "') AND ";
                }
                else
                {
                    if (txtOffRentalDateFrom.Text.Trim().Length > 0)
                        query += " OffRentalDate = '" + txtOffRentalDateFrom.Text + "' AND ";

                    if (txtOffRentalDateTo.Text.Trim().Length > 0)
                        query += " OffRentalDate = '" + txtOffRentalDateTo.Text + "' AND ";
                }
                //
                if (txtPickedUpDateFrom.Text.Trim().Length > 0 && txtPickedUpDateTo.Text.Trim().Length > 0)
                {
                    query += " (PickedUpDate BETWEEN '" + txtPickedUpDateFrom.Text + "' AND '" + txtPickedUpDateTo.Text + "') AND ";
                }
                else
                {
                    if (txtPickedUpDateFrom.Text.Trim().Length > 0)
                        query += " PickedUpDate = '" + txtPickedUpDateFrom.Text + "' AND ";

                    if (txtPickedUpDateTo.Text.Trim().Length > 0)
                        query += " PickedUpDate = '" + txtPickedUpDateTo.Text + "' AND ";
                }
                //
                if (cboVendor.Text.Trim().Length > 0)
                    query += " Vendor = '" + cboVendor.EditValue.ToString() + "' AND ";
                //
                if (cboStatus.Text.Trim().Length > 0)
                    query += " Status = '" + cboStatus.Text + "' AND ";
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

                GetEquipmentRentalList(query);
                
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(equipmentRentalTable, equipmentRentalListView,reportSort, reportFilter));
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
            txtRequestNumber.Text = "";
            txtPONumber.Text = "";
            txtCreatedDateFrom.Text = "";
            txtCreatedDateTo.Text = "";
            txtDeliveryDateFrom.Text = "";
            txtDeliveryDateTo.Text = "";
            txtStartRentalDateFrom.Text = "";
            txtStartRentalDateTo.Text = "";
            txtOffRentalDateFrom.Text = "";
            txtOffRentalDateTo.Text = "";
            txtPickedUpDateFrom.Text = "";
            txtPickedUpDateTo.Text = "";
            cboVendor.EditValue = null;
            cboStatus.Text = "";
            txtCreatedBy.Text = "";
            btnClear.Visible = false;
        }
        //
        public void UpdateListView( EquipmentRentalListView equipView)
        {
            try
            {
                if (grdEquipmentRentalListView.Columns["Job"].GroupIndex > -1)
                    grdEquipmentRentalListView.Columns["Job"].UnGroup();
                if (grdEquipmentRentalListView.Columns["Vendor"].GroupIndex > -1)
                    grdEquipmentRentalListView.Columns["Vendor"].UnGroup();
                if (grdEquipmentRentalListView.Columns["Status"].GroupIndex > -1)
                    grdEquipmentRentalListView.Columns["Status"].UnGroup();

                switch (equipView)
                {
                    case EquipmentRentalListView.Job:
                        grdEquipmentRentalListView.Columns["Job"].Group();
                        break;
                    case EquipmentRentalListView.Status:
                        grdEquipmentRentalListView.Columns["Status"].Group();
                        break;
                    case EquipmentRentalListView.Vendor:
                        grdEquipmentRentalListView.Columns["Vendor"].Group();
                        break;
                }
                equipmentRentalListView = equipView;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(equipmentRentalTable, equipmentRentalListView, reportSort, reportFilter));
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
                        panReportParamters.Controls.Add(new ctlAdHocReport(equipmentRentalTable, equipmentRentalListView, reportSort, reportFilter));
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
        private void grdEquipmentRentalListView_MouseUp(object sender, MouseEventArgs e)
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
                equipmentRentalTable.DefaultView.Sort = command;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(equipmentRentalTable, equipmentRentalListView, reportSort, reportFilter));
                }   
            }
        }
        //
        private void grdEquipmentRentalListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdEquipmentRentalListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdEquipmentRentalListView.Columns)
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
                equipmentRentalTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(equipmentRentalTable, equipmentRentalListView, reportSort, reportFilter));
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
                if (!StaticTables.IsLoaded)
                    StaticTables.PopulateStaticTables();
                //
                cboVendor.Properties.DataSource = StaticTables.Vendor;
                cboVendor.Properties.PopulateColumns();
                cboVendor.Properties.DisplayMember = "Name";
                cboVendor.Properties.ValueMember = "VendorID";
                cboVendor.Properties.ShowHeader = false;
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
                    Security.Security.UserID.ToString(), "EquipmentRentalList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdEquipmentRentalListView.RestoreLayoutFromStream(stream);
                grdEquipmentRentalListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdEquipmentRentalListView.CustomizationForm != null)
                    grdEquipmentRentalListView.CustomizationForm.Close();
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
            grdEquipmentRentalListView.Columns["JobEquipmentRentalID"].Visible = false;
            grdEquipmentRentalListView.Columns["Job"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdEquipmentRentalListView.Columns["Job"].SummaryItem.DisplayFormat = "Total Count: {0:n0}";
        }
        //
        private void grdEquipmentRentalListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuToolWatch.ShowPopup(ctlEquipmentRentalList.MousePosition);
        }

        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdEquipmentRentalListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "EquipmentRentalList", configuration);
                        config.Save();
                        grdEquipmentRentalListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdEquipmentRentalListView.CustomizationForm != null)
                            grdEquipmentRentalListView.CustomizationForm.Close();
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
                        if (grdEquipmentRentalListView.CustomizationForm != null)
                        {
                            grdEquipmentRentalListView.CustomizationForm.Enabled = false;
                            grdEquipmentRentalListView.OptionsCustomization.AllowColumnMoving = false;
                            grdEquipmentRentalListView.CustomizationForm.Controls.Clear();
                            grdEquipmentRentalListView.CustomizationForm.Close();
                        }
                        grdEquipmentRentalList.Refresh();
                        grdEquipmentRentalListView.PopulateColumns();
                        grdEquipmentRentalListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdEquipmentRentalListView.CustomizationForm != null)
                            grdEquipmentRentalListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdEquipmentRentalListView.OptionsCustomization.AllowColumnMoving = true;
                    grdEquipmentRentalListView.ColumnsCustomization();

                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdEquipmentRentalListView.RowCount == 0)
                            return;
                        string fileName = "EquipmentRentalList.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions();
                        grdEquipmentRentalListView.ExportToXls(tempLocation + "\\" + fileName, option);
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
        private void grdEquipmentRentalList_DoubleClick(object sender, EventArgs e)
        {
            if (grdEquipmentRentalListView.RowCount == 0)
                return;
            DataRow dataRow;
            dataRow = this.grdEquipmentRentalListView.GetDataRow(grdEquipmentRentalListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                if (equipmentRental != null)
                {
                    equipmentRental.Close();
                    equipmentRental.Dispose();
                }
                equipmentRental = new frmEquipmentRental(dataRow[0].ToString(), "0", equipmentRentalSourceBinding, true);
                try
                {
                    equipmentRental.Show();
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
            equipmentRental  = new frmEquipmentRental("0", "0", equipmentRentalSourceBinding, true);
            equipmentRental.ShowDialog();
        }
        //
    }
}
