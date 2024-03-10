using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class PreBidRFI
    {
        private string opportunityRFIID;			
        private string otProjectID;				
        private string opportunityRFINumber;
        private string opportunityRFINumberRev;
        private string RFIToContactID;		
        private string RFISubject;			
        private string RFIFromID;				
        private string RFIDate;				
        private string RFIText;				
        private string RFIGeneralNumber;	
        private string designDetailRequired;
        private string delayJob;			
        private string discussedOnPhoneWith;
        private string phoneDiscussionDate;	
        private string answeredNeededBy;	
        private string statusOpenClosed;	
        private string costImpactYesNo;		
        private string RFIResponse;			
        private string responseDate;
        private string responseBy;
        private string emailBody;
        private string rfivoid;
        private string toCompany;

        public string OpportunityRFIID
        {
            get { return opportunityRFIID; }
        }
        public string OpportunityRFINumber
        {
            get { return opportunityRFINumber; }
        }
        public string OpportunityRFINumberRev
        {
            get { return opportunityRFINumberRev; }
        }

        public PreBidRFI()
        {
        }
        public PreBidRFI ( string opportunityRFIID,			
                      string otProjectId,		
	                  string oppportunityRFINumber,
                      string oppportunityRFINumberRev,
                      string RFIToContactID,		
                      string RFISubject,			
                      string RFIFromID,				
                      string RFIDate,				
                      string RFIText,				
                      string RFIGeneralNumber,	
                      string designDetailRequired,
                      string discussedOnPhoneWith,
                      string phoneDiscussionDate,	
                      string answeredNeededBy,
                      string statusOpenClosed,	
                      string costImpactYesNo,		
                      string RFIResponse,			
                      string responseDate,
                      string responseBy,
                      string emailBody,
                      string rfivoid,
                      string toCompany)		
        {
            this.opportunityRFIID =  opportunityRFIID;               		
            this.otProjectID		                =  String.IsNullOrEmpty(otProjectId) ? "Null" : otProjectId;
            this.opportunityRFINumber               = "'" + oppportunityRFINumber.Trim().Replace("'", "''") + "'";
            this.opportunityRFINumberRev            = "'" + oppportunityRFINumberRev.Trim().Replace("'", "''") + "'";	
            this.RFIToContactID		        =  String.IsNullOrEmpty(RFIToContactID) ? "Null" : "'" + RFIToContactID + "'";		    
            this.RFISubject			        =  "'" + RFISubject.Trim().Replace("'","''") + "'";			    
            this.RFIFromID				    =  String.IsNullOrEmpty(RFIFromID) ? "Null" : "'" + RFIFromID + "'";				
            this.RFIDate				    =  String.IsNullOrEmpty(RFIDate) ? "Null" : "'" + RFIDate + "'";				
            this.RFIText				    =  "'" + RFIText.Trim().Replace("'","''") + "'";				
            this.RFIGeneralNumber	        =  "'" + RFIGeneralNumber.Trim().Replace("'","''") + "'";	    
            this.designDetailRequired       =  designDetailRequired == "True" ? "1" : "0";   
            this.delayJob                   =  delayJob == "True" ? "1" : "0";               
            this.discussedOnPhoneWith       =  "'" + discussedOnPhoneWith.Trim().Replace("'","''") + "'";   
            this.phoneDiscussionDate	    =  String.IsNullOrEmpty(phoneDiscussionDate) ? "Null" : "'" + phoneDiscussionDate + "'";	
            this.answeredNeededBy           =  String.IsNullOrEmpty(answeredNeededBy) ? "Null" : "'" + answeredNeededBy + "'";       
            this.statusOpenClosed	        =  statusOpenClosed;	    
            this.costImpactYesNo		    =  costImpactYesNo;		
            this.RFIResponse		        =  "'" + RFIResponse.Trim().Replace("'","''") + "'";		    
            this.responseDate               =  String.IsNullOrEmpty(responseDate) ? "Null" : "'" + responseDate + "'";
            this.responseBy                 = "'" + responseBy.Trim().Replace("'", "''") + "'";
            this.emailBody                  = "'" + emailBody.Trim().Replace("'", "''") + "'";		    
            this.rfivoid                    =  rfivoid == "True" ? "1" : "0";
            this.toCompany                  = string.IsNullOrEmpty(toCompany) ? "Null" : "'" + toCompany + "'";

        }
        //
        public static DataSet GetRFISheet(string opportunityRFIID)
        {
            string query = "";

            query = " SELECT " +
                    " Company = RFIToCompany, " +
                    " CompanyTo = RFIToContact, " +
                    " RFISubject, " +
                    " PreBidRFINumber, " +
                    " PreBidRFINumberRev, " +
                    " RFIDate, " +
                    " JobNumber, " +
                    " JobName, " +
                    " CompanyFrom = RFIFrom, " + 
                    " RFIText, " +
                    " DesignDetailRequired, " +
                    " DiscussedOnPhoneWith, " +
                    " PhoneDiscussionDate, " +
                    " AnsweredNeededBy, " +
                    " RFIResponse, " +
                    " ISNULL(EmailBody, '') AS EmailBody, " +
                    " CostImpactYesNo " +
                    " FROM tblPreBidRFI r " +
                    " JOIN tblJob o on r.JobID=o.JobID " +
                    " WHERE r.PreBidRFIID =  " + opportunityRFIID + " ";

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
        public static DataSet GetRFI(string RFIID)
        {
            string query = "";

            query = " SELECT * FROM tblPreBidRFI WHERE PreBidRFIID = " + RFIID + " ";

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
        public static DataSet GetOpportunityRFI(string projectID)
        {
            string query = "";

            query = " SELECT " +
                    " PreBidRFIID, " +
                    " LTRIM(RTRIM(PreBidRFINumber)) + '.' + PreBidRFINumberRev AS [RFI No], " +
                    " RFIGeneralNumber AS [GC RFI No], " +
                    " RFISubject AS [Subject], " +
                    " RFIDate AS [RFI Date], " +
                    " ResponseDate AS [Response Date], " +
                    " [Status] =  " +
                    " CASE StatusOpenClosed " +
                    " WHEN 1 THEN 'Closed' " +
                    " ELSE 'Open' " +
                    " END , " +
                    " [Days Out] = " +
                    " CASE StatusOpenClosed " +
                    " WHEN 0 THEN " +
                    " DATEDIFF(Day, RFIDate, GetDATE()) " +
                    " END, " +
                    " Void, " +
                    " [Cost Impact] = " +
                    " CASE CostImpactYesNo " +
                    " WHEN 1 THEN 'No'" +
                    " ELSE 'Yes' " +
                    " END " +
                    " FROM tblPreBidRFI r  " +
                    " WHERE r.JobID = " + projectID + " " +
                    " ORDER BY PreBidRFINumber, PreBidRFINumberRev ";
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
            if (opportunityRFIID == "" || opportunityRFIID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblPreBidRFI(" +
                    " JobID, " +
                    " PreBidRFINumber, " +
                    " PreBidRFINumberRev, " +
                    " RFIToContact, " +		   
                    " RFISubject, " +			   
                    " RFIFrom, " +				
                    " RFIDate, " +				
                    " RFIText, " +				
                    " RFIGeneralNumber, " +	   
                    " DesignDetailRequired, " +               
                    " DiscussedOnPhoneWith, " +  
                    " PhoneDiscussionDate, " +	
                    " AnsweredNeededBy, " +      
                    " StatusOpenClosed, " +	   
                    " CostImpactYesNo, " +		
                    " RFIResponse, " +		   
                    " ResponseDate, " + 
                    " EmailBody, " +
                    " Void, " +
                    " ResponseBy," +
                    "RFIToCompany) VALUES (" +
                    otProjectID + ", " +	
	                opportunityRFINumber + ", " +
                    opportunityRFINumberRev + ", " +
                    RFIToContactID + ", " +		   
                    RFISubject + ", " +			   
                    RFIFromID + ", " +				
                    RFIDate + ", " +				
                    RFIText + ", " +				
                    RFIGeneralNumber + ", " +	   
                    designDetailRequired + ", " +  
                    discussedOnPhoneWith + ", " +  
                    phoneDiscussionDate + ", " +	
                    answeredNeededBy + ", " +      
                    statusOpenClosed + ", " +	   
                    costImpactYesNo + ", " +		
                    RFIResponse + ", " +		   
                    responseDate + ", " + 
                    emailBody + ", " +
                    rfivoid + ", " +
                    responseBy + ", " +
                    toCompany + ") " +
                   "Select @@IDENTITY ";
            try
            {
                opportunityRFIID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT PreBidRFINumber, PreBidRFINumberRev FROM tblPreBidRFI WHERE PreBidRFIID = " + opportunityRFIID + " ";

                DataTable t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                {
                    opportunityRFINumber = t.Rows[0]["PreBidRFINumber"].ToString();
                    opportunityRFINumberRev = t.Rows[0]["PreBidRFINumberRev"].ToString();
                }
                else
                {
                    opportunityRFINumber = "";
                    opportunityRFINumberRev = "";
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

            query = "Update tblPreBidRFI SET " +
                    " JobID                 = " + otProjectID + ", " +
                    " PreBidRFINumber          = " + opportunityRFINumber + ", " +
                    " PreBidRFINumberRev       = " + opportunityRFINumberRev + ", " +
                    " RFIToContact        = " + RFIToContactID + ", " +
                    " RFISubject            = " + RFISubject + ", " +
                    " RFIFrom             = " + RFIFromID + ", " +
                    " RFIDate               = " + RFIDate + ", " +
                    " RFIText               = " + RFIText + ", " +
                    " RFIGeneralNumber      = " + RFIGeneralNumber + ", " +
                    " DesignDetailRequired  = " + designDetailRequired + ", " +
                    " DiscussedOnPhoneWith  = " + discussedOnPhoneWith + ", " +
                    " PhoneDiscussionDate   = " + phoneDiscussionDate + ", " +
                    " AnsweredNeededBy      = " + answeredNeededBy + ", " +
                    " StatusOpenClosed      = " + statusOpenClosed + ", " +
                    " CostImpactYesNo       = " + costImpactYesNo + ", " +
                    " RFIResponse           = " + RFIResponse + ", " +
                    " ResponseDate          = " + responseDate + ", " +
                    " EmailBody             = " + emailBody + ", " +
                    " Void                  = " + rfivoid + ", " +
                    " ResponseBy            = " + responseBy + ", " +
                    " RFIToCompany            = " + toCompany + " " +
                    " WHERE PreBidRFIID  = " + opportunityRFIID;
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

        public static DataSet GetOpportunityOffice ( string otProjectID )
        {
            string query = "SELECT o.* FROM tblJob j " +
                            " LEFT JOIN tblOffice o " +
                            " ON j.OfficeID = o.OfficeID " +
                            " WHERE JobID =  " + otProjectID + "";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
