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
    public enum ContactListView
    {
        Status,
        ReferredBy,
        Industry,
        Territory,
        List
    }
    //
    public partial class ctlContactList : UserControl
    {
        private ContactListView contactListView = ContactListView.List;
        private BindingSource contactSourceBinding = new BindingSource();
        DataTable contactTable;
        private bool isAdHoc = false;
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;
        frmContact contact;
       
        public ctlContactList()
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
            GetContactList(" Where CMContactID = 0 ");
            initialScreen = false;
        } 
        //
        private void ctlContactList_Load(object sender, EventArgs e)
        {
            cboReport.Properties.Items.Add("Ad Hoc");
            //cboReport.Properties.Items.Add("additional reports");
            PopulatePulldownLists();
        }
        //
        private void GetContactList(string where)
        {
            try
            {
                // Change the data source
                contactTable = CMContact.GetCMContactList(where).Tables[0];
                contactSourceBinding.DataSource = contactTable.DefaultView;
                grdContactList.DataSource = contactSourceBinding;
                grdContactList.MainView.PopulateColumns();
                FormatGrid();
                RestoreCustomization();
                UpdateListView(contactListView);
                if (!initialScreen)
                {
                    if (contactTable.Rows.Count == 0)
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
                if (txtCMContactLastName.Text.Trim().Length > 0)
                    query += " CMContactLastName LIKE '" + txtCMContactLastName.Text.Trim() + "%' AND ";

                if (txtCMContactFirstName.Text.Trim().Length > 0)
                    query += " CMContactFirstName LIKE '" + txtCMContactFirstName.Text.Trim() + "%' AND ";
                //
                if (txtCMCompanyRegion.Text.Trim().Length > 0)
                    query += " c.CMCompanyRegion LIKE '" + txtCMCompanyRegion.Text.Trim() + "%' AND ";
                //
                if (cboCMContactStatus.Text.Trim().Length > 0)
                    query += " cc.CMContactStatus = " + cboCMContactStatus.EditValue.ToString() + " AND ";
                //
                if (cboCMContactReferredBy.Text.Trim().Length > 0)
                    query += " cc.CMContactReferredBy = " + cboCMContactReferredBy.EditValue.ToString() + " AND ";
                //
                if (cboCMCompanyTerritory.Text.Trim().Length > 0)
                    query += " c.CMCompanyTerritory = " + cboCMCompanyTerritory.EditValue.ToString() + " AND ";
                //
                if (cboCMCompanyIndustry.Text.Trim().Length > 0)
                    query += " c.CMCompanyIndustry = " + cboCMCompanyIndustry.EditValue.ToString() + " AND ";
                //
                if (chkCMContactKeyContact.CheckState == CheckState.Checked)
                    query += " cc.CMContactKeyContact = 1  AND ";
                if (chkCMLotusNotes.CheckState == CheckState.Checked)
                    query += " cc.CMLotusNotes = 1  AND ";

                if (query.Length <  11)
                    query = "";
                else
                    query = query.Remove(query.Length - 5, 5);
                GetContactList(query);
                
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocContactReport(contactTable, contactListView,reportSort, reportFilter));
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
            txtCMContactLastName.Text = "";
            txtCMCompanyRegion.Text = "";
            cboCMContactStatus.EditValue = null;
            cboCMContactReferredBy.EditValue = null;
            cboCMCompanyIndustry.EditValue = null;
            cboCMCompanyTerritory.EditValue = null;
            chkCMContactKeyContact.CheckState = CheckState.Unchecked;
            chkCMLotusNotes.CheckState = CheckState.Unchecked;
            btnClear.Visible = false;
        }
        //
        public void UpdateListView( ContactListView contactView)
        {
            try
            {
                if (grdContactListView.Columns["Status"].GroupIndex > -1)
                    grdContactListView.Columns["Status"].UnGroup();
                if (grdContactListView.Columns["Referred By"].GroupIndex > -1)
                    grdContactListView.Columns["Referred By"].UnGroup();
                if (grdContactListView.Columns["Industry"].GroupIndex > -1)
                    grdContactListView.Columns["Industry"].UnGroup();
                if (grdContactListView.Columns["Territory"].GroupIndex > -1)
                    grdContactListView.Columns["Territory"].UnGroup();

                switch (contactView)
                {
                    case ContactListView.Industry:
                        grdContactListView.Columns["Industry"].Group();
                        break;
                    case ContactListView.ReferredBy:
                        grdContactListView.Columns["Referred By"].Group();
                        break;
                    case ContactListView.Status:
                        grdContactListView.Columns["Status"].Group();
                        break;
                    case ContactListView.Territory:
                        grdContactListView.Columns["Territory"].Group();
                        break;
                }
                contactListView = contactView;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocContactReport(contactTable, contactListView, reportSort, reportFilter));
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
                        panReportParamters.Controls.Add(new ctlAdHocContactReport(contactTable, contactListView, reportSort, reportFilter));
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
        private void grdContactListView_MouseUp(object sender, MouseEventArgs e)
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
                contactTable.DefaultView.Sort = command;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocContactReport(contactTable, contactListView, reportSort, reportFilter));
                }   
            }
        }
        //
        private void grdContactListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdContactListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdContactListView.Columns)
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
                contactTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocContactReport(contactTable, contactListView, reportSort, reportFilter));
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
                cboCMContactReferredBy.Properties.DataSource = StaticTables.ReferredBy;
                cboCMContactReferredBy.Properties.PopulateColumns();
                cboCMContactReferredBy.Properties.DisplayMember = "Description";
                cboCMContactReferredBy.Properties.ValueMember = "ID";
                cboCMContactReferredBy.Properties.ShowHeader = false;
                //
                cboCMContactStatus.Properties.DataSource = StaticTables.Status;
                cboCMContactStatus.Properties.PopulateColumns();
                cboCMContactStatus.Properties.DisplayMember = "Description";
                cboCMContactStatus.Properties.ValueMember = "ID";
                cboCMContactStatus.Properties.ShowHeader = false;
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
                    Security.Security.UserID.ToString(), "CMContactList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdContactListView.RestoreLayoutFromStream(stream);
                grdContactListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdContactListView.CustomizationForm != null)
                    grdContactListView.CustomizationForm.Close();
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
            grdContactListView.Columns["CMContactID"].Visible = false;
            grdContactListView.Columns["Contact"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdContactListView.Columns["Contact"].SummaryItem.DisplayFormat = "Total Count: {0:n0}";
        }
        //
        private void grdContactListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuToolWatch.ShowPopup(ctlContactList.MousePosition);
        }

        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdContactListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "CMContactList", configuration);
                        config.Save();
                        grdContactListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdContactListView.CustomizationForm != null)
                            grdContactListView.CustomizationForm.Close();
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
                        if (grdContactListView.CustomizationForm != null)
                        {
                            grdContactListView.CustomizationForm.Enabled = false;
                            grdContactListView.OptionsCustomization.AllowColumnMoving = false;
                            grdContactListView.CustomizationForm.Controls.Clear();
                            grdContactListView.CustomizationForm.Close();
                        }
                        grdContactList.Refresh();
                        grdContactListView.PopulateColumns();
                        grdContactListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdContactListView.CustomizationForm != null)
                            grdContactListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdContactListView.OptionsCustomization.AllowColumnMoving = true;
                    grdContactListView.ColumnsCustomization();

                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdContactListView.RowCount == 0)
                            return;
                        string fileName = "CMContactListAdHoc.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions(true, true);
                        grdContactListView.ExportToXls(tempLocation + "\\" + fileName, option);
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
        private void grdContactList_DoubleClick(object sender, EventArgs e)
        {
            if (grdContactListView.RowCount == 0)
                return;
            DataRow dataRow;
            dataRow = this.grdContactListView.GetDataRow(grdContactListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                if (contact != null)
                {
                    contact.Close();
                    contact.Dispose();
                }
                contact = new frmContact(dataRow[0].ToString(), contactSourceBinding);
                try
                {
                    contact.Show();
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
            frmContact contact = new frmContact("0", contactSourceBinding);
            contact.ShowDialog();
        }
        //
    }
}
