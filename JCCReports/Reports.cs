using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;
using JCCBusinessLayer;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace JCCReports
{
    public class Reports
    {
        public enum LaborAnalysisView
        {
            List,
            Phase,
            Code,
            Employee,
            Week,
            HoursType,
            Craft
        }
        //
        public enum ReportTypeView
        {
            Detail,
            Summary
        }
        //
        public enum CostAnalysisView
        {
            List,
            App,
            Phase,
            Code,
            Name,
            Date
        }
        //
        public static void CorrespondenceLetterLog(string jobID, string jobNumber, string jobName, DataTable CorrespondenceTable,
                                   string sort, string filter)
        {
            try
            {

                if (CorrespondenceTable == null || CorrespondenceTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Correspondence Letter to Print!");
                    throw ex;
                }
                else
                {
                    rptCorrespondenceLetterLog report = new rptCorrespondenceLetterLog();
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

                    report.DataSource = CorrespondenceTable;
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
        public static void CorrespondenceLetter(string jobID, string jobCorrespondenceLetterID)
        {
            if (String.IsNullOrEmpty(jobCorrespondenceLetterID))
            {
                Exception ex = new Exception("No Selected Letter to Print!");
                throw ex;
            }
            try
            {
                DataTable table = Job.GetJobOffice(jobID).Tables[0];
                DataTable letter = JobCorrespondenceLetter.GetCorrespondenceLetter(jobCorrespondenceLetterID).Tables[0];

                switch (letter.Rows[0]["CostImpact"].ToString())
                {
                    case "1":
                        rptCorrespondenceLetterEffect report = new rptCorrespondenceLetterEffect();
                        if (table.Rows.Count > 0)
                        {
                            report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }


                        report.DataSource = letter;
                        report.ShowPreviewDialog();
                        break;
                    case "0":
                        rptCorrespondenceLetterNonEffect report1 = new rptCorrespondenceLetterNonEffect();
                        if (table.Rows.Count > 0)
                        {
                            report1.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report1.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report1.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        report1.DataSource = letter;
                        report1.ShowPreviewDialog();
                        break;
                    case "2":
                        rptCorrespondenceLetterFreeFormat report2 = new rptCorrespondenceLetterFreeFormat();
                        if (table.Rows.Count > 0)
                        {
                            report2.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report2.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report2.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        report2.DataSource = letter;
                        report2.ShowPreviewDialog();
                        break;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void MeetingMinutesLog(string jobID, string jobNumber, string jobName, DataTable MeetingMinutesTable,
                                      string sort, string filter)
        {
            try
            {

                if (MeetingMinutesTable == null || MeetingMinutesTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Meeting Minutes to Print!");
                    throw ex;
                }
                else
                {
                    rptMeetingMinutesLog report = new rptMeetingMinutesLog();
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

                    report.DataSource = MeetingMinutesTable;
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
        //
        public static void ChangeOrderContractLetterRev(string jobID, string jobChangeOrderID, string revision)
        {
            if (String.IsNullOrEmpty(jobChangeOrderID))
            {
                Exception ex = new Exception("No Selected Changer Order Contract to Print!");
                throw ex;
            }
            try
            {
                rptChangeOrderContractLetter report = new rptChangeOrderContractLetter();
                DataTable table = Job.GetJobOffice(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    report.subContract.ReportSource.FindControl("txtPhone", false).Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                    report.subContract.ReportSource.FindControl("txtFax", false).Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                    report.subContract.ReportSource.FindControl("txtAddress", false).Text = table.Rows[0]["Address"].ToString() + " " +
                                        table.Rows[0]["City"].ToString() + ", " +
                                            table.Rows[0]["State"].ToString() + " " +
                                            table.Rows[0]["ZipCode"].ToString();
                    report.subLetter.ReportSource.FindControl("txtPhone", false).Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                    report.subLetter.ReportSource.FindControl("txtFax", false).Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                    report.subLetter.ReportSource.FindControl("txtAddress", false).Text = table.Rows[0]["Address"].ToString() + " " +
                                        table.Rows[0]["City"].ToString() + ", " +
                                            table.Rows[0]["State"].ToString() + " " +
                                            table.Rows[0]["ZipCode"].ToString();
                }



                report.subLetter.ReportSource.DataSource = JobChangeOrderContract.GetJobChangeOrderLetterRev(jobChangeOrderID, revision).Tables[0];
                report.subContract.ReportSource.DataSource = JobChangeOrderContract.GetJobChangeOrderRev(jobChangeOrderID, revision).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ChangeOrderContractLetter(string jobID, string jobChangeOrderID)
        {
            if (String.IsNullOrEmpty(jobChangeOrderID))
            {
                Exception ex = new Exception("No Selected Changer Order Contract to Print!");
                throw ex;
            }
            try
            {
                rptChangeOrderContractLetter report = new rptChangeOrderContractLetter();
                DataTable table = Job.GetJobOffice(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    report.subContract.ReportSource.FindControl("txtPhone", false).Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                    report.subContract.ReportSource.FindControl("txtFax", false).Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                    report.subContract.ReportSource.FindControl("txtAddress", false).Text = table.Rows[0]["Address"].ToString() + " " +
                                        table.Rows[0]["City"].ToString() + ", " +
                                            table.Rows[0]["State"].ToString() + " " +
                                            table.Rows[0]["ZipCode"].ToString();
                    report.subLetter.ReportSource.FindControl("txtPhone", false).Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                    report.subLetter.ReportSource.FindControl("txtFax", false).Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                    report.subLetter.ReportSource.FindControl("txtAddress", false).Text = table.Rows[0]["Address"].ToString() + " " +
                                        table.Rows[0]["City"].ToString() + ", " +
                                            table.Rows[0]["State"].ToString() + " " +
                                            table.Rows[0]["ZipCode"].ToString();
                }

                if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                { report.subLetter.ReportSource.DataSource = JobChangeOrderContract.GetJobChangeOrderLetterForNewJob(jobChangeOrderID).Tables[0]; }
                else
                { report.subLetter.ReportSource.DataSource = JobChangeOrderContract.GetJobChangeOrderLetter(jobChangeOrderID).Tables[0]; }


                report.subContract.ReportSource.DataSource = JobChangeOrderContract.GetJobChangeOrder(jobChangeOrderID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobSubmittalLog(string jobID, string jobNumber, string jobName, DataSet submittalDataSet,
                                      string sort, string filter)
        {
            try
            {

                if (submittalDataSet == null || submittalDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Submittal to Print!");
                    throw ex;
                }
                else
                {
                    rptJobSubmittalLog report = new rptJobSubmittalLog();
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

                    report.DataSource = submittalDataSet.Tables[0];
                    report.sub.ReportSource.DataSource = submittalDataSet.Tables[1];
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.txtFilter.Text = filter;
                    report.GroupHeader1.GroupFields[0].FieldName = "Spec";
                    report.GroupHeader1.GroupFields[1].FieldName = "JobSubmittalID";
                    switch (sort)
                    {
                        case "Spec ASC":
                            report.txtSort.Text = sort;
                            report.GroupHeader1.GroupFields[0].SortOrder = DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending;
                            break;
                        case "Spec DESC":
                            report.txtSort.Text = sort;
                            report.GroupHeader1.GroupFields[0].SortOrder = DevExpress.XtraReports.UI.XRColumnSortOrder.Descending;
                            break;
                        default:
                            report.txtSort.Text = "Spec ASC";
                            report.GroupHeader1.GroupFields[0].SortOrder = DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending;
                            break;
                    }
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void SubmittalForm(string jobID, string jobSubmittalID)
        {
            if (String.IsNullOrEmpty(jobSubmittalID))
            {
                Exception ex = new Exception("No Selected Submittal to Print!");
                throw ex;
            }
            try
            {
                rptJobSubmittal report = new rptJobSubmittal();
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


                report.DataSource = JCCBusinessLayer.JobSubmittal.GetJobSubmittalForm(jobSubmittalID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //



        //
        public static void TransmittalForm(string jobID, string jobTransmittalID)
        {
            if (String.IsNullOrEmpty(jobTransmittalID))
            {
                Exception ex = new Exception("No Selected Transmittal to Print!");
                throw ex;
            }
            try
            {
                rptJobTransmittal report = new rptJobTransmittal();
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

                if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    report.DataSource = JCCBusinessLayer.JobTransmittal.GetTransmittalFormForNewJobs(jobTransmittalID).Tables[0];
                    report.ShowPreviewDialog();
                }
                else
                {
                    report.DataSource = JCCBusinessLayer.JobTransmittal.GetTransmittalForm(jobTransmittalID).Tables[0];
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //




        //
        public static void JobTransmittalLog(string jobID, string jobNumber, string jobName, DataTable TransmittalTable,
                                      string sort, string filter)
        {
            try
            {

                if (TransmittalTable == null || TransmittalTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Transmittal to Print!");
                    throw ex;
                }
                else
                {
                    rptJobTransmittalLog report = new rptJobTransmittalLog();
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

                    report.DataSource = TransmittalTable;
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
        public static void JobMajorPOLog(string jobID, string jobNumber, string jobName, DataTable MajorPOTable,
                                      string sort, string filter)
        {
            try
            {

                if (MajorPOTable == null || MajorPOTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Major PO to Print!");
                    throw ex;
                }
                else
                {
                    rptJobMajorPOLog report = new rptJobMajorPOLog();
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

                    report.DataSource = MajorPOTable;
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
        public static void MajorPO(string jobID, string jobMajorPOID)
        {
            if (String.IsNullOrEmpty(jobMajorPOID))
            {
                Exception ex = new Exception("No Selected Major PO to Print!");
                throw ex;
            }
            try
            {
                rptJobMajorPO report = new rptJobMajorPO();
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



                report.DataSource = JCCBusinessLayer.MajorPO.GetJobMajorPOReport(jobMajorPOID).Tables[0];
                //report.ShowPreview();
                report.ShowPreviewDialog();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void MeetingMinutes(string jobID, string meetingMinutesScheduleID, string meetingMinutesSubjectID)
        {
            if (String.IsNullOrEmpty(meetingMinutesScheduleID))
            {
                Exception ex = new Exception("No Selected Meeting Minutes to Print!");
                throw ex;
            }
            try
            {
                rptMeetingMinutes report = new rptMeetingMinutes();
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
                report.DataSource = MeetingMinutesSchedule.GetMeetingMinutesScheduleReport(meetingMinutesScheduleID, meetingMinutesSubjectID).Tables[0];



                report.subAttendee.ReportSource.DataSource = MeetingMinutesAttendee.GetScheduleMeetingMinutesAttendee(meetingMinutesScheduleID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static void ChangeOrderLetterRev(string jobID, string jobChangeOrderID, string revision)
        {
            if (String.IsNullOrEmpty(jobChangeOrderID))
            {
                Exception ex = new Exception("No Selected Changer Order Contract to Print!");
                throw ex;
            }
            try
            {
                rptChangeOrderLetter report = new rptChangeOrderLetter();
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

                if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    report.DataSource = JobChangeOrderContract.GetJobChangeOrderLetterRevFornewjob(jobChangeOrderID, revision).Tables[0];
                    report.ShowPreviewDialog();
                }
                else
                {

                    report.DataSource = JobChangeOrderContract.GetJobChangeOrderLetterRev(jobChangeOrderID, revision).Tables[0];
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static void ChangeOrderLetter(string jobID, string jobChangeOrderID)
        {
            if (String.IsNullOrEmpty(jobChangeOrderID))
            {
                Exception ex = new Exception("No Selected Changer Order Contract to Print!");
                throw ex;
            }
            try
            {
                rptChangeOrderLetter report = new rptChangeOrderLetter();
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


                if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    report.DataSource = JobChangeOrderContract.GetJobChangeOrderLetterForNewJob(jobChangeOrderID).Tables[0];
                    report.ShowPreviewDialog();
                }
                else
                {
                    report.DataSource = JobChangeOrderContract.GetJobChangeOrderLetter(jobChangeOrderID).Tables[0];
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //

        //
        public static void ChangeOrderContractRev(string jobID, string jobChangeOrderID, string revision)
        {
            if (String.IsNullOrEmpty(jobChangeOrderID))
            {
                Exception ex = new Exception("No Selected Changer Order Contract to Print!");
                throw ex;
            }
            try
            {
                rptChangeOrderContract report = new rptChangeOrderContract();
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


                report.DataSource = JobChangeOrderContract.GetJobChangeOrderRev(jobChangeOrderID, revision).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static void ChangeOrderContract(string jobID, string jobChangeOrderID)
        {
            if (String.IsNullOrEmpty(jobChangeOrderID))
            {
                Exception ex = new Exception("No Selected Changer Order Contract to Print!");
                throw ex;
            }
            try
            {
                rptChangeOrderContract report = new rptChangeOrderContract();
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

                //report.lblRev.Visible = false;
                report.DataSource = JobChangeOrderContract.GetJobChangeOrder(jobChangeOrderID).Tables[0];
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static void JobRFISheet(string jobID, string jobRTFID)
        {
            if (String.IsNullOrEmpty(jobRTFID))
            {
                Exception ex = new Exception("Please select RFI to Print!");
                throw ex;
            }
            try
            {
                rptJobRFISheet report = new rptJobRFISheet();
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

                if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    report.DataSource = JobRFI.GetRFISheetForNewJobs(jobRTFID);
                    report.ShowPreviewDialog();

                }
                else
                {
                    report.DataSource = JobRFI.GetRFISheet(jobRTFID);
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool JobMasterProposalSheet(string jobID, string proposalID, string user, string revision)
        {
            if (String.IsNullOrEmpty(proposalID) || proposalID == "0")
            {
                return false;
            }
            try
            {
                rptJobMasterProposalSheet report = new rptJobMasterProposalSheet();
                DataTable table = Job.GetJobOffice(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    
                    report.DynaAddress.Text = table.Rows[0]["Address"].ToString().Replace(",","");
                    report.txtZipCountry.Text = table.Rows[0]["City"].ToString() + ", " + table.Rows[0]["State"].ToString() + "  " + table.Rows[0]["ZipCode"].ToString(); ;
                    report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                    report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                    report.txtEmail.Text = "www.dyna-sd.com";
                    report.txtLicense.Text= "License # 749757";
                }

                DataSet dsProposalDetail = ProjectProposal.Getproposals(Convert.ToInt32(proposalID));
                
                DataTable contact = Contact.GetJobContactForPullDown(jobID).Tables[0];
                dsProposalDetail.Tables[0].Columns.Add("UserName", typeof(String));
                dsProposalDetail.Tables[0].Columns.Add("CompanyName", typeof(String));

                foreach (DataRow dr in dsProposalDetail.Tables[0].Rows)
                {
                    int userID = Convert.ToInt32(dr["User"]);
                    dr["UserName"] = (from DataRow dr1 in contact.Rows
                                      where (int)dr1["ContactID"] == userID
                                      select (string)dr1["Name"]).FirstOrDefault();

                    dr["CompanyName"] = (from DataRow dr1 in contact.Rows
                                         where (int)dr1["ContactID"] == userID
                                         select (string)dr1["Company"]).FirstOrDefault();
                }
                if (dsProposalDetail != null && dsProposalDetail.Tables.Count > 0)
                {
                    DataView view = new DataView(dsProposalDetail.Tables[0]);
                    view.RowFilter = "REV = " + revision;
                    DataTable results = view.ToTable(true).AsEnumerable().First().Table;
                    DataTable dt = new DataTable();
                    dt = results.Clone();
                    dt.ImportRow(results.Rows[0]);

                    report.DataSource = dt;
                    DataSet ds = ProjectProposal.GetPricingForReport(Convert.ToInt32(proposalID), Convert.ToInt32(user), Convert.ToInt32(revision));
                    if (ds.Tables[0].Rows.Count > 0)
                    {                     
                        report.Pricing.ReportSource.DataSource = ds.Tables[0];
                        report.pricingTotal.ReportSource.DataSource = ds.Tables[1];
                    }
                    else
                    {
                        
                        report.Pricing.HeightF = 0;
                        report.Pricing.Visible=false;
                        report.pricingTotal.Visible = false;
                    }

                    if (ProjectProposal.GetPricingAlternateForReport(Convert.ToInt32(proposalID), Convert.ToInt32(user), Convert.ToInt32(revision)).Tables[0].Rows.Count > 0)
                    {
                        report.pricingAlternate.ReportSource.DataSource = ProjectProposal.GetPricingAlternateForReport(Convert.ToInt32(proposalID), Convert.ToInt32(user), Convert.ToInt32(revision)).Tables[0];
                        report.AlternatePricingTotal.ReportSource.DataSource = ProjectProposal.GetPricingAlternateForReport(Convert.ToInt32(proposalID), Convert.ToInt32(user), Convert.ToInt32(revision)).Tables[1];
                    }
                    else
                    {
                        report.pricingAlternate.HeightF = 0;
                        report.pricingAlternate.Visible = false;
                        report.AlternatePricingTotal.Visible = false;
                    }
                    
                    report.ShowPreviewDialog();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //

        public static DataSet GetPricing(int ProposalID, int user, int rev)
        {
            SqlParameter[] par;
            DataSet emp = new DataSet();
            try
            {
                par = new SqlParameter[3];
                par[0] = new SqlParameter("@ProposalID", ProposalID);
                par[1] = new SqlParameter("@user", user);
                par[2] = new SqlParameter("@rev", rev);
                emp = DataBaseUtil.ExecuteParDataset("up_GetPricing", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }
        public static void JobRFIEmail(string jobID, string jobRTFID)
        {
            //  Exception ex1 = new Exception("The Function is Disabled for the test Environment!");
            //  throw ex1;

            if (String.IsNullOrEmpty(jobRTFID))
            {
                Exception ex = new Exception("Please select RFI to Email!");
                throw ex;
            }
            try
            {
                rptJobRFISheet report = new rptJobRFISheet();
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
                DataTable t = new DataTable();
                if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    t = JobRFI.GetRFISheetForNewJobs(jobRTFID).Tables[0];
                    report.DataSource = t;

                }
                else
                {
                    t = JobRFI.GetRFISheet(jobRTFID).Tables[0];
                    report.DataSource = t;
                }

                string fileName = "RFI.PDF";
                Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                string tempLocation = Environment.CurrentDirectory;

                if (File.Exists(tempLocation + "\\" + fileName))
                    File.Delete(tempLocation + "\\" + fileName);

                report.ExportToPdf(tempLocation + "\\" + fileName);
                DataRow r = t.Rows[0];

                if (r["EmailFrom"].ToString().Length > 0 && r["EmailTo"].ToString().Length > 0)
                {
                    // Email The Document
                    string subject = "Request For Information  " +
                           "RFI Number: " + r["JobRFINumber"].ToString() + "  " +
                           "RFI Subject: " + r["RFISubject"].ToString().Replace("\r", " ").Replace("\n", " ");
                    MailMessage message;
                    SmtpClient client;
                    Attachment attachment;
                    string file = tempLocation + "\\" + fileName;
                    message = new MailMessage(
                           r["EmailFrom"].ToString(),       // From
                           r["EmailTo"].ToString(),          // To 
                            subject,      // Subject
                            "Body");                          // Body

                    message.CC.Add(r["EmailFrom"].ToString());
                    message.Body = r["EmailBody"].ToString() + "\r\r\r\r" +
                        "___________________________________________________________________";
                    // Create  the file attachment for this e-mail message.
                    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                    // Add the file attachment to this e-mail message.
                    message.Attachments.Add(data);
                    // Add Selected Attachment from The Database *//  

                    t = JobRFIDocument.GetDocumentsForEmail(jobRTFID).Tables[0];
                    foreach (DataRow rr in t.Rows)
                    {
                        data = new Attachment(rr["Document"].ToString(), MediaTypeNames.Application.Octet);

                        disposition = data.ContentDisposition;
                        disposition.CreationDate = System.IO.File.GetCreationTime(file);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                        // Add the file attachment to this e-mail message.
                        message.Attachments.Add(data);

                    }



                    client = new SmtpClient("10.1.3.15");
                    client.Send(message);

                }

                //report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobRFILog(string jobID, string jobNumber, string jobName, DataTable RFITable,
                                      string sort, string filter)
        {
            try
            {

                if (RFITable == null || RFITable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No RFI to Print!");
                    throw ex;
                }
                else
                {
                    rptJobRFILog report = new rptJobRFILog();
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

                    report.DataSource = RFITable;
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.txtFilter.Text = filter.ToString().Replace("[", "").Replace("]", "");
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
        public static void AllInsuranceRequirementsReport(string where)
        {
            try
            {
                rptAllInsuranceRequirements report = new rptAllInsuranceRequirements();
                string query = "SELECT " +
                             " OfficeName AS Office, " +
                             " DepartmentName AS Department, " +
                             " JobNumber, " +
                             " JobName, " +
                             " JobStatus = " +
                             " CASE Archived " +
                             " WHEN 1 THEN 'Closed' " +
                             " ELSE 'Open' " +
                             " END, " +
                             " JobClosedDate, " +
                             " CompletedOps, " +
                             " CompletedOpsYears, " +
                             " GLAutoWC, " +
                             " GLAutoWCYears, " +
                             " ProfLiab, " +
                             " ProfLiabYears " +
                             " FROM tblJob j " +
                             " LEFT JOIN tblOffice o ON j.OfficeID = o.OfficeID " +
                             " LEFT JOIN tblDepartment d ON j.DepartmentID = d.DepartmentID " +
                             where + " Order by JobName ";
                report.DataSource = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }












        public static void JobMonthEndComments(string jobNumber, string jobName, DataTable commentsTable,
                                       string sort, string filter)
        {
            try
            {

                rptMonthEndComments report = new rptMonthEndComments();

                if (commentsTable == null || commentsTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Comments to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = commentsTable;
                    report.txtNumber.Text = jobNumber;
                    report.txtName.Text = jobName;
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

        //Reports.JobPrequalSheet(@where, reportType);
        public static void JobPrequalSheet(string where, int reportType)
        {
            DataTable table = new DataTable();

            try
            {
                switch (reportType)
                {
                    case 0:
                        table = Job.GetJobPrequalSheetData(where).Tables[0];
                        break;
                    case 1:
                        table = Job.GetJobPrequalSheetDataDetail(where).Tables[0];
                        break;
                    case 2:
                        table = Job.GetJobPrequalSheetDataSummary(where).Tables[0];
                        break;
                }
                if (reportType == 0)
                {
                    rptPrequalSheet report = new rptPrequalSheet();
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
                else
                // Export To Excel
                {
                    Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                    string fullPath = Environment.CurrentDirectory + "\\" + "PrequalSheet.csv";

                    if (File.Exists(fullPath))
                        File.Delete(fullPath);
                    if (reportType == 1)
                    {
                        rptPrequalExcel report = new rptPrequalExcel();
                        report.DataSource = table;
                        report.ExportToCsv(fullPath);
                    }
                    else
                    {
                        rptPrequalExcelSummary report = new rptPrequalExcelSummary();
                        report.DataSource = table;
                        report.ExportToCsv(fullPath);
                    }
                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    myProcess.StartInfo.FileName = fullPath;
                    myProcess.StartInfo.Verb = "Open";
                    myProcess.Start();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void AdHoc(string where, string reportName)
        {
            DataTable table;

            switch (reportName)
            {
                case "Job List":
                    table = Job.GetJobList(where).Tables[0];
                    if (table.Rows.Count == 0)
                    {
                        Exception ex = new Exception("No Matching Record were found!");
                        throw ex;
                    }
                    else
                    {
                        rptJobList report = new rptJobList();
                        report.DataSource = table;
                        report.ShowPreviewDialog();
                    }
                    break;
                case "Bid Schedule":
                    try
                    {

                        SqlParameter[] par = new SqlParameter[1];
                        par[0] = new SqlParameter("@Where", where);

                        table = DataBaseUtil.ExecuteParDataset("up_jCBidStatusReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                        if (table.Rows.Count == 0)
                        {
                            Exception ex = new Exception("No Matching Record were found!");
                            throw ex;
                        }
                        else
                        {
                            rptBidSchedule report = new rptBidSchedule();
                            report.DataSource = table;
                            report.ShowPreviewDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "Weekly Budget":
                    try
                    {
                        SqlParameter[] par = new SqlParameter[1];
                        par[0] = new SqlParameter("@Where", where);

                        table = DataBaseUtil.ExecuteParDataset("up_JCWeeklyEstimateBudgetAdHocReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                        if (table.Rows.Count == 0)
                        {
                            Exception ex = new Exception("No Matching Record were found!");
                            throw ex;
                        }
                        else
                        {
                            rptWeeklyEstimateBudget report = new rptWeeklyEstimateBudget();
                            report.DataSource = table;
                            report.ShowPreviewDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "Weekly Estimate Successful":
                    try
                    {
                        SqlParameter[] par = new SqlParameter[1];
                        par[0] = new SqlParameter("@Where", where);

                        table = DataBaseUtil.ExecuteParDataset("up_JCWeeklyEstimateSuccessfulAdHocReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                        if (table.Rows.Count == 0)
                        {
                            Exception ex = new Exception("No Matching Record were found!");
                            throw ex;
                        }
                        else
                        {
                            rptWeeklyEstimateSuccessful report = new rptWeeklyEstimateSuccessful();
                            report.DataSource = table;
                            report.ShowPreviewDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case "Weekly Estimate No No Bid":
                    try
                    {
                        SqlParameter[] par = new SqlParameter[1];
                        par[0] = new SqlParameter("@Where", where);

                        table = DataBaseUtil.ExecuteParDataset("up_JCWeeklyEstimateNoNoBidAdHocReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                        if (table.Rows.Count == 0)
                        {
                            Exception ex = new Exception("No Matching Record were found!");
                            throw ex;
                        }
                        else
                        {
                            rptWeeklyEstimateNoNoBid report = new rptWeeklyEstimateNoNoBid();
                            report.txtTitle2.Text = "";
                            report.DataSource = table;
                            report.ShowPreviewDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case "Weekly Estimate Open Pending":
                    try
                    {
                        SqlParameter[] par = new SqlParameter[1];
                        par[0] = new SqlParameter("@Where", where);

                        table = DataBaseUtil.ExecuteParDataset("up_JCWeeklyEstimateOpenPendingAdHocReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                        if (table.Rows.Count == 0)
                        {
                            Exception ex = new Exception("No Matching Record were found!");
                            throw ex;
                        }
                        else
                        {
                            rptWeeklyEstimateOpenPending report = new rptWeeklyEstimateOpenPending();
                            report.txtTitle2.Text = "";
                            report.DataSource = table;
                            report.ShowPreviewDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case "Weekly New Job":
                    try
                    {
                        SqlParameter[] par = new SqlParameter[1];
                        par[0] = new SqlParameter("@Where", where);

                        table = DataBaseUtil.ExecuteParDataset("up_JCWeeklyNewJobAdHocReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                        if (table.Rows.Count == 0)
                        {
                            Exception ex = new Exception("No Matching Record were found!");
                            throw ex;
                        }
                        else
                        {
                            rptWeeklyNewJob report = new rptWeeklyNewJob();
                            report.txtTitle2.Text = "";
                            report.DataSource = table;
                            report.ShowPreviewDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
            }

        }

        public static void JobProgressSummaryMonthEndReport(string query, string period)
        {
            try
            {
                DataTable table;
                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count == 0)
                {
                    throw new Exception("No items to display for Job Progress Summary (WIP)!");
                }
                rptJobProgressSummaryMonthEnd report = new rptJobProgressSummaryMonthEnd();
                report.DataSource = table;
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

        public static void JobProgressSummaryWIPMonthEndReport(string query, string period)
        {
            try
            {
                DataTable table;
                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count == 0)
                {
                    throw new Exception("No items to display for Job Progress Summary (WIP)!");
                }
                rptJobProgressSummaryWIPMonthEnd report = new rptJobProgressSummaryWIPMonthEnd();
                report.DataSource = table;
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

        public static void JobDetailMonthEndCostOfCompletion(string query, string period)
        {
            try
            {
                DataTable table;
                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count == 0)
                {
                    throw new Exception("No items to display for Month End Cost of Completion Detail WIP!");
                }
                rptJobDetailedMonthEndCostOfCompletion report = new rptJobDetailedMonthEndCostOfCompletion();
                report.DataSource = table;
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
        public static void JobDetailMonthEndCostOfCompletionWIP(string query, string period)
        {
            try
            {
                DataTable table;
                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count == 0)
                {
                    throw new Exception("No items to display for Month End Cost of Completion Detail WIP!");
                }
                rptJobDetailedMonthEndCostOfCompletionWIP report = new rptJobDetailedMonthEndCostOfCompletionWIP();
                report.DataSource = table;
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

        public static void JobContractLogMonthEndReport(string query, string period)
        {
            try
            {
                DataTable table;

                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count == 0)
                {
                    throw new Exception("No items to display for Contract Log!");
                }

                rptJobContractLog report = new rptJobContractLog();
                report.DataSource = table;
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



        public static void JobProgressSummaryReport(string query, string period)
        {
            try
            {
                DataTable table;

                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count == 0)
                {
                    throw new Exception("No items to display for Month End Summary!");
                }

                rptJobProgressSummaryHistory report = new rptJobProgressSummaryHistory();
                report.DataSource = table;
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

        public static void JobProgressSummaryWIPReport(string query, string period)
        {
            try
            {
                DataTable table;

                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count == 0)
                {
                    throw new Exception("No items to display for Month End Summary (WIP)!");
                }

                rptJobProgressSummaryHistoryWIP report = new rptJobProgressSummaryHistoryWIP();
                report.DataSource = table;
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


        public static void JobByCostCodesReport(string date, string jobPhase, string jobCode, string office, string department)
        {
            try
            {
                rptJobByCostCodes report = new rptJobByCostCodes();
                string query = "SELECT job_no, " +
                             " Office = (Select OfficeName FROM tblJob j LEFT JOIN tblOffice o ON j.OfficeID = o.OfficeID WHERE JobNumber = job_no ),  " +
                             " Department = (Select DepartmentName FROM tblJob j LEFT JOIN tblDepartment d ON j.DepartmentID = d.DepartmentID WHERE JobNumber = job_no), " +
                             " JobName = (Select JobName FROM tblJob WHERE JobNumber = Job_no), " +
                             " FinalContractAmount = (Select JobFinalContractAmount FROM tblJob WHERE JobNumber = Job_no), " +
                             " CostCodeTitle = (SELECT CostCodeTitle FROM tblCostCode WHERE CostCodeType = cost_type AND CostCodeType = Cost_type AND CostCodePhase = Phase_no AND CostCode = cost_no), " +
                             " Cost_type, " +
                             " Phase_no, " +
                             " cost_no, " +
                             " SUM(trn_amt) AS [PhaseCost], SUM(job_hrs) AS [PhaseHours] " +
                             " FROM StarBldr.dbo.GLDetail g " +
                             " INNER JOIN tblJob j ON g.Job_no = j.JobNumber " +
                             " WHERE  Post_yr = '" + date + "' ";
                if (jobPhase.Trim().Length > 0)
                    query += " AND  phase_no IN " + jobPhase + " ";
                if (jobCode.Trim().Length > 0)
                    query += " AND  cost_no IN " + jobCode + " ";
                if (office.Trim().Length > 0)
                    query += " AND j.OfficeID = " + office + " ";
                if (department.Trim().Length > 0)
                    query += " AND j.DepartmentID = " + department + " ";
                //
                // Security
                //
                query += " AND [dbo].[GetUserJobAccess](j.JobID, '" + Security.Security.LoginID + "')  = 1 ";
                query += " GROUP BY Job_no, Cost_type, Phase_no, Cost_no " +
                         " ORDER by job_no, Cost_type, Phase_no, Cost_no ";

                report.txtPeriod.Text = date;
                report.DataSource = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        public static void CompanyEstimateReviewReport(string startDate, string endDate, string jobStatus)
        {
            try
            {
                rptCompanyEstimateReview report = new rptCompanyEstimateReview();
                string query = "DECLARE @StartDate SMALLDATETIME " +
                            " SET @StartDate = DATEADD(day,  -6, '" + endDate + "') " +
                            " SELECT " +
                            " EstimateNumber, " +
                            " JobNumber, " +
                            " JobName, " +
                            " c.Name AS [CustomerName], " +
                            " j.OwnerName, " +
                            " j.ContractorName, " +
                            " cc.Description As OwnerClass, " +
                            " e.Description As Estimator, " +
                            " w.JobStatus, " +
                            " BidDate, " +
                            " b.Description AS [BidBond], " +
                            // " ISNULL(PrebidAmount, 0) As ApproxValue " +
                            " ApproxValue = ( " +
                            " CASE w.JobStatus " +
                            " WHEN 'PENDING' THEN ISNULL(FinalBidAmount, 0) " +
                            " WHEN 'LOST' THEN ISNULL(FinalBidAmount, 0) " +
                            " WHEN 'WON' THEN ISNULL(JobFinalContractAmount, 0) " +
                            " WHEN 'OPEN' THEN PreBidAmount " +
                            " ELSE PreBidAmount " +
                            " END ) " +
                            " FROM tblJOB j " +
                            " LEFT JOIN tblEstimator e on j.EstimatorID = e.EstimatorID " +
                            " LEFT JOIN tblCustomer c ON j.CustomerID = c.CustomerID " +
                            " LEFT JOIN tblBidBond b ON j.BidBondID = b.BidBondID " +
                            " LEFT JOIN tblJobStatus w ON j.JobStatusID = w.JobStatusID " +
                            " LEFT JOIN tblOwnerClass cc ON j.OwnerClassID = cc.OwnerClassID " +
                            " WHERE " +
                            " (BidDate BETWEEN  '" + startDate + "' AND '" + endDate + "') ";
                if (jobStatus.Length > 1)
                    query = query + " AND w.JobStatus IN " + jobStatus + " ";
                query = query + " AND Archived = 0 AND Void = 0 ";
                //
                // Security
                //
                query += " AND [dbo].[GetUserJobAccess](j.JobID, '" + Security.Security.LoginID + "')  = 1 ";

                report.DataSource = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CompanyEstimateHistoryReport(string endDate, string jobStatus, string archiveStatus)
        {
            try
            {
                rptCompanyEstimateHistory report = new rptCompanyEstimateHistory();
                string query = " SELECT " +
                            " EstimateNumber, " +
                            " JobNumber, " +
                            " JobName, " +
                            " ISNULL(Competitive, 0) AS Competitive, " +
                            " WONLOSTDate," +
                            " c.Name AS [CustomerName], " +
                            " j.OwnerName, " +
                            " j.ContractorName, " +
                            " cc.Description As OwnerClass, " +
                            " e.Description As Estimator, " +
                            " t.Description AS ContractType, " +
                            " w.JobStatus, " +
                            " BidDate, " +
                            " b.Description AS [BidBond], " +
                            " ApproxValue = ( " +
                            " CASE w.JobStatus " +
                            " WHEN 'PENDING' THEN ISNULL(FinalBidAmount, 0) " +
                            " WHEN 'LOST' THEN ISNULL(FinalBidAmount, 0) " +
                            " WHEN 'WON' THEN ISNULL(JobFinalContractAmount, 0) " +
                            " WHEN 'OPEN' THEN PreBidAmount " +
                            " ELSE PreBidAmount " +
                             " END ), " +
                             " 	Note =	" +
                            " CASE LEN(LTRIM(RTRIM(ISNULL(comment,'')))) " +
                            " WHEN 0 THEN 0 " +
                            " ELSE 1 " +
                            " END " +
                            " FROM tblJOB j " +
                            " LEFT JOIN tblEstimator e on j.EstimatorID = e.EstimatorID " +
                            " LEFT JOIN tblCustomer c ON j.CustomerID = c.CustomerID " +
                            " LEFT JOIN tblBidBond b ON j.BidBondID = b.BidBondID " +
                            " LEFT JOIN tblJobStatus w ON j.JobStatusID = w.JobStatusID " +
                            " LEFT JOIN tblOwnerClass cc ON j.OwnerClassID = cc.OwnerClassID " +
                            " LEFT JOIN tblContractType t ON j.ContractTypeID = t.ContractTypeID " +
                            " WHERE " +
                             // " dbo.GetOverDate(WONLostDate, '" + endDate + "', JobStatus)   = 2 ";
                             " bidDate <= '" + endDate + "' ";
                if (jobStatus.Length > 1)
                    query = query + " AND w.JobStatus IN " + jobStatus + " ";
                if (archiveStatus == "0")
                    query = query + " AND Archived = 0  ";
                query = query + " AND EstimateNumber Not Like '90%' AND Void = 0 ";
                //
                // Security
                //
                query += " AND [dbo].[GetUserJobAccess](j.JobID, '" + Security.Security.LoginID + "')  = 1 ";
                report.DataSource = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                report.txtDate.Text = "Report As Of: " + endDate;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void JobContractLog(string jobID)
        {

            try
            {
                DataTable table = JobChangeOrder.GetContractLog(jobID).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No data available for Contract Log");
                    throw ex;

                }
                else
                {
                    rptJobContractLog report = new rptJobContractLog();

                    report.DataSource = table;
                    report.txtPeriod.Text = "Current";
                    report.ShowPreviewDialog();
                }
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

        public static void JobTotalBudget(string jobID, string JobNumber, string jobName, string period)
        {
            try
            {


                rptJobTotalBudget report = new rptJobTotalBudget();
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
                    report.DataSource = CostCode.GetJobProgressHistory(jobID, period).Tables[0];
                    report.txtPeriod.Text = period;
                }
                else
                {
                    report.DataSource = CostCode.GetJobProgress(jobID).Tables[0];
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
                    report.txtPeriod.Text = "Current";
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

        public static void JobProgressSummaryWIP(string jobID, string JobNumber, string jobName, string period)
        {
            try
            {


                rptJobProgressSummaryWIP report = new rptJobProgressSummaryWIP();
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
                    report.txtPeriod.Text = "Current";
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
        //
        public static void JobDashboardCost(string sort, string filer, DataTable jobDashboardCost, int reportType)
        {
            try
            {

                if (reportType == 0)
                {
                    rptJobDashboardCost report = new rptJobDashboardCost();
                    report.txtSort.Text = sort;
                    report.txtFilter.Text = filer;
                    report.DataSource = jobDashboardCost;
                    report.ShowPreviewDialog();
                }
                else
                {
                    rptJobDashboardCostSummary report1 = new rptJobDashboardCostSummary();
                    report1.txtSort.Text = sort;
                    report1.txtFilter.Text = filer;
                    report1.DataSource = jobDashboardCost;
                    report1.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        //
        // Job Labor Analysis
        //
        public static void JobLaborAnalysis(string jobID, string JobNumber, string jobName, DataTable jobLaborAnalysis,
            LaborAnalysisView laborView, ReportTypeView reportType, string filter)
        {
            try
            {
                rptJobLaborAnalysisCode reportCode;
                rptJobLaborAnalysisCodeSummary reportCodeSummary;
                rptJobLaborAnalysisEmp reportEmp;
                rptJobLaborAnalysisEmpSummary reportEmpSummary;
                rptJobLaborAnalysisList reportList;
                rptJobLaborAnalysisPhase reportPhase;
                rptJobLaborAnalysisPhaseSummary reportPhaseSummary;
                rptJobLaborAnalysisWeek reportWeek;
                rptJobLaborAnalysisWeekSummary reportWeekSummary;
                rptJobLaborAnalysisCraft reportCraft;
                rptJobLaborAnalysisCraftSummary reportCraftSummary;
                rptJobLaborAnalysisHoursType reportHoursType;
                rptJobLaborAnalysisHoursTypeSummary reportHoursTypeSummary;

                DataTable table = Job.GetJobOffice(jobID).Tables[0];


                switch (laborView)
                {
                    case LaborAnalysisView.Code:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportCode = new rptJobLaborAnalysisCode();
                                if (table.Rows.Count > 0)
                                {

                                    reportCode.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportCode.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportCode.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportCode.txtJobName.Text = jobName;
                                reportCode.txtJobNumber.Text = JobNumber;
                                reportCode.txtFilter.Text = filter;
                                reportCode.DataSource = jobLaborAnalysis;
                                reportCode.ShowPreviewDialog();

                                break;
                            case ReportTypeView.Summary:
                                reportCodeSummary = new rptJobLaborAnalysisCodeSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportCodeSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportCodeSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportCodeSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportCodeSummary.txtJobName.Text = jobName;
                                reportCodeSummary.txtJobNumber.Text = JobNumber;
                                reportCodeSummary.txtFilter.Text = filter;
                                reportCodeSummary.DataSource = jobLaborAnalysis;
                                reportCodeSummary.ShowPreviewDialog();
                                break;
                        }


                        break;
                    case LaborAnalysisView.Employee:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportEmp = new rptJobLaborAnalysisEmp();
                                if (table.Rows.Count > 0)
                                {
                                    reportEmp.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportEmp.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportEmp.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportEmp.txtJobName.Text = jobName;
                                reportEmp.txtJobNumber.Text = JobNumber;
                                reportEmp.txtFilter.Text = filter;
                                reportEmp.DataSource = jobLaborAnalysis;
                                reportEmp.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportEmpSummary = new rptJobLaborAnalysisEmpSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportEmpSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportEmpSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportEmpSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportEmpSummary.txtJobName.Text = jobName;
                                reportEmpSummary.txtJobNumber.Text = JobNumber;
                                reportEmpSummary.txtFilter.Text = filter;
                                reportEmpSummary.DataSource = jobLaborAnalysis;
                                reportEmpSummary.ShowPreviewDialog();
                                break;
                        }
                        break;
                    case LaborAnalysisView.List:
                        reportList = new rptJobLaborAnalysisList();
                        if (table.Rows.Count > 0)
                        {
                            reportList.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            reportList.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            reportList.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        reportList.txtJobName.Text = jobName;
                        reportList.txtJobNumber.Text = JobNumber;
                        reportList.txtFilter.Text = filter;
                        reportList.DataSource = jobLaborAnalysis;
                        reportList.ShowPreviewDialog();
                        break;
                    case LaborAnalysisView.Phase:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportPhase = new rptJobLaborAnalysisPhase();
                                if (table.Rows.Count > 0)
                                {
                                    reportPhase.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportPhase.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportPhase.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportPhase.txtJobName.Text = jobName;
                                reportPhase.txtJobNumber.Text = JobNumber;
                                reportPhase.txtFilter.Text = filter;
                                reportPhase.DataSource = jobLaborAnalysis;
                                reportPhase.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportPhaseSummary = new rptJobLaborAnalysisPhaseSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportPhaseSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportPhaseSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportPhaseSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportPhaseSummary.txtJobName.Text = jobName;
                                reportPhaseSummary.txtJobNumber.Text = JobNumber;
                                reportPhaseSummary.txtFilter.Text = filter;
                                reportPhaseSummary.DataSource = jobLaborAnalysis;
                                reportPhaseSummary.ShowPreviewDialog();
                                break;
                        }
                        break;

                    case LaborAnalysisView.Week:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportWeek = new rptJobLaborAnalysisWeek();
                                if (table.Rows.Count > 0)
                                {
                                    reportWeek.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportWeek.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportWeek.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportWeek.txtJobName.Text = jobName;
                                reportWeek.txtJobNumber.Text = JobNumber;
                                reportWeek.txtFilter.Text = filter;
                                reportWeek.DataSource = jobLaborAnalysis;
                                reportWeek.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportWeekSummary = new rptJobLaborAnalysisWeekSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportWeekSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportWeekSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportWeekSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportWeekSummary.txtJobName.Text = jobName;
                                reportWeekSummary.txtJobNumber.Text = JobNumber;
                                reportWeekSummary.txtFilter.Text = filter;
                                reportWeekSummary.DataSource = jobLaborAnalysis;
                                reportWeekSummary.ShowPreviewDialog();
                                break;
                        }
                        break;


                    case LaborAnalysisView.HoursType:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportHoursType = new rptJobLaborAnalysisHoursType();
                                if (table.Rows.Count > 0)
                                {
                                    reportHoursType.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportHoursType.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportHoursType.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportHoursType.txtJobName.Text = jobName;
                                reportHoursType.txtJobNumber.Text = JobNumber;
                                reportHoursType.txtFilter.Text = filter;
                                reportHoursType.DataSource = jobLaborAnalysis;
                                reportHoursType.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportHoursTypeSummary = new rptJobLaborAnalysisHoursTypeSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportHoursTypeSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportHoursTypeSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportHoursTypeSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportHoursTypeSummary.txtJobName.Text = jobName;
                                reportHoursTypeSummary.txtJobNumber.Text = JobNumber;
                                reportHoursTypeSummary.txtFilter.Text = filter;
                                reportHoursTypeSummary.DataSource = jobLaborAnalysis;
                                reportHoursTypeSummary.ShowPreviewDialog();
                                break;
                        }
                        break;

                    case LaborAnalysisView.Craft:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportCraft = new rptJobLaborAnalysisCraft();
                                if (table.Rows.Count > 0)
                                {
                                    reportCraft.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportCraft.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportCraft.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportCraft.txtJobName.Text = jobName;
                                reportCraft.txtJobNumber.Text = JobNumber;
                                reportCraft.txtFilter.Text = filter;
                                reportCraft.DataSource = jobLaborAnalysis;
                                reportCraft.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportCraftSummary = new rptJobLaborAnalysisCraftSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportCraftSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportCraftSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportCraftSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportCraftSummary.txtJobName.Text = jobName;
                                reportCraftSummary.txtJobNumber.Text = JobNumber;
                                reportCraftSummary.txtFilter.Text = filter;
                                reportCraftSummary.DataSource = jobLaborAnalysis;
                                reportCraftSummary.ShowPreviewDialog();
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        // Job Cost Analysis
        //
        public static void JobCostAnalysis(string jobID, string JobNumber, string jobName, DataTable jobCostAnalysis,
            CostAnalysisView costView, ReportTypeView reportType, string filter)
        {
            try
            {

                rptJobCostAnalysisCode reportCode;
                rptJobCostAnalysisCodeSummary reportCodeSummary;
                rptJobCostAnalysisVendor reportVendor;
                rptJobCostAnalysisVendorSummary reportVendorSummary;
                rptJobCostAnalysisList reportList;
                rptJobCostAnalysisPhase reportPhase;
                rptJobCostAnalysisPhaseSummary reportPhaseSummary;
                rptJobCostAnalysisWeek reportTrans;
                rptJobCostAnalysisWeekSummary reportTransSummary;
                rptJobCostAnalysisApp reportApp;
                rptJobCostAnalysisAppSummary reportAppSummary;

                DataTable table = Job.GetJobOffice(jobID).Tables[0];

                switch (costView)
                {
                    case CostAnalysisView.Code:

                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportCode = new rptJobCostAnalysisCode();
                                reportCode.txtJobName.Text = jobName;
                                reportCode.txtJobNumber.Text = JobNumber;
                                if (table.Rows.Count > 0)
                                {
                                    reportCode.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportCode.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportCode.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportCode.txtFilter.Text = filter;
                                reportCode.DataSource = jobCostAnalysis;
                                reportCode.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportCodeSummary = new rptJobCostAnalysisCodeSummary();
                                reportCodeSummary.txtJobName.Text = jobName;
                                reportCodeSummary.txtJobNumber.Text = JobNumber;
                                if (table.Rows.Count > 0)
                                {
                                    reportCodeSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportCodeSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportCodeSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportCodeSummary.txtFilter.Text = filter;
                                reportCodeSummary.DataSource = jobCostAnalysis;
                                reportCodeSummary.ShowPreviewDialog();
                                break;
                        }


                        break;


                    case CostAnalysisView.App:

                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportApp = new rptJobCostAnalysisApp();
                                reportApp.txtJobName.Text = jobName;
                                reportApp.txtJobNumber.Text = JobNumber;
                                if (table.Rows.Count > 0)
                                {
                                    reportApp.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportApp.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportApp.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportApp.txtFilter.Text = filter;
                                reportApp.DataSource = jobCostAnalysis;
                                reportApp.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportAppSummary = new rptJobCostAnalysisAppSummary();
                                reportAppSummary.txtJobName.Text = jobName;
                                reportAppSummary.txtJobNumber.Text = JobNumber;
                                if (table.Rows.Count > 0)
                                {
                                    reportAppSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportAppSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportAppSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportAppSummary.txtFilter.Text = filter;
                                reportAppSummary.DataSource = jobCostAnalysis;
                                reportAppSummary.ShowPreviewDialog();
                                break;
                        }


                        break;


                    case CostAnalysisView.Name:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportVendor = new rptJobCostAnalysisVendor();
                                if (table.Rows.Count > 0)
                                {
                                    reportVendor.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportVendor.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportVendor.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportVendor.DataSource = jobCostAnalysis;

                                reportVendor.txtJobName.Text = jobName;
                                reportVendor.txtJobNumber.Text = JobNumber;
                                reportVendor.txtFilter.Text = filter;
                                reportVendor.ShowPreviewDialog();

                                break;
                            case ReportTypeView.Summary:
                                reportVendorSummary = new rptJobCostAnalysisVendorSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportVendorSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportVendorSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportVendorSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportVendorSummary.DataSource = jobCostAnalysis;
                                reportVendorSummary.txtJobName.Text = jobName;
                                reportVendorSummary.txtJobNumber.Text = JobNumber;
                                reportVendorSummary.txtFilter.Text = filter;
                                reportVendorSummary.ShowPreviewDialog();
                                break;
                        }
                        break;
                    case CostAnalysisView.List:
                        reportList = new rptJobCostAnalysisList();
                        if (table.Rows.Count > 0)
                        {
                            reportList.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            reportList.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            reportList.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        reportList.DataSource = jobCostAnalysis;

                        reportList.txtJobName.Text = jobName;
                        reportList.txtJobNumber.Text = JobNumber;
                        reportList.txtFilter.Text = filter;
                        reportList.ShowPreviewDialog();
                        break;
                    case CostAnalysisView.Phase:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportPhase = new rptJobCostAnalysisPhase();
                                if (table.Rows.Count > 0)
                                {
                                    reportPhase.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportPhase.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportPhase.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportPhase.DataSource = jobCostAnalysis;
                                reportPhase.txtJobName.Text = jobName;
                                reportPhase.txtJobNumber.Text = JobNumber;
                                reportPhase.txtFilter.Text = filter;
                                reportPhase.ShowPreviewDialog();
                                break;
                            case ReportTypeView.Summary:
                                reportPhaseSummary = new rptJobCostAnalysisPhaseSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportPhaseSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportPhaseSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportPhaseSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportPhaseSummary.DataSource = jobCostAnalysis;
                                reportPhaseSummary.txtJobName.Text = jobName;
                                reportPhaseSummary.txtJobNumber.Text = JobNumber;
                                reportPhaseSummary.txtFilter.Text = filter;
                                reportPhaseSummary.ShowPreviewDialog();
                                break;
                        }
                        break;

                    case CostAnalysisView.Date:
                        switch (reportType)
                        {
                            case ReportTypeView.Detail:
                                reportTrans = new rptJobCostAnalysisWeek();
                                if (table.Rows.Count > 0)
                                {
                                    reportTrans.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportTrans.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportTrans.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportTrans.DataSource = jobCostAnalysis;
                                reportTrans.txtJobName.Text = jobName;
                                reportTrans.txtJobNumber.Text = JobNumber;
                                reportTrans.txtFilter.Text = filter;
                                reportTrans.ShowPreviewDialog();

                                break;
                            case ReportTypeView.Summary:
                                reportTransSummary = new rptJobCostAnalysisWeekSummary();
                                if (table.Rows.Count > 0)
                                {
                                    reportTransSummary.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                                    reportTransSummary.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                                    reportTransSummary.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                        table.Rows[0]["City"].ToString() + ", " +
                                                            table.Rows[0]["State"].ToString() + " " +
                                                            table.Rows[0]["ZipCode"].ToString();
                                }
                                reportTransSummary.DataSource = jobCostAnalysis;
                                reportTransSummary.txtJobName.Text = jobName;
                                reportTransSummary.txtJobNumber.Text = JobNumber;
                                reportTransSummary.txtFilter.Text = filter;
                                reportTransSummary.ShowPreviewDialog();
                                break;
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobsWithLaborActivityByWeek(DateTime date)
        {
            try
            {

                string day = date.DayOfWeek.ToString();

                switch (day)
                {
                    case "Monday":
                        date = date.AddDays(6);
                        break;
                    case "Tuesday":
                        date = date.AddDays(5);
                        break;
                    case "Wednesday":
                        date = date.AddDays(4);
                        break;
                    case "Thursday":
                        date = date.AddDays(3);
                        break;
                    case "Friday":
                        date = date.AddDays(2);
                        break;
                    case "Saturday":
                        date = date.AddDays(1);
                        break;
                }
                string myDate;
                myDate = date.ToShortDateString();

                rptJobsWithLaborActivityByWeek report = new rptJobsWithLaborActivityByWeek();
                report.DataSource = Job.GetJobsWithLaborActivityByWeek(myDate);
                report.txtWeekend.Text = myDate;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobDocumentsList(string jobID, string estimateNumber, string JobNumber, string jobName, DataTable documentTable)
        {
            try
            {

                rptJobDocumentList report = new rptJobDocumentList();
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

                if (documentTable == null || documentTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Documents to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = documentTable;
                    report.txtJobName.Text = jobName;
                    report.txtJobNumber.Text = JobNumber;
                    report.txtEstimateNumber.Text = estimateNumber;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobInvoicesNoPO(string jobID, string JobNumber, string jobName, DataTable invoicesTable, string filter)
        {
            try
            {

                rptJobInvoicesNoPO report = new rptJobInvoicesNoPO();
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

                if (invoicesTable == null || invoicesTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Documents to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = invoicesTable;
                    report.txtJobName.Text = jobName;
                    report.txtJobNumber.Text = JobNumber;
                    report.txtFilter.Text = filter;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void JobSubcontractsInvoices(string jobID, string JobNumber, string jobName, DataTable invoicesTable, string filter)
        {
            try
            {

                rptJobSubcontractsInvoices report = new rptJobSubcontractsInvoices();
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

                if (invoicesTable == null || invoicesTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Invoices to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = invoicesTable;
                    report.txtJobName.Text = jobName;
                    report.txtJobNumber.Text = JobNumber;
                    report.txtFilter.Text = filter;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void JobLogList(string jobID, string JobNumber, string jobName, string contractType, DataTable jobLogTable, string filter)
        {
            try
            {

                rptJobLogList report = new rptJobLogList();
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

                if (jobLogTable == null || jobLogTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Documents to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = jobLogTable;
                    report.txtJobName.Text = jobName;
                    report.txtJobNumber.Text = JobNumber;
                    report.txtContractType.Text = contractType;
                    if (filter.Trim().Length > 0)
                        report.lblFilter.Visible = true;
                    else
                        report.lblFilter.Visible = false;
                    report.txtFilter.Text = filter;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Job Invoice Aging
        //
        public static void JobInvoiceDetailAging(DataSet jobInvoiceDetailAgingDataSet)
        {
            try
            {

                rptJobInvoiceDetailAging report = new rptJobInvoiceDetailAging();

                report.DataSource = jobInvoiceDetailAgingDataSet;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Job Invoice Detail
        //
        public static void JobInvoiceDetail(string jobID, string JobNumber, string jobName, DataSet jobInvoiceDetailDataSet, string filter)
        {
            try
            {

                rptJobInvoiceDetailN report = new rptJobInvoiceDetailN();
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
                report.DataSource = jobInvoiceDetailDataSet;
                if (jobInvoiceDetailDataSet.Tables.Count > 1)
                {
                    if (jobInvoiceDetailDataSet.Relations[0].RelationName == "Payments")
                    {
                        report.rptInvoiceDetailSub.ReportSource.DataSource = jobInvoiceDetailDataSet.Tables[1];
                        report.rptInvoiceDetailSub.Visible = true;
                        report.rptInvoiceDetailSub1.Visible = false;
                    }
                    else
                    {
                        report.rptInvoiceDetailSub1.ReportSource.DataSource = jobInvoiceDetailDataSet.Tables[1];
                        report.rptInvoiceDetailSub.Visible = false;
                        report.rptInvoiceDetailSub1.Visible = true;
                    }
                }
                else
                {
                    report.rptInvoiceDetailSub.Visible = false;
                    report.rptInvoiceDetailSub1.Visible = false;
                }
                report.txtJobName.Text = jobName;
                report.txtJobNumber.Text = JobNumber;
                report.txtFilter.Text = filter;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        // Job Purchasing Detail
        //
        public static void JobPurchasingDetail(string jobID, string JobNumber, string jobName, DataSet jobPurchasingDetailDataSet, int reportType, string filter)
        {
            try
            {
                if (jobPurchasingDetailDataSet.Tables.Count == 0 || jobPurchasingDetailDataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No data available for Purchasing");
                    throw ex;
                }
                DataTable table = Job.GetJobOffice(jobID).Tables[0];

                switch (reportType)
                {
                    case 3:
                        rptJobPurchasingDetailNI report = new rptJobPurchasingDetailNI();
                        if (table.Rows.Count > 0)
                        {
                            report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        report.DataSource = jobPurchasingDetailDataSet;
                        if (jobPurchasingDetailDataSet.Tables.Count > 1)
                        {

                            report.rptPurchasingDetailSub.ReportSource.DataSource = jobPurchasingDetailDataSet.Tables[1];
                            report.rptPurchasingDetailSub.Visible = true;
                        }
                        else
                            report.rptPurchasingDetailSub.Visible = false;
                        report.txtJobName.Text = jobName;
                        report.txtJobNumber.Text = JobNumber;
                        report.txtFilter.Text = filter;
                        report.ShowPreviewDialog();
                        break;


                    case 4:
                        rptJobPurchasingItems report4 = new rptJobPurchasingItems();
                        if (table.Rows.Count > 0)
                        {
                            report4.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report4.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report4.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        report4.DataSource = jobPurchasingDetailDataSet.Tables[0];
                        report4.txtJobName.Text = jobName;
                        report4.txtJobNumber.Text = JobNumber;
                        report4.txtFilter.Text = filter;
                        report4.ShowPreviewDialog();
                        break;

                    case 5:
                        rptJobPurchasingSummary report5 = new rptJobPurchasingSummary();
                        if (table.Rows.Count > 0)
                        {
                            report5.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report5.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report5.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        report5.DataSource = jobPurchasingDetailDataSet.Tables[0];
                        report5.txtJobName.Text = jobName;
                        report5.txtJobNumber.Text = JobNumber;
                        report5.txtFilter.Text = filter;
                        report5.ShowPreviewDialog();
                        break;

                    case 6:
                        rptJobPOInvoices report6 = new rptJobPOInvoices();
                        if (table.Rows.Count > 0)
                        {
                            report6.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report6.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report6.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        report6.DataSource = jobPurchasingDetailDataSet.Tables[0];
                        report6.txtJobName.Text = jobName;
                        report6.txtJobNumber.Text = JobNumber;
                        report6.txtFilter.Text = filter;
                        report6.ShowPreviewDialog();
                        break;


                    default:
                        rptJobPurchasingDetailN report1 = new rptJobPurchasingDetailN();
                        if (table.Rows.Count > 0)
                        {
                            report1.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                            report1.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                            report1.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                                table.Rows[0]["City"].ToString() + ", " +
                                                    table.Rows[0]["State"].ToString() + " " +
                                                    table.Rows[0]["ZipCode"].ToString();
                        }
                        report1.DataSource = jobPurchasingDetailDataSet;
                        if (jobPurchasingDetailDataSet.Tables.Count > 1)
                        {
                            report1.rptPurchasingDetailSub.Tag = JobNumber;
                            report1.rptPurchasingDetailSub.ReportSource.DataSource = jobPurchasingDetailDataSet.Tables[1];
                            report1.rptPurchasingDetailSub.Visible = true;
                            report1.txtTitle.Text = report1.txtTitle.Text + " - " + " WITH INVOICES";
                        }
                        else
                            report1.rptPurchasingDetailSub.Visible = false;
                        report1.txtJobName.Text = jobName;
                        report1.txtJobNumber.Text = JobNumber;
                        report1.txtFilter.Text = filter;
                        if (reportType == 0)
                        {
                            report1.lblComment.Visible = true;
                            report1.txtComment.Visible = true;
                            report1.txtCommentFlag.Visible = true;
                        }
                        else
                        {
                            report1.lblComment.Visible = false;
                            report1.txtComment.Visible = false;
                            report1.txtCommentFlag.Visible = false;
                        }
                        report1.ShowPreviewDialog();
                        break;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void JobOutstandingChangeOrderLog(string jobID,
                        string JobNumber,
                        string jobName)
        {
            try
            {


                rptJobOutstandingChangeOrderLog report = new rptJobOutstandingChangeOrderLog();
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

                report.DataSource = JobChangeOrderContract.GetJobOutstandingChangeOrders(jobID).Tables[0];
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
        public static void JobChangeOrderLog(string jobID,
                        string JobNumber,
                        string jobName,
                        DataTable reportTable,
                        string reportSort,
                        string reportFilter)
        {
            try
            {


                rptJobChangeOrderLog report = new rptJobChangeOrderLog();
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

                report.DataSource = reportTable;
                report.txtSort.Text = reportSort;
                report.txtFilter.Text = reportFilter;
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
        public static void JobChangeOrderList(string jobID, string JobNumber, string jobName)
        {
            try
            {


                rptJobChangeOrderList report = new rptJobChangeOrderList();
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

                report.DataSource = JobChangeOrder.GetJobChangeOrders(jobID).Tables[0];
                report.txtJobName.Text = jobName;
                report.txtJobNumber.Text = JobNumber;


                // Job Summary
                table = Job.GetJobSummary(jobID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    // Original Contract
                    float originalContractAmount = float.Parse(table.Rows[0]["OriginalContract"].ToString());
                    float origilanContractCost = float.Parse(table.Rows[0]["OriginalContractCost"].ToString());
                    // Approved CO Amount
                    float approvedCOAmount = float.Parse(table.Rows[0]["ApprovedCO"].ToString());
                    float approvedCOCost = float.Parse(table.Rows[0]["ApprovedCOCost"].ToString());
                    // Pending with Proceed
                    float pendingCOWithProceedAmount = float.Parse(table.Rows[0]["PendingCO"].ToString());
                    float pendingCOWithProceedCost = float.Parse(table.Rows[0]["PendingWithProceedCost"].ToString());
                    // Pending No Proceed
                    float pendingCOWithNoProceedAmount = float.Parse(table.Rows[0]["NotApprovedCO"].ToString());
                    float pendingCOWithNoProceedCost = float.Parse(table.Rows[0]["PendingNoProceedCost"].ToString());


                    float currentContract = float.Parse(table.Rows[0]["CurrentContract"].ToString());
                    float currentBudget = float.Parse(table.Rows[0]["CurrentBudget"].ToString());

                    float originalContractProfit = originalContractAmount - origilanContractCost;
                    float approvedCOProfit = approvedCOAmount - approvedCOCost;
                    float pendingCOWithProceedProfit = pendingCOWithProceedAmount - pendingCOWithProceedCost;
                    float pendingCOWithNoProceedProfit = pendingCOWithNoProceedAmount - pendingCOWithNoProceedCost;


                    float currentContractProfit = currentContract - currentBudget;

                    // String.Format("{0:c2}", Convert.ToDouble(TotalOverHead()));
                    report.txtOriginalContractAmount.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["OriginalContract"].ToString()));
                    report.txtOriginalContractCost.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["OriginalContractCost"].ToString()));
                    report.txtOriginalContractProfit.Text = String.Format("{0:c2}", originalContractProfit);
                    if (originalContractProfit != 0)
                        report.txtOriginalContractOHP.Text = String.Format("{0:P}", originalContractProfit / originalContractAmount);
                    else
                        report.txtOriginalContractOHP.Text = String.Format("{0:P}", 0);


                    report.txtApprovedCOAmount.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["ApprovedCO"].ToString()));
                    report.txtApprovedCOCost.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["ApprovedCOCost"].ToString()));
                    report.txtApprovedCOProfit.Text = String.Format("{0:c2}", approvedCOProfit);
                    if (approvedCOProfit != 0)
                        report.txtApprovedCOOHP.Text = String.Format("{0:P}", approvedCOProfit / approvedCOAmount);
                    else
                        report.txtApprovedCOOHP.Text = String.Format("{0:P}", 0);


                    //
                    // Create Bending With Proceed
                    //
                    report.txtPendingCOWithProceedAmount.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["PendingCO"].ToString()));
                    report.txtPendingCOWithProceedCost.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["PendingWithProceedCost"].ToString()));
                    report.txtPendingCOWithProceedProfit.Text = String.Format("{0:c2}", pendingCOWithProceedProfit);
                    if (pendingCOWithProceedProfit != 0)
                        report.txtPendingCOWithProceedOHP.Text = String.Format("{0:P}", pendingCOWithProceedProfit / pendingCOWithProceedAmount);
                    else
                        report.txtPendingCOWithProceedOHP.Text = String.Format("{0:P}", 0);


                    report.txtPendingCOWithNoProceedAmount.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["NotApprovedCO"].ToString()));
                    report.txtPendingCOWithNoProceedCost.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["PendingNoProceedCost"].ToString()));
                    report.txtPendingCOWithNoProceedProfit.Text = String.Format("{0:c2}", pendingCOWithNoProceedProfit);
                    if (pendingCOWithNoProceedProfit != 0)
                        report.txtPendingCOWithNoProceedOHP.Text = String.Format("{0:P}", pendingCOWithNoProceedProfit / pendingCOWithNoProceedAmount);
                    else
                        report.txtPendingCOWithNoProceedOHP.Text = String.Format("{0:P}", 0);


                    report.txtCurrentContractAmount.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["CurrentContract"].ToString()));
                    report.txtCurrentContractCost.Text = String.Format("{0:c2}", Convert.ToDouble(table.Rows[0]["CurrentBudget"].ToString()));
                    report.txtCurrentContractProfit.Text = String.Format("{0:c2}", currentContractProfit);
                    if (currentContractProfit != 0)
                        report.txtCurrentContractOHP.Text = String.Format("{0:P}", currentContractProfit / currentContract);
                    else
                        report.txtCurrentContractOHP.Text = String.Format("{0:P}", 0);




                }





                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //        
        public static void JobCostCodesToResearch(string jobID, string JobNumber, string jobName)
        {
            try
            {


                rptJobCostCodesToResearch report = new rptJobCostCodesToResearch();
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
                table = CostCode.GetJobCostCodesToResearch(jobID).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }

                report.DataSource = table;
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
        public static void JobChangeOrderDetailRev(string jobChangeOrderID, string jobID, string revision)
        {
            try
            {
                DataTable table = JobChangeOrder.GetJobChangeOrderDetailRev(jobChangeOrderID, revision).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No data available for the Change Control");
                    throw ex;

                }
                else
                {
                    rptCostBreakdownSheet report = new rptCostBreakdownSheet();

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
                    if (table.Rows[0]["JobChangeOrderNumber"].ToString() == "0")
                    {
                        report.txtContractAmount.Text = "Contract Amount:";
                        report.txtContractAmountTitle.Text = "Contract Amount:";
                    }
                    else
                    {
                        report.txtContractAmount.Text = "Change Order Amount:";
                        report.txtContractAmountTitle.Text = "Change Order Amount:";
                    }
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //
        public static void JobChangeOrderDetail(string jobChangeOrderID, string jobID)
        {
            try
            {
                DataTable table = JobChangeOrder.GetJobChangeOrderDetail(jobChangeOrderID).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No data available for the Change Control");
                    throw ex;

                }
                else
                {
                    rptCostBreakdownSheet report = new rptCostBreakdownSheet();

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
                    //report.lblRev.Visible = false;
                    if (table.Rows[0]["JobChangeOrderNumber"].ToString() == "0")
                    {
                        report.txtContractAmount.Text = "Contract Amount:";
                        report.txtContractAmountTitle.Text = "Contract Amount:";
                    }
                    else
                    {
                        report.txtContractAmount.Text = "Change Order Amount:";
                        report.txtContractAmountTitle.Text = "Change Order Amount:";
                    }
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void LaborFeedback(DevExpress.XtraCharts.ChartControl chart,
            DevExpress.XtraPivotGrid.PivotGridControl pivot,
            string jobName,
            string weekEnding, string jobID, string jobNumber, string employeeName)
        {
            try
            {
                rptLaborFeedbackReport report = new rptLaborFeedbackReport();
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

                table = JobCost.GetLaborPerformanceFactor(jobID, weekEnding).Tables[0];
                if (table.Rows.Count > 0)
                    report.txtLaborPerformanceFactor.Text = String.Format("{0:n2}", Convert.ToDouble(table.Rows[0][0].ToString()));

                report.grdLaborFeedback.DataSource = pivot.DataSource;

                int i = pivot.Fields.Count;
                for (int j = 0; j < i; j++)
                    report.grdLaborFeedback.Fields.Add(pivot.Fields[j]);
                //
                report.xrChart1.DataSource = chart.DataSource;
                report.xrChart1.SeriesDataMember = "Series";
                report.xrChart1.SeriesTemplate.ArgumentDataMember = "Arguments";
                report.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
                report.xrChart1.PaletteName = chart.PaletteName;
                report.xrChart1.SeriesTemplate.Label.Visible = chart.SeriesTemplate.Label.Visible;
                report.xrChart1.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                report.xrChart1.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 0;
                DevExpress.XtraCharts.XYDiagram diag = (DevExpress.XtraCharts.XYDiagram)report.xrChart1.Diagram;
                diag.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                diag.AxisY.NumericOptions.Precision = 0;
                diag.AxisX.Label.Angle = 50;

                /*    if (report.xrChart1.Series.Count == 3)
                    {
                        report.xrChart1.Series[0].View.Color = Color.Yellow;
                        report.xrChart1.Series[1].View.Color = Color.Red;
                        report.xrChart1.Series[2].View.Color = Color.Green;
                        report.xrChart1.Series[0].LegendText = "Budget";
                        report.xrChart1.Series[1].LegendText = "Used";
                        report.xrChart1.Series[2].LegendText = "Earned";
                    }*/
                foreach (DevExpress.XtraCharts.Series s in report.xrChart1.Series)
                {
                    switch (s.Name)
                    {
                        case "Grand Total | Budget":
                            s.View.Color = Color.Yellow;
                            s.LegendText = "Budget";
                            break;
                        case "Grand Total | Used":
                            s.View.Color = Color.Red;
                            s.LegendText = "Used";
                            break;
                        case "Grand Total | Earned":
                            s.View.Color = Color.Green;
                            s.LegendText = "Earned";
                            break;
                        case "Grand Total | Labor Performance Factor":
                            s.Visible = false;
                            break;
                    }
                }
                report.txtJobNumber.Text = jobNumber;
                report.txtJobName.Text = jobName;
                report.txtWeekEnding.Text = weekEnding;
                if (employeeName.Length > 0)
                {
                    report.lblEmployeeName.Visible = true;
                    report.txtEmployeeName.Visible = true;
                    report.txtEmployeeName.Text = employeeName;
                }
                else
                {
                    report.lblEmployeeName.Visible = false;
                    report.txtEmployeeName.Visible = false;
                }
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static void LaborPerformanceFactor(DevExpress.XtraCharts.ChartControl chart,
            DevExpress.XtraPivotGrid.PivotGridControl pivot,
            string jobName,
            string jobNumber, string jobID)
        {
            try
            {
                rptLaborPerformanceReport report = new rptLaborPerformanceReport();
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

                report.grdLaborPerformance.DataSource = pivot.DataSource;
                int i = pivot.Fields.Count;
                for (int j = 0; j < i; j++)
                    report.grdLaborPerformance.Fields.Add(pivot.Fields[j]);

                report.xrChart1.DataSource = chart.DataSource;

                report.xrChart1.SeriesDataMember = "Series";
                report.xrChart1.SeriesTemplate.ArgumentDataMember = "Arguments";
                report.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
                report.xrChart1.PaletteName = chart.PaletteName;
                report.xrChart1.SeriesTemplate.Label.Visible = chart.SeriesTemplate.Label.Visible;
                report.xrChart1.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                report.xrChart1.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 2;
                DevExpress.XtraCharts.XYDiagram diag = (DevExpress.XtraCharts.XYDiagram)report.xrChart1.Diagram;
                diag.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                diag.AxisY.NumericOptions.Precision = 2;
                diag.AxisX.Label.Angle = 50;

                report.xrChart1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Line);


                report.txtJobName.Text = jobName;
                report.txtJobNumber.Text = jobNumber;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void WeeklyQuantity(string jobName, string weekEnding, string jobID, string jobNumber)
        {


            try
            {
                DataTable table = JobCostTimeSheet.GetCostCodeWeekly(jobID, weekEnding).Tables[0];
                rptWeeklyQuantity report = new rptWeeklyQuantity();
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



                report.txtJobNumber.Text = jobNumber;
                report.txtJobName.Text = jobName;
                report.txtWeek.Text = weekEnding;
                report.DataSource = table;
                report.ShowPreviewDialog();
            }



            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void JobDashboardSummary(DevExpress.XtraCharts.ChartControl chart,
         DevExpress.XtraPivotGrid.PivotGridControl pivot, string reportQuery)

        {
            try
            {
                rptJobDashboardSummary report = new rptJobDashboardSummary();
                report.grdOrganization.DataSource = pivot.DataSource;
                report.lblReportQuery.Text = reportQuery;
                int i = pivot.Fields.Count;
                for (int j = 0; j < i; j++)
                    report.grdOrganization.Fields.Add(pivot.Fields[j]);
                //
                report.chartOrganization.DataSource = chart.DataSource;
                report.chartOrganization.SeriesDataMember = "Series";
                report.chartOrganization.SeriesTemplate.ArgumentDataMember = "Arguments";
                report.chartOrganization.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
                report.chartOrganization.PaletteName = chart.PaletteName;
                report.chartOrganization.SeriesTemplate.Label.Visible = chart.SeriesTemplate.Label.Visible;
                report.chartOrganization.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                report.chartOrganization.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 0;
                DevExpress.XtraCharts.XYDiagram diag = (DevExpress.XtraCharts.XYDiagram)report.chartOrganization.Diagram;
                diag.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                diag.AxisY.NumericOptions.Precision = 0;
                diag.AxisX.Label.Angle = 50;

                if (report.chartOrganization.Series.Count > 0)
                {
                    foreach (DevExpress.XtraCharts.Series ser in report.chartOrganization.Series)
                    {
                        if (ser.Name.Length > 13)
                            ser.LegendText = ser.Name.Substring(13, ser.Name.Length - 13);
                        else
                            ser.LegendText = "";
                    }
                }
                report.ShowPreviewDialog();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void JobSummaryDashboardSummary(DevExpress.XtraCharts.ChartControl chart,
         DevExpress.XtraPivotGrid.PivotGridControl pivot, string reportQuery)
        {
            try
            {
                rptJobSummaryDashboardSummary report = new rptJobSummaryDashboardSummary();
                report.grdOrganization.DataSource = pivot.DataSource;
                report.lblReportQuery.Text = reportQuery;
                int i = pivot.Fields.Count;
                for (int j = 0; j < i; j++)
                    report.grdOrganization.Fields.Add(pivot.Fields[j]);
                //
                report.chartOrganization.DataSource = chart.DataSource;
                report.chartOrganization.SeriesDataMember = "Series";
                report.chartOrganization.SeriesTemplate.ArgumentDataMember = "Arguments";
                report.chartOrganization.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
                report.chartOrganization.PaletteName = chart.PaletteName;
                report.chartOrganization.SeriesTemplate.Label.Visible = chart.SeriesTemplate.Label.Visible;
                report.chartOrganization.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                report.chartOrganization.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 0;
                DevExpress.XtraCharts.XYDiagram diag = (DevExpress.XtraCharts.XYDiagram)report.chartOrganization.Diagram;
                diag.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                diag.AxisY.NumericOptions.Precision = 0;
                diag.AxisX.Label.Angle = 50;

                if (report.chartOrganization.Series.Count > 0)
                {
                    foreach (DevExpress.XtraCharts.Series ser in report.chartOrganization.Series)
                    {
                        if (ser.Name.Length > 13)
                            ser.LegendText = ser.Name.Substring(13, ser.Name.Length - 13);
                        else
                            ser.LegendText = "";
                    }
                }
                report.ShowPreviewDialog();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void JobDashboardDetail(DataTable table, string reportQuery)
        {
            try
            {
                rptJobDashboardDetail report = new rptJobDashboardDetail();
                report.DataSource = table;
                report.lblReportQuery.Text = reportQuery;
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void JobWeeklyTimeSheet(string jobID, string jobNumber, string endDate, string jobName, DataSet dataSet)
        {
            try
            {
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Cost Codes in the Time Sheet!");
                    throw ex;

                }
                else
                {

                    rptWeeklyTimeSheet report = new rptWeeklyTimeSheet();
                    dataSet.Tables[0].DefaultView.RowFilter = "Selected = True";
                    report.txtSelectedDate.Text = endDate;
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.DataSource = dataSet;
                    // Office Address
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

                    report.ShowPreviewDialog();
                    dataSet.Tables[0].DefaultView.RowFilter = "";
                    // Add Offic Address


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void JobWeeklyQuantitySheet(string jobID, string jobNumber, string endDate, string jobName, DataSet dataSet)
        {
            try
            {
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    Exception ex = new Exception("No Cost Codes in the Quantity Sheet!");
                    throw ex;

                }
                else
                {
                    rptWeeklyQuantitySheet report = new rptWeeklyQuantitySheet();
                    dataSet.Tables[0].DefaultView.RowFilter = "Selected = True";
                    report.txtSelectedDate.Text = endDate;
                    report.txtJobNumber.Text = jobNumber;
                    report.txtJobName.Text = jobName;
                    report.DataSource = dataSet;

                    // Office Address
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


                    report.ShowPreviewDialog();
                    dataSet.Tables[0].DefaultView.RowFilter = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void POsWithNoInvoce(string where)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@Where", where);

                table = DataBaseUtil.ExecuteParDataset("up_JCPOsWithNoInvoceReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptPOsWithNoInvoice report = new rptPOsWithNoInvoice();
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void POsWithNoMatchInvoce(string where)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@Where", where);

                table = DataBaseUtil.ExecuteParDataset("up_JCPOsWithNoMatchInvoceReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptPOsWithNoMatchInvoice report = new rptPOsWithNoMatchInvoice();
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void JobLaborAnalysis(string where)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@Where", where);

                table = DataBaseUtil.ExecuteParDataset("up_JCLaborAnalysisReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptJobLaborAnalysis report = new rptJobLaborAnalysis();
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BidStatus(string where)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@Where", where);

                table = DataBaseUtil.ExecuteParDataset("up_jCBidStatusReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptBidSchedule report = new rptBidSchedule();
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void JobLogListAll(string where, string startDate, string endDate)
        {
            try
            {
                DataTable table;
                string query = "SELECT " +
                             " UserName as [User], " +
                             " JobNumber, " +
                             " JobName, " +
                             " Description AS [ContractType], " +
                             " Module = " +
                             " CASE Module " +
                             " WHEN 'B' THEN 'Job Info' " +
                             " WHEN 'W' THEN 'Weekly Quantity' " +
                             " WHEN 'P' THEN 'Job Progress' " +
                             " WHEN 'S' THEN 'Job Progress Summary' " +
                             " WHEN 'L' THEN 'Labor Feedback' " +
                             " ELSE '' " +
                             " END, " +
                             " COUNT(UserName) AS Usage " +
                             " FROM tblJobLog l " +
                             " LEFT JOIN tblUser u ON l.UserID = u.UserID " +
                             " LEFT JOIN tblJob j ON l.JobID = j.JobID " +
                             " LEFT Join tblContractType t ON j.ContractTypeID = t.ContractTypeID " +
                             where +
                             " GROUP BY UserName, JobNumber, JobName, Description, Module ";

                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptJobLogListAll report = new rptJobLogListAll();
                    report.DataSource = table;
                    report.txtStartDate.Text = startDate;
                    report.txtEndDate.Text = endDate;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void PreJobPlanning(string reportType)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@UserID", Security.Security.LoginID);
                par[1] = new SqlParameter("@ReportType", reportType);


                table = DataBaseUtil.ExecuteParDataset("up_JCJobPlanningReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptPreJobPlanning report = new rptPreJobPlanning();
                    if (reportType == "A")
                        report.txtTitle.Text += " - ACTIVE";
                    else
                        report.txtTitle.Text += " - COMPLETED";
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WeeklyEstimateSuccessful(string startDate, string endDate)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@StartDate", startDate);
                par[1] = new SqlParameter("@EndDate", endDate);
                par[2] = new SqlParameter("@UserID", Security.Security.LoginID);


                table = DataBaseUtil.ExecuteParDataset("up_jCWeeklyEstimateSuccessfulReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptWeeklyEstimateSuccessful report = new rptWeeklyEstimateSuccessful();
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void WeeklyEstimateBudget(string reportType, string reportCompany)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@UserID", Security.Security.LoginID);

                if (reportType == "0")
                {
                    if (reportCompany == "0")
                        table = DataBaseUtil.ExecuteParDataset("[up_JCWeeklyEstimateBudgetReport]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];
                    else
                        table = DataBaseUtil.ExecuteParDataset("[up_JCWeeklyEstimateBudgetEmcorReport]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];
                }
                else
                {
                    if (reportCompany == "0")
                        table = DataBaseUtil.ExecuteParDataset("[up_JCWeeklyEstimateBudgetOverMillionReport]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];
                    else
                        table = DataBaseUtil.ExecuteParDataset("[up_JCWeeklyEstimateBudgetOverMillionEmcorReport]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];
                }
                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptWeeklyEstimateBudget report = new rptWeeklyEstimateBudget();
                    if (reportType == "1")
                        report.txtTitle.Text += " - OVER $1M";
                    else
                        report.txtTitle.Text += " - ALL ";
                    report.DataSource = table;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void WeeklyEstimateNoNoBid(string startDate, string endDate)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@StartDate", startDate);
                par[1] = new SqlParameter("@EndDate", endDate);
                par[2] = new SqlParameter("@UserID", Security.Security.LoginID);

                table = DataBaseUtil.ExecuteParDataset("up_jCWeeklyEstimateNoNoBidReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptWeeklyEstimateNoNoBid report = new rptWeeklyEstimateNoNoBid();
                    report.DataSource = table;
                    report.txtTitle.Text = "WEEKLY ESTIMATE - NON SUCCESSFUL / NO BID / DROPPED";
                    report.txtTitle2.Text = "From: " + startDate + " To: " + endDate + " ";
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WeeklyNewJob(string startDate, string endDate)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@StartDate", startDate);
                par[1] = new SqlParameter("@EndDate", endDate);
                par[2] = new SqlParameter("@UserID", Security.Security.LoginID);


                table = DataBaseUtil.ExecuteParDataset("up_JCWeeklyNewJobReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptWeeklyNewJob report = new rptWeeklyNewJob();
                    report.DataSource = table;
                    report.txtTitle.Text = "WEEKLY NEW JOB";
                    report.txtTitle2.Text = "From: " + startDate + " To: " + endDate + " ";
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void OCIPClassifiedProjects(string startDate, string endDate)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@StartDate", startDate);
                par[1] = new SqlParameter("@EndDate", endDate);
                par[2] = new SqlParameter("@UserID", Security.Security.LoginID);


                table = DataBaseUtil.ExecuteParDataset("up_JCOCIPClassifiedProjectsReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptOCIPClassifiedProjects report = new rptOCIPClassifiedProjects();
                    report.DataSource = table;
                    report.txtTitle.Text = "OCIP CLASSIFIED PROJECTS";
                    report.txtTitle2.Text = "From: " + startDate + " To: " + endDate + " ";
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void WeeklyEstimateMillionDollar(string endDate)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@EndDate", endDate);
                par[1] = new SqlParameter("@UserID", Security.Security.LoginID);

                table = DataBaseUtil.ExecuteParDataset("up_jCWeeklyEstimateMillionDollarReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptWeeklyMillionDollar report = new rptWeeklyMillionDollar();
                    report.DataSource = table;
                    report.txtTitle2.Text = "Preparation Date: " + endDate;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WeeklyEstimateOpenPending(string endDate, string reportType, string company, string departmentID)
        {
            try
            {
                DataTable table;
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@EndDate", endDate);
                par[1] = new SqlParameter("@UserID", Security.Security.LoginID);
                par[2] = new SqlParameter("@ReportType", reportType);
                // par[3] = new SqlParameter("@DepartmentID", departmentID);

                if (company == "0")
                    table = DataBaseUtil.ExecuteParDataset("up_jCWeeklyEstimateOpenPendingReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];
                else
                    table = DataBaseUtil.ExecuteParDataset("up_jCWeeklyEstimateOpenPendingEMCORReport", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0];

                if (table.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Matching Record were found!");
                    throw ex;
                }
                else
                {
                    rptWeeklyEstimateOpenPending report = new rptWeeklyEstimateOpenPending();
                    report.DataSource = table;
                    switch (reportType)
                    {
                        case "0":
                            report.txtTitle.Text = "WEEKLY ESTIMATE - OPEN / PENDING";
                            break;
                        case "1":
                            report.txtTitle.Text = "WEEKLY ESTIMATE - OPEN ";
                            break;
                        case "2":
                            report.txtTitle.Text = "WEEKLY ESTIMATE - PENDING";
                            break;
                    }
                    report.txtTitle2.Text = "As of week ending: " + endDate;
                    report.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void PreBidRFISheet(string otProjectID, string OpportunityRTFID)
        {
            if (String.IsNullOrEmpty(OpportunityRTFID))
            {
                Exception ex = new Exception("Please select RFI to Print!");
                throw ex;
            }
            try
            {
                rptPreBidRFISheet report = new rptPreBidRFISheet();
                DataTable table = PreBidRFI.GetOpportunityOffice(otProjectID).Tables[0];
                if (table.Rows.Count > 0)
                {
                    report.txtPhone.Text = "Phone: " + table.Rows[0]["Phone"].ToString();
                    report.txtFax.Text = "Fax: " + table.Rows[0]["Fax"].ToString();
                    report.txtAddress.Text = table.Rows[0]["Address"].ToString() + " " +
                                        table.Rows[0]["City"].ToString() + ", " +
                                            table.Rows[0]["State"].ToString() + " " +
                                            table.Rows[0]["ZipCode"].ToString();
                }


                report.DataSource = PreBidRFI.GetRFISheet(OpportunityRTFID);
                report.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void JobPrelimInformation(string jobID)
        {
            try
            {
                rptJobPrelimInfo report = new rptJobPrelimInfo();
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

                report.DataSource = Job.GetJobPrelimInfo(jobID).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EmployeeTraining(string employeeID, string where)
        {
            if (String.IsNullOrEmpty(employeeID))
            {
                Exception ex = new Exception("No Selected Training to Print!");
                throw ex;
            }
            try
            {
                DataTable dtTraining = Employee.GetEmployeeTrainingData(where).Tables[0];
                if (dtTraining.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Training data for employee to Print!");
                    throw ex;
                }
                else
                {
                    rptEmployeeTraining report = new rptEmployeeTraining();
                    report.DataSource = dtTraining;
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
