using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCDailyLog.BusinessLayer;
using JCCDailyLog.Controls;
using JCCBusinessLayer;
using DevExpress.XtraReports.UI;
namespace JCCDailyLog.Reports
{
    public class Reports
    {
        //
        public static void DailyLogForm ( string jobID, string jobDailyLogID )
        {
            if (String.IsNullOrEmpty(jobDailyLogID))
            {
                Exception ex = new Exception("No Selected Daily Log to Print!");
                throw ex;
            }
            try
            {
                rptJobDailyLog report = new rptJobDailyLog();
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

                report.DataSource = DailyLog.GetDailyLogForm(jobDailyLogID).Tables[0];
                table = DailyLogPicture.GetPicturesForReport(jobDailyLogID).Tables[0];
                if (table.Rows.Count > 0)
                    report.rptPictures.ReportSource.DataSource = table;
                else
                    report.rptPictures.Visible = false;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static void JobDailyLogLog ( string jobID, string jobNumber, string jobName, DataTable dailyLogTable,
                                 string sort, string filter, int reportType )
        {
            try
            {

                if (dailyLogTable == null || dailyLogTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Daily Log to Print!");
                    throw ex;
                }
                else
                {
                    if (reportType == 0)
                    {
                        rptJobDailyLogLog report = new rptJobDailyLogLog();
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

                        report.DataSource = dailyLogTable;
                        report.txtJobNumber.Text = jobNumber;
                        report.txtJobName.Text = jobName;
                        report.txtFilter.Text = filter;
                        report.txtSort.Text = sort;
                        report.ShowPreviewDialog();
                    }
                    else
                    {
                        rptJobDailyLogSummaryLog report = new rptJobDailyLogSummaryLog(reportType);
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

                        report.DataSource = dailyLogTable;
                        report.txtJobNumber.Text = jobNumber;
                        report.txtJobName.Text = jobName;
                        report.txtFilter.Text = filter;
                        report.txtSort.Text = sort;
                        report.ShowPreviewDialog();
                    }
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