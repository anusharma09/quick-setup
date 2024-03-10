using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using JCCContactManagement.BusinessLayer;
using JCCContactManagement.PresentationLayer;

namespace JCCContactManagement.Controls
{
    public partial class ctlCompanyContacts : UserControl
    {
        DataTable table; 
        private string id = "0";
        private string viewFilter = "";
        private string viewSort = "";
        private bool isProduct = false;
        private string productCode = "";
        private BindingSource contactSourceBinding = new BindingSource();
        //
        public ctlCompanyContacts()
        {
            InitializeComponent();
        }
        //
        public string CompamyID
        {
            set
            {
                {
                    id = value;
                    GetCompanyContacts();
                }
            }
        }
        //
        public string CompanyContactsSort
        {
            get { return viewSort; }
        }
        //
        public string CompanyContactsFilter
        {
            get { return viewFilter; }
        }
        //
        public DataTable CompanyContactsTable
        {
            get { return table; }
        }
        //
        private void GetCompanyContacts()
        {
            try
            {
                table = CMContact.GetCMCompanyContacts(id).Tables[0];
                contactSourceBinding.DataSource = table.DefaultView;
                grdData.DataSource = contactSourceBinding;
                grdDataView.Columns["CMContactID"].Visible = false;
                grdDataView.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdDataView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                viewFilter = grdDataView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdDataView.Columns)
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
                table.DefaultView.RowFilter = criteria;
            }
            catch (Exception ex)
            {
            }
        }
        //
        private void grdDataView_MouseUp(object sender, MouseEventArgs e)
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
                    viewSort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    viewSort = info.Column.Caption + " ASC";
                    
                }
                table.DefaultView.Sort = command;
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmContact contact = new frmContact("0", contactSourceBinding, id);
            contact.ShowDialog();
            GetCompanyContacts();
        }

        private void grdDataView_DoubleClick(object sender, EventArgs e)
        {
            if (grdDataView.RowCount == 0)
                return;
            try
            {
                DataRow dataRow;
                dataRow = this.grdDataView.GetDataRow(grdDataView.GetSelectedRows()[0]);
                if (!dataRow.IsNull(0))
                {
                    frmContact contact = new frmContact(dataRow[0].ToString(), contactSourceBinding, id);
                    contact.ShowDialog();
                    GetCompanyContacts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
