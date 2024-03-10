using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CCEJobs.Utilities;

namespace CCEJobs.Controls
{
    public partial class ctlGlobalContacts : UserControl
    {
        private BindingSource contactSourceBinding = new BindingSource();
        private DataTable contactTable;
        private static string queryCondition = "";
        private string reportFilter = "";
        private string reportSort = "";
        private bool initialScreen = true;
        private bool IsNewContact = false;
        public ctlGlobalContacts ()
        {
            InitializeComponent();
            queryCondition = "Where a.GlobalContactID = 0";
            GetContactList(" Where a.GlobalContactID = 0 ");
            initialScreen = false;
        }
        //
        private void grdContactList_DoubleClick ( object sender, EventArgs e)
        {
            DataRow r;
            r = grdContactListView.GetDataRow(grdContactListView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmGlobalContact f = new frmGlobalContact(r[0].ToString());
            f.ShowDialog();
            GetContactList(queryCondition);
        }
        //
        private void ctlContactList_Load ( object sender, EventArgs e)
        {
            if (Security.Security.UserJCCAccess != Security.Security.Access.ApplicationAdministrator)
            {
                if ((Security.Security.UserJCCGlobalContactLevel != Security.Security.AccessLevel.ReadWriteCreate
                && Security.Security.UserJCCGlobalContactLevel != Security.Security.AccessLevel.RedWriteCreateSB))
                {
                    panelControl1.Visible = false;
                    lnkImportContact.Visible = false;
                }
                else
                {
                    panelControl1.Visible = true;
                    lnkImportContact.Visible = true;
                }
            }
            else
            {
                panelControl1.Visible = true;
                lnkImportContact.Visible = true;
            }
            cboCompany.Properties.DataSource = GlobalContacts.GetCompany().Tables[0];
            cboCompany.Properties.DisplayMember = "CompanyName";
            cboCompany.Properties.PopulateColumns();
            cboCompany.Properties.ShowHeader = false;
        }
        public void GetContactList(string where)
        {
            if (! initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
            try
            {
                //int a = 0;
                //int b  = 2 / a; // for test purpose to generate log
                contactTable = GlobalContacts.getContactList(where).Tables[0];
                contactSourceBinding.DataSource = contactTable;
                grdContactList.DataSource = contactSourceBinding;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            finally
            {
                grdContactList.MainView.PopulateColumns();
                grdContactListView.Columns[0].Visible = false;
                lblCount.Text = Convert.ToString(contactTable.Rows.Count);
                RestoreCustomization();
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (contactTable.Rows.Count == 0)
                    {
                        if (!IsNewContact)
                            MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {   //
            // Process The List
            //   
          string query = " WHERE ";
            if (cboCompany.Text.Trim().Length > 0)
            {
                if (cboCompany.Text!="--None--")
                    query += " a.CompanyName = '" + cboCompany.Text.Trim() + "' AND ";
            }
            if (!String.IsNullOrEmpty(txtFirstName.Text))
                query += " a.FirstName like '%" + txtFirstName.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtLastName.Text))
                query += " a.LastName like '%" + txtLastName.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtEmail.Text))
                query += " a.email like '%" + txtEmail.Text.Trim().Replace("'", "''") + "%' AND ";
            if (query.Length == 7)
                query = "";
            else
                query = query.Remove(query.Length - 4, 4);
            queryCondition = query;
            GetContactList(query);
        }

        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cboCompany.EditValue = null;
            btnClear.Visible = false;
        }
       
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
           //frmJob job = new frmJob("0", jobSourceBinding, Security.Security.JobCaller.JCCJob);
           // job.ShowDialog();
        }
       
        private void dockManager1_StartDocking(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }
        //
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
   
            DataRow row = grdContactListView.GetDataRow(e.RowHandle);
           // Job.UpdateAdjustmentPercent(row[0].ToString(), row["AdjustmentPercent"].ToString());
           
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
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "MainJobList", configuration);
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
                        string fileName = "ContactList.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions();
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
        private void RestoreCustomization()
        {
            try
            {
                string configuration = "";

                configuration = Security.BusinessLayer.UserConfiguration.GetConfiguration(
                    Security.Security.UserID.ToString(), "MainJobList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdContactListView.RestoreLayoutFromStream(stream);
                grdContactListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdContactListView.CustomizationForm != null)
                    grdContactListView.CustomizationForm.Close();
               // FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
            }
        }
        //
        //
        private void grdContactListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuJobList.ShowPopup(ctlJobList.MousePosition);
        }

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
            }
            catch
            {
            }
            
        }

        private void grdContactListView_MouseUp(object sender, MouseEventArgs e)
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
                contactTable.DefaultView.Sort = command;
            }
        }

        private void btnAddNewJob_MouseClick(object sender, MouseEventArgs e)
        {
            GlobalContacts globalContact = new GlobalContacts();
            List<ContactList> lstContact = new List<ContactList>();
            try
            {
                openFile.FileName = "*.xls";
                openFile.Filter = "Excel Files|*.xls";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Analyzing duplicate contacts ...");
                    lstContact = globalContact.Import(@openFile.FileName);
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (lstContact.Count>0)
                    {
                        frmImportContact frm = new frmImportContact(lstContact);
                        frm.ShowDialog();
                    }
                   // MessageBox.Show("Employee(s) successfully imported.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }   
        }
        private void hyperLinkEdit1_Click_1 ( object sender, EventArgs e )
        {
            IsNewContact = true;
            frmGlobalContact frm = new frmGlobalContact("0");
            frm.ShowDialog();
            GetContactList(queryCondition);
            IsNewContact = false;
        }
    }
}
