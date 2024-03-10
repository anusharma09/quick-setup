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
    public partial class ctlStaticTables : UserControl
    {
        private DataTable table;
        private string currentTable = "CMActivityType";
        private BindingSource sourceBinding = new BindingSource();
        private Form itemForm;
        public ctlStaticTables()
        {
            InitializeComponent();
            if (Security.Security.UserJCCContactManagementAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                panelControlItem.Visible = false;
            hyperLinkEdit1.Text = "New Activity Type ...";
            lblList.Text = "Activity Type List";
            GetActivityType();
            RestoreCustomization();
        }
        //
        private void treeTables_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            currentTable = e.Node.GetValue(0).ToString();
            switch (e.Node.GetValue(0).ToString())
            {
                case "Activity Type":
                    hyperLinkEdit1.Text = "New Activity Type ...";
                    lblList.Text = "Activity Type List";
                    GetActivityType();
                    break;
                case "Department":
                    hyperLinkEdit1.Text = "New Department ...";
                    lblList.Text = "Department List";
                    GetDepartment();
                    break;
                case "Industry":
                    hyperLinkEdit1.Text = "New Industry ...";
                    lblList.Text = "Industry List";
                    GetIndustry();
                    break;
                case "Referred By":
                    hyperLinkEdit1.Text = "New Referred By ...";
                    GetReferredBy();
                    break;
                case "Status":
                    hyperLinkEdit1.Text = "New Status ...";
                    lblList.Text = "Status List";
                    GetStatus();
                    break;
                case "Territory":
                    hyperLinkEdit1.Text = "New Territory ...";
                    lblList.Text = "Territory List";
                    GetTerritory();
                    break;
                case "Title":
                    hyperLinkEdit1.Text = "New Title ...";
                    lblList.Text = "Title List";
                    GetTitle();
                    break;
            }
            RestoreCustomization();
        }
        //
        private void GetActivityType()
        {
            try
            {
                table = CMActivityType.GetCMActivityTypeList().Tables[0];
                sourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = sourceBinding;
                grdData.DefaultView.PopulateColumns();
                grdDataView.Columns["CMActivityTypeID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetDepartment()
        {
            try
            {
                table = CMDepartment.GetCMDepartmentList().Tables[0];
                sourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = sourceBinding;
                grdData.DefaultView.PopulateColumns();
                grdDataView.Columns["CMDepartmentID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetIndustry()
        {
            try
            {
                table = CMIndustry.GetCMIndustryList().Tables[0];
                sourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = sourceBinding;
                grdData.DefaultView.PopulateColumns();
                grdDataView.Columns["CMIndustryID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetReferredBy()
        {
            try
            {
                table = CMReferredBy.GetCMReferredByList().Tables[0];
                sourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = sourceBinding;
                grdData.DefaultView.PopulateColumns();
                grdDataView.Columns["CMReferredByID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetStatus()
        {
            try
            {
                table = CMStatus.GetCMStatusList().Tables[0];
                sourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = sourceBinding;
                grdData.DefaultView.PopulateColumns();
                grdDataView.Columns["CMStatusID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetTerritory()
        {
            try
            {
                table = CMTerritory.GetCMTerritoryList().Tables[0];
                sourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = sourceBinding;
                grdData.DefaultView.PopulateColumns();
                grdDataView.Columns["CMTerritoryID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetTitle()
        {

            try
            {
                table = CMTitle.GetCMTitleList().Tables[0];
                sourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = sourceBinding;
                grdData.DefaultView.PopulateColumns();
                grdDataView.Columns["CMTitleID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void HideKey()
        {
            switch (currentTable)
            {
                case "Activity Type":
                    grdDataView.Columns["CMActivityTypeID"].Visible = false;
                    break;
                case "Department":
                    grdDataView.Columns["CMDepartmentID"].Visible = false;
                    break;
                case "Industry":
                    grdDataView.Columns["CMIndustryID"].Visible = false;
                    break;
                case "Referred By":
                    grdDataView.Columns["CMReferredByID"].Visible = false;
                    break;
                case "Status":
                    grdDataView.Columns["CMStatusID"].Visible = false;
                    break;
                case "Territory":
                    grdDataView.Columns["CMTerritoryID"].Visible = false;
                    break;
                case "Title":
                    grdDataView.Columns["CMTitleID"].Visible = false;
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
                    Security.Security.UserID.ToString(), currentTable);
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdDataView.RestoreLayoutFromStream(stream);
                grdDataView.OptionsCustomization.AllowColumnMoving = false;

                if (grdDataView.CustomizationForm != null)
                    grdDataView.CustomizationForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdDataView_MouseDown(object sender, MouseEventArgs e)
        {
             if (e.Button == MouseButtons.Right)
                 mnuMenuToolWatch.ShowPopup(ctlStaticTables.MousePosition);
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
                         grdDataView.SaveLayoutToStream(stream);
                         stream.Seek(0, System.IO.SeekOrigin.Begin);
                         System.IO.StreamReader read = new System.IO.StreamReader(stream);
                         string configuration = read.ReadToEnd().Replace("'", "''");

                         Security.BusinessLayer.UserConfiguration config =
                             new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), currentTable, configuration);
                         config.Save();
                         grdDataView.OptionsCustomization.AllowColumnMoving = false;
                         if (grdDataView.CustomizationForm != null)
                             grdDataView.CustomizationForm.Close();
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
                         if (grdDataView.CustomizationForm != null)
                         {
                             grdDataView.CustomizationForm.Enabled = false;
                             grdDataView.OptionsCustomization.AllowColumnMoving = false;
                             grdDataView.CustomizationForm.Controls.Clear();
                             grdDataView.CustomizationForm.Close();
                         }
                         grdData.Refresh();
                         grdDataView.PopulateColumns();
                         grdDataView.OptionsCustomization.AllowColumnMoving = false;
                         if (grdDataView.CustomizationForm != null)
                             grdDataView.CustomizationForm.Close();
                         HideKey();
                     }
                     catch (Exception ex) { }
                     break;
                 case "btnCustomization":
                     grdDataView.OptionsCustomization.AllowColumnMoving = true;
                     grdDataView.Columns[0].OptionsColumn.ShowInCustomizationForm = false;
                     grdDataView.ColumnsCustomization();

                     break;
                 case "btnExportToExcel":
                     try
                     {
                         if (grdDataView.RowCount == 0)
                             return;
                         string fileName = currentTable + ".xls";
                         Exception ex;
                         Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                         string tempLocation = Environment.CurrentDirectory;

                         if (File.Exists(tempLocation + "\\" + fileName))
                             File.Delete(tempLocation + "\\" + fileName);
                         //
                         DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions(true, true);
                         grdDataView.ExportToXls(tempLocation + "\\" + fileName, option);
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
        private void grdDataView_DoubleClick(object sender, EventArgs e)
        {
            if (grdDataView.RowCount == 0)
                return;
            DataRow dataRow;
            dataRow = this.grdDataView.GetDataRow(grdDataView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                try
                {
                    switch (currentTable)
                    {
                        case "Activity Type":
                            itemForm = new frmActivityType(dataRow[0].ToString(), sourceBinding);
                            break;
                        case "Department":
                            itemForm = new frmDepartment(dataRow[0].ToString(), sourceBinding);
                            break;
                        case "Industry":
                            itemForm = new frmIndustry(dataRow[0].ToString(), sourceBinding);
                            break;
                        case "Referred By":
                            itemForm = new frmReferredBy(dataRow[0].ToString(), sourceBinding);
                            break;
                        case "Status":
                            itemForm = new frmStatus(dataRow[0].ToString(), sourceBinding);
                            break;
                        case "Territory":
                            itemForm = new frmTerritory(dataRow[0].ToString(), sourceBinding);
                            break;
                        case "Title":
                            itemForm = new frmTitle(dataRow[0].ToString(), sourceBinding);
                            break;
                    }
                    itemForm.ShowDialog();
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
            try
            {
                switch (currentTable)
                {
                        case "Activity Type":
                            itemForm = new frmActivityType("0", sourceBinding);
                            break;
                        case "Department":
                            itemForm = new frmDepartment("0", sourceBinding);
                            break;
                        case "Industry":
                            itemForm = new frmIndustry("0", sourceBinding);
                            break;
                        case "Referred By":
                            itemForm = new frmReferredBy("0", sourceBinding);
                            break;
                        case "Status":
                            itemForm = new frmStatus("0", sourceBinding);
                            break;
                        case "Territory":
                            itemForm = new frmTerritory("0", sourceBinding);
                            break;                  
                        case "Title":
                            itemForm = new frmTitle("0", sourceBinding);
                            break;
                   }
                itemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
    }
}
