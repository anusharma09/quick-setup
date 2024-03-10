using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using JCCBusinessLayer;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;
using CCEJobs.Controls;
using JCCReports;
using DevExpress.XtraReports.UI;
namespace CCEJobs.Subcontracts.Reports
{
    class Reports
    {

        public static void JobProgressSummaryReport(string query, string period)
        {
            try
            {
                rptJobProgressSummaryHistory report = new rptJobProgressSummaryHistory();
                report.DataSource = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (period.Length > 0)
                    report.txtPeriod.Text = period;
                else
                    report.txtPeriod.Text = "Current";
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static void SubcontractSheet(string jobID, string subcontractID)
        {
            try
            {
                string query;
                rptSubcontract report = new rptSubcontract();
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

                report.DataSource = Subcontract.GetSubcontractSheet(subcontractID).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 



        public static void JobSheet(string jobID)
        {
            try
            {
                rptJobSheet report = new rptJobSheet();
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

                report.DataSource = Job.GetJobSetupSheetData(jobID).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void JobProgressSummary(string jobID, string JobNumber, string jobName, string period)
        {
            try
            {


                rptJobProgressSummary report = new rptJobProgressSummary();
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
                if (period.Trim().Length > 0)
                {
                    report.DataSource = Job.GetJobSummaryHistory(jobID, period).Tables[0];
                    report.txtPeriod.Text = period;
                }
                else
                {
                    report.DataSource = Job.GetJobSummary(jobID).Tables[0];
                    report.lblPeriod.Visible = false;
                }
                report.txtJobName.Text = jobName;
                report.txtJobNumber.Text = JobNumber;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        // Job Labor Analysis
        //
      
        // Job Invoice Detail
        //
        //        
         public static void SubcontractChangeOrderList(string subcontractID, string jobID)
        {
            try
            {


                rptSubcontractChangeOrderList report = new rptSubcontractChangeOrderList();
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

                report.DataSource = SubcontractChangeOrder.GetSubcontractChangeOrders(subcontractID).Tables[0];
               
                // Subcontract Summary
                table = Subcontract.GetSubcontractSummary(subcontractID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    report.txtJobNumber.Text = table.Rows[0]["JobNumber"].ToString();
                    report.txtJobName.Text = table.Rows[0]["JobName"].ToString();
                    report.txtSubcontractNumber.Text = table.Rows[0]["SubcontractNumber"].ToString();

                    report.txtOriginalContractAmount.Text =    String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["OriginalContract"] == DBNull.Value ? "0" :  table.Rows[0]["OriginalContract"].ToString()));
                    report.txtOriginalContractCost.Text = String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["TotalOriginalContractCost"] == DBNull.Value ? "0" : table.Rows[0]["TotalOriginalContractCost"].ToString()));

                    report.txtApprovedCOAmount.Text = String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["ApprovedChanges"] == DBNull.Value ? "0" : table.Rows[0]["ApprovedChanges"].ToString()));
                    report.txtApprovedCOCost.Text = String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["TotalApprovalCost"] == DBNull.Value ? "0" : table.Rows[0]["TotalApprovalCost"].ToString()));

                    report.txtPendingCOWithProceedAmount.Text = String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["PendingChanges"] == DBNull.Value ? "0" :  table.Rows[0]["PendingChanges"].ToString()));
                    report.txtPendingCOWithProceedCost.Text = String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["TotalPendingCost"] == DBNull.Value ? "0" : table.Rows[0]["TotalPendingCost"].ToString()));

                    report.txtCurrentContractAmount.Text = String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["CurrentContract"] == DBNull.Value ? "0" : table.Rows[0]["CurrentContract"].ToString()));
                    report.txtCurrentContractCost.Text = String.Format("{0:c2}",Convert.ToDouble(table.Rows[0]["TotalCost"] == DBNull.Value ? "0" : table.Rows[0]["TotalCost"].ToString()));
                }





                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SubcontractChangeOrderDetail(string subcontractChangeOrderID, string jobID)
        {
            try
            {
                DataTable table = SubcontractChangeOrder.GetSubcontractChangeOrderDetail(subcontractChangeOrderID).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No data available for the Change Control");
                    throw ex;

                }
                else
                {
                    rptSubcontractBreakdownSheet report = new rptSubcontractBreakdownSheet();

                    DataTable table1 = Job.GetJobOffice(jobID).Tables[0];
                    if (table1.Rows.Count > 0)
                    {
                        report.txtPhone.Text = "Phone: " + table1.Rows[0]["Phone"].ToString();
                        report.txtFax.Text = "Fax: " + table1.Rows[0]["Fax"].ToString();
                        report.txtAddress.Text = table1.Rows[0]["Address"].ToString() + " " +
                                            table1.Rows[0]["City"].ToString() + ", " +
                                                table1.Rows[0]["State"].ToString() + " " +
                                                table1.Rows[0]["ZipCode"].ToString();
                    }

                    report.DataSource = table;
                    if (table.Rows[0]["SubcontractChangeOrderNumber"].ToString() == "0")
                    {
                        
                        report.txtContractAmountTitle.Text = "Subcontract Amt.:";
                    }
                    else
                    {
                        report.txtContractAmountTitle.Text = "Subcontract CO. Amt.:";
                    }
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void JobSubcontractLog(string subcontractID)
        {
            try
            {
                DataTable table = SubcontractChangeOrder.GetSubcontractLog(subcontractID).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No data available for the Change Control");
                    throw ex;

                }

                else
                {
                    rptSubcontractContractLog report = new rptSubcontractContractLog();

                    report.DataSource = table;
                    //report.txtPeriod.Text = "Current";
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
