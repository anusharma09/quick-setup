using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCMaterialOrder.BusinessLayer;
using JCCMaterialOrder.Controls;
using JCCBusinessLayer;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using DevExpress.XtraReports.UI;

namespace JCCMaterialOrder.Reports
{
    public class Reports
    {
        public static void JobMaterialOrderEmail(string jobID, string jobMaterialOrderID)
        {
            //  Exception ex1 = new Exception("The Function is Disabled for the test Environment!");
            //  throw ex1;

            if (String.IsNullOrEmpty(jobMaterialOrderID))
            {
                Exception ex = new Exception("Please select Material Order to Email!");
                throw ex;
            }
            try
            {
                rptJobMaterialOrder report = new rptJobMaterialOrder();
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

                DataTable t = MaterialOrder.GetJobMaterialOrderForm(jobMaterialOrderID).Tables[0];
                report.DataSource = t;

                string fileName = "MaterialOrder.PDF";
                Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                string tempLocation = Environment.CurrentDirectory;

                if (File.Exists(tempLocation + "\\" + fileName))
                    File.Delete(tempLocation + "\\" + fileName);

                report.ExportToPdf(tempLocation + "\\" + fileName);
                DataRow r = t.Rows[0];

                DataTable eTo = MaterialOrder.GetEmailTo().Tables[0];
               

                if (r["EmailFrom"].ToString().Trim().Length == 0 || eTo.Rows.Count == 0)
                {
                    Exception ex = new Exception("Either Email From or Email To is not available. Email can't be sent!");
                    throw ex;

                }


                    // Email The Document
                    string subject = "Material Order For  " +
                           "Order Number: " + r["OrderNumber"].ToString() + "  " +
                           "Job Number: " + r["JobNumber"].ToString().Replace("\r", " ").Replace("\n", " ");
                    MailMessage message;
                    SmtpClient client;
                    Attachment attachment;
                    string file = tempLocation + "\\" + fileName;
                    message = new MailMessage(
                           r["EmailFrom"].ToString(),       // From
                            eTo.Rows[0][0].ToString(),          // To 
                            subject,      // Subject
                            "Body");                          // Body

                    message.To.Clear();
                    foreach (DataRow rr in eTo.Rows)
                        message.To.Add(rr["Email"].ToString());



                    message.CC.Add(r["EmailFrom"].ToString());
                    message.Body = "Material Order FOR: \n" +
                           "Order Number: " + r["OrderNumber"].ToString() + "\n " +
                           "Job Number: " + r["JobNumber"].ToString() + "\n" +
                           " Please see Attachment";
                    // Create  the file attachment for this e-mail message.
                    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                    // Add the file attachment to this e-mail message.
                    message.Attachments.Add(data);


                    client = new SmtpClient("10.1.3.15");
                    client.Send(message);


                //report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //




        //
        public static void MaterialOrderForm(string jobID, string jobMaterialOrderID)
        {
            if (String.IsNullOrEmpty(jobMaterialOrderID))
            {
                Exception ex = new Exception("No Selected Material Order to Print!");
                throw ex;
            }
            try
            {
                rptJobMaterialOrder report = new rptJobMaterialOrder();
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


                report.DataSource = MaterialOrder.GetJobMaterialOrderForm(jobMaterialOrderID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobMaterialOrderLog(string jobID, string jobNumber, string jobName, DataTable materialOrderTable,
                                 string sort, string filter)
        {
            try
            {

                if (materialOrderTable == null || materialOrderTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Material Order to Print!");
                    throw ex;
                }
                else
                {
                    rptJobMaterialOrderLog report = new rptJobMaterialOrderLog();
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

                    report.DataSource = materialOrderTable;
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
        public static void AdHocReport(DataTable table, MaterialOrderListView view, string sortOrder, string filter)
        {
            try
            {
                switch (view)
                {
                    case MaterialOrderListView.Job:
                        rptAdHocMaterialOrderListByJob report = new rptAdHocMaterialOrderListByJob();
                        report.SortOrder.Text = sortOrder;
                        report.filter.Text = filter;
                        report.DataSource = table;
                        report.ShowPreviewDialog();
                        break;
                    case MaterialOrderListView.List:
                        rptAdHocMaterialOrderList report1 = new rptAdHocMaterialOrderList();
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
