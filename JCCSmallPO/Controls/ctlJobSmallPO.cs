using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCSmallPO.BusinessLayer;
using JCCSmallPO.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace JCCSmallPO.Controls
{
 
    public partial class ctlJobSmallPO : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource smallPOSourceBinding = new BindingSource();
        private DataTable jobSmallPODataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobSmallPOID;
        //
        public ctlJobSmallPO()
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
                GetJobSmallPO();
                SetControlAccess();
            }
        }
        //
        public DataTable SmallPODataTable
        {
            get
            {
                return jobSmallPODataTable;
            }
        }
        //
        public String SmallPOID
        {
            get
            {
                return jobSmallPOID;
            }
        }
        //
        public String SmallPOSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String SmallPOFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetJobSmallPO()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSmallPOView, "ctlJobSmallPO");
                }


                jobSmallPODataTable = SmallPO.GetJobSmallPO(jobID).Tables[0];
                smallPOSourceBinding.DataSource = jobSmallPODataTable;
                grdSmallPO.DataSource = smallPOSourceBinding;
                grdSmallPOView.Columns["JobSmallPOID"].Visible = false;

                grdSmallPOView.Columns["Shipping"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSmallPOView.Columns["Shipping"].DisplayFormat.FormatString = "{0:c2}";


                grdSmallPOView.Columns["Sales Tax"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSmallPOView.Columns["Sales Tax"].DisplayFormat.FormatString = "{0:c2}";

                grdSmallPOView.Columns["Subtotal"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSmallPOView.Columns["Subtotal"].DisplayFormat.FormatString = "{0:c2}";

                grdSmallPOView.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSmallPOView.Columns["Total"].DisplayFormat.FormatString = "{0:c2}";

                grdSmallPOView.Columns["Shipping"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSmallPOView.Columns["Shipping"].SummaryItem.DisplayFormat = "{0:c2}";


                grdSmallPOView.Columns["Sales Tax"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSmallPOView.Columns["Sales Tax"].SummaryItem.DisplayFormat = "{0:c2}";

                grdSmallPOView.Columns["Subtotal"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSmallPOView.Columns["Subtotal"].SummaryItem.DisplayFormat = "{0:c2}";

                grdSmallPOView.Columns["Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSmallPOView.Columns["Total"].SummaryItem.DisplayFormat = "{0:c2}";


                grdSmallPOView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSmallPOView, "ctlJobSmallPO");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                panSmallPO.Visible = false;
            }
            else
            {
                panSmallPO.Visible = true;
            }
        }

        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmSmallPO f = new frmSmallPO("0", jobID,smallPOSourceBinding, false );
            f.ShowDialog();
            GetJobSmallPO();
            
        }

        private void grdSmallPOView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdSmallPOView.GetDataRow(grdSmallPOView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmSmallPO f = new frmSmallPO(r[0].ToString(), jobID, smallPOSourceBinding, false);
            f.ShowDialog();
            GetJobSmallPO();
            
        }
        //
        private void grdSmallPOView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdSmallPOView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdSmallPOView.Columns)
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
                jobSmallPODataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdSmallPOView_MouseUp(object sender, MouseEventArgs e)
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
                jobSmallPODataTable.DefaultView.Sort = command;
            }
        }

        private void grdSmallPOView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdSmallPOView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobSmallPOID = "";
                    return;
                }
                jobSmallPOID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }

        private void grdSmallPOView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
        
    }
}
