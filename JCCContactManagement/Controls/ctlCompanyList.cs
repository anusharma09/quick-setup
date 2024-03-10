using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCContactManagement.BusinessLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using JCCContactManagement.PresentationLayer;
namespace JCCContactManagement.Controls
{
    public enum CompanyListView
    {
        Status,
        ReferredBy,
        Industry,
        Territory,
        List
    }
    //
    public partial class ctlCompanyList : UserControl
    {
        private CompanyListView companyListView = CompanyListView.List;
        private BindingSource companySourceBinding = new BindingSource();
        DataTable companyTable;
        private bool isAdHoc = false;
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;
        frmCompany company;
       
        public ctlCompanyList()
        {
            InitializeComponent();
            if (Security.Security.UserJCCContactManagementAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                panelControlNewCompany.Visible = false;
            try
            {
                StaticTables.PopulateStaticTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            GetCompanyList(" Where CMCompanyID = 0 ");
            initialScreen = false;
        } 
        //
        private void ctlTransferList_Load(object sender, EventArgs e)
        {
            cboReport.Properties.Items.Add("Ad Hoc");
            //cboReport.Properties.Items.Add("additional reports");
            PopulatePulldownLists();
        }
        //
        private void GetCompanyList(string where)
        {
            try
            {
                // Change the data source
                companyTable = CMCompany.GetCMCompanyList(where).Tables[0];
                companySourceBinding.DataSource = companyTable.DefaultView;
                grdCompanyList.DataSource = companySourceBinding;
                grdCompanyList.MainView.PopulateColumns();
                FormatGrid();
                RestoreCustomization();
                UpdateListView(companyListView);
                if (!initialScreen)
                {
                    if (companyTable.Rows.Count == 0)
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }            
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            string query = " WHERE   ";
            try
            {
                if (txtCMCompanyName.Text.Trim().Length > 0)
                    query += " CMCompanyName LIKE '" + txtCMCompanyName.Text.Trim() + "%' AND ";
                //
                if (txtCMCompanyRegion.Text.Trim().Length > 0)
                    query += " CMCompanyRegion LIKE '" + txtCMCompanyRegion.Text.Trim() + "%' AND ";
                //
                if (cboCMCompanyStatus.Text.Trim().Length > 0)
                    query += " c.CMCompanyStatus = " + cboCMCompanyStatus.EditValue.ToString() + " AND ";
                //
                if (cboCMCompanyReferredBy.Text.Trim().Length > 0)
                    query += " c.CMCompanyReferredBy = " + cboCMCompanyReferredBy.EditValue.ToString() + " AND ";
                //
                if (cboCMCompanyTerritory.Text.Trim().Length > 0)
                    query += " c.CMCompanyTerritory = " + cboCMCompanyTerritory.EditValue.ToString() + " AND ";
                //
                if (cboCMCompanyIndustry.Text.Trim().Length > 0)
                    query += " c.CMCompanyIndustry = " + cboCMCompanyIndustry.EditValue.ToString() + " AND ";
                //
                if (chkCustomer.CheckState == CheckState.Checked)
                    query += " c.IsCustomer = 1  AND ";
                if (chkVendor.CheckState == CheckState.Checked)
                    query += " c.IsVendor = 1  AND ";
                if (query.Length <  11)
                    query = "";
                else
                    query = query.Remove(query.Length - 5, 5);
                GetCompanyList(query);
                
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(companyTable, companyListView,reportSort, reportFilter));
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
            txtCMCompanyName.Text = "";
            txtCMCompanyRegion.Text = "";
            cboCMCompanyStatus.EditValue = null;
            cboCMCompanyReferredBy.EditValue = null;
            cboCMCompanyIndustry.EditValue = null;
            cboCMCompanyTerritory.EditValue = null;
            chkCustomer.CheckState = CheckState.Unchecked;
            chkVendor.CheckState = CheckState.Unchecked;
            btnClear.Visible = false;
        }
        //
        public void UpdateListView( CompanyListView companyView)
        {
            try
            {
                if (grdCompanyListView.Columns["Status"].GroupIndex > -1)
                    grdCompanyListView.Columns["Status"].UnGroup();
                if (grdCompanyListView.Columns["Referred By"].GroupIndex > -1)
                    grdCompanyListView.Columns["Referred By"].UnGroup();
                if (grdCompanyListView.Columns["Industry"].GroupIndex > -1)
                    grdCompanyListView.Columns["Industry"].UnGroup();
                if (grdCompanyListView.Columns["Territory"].GroupIndex > -1)
                    grdCompanyListView.Columns["Territory"].UnGroup();

                switch (companyView)
                {
                    case CompanyListView.Industry:
                        grdCompanyListView.Columns["Industry"].Group();
                        break;
                    case CompanyListView.ReferredBy:
                        grdCompanyListView.Columns["Referred By"].Group();
                        break;
                    case CompanyListView.Status:
                        grdCompanyListView.Columns["Status"].Group();
                        break;
                    case CompanyListView.Territory:
                        grdCompanyListView.Columns["Territory"].Group();
                        break;
                }
                companyListView = companyView;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(companyTable, companyListView, reportSort, reportFilter));
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
                        panReportParamters.Controls.Add(new ctlAdHocReport(companyTable, companyListView, reportSort, reportFilter));
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
        private void grdCompanyListView_MouseUp(object sender, MouseEventArgs e)
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
                companyTable.DefaultView.Sort = command;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(companyTable, companyListView, reportSort, reportFilter));
                }   
            }
        }
        //
        private void grdCompanyListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdCompanyListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdCompanyListView.Columns)
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
                companyTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(companyTable, companyListView, reportSort, reportFilter));
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
                cboCMCompanyIndustry.Properties.DataSource = StaticTables.Industry;
                cboCMCompanyIndustry.Properties.PopulateColumns();
                cboCMCompanyIndustry.Properties.DisplayMember = "Description";
                cboCMCompanyIndustry.Properties.ValueMember = "ID";
                cboCMCompanyIndustry.Properties.ShowHeader = false;
                //
                cboCMCompanyReferredBy.Properties.DataSource = StaticTables.ReferredBy;
                cboCMCompanyReferredBy.Properties.PopulateColumns();
                cboCMCompanyReferredBy.Properties.DisplayMember = "Description";
                cboCMCompanyReferredBy.Properties.ValueMember = "ID";
                cboCMCompanyReferredBy.Properties.ShowHeader = false;
                //
                cboCMCompanyStatus.Properties.DataSource = StaticTables.Status;
                cboCMCompanyStatus.Properties.PopulateColumns();
                cboCMCompanyStatus.Properties.DisplayMember = "Description";
                cboCMCompanyStatus.Properties.ValueMember = "ID";
                cboCMCompanyStatus.Properties.ShowHeader = false;
                //
                cboCMCompanyTerritory.Properties.DataSource = StaticTables.Territory;
                cboCMCompanyTerritory.Properties.PopulateColumns();
                cboCMCompanyTerritory.Properties.DisplayMember = "Description";
                cboCMCompanyTerritory.Properties.ValueMember = "ID";
                cboCMCompanyTerritory.Properties.ShowHeader = false;
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
                    Security.Security.UserID.ToString(), "CMCompanyList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdCompanyListView.RestoreLayoutFromStream(stream);
                grdCompanyListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdCompanyListView.CustomizationForm != null)
                    grdCompanyListView.CustomizationForm.Close();
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void FormatGrid()
        {
            grdCompanyListView.Columns["CMCompanyID"].Visible = false;
            grdCompanyListView.Columns["Company Name"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdCompanyListView.Columns["Company Name"].SummaryItem.DisplayFormat = "Total Count: {0:n0}";
        }
        //
        private void grdCompanyListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuToolWatch.ShowPopup(ctlCompanyList.MousePosition);
        }

        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdCompanyListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "CMCompanyList", configuration);
                        config.Save();
                        grdCompanyListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdCompanyListView.CustomizationForm != null)
                            grdCompanyListView.CustomizationForm.Close();
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
                        if (grdCompanyListView.CustomizationForm != null)
                        {
                            grdCompanyListView.CustomizationForm.Enabled = false;
                            grdCompanyListView.OptionsCustomization.AllowColumnMoving = false;
                            grdCompanyListView.CustomizationForm.Controls.Clear();
                            grdCompanyListView.CustomizationForm.Close();
                        }
                        grdCompanyList.Refresh();
                        grdCompanyListView.PopulateColumns();
                        grdCompanyListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdCompanyListView.CustomizationForm != null)
                            grdCompanyListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdCompanyListView.OptionsCustomization.AllowColumnMoving = true;
                    grdCompanyListView.ColumnsCustomization();

                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdCompanyListView.RowCount == 0)
                            return;
                        string fileName = "CMCompanyListAdHoc.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions(true, true);
                        grdCompanyListView.ExportToXls(tempLocation + "\\" + fileName, option);
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
        private void grdCompanyList_DoubleClick(object sender, EventArgs e)
        {
            if (grdCompanyListView.RowCount == 0)
                return;
            DataRow dataRow;
            dataRow = this.grdCompanyListView.GetDataRow(grdCompanyListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                if (company != null)
                {
                    company.Close();
                    company.Dispose();
                }
                company = new frmCompany(dataRow[0].ToString(), companySourceBinding);
                try
                {
                    company.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //
        private void btnNewCompany_Click(object sender, EventArgs e)
        {
            frmCompany company = new frmCompany("0", companySourceBinding);
            company.ShowDialog();
        }
        //
    }
}
