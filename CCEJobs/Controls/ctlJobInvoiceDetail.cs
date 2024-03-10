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

namespace CCEJobs.Controls
{
    public partial class ctlJobInvoiceDetail : UserControl
    {
        protected bool bColumnWidthChanged = false;
        protected bool bColumnWidthChangedd = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        DataSet jobInvoiceDetailDataSet = new DataSet();
        DataSet jobInvoiceDetailAgingDataSet = new DataSet();
        private string filter = "";
        private string jobID;
        private bool isFourDigit = false;
        //
       
        public ctlJobInvoiceDetail()
        {
            InitializeComponent();
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
        public string JobID
        {
            set
            {
                if (jobID != value)
                {
                    jobID = value;
                    GetJobInvoiceDetail();
                }
            }
        }
        //
        //
        public Security.Security.JobCaller JobCaller
        {
            set
            {
                jobCaller = value;
            }
        }
        //
        public string Filter
        {
            get { return filter; }
        }
        //
        public DataSet JobInvoiceDetailDataSet
        {
            get { return jobInvoiceDetailDataSet; }
        }
        //
        public DataSet JobInvoiceDetailAgingDataSet
        {
            get { return jobInvoiceDetailAgingDataSet; }
        }
        //
        public int ReportOption
        {
            get { return radioGroup.SelectedIndex; }
        }
        //
        private void GetJobInvoiceDetail()
        {
            string id;
            if (jobID == "" )   
                id = "0";
            else
                id = jobID;
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdBillSummaryView, "ctlJobInvoiceDetail");
                }
                int selectedIndex = 0;
                bool includePayment = false;
                grdBillSummaryAging.Visible = false;
                grdBillSummary.Visible = true;
                grdBillSummary.Dock = DockStyle.Fill;
                if (radioGroup.SelectedIndex != -1)
                    selectedIndex = radioGroup.SelectedIndex;

                jobInvoiceDetailDataSet = JobCost.GetJobARInvoiceDetail(jobID, selectedIndex);
                if (selectedIndex == 1)
                    jobInvoiceDetailDataSet.Relations[0].RelationName = "Payments";
                else
                    if (selectedIndex == 3)
                        jobInvoiceDetailDataSet.Relations[0].RelationName = "Comments";
                grdBillSummary.DataSource = jobInvoiceDetailDataSet.Tables[0];
                grdBillSummaryView.BestFitColumns();
                grdBillSummaryView.Columns["JobInvoiceID"].Visible = false;
                grdBillSummaryView.Columns["Inv Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryView.Columns["Inv Amt"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryView.Columns["Ret Draw"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryView.Columns["Ret Draw"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryView.Columns["Discount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryView.Columns["Discount"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryView.Columns["Net Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryView.Columns["Net Amt"].DisplayFormat.FormatString = "{0:c2}";

                grdBillSummaryView.Columns["Rec Amt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryView.Columns["Rec Amt"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryView.Columns["Ret Held"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryView.Columns["Ret Held"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryView.Columns["Open Bal"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryView.Columns["Open Bal"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryView.Columns["Inv Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryView.Columns["Inv Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryView.Columns["Ret Draw"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryView.Columns["Ret Draw"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryView.Columns["Discount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryView.Columns["Discount"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryView.Columns["Rec Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryView.Columns["Rec Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryView.Columns["Ret Held"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryView.Columns["Ret Held"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryView.Columns["Net Amt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryView.Columns["Net Amt"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryView.Columns["Open Bal"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryView.Columns["Open Bal"].SummaryItem.DisplayFormat = "{0:c2}";
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdBillSummaryView, "ctlJobInvoiceDetail");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        //
        private void GetJobInvoiceDetailAging()
        {
            string id;
            if (jobID == "")
                id = "0";
            else
                id = jobID;
            try
            {
                if (bColumnWidthChangedd)
                {
                    bColumnWidthChangedd = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdBillSummaryAgingView, "ctlJobInvoiceDetailAging");
                }

                grdBillSummary.Visible = false;
                grdBillSummaryAging.Visible = true;
                grdBillSummaryAging.Dock = DockStyle.Fill;
                jobInvoiceDetailAgingDataSet = JobCost.GetJobARInvoiceDetailAging( " WHERE n.JobID = " + id + " ");
                
                grdBillSummaryAging.DataSource = jobInvoiceDetailAgingDataSet.Tables[0];
                grdBillSummaryAgingView.BestFitColumns();

                grdBillSummaryAgingView.Columns["JobNumber"].Visible = false;
                grdBillSummaryAgingView.Columns["JobName"].Visible = false;
                grdBillSummaryAgingView.Columns["ProjectManager"].Visible = false;
                grdBillSummaryAgingView.Columns["InvoiceNumber"].Caption = "Inv No";
                grdBillSummaryAgingView.Columns["InvoiceDate"].Caption = "Inv Date";
                grdBillSummaryAgingView.Columns["InvoiceDescription"].Caption = "Inv Description";
                grdBillSummaryAgingView.Columns["InvoiceAmount"].Caption = "Inv Amt";
                grdBillSummaryAgingView.Columns["NetAmount"].Caption = "Net Amt";

                grdBillSummaryAgingView.Columns["ReceivedAmount"].Caption = "Rec Amt";
                grdBillSummaryAgingView.Columns["RetentionHeld"].Caption = "Ret Held";
                grdBillSummaryAgingView.Columns["RetentionDraw"].Caption = "Ret Draw";
                grdBillSummaryAgingView.Columns["NetDueAmount"].Caption = "Open Bal";
                grdBillSummaryAgingView.Columns["InvoiceAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["InvoiceAmount"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["NetAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["NetAmount"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["ReceivedAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["ReceivedAmount"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["RetentionHeld"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["RetentionHeld"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["RetentionDraw"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["RetentionDraw"].DisplayFormat.FormatString = "{0:c2}";

                grdBillSummaryAgingView.Columns["NetDueAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["NetDueAmount"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["Current"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["Current"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over30"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["Over30"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over60"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["Over60"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over90"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["Over90"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over120"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["Over120"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over180"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdBillSummaryAgingView.Columns["Over180"].DisplayFormat.FormatString = "{0:c2}";
                grdBillSummaryAgingView.Columns["InvoiceAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["InvoiceAmount"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["ReceivedAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["ReceivedAmount"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["NetAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["NetAmount"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["RetentionHeld"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["RetentionHeld"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["RetentionDraw"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["RetentionDraw"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["NetDueAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["NetDueAmount"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["Current"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["Current"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over30"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["Over30"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over60"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["Over60"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over90"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["Over90"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over120"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["Over120"].SummaryItem.DisplayFormat = "{0:c2}";
                grdBillSummaryAgingView.Columns["Over180"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdBillSummaryAgingView.Columns["Over180"].SummaryItem.DisplayFormat = "{0:c2}";
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdBillSummaryAgingView, "ctlJobInvoiceDetailAging");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdBillSummaryView_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
              GridView grdBillSummaryView = sender as GridView;
            GridView view = grdBillSummaryView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();
            if (radioGroup.SelectedIndex == 1)
            {

                view.Columns["Cust_Id"].Visible = false;
                view.Columns["Inv No"].Visible = false;
                view.Columns["Line_No"].Visible = false;
                view.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["Amount"].DisplayFormat.FormatString = "{0:c2}";
                view.OptionsBehavior.Editable = false;
            }
            else
            {
                if (radioGroup.SelectedIndex == 3)
                {
                    view.Columns["JobInvoiceCommentID"].Visible = false;
                    view.Columns["JobInvoiceID"].Visible = false;
                    view.Columns["JobID"].Visible = false;
                    view.Columns["LastUpdateDate"].OptionsColumn.AllowEdit = false;
                    view.Columns["UserID"].OptionsColumn.AllowEdit = false;
                    view.Columns["LastUpdateDate"].Caption = "Update Date";
                    view.Columns["UserID"].Caption = "User";
                    view.Columns["Comment"].Width = 500;
                    view.Columns["Comment"].ColumnEdit = repComment;

                    if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                         Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                        view.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        view.OptionsBehavior.Editable = true;
                        view.Columns["UserID"].OptionsColumn.AllowEdit = false;
                        view.Columns["LastUpdateDate"].OptionsColumn.AllowEdit = false;

                        view.ValidateRow += new ValidateRowEventHandler(view_ValidateRow);
                        view.InvalidRowException += new InvalidRowExceptionEventHandler(view_InvalidRowException);
                        view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    }
                }
            }
            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }
        //
        private void view_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void view_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DialogResult result;



            DataRowView r = (DataRowView)e.Row;

            result = MessageBox.Show("Save Comment?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    e.Valid = false;
                    break;
                case DialogResult.No:
                    e.Valid = true;
                    r.CancelEdit();
                    break;
                case DialogResult.Yes:
                    if (r["Comment"] == DBNull.Value)
                    {
                        message = message + "Comment is Requred ..\n";
                        valid = false;
                    }

                    if (valid)
                    {
                        UpdateInvoiceComment(r);
                        e.Valid = true;

                        grdBillSummaryView.RefreshData();

                    }
                    else
                    {
                        MessageBox.Show(message, CCEApplication.ApplicationName);
                        e.Valid = false;
                    }
                    break;
            }
        }
        //
        void UpdateInvoiceComment(DataRowView r)
        {
            DataRow row = grdBillSummaryView.GetDataRow(grdBillSummaryView.GetSelectedRows()[0]);

            r["LastUpdateDate"] = DateTime.Today.Date;
            r["UserID"] = Security.Security.LoginID;

            InvoiceComment comment = new InvoiceComment(r["JobInvoiceCommentID"].ToString(),
                                    row["JobInvoiceID"].ToString(),
                                    jobID,
                                    r["Comment"].ToString(),
                                    r["LastUpdateDate"].ToString(),
                                    r["UserID"].ToString());
            comment.Save();
            r["JobInvoiceCommentID"] = comment.JobInvoiceCommentID;
            r["JobInvoiceID"] = row["JobInvoiceID"].ToString();
            

        }
        //
        private void grdBillSummaryView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                jobInvoiceDetailDataSet.Tables[0].DefaultView.RowFilter = grdBillSummaryView.FilterPanelText.Replace("$","").Replace(",","").Replace("(","-").Replace(")","");
                filter = grdBillSummaryView.FilterPanelText.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "");
            }
            catch (Exception ex)
            {
            }
        }
        //
        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup.SelectedIndex == 0 || radioGroup.SelectedIndex == 1 || radioGroup.SelectedIndex == 3)
                GetJobInvoiceDetail();
            else
                GetJobInvoiceDetailAging();
        }
        //
        private void grdBillSummaryAgingView_ColumnFilterChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    string criteria = "";
                    string filter = grdBillSummaryAgingView.FilterPanelText;

                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdBillSummaryAgingView.Columns)
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
                    jobInvoiceDetailAgingDataSet.Tables[0].DefaultView.RowFilter = criteria;
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void grdBillSummaryView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void grdBillSummaryAgingView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedd = true;
        }  
    }
}
