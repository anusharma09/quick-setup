using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCEquipmentRental.BusinessLayer;
using JCCEquipmentRental.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace JCCEquipmentRental.Controls
{
 
    public partial class ctlEquipmentRental : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource equipmentRentalSourceBinding = new BindingSource();
        private DataTable equipmentRentalDataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobEquipmentRentalID;
        //
        public ctlEquipmentRental()
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
        public string JobID
        {
            set
            {
                jobID = value;
                if (jobID == "")
                    jobID = "0";
                GetEquipmentRental();
                SetControlAccess();
            }
        }
        //
        public DataTable EquipmentRentalDataTable
        {
            get
            {
                return equipmentRentalDataTable;
            }
        }
        //
        public String JobEquipmentRentalID
        {
            get
            {
                return jobEquipmentRentalID;
            }
        }
        //
        public String EquipmentRentalSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String EquimentRentalFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetEquipmentRental()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobEquipmentRentalView, "ctlEquipmentRental");
                }

                equipmentRentalDataTable = EquipmentRental.GetJobEquipmentRentalList(jobID).Tables[0];
                equipmentRentalSourceBinding.DataSource = equipmentRentalDataTable;
                grdJobEquipmentRental.DataSource = equipmentRentalSourceBinding;
                grdJobEquipmentRentalView.Columns["JobEquipmentRentalID"].Visible = false;
                grdJobEquipmentRentalView.Columns["JobID"].Visible = false;

               // grdSubmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
               // grdSubmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdJobEquipmentRentalView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobEquipmentRentalView, "ctlEquipmentRental");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCJob && Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                panJobEquipmentRental.Visible = true;
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panJobEquipmentRental.Visible = false;
                }
                else
                {
                    panJobEquipmentRental.Visible = true;
                }
            }

        }
        //
        private void grdEquipmentRentalView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdJobEquipmentRentalView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobEquipmentRentalID = "";
                    return;
                }
                jobEquipmentRentalID = r["JobEquipmentRentalID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmEquipmentRental f = new frmEquipmentRental("0", jobID, equipmentRentalSourceBinding, false);
            f.ShowDialog();
            GetEquipmentRental();
        }
        //
        private void grdEquipmentRentalView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdJobEquipmentRentalView.GetDataRow(grdJobEquipmentRentalView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmEquipmentRental f = new frmEquipmentRental(r["JobEquipmentRentalID"].ToString(), jobID, equipmentRentalSourceBinding, false);
            f.ShowDialog();
            GetEquipmentRental();
        }
        //
        private void grdEquipmentRentalView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdJobEquipmentRentalView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobEquipmentRentalView.Columns)
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
                equipmentRentalDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdEquipmentRentalView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1) return;
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
               // ColumnSortOrder sort = info.Column.SortOrder;
                string command = info.Column.FieldName;
                if (info.Column.SortOrder == ColumnSortOrder.Ascending)
                {
                    command += " DESC";
                    sort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    sort = info.Column.Caption + " ASC";
                }
                equipmentRentalDataTable.DefaultView.Sort = command;
            }
        }

        private void grdJobEquipmentRentalView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
       // 
    }
}
