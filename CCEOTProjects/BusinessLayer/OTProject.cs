using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CCEOTProjects.BusinessLayer
{
    class OTProject
    {
        private string otProjectID; 
	    private string otProjectNumber; 
	    private string otProjectStatusID;
	    private string workTypeID; 
	    private string officeID; 
	    private string departmentID;
        private string assignedTo;
        private string assignedToAccepted;
	    private string estimateNumber;
	    private string rush; 
	    private string otProjectName; 
	    private string otProjectAddress; 
	    private string otProjectCity; 
	    private string otProjectState; 
	    private string otProjectZip; 
	    private string bidBondRequired; 
	    private string ppbRequired; 
	    private string bidDate; 
	    private string bidTime; 
	    private string bidWalkDate; 
	    private string bidWalkTime; 
	    private string cceRepForBidWalk;
	    private string biddingAsPrime; 
	    private string biddingAsSub;  
	    private string nextActionNeeded;  
	    private string nextActionDate;
        private string nextActionDateAuto;
        private string prequalDate;
	    private string bidToOwner;  
	    private string bidToContractor; 
	    private string bidToDeveloper;
	    private string bidToOther;
        private string bidToOtherDescription;
	    private string description;
	    private string projectTotalDollar;				
	    private string electricalDollar;
	    private string forwardForApproval;
	    private string engineered; 
	    private string leed; 
	    private string designBuild; 
	    private string designAssist; 
	    private string pla; 
	    private string prevailingWage; 
	    private string budgetOnly; 
	    private string bid; 
	    private string negotiated;
	    private string other; 
	    private string financeInPlace; 
	    private string minorityRequirements;		
        private string minorityType;
	    private string prequalRequired; 
	    private string drawingAvailable;
	    private string opportunityValue;			 
	    private string note; 
	    private string website;  
	    private string ownerName; 
	    private string ownerAddress; 
	    private string ownerCity; 
	    private string ownerState; 
	    private string ownerZip; 
	    private string ownerContactName; 
	    private string ownerContactEmail; 
	    private string ownerContactPhone; 
	    private string ownerContactFax; 
	    private string generalContractorName; 
	    private string generalContractorAddress; 
	    private string generalContractorCity; 
	    private string generalContractorState;			 
	    private string generalContractorZip; 
	    private string generalContractorContactName; 
	    private string generalContractorContactEmail; 
	    private string generalContractorContactPhone;	 
	    private string generalContractorContactFax;
        private string developerName;
        private string developerAddress;
        private string developerCity;
        private string developerState;
        private string developerZip;
        private string developerContactName;
        private string developerContactEmail;
        private string developerContactPhone;
        private string developerContactFax;
        private string architectName;
        private string architectAddress;
        private string architectCity;
        private string architectState;
        private string architectZip;
        private string architectContactName;
        private string architectContactEmail;
        private string architectContactPhone;
        private string architectContactFax;
        private string engineerName;
        private string engineerAddress;
        private string engineerCity;
        private string engineerState;
        private string engineerZip;
        private string engineerContactName;
        private string engineerContactEmail;
        private string engineerContactPhone;
        private string engineerContactFax;
        private string submittedBy; 
	    private string submittedDate; 
	    private string approved; 
	    private string approvedBy;
        private string pApproved;
        private string pApprovedBy;
	    private string lastModifiedDate; 
	    private string lastModifiedBy;
        private string bidWalk;
        private string source;
        private string referenceNumber;
        private string statusDate;
        private string otProjectNameOld = "";
        private string nextActionTime;
        private string unitType;
        private string units;
        private string otProjectEstimate = "";
        //
        public string OTProjectID
        {
            get { return otProjectID; }
        }
        //
        public OTProject()
        {
        }
        //
        public OTProject(string otProjectID, 
	                    string otProjectNumber, 
	                    string otProjectStatusID,
	                    string workTypeID, 
	                    string officeID, 
	                    string departmentID,
                        string assignedTo,
                        string assignedToAccepted,
	                    string estimateNumber,
	                    string rush, 
	                    string otProjectName, 
	                    string otProjectAddress, 
	                    string otProjectCity, 
	                    string otProjectState, 
	                    string otProjectZip, 
	                    string bidBondRequired, 
	                    string ppbRequired, 
	                    string bidDate, 
	                    string bidTime, 
	                    string bidWalkDate, 
	                    string bidWalkTime, 
	                    string cceRepForBidWalk,
	                    string biddingAsPrime, 
	                    string biddingAsSub,  
	                    string nextActionNeeded,  
	                    string nextActionDate,
                        string nextActionDateAuto,
                        string prequalDate,
	                    string bidToOwner,  
	                    string bidToContractor, 
	                    string bidToDeveloper,
	                    string bidToOther,
                        string bidToOtherDescription,
	                    string description,
	                    string projectTotalDollar,				
	                    string electricalDollar,
	                    string forwardForApproval,
	                    string engineered, 
	                    string leed, 
	                    string designBuild,
	                    string designAssist, 
	                    string pla, 
	                    string prevailingWage, 
	                    string budgetOnly, 
	                    string bid, 
	                    string negotiated,
	                    string other, 
	                    string financeInPlace, 
	                    string minorityRequirements,		
                        string minorityType,
	                    string prequalRequired, 
	                    string drawingAvailable,
	                    string opportunityValue,			 
	                    string note, 
	                    string website,  
	                    string ownerName, 
	                    string ownerAddress, 
	                    string ownerCity, 
	                    string ownerState, 
	                    string ownerZip, 
	                    string ownerContactName, 
	                    string ownerContactEmail, 
	                    string ownerContactPhone, 
	                    string ownerContactFax, 
	                    string generalContractorName, 
	                    string generalContractorAddress, 
	                    string generalContractorCity, 
	                    string generalContractorState,			 
	                    string generalContractorZip, 
	                    string generalContractorContactName, 
	                    string generalContractorContactEmail, 
	                    string generalContractorContactPhone,	 
	                    string generalContractorContactFax, 
	                    string developerName, 
	                    string developerAddress, 
	                    string developerCity, 
	                    string developerState,			 
	                    string developerZip, 
	                    string developerContactName, 
	                    string developerContactEmail, 
	                    string developerContactPhone,	 
	                    string developerContactFax, 
                        string architectName, 
	                    string architectAddress, 
	                    string architectCity, 
	                    string architectState,			 
	                    string architectZip, 
	                    string architectContactName, 
	                    string architectContactEmail, 
	                    string architectContactPhone,	 
	                    string architectContactFax, 
                        string engineerName, 
	                    string engineerAddress, 
	                    string engineerCity, 
	                    string engineerState,			 
	                    string engineerZip, 
	                    string engineerContactName, 
	                    string engineerContactEmail, 
	                    string engineerContactPhone,	 
	                    string engineerContactFax, 
	                    string submittedBy, 
	                    string submittedDate, 
	                    string approved, 
	                    string approvedBy, 
                        string pApproved,
                        string pApprovedBy,
	                    string lastModifiedDate, 
	                    string lastModifiedBy,
                        string bidWalk,
                        string source,
                        string referenceNumber,
                        string statusDate,
                        string nextActionTime,
                        string unitType,
                        string units)				
        {
            this.otProjectID                = otProjectID;
	        this.otProjectNumber            = String.IsNullOrEmpty(otProjectNumber) ? "" : otProjectNumber; 
	        this.otProjectStatusID          = String.IsNullOrEmpty(otProjectStatusID) ? "null" : otProjectStatusID;
	        this.workTypeID                 = String.IsNullOrEmpty(workTypeID) ? "null" : workTypeID;
	        this.officeID                   = String.IsNullOrEmpty(officeID) ? "null" : officeID;
	        this.departmentID               = String.IsNullOrEmpty(departmentID) ? "null" : departmentID;
            this.assignedTo                 = String.IsNullOrEmpty(assignedTo) ? "" : assignedTo.Trim().Replace("'", "''");
            this.assignedToAccepted         = assignedToAccepted == "True" ? "1" : "0";
            this.estimateNumber             = String .IsNullOrEmpty(estimateNumber) ? "" : estimateNumber;
            this.rush                       = rush == "True" ? "1" : "0";
	        this.otProjectName              = String.IsNullOrEmpty(otProjectName) ? "" : otProjectName.Trim().Replace("'", "''");
	        this.otProjectAddress           = String.IsNullOrEmpty(otProjectAddress) ? "" : otProjectAddress.Trim().Replace("'","''");
	        this.otProjectCity              = String.IsNullOrEmpty(otProjectCity) ? "" : otProjectCity.Trim().Replace("'","''");
	        this.otProjectState             = String.IsNullOrEmpty(otProjectState) ? "" : otProjectState.Trim().Replace("'","''");
	        this.otProjectZip               = String.IsNullOrEmpty(otProjectZip) ? "" : otProjectZip.Trim().Replace("'", "''"); 
            this.bidBondRequired            = bidBondRequired == "True" ? "1" : "0";
	        this.ppbRequired                = ppbRequired == "True" ? "1" : "0";
	        this.bidDate                    = String.IsNullOrEmpty(bidDate) ? "Null" : "'" + bidDate + "'";
	        this.bidTime                    = String.IsNullOrEmpty(bidTime) ? "" : bidTime.Trim().Replace("'","''");
	        this.bidWalkDate                = String.IsNullOrEmpty(bidWalkDate) ? "Null" : "'" + bidWalkDate + "'";
	        this.bidWalkTime                = String.IsNullOrEmpty(bidWalkTime) ? "" : bidWalkTime.Trim().Replace("'","''");
	        this.cceRepForBidWalk           = String.IsNullOrEmpty(cceRepForBidWalk) ? "" : cceRepForBidWalk.Trim().Replace("'", "''");
	        this.biddingAsPrime             = biddingAsPrime == "True" ? "1" : "0";
	        this.biddingAsSub               = biddingAsSub == "True" ? "1" : "0";
	        this.nextActionNeeded           = String.IsNullOrEmpty(nextActionNeeded) ? "" : nextActionNeeded.Trim().Replace("'","''"); 
	        this.nextActionDate             = String.IsNullOrEmpty(nextActionDate) ? "null" : "'" + nextActionDate + "'";
            this.nextActionDateAuto         = String.IsNullOrEmpty(nextActionDateAuto) ? "null" : "'" + nextActionDateAuto + "'";
            this.prequalDate                = String.IsNullOrEmpty(prequalDate) ? "null" : "'" + prequalDate + "'";
            this.bidToOwner                 = bidToOwner == "True" ? "1" : "0";  
	        this.bidToContractor            = bidToContractor == "True" ? "1" : "0";
	        this.bidToDeveloper             = bidToDeveloper == "True" ? "1" : "0";
	        this.bidToOther                 = bidToOther == "True" ? "1" : "0";
            this.bidToOtherDescription      = String.IsNullOrEmpty(bidToOtherDescription) ? "" : bidToOtherDescription.Trim().Replace("'", "''");
	        this.description                = String.IsNullOrEmpty(description) ? "" : description.Trim().Replace("'", "''");
            this.projectTotalDollar         = String.IsNullOrEmpty(projectTotalDollar) ? "null" : projectTotalDollar.Replace(",", "").Replace("(", "-").Replace(")", "").Replace("$", "");
            this.electricalDollar           = String.IsNullOrEmpty(electricalDollar) ? "null" : electricalDollar.Replace(",", "").Replace("(", "-").Replace(")", "").Replace("$", "");
            this.forwardForApproval         = forwardForApproval == "True" ? "1" : "0";
	        this.engineered                 = engineered == "True" ? "1" : "0";
	        this.leed                       = leed == "True" ? "1" : "0";
	        this.designBuild                = designBuild == "True" ? "1" : "0";
	        this.designAssist               = designAssist == "True" ? "1" : "0";
	        this.pla                        = pla == "True" ? "1" : "0";
	        this.prevailingWage             = prevailingWage == "True" ? "1" : "0"; 
	        this.budgetOnly                 = budgetOnly == "True" ? "1" : "0";
	        this.bid                        = bid == "True" ? "1" : "0"; 
	        this.negotiated                 = negotiated == "True" ? "1" : "0";
            this.other                      = String.IsNullOrEmpty(other) ? "" : other.Trim().Replace("'", "''");  
	        this.financeInPlace             = String.IsNullOrEmpty(financeInPlace) ? "" : financeInPlace.Trim().Replace("'","''");  
	        this.minorityRequirements       = minorityRequirements == "True" ? "1" : "0";		
            this.minorityType               = String.IsNullOrEmpty(minorityType) ? "" : minorityType.Trim().Replace("'","''");
            this.prequalRequired            = String.IsNullOrEmpty(prequalRequired) ? "" : prequalRequired.Trim().Replace("'", "''"); 
	        this.drawingAvailable           = drawingAvailable == "True" ? "1" : "0";         
            this.opportunityValue           = String.IsNullOrEmpty(opportunityValue) ? "null" : opportunityValue.Trim().Replace("'","''");			     
            this.note                       = String.IsNullOrEmpty(note) ? "" : note.Trim().Replace("'","''"); 
	        this.website                    = String.IsNullOrEmpty(website) ? "" : website.Trim().Replace("'","''");  
	        this.ownerName                  = String.IsNullOrEmpty(ownerName) ? "" : ownerName.Trim().Replace("'", "''");
	        this.ownerAddress               = String.IsNullOrEmpty(ownerAddress) ? "" : ownerAddress.Trim().Replace("'","''");
	        this.ownerCity                  = String.IsNullOrEmpty(ownerCity) ? "" : ownerCity.Trim().Replace("'","''");
	        this.ownerState                 = String.IsNullOrEmpty(ownerState) ? "" : ownerState.Trim().Replace("'","''"); 
	        this.ownerZip                   = String.IsNullOrEmpty(ownerZip) ? "" : ownerZip.Trim().Replace("'","''"); 
	        this.ownerContactName           = String.IsNullOrEmpty(ownerContactName) ? "" : ownerContactName.Trim().Replace("'","''");
	        this.ownerContactEmail          = String.IsNullOrEmpty(ownerContactEmail) ? "" : ownerContactEmail.Trim().Replace("'", "''"); 
	        this.ownerContactPhone          = String.IsNullOrEmpty(ownerContactPhone) ? "" : ownerContactPhone.Trim().Replace("'","''");
	        this.ownerContactFax            = String.IsNullOrEmpty(ownerContactFax) ? "" : ownerContactFax.Trim().Replace("'","''");
            this.generalContractorName      = String.IsNullOrEmpty(generalContractorName) ? "" : generalContractorName.Trim().Replace("'", "''"); 
	        this.generalContractorAddress   = String.IsNullOrEmpty(generalContractorAddress) ? "" : generalContractorAddress.Trim().Replace("'", "''"); 
	        this.generalContractorCity      = String.IsNullOrEmpty(generalContractorCity) ? "" : generalContractorCity.Trim().Replace("'", "''");
	        this.generalContractorState     = String.IsNullOrEmpty(generalContractorState) ? "" : generalContractorState.Trim().Replace("'", "''");			 
	        this.generalContractorZip       = String.IsNullOrEmpty(generalContractorZip) ? "" : generalContractorZip.Trim().Replace("'", "''");
	        this.generalContractorContactName = String.IsNullOrEmpty(generalContractorContactName) ? "" : generalContractorContactName.Trim().Replace("'", "''");
	        this.generalContractorContactEmail = String.IsNullOrEmpty(generalContractorContactEmail) ? "" : generalContractorContactEmail.Trim().Replace("'", "''");
	        this.generalContractorContactPhone = String.IsNullOrEmpty(generalContractorContactPhone) ? "" : generalContractorContactPhone.Trim().Replace("'", "''"); 
	        this.generalContractorContactFax = String.IsNullOrEmpty(generalContractorContactFax) ? "" : generalContractorContactFax.Trim().Replace("'", "''");
	        this.developerName                  = String.IsNullOrEmpty(developerName) ? "" : developerName.Trim().Replace("'", "''");
	        this.developerAddress               = String.IsNullOrEmpty(developerAddress) ? "" : developerAddress.Trim().Replace("'","''");
	        this.developerCity                  = String.IsNullOrEmpty(developerCity) ? "" : developerCity.Trim().Replace("'","''");
	        this.developerState                 = String.IsNullOrEmpty(developerState) ? "" : developerState.Trim().Replace("'","''"); 
	        this.developerZip                   = String.IsNullOrEmpty(developerZip) ? "" : developerZip.Trim().Replace("'","''"); 
	        this.developerContactName           = String.IsNullOrEmpty(developerContactName) ? "" : developerContactName.Trim().Replace("'","''");
	        this.developerContactEmail          = String.IsNullOrEmpty(developerContactEmail) ? "" : developerContactEmail.Trim().Replace("'", "''"); 
	        this.developerContactPhone          = String.IsNullOrEmpty(developerContactPhone) ? "" : developerContactPhone.Trim().Replace("'","''");
	        this.developerContactFax            = String.IsNullOrEmpty(developerContactFax) ? "" : developerContactFax.Trim().Replace("'","''"); 
	        this.architectName                  = String.IsNullOrEmpty(architectName) ? "" : architectName.Trim().Replace("'", "''");
	        this.architectAddress               = String.IsNullOrEmpty(architectAddress) ? "" : architectAddress.Trim().Replace("'","''");
	        this.architectCity                  = String.IsNullOrEmpty(architectCity) ? "" : architectCity.Trim().Replace("'","''");
	        this.architectState                 = String.IsNullOrEmpty(architectState) ? "" : architectState.Trim().Replace("'","''"); 
	        this.architectZip                   = String.IsNullOrEmpty(architectZip) ? "" : architectZip.Trim().Replace("'","''"); 
	        this.architectContactName           = String.IsNullOrEmpty(architectContactName) ? "" : architectContactName.Trim().Replace("'","''");
	        this.architectContactEmail          = String.IsNullOrEmpty(architectContactEmail) ? "" : architectContactEmail.Trim().Replace("'", "''"); 
	        this.architectContactPhone          = String.IsNullOrEmpty(architectContactPhone) ? "" : architectContactPhone.Trim().Replace("'","''");
	        this.architectContactFax            = String.IsNullOrEmpty(architectContactFax) ? "" : architectContactFax.Trim().Replace("'","''"); 
            this.engineerName                   = String.IsNullOrEmpty(engineerName) ? "" : engineerName.Trim().Replace("'", "''");
	        this.engineerAddress                = String.IsNullOrEmpty(engineerAddress) ? "" : engineerAddress.Trim().Replace("'","''");
	        this.engineerCity                   = String.IsNullOrEmpty(engineerCity) ? "" : engineerCity.Trim().Replace("'","''");
	        this.engineerState                  = String.IsNullOrEmpty(engineerState) ? "" : engineerState.Trim().Replace("'","''"); 
	        this.engineerZip                    = String.IsNullOrEmpty(engineerZip) ? "" : engineerZip.Trim().Replace("'","''"); 
	        this.engineerContactName            = String.IsNullOrEmpty(engineerContactName) ? "" : engineerContactName.Trim().Replace("'","''");
	        this.engineerContactEmail           = String.IsNullOrEmpty(engineerContactEmail) ? "" : engineerContactEmail.Trim().Replace("'", "''"); 
	        this.engineerContactPhone           = String.IsNullOrEmpty(engineerContactPhone) ? "" : engineerContactPhone.Trim().Replace("'","''");
	        this.engineerContactFax             = String.IsNullOrEmpty(engineerContactFax) ? "" : engineerContactFax.Trim().Replace("'","''");  
            this.submittedBy                    = String.IsNullOrEmpty(submittedBy) ? "" : submittedBy.Trim().Replace("'", "''"); 
	        this.submittedDate                  = String.IsNullOrEmpty(submittedDate) ? "null" : "'" + submittedDate + "'"; 
	        this.approved                       = approved == "True" ? "1" : "0"; 
	        this.approvedBy                     = String.IsNullOrEmpty(approvedBy) ? "" : approvedBy.Trim().Replace("'", "''");
            this.pApproved                      = pApproved == "True" ? "1" : "0";
            this.pApprovedBy                    = String.IsNullOrEmpty(pApprovedBy) ? "" : pApprovedBy.Trim().Replace("'", "''"); 	        
            this.lastModifiedDate               = String.IsNullOrEmpty(lastModifiedDate) ? "null" : "'" + lastModifiedDate + "'";
            this.lastModifiedBy                 = String.IsNullOrEmpty(lastModifiedBy) ? "" : lastModifiedBy.Trim().Replace("'", "''");
            this.bidWalk                        = String.IsNullOrEmpty(bidWalk) ? "" : bidWalk.Trim().Replace("'", "''");
            this.source                         = String.IsNullOrEmpty(source) ? "" : source.Trim().Replace("'", "''");
            this.referenceNumber                = String.IsNullOrEmpty(referenceNumber) ? "" : referenceNumber.Trim().Replace("'", "''");
            this.statusDate                     = String.IsNullOrEmpty(statusDate) ? "null" : "'" + statusDate + "'";
            this.nextActionTime                 = String.IsNullOrEmpty(nextActionTime) ? "" : nextActionTime.Trim().Replace("'", "''");
            this.unitType                       = String.IsNullOrEmpty(unitType) ? "" : unitType.Trim().Replace("'", "''");
            this.units                          = String.IsNullOrEmpty(units) ? "null" : units.Trim().Replace(",", "");


        }
        //
        public static DataSet GetProjectAndEstimateNumber(string otProjectID)
        {
            string query = " SELECT OTProjectNumber, EstimateNumber, NextActionDateAuto, UserName AS  SubmittedBy, SubmittedDate, ApprovedBy, PApprovedBy, " +
                            " [dbo].[GetUserProjectOpportunityApproval](j.OTProjectID,'" + Security.Security.LoginID.ToUpper() + "')  ProjectApproval, " +
                            " [dbo].[GetUserProjectOpportunityApproval5Million](j.OTProjectID,'" + Security.Security.LoginID.ToUpper() + "')  ProjectApproval5Million " +  
                            " FROM tblOTProject j " +
                            " LEFT JOIN tblUser u ON j.SubmittedBy = u.UserLANID " +
                            " WHERE otProjectID = " + otProjectID + "";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetProjectInfo(string otProjectID)
        {
            string query = " SELECT OTProjectNumber, OTProjectName FROM tblOTProject WHERE otProjectID = " + otProjectID + "";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static string GetServerName()
        {
            DataSet ds;
            string serverName = "";
            string query = "";

            try
            {
                query = "SELECT  ServerName AS [ServerName] from tblOffice WHERE LTRIM(RTRIM(OfficeName)) = 'Dynalectric Company'";
                ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                    serverName = ds.Tables[0].Rows[0]["ServerName"].ToString();
                return serverName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetApproval(string projectID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@OTProjectID", projectID);

            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_OTGetUsersForApproval", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetChangesNotification(string projectID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@OTProjectID", projectID);

            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_OTGetUsersForChangeNotification", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
        //
        public static DataSet GetEstimateOpportunityTrackingReport(string opportunityQuery, string estimateQuery)
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@OpportunityQuery", opportunityQuery);
            par[1] = new SqlParameter("@EstimateQuery", estimateQuery);

            try
            {
                return DataBaseUtil.ExecuteParDataset("up_OTEstimateOpportunityReport", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static DataSet GetEstimateOpportunityHoursTrackingReport(string opportunityQuery)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@OpportunityQuery", opportunityQuery);

            try
            {
                return DataBaseUtil.ExecuteParDataset("up_OTEstimateOpportunityHoursReport", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetOpportunityEstimateJobReport(string query)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Query", query);

            try
            {
                return DataBaseUtil.ExecuteParDataset("up_OTOpportunityEstimateJobAnalysisReport", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static DataSet GetCCNotification(string projectID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@OTProjectID", projectID);

            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_OTGetUsersForCCNotification", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static DataSet GetApprovalOverFiveMillion(string projectID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@OTProjectID", projectID);

            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_OTGetUsersForApprovalOver5Million", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetAnalysisReport(string where)
        {
            string query =
                " SELECT  " +
                " o.OfficeName AS Office, " +
                " DepartmentName AS Department, " +
                " w.Description AS WorkType, " +
                " COUNT(OTProjectID)  AS Opportunity, " +
                " SUM(dbo.GetEstimateCount(OTProjectID)) AS Estimates,	" +
                " SUM(dbo.GetJobCount(EstimateNumber)) AS Jobs, " +
                " CAST(SUM(dbo.GetEstimateCount(OTProjectID)) AS FLOAT) / " +
                " CAST(COUNT(OTProjectID) AS FLOAT)  AS [Estimate/Apportunity], " +
                " [Job/Opportunity] = " +
                " CASE CAST(COUNT(OTProjectID) AS FLOAT) " +
                " WHEN 0 THEN 0 " +
                " ELSE " +
                " CAST(SUM(dbo.GetJobCount(EstimateNumber)) AS FLOAT) / " +
                " CAST(COUNT(OTProjectID) AS FLOAT) " +
                " END, " +
                " [Job/Estimate] = " +
                " CASE CAST(SUM(dbo.GetEstimateCount(OTProjectID)) AS FLOAT) " +
                " WHEN 0 THEN	0 " +
                " ELSE " +
                " CAST(SUM(dbo.GetJobCount(EstimateNumber)) AS FLOAT) /	" +
                " CAST(SUM(dbo.GetEstimateCount(OTProjectID)) AS FLOAT) " +
                " END " +
                " FROM tblOTProject p " +
                " LEFT JOIN tblOffice o ON p.OfficeID = o.OfficeID " +
                " LEFT JOIN tblOTStatus s ON p.OTProjectStatusID = s.OTStatusID " +
                " LEFT JOIN tblDepartment d ON p.DepartmentID = d.DepartmentID " +
                " LEFT JOIN tblWorkType w ON p.WorktypeID = w.WorktypeID " +
                " " + where + " " +
                " GROUP BY  OfficeName, DepartmentName, w.Description, p.OfficeID, p.DepartmentID, p.WorkTypeID ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetOTProject(string otProjectID)
        {
            string query = " SELECT j.*, u.UserName AS SubmittedByName, " +
                            " 	JobNumber =   " +            
		                    "       Case LTRIM(RTRIM(j.EstimateNumber)) " +
			                "           WHEN null THEN '' " +
			                "           WHEN ''  THEN '' " +
			                "       ELSE  (SELECT JobNumber FROM tblJob WHERE EstimateNumber = j.EstimateNumber) " +
		                    " END, " +
                            " [dbo].[GetUserProjectOpportunityApproval](j.OTProjectID,'" + Security.Security.LoginID.ToUpper() + "')  ProjectApproval, " +
                            " [dbo].[GetUserProjectOpportunityApproval5Million](j.OTProjectID,'" + Security.Security.LoginID.ToUpper() + "')  ProjectApproval5Million, " +
                            " [dbo].[GetAssignmentsToMe] (j.OTProjectID, '" + Security.Security.LoginID.ToUpper() + "') AssignmentNumberToMe,  " +
                            " [dbo].[GetAssignmentsByMe] (j.OTProjectID, '" + Security.Security.LoginID.ToUpper() + "') AssignmentNumberByMe  " +

                            " FROM tblOTProject j " +
                            " LEFT JOIN tblUser u ON j.SubmittedBy = u.UserLANID " +
                            " WHERE otProjectID = " + otProjectID + "";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetProjectSheetReport(string otProjectID)
        {
            string query =  " SELECT " +
                            " u.UserName AS SubmittedByName, " +
                           // " uu.UserName AS  AssignedToName, " +
	                        " s.OTStatusDescription, " +
	                        " w.Description AS [WorkType], " +
	                        " OfficeName, " +
	                        " DepartmentName, " +
	                        " p.* " +
                            " FROM tblOTProject p " +
                            " LEFT JOIN tblOTStatus s ON p.OTProjectStatusID = s.OTStatusID " +
                            " LEFT JOIN tblWorkType w ON p.WorkTypeID = w.WorkTypeID " +
                            " LEFT JOIN tblOffice o ON p.OfficeID = o.OfficeID " +
                            " LEFT JOIN tblDepartment d ON p.DepartmentID = d.DepartmentID " +
                            " LEFT JOIN tblUser u ON p.SubmittedBy = u.UserLANID " +
                           // " LEFT JOIN tblUser uu ON p.AssignedTo = uu.UserLANID " +
                    " WHERE otProjectID = " + otProjectID + "";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetProjectList(string where)
        {
            string query = " SELECT OTProjectID, " +
                            " OTProjectNumber		AS [Project #], " +
                            " OTProjectName			AS [Project Name], " +
                            " OTProjectAddress		AS [Address], " +
                            " OTProjectCity			AS [City], " +
                            " OTProjectState		AS [State], " +
                            " OTProjectZip			AS [Zip], " +
                            " p.OwnerName             As [Owner], " +
                            " p.Description, " +
                            " GeneralContractorName AS [General Contractor], " +
                            " ForwardForApproval    As [Forward for App], " +
                            " Approved              AS [DM Approved], " +
                            " PApproved             AS [CEO Approved], " + 
                            " p.BidDate				AS [Bid Date], " +
                            " p.BidTime             AS [Bid Time], " +
                            " NextActionDateAuto    AS [Next Action Date], " +
                            " PrequalDate           AS [Prequal Due Date], " +
                            " PrequalRequired       AS [Prequal Required], " +
                            " p.EstimateNumber		AS [Estimate #], " +
                            " [Job #] =                           " +
		                    " Case LTRIM(RTRIM(p.EstimateNumber)) " +
			                "   WHEN null THEN '' " +
			                "   WHEN ''  THEN ''   " +
			                " ELSE  (SELECT JobNumber FROM tblJob WHERE EstimateNumber = p.EstimateNumber) " +
		                    " END, " +
                            " OTStatusDescription	AS [Status], " +
                            " StatusDate            AS [Status Date], " +
                            " w.Description			AS [Work Type], " +
                            " o.OfficeName			As [Office], " +
                            " d.DepartmentName		AS [Department], " +
                            //" u.UserName            AS [Assigned To], " +
                            " ProjectTotalDollar    AS [Project $], " +
                            " ElectricalDollar      AS [Electrical $], " +
                            " [dbo].[GetAssignmentsToMe] (p.OTProjectID, '" + Security.Security.LoginID.ToUpper() + "')  [Assign. To Me], " +
                            " [dbo].[GetAssignmentsByMe] (p.OTProjectID, '" + Security.Security.LoginID.ToUpper() + "')  [Assign. By Me], " +
                            " [dbo].[GetAssignments] (p.OTProjectID)  [Assign.] " +
                            " FROM tblOTProject p " +
                            " LEFT JOIN tblOTStatus s ON p.OTProjectStatusID = s.OTStatusID " +
                            " LEFT JOIN tblWorkType w ON p.WorkTypeID = w.WorkTypeID " +
                            " LEFT JOIN tblOffice o ON p.OfficeID = o.OfficeID " +
                           // " LEFT JOIN tblUser u ON p.AssignedTo = u.UserLanID " +
                            " LEFT JOIN tblDepartment d ON p.DepartmentID = d.DepartmentID " + where + "  ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            DataTable dt;
            string query = "";
            bool ret;

            try
            {
                if (String.IsNullOrEmpty(otProjectID))
                    otProjectID = "0";
                if (otProjectID == "0")
                {
                    otProjectNameOld = "";
                    ret = Insert();
                }
                else
                {
                    query = "SELECT otProjectName FROM tblOTProject WHERE OTProjectID = " + otProjectID + " ";
                    dt = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                        otProjectNameOld = dt.Rows[0]["OTProjectName"].ToString();
                    ret = Update();
                }
                if (otProjectNumber.Trim().Length == 0)
                {
                    query = "SELECT otProjectNumber FROM tblOTProject WHERE OTProjectID = " + otProjectID + " ";
                    dt = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                        otProjectNumber = dt.Rows[0]["OTProjectNumber"].ToString();

                }
                CreateProjectFolder();
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool Insert()
        {
            string query = "INSERT INTO tblOTProject( " +
                    " OTProjectNumber," + 
                    " OTProjectStatusID, " + 
                    " WorkTypeID, " + 
                    " OfficeID, " + 
                    " DepartmentID, " + 
                    " AssignedTo, " +
                    " AssignedToAccepted, " +
                    " EstimateNumber, " + 
                    " Rush, " + 
                    " OTProjectName, " + 
                    " OTProjectAddress, " + 
                    " OTProjectCity, " + 
                    " OTProjectState, " + 
                    " OTProjectZip, " + 
                    " BidBondRequired, " + 
                    " PPBRequired, " + 
                    " BidDate, " + 
                    " BidTime, " + 
                    " BidWalkDate, " + 
                    " BidWalkTime, " + 
                    " CCERepForBidWalk, " + 
                    " BiddingAsPrime, " + 
                    " BiddingAsSub, " + 
                    " NextActionNeeded, " + 
                    " NextActionDate, " + 
                    " NextActionDateAuto, " +
                    " PrequalDate, " +
                    " BidToOwner, " + 
                    " BidToContractor, " + 
                    " BidToDeveloper, " + 
                    " BidToOther, " +
                    " BidToOtherDescription, " +
                    " Description, " + 
                    " ProjectTotalDollar, " + 
                    " ElectricalDollar, " + 
                    " ForwardForApproval, " + 
                    " Engineered, " + 
                    " LEED, " + 
                    " DesignBuild, " + 
                    " DesignAssist, " + 
                    " PLA, " + 
                    " PrevailingWage, " + 
                    " BudgetOnly, " + 
                    " Bid, " + 
                    " Negotiated, " + 
                    " Other, " + 
                    " FinanceInPlace, " + 
                    " MinorityRequirements, " + 
                    " MinorityType, " + 
                    " PrequalRequired, " + 
                    " DrawingAvailable, " + 
                    " OpportunityValue, " + 
                    " Note, " + 
                    " Website, " + 
                    " OwnerName, " + 
                    " OwnerAddress, " + 
                    " OwnerCity, " + 
                    " OwnerState, " + 
                    " OwnerZip, " + 
                    " OwnerContactName, " + 
                    " OwnerContactEmail, " + 
                    " OwnerContactPhone, " + 
                    " OwnerContactFax, " + 
                    " GeneralContractorName, " + 
                    " GeneralContractorAddress, " + 
                    " GeneralContractorCity, " + 
                    " GeneralContractorState, " + 
                    " GeneralContractorZip, " + 
                    " GeneralContractorContactName, " + 
                    " GeneralContractorContactEmail, " + 
                    " GeneralContractorContactPhone, " + 
                    " GeneralContractorContactFax, " + 
                    " DeveloperName, " + 
                    " DeveloperAddress, " + 
                    " DeveloperCity, " + 
                    " DeveloperState, " + 
                    " DeveloperZip, " + 
                    " DeveloperContactName, " + 
                    " DeveloperContactEmail, " + 
                    " DeveloperContactPhone, " + 
                    " DeveloperContactFax, " + 
                    " ArchitectName, " + 
                    " ArchitectAddress, " + 
                    " ArchitectCity, " + 
                    " ArchitectState, " + 
                    " ArchitectZip, " + 
                    " ArchitectContactName, " + 
                    " ArchitectContactEmail, " + 
                    " ArchitectContactPhone, " + 
                    " ArchitectContactFax, " + 
                    " EngineerName, " + 
                    " EngineerAddress, " + 
                    " EngineerCity, " + 
                    " EngineerState, " + 
                    " EngineerZip, " + 
                    " EngineerContactName, " + 
                    " EngineerContactEmail, " + 
                    " EngineerContactPhone, " + 
                    " EngineerContactFax, " + 
                   // " SubmittedBy, " + 
                   // " SubmittedDate, " + 
                    " Approved, " + 
                    " ApprovedBy, " + 
                    " PApproved, " +
                    " PApprovedBy, " +
                    " LastModifiedDate, " + 
                    " StatusDate, " +
                    " LastModifiedBy, " + 
                    " BidWalk, " + 
                    " Source, " + 
                    " ReferenceNumber, " +
                    " NextActionTime, " +
                    " UnitType, " +
                    " Units)" +  		
            
            " Values(" +
                    "'" + otProjectNumber + "', " +
                    " " + otProjectStatusID + ", " +
                    " " + workTypeID + ", " +
                    " " + officeID + ", " +
                    " " + departmentID + ", " +
                    " '" + assignedTo + "', " +
                    " " + assignedToAccepted + ", " +
                    "'" + estimateNumber + "', " +
                    " " + rush + ", " +
                    "'" + otProjectName + "', " +
                    "'" + otProjectAddress + "', " +
                    "'" + otProjectCity + "', " +
                    "'" + otProjectState + "', " +
                    "'" + otProjectZip + "', " +
                    " " + bidBondRequired + ", " +
                    " " + ppbRequired + ", " +
                    " " + bidDate + ", " +
                    "'" + bidTime + "', " +
                    " " + bidWalkDate + ", " +
                    "'" + bidWalkTime + "', " +
                    "'" + cceRepForBidWalk + "', " +
                    " " + biddingAsPrime + ", " +
                    " " + biddingAsSub + ", " +
                    "'" + nextActionNeeded + "', " +
                    " " + nextActionDate + ", " +
                    " " + nextActionDateAuto + ", " +
                    " " + prequalDate + ", " +
                    " " + bidToOwner + ", " +
                    " " + bidToContractor + ", " +
                    " " + bidToDeveloper + ", " +
                    " " + bidToOther + ", " +
                    "'" + bidToOtherDescription + "', " +
                    "'" + description + "', " +
                    " " + projectTotalDollar + ", " +
                    " " + electricalDollar + ", " +
                    " " + forwardForApproval + ", " +
                    " " + engineered + ", " +
                    " " + leed + ", " +
                    " " + designBuild + ", " +
                    " " + designAssist + ", " +
                    " " + pla + ", " +
                    " " + prevailingWage + ", " +
                    " " + budgetOnly + ", " +
                    " " + bid + ", " +
                    " " + negotiated + ", " +
                    " '" + other + "', " +
                    "'" + financeInPlace + "', " +
                    " " + minorityRequirements + ", " +
                    "'" + minorityType + "', " +
                    " '" + prequalRequired + "', " +
                    " " + drawingAvailable + ", " +
                    " " + opportunityValue + ", " +
                    "'" + note + "', " +
                    "'" + website + "', " +
                    "'" + ownerName + "', " +
                    "'" + ownerAddress + "', " +
                    "'" + ownerCity + "', " +
                    "'" + ownerState + "', " +
                    "'" + ownerZip + "', " +
                    "'" + ownerContactName + "', " +
                    "'" + ownerContactEmail + "', " +
                    "'" + ownerContactPhone + "', " +
                    "'" + ownerContactFax + "', " +
                    "'" + generalContractorName + "', " +
                    "'" + generalContractorAddress + "', " +
                    "'" + generalContractorCity + "', " +
                    "'" + generalContractorState + "', " +
                    "'" + generalContractorZip + "', " +
                    "'" + generalContractorContactName + "', " +
                    "'" + generalContractorContactEmail + "', " +
                    "'" + generalContractorContactPhone + "', " +
                    "'" + generalContractorContactFax + "', " +
                    "'" + developerName + "', " +
                    "'" + developerAddress + "', " +
                    "'" + developerCity + "', " +
                    "'" + developerState + "', " +
                    "'" + developerZip + "', " +
                    "'" + developerContactName + "', " +
                    "'" + developerContactEmail + "', " +
                    "'" + developerContactPhone + "', " +
                    "'" + developerContactFax + "', " +
                    "'" + architectName + "', " +
                    "'" + architectAddress + "', " +
                    "'" + architectCity + "', " +
                    "'" + architectState + "', " +
                    "'" + architectZip + "', " +
                    "'" + architectContactName + "', " +
                    "'" + architectContactEmail + "', " +
                    "'" + architectContactPhone + "', " +
                    "'" + architectContactFax + "', " +
                    "'" + engineerName + "', " +
                    "'" + engineerAddress + "', " +
                    "'" + engineerCity + "', " +
                    "'" + engineerState + "', " +
                    "'" + engineerZip + "', " +
                    "'" + engineerContactName + "', " +
                    "'" + engineerContactEmail + "', " +
                    "'" + engineerContactPhone + "', " +
                    "'" + engineerContactFax + "', " +
                   // "'" + submittedBy + "', " +
                   // " " + submittedDate + ", " +
                    " " + approved + ", " +
                    "'" + approvedBy + "', " +
                    " " + pApproved + ", " +
                    "'" + pApprovedBy + "', " +
                    " " + lastModifiedDate + ", " +
                    " " + statusDate + ", " +
                    "'" + lastModifiedBy + "', " +
                    "'" + bidWalk + "', " +
                    "'" + source + "', " +
                    "'" + referenceNumber + "', " +
                    "'" + nextActionTime + "', " +
                    "'" + unitType + "', " +
                    "" + units + ") " + 		
            " Select @@IDENTITY ";
            try
            {
                otProjectID = DataBaseUtil.ExecuteScalar(query, Security.Security.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static bool Delete(string otProjectID)
        {
            string query = " DELETE FROM tblOTProject WHERE OTProjectID = " + otProjectID + " ";
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
        //
        private bool Update()
        {

            string queryForEstimateNumber = string.Empty;
       
                
            string query = " UPDATE tblOTProject  SET " +
                    " OTProjectNumber               = '" + otProjectNumber + "', " +
                    " OTProjectStatusID             = " + otProjectStatusID + ", " +
                    " WorkTypeID                    = " + workTypeID + ", " +
                    " OfficeID                      = " + officeID + ", " +
                    " DepartmentID                  = " + departmentID + ", " +
                    " AssignedTo                    = '" + assignedTo + "', " +
                    " AssignedToAccepted            = " + assignedToAccepted + ", " +
                    " EstimateNumber                = '" + estimateNumber + "', " +
                    " Rush                          = " + rush + ", " +
                    " OTProjectName                 = '" + otProjectName + "', " + 
                    " OTProjectAddress              = '" + otProjectAddress + "', " + 
                    " OTProjectCity                 = '" + otProjectCity + "', " +
                    " OTProjectState                = '" + otProjectState + "', " +
                    " OTProjectZip                  = '" + otProjectZip + "', " +
                    " BidBondRequired               = " + bidBondRequired + ", " + 
                    " PPBRequired                   = " + ppbRequired + ", " + 
                    " BidDate                       = " + bidDate + ", " + 
                    " BidTime                       = '" + bidTime + "', " + 
                    " BidWalkDate                   =  " + bidWalkDate + ", " + 
                    " BidWalkTime                  = '" + bidWalkTime + "', " +
                    " CCERepForBidWalk              = '" + cceRepForBidWalk + "', " + 
                    " BiddingAsPrime                = " + biddingAsPrime + ", " +
                    " BiddingAsSub                  = " + biddingAsSub + ", " + 
                    " NextActionNeeded              = '" + nextActionNeeded + "', " + 
                    " NextActionDate                = " + nextActionDate + ", " + 
                    " NextActionDateAuto            = " + nextActionDateAuto + ", " +
                    " PrequalDate                   = " + prequalDate + ", " +
                    " BidToOwner                    = " + bidToOwner + ", " + 
                    " BidToContractor               = " + bidToContractor + ", " +
                    " BidToDeveloper                = " + bidToDeveloper + ", " + 
                    " BidToOther                    = " + bidToOther + ", " + 
                    " BidToOtherDescription         = '" + bidToOtherDescription + "', " +
                    " Description                   = '" + description + "', " + 
                    " ProjectTotalDollar            = " + projectTotalDollar + ", " +
                    " ElectricalDollar              = " + electricalDollar + ", " + 
                    " ForwardForApproval            = " + forwardForApproval + ", " + 
                    " Engineered                    = " + engineered + ", " + 
                    " LEED                          = " + leed + ", " + 
                    " DesignBuild                   = " + designBuild + ", " + 
                    " DesignAssist                  = " + designAssist + ", " + 
                    " PLA                           = " + pla + ", " + 
                    " PrevailingWage                = " + prevailingWage + ", " + 
                    " BudgetOnly                    = " + budgetOnly + ", " + 
                    " Bid                           = " + bid + ", " + 
                    " Negotiated                    = " + negotiated + ", " + 
                    " Other                         = '" + other + "', " + 
                    " FinanceInPlace                = '" + financeInPlace + "', " +
                    " MinorityRequirements          = " + minorityRequirements + ", " +
                    " MinorityType                  = '" + minorityType + "', " + 
                    " PrequalRequired               = '" + prequalRequired + "', " + 
                    " DrawingAvailable              = " + drawingAvailable + ", " + 
                    " OpportunityValue               = " + opportunityValue + ", " +
                    " Note                          = '" + note + "', " +
                    " Website                       = '" + website + "', " + 
                    " OwnerName                     = '" + ownerName + "', " + 
                    " OwnerAddress                  = '" + ownerAddress + "', " + 
                    " OwnerCity                     = '" + ownerCity + "', " + 
                    " OwnerState                    = '" + ownerState + "', " + 
                    " OwnerZip                      = '" + ownerZip + "', " + 
                    " OwnerContactName              = '" + ownerContactName + "', " +
                    " OwnerContactEmail             = '" + ownerContactEmail + "', " +
                    " OwnerContactPhone             = '" + ownerContactPhone + "', " + 
                    " OwnerContactFax               = '" + ownerContactFax + "', " + 
                    " GeneralContractorName         = '" + generalContractorName + "', " + 
                    " GeneralContractorAddress      = '" + generalContractorAddress + "', " + 
                    " GeneralContractorCity         = '" + generalContractorCity + "', " + 
                    " GeneralContractorState        = '" + generalContractorState + "', " + 
                    " GeneralContractorZip          = '" + generalContractorZip + "', " + 
                    " GeneralContractorContactName  = '" + generalContractorContactName + "', " + 
                    " GeneralContractorContactEmail = '" + generalContractorContactEmail + "', " + 
                    " GeneralContractorContactPhone = '" + generalContractorContactPhone + "', " + 
                    " GeneralContractorContactFax   = '" + generalContractorContactFax + "', " + 
                    " DeveloperName                 = '" + developerName + "', " + 
                    " DeveloperAddress              = '" + developerAddress + "', " + 
                    " DeveloperCity                 = '" + developerCity + "', " + 
                    " DeveloperState                = '" + developerState + "', " + 
                    " DeveloperZip                  = '" + developerZip + "', " + 
                    " DeveloperContactName          = '" + developerContactName + "', " + 
                    " DeveloperContactEmail         = '" + developerContactEmail + "', " + 
                    " DeveloperContactPhone         = '" + developerContactPhone + "', " + 
                    " DeveloperContactFax           = '" + developerContactFax + "', " + 
                    " ArchitectName                 = '" + architectName + "', " + 
                    " ArchitectAddress              = '" + architectAddress + "', " + 
                    " ArchitectCity                 = '" + architectCity + "', " + 
                    " ArchitectState                = '" + architectState + "', " + 
                    " ArchitectZip                  = '" + architectZip + "', " + 
                    " ArchitectContactName          = '" + architectContactName + "', " + 
                    " ArchitectContactEmail         = '" + architectContactEmail + "', " + 
                    " ArchitectContactPhone         = '" + architectContactPhone + "', " + 
                    " ArchitectContactFax           = '" + architectContactFax + "', " + 
                    " EngineerName                  = '" + engineerName + "', " + 
                    " EngineerAddress               = '" + engineerAddress + "', " + 
                    " EngineerCity                  = '" + engineerCity + "', " + 
                    " EngineerState                 = '" + engineerState + "', " + 
                    " EngineerZip                   = '" + engineerZip + "', " + 
                    " EngineerContactName           = '" + engineerContactName + "', " + 
                    " EngineerContactEmail          = '" + engineerContactEmail + "', " + 
                    " EngineerContactPhone          = '" + engineerContactPhone + "', " + 
                    " EngineerContactFax            = '" + engineerContactFax + "', " + 
                   // " SubmittedBy                   = '" + submittedBy + "', " + 
                   // " SubmittedDate                 =  " + submittedDate + ", " + 
                    " Approved                      =  " + approved + ", " + 
                    " ApprovedBy                    = '" + approvedBy + "', " +
                    " PApproved                     =  " + pApproved + ", " +
                    " PApprovedBy                   = '" + pApprovedBy + "', " +                     
                    " LastModifiedDate              =  " + lastModifiedDate + ", " + 
                    " StatusDate                    =  " + statusDate + ", " +
                    " LastModifiedBy                = '" + lastModifiedBy + "', " +
 		            " BidWalk                       = '" + bidWalk + "', " +
                    " Source                        = '" + source + "', " +
                    " ReferenceNumber               = '" + referenceNumber + "', " +
                    " NextActionTime                = '" + nextActionTime + "', " +
                    " UnitType                      = '" + unitType + "', " +
                    " Units                         = " + units + " " +
                    " WHERE OTProjectID             = " + otProjectID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Security.Connection, CommandType.Text);
                //#region  update new job
                //queryForEstimateNumber = "SELECT EstimateNumber FROM tblOTProject WHERE otProjectID = " + otProjectID + " ";
                //DataTable dtEstimateNumver = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                //if (dtEstimateNumver.Rows.Count > 0)
                //    otProjectEstimate = dtEstimateNumver.Rows[0]["EstimateNumber"].ToString();

                //if (!string.IsNullOrEmpty(otProjectEstimate))
                //{
                //    string queryForupdateJob = "";

                //    queryForupdateJob = "UPDATE tblJob SET IsNewJob = 1 WHERE EstimateNumber = " + otProjectEstimate;
                //    DataBaseUtil.ExecuteNonQuery(queryForupdateJob, CCEApplication.Connection, CommandType.Text);
                //}
                //#endregion
                return true;
            }
           
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
        //
        private void CreateProjectFolder()
        {
            string serverName = GetServerName();
            string sourceProjectLocationOld = "";
            string sourceProjectLocation = "";
            DirectoryInfo dir;

            try
            {
                sourceProjectLocation =  CCEApplication.ProjectOpportunityLocation + "\\";

                dir = new DirectoryInfo(@sourceProjectLocation);
                if (!dir.Exists)
                    dir.Create();
                // 
                if (otProjectNameOld.Length > 0 && otProjectName != otProjectNameOld)
                {
                    sourceProjectLocationOld =  CCEApplication.ProjectOpportunityLocation +
                                                otProjectNumber + " " + otProjectNameOld + "\\";
                    sourceProjectLocation += otProjectNumber + " " + otProjectName + "\\";
                    if (FileSystem.DirectoryExists(@sourceProjectLocationOld))
                    {
                        FileSystem.CopyDirectory(@sourceProjectLocationOld, @sourceProjectLocation);
                        FileSystem.DeleteDirectory(@sourceProjectLocationOld, DeleteDirectoryOption.DeleteAllContents);
                    }
                    else
                    {
                        dir = new DirectoryInfo(@sourceProjectLocation);
                        if (!dir.Exists)
                            dir.Create();
                    }
                }
                else
                {
                    sourceProjectLocation += otProjectNumber + " " + otProjectName + "\\";
                    dir = new DirectoryInfo(@sourceProjectLocation);
                    if (!dir.Exists)
                        dir.Create();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }               
        }
    }
}
