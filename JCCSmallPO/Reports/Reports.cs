using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCSmallPO.BusinessLayer;
using JCCSmallPO.Controls;
using JCCBusinessLayer;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;

namespace JCCSmallPO.Reports
{
   
    public class Reports
    {
        //
        public static void SmallPOForm(string jobID, string jobSmallPOID)
        {
            if (String.IsNullOrEmpty(jobSmallPOID))
            {
                Exception ex = new Exception("No Selected Small PO to Print!");
                throw ex;
            }
            try
            {
                string terms = "";
                rptJobSmallPO report = new rptJobSmallPO();
                DataTable table = Job.GetJobOffice(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                    report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                    report.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                        table.Rows[0]["City"].ToString() + ", " +
                                            table.Rows[0]["State"].ToString() + " " +
                                            table.Rows[0]["ZipCode"].ToString();
                }
                table = SmallPO.GetJobSmallPOForm(jobSmallPOID).Tables[0];
                if (!JCCSmallPO.BusinessLayer.StaticTables.IsLoaded)
                    JCCSmallPO.BusinessLayer.StaticTables.PopulateStaticTables();

                if (table.Rows[0]["AttachmentA"].ToString() == "True")
                {
                    foreach (DataRow r in JCCSmallPO.BusinessLayer.StaticTables.Terms.Rows)
                    {
                        if (r["Term"].ToString() == "AttachmentA")
                            terms += r["Description"].ToString() + "\n";
                    }
                }
                if (table.Rows[0]["NoUPSDHL"].ToString() == "True")
                {
                    foreach (DataRow r in JCCSmallPO.BusinessLayer.StaticTables.Terms.Rows)
                    {
                        if (r["Term"].ToString() == "NoUPSDHL")
                            terms += r["Description"].ToString() + "\n";
                    }
                }
                if (table.Rows[0]["Notification"].ToString() == "True")
                {
                    foreach (DataRow r in JCCSmallPO.BusinessLayer.StaticTables.Terms.Rows)
                    {
                        if (r["Term"].ToString() == "Notification")
                            terms += r["Description"].ToString() + "\n";
                    }
                }
                if (table.Rows[0]["PaymentNet30"].ToString() == "True")
                {
                    foreach (DataRow r in JCCSmallPO.BusinessLayer.StaticTables.Terms.Rows)
                    {
                        if (r["Term"].ToString() == "PaymentNet30")
                            terms += r["Description"].ToString() + "\n";
                    }
                }

                report.DataSource = table;
                report.terms.Text = terms;
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
         public static void JobSmallOrderLog(string jobID, string jobNumber, string jobName, DataTable smallPOTable,
                                 string sort, string filter)
        {
            try
            {

                if (smallPOTable == null || smallPOTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Small POs to Print!");
                    throw ex;
                }
                else
                {
                    rptJobSmallPOLog report = new rptJobSmallPOLog();
                    DataTable table = Job.GetJobOffice(jobID).Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                        report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                        report.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                            table.Rows[0]["City"].ToString() + ", " +
                                                table.Rows[0]["State"].ToString() + " " +
                                                table.Rows[0]["ZipCode"].ToString();
                    }

                    report.DataSource = smallPOTable;
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.txtFilter.Text = filter;
                    report.txtSort.Text = sort;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void AdHocReport(DataTable table, SmallPOListView view, string sortOrder, string filter)
        {
            try
            {
                switch (view)
                {
                    case SmallPOListView.Job:
                        rptAdHocSmallPOListByJob report = new rptAdHocSmallPOListByJob();
                        report.SortOrder.Text = sortOrder;
                        report.filter.Text = filter;
                        report.DataSource = table;
                        report.ShowPreviewDialog();
                        break;
                    case SmallPOListView.List:
                        rptAdHocSmallPOList report1 = new rptAdHocSmallPOList();
                        report1.SortOrder.Text = sortOrder;
                        report1.filter.Text = filter;
                        report1.DataSource = table;
                        report1.ShowPreviewDialog();
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
