using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCContactManagement.BusinessLayer;
using JCCContactManagement.Controls;
namespace JCCContactManagement.Reports
{
    class Reports
    {
        public static void AdHocReport(DataTable table, CompanyListView view, string sortOrder, string filter)
        {
            try
            {
                switch (view)
                {
                    case CompanyListView.Industry:
                        rptAdHocCompanyListByIndustry report = new rptAdHocCompanyListByIndustry();
                        report.SortOrder.Text = sortOrder;
                        report.filter.Text = filter;
                        report.DataSource = table;
                        report.ShowPreviewDialog();

                       break;
                    case CompanyListView.List:
                        rptAdHocCompanyList report1 = new rptAdHocCompanyList();
                        report1.SortOrder.Text = sortOrder;
                        report1.filter.Text = filter;
                        report1.DataSource = table;
                        report1.ShowPreviewDialog();
                        break;
                    case CompanyListView.ReferredBy:
                        rptAdHocCompanyListByReferredBy report2 = new rptAdHocCompanyListByReferredBy();
                        report2.SortOrder.Text = sortOrder;
                        report2.filter.Text = filter;
                        report2.DataSource = table;
                        report2.ShowPreviewDialog();
                        break;
                    case CompanyListView.Status:
                        rptAdHocCompanyListByStatus report3 = new rptAdHocCompanyListByStatus();
                        report3.SortOrder.Text = sortOrder;
                        report3.filter.Text = filter;
                        report3.DataSource = table;
                        report3.ShowPreviewDialog();
                        break;
                    case CompanyListView.Territory:
                        rptAdHocCompanyListByTerritory report4 = new rptAdHocCompanyListByTerritory();
                        report4.SortOrder.Text = sortOrder;
                        report4.filter.Text = filter;
                        report4.DataSource = table;
                        report4.ShowPreviewDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void AdHocContactReport(DataTable table, ContactListView view, string sortOrder, string filter)
        {
            try
            {
                switch (view)
                {
                    case ContactListView.Industry:
                        rptAdHocContactListByIndustry report = new rptAdHocContactListByIndustry();
                        report.SortOrder.Text = sortOrder;
                        report.filter.Text = filter;
                        report.DataSource = table;
                        report.ShowPreviewDialog();
                        break;
                    case ContactListView.List:
                        rptAdHocContactList report1 = new rptAdHocContactList();
                        report1.SortOrder.Text = sortOrder;
                        report1.filter.Text = filter;
                        report1.DataSource = table;
                        report1.ShowPreviewDialog();
                        break;
                    case ContactListView.ReferredBy:
                        rptAdHocContactListByReferredBy report2 = new rptAdHocContactListByReferredBy();
                        report2.SortOrder.Text = sortOrder;
                        report2.filter.Text = filter;
                        report2.DataSource = table;
                        report2.ShowPreviewDialog();
                        break;
                    case ContactListView.Status:
                        rptAdHocContactListByStatus report3 = new rptAdHocContactListByStatus();
                        report3.SortOrder.Text = sortOrder;
                        report3.filter.Text = filter;
                        report3.DataSource = table;
                        report3.ShowPreviewDialog();
                        break;
                    case ContactListView.Territory:
                        rptAdHocContactListByTerritory report4 = new rptAdHocContactListByTerritory();
                        report4.SortOrder.Text = sortOrder;
                        report4.filter.Text = filter;
                        report4.DataSource = table;
                        report4.ShowPreviewDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
    }
}
