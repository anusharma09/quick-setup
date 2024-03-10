using ContraCostaElectric.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace JCCBusinessLayer
{
    public class ProjectProposal
    {
        private readonly string proposalID;
        private readonly string subject;
        private readonly string date;
        private readonly string user;
        private readonly string jobID;
        private readonly string dynaEstimate;
        private readonly string REV;
        //  private readonly string newREV;
        private readonly string description;
        private readonly string leadTimes;
        private readonly string GenInfo;
        private readonly string Alternates;
        private readonly string clarification;
        private readonly string exclusion;
        private readonly DataTable pricingDT;
        private readonly DataTable pricingAlternateDT;


        public static string globalProposalID { get; set; }
        public static string ProfilePicDestinationPath { get; set; }
        public string TargetProfilePicPath { get; set; }
        public static string OldDescription { get; set; }
        public static string oldLeadtimes { get; set; }
        public static string oldClarification { get; set; }
        public static string oldGenInfo { get; set; }
        public static string oldAlternate { get; set; }
        public static string oldExclusion { get; set; }

        public static string globalJobid { get; set; }

        public static string globalClarification { get; set; }
        public static string globalREV;
        public static string globalnewREV;

        private static string globalUser;
        public ProjectProposal(string proposalID, string JobID,
            string subject,
                        string date,
                        string user,
                        string dynaEstimate,
                        string rev,
                        string Description,
                        string LeadTimes,
                        string genInfo,
                        string Alternates,
                        string Clarification,
                        string Exclusion,
                        DataTable pricing,
                        DataTable alternatePricing
                         )
        {
            globalProposalID = proposalID.Trim().Replace("'", "''");
            this.proposalID = "'" + proposalID.Trim().Replace("'", "''") + "'";
            this.subject = "'" + subject.Trim().Replace("'", "''") + "'";
            this.date = String.IsNullOrEmpty(date) ? "Null" : "'" + date + "'";
            this.user = "'" + user.Trim().Replace("'", "''") + "'";
            this.dynaEstimate = "'" + dynaEstimate.Trim().Replace("'", "''") + "'";
            this.jobID = globalJobid = "'" + JobID.Trim().Replace("'", "''") + "'";
            this.REV = globalREV = "'" + rev.Trim().Replace("'", "''") + "'";
            this.description = "'" + Description.Trim().Replace("'", "''") + "'";
            this.leadTimes = "'" + LeadTimes.Trim().Replace("'", "''") + "'";
            this.GenInfo = "'" + genInfo.Trim().Replace("'", "''") + "'";
            this.Alternates = "'" + Alternates.Trim().Replace("'", "''") + "'";
            this.clarification = globalClarification = "'" + Clarification.Trim().Replace("'", "''") + "'";
            this.exclusion = "'" + Exclusion.Trim().Replace("'", "''") + "'";
            this.pricingDT = pricing;
            this.pricingAlternateDT = alternatePricing;
        }

        public static DataSet Getproposals(int ProposalID)
        {
            SqlParameter[] par;
            DataSet prop = new DataSet();
            try
            {
                par = new SqlParameter[1];
                par[0] = new SqlParameter("@ProposalID", ProposalID);
                prop = DataBaseUtil.ExecuteParDataset("SP_GetProjectProposals", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prop;
        }

        public static DataTable GetJobAndEstimateNumber(string jobID)
        {
            string query = "";
            query = " select JobName, EstimateNumber, * from tblJob where JobID =" + jobID;
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      


        public static DataSet GetClarification()
        {
            string query = "";
            query = "select value from DefaultValuelist  where valuename ='Clarification'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetGenInfoAndAlternates()
        {
            string query = "";
            query = "select value from DefaultValuelist  where valuename ='GenInfo' or valuename ='Alternate'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetProposals(string jobID)
        {
            string query = "";
            query = " select distinct ROW_NUMBER() Over (Order by MP.ProposalID) As [Serial No.], MP.ProposalID,MP.JobID,MP.Subject,MP.Date,MP.[user] as UserID, " +
                "[User] = CASE LotusNotes WHEN 1 THEN ISNULL(gc.FirstName, '') +' ' + ISNULL(gc.LastName, '') ELSE ISNULL(d.FirstName, '') +' ' + ISNULL(d.LastName, '') END , " +
                "Company = CASE LotusNotes WHEN 1 THEN ISNULL(gc.CompanyName, '') ELSE ISNULL(d.CompanyName, '') END ," +
                " MP.DynaEstimate,MAX(MP.REV) as REV  from tblMasterProposalDetails MP " +
                "LEFT JOIN  tblJobContact jc ON MP.[User] = jc.ContactID LEFT JOIN tblGlobalContact gc ON jc.CompanyContactID = gc.GlobalContactID " +
                "LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID WHERE MP.JobID =" + jobID +
                "and  MP.rev = (SELECT max(rev) FROM tblMasterProposalDetails MD WHERE MD.ProposalID = MP.ProposalID) " +
                "group by MP.[user],MP.ProposalID,MP.JobID,MP.[Subject],MP.Date,[User],MP.DynaEstimate ,jc.LotusNotes,gc.FirstName,gc.LastName,d.FirstName,d.LastName,gc.CompanyName,d.CompanyName";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetProposalDescription(string proposalID, string user, string rev)
        {
            string query = "";
            query = "select Desription as Value from tblMasterProposalDescription  WHERE proposalID = '" + proposalID + "' AND REV = '" + rev + "' AND [User] = '" + user + "'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetProposalleadTime(string proposalID, string user, string rev)
        {
            string query = "";
            query = "select LeadTime as value from tblMasterProposalLeadTimes  WHERE proposalID = '" + proposalID + "' AND REV = '" + rev + "' AND [User] = '" + user + "'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetProposalClarification(string proposalID, string user, string rev)
        {
            string query = "";
            query = "select Clarification as value from tblMasterProposalClarification  WHERE proposalID = '" + proposalID + "' AND REV = '" + rev + "' AND [User] = '" + user + "'";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetProposalGenInfoAndAlternate(string proposalID, string user, string rev)
        {
            string query = "";
            query = "select GenInfo as value ,Alternate as value2 from tblMasterProposalScopeInfo  WHERE proposalID = '" + proposalID + "' AND REV = '" + rev + "' AND [User] = '" + user + "'";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetProposalExclusion(string proposalID, string user, string rev)
        {
            string query = "";
            query = "select Exclusion as value from tblMasterProposalExclusions  WHERE proposalID = '" + proposalID + "' AND REV = '" + rev + "' AND [User] = '" + user + "'";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public static DataSet GetPricingAlternate(int ProposalID, int user, int rev)
        {
            SqlParameter[] par;
            DataSet emp = new DataSet();
            try
            {
                par = new SqlParameter[3];
                par[0] = new SqlParameter("@ProposalID", ProposalID);
                par[1] = new SqlParameter("@user", user);
                par[2] = new SqlParameter("@rev", rev);
                emp = DataBaseUtil.ExecuteParDataset("up_GetPricingAlternate", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }

        public static DataSet GetPricingForReport(int ProposalID, int user, int rev)
        {
            SqlParameter[] par;
            DataSet emp = new DataSet();
            try
            {
                par = new SqlParameter[3];
                par[0] = new SqlParameter("@ProposalID", ProposalID);
                par[1] = new SqlParameter("@user", user);
                par[2] = new SqlParameter("@rev", rev);
                emp = DataBaseUtil.ExecuteParDataset("up_GetPricingForReport", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }

        public static DataSet GetPricingAlternateForReport(int ProposalID, int user, int rev)
        {
            SqlParameter[] par;
            DataSet emp = new DataSet();
            try
            {
                par = new SqlParameter[3];
                par[0] = new SqlParameter("@ProposalID", ProposalID);
                par[1] = new SqlParameter("@user", user);
                par[2] = new SqlParameter("@rev", rev);
                emp = DataBaseUtil.ExecuteParDataset("up_GetPricingAlternateForReport", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }

        public static DataSet GetDefaultExclusion()
        {
            string query = "";
            query = "select value from DefaultValuelist  where valuename ='Exclusion'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetDefaultDescription()
        {

            string query = "";

            query = "select value from DefaultValuelist  where valuename ='Description'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetLeadTimes()
        {
            string query = "";
            query = "select value from DefaultValuelist  where valuename ='LeadTimes'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetContacts()
        {
            string query = "";
            query = "select GlobalContactID as ContactID,FirstName + ' '  + LastName as Name, CompanyName from tblGlobalContact";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string  Save()
        {
            string ID = string.Empty;
            if (string.IsNullOrEmpty(globalProposalID) || globalProposalID == "0")
            {

                 ID= Insert();
            }
            else
            {

                ID= Update();
            }
            return ID;
        }

        private string Insert()
        {
            string query = string.Empty;

            string countQuery = string.Empty;
            countQuery = "select count (*) AS count from tblMasterProposalDetails where JobID = " + jobID +
                " AND [user] = " + user +
                " AND REV = " + REV;

            if (Convert.ToInt16(DataBaseUtil.ExecuteDataset(countQuery, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0]["count"].ToString()) > 0)
            {
                return "Proposal Already Exist";
            }
            else
            {
                string queryForUpdatedProposalID = string.Empty;
                queryForUpdatedProposalID = "if ((select count(*) from tblMasterProposalDetails )>0)" +
                    " BEGIN select MAX(proposalID) + 1 from tblMasterProposalDetails as ProposalID END " +
                    "else " +
                    "BEGIN    " +
                    "select 1 AS ProposalID END";

                int proposalID = Convert.ToInt32(DataBaseUtil.ExecuteScalar(queryForUpdatedProposalID, CCEApplication.Connection, CommandType.Text));

                query = "INSERT INTO tblMasterProposalDetails(ProposalID,JobID,Date,Subject,[User],DynaEstimate, REV) VALUES (" +
                    proposalID + ", " + jobID + ", " + date + ", " + subject + "," + user + "," + dynaEstimate + "," + REV + ")";
                try
                {

                    DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    globalProposalID = proposalID.ToString();
                    if (!string.IsNullOrEmpty(globalProposalID))
                    {
                        if (!string.IsNullOrEmpty(description))
                        {
                            query = "INSERT INTO tblMasterProposalDescription(ProposalID,Desription,REV,[User]) VALUES (" +
                       globalProposalID + ", " + description + ", " + REV + "," + user + ")" +
                       " Select @@IDENTITY ";

                            string descriptionID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                        }
                        if (!string.IsNullOrEmpty(leadTimes))
                        {
                            query = "INSERT INTO tblMasterProposalLeadTimes(ProposalID,LeadTime,REV,[User]) VALUES (" +
                       globalProposalID + ", " + leadTimes + ", " + REV + "," + user + ")" +
                       " Select @@IDENTITY ";

                            string leadTimeID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                        }
                        if (!string.IsNullOrEmpty(clarification))
                        {
                            query = "INSERT INTO tblMasterProposalClarification(ProposalID,Clarification,REV,[User]) VALUES (" +
                        globalProposalID + ", " + clarification + ", " + REV + "," + user + ")" +
                        " Select @@IDENTITY ";

                            string clarificationID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                        }
                        if (!string.IsNullOrEmpty(exclusion))
                        {
                            query = "INSERT INTO tblMasterProposalExclusions(ProposalID,Exclusion,REV,[User]) VALUES (" +
                      globalProposalID + ", " + exclusion + ", " + REV + "," + user + ")" +
                      " Select @@IDENTITY ";

                            string ExclusionID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                        }

                        if (!string.IsNullOrEmpty(GenInfo) && !string.IsNullOrEmpty(Alternates))
                        {
                            query = "INSERT INTO tblMasterProposalScopeInfo(ProposalID,GenInfo,Alternate,REV,[User]) VALUES (" +
                      globalProposalID + ", " + GenInfo + ", " + Alternates + ", " + REV + "," + user + ")" +
                      " Select @@IDENTITY ";

                            string ExclusionscopeinfoID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                        }

                    }
                    return Convert.ToString(proposalID);
                }
                catch (Exception ex)
                {
                    return "0";
                }
            }
        }

        private string Update()
        {
            string result = "False";
            string query = "";
            query = "Update tblMasterProposalDetails SET " +
                    " Subject                 = " + subject + ", " +
                    " Date               = " + date + ", " +
                    " [User]               = " + user + ", " +
                    " DynaEstimate      = " + dynaEstimate +

                    " WHERE Rev = " + globalREV + " and ProposalID  = " + Convert.ToInt32(globalProposalID);
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                result= "True";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool Delete(int proposalID, int user, int rev)
        {
            SqlParameter[] par;
            try
            {
                par = new SqlParameter[3];
                par[0] = new SqlParameter("@ProposalID", Convert.ToInt32(proposalID));
                par[1] = new SqlParameter("@user", Convert.ToInt32(user));
                par[2] = new SqlParameter("@rev", Convert.ToInt32(rev));
                DataBaseUtil.ExecuteParDataset("sp_DeleteProposal", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool UpdateDescription(string Id, string description, string rev, string user)
        {
            string query = "";

            query = " UPDATE tblMasterProposalDescription SET " +
                " Desription   = " + "'" + description.Trim().Replace("'", "''") + "'" + " " +
               " WHERE ProposalID = " + Id + " and REV=" + rev + " and [user]=" + user + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Security.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool deletePricing(string Id, string rev, string user)
        {
            string query = "";

            query = " Delete from tblMasterProposalPricing "+
               " WHERE ProposalID = " + Id + " and REV=" + rev + " and [user]=" + user + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Security.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool deletePricingAlternate(string Id, string rev, string user)
        {
            string query = "";

            query = " Delete from tblMasterProposalAlternate " +
               " WHERE ProposalID = " + Id + " and REV=" + rev + " and [user]=" + user + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Security.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdateLeadTimes(string Id, string leadtimes, string rev, string user)
        {
            string query = "";

            query = " UPDATE tblMasterProposalLeadTimes SET " +
                " LeadTime   = " + "'" + leadtimes.Trim().Replace("'", "''") + "'" + " " +
               " WHERE ProposalID = " + Id + " and REV=" + rev + " and [user]=" + user + " ";
            try
            {
                DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static bool UpdateClarification(string Id, string Clarification, string rev, string user)
        {
            string query = "";
            query = "Update tblMasterProposalClarification SET " +
                   " Clarification   = " + "'" + Clarification.Trim().Replace("'", "''") + "'" + " " +
                   " WHERE ProposalID = " + Id + " and REV=" + rev + " and [user]=" + user + " ";

            try
            {
                DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool UpdateExclusion(string Id, string Exclusion, string rev, string user)
        {
            string query = "";

            query = " UPDATE tblMasterProposalExclusions SET " +
                " Exclusion   = " + "'" + Exclusion.Trim().Replace("'", "''") + "'" + " " +
              " WHERE ProposalID = " + Id + " and REV=" + rev + " and [user]=" + user + " ";
            try
            {
                DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static bool UpdategenInfoAndAlternate(string Id, string GenInfo, string Alternate, string rev, string user)
        {
            string query = "";
            query = "Update tblMasterProposalScopeInfo SET " +
                   " GenInfo   = " + "'" + GenInfo.Trim().Replace("'", "''") + "'" + ", " +
                    " Alternate =" + "'" + Alternate.Trim().Replace("'", "''") + "'" + " " +
                   " WHERE ProposalID = " + Id + " and REV=" + rev + " and [user]=" + user + " ";

            try
            {
                DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string RtfToPlainText(string rtf)
        {
            try
            {
                System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
                // Convert the RTF to plain text.
                rtBox.Rtf = rtf;
                return rtBox.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool CreateRevision(DataTable dtPrice, DataTable dtAlternatePrice)
        {

            string query = "INSERT INTO tblMasterProposalDetails(ProposalID,JobID,Date,Subject,[User],DynaEstimate, REV) VALUES (" +
                 proposalID + ", " + jobID + ", " + date + ", " + subject + "," + user + "," + dynaEstimate + "," + REV + ")";
            try
            {

                DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                globalProposalID = proposalID.ToString();
                if (!string.IsNullOrEmpty(globalProposalID))
                {
                    if (!string.IsNullOrEmpty(description))
                    {
                        query = "INSERT INTO tblMasterProposalDescription(ProposalID,Desription,REV,[User]) VALUES (" +
                   globalProposalID + ", " + description + ", " + REV + "," + user + ")" +
                   " Select @@IDENTITY ";

                        string descriptionID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    }
                    if (!string.IsNullOrEmpty(leadTimes))
                    {
                        query = "INSERT INTO tblMasterProposalLeadTimes(ProposalID,LeadTime,REV,[User]) VALUES (" +
                   globalProposalID + ", " + leadTimes + ", " + REV + "," + user + ")" +
                   " Select @@IDENTITY ";

                        string leadTimeID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    }
                    if (!string.IsNullOrEmpty(clarification))
                    {
                        query = "INSERT INTO tblMasterProposalClarification(ProposalID,Clarification,REV,[User]) VALUES (" +
                    globalProposalID + ", " + clarification + ", " + REV + "," + user + ")" +
                    " Select @@IDENTITY ";

                        string clarificationID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    }
                    if (!string.IsNullOrEmpty(exclusion))
                    {
                        query = "INSERT INTO tblMasterProposalExclusions(ProposalID,Exclusion,REV,[User]) VALUES (" +
                  globalProposalID + ", " + exclusion + ", " + REV + "," + user + ")" +
                  " Select @@IDENTITY ";

                        string ExclusionID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    }

                    if (!string.IsNullOrEmpty(GenInfo) && !string.IsNullOrEmpty(Alternates))
                    {
                        query = "INSERT INTO tblMasterProposalScopeInfo(ProposalID,GenInfo,Alternate,REV,[User]) VALUES (" +
                  globalProposalID + ", " + GenInfo + ", " + Alternates + ", " + REV + "," + user + ")" +
                  " Select @@IDENTITY ";

                        string ExclusionscopeinfoID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                        //return true;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                SqlConnection con = new SqlConnection(CCEApplication.Connection);
                //create object of SqlBulkCopy which help to insert  
                SqlBulkCopy objbulk = new SqlBulkCopy(con);

                //assign Destination table name  
                objbulk.DestinationTableName = "tblMasterProposalPricing";
                objbulk.ColumnMappings.Add("ProposalID", "ProposalID");
                objbulk.ColumnMappings.Add("BaseBid", "BaseBid");
                objbulk.ColumnMappings.Add("Price", "Price");
                objbulk.ColumnMappings.Add("REV", "REV");
                objbulk.ColumnMappings.Add("User", "User");

                con.Open();
                //insert bulk Records into DataBase.  
                objbulk.WriteToServer(dtPrice);
                con.Close();
            }
            catch (Exception ex)
            { }
            try
            {
                SqlConnection con = new SqlConnection(CCEApplication.Connection);
                //create object of SqlBulkCopy which help to insert  
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                //assign Destination table name  
                objbulk.DestinationTableName = "tblMasterProposalAlternate";
                objbulk.ColumnMappings.Add("ProposalID", "ProposalID");
                objbulk.ColumnMappings.Add("Alternate", "Alternate");
                objbulk.ColumnMappings.Add("AlternatePrice", "AlternatePrice");
                objbulk.ColumnMappings.Add("REV", "REV");
                objbulk.ColumnMappings.Add("User", "User");

                con.Open();
                //insert bulk Records into DataBase.  
                objbulk.WriteToServer(dtAlternatePrice);
                con.Close();
            }
            catch (Exception ex)
            { }
            return true;
        }

        public static bool BulkUpdatePricing(DataTable dtprice)
        {
            try
            {
                if (dtprice.Rows.Count > 0)
                {
                    SqlConnection con = new SqlConnection(CCEApplication.Connection);
                    //create object of SqlBulkCopy which help to insert  
                    SqlBulkCopy objbulk = new SqlBulkCopy(con);

                    //assign Destination table name  
                    objbulk.DestinationTableName = "tblMasterProposalPricing";
                    objbulk.ColumnMappings.Add("ProposalID", "ProposalID");
                    objbulk.ColumnMappings.Add("BaseBid", "BaseBid");
                    objbulk.ColumnMappings.Add("Price", "Price");
                    objbulk.ColumnMappings.Add("REV", "REV");
                    objbulk.ColumnMappings.Add("User", "User");

                    con.Open();
                    //insert bulk Records into DataBase.  
                    objbulk.WriteToServer(dtprice);
                    con.Close();
                }
               
            }
            catch (Exception ex)
            { }
            return true;
            
        }
        public static bool BulkUpdatePricingAlternate(DataTable dtPriceAlternate)
        {
            try
            {
                if (dtPriceAlternate.Rows.Count > 0)
                {
                    SqlConnection con = new SqlConnection(CCEApplication.Connection);
                    //create object of SqlBulkCopy which help to insert  
                    SqlBulkCopy objbulk = new SqlBulkCopy(con);
                    //assign Destination table name  
                    objbulk.DestinationTableName = "tblMasterProposalAlternate";
                    objbulk.ColumnMappings.Add("ProposalID", "ProposalID");
                    objbulk.ColumnMappings.Add("Alternate", "Alternate");
                    objbulk.ColumnMappings.Add("AlternatePrice", "AlternatePrice");
                    objbulk.ColumnMappings.Add("REV", "REV");
                    objbulk.ColumnMappings.Add("User", "User");

                    con.Open();
                    //insert bulk Records into DataBase.  
                    objbulk.WriteToServer(dtPriceAlternate);
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public static string GetNewRevison(int proposalID, int user)
        {
            string query = "";
            query = "select MAX(Rev) + 1 from tblMasterProposalDetails where ProposalID= " + proposalID + " and [User] = " + user + " ";
            try
            {
                string newRevison = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return newRevison;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
