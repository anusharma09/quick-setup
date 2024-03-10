using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using JCCEquipmentRental.BusinessLayer;
using JCCEquipmentRental.Controls;
using JCCBusinessLayer;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using DevExpress.XtraReports.UI;
namespace JCCEquipmentRental.Reports
{
    public class Reports
    {

        public static void JobEquipmentRentalEmail(string jobID, string jobEquipmentRentalID)
        {
            //  Exception ex1 = new Exception("The Function is Disabled for the test Environment!");
            //  throw ex1;

            if (String.IsNullOrEmpty(jobEquipmentRentalID))
            {
                Exception ex = new Exception("Please select Equipment Rental to Email!");
                throw ex;
            }
            try
            {
                rptJobEquipmentRental report = new rptJobEquipmentRental();
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

                DataTable t = EquipmentRental.GetEquipmentRentalForm(jobEquipmentRentalID).Tables[0];
                report.DataSource = t;

                string fileName = "EquipmentRental.PDF";
                Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                string tempLocation = Environment.CurrentDirectory;

                if (File.Exists(tempLocation + "\\" + fileName))
                    File.Delete(tempLocation + "\\" + fileName);

                report.ExportToPdf(tempLocation + "\\" + fileName);
                DataRow r = t.Rows[0];

                DataTable eTo = EquipmentRental.GetEmailTo().Tables[0];


                if (r["EmailFrom"].ToString().Trim().Length == 0 || eTo.Rows.Count == 0)
                {
                    Exception ex = new Exception("Either Email From or Email To is not available. Email can't be sent!");
                    throw ex;

                }


                // Email The Document
                string subject = "Equipment Rental For  " +
                       "Request Number: " + r["RequestNumber"].ToString() + "  " +
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
                message.Body = "Equipment Rental FOR: \n" +
                       "Request Number: " + r["RequestNumber"].ToString() + "\n " +
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

        public static bool CheckIsJobNew(int jobId)
        {
            string query = "";
            bool isNew = false;
            query = "SELECT IsNewJob FROM tblJob WHERE JobID = " + jobId;
            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IsNewJob"].ToString()))
                        isNew = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsNewJob"]);
                    else
                        isNew = false;
                }
                return isNew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static void EquipmentRentalForm(string jobID, string jobEquipmentRentalID)
        {
            if (String.IsNullOrEmpty(jobEquipmentRentalID))
            {
                Exception ex = new Exception("No Selected Equipment Rental to Print!");
                throw ex;
            }
            try
            {
                rptJobEquipmentRental report = new rptJobEquipmentRental();
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


                if (CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    report.DataSource = EquipmentRental.GetEquipmentRentalFormForNewjob(jobEquipmentRentalID).Tables[0];
                    report.ShowPreviewDialog();
                }
                else
                {
                    report.DataSource = EquipmentRental.GetEquipmentRentalForm(jobEquipmentRentalID).Tables[0];
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobEquipmentRentalLog(string jobID, string jobNumber, string jobName, DataTable equipmentRentalTable,
                                 string sort, string filter)
        {
            try
            {

                if (equipmentRentalTable == null || equipmentRentalTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Equipment Rental to Print!");
                    throw ex;
                }
                else
                {
                    rptJobEquipmentRentalLog report = new rptJobEquipmentRentalLog();
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

                    report.DataSource = equipmentRentalTable;
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
        public static void AdHocReport(DataTable table, EquipmentRentalListView view, string sortOrder, string filter)
        {
            try
            {
                switch (view)
                {
                    case EquipmentRentalListView.Job:
                        rptAdHocEquipmentRentalListByJob report = new rptAdHocEquipmentRentalListByJob();
                        report.SortOrder.Text = sortOrder;
                        report.filter.Text = filter;
                        report.DataSource = table;
                        report.ShowPreviewDialog();

                        break;
                    case EquipmentRentalListView.List:
                        rptAdHocEquipmentRentalList report1 = new rptAdHocEquipmentRentalList();
                        report1.SortOrder.Text = sortOrder;
                        report1.filter.Text = filter;
                        report1.DataSource = table;
                        report1.ShowPreviewDialog();
                        break;
                    case EquipmentRentalListView.Status:
                        rptAdHocEquipmentRentalListByStatus report2 = new rptAdHocEquipmentRentalListByStatus();
                        report2.SortOrder.Text = sortOrder;
                        report2.filter.Text = filter;
                        report2.DataSource = table;
                        report2.ShowPreviewDialog();
                        break;
                    case EquipmentRentalListView.Vendor:
                        rptAdHocEquipmentRentalListByVendor report3 = new rptAdHocEquipmentRentalListByVendor();
                        report3.SortOrder.Text = sortOrder;
                        report3.filter.Text = filter;
                        report3.DataSource = table;
                        report3.ShowPreviewDialog();
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
