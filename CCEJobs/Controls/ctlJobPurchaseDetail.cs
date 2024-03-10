using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using JCCPurchasing.Reports;
namespace CCEJobs.Controls
{
    public partial class ctlJobPurchaseDetail : UserControl
    {
        DataSet jobPurchaseDetailDataSet = new DataSet();
        //frmPOInvoiceSummary f = new frmPOInvoiceSummary();
        private string filter = "";
        private bool isFourDigit = false;
        private string jobNumber = "0";
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private bool isClosed = false;
        protected bool bColumnWidthChanged = false;
        //
       
        public ctlJobPurchaseDetail()
        {
            InitializeComponent();
           // f.Show();
           // f.Visible = false;
        }
        //
        public bool IsFourDigit
        {
            set
            {    
                isFourDigit = value;
            }
        }
        //
        public string JobNumber
        {
            set
            {
                if (jobNumber != value)
                {
                    jobNumber = value;
                    GetJobPurchaseDetail();
                }
            }
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
        public bool IsClosed
        {
            set
            {
                isClosed = value;
            }
        }
        //
        public string Filter
        {
            get { return filter; }
        }
        //
        public DataSet JobPurchaseDetailDataSet
        {
            get { return jobPurchaseDetailDataSet; }
        }
        //
        public int ReportType
        {
            get { return radioGroup.SelectedIndex; }
        }
        private void GetJobPurchaseDetail()
        {
            string id;
            if (jobNumber == "" )   
                id = "0";
            else
                id = jobNumber;
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    switch (radioGroup.SelectedIndex)
                    {
                        case 4:
                            Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail4");
                            break;
                        case 5:
                            Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail5");
                            break;
                        case 6:
                            Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail6");
                            break;
                        default:
                            Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail4");
                            break;

                    }
                }

                bool includeInvoice = false;
                
                if (radioGroup.SelectedIndex == 1)
                    includeInvoice = true;
                jobPurchaseDetailDataSet = JobCost.GetJobPurchaseDetail(jobNumber, radioGroup.SelectedIndex);
                if (radioGroup.SelectedIndex == 1 ) 
                    jobPurchaseDetailDataSet.Relations[0].RelationName = "Invoices";
                if (radioGroup.SelectedIndex == 3)
                    jobPurchaseDetailDataSet.Relations[0].RelationName = "Received Items";

               // grdPurchaseSummary.DataSource = null;
                grdPurchaseSummaryView.Columns.Clear();

              //  foreach (DevExpress.XtraGrid.Columns.GridColumn g in grdPurchaseSummary.DefaultView)
              //      grdPurchaseSummaryView.Columns.Remove(g);

               grdPurchaseSummary.DataSource = jobPurchaseDetailDataSet.Tables[0];
  
               //if (radioGroup.SelectedIndex == 4)
              //     grdPurchaseSummary.DefaultView.Assign(grdPurchaseSummaryItems, true);
              // else
              //     grdPurchaseSummary.DefaultView.Assign(grdPurchaseSummaryView, true);
               grdPurchaseSummaryView.BestFitColumns();

               //grdPurchaseSummary.DefaultView.Assign()
               grdPurchaseSummaryView.OptionsBehavior.Editable = false;
               switch (radioGroup.SelectedIndex)
               {
                   case 4:
                        grdPurchaseSummaryView.Columns["PONumber"].Caption = "PO";
                        grdPurchaseSummaryView.Columns["LineNumber"].Caption = "Line #";
                        grdPurchaseSummaryView.Columns["CatNo"].Caption = "Catalog Item";
                        grdPurchaseSummaryView.Columns["QuantityOrdered"].Caption = "Qty Ordered";
                        grdPurchaseSummaryView.Columns["QuantityReceived"].Caption = "Qty Received";
                        grdPurchaseSummaryView.Columns["QuantityBackOrder"].Caption = "Qty Bk. Ord.";
                        grdPurchaseSummaryView.Columns["ExtGross"].Caption = "Total";
                        grdPurchaseSummaryView.Columns["Price"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        grdPurchaseSummaryView.Columns["Price"].DisplayFormat.FormatString = "{0:c2}";
                        grdPurchaseSummaryView.Columns["ExtGross"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        grdPurchaseSummaryView.Columns["ExtGross"].DisplayFormat.FormatString = "{0:c2}";
                        grdPurchaseSummaryView.Columns["Price"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        grdPurchaseSummaryView.Columns["Price"].SummaryItem.DisplayFormat = "{0:c2}";
                        grdPurchaseSummaryView.Columns["ExtGross"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        grdPurchaseSummaryView.Columns["ExtGross"].SummaryItem.DisplayFormat = "{0:c2}";
                        break;
                   case 5:
                       grdPurchaseSummaryView.Columns["Gross Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Gross Amt"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Net Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Net Amt"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Remaining Balance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Remaining Balance"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Variance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Variance"].DisplayFormat.FormatString = "{0:c2}";
                       break;

                   case 6:
                       grdPurchaseSummaryView.Columns["Gross Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Gross Amt"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Gross Pay Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Gross Pay Amt"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Gross Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                       grdPurchaseSummaryView.Columns["Gross Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Gross Pay Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                       grdPurchaseSummaryView.Columns["Gross Pay Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                       break;

                   default:
                       grdPurchaseSummaryView.Columns["JobPOID"].Visible = false;
                       grdPurchaseSummaryView.Columns["JobNumber"].Visible = false;
                       grdPurchaseSummaryView.Columns["Ship Name"].Visible = false;
                       grdPurchaseSummaryView.Columns["Ship Name"].Caption = "PO Date";
                       grdPurchaseSummaryView.Columns["Gross Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Gross Amt"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Net Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Net Amt"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Invoices Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Invoices Total"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Remaining Balance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Remaining Balance"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Variance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                       grdPurchaseSummaryView.Columns["Variance"].DisplayFormat.FormatString = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Ship Date"].Caption = "Date Issued";
                       grdPurchaseSummaryView.Columns["Gross Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                       grdPurchaseSummaryView.Columns["Gross Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Net Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                       grdPurchaseSummaryView.Columns["Net Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Invoices Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                       grdPurchaseSummaryView.Columns["Invoices Total"].SummaryItem.DisplayFormat = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Remaining Balance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                       grdPurchaseSummaryView.Columns["Remaining Balance"].SummaryItem.DisplayFormat = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Variance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                       grdPurchaseSummaryView.Columns["Variance"].SummaryItem.DisplayFormat = "{0:c2}";
                       grdPurchaseSummaryView.Columns["Comment"].Width = 200;
                       if (radioGroup.SelectedIndex != 0)
                       {
                           grdPurchaseSummaryView.Columns["Comment"].Visible = false;
                           grdPurchaseSummaryView.Columns["CommentFlag"].Visible = false;
                       }
                       else
                       {
                           grdPurchaseSummaryView.Columns["Comment"].Visible = true;
                           grdPurchaseSummaryView.Columns["CommentFlag"].Visible = true;
                           grdPurchaseSummaryView.Columns["CommentFlag"].Caption = "";
                           if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                                 Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly  || isClosed)
                           {

                           }
                           else
                           {
                               grdPurchaseSummaryView.OptionsBehavior.Editable = true;
                               grdPurchaseSummaryView.Columns["Ship Name"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Gross Amt"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Net Amt"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Invoices Total"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Remaining Balance"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Variance"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Ship Date"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Gross Amt"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Net Amt"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Invoices Total"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Remaining Balance"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Variance"].OptionsColumn.AllowEdit = false;
                               grdPurchaseSummaryView.Columns["Work Order"].OptionsColumn.AllowEdit = false;
                               
                               grdPurchaseSummaryView.Columns["Comment"].OptionsColumn.AllowEdit = true;
                               grdPurchaseSummaryView.Columns["CommentFlag"].OptionsColumn.AllowEdit = true;
                               grdPurchaseSummaryView.Columns["Comment"].ColumnEdit = repComment;
                           }
                       }
                       break;

               }

               switch (radioGroup.SelectedIndex)
               {
                   case 4:
                       Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail4");
                       break;
                   case 5:
                       Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail5");
                       break;
                   case 6:
                       Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail6");
                       break;
                   default:
                       Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail4");
                       break;

               }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }


        private void grdBillSummaryView_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView grdPurchaseSummaryView = sender as GridView;
            GridView view = grdPurchaseSummaryView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
           // view.DoubleClick += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(view_DoubleClick,e.ToString() );

            
            view.RowStyle += new RowStyleEventHandler(view_RowStyle);
            view.DoubleClick += new EventHandler(grdBillSummaryCheckView_DoubleClick);
            view.BeginDataUpdate();
            view.BestFitColumns();
            view.Columns["PO"].Visible = false;
            if (radioGroup.SelectedIndex == 1)
            {
                view.Columns["Job"].Visible = false;
                view.Columns["Gross Pay Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["Gross Pay Amt"].DisplayFormat.FormatString = "{0:c2}";
                view.Columns["Gross Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["Gross Amt"].DisplayFormat.FormatString = "{0:c2}";
            }
            else
            {
                view.Columns["Price"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["Price"].DisplayFormat.FormatString = "{0:c2}";
                view.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["Total"].DisplayFormat.FormatString = "{0:c2}";
                view.Columns["Qty Recvd"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["Qty Recvd"].DisplayFormat.FormatString = "{0:n0}";
            }

            view.OptionsBehavior.Editable = false;
            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }

        void view_RowStyle(Object sender,  RowStyleEventArgs e)
        {
            if (radioGroup.SelectedIndex != 1)
                return;
            GridView View = sender as GridView;
            
            string selectedJob = View.GetRowCellDisplayText(e.RowHandle, View.Columns["JobNumber"]).ToString();
            if(selectedJob != jobNumber)
            {
                e.Appearance.BackColor = Color.Tomato;  
            }
        }

        //
        // Event Handler for the Double Click
        // EventArgs e
        //
        void view_DoubleClick(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e )
        {
            //MessageBox.Show("This is a test");


            //DataView r = (DataRow) grdPurchaseSummary.Views[1].GetRow(1).
            //  if (r != null)
            //  {
            //      MessageBox.Show(r[2].ToString());
            //  }
            frmPOInvoiceSummary f = new frmPOInvoiceSummary();
            //f.Visible = false;
            f.Show();
            f.Visible = false;
           // f.Show();
           // f.Visible = false;
        }

        private void grdBillSummaryView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                
                
                jobPurchaseDetailDataSet.Tables[0].DefaultView.RowFilter = grdPurchaseSummaryView.FilterPanelText.Replace("$","").Replace(",","").Replace("(","-").Replace(")","");
                filter = grdPurchaseSummaryView.FilterPanelText.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "");
            }
            catch (Exception ex)
            {
            }
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetJobPurchaseDetail();
        }

        private void grdPurchaseSummaryView_DoubleClick(object sender, EventArgs e)
        {


            DataRow r = grdPurchaseSummaryView.GetDataRow(grdPurchaseSummaryView.GetSelectedRows()[0]);
            if (r != null)
            {
                switch (radioGroup.SelectedIndex)
                {
                    case 3:
                        JCCPurchasing.Reports.Reports.PurchaseOrderReceivedItems(r["PO"].ToString());
                        break;
                    case 1:
                        JCCPurchasing.Reports.Reports.PurchaseOrderInvoices(r["PO"].ToString());
                        break;
                    case 0:
                    case 2:
                        JCCPurchasing.Reports.Reports.PurchaseOrder(r["JobNumber"].ToString(), r["PO"].ToString());
                        break;
                }
            }
        }

        private void grdBillSummaryCheckView_DoubleClick(object sender, EventArgs e)
        {
            
          /*  int row = (sender as GridView).FocusedRowHandle;
            Object dataRow = (sender as GridView).GetRow((sender as GridView).FocusedRowHandle);
            DataRowView r = (DataRowView)dataRow;


            if (r[1].ToString().Length > 0)
            {
                f.InvoiceNumber = r[1].ToString();
            }
            if (r[2].ToString().Length > 0)
            {
                f.Vendor = r[2].ToString().Substring(0, 5);
            }
            if (r[4].ToString().Length > 0)
            {
                f.InvoiceAmount = r[4].ToString().Replace("$", "").Replace(",", "");
            }
            if (r[6].ToString().Length > 0)
            {
                f.InvoiceDate = r[6].ToString().Substring(0, 2) + "-" +
                                r[6].ToString().Substring(3, 2) + "-" +
                                r[6].ToString().Substring(6, 4);
            }
           */
        }

        private void ctlJobPurchaseDetail_Leave(object sender, EventArgs e)
        {
           // f.Close();
        }

        private void grdPurchaseSummaryView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
           
            if (grdPurchaseSummaryView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdPurchaseSummaryView.GetDataRow(grdPurchaseSummaryView.GetSelectedRows()[0]);
                if (r == null)
                    return;

                try
                {

                    JobCost.UpdateJobPO(r["JobPOID"].ToString(),
                        r["CommentFlag"].ToString() == "True" ? "1" : "0",
                        r["Comment"].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }
        //
        private void grdPurchaseSummaryView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdPurchaseSummaryView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

      
  
    }
}
