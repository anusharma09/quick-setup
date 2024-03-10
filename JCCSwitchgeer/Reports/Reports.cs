using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCSwitchgear.BusinessLayer;
using JCCSwitchgear.Controls;
using JCCBusinessLayer;
using DevExpress.XtraReports.UI; 

namespace JCCSwitchgear.Reports
{
    public class Reports
    {
        public static void SwitchgearReleaseForm(string jobID, string jobSwitchgearReleaseID)
        {
            if (String.IsNullOrEmpty(jobSwitchgearReleaseID))
            {
                Exception ex = new Exception("No Selected Switchgear Release to Print!");
                throw ex;
            }
            try
            {
                rptJobSwitchgearReleaseForm report = new rptJobSwitchgearReleaseForm();
                DataTable table = Job.GetJobOffice(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    if (table.Rows.Count > 0)
                    {
                        report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                        report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                        report.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                            table.Rows[0]["City"].ToString() + ", " +
                                                table.Rows[0]["State"].ToString() + " " +
                                                table.Rows[0]["ZipCode"].ToString();
                    }
                }


                report.DataSource = BusinessLayer.SwitchgearRelease.GetSwitchgearReleaseForm(jobSwitchgearReleaseID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SwitchgearRevisionForm(string jobID, string jobSwitchgearRevisionID)
        {
            if (String.IsNullOrEmpty(jobSwitchgearRevisionID))
            {
                Exception ex = new Exception("No Selected Switchgear Revision to Print!");
                throw ex;
            }
            try
            {
                rptJobSwitchgearRevisionForm report = new rptJobSwitchgearRevisionForm();
                DataTable table = Job.GetJobOffice(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    if (table.Rows.Count > 0)
                    {
                        report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                        report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                        report.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                            table.Rows[0]["City"].ToString() + ", " +
                                                table.Rows[0]["State"].ToString() + " " +
                                                table.Rows[0]["ZipCode"].ToString();
                    }
                }


                report.DataSource = BusinessLayer.SwitchgearRevision.GetSwitchgearRevisionForm(jobSwitchgearRevisionID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobSwitchgearLog(string jobID, string jobNumber, string jobName, DataSet switchgearDataSet,
                                      string sort, string filter)
        {
            try
            {

                if (switchgearDataSet == null || switchgearDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Switchgear to Print!");
                    throw ex;
                }
                else
                {
                    rptJobSwitchgearLog report = new rptJobSwitchgearLog();
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

                    report.DataSource = switchgearDataSet.Tables[0];
                    report.sub.ReportSource.DataSource = switchgearDataSet.Tables[1];
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.txtFilter.Text = filter;
                    //report.txtSort.Text = sort;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static void JobSwitchgearReleaseLog(string jobID, string jobNumber, string jobName, DataSet switchgearReleaseDataSet,
                                      string sort, string filter)
        {
            try
            {

                if (switchgearReleaseDataSet == null || switchgearReleaseDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Switchgear Release to Print!");
                    throw ex;
                }
                else
                {
                    rptJobSwitchgearReleaseLog report = new rptJobSwitchgearReleaseLog();
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

                    report.DataSource = switchgearReleaseDataSet.Tables[0];
                    report.sub.ReportSource.DataSource = switchgearReleaseDataSet.Tables[1];
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.txtFilter.Text = filter;
                    //report.txtSort.Text = sort;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobSwitchgearRevisionLog(string jobID, string jobNumber, string jobName, DataSet switchgearRevisionDataSet,
                                      string sort, string filter)
        {
            try
            {

                if (switchgearRevisionDataSet == null || switchgearRevisionDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Switchgear Revision to Print!");
                    throw ex;
                }
                else
                {
                    rptJobSwitchgearRevisionLog report = new rptJobSwitchgearRevisionLog();
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

                    report.DataSource = switchgearRevisionDataSet.Tables[0];
                    report.sub.ReportSource.DataSource = switchgearRevisionDataSet.Tables[1];
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.txtFilter.Text = filter;
                    //report.txtSort.Text = sort;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
