using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCSmallPO.BusinessLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using JCCSmallPO;
using JCCSmallPO.PresentationLayer;
namespace JCCSmallPO.Controls
{
    public enum SmallPOListView
    {
        Job,
        List
    }
    //
    public partial class ctlSmallPOList : UserControl
    {
        private SmallPOListView smallPOListView = SmallPOListView.List;
        private BindingSource smallPOSourceBinding = new BindingSource();
        DataTable smallPOTable;
        private bool isAdHoc = false;
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;
        
  
        frmSmallPO smallPO;
       
        public ctlSmallPOList()
        {
            InitializeComponent();
            if (Security.Security.UserJCCSmallPOAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                panelControlNewSmallPO.Visible = false;
            try
            {
                StaticTables.PopulateStaticTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            GetSmallPOList(" Where JobSmallPOID = 0 ");
            initialScreen = false;
        } 
        //
        private void ctlSmallPOList_Load(object sender, EventArgs e)
        {
            cboReport.Properties.Items.Add("Ad Hoc");
            //cboReport.Properties.Items.Add("additional reports");
            PopulatePulldownLists();
        }
        //
        private void GetSmallPOList(string where)
        {
            if (!initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
            try
            {
                // Change the data source
                smallPOTable = SmallPO.GetSmallPOList(where).Tables[0];
                smallPOSourceBinding.DataSource = smallPOTable.DefaultView;
                grdSmallPOList.DataSource = smallPOSourceBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }  
            finally
            {
                grdSmallPOList.MainView.PopulateColumns();
                FormatGrid();
                RestoreCustomization();
                UpdateListView(smallPOListView);
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (smallPOTable.Rows.Count == 0)
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
                if (txtServCommJobNo.Text.Trim().Length > 0)
                {
                    query += " ServCommJobNo LIKE '" + txtServCommJobNo.Text.Trim() + "%' AND ";
                }
                //
                if (txtPONumber.Text.Trim().Length > 0)
                {
                    query += " SmallPONumber LIKE '" + txtPONumber.Text.Trim() + "%' AND ";
                }
                //
                if (txtSmallPODateFrom.Text.Trim().Length > 0 && txtSmallPODateTo.Text.Trim().Length > 0)
                {
                    query += " (PODate BETWEEN '" + txtSmallPODateFrom.Text + "' AND '" + txtSmallPODateTo.Text + "') AND ";
                }
                else
                {
                    if (txtSmallPODateFrom.Text.Trim().Length > 0)
                        query += " PODateDate = '" + txtSmallPODateFrom.Text + "' AND ";

                    if (txtSmallPODateTo.Text.Trim().Length > 0)
                        query += " PODateDate = '" + txtSmallPODateTo.Text + "' AND ";
                }
                //
                if (txtCreatedBy.Text.Trim().Length > 0)
                    query += " UserName LIKE '" + txtCreatedBy.Text.Trim() + "%' AND ";
                //
                if (Security.Security.UserJCCEquipmentRentalAccess == Security.Security.Access.JCCSmallPOUser)
                    query += " [dbo].[GetUserJobAccess](j.JobID,'" + Security.Security.LoginID + "')  = 1 AND ";

                if (query.Length == 7)
                    query = "";
                else
                    query = query.Remove(query.Length - 4, 4);

                GetSmallPOList(query);
                
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(smallPOTable, smallPOListView,reportSort, reportFilter));
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
            txtServCommJobNo.Text = "";
            txtPONumber.Text = "";
            txtSmallPODateFrom.Text = "";
            txtSmallPODateTo.Text = "";
            txtCreatedBy.Text = "";
            btnClear.Visible = false;
        }
        //
        public void UpdateListView( SmallPOListView poView)
        {
            try
            {
                if (grdSmallPOListView.Columns["Job"].GroupIndex > -1)
                    grdSmallPOListView.Columns["Job"].UnGroup();
                switch (poView)
                {
                    case SmallPOListView.Job:
                        grdSmallPOListView.Columns["Job"].Group();
                        break;
                }
                smallPOListView = poView;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(smallPOTable, smallPOListView, reportSort, reportFilter));
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
                        panReportParamters.Controls.Add(new ctlAdHocReport(smallPOTable, smallPOListView, reportSort, reportFilter));
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
        private void grdSmallPOListView_MouseUp(object sender, MouseEventArgs e)
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
                smallPOTable.DefaultView.Sort = command;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(smallPOTable, smallPOListView, reportSort, reportFilter));
                }   
            }
        }
        //
        private void grdSmallPOListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdSmallPOListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdSmallPOListView.Columns)
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
                smallPOTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(smallPOTable, smallPOListView, reportSort, reportFilter));
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
                    Security.Security.UserID.ToString(), "SmallPOList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdSmallPOListView.RestoreLayoutFromStream(stream);
                grdSmallPOListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdSmallPOListView.CustomizationForm != null)
                    grdSmallPOListView.CustomizationForm.Close();
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
            grdSmallPOListView.Columns["JobSmallPOID"].Visible = false;
            grdSmallPOListView.Columns["Job"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdSmallPOListView.Columns["Job"].SummaryItem.DisplayFormat = "Total Count: {0:n0}";
        }
        //
        private void grdSmallPOListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuToolWatch.ShowPopup(ctlSmallPOList.MousePosition);
        }

        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdSmallPOListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "SmallPOList", configuration);
                        config.Save();
                        grdSmallPOListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdSmallPOListView.CustomizationForm != null)
                            grdSmallPOListView.CustomizationForm.Close();
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
                        if (grdSmallPOListView.CustomizationForm != null)
                        {
                            grdSmallPOListView.CustomizationForm.Enabled = false;
                            grdSmallPOListView.OptionsCustomization.AllowColumnMoving = false;
                            grdSmallPOListView.CustomizationForm.Controls.Clear();
                            grdSmallPOListView.CustomizationForm.Close();
                        }
                        grdSmallPOList.Refresh();
                        grdSmallPOListView.PopulateColumns();
                        grdSmallPOListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdSmallPOListView.CustomizationForm != null)
                            grdSmallPOListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdSmallPOListView.OptionsCustomization.AllowColumnMoving = true;
                    grdSmallPOListView.ColumnsCustomization();

                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdSmallPOListView.RowCount == 0)
                            return;
                        string fileName = "SmnallPOList.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions(); // new DevExpress.XtraPrinting.XlsExportOptions(true, true);
                        grdSmallPOListView.ExportToXls(tempLocation + "\\" + fileName, option);
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
        private void grdSmallPOList_DoubleClick(object sender, EventArgs e)
        {
            if (grdSmallPOListView.RowCount == 0)
                return;
            DataRow dataRow;
            dataRow = this.grdSmallPOListView.GetDataRow(grdSmallPOListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                if (smallPO != null)
                {
                    smallPO.Close();
                    smallPO.Dispose();
                }
                smallPO = new frmSmallPO(dataRow[0].ToString(), "0", smallPOSourceBinding, true);
                try
                {
                    smallPO.Show();
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
            smallPO  = new frmSmallPO("0", "0", smallPOSourceBinding, true);
            smallPO.ShowDialog();
        }
        //
    }
}
