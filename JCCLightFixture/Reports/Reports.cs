using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCLightFixture.BusinessLayer;
using JCCLightFixture.Controls;
using JCCBusinessLayer;
using DevExpress.XtraReports.UI;

namespace JCCLightFixture.Reports
{
    public class Reports
    {
        public static void LightFixtureReleaseForm(string jobID, string jobLightFixtureReleaseID)
        {
            if (String.IsNullOrEmpty(jobLightFixtureReleaseID))
            {
                Exception ex = new Exception("No Selected Light Fixture Release to Print!");
                throw ex;
            }
            try
            {
                rptJobLightFixtureReleaseForm report = new rptJobLightFixtureReleaseForm();
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


                report.DataSource = BusinessLayer.JobLightFixtureRelease.GetLightFixtureReleaseForm(jobLightFixtureReleaseID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void LightFixtureRevisionForm(string jobID, string jobLightFixtureRevisionID)
        {
            if (String.IsNullOrEmpty(jobLightFixtureRevisionID))
            {
                Exception ex = new Exception("No Selected Light Fixture Revision to Print!");
                throw ex;
            }
            try
            {
                rptJobLightFixtureRevisionForm report = new rptJobLightFixtureRevisionForm();
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


                report.DataSource = BusinessLayer.JobLightFixtureRevision.GetLightFixtureRevisionForm(jobLightFixtureRevisionID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //
        public static void JobLightFixtureLog(string jobID, string jobNumber, string jobName, DataSet lightFixtureDataSet,
                                      string sort, string filter)
        {
            try
            {

                if (lightFixtureDataSet == null || lightFixtureDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Light Fixture to Print!");
                    throw ex;
                }
                else
                {
                    rptJobLightFixtureLog report = new rptJobLightFixtureLog();
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

                    report.DataSource = lightFixtureDataSet.Tables[0];
                    report.sub.ReportSource.DataSource = lightFixtureDataSet.Tables[1];
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
        public static void JobLightFixtureReleaseLog(string jobID, string jobNumber, string jobName, DataSet lightFixtureReleaseDataSet,
                                      string sort, string filter)
        {
            try
            {

                if (lightFixtureReleaseDataSet == null || lightFixtureReleaseDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Light Fixture Release to Print!");
                    throw ex;
                }
                else
                {
                    rptJobLightFixtureReleaseLog report = new rptJobLightFixtureReleaseLog();
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

                    report.DataSource = lightFixtureReleaseDataSet.Tables[0];
                    report.sub.ReportSource.DataSource = lightFixtureReleaseDataSet.Tables[1];
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
        public static void JobLightFixtureRevisionLog(string jobID, string jobNumber, string jobName, DataSet lightFixtureRevisionDataSet,
                                      string sort, string filter)
        {
            try
            {

                if (lightFixtureRevisionDataSet == null || lightFixtureRevisionDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Light Fixture Revision to Print!");
                    throw ex;
                }
                else
                {
                    rptJobLightFixtureRevisionLog report = new rptJobLightFixtureRevisionLog();
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

                    report.DataSource = lightFixtureRevisionDataSet.Tables[0];
                    report.sub.ReportSource.DataSource = lightFixtureRevisionDataSet.Tables[1];
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
