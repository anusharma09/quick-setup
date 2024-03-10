using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCMaterialOrder.BusinessLayer;
using JCCMaterialOrder.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace JCCMaterialOrder.Controls
{
 
    public partial class ctlMaterialOrder : UserControl
    {  
        //
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource materialOrderSourceBinding = new BindingSource();
        private DataTable materialOrderDataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobMaterialOrderID;
        protected bool bColumnWidthChanged = false;
        //
        public ctlMaterialOrder()
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
                GetMaterialOrder();
                SetControlAccess();
            }
        }
        //
        public DataTable MaterialOrderDataTable
        {
            get
            {
                return materialOrderDataTable;
            }
        }
        //
        public String JobMaterialOrderID
        {
            get
            {
                return jobMaterialOrderID;
            }
        }
        //
        public String MaterialOrderSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String MaterialOrderFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetMaterialOrder()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    try
                    {
                        Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobMaterialOrderView, "ctlMaterialOrder");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                }
                materialOrderDataTable = MaterialOrder.GetJobMaterialOrderList(jobID).Tables[0];
                materialOrderSourceBinding.DataSource = materialOrderDataTable;
                grdJobMaterialOrder.DataSource = materialOrderSourceBinding;
                grdJobMaterialOrderView.Columns["JobMaterialOrderID"].Visible = false;
                grdJobMaterialOrderView.Columns["JobID"].Visible = false;

               // grdSubmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
               // grdSubmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdJobMaterialOrderView.BestFitColumns();
                try
                {
                    Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobMaterialOrderView, "ctlMaterialOrder");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
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
                panJobMaterialOrder.Visible = true;
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panJobMaterialOrder.Visible = false;
                }
                else
                {
                    panJobMaterialOrder.Visible = true;
                }
            }
        }
        //
        private void grdMaterialOrderView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdJobMaterialOrderView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobMaterialOrderID = "";
                    return;
                }
                jobMaterialOrderID = r["JobMaterialOrderID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmMaterialOrder f = new frmMaterialOrder("0", jobID, materialOrderSourceBinding, false);
            f.ShowDialog();
            GetMaterialOrder();
        }
        //
        private void grdMaterialOrderView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdJobMaterialOrderView.GetDataRow(grdJobMaterialOrderView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmMaterialOrder f = new frmMaterialOrder(r["JobMaterialOrderID"].ToString(), jobID, materialOrderSourceBinding, false);
            f.ShowDialog();
            GetMaterialOrder();
        }
        //
        private void grdMaterialOrderView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdJobMaterialOrderView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobMaterialOrderView.Columns)
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
                materialOrderDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdMaterialOrderView_MouseUp(object sender, MouseEventArgs e)
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
                materialOrderDataTable.DefaultView.Sort = command;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string where = "";

            if (txtOrderDescription.Text.Trim().Length > 0 || txtItemDescription.Text.Trim().Length > 0)
            {
                where = " WHERE (r.JobID = " + jobID + ") ";

                if (txtOrderDescription.Text.Trim().Length > 0 && txtItemDescription.Text.Trim().Length > 0)
                    where += " AND ( r.Description like '%" + txtOrderDescription.Text.Trim() + "%' AND d.Description LIKE '%" + txtItemDescription.Text.Trim() + "%')";
                else
                    if (txtOrderDescription.Text.Trim().Length > 0)
                        where += " AND ( r.Description LIKE '%" + txtOrderDescription.Text.Trim() + "%') ";
                    else
                        if (txtItemDescription.Text.Trim().Length > 0)
                            where += " AND ( d.Description LIKE '%" + txtItemDescription.Text.Trim() + "%' ) ";

            }


            try
            {
                
                if (txtOrderDescription.Text.Trim().Length > 0 || txtItemDescription.Text.Trim().Length > 0)
                    materialOrderDataTable = MaterialOrder.GetJobMaterialOrderListCondition(where).Tables[0];
                else
                    materialOrderDataTable = MaterialOrder.GetJobMaterialOrderList(jobID).Tables[0];
                materialOrderSourceBinding.DataSource = materialOrderDataTable;
                grdJobMaterialOrder.DataSource = materialOrderSourceBinding;
                grdJobMaterialOrderView.Columns["JobMaterialOrderID"].Visible = false;
                grdJobMaterialOrderView.Columns["JobID"].Visible = false;

                // grdSubmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                // grdSubmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdJobMaterialOrderView.BestFitColumns();
                txtOrderDescription.Text = "";
                txtItemDescription.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdJobMaterialOrderView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

      
       // 
    }
}
