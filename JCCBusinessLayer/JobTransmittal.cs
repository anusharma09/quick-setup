using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobTransmittal
    {
        private string jobTransmittalID;
        private string jobID;
        private string transmittalNumber;
        private string contactID;
        private string transmittalDate;
        private string from;
        private string shipVia;
        private string enclosed;
        private string underSeparateCover;
        private string originals;
        private string submittals;
        private string drawingsPrints;
        private string omManuals;
        private string letters;
        private string changeOrders;
        private string specifications;
        private string otherInfo;
        private string forYourReview;
        private string forYourInformation;
        private string forYourFiles;
        private string forYourApproval;
        private string actionRequired;
        private string asRequired;
        private string replyRequested;
        private string remarkOrReply;


        public string JobTransmittalID
        {
            get { return jobTransmittalID; }
        }
        //
        public string TransmittalNumber
        {
            get { return transmittalNumber; }
        }

        public JobTransmittal()
        {
        }
        public JobTransmittal(string jobTransmittalID,
                              string jobID,
                              string transmittalNumber,
                              string contactID,
                              string transmittalDate,
                              string from,
                              string shipVia,
                              string enclosed,
                              string underSeparateCover,
                              string originals,
                              string submittals,
                              string drawingsPrints,
                              string omManuals,
                              string letters,
                              string changeOrders,
                              string specifications,
                              string otherInfo,
                              string forYourReview,
                              string forYourInformation,
                              string forYourFiles,
                              string forYourApproval,
                              string actionRequired,
                              string asRequired,
                              string replyRequested,
                              string remarkOrReply)
        {
            //this.delayJob                   =  delayJob == "True" ? "1" : "0"; 
            this.jobTransmittalID = jobTransmittalID;
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.transmittalNumber = "'" + transmittalNumber.Trim().Replace("'", "''") + "'";
            this.contactID = String.IsNullOrEmpty(contactID) ? "Null" : contactID;
            this.transmittalDate = String.IsNullOrEmpty(transmittalDate) ? "Null" : "'" + transmittalDate + "'";
            this.from = "'" + from.Trim().Replace("'", "''") + "'";
            this.shipVia = "'" + shipVia.Trim().Replace("'", "''") + "'";
            this.enclosed = enclosed == "True" ? "1" : "0";
            this.underSeparateCover = underSeparateCover == "True" ? "1" : "0";
            this.originals = originals == "True" ? "1" : "0";
            this.submittals = submittals == "True" ? "1" : "0";
            this.drawingsPrints = drawingsPrints == "True" ? "1" : "0";
            this.omManuals = omManuals == "True" ? "1" : "0";
            this.letters = letters == "True" ? "1" : "0";
            this.changeOrders = changeOrders == "True" ? "1" : "0";
            this.specifications = specifications == "True" ? "1" : "0";
            this.otherInfo = "'" + otherInfo.Trim().Replace("'", "''") + "'";
            this.forYourReview = forYourReview == "True" ? "1" : "0";
            this.forYourInformation = forYourInformation == "True" ? "1" : "0";
            this.forYourFiles = forYourFiles == "True" ? "1" : "0";
            this.forYourApproval = forYourApproval == "True" ? "1" : "0";
            this.actionRequired = actionRequired == "True" ? "1" : "0";
            this.asRequired = asRequired == "True" ? "1" : "0";
            this.replyRequested = replyRequested == "True" ? "1" : "0";
            this.remarkOrReply = "'" + remarkOrReply.Trim().Replace("'", "''") + "'";
        }
        //

        public static DataSet GetJobTransmittalList(string jobID)
        {
            string query = "";

            if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
            {

                query = " SELECT " +
                    " JobTransmittalID, " +
                    " TransmittalNumber AS [No], " +
                    " TransmittalDate AS [Date], " +
                    " [From], " +
                    " Contact = " +
                    "   CASE LotusNotes " +
                    "   WHEN 1 THEN ISNULL(gc.FirstName, '') + ' ' + ISNULL(gc.LastName, '') + ' at: '  + ISNULL(gc.PhoneNumber, '') " +
                    "   ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') + ' at: '  + ISNULL(d.PhoneNumber,'') " +
                    " END, " +
                    " Company = " +
                    "   CASE LotusNotes " +
                    "   WHEN 1 THEN ISNULL(gc.CompanyName, '') " +
                    "   ELSE ISNULL(d.CompanyName, '') " +
                    " END, " +
                    " ShipVia AS [Ship Via], " +
                    " Enclosed, " +
                    " UnderSeparateCover AS [Under Separate Cover], " +
                    " ActionRequired AS [Action Required], " +
                    " AsRequired AS [AS Required], " +
                    " ReplyRequested AS [Reply Requested] " +
                    " FROM tblJobTransmittal t " +
                    " LEFT JOIN  tblJobContact jc ON t.ContactID = jc.ContactID " +
                    " LEFT JOIN tblGlobalContact gc ON jc.CompanyContactID = gc.GlobalContactID  " +
                    " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                " WHERE t.JobID = " + jobID + " ";

            }
            else
            {
                query = " SELECT " +
                    " JobTransmittalID, " +
                    " TransmittalNumber AS [No], " +
                    " TransmittalDate AS [Date], " +
                    " [From], " +
                    " Contact = " +
                    "   CASE LotusNotes " +
                    "   WHEN 1 THEN ISNULL(c.FirstName, '') + ' ' + ISNULL(c.LastName, '') + ' at: '  + ISNULL(c.PhoneNumber, '') " +
                    "   ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') + ' at: '  + ISNULL(d.PhoneNumber,'') " +
                    " END, " +
                    " Company = " +
                    "   CASE LotusNotes " +
                    "   WHEN 1 THEN ISNULL(c.CompanyName, '') " +
                    "   ELSE ISNULL(d.CompanyName, '') " +
                    " END, " +
                    " ShipVia AS [Ship Via], " +
                    " Enclosed, " +
                    " UnderSeparateCover AS [Under Separate Cover], " +
                    " ActionRequired AS [Action Required], " +
                    " AsRequired AS [AS Required], " +
                    " ReplyRequested AS [Reply Requested] " +
                    " FROM tblJobTransmittal t " +
                    " LEFT JOIN  tblJobContact jc ON t.ContactID = jc.ContactID " +
                    " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                " WHERE t.JobID = " + jobID + " ";
            }

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static bool IsTransmittalInDatabase(string transmittalNumber, string jobID)
        {
            string query = "";
            bool ret = false;
            DataTable t;
            query = " SELECT JobTransmittalID FROM tblJobTransmittal WHERE TransmittalNumber = '" + transmittalNumber + "' AND JobID = " + jobID + " ";

            try
            {
                t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    ret = true;
                else
                    ret = false;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobDefaultFrom(string jobID)
        {
            string query = "";

            query = " SELECT " +
                    "  [From] =  " +
                    "   CASE nn.LotusNotes " +
                    "   WHEN 1 THEN ISNULL(gc.FirstName, '') + ' ' + ISNULL(gc.LastName, '') " +
                    "   ELSE ISNULL(pp.FirstName, '') + ' ' + ISNULL(pp.LastName, '') " +
                    " END  " +
                    " FROM tblJobDefaultValues mm " +
                    " LEFT JOIN  tblJobContact nn ON mm.JobDefaultFromID = nn.ContactID " +
                    " LEFT JOIN tblGlobalContact gc ON nn.CompanyContactID = gc.GlobalContactID  " +
                    " LEFT JOIN tblCompanyContact oo ON nn.CompanyContactID = oo.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail pp ON nn.CompanyContactID = pp.JobContactDetailID " +

                " WHERE mm.JobID = " + jobID + " ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetTransmittalForm(string jobTransmittalID)
        {
            string query = "";

            query = " SELECT Distinct " +
                    " JobTransmittalNumber = JobNumber + '-' + TransmittalNumber, " +
                    " JobName, " +
                    " OfficeName = OfficeName, " +
                    " OfficeAddress = address, " +
                    " OfficeCityStateZip = ISNULL(o.City, '') + ', ' + ISNULL(o.State, '') + ' ' + ISNULL(o.ZipCode, '') , " +
                    " OfficePhone = o.Phone, " +
                    " OfficeFax = o.Fax, " +
                    " Att =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(c.FirstName, '') + ' ' + ISNULL(c.LastName, '') " +
                    "   ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') " +
                    " END, " +
                    " CompanyName = " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(c.CompanyName, '') " +
                    "   ELSE ISNULL(d.CompanyName, '')  " +
                    " END, " +
                    "  CompanyAddress =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(c.OfficeStreetAddress, '') " +
                    "   ELSE ISNULL(d.OfficeStreetAddress, '')  " +
                    " END, " +
                    "   CompanyCityStateZip =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(c.OfficeCity, '') + ', ' + ISNULL(c.OfficeState, '') + ' ' + ISNULL(c.OfficeZip, '') " +
                    "   ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' ' + ISNULL(d.OfficeZip, '') " +
                    " END, " +
                    "  [From], " +
                    " t.*, " +
                    " tt.* " +
                    " FROM tblJobTransmittal t " +
                    " LEFT JOIN tblJobTransmittalDetail tt ON t.JobTransmittalID = tt.JobTransmittalID " +
                    " LEFT JOIN tblJob j ON t.JobID = j.JobID " +
                    " LEFT JOIN  tblJobContact jc ON t.ContactID = jc.ContactID " +
                    " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                    " LEFT JOIN tblOffice o ON j.OfficeID = o.OfficeID " +
                " WHERE t.JobTransmittalID = " + jobTransmittalID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetTransmittalFormForNewJobs(string jobTransmittalID)
        {
            string query = "";

            query = " SELECT Distinct " +
                    " JobTransmittalNumber = JobNumber + '-' + TransmittalNumber, " +
                    " JobName, " +
                    " OfficeName = OfficeName, " +
                    " OfficeAddress = address, " +
                    " OfficeCityStateZip = ISNULL(o.City, '') + ', ' + ISNULL(o.State, '') + ' ' + ISNULL(o.ZipCode, '') , " +
                    " OfficePhone = o.Phone, " +
                    " OfficeFax = o.Fax, " +
                    " Att =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.FirstName, '') + ' ' + ISNULL(gc.LastName, '') " +
                    "   ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') " +
                    " END, " +
                    " CompanyName = " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.CompanyName, '') " +
                    "   ELSE ISNULL(d.CompanyName, '')  " +
                    " END, " +
                    "  CompanyAddress =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.OfficeStreetAddress, '') " +
                    "   ELSE ISNULL(d.OfficeStreetAddress, '')  " +
                    " END, " +
                    "   CompanyCityStateZip =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.OfficeCity, '') + ', ' + ISNULL(gc.OfficeState, '') + ' ' + ISNULL(gc.OfficeZip, '') " +
                    "   ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' ' + ISNULL(d.OfficeZip, '') " +
                    " END, " +
                    "  [From], " +
                    " t.*, " +
                    " tt.* " +
                    " FROM tblJobTransmittal t " +
                    " LEFT JOIN tblJobTransmittalDetail tt ON t.JobTransmittalID = tt.JobTransmittalID " +
                    " LEFT JOIN tblJob j ON t.JobID = j.JobID " +
                    " LEFT JOIN  tblJobContact jc ON t.ContactID = jc.ContactID " +
                    // " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblGlobalContact gc ON jc.CompanyContactID = gc.GlobalContactID  " +
                    " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                    " LEFT JOIN tblOffice o ON j.OfficeID = o.OfficeID " +
                " WHERE t.JobTransmittalID = " + jobTransmittalID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetTransmittalDetail(string jobTransmittalID)
        {
            string query = "";

            query = " SELECT * FROM tblJobTransmittal WHERE JobTransmittalID = " + jobTransmittalID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobTransmittalID == "" || jobTransmittalID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobTransmittal(" +
                    " JobID, " +
                    " TransmittalNumber, " +
                    " ContactID, " +
                    " TransmittalDate, " +
                    " [From], " +
                    " ShipVia, " +
                    " Enclosed, " +
                    " UnderSeparateCover, " +
                    " Originals, " +
                    " Submittals, " +
                    " DrawingsPrints, " +
                    " OMManuals, " +
                    " Letters, " +
                    " ChangeOrders, " +
                    " Specifications, " +
                    " OtherInfo, " +
                    " ForYourReview, " +
                    " ForYourInformation, " +
                    " ForYourFiles, " +
                    " ForYourApproval, " +
                    " ActionRequired, " +
                    " AsRequired, " +
                    " ReplyRequested, " +
                    " RemarkOrReply) VALUES ( " +
                    jobID + ", " +
                    transmittalNumber + ", " +
                    contactID + ", " +
                    transmittalDate + ", " +
                    from + ", " +
                    shipVia + ", " +
                    enclosed + ", " +
                    underSeparateCover + ", " +
                    originals + ", " +
                    submittals + ", " +
                    drawingsPrints + ", " +
                    omManuals + ", " +
                    letters + ", " +
                    changeOrders + ", " +
                    specifications + ", " +
                    otherInfo + ", " +
                    forYourReview + ", " +
                    forYourInformation + ", " +
                    forYourFiles + ", " +
                    forYourApproval + ", " +
                    actionRequired + ", " +
                    asRequired + ", " +
                    replyRequested + ", " +
                    remarkOrReply + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobTransmittalID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT TransmittalNumber FROM tblJobTransmittal WHERE JobTransmittalID = " + jobTransmittalID + " ";

                DataTable t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                {
                    transmittalNumber = t.Rows[0]["TransmittalNumber"].ToString();
                }
                else
                {
                    transmittalNumber = "";
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool Update()
        {
            string query = "";

            query = "Update tblJobTransmittal SET " +
                     " JobID                = " + jobID + ", " +
                     " TransmittalNumber    = " + transmittalNumber + ", " +
                     " ContactID            = " + contactID + ", " +
                     " TransmittalDate      = " + transmittalDate + ", " +
                     " [From]               = " + from + ", " +
                     " ShipVia              = " + shipVia + ", " +
                     " Enclosed             = " + enclosed + ", " +
                     " UnderSeparateCover   = " + underSeparateCover + ", " +
                     " Originals            = " + originals + ", " +
                     " Submittals           = " + submittals + ", " +
                     " DrawingsPrints       = " + drawingsPrints + ", " +
                     " OMManuals            = " + omManuals + ", " +
                     " Letters              = " + letters + ", " +
                     " ChangeOrders         = " + changeOrders + ", " +
                     " Specifications       = " + specifications + ", " +
                     " OtherInfo            = " + otherInfo + ", " +
                     " ForYourReview        = " + forYourReview + ", " +
                     " ForYourInformation   = " + forYourInformation + ", " +
                     " ForYourFiles         = " + forYourFiles + ", " +
                     " ForYourApproval      = " + forYourApproval + ", " +
                     " ActionRequired       = " + actionRequired + ", " +
                     " AsRequired           = " + asRequired + ", " +
                     " ReplyRequested       = " + replyRequested + ", " +
                     " RemarkOrReply        =  " + remarkOrReply + " " +
                " WHERE JobTransmittalID  = " + jobTransmittalID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
