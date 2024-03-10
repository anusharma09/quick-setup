using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCTimeMaterial.BusinessLayer;
using JCCTimeMaterial.Controls;
using JCCBusinessLayer;
using DevExpress.XtraReports.UI;
namespace JCCTimeMaterial.Reports
{
    public class Reports
    {
        //
     public static void TimeMaterialWorkOrder(string jobID, string jobTimeMaterialWorkOrderID)
        {
            if (String.IsNullOrEmpty(jobTimeMaterialWorkOrderID))
            {
                Exception ex = new Exception("No Selected Work Order to Print!");
                throw ex;
            }
            try
            {
                rptJobTimeMaterialWorkOrder report = new rptJobTimeMaterialWorkOrder();
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


               // report.DataSource = BusinessLayer.TimeMaterialWorkOrder.GetTimeMaterialForm(jobTimeMaterialWorkOrderID).Tables[0];
                report.DataSource = BusinessLayer.TimeMaterialWorkOrder.GetTimeMaterialForm(jobTimeMaterialWorkOrderID, jobID).Tables[0];


                report.Material.ReportSource.DataSource = TimeMaterialWorkOrderMaterial.GetJobTimeMaterialWorkOrderMaterial(jobTimeMaterialWorkOrderID).Tables[0];
                report.Labor.ReportSource.DataSource = TimeMaterialWorkOrderHour.GetJobTimeMaterialWorkOrderHourForm(jobTimeMaterialWorkOrderID).Tables[0];
                report.RentalsSubcontractors.ReportSource.DataSource = TimeMaterialRentalsSubcontractors.GetJobTimeMaterialRentalsSubcontractors(jobTimeMaterialWorkOrderID).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        //
        public static void JobTimeMaterialLog(string jobID, string jobNumber, string jobName, DataTable timeMaterialTable,
                                 string sort, string filter)
        {
            try
            {

                if (timeMaterialTable == null || timeMaterialTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Work Orders to Print!");
                    throw ex;
                }
                else
                {
                    rptJobTimeMaterialLog report = new rptJobTimeMaterialLog();
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

                    report.DataSource = timeMaterialTable;
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
    }
}
