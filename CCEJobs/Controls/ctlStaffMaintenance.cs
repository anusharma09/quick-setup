using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BakirConsulting.DataAccessLayer;
using WindowsClient.Reports;
using WindowsClient.PresentationLayer;
using WindowsClient.BusinessLayer;

namespace WindowsClient.Controls
{
    public partial class ctlStaffMaintenance : DevExpress.XtraEditors.XtraUserControl
    {

        private DevExpress.XtraReports.UI.XtraReport staffReport;
        private BindingSource staffBindingSource = new BindingSource();
        public ctlStaffMaintenance()
        {
            InitializeComponent();
        }

        private void grdStaff_Load(object sender, EventArgs e)
        {
            staffBindingSource.DataSource =  Staff.GetAll().Tables[0].DefaultView;
            this.grdStaff.DataSource = staffBindingSource ;
            this.grdStaff.MainView.PopulateColumns();

            SetStaffView(StaffViewSelection.List);



        }

        public void SetStaffView(StaffViewSelection staffViewSelection)
        {
            switch (staffViewSelection)
            {
                case StaffViewSelection.BusinessCard:
                    grdStaff.MainView = cardView;
                    cardView.CardInterval = 2;
                    //
                    // Add name to caption
                    //
                    cardView.CardCaptionFormat = "";
                    cardView.Columns["StaffID"].Visible = false;
                    cardView.Columns["Staff Role"].Visible = false;
                    cardView.Columns["System User"].Visible = false;

                    cardView.Columns["Login ID"].Visible = false;
                    cardView.Columns["Note"].Visible = false;
                    grdStaff.MainView = cardView;
                    break;
                case StaffViewSelection.List:
                case StaffViewSelection.StaffRole:
                case StaffViewSelection.SystemUser:
                case StaffViewSelection.UserAccess:
                    grdView.Columns[0].ColumnEdit = staffRepository;
                    grdView.Columns[0].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
                    grdView.Columns[0].OptionsFilter.AllowFilter = false;
                    grdView.Columns[0].OptionsColumn.AllowEdit = false;
                    grdView.Columns[0].OptionsColumn.AllowFocus = false;
                    grdView.Columns[0].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                    grdView.Columns[0].OptionsColumn.AllowMove = false;
                    grdView.Columns[0].OptionsColumn.AllowSize = false;
                    grdView.Columns[0].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    grdView.Columns[0].OptionsColumn.ShowCaption = false;
                    grdView.Columns[0].OptionsColumn.FixedWidth = true;
                    grdView.Columns[0].Width = 30;
                    grdView.Images = imageCollection1;
                    grdView.Columns[0].ImageIndex = 1;

                    grdView.Columns[1].ColumnEdit = SearchRepositoryItems.staffRole;
                    SearchRepositoryItems.staffRole.NullText = "";
                    grdView.Columns[1].Width = 200;
                    grdView.Columns[1].Caption = "Staff Role";


                   // grdView.Columns[1].ImageIndex = 2;
                    if (grdView.Columns["Staff Role"].GroupIndex > -1)
                        grdView.Columns["Staff Role"].UnGroup();
                    if (grdView.Columns["User Access"].GroupIndex > -1) 
                        grdView.Columns["User Access"].UnGroup();
                    if (grdView.Columns["System User"].GroupIndex > -1)                     
                        grdView.Columns["System User"].UnGroup();
                    switch (staffViewSelection)
                    {
                        case StaffViewSelection.StaffRole:
                            grdView.Columns["Staff Role"].Group();
                            break;
                        case StaffViewSelection.UserAccess:
                            grdView.Columns["User Access"].Group();
                            break;
                        case StaffViewSelection.SystemUser:
                            grdView.Columns["System User"].Group();
                            break;
                    }

                    grdStaff.MainView = grdView;

                                   
                    break;

            }
        }
        

        public void RestoreEnvironment()
        {
            grdView.RestoreLayoutFromXml(@"c:\Layout.xml");
        }
        public void SaveEnvironment()
        {
            grdView.SaveLayoutToXml(@"c:\Layout.xml");
        }

        private void grdStaff_DoubleClick(object sender, EventArgs e)
        {
            int staffID = 0;
            DataRow dataRow;
            int rowHandle;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitInfo = new DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo();

            bool openForm = false;

         
            if (grdStaff.MainView.RowCount > 0)
            {
             
                if (grdStaff.DefaultView.Name == "grdView")
                {
                    if (grdView.IsDataRow(grdView.GetSelectedRows()[0]))
                    {
                        dataRow = grdView.GetDataRow(grdView.GetSelectedRows()[0]);
                        staffID = int.Parse(dataRow[0].ToString());
                        rowHandle  = grdView.FocusedRowHandle;
                        gridHitInfo = grdView.CalcHitInfo(grdStaff.PointToClient(MousePosition));

                    }


                }
                else
                {
                    if (cardView.IsDataRow(cardView.GetSelectedRows()[0]))
                    {
                        dataRow = cardView.GetDataRow(cardView.GetSelectedRows()[0]);
                        staffID = int.Parse(dataRow[0].ToString());
                        rowHandle = cardView.FocusedRowHandle;

                    }

                }
                if (staffID > 0 && !gridHitInfo.InColumnPanel)
               {
                    PresentationLayer.frmStaff frm = new WindowsClient.PresentationLayer.frmStaff(staffID,staffBindingSource);
                    frm.ShowDialog();
                    

                }
            }

        }

        private void labelControl1_DoubleClick(object sender, EventArgs e)
        {
            PresentationLayer.frmStaff frm = new WindowsClient.PresentationLayer.frmStaff(0, staffBindingSource);
            frm.ShowDialog();
     
        }

        private void dockPanel1_Resize(object sender, EventArgs e)
        {
           
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string report = cboStaffReport.Text;
            string title = "";
            switch (report)
            {
                case "Staff By Role":
                    staffReport = new WindowsClient.Reports.StaffByRoleReport();
                    title = "Staff By Role";
                    break;

                case "Staff By System Users":
                    staffReport = new WindowsClient.Reports.StaffBySystemUserReport();
                    title = "Staff By System User";
                    break;

                case "Staff By User Access":
                    staffReport = new WindowsClient.Reports.StaffByUserAccessReport();
                    title = "Staff By User Access";
                    break;


                case "Staff List":
                    staffReport = new WindowsClient.Reports.StaffListReport();
                    title = "Staff List";
                    break;
                
                case "Staff List with Accounts":
                    staffReport = new WindowsClient.Reports.StaffReport();
                    title = "Staff List with Accounts";

                    break;



            }
            if (radReport.SelectedIndex == 0)
            {

                WindowsClient.PresentationLayer.frmReport myReport = new frmReport(staffReport);
                myReport.Text = title;
                myReport.ShowDialog();

            }
            else
            {
                staffReport.Print();
            }
        }

       
       
    }
}
