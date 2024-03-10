using System;
using System.Data;
using JCCPurchasing.BusinessLayer;
using JCCPurchasing.Controls;
using DevExpress.XtraReports.UI;
namespace JCCPurchasing.Reports
{
    public static class Reports
    {
        public static void AdHocReport(DataTable table, POListView view,string query, int selectedItem, string reportFilter, string reportSort)
        {
            try
            {
                if (selectedItem == 0 || selectedItem == 2)
                {
                    switch (view)
                    {
                        case POListView.Category:
                            rptAdHocPurchaseOrdersListByCategory report = new rptAdHocPurchaseOrdersListByCategory();
                            if (selectedItem == 2)
                                report.Detail.Visible = false;
                            report.DataSource = table;
                            report.filter.Text = reportFilter;
                            report.SortOrder.Text = reportSort;
                            report.ShowPreviewDialog();
                            break;
                        case POListView.Job:
                            rptAdHocPurchaseOrdersListByJob report1 = new rptAdHocPurchaseOrdersListByJob();
                            if (selectedItem == 2)
                                report1.Detail.Visible = false;
                            report1.DataSource = table;
                            report1.filter.Text = reportFilter;
                            report1.SortOrder.Text = reportSort;
                            report1.ShowPreviewDialog();
                            break;
                        case POListView.List:
                            rptAdHocPurchaseOrdersList report2 = new rptAdHocPurchaseOrdersList();                                
                            report2.DataSource = table;
                            report2.filter.Text = reportFilter;
                            report2.SortOrder.Text = reportSort;
                            report2.ShowPreviewDialog();
                            break;
                        case POListView.PurchasingAgent:
                            rptAdHocPurchaseOrdersListByPurchasingAgent report3 = new rptAdHocPurchaseOrdersListByPurchasingAgent();
                            if (selectedItem == 2)
                                report3.Detail.Visible = false;
                            report3.DataSource = table;
                            report3.filter.Text = reportFilter;
                            report3.SortOrder.Text = reportSort;
                            report3.ShowPreviewDialog();
                            break;
                        case POListView.Vendor:
                            rptAdHocPurchaseOrdersListByVendor report4 = new rptAdHocPurchaseOrdersListByVendor();
                            if (selectedItem == 2)
                                report4.Detail.Visible = false;
                            report4.DataSource = table;
                            report4.filter.Text = reportFilter;
                            report4.SortOrder.Text = reportSort;
                            report4.ShowPreviewDialog();
                            break;
                        case POListView.projectManager:
                            rptAdHocPurchaseOrdersListByProjectManager report5 = new rptAdHocPurchaseOrdersListByProjectManager();
                            if (selectedItem == 2)
                                report5.Detail.Visible = false;
                            report5.DataSource = table;
                            report5.filter.Text = reportFilter;
                            report5.SortOrder.Text = reportSort;
                            report5.ShowPreviewDialog();
                            break;
                    }
                }
                else
                {
                    rptPurchaseOrder report = new rptPurchaseOrder();
                    report.DataSource = PO.GetPOAll(query).Tables[0];
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrder(string JobNumber, string poNumber)
        {
            try
            {
                rptPurchaseOrder report = new rptPurchaseOrder();
                report.DataSource = PO.GetPO(JobNumber, poNumber).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrderAll(string query)
        {
            try
            {
                rptPurchaseOrder report = new rptPurchaseOrder();
                report.DataSource = PO.GetPOAll(query).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrderByNumber(string poNumber)
        {
            try
            {
                rptPurchaseOrder report = new rptPurchaseOrder();
                report.DataSource = PO.GetPurchaseOrder(poNumber).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrderReceivedItems(string poNumber)
        {
            try
            {
                rptPurchaseOrderReceivedItems report = new rptPurchaseOrderReceivedItems();
                report.DataSource = PO.GetPurchaseOrderReceivedItems(poNumber).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GetPOInvoicesWithDifferentJobNumber
        public static void PurchaseOrderInvoices(string poNumber)
        {
            try
            {
                rptPurchaseOrderInvoices report = new rptPurchaseOrderInvoices();
                report.DataSource = PO.GetPurchaseOrderInvoices(poNumber).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void POInvoicesWithDifferentJobNumber(string query)
        {
            try
            {
                rptPOsInvoicesWithDifferentJobNumber report = new rptPOsInvoicesWithDifferentJobNumber();
                report.DataSource = PO.GetPOInvoicesWithDifferentJobNumber(query).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrdersListByType(string jobNumber)
        {
            try
            {
                rptJobPurchaseOrdersList report = new rptJobPurchaseOrdersList();
                report.DataSource = PO.GetJobPurchaseOrdersList(jobNumber).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrdersListBySupplier(string jobNumber)
        {
            try
            {
                rptJobPurchaseOrdersListBySupplier report = new rptJobPurchaseOrdersListBySupplier();
                report.DataSource = PO.GetJobPurchaseOrderListBySupplier(jobNumber).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrdersList5000(string startDate, string endDate)
        {
            try
            {
                rptJobPurchaseOrdersList5000 report = new rptJobPurchaseOrdersList5000();
                report.DataSource = PO.GetJobPurchaseOrdersList5000(startDate, endDate).Tables[0];
                report.txtStartDate.Text = startDate;
                report.txtEndDate.Text = endDate;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PurchaseOrdersListByWorkOrder(string jobNumber, string startDate, string endDate)
        {
            try
            {
                rptJobPurchaseOrdersListByWorkOrder report = new rptJobPurchaseOrdersListByWorkOrder();
                report.DataSource = PO.GetJobPurchaseOrdersListByWorkOrder(jobNumber, startDate, endDate).Tables[0];
                report.txtStartDate.Text = startDate;
                report.txtEndDate.Text = endDate;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         //
        public static void NotUsedPONumbers( string startDate, string endDate)
        {
            try
            {
                rptNotUsedPONumbers report = new rptNotUsedPONumbers();
                report.DataSource = PO.GetNotUsedPONumbers(startDate, endDate).Tables[0];
                report.txtStartDate.Text = startDate;
                report.txtEndDate.Text = endDate;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static void PurchaseOrdersListWithoutInvoices(string where)
        {
            try
            {
                rptPOsWithNoInvoice report = new rptPOsWithNoInvoice();
                report.DataSource = PO.GetPOsWithNoInvoce(where).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
