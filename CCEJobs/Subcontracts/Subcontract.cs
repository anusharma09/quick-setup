using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using JCCBusinessLayer;
namespace CCEJobs.Subcontracts
{
    class Subcontract
    {
  
        private string subcontractID;
        private string jobID;
        private string subcontractNumber;
        private string MSA;
        private string vendorID;
        private string contractDescription;
        private string retainagePercent;
        private string performanceBondRequired;
        private string dateBondReceived;
        private string contractRequired;
        private string dateContractReceived;
        private string insuranceCertificateRequired;
        private string insuranceCertificateExpiredDateA;
        private string insuranceCertificateExpiredDateB;
        private string insuranceCertificateExpiredDateC;
        private string contractDate;
        private string originalContract;
        private string buyoutAmount;
        private string lienWaiverFlag;
        private string lienWaiverDate;
        private string submittalRequiredFlag;
        private string submittalReceivedDate;
        private string sequenceNumber;
        private string releaseNumber;
        private string PONumber;
        //
        public string SubcontractID
        {
            get { return subcontractID; }
        }
        public Subcontract()
        {
        }
        public Subcontract(string subcontractID,
                                string jobID,
                                string subcontractNumber,
                                string MSA,
                                string vendorID,
                                string contractDescription,
                                string retainagePercent,
                                string performanceBondRequired,
                                string dateBondReceived,
                                string contractRequired,
                                string dateContractReceived,
                                string insuranceCertificateRequired,
                                string insuranceCertificateExpiredDateA,
                                string insuranceCertificateExpiredDateB,
                                string insuranceCertificateExpiredDateC,
                                string contractDate,
                                string originalContract,
                                string buyoutAmount,
                                string lienWaiverFlag,
                                string lienWaiverDate,
                                string submittalRequiredFlag,
                                string submittalReceivedDate,
                                string sequenceNumber,
                                string releaseNumber,
                                string PONumber)
        {


            this.subcontractID                      = subcontractID;
            this.jobID                              = jobID;
            this.subcontractNumber                  = subcontractNumber.Trim().ToUpper().Replace("'", "''");
            this.MSA                                = MSA == "True" ? "1" : "0";
            this.vendorID                           = vendorID;
            this.contractDescription                = contractDescription.Trim().ToUpper().Replace("'", "''");
            this.retainagePercent                   = String.IsNullOrEmpty(retainagePercent) ? "Null" : retainagePercent;
            this.performanceBondRequired            = performanceBondRequired == "True" ? "1" : "0";
            this.dateBondReceived                   = String.IsNullOrEmpty(dateBondReceived) ? "null" : "'" + dateBondReceived + "'";
            this.contractRequired                   = contractRequired == "True" ? "1" : "0";
            this.dateContractReceived               = String.IsNullOrEmpty(dateContractReceived) ? "null" : "'" + dateContractReceived + "'";
            this.insuranceCertificateRequired       = insuranceCertificateRequired == "True" ? "1" : "0";
            this.insuranceCertificateExpiredDateA   = String.IsNullOrEmpty(insuranceCertificateExpiredDateA) ? "Null" : "'" + insuranceCertificateExpiredDateA + "'";
            this.insuranceCertificateExpiredDateB   = String.IsNullOrEmpty(insuranceCertificateExpiredDateB) ? "Null" : "'" + insuranceCertificateExpiredDateB + "'";
            this.insuranceCertificateExpiredDateC   = String.IsNullOrEmpty(insuranceCertificateExpiredDateC) ? "Null" : "'" + insuranceCertificateExpiredDateC + "'";
            this.contractDate                       = String.IsNullOrEmpty(contractDate) ? "null" : "'" + contractDate + "'";
            this.originalContract                   = String.IsNullOrEmpty(originalContract) ? "null" : originalContract;
            this.buyoutAmount                       = String.IsNullOrEmpty(buyoutAmount) ? "Null" : buyoutAmount;
            this.lienWaiverFlag                     = lienWaiverFlag == "True" ? "1" : "0";
            this.lienWaiverDate                     = String.IsNullOrEmpty(lienWaiverDate) ? "null" : "'"  + lienWaiverDate + "'" ;
            this.submittalRequiredFlag              = submittalRequiredFlag == "True" ? "1" : "0";
            this.submittalReceivedDate              = String.IsNullOrEmpty(submittalReceivedDate) ? "null" : "'" + submittalReceivedDate + "'";
            this.sequenceNumber                     = sequenceNumber;
            this.releaseNumber                      = releaseNumber.Trim().ToUpper().Replace("'", "''");
            this.PONumber                           = PONumber.Trim().ToUpper().Replace("'", "''");
        }
        //
        public static void UpdateSubcontractBalance(string subcontractID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@SubcontractID", subcontractID);
            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.up_DMSubcontractBalanceUpdate", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetSubcontractSheet(string subcontractID)
        {
            string query = "";


            query = "SELECT JobNumber, JobName, [Name], s.* FROM tblSubcontract s " +
                    " INNER JOIN tblJob j " +
                    " ON s.JobID = j.JobID " +
                    " LEFT JOIN tblVendor v " +
                    " ON s.VendorID = v.VendorID " +
                    " where SubcontractID = '" + subcontractID + "' ";
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
        public static DataSet GetSubcontracts(string jobID)
        {
            string query = "";


            query = "SELECT SubcontractID, SubcontractNumber, ContractDescription FROM tblSubcontract " +
                    " WHERE JobID = '" + jobID + "' ";
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
        public static DataSet GetSubcontract(string subcontractID)
        {
            string query = "";


            query = "SELECT * FROM tblSubcontract " +
                    " WHERE SubcontractID = '" + subcontractID + "' ";
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
        public static DataSet GetSubcontractSummary(string subcontractID)
        {
            string query = "";


            query = "SELECT JobNumber, JobName, SubcontractNumber, OriginalContract, TotalOriginalContractCost, ApprovedChanges, PendingChanges, TotalOriginalContractCost, TotalApprovalCost, " +
                    " TotalInvoice, TotalRetainage, TotalAmountPaid, TotalBackCharges, LastBilledDate, LastPaymentDate, " +
                    " CurrentContract, TotalPendingCost, TotalCost " +
                    " FROM tblSubContract s " +
                    " LEFT JOIN tblJob j ON s.JobID = j.JobID " +             
                    " WHERE subcontractID = " + subcontractID + " ";
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
            bool ret = false; 
            if (String.IsNullOrEmpty(subcontractID))
                ret =  Insert();
            else
                ret =  Update();
            //Update Starbuilder
            if (ret)
            {
                SqlParameter[] par = new SqlParameter[1];

                par[0] = new SqlParameter("@SubcontractID", subcontractID);
                DataBaseUtil.ExecuteParDataset("up_DMJobUpdateStarbuilderSubcontract", CCEApplication.Connection, CommandType.StoredProcedure, par);

            }
            return ret;
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblSubcontract(JobID, " +
                                " SubcontractNumber, " +
                                " MSA, " +
                                " VendorID, " +
                                " ContractDescription, " +
                                " RetainagePercent, " +
                                " PerformanceBondRequired, " +
                                " DateBondReceived, " +
                                " ContractRequired, " +
                                " DateContractReceived, " +
                                " InsuranceCertificateRequired, " +
                                " InsuranceCertificateExpiredDateA, " +
                                " InsuranceCertificateExpiredDateB, " +
                                " InsuranceCertificateExpiredDateC, " +
                                " ContractDate, " +
                                " OriginalContract, " +
                                " BuyoutAmount, " +
                                " LienWaiverFlag, " +
                                " LienWaiverDate, " +
                                " SubmittalRequiredFlag, " +
                                " SubmittalReceivedDate, SequenceNumber, ReleaseNumber, PONumber) VALUES ( " +
                                jobID + ", " +
                                "'" + subcontractNumber + "', " +
                                MSA + ", " +
                                "'" + vendorID + "', " +
                                "'" + contractDescription + "', " +
                                retainagePercent + ", " +
                                performanceBondRequired + ", " +
                                dateBondReceived + ", " +
                                contractRequired + ", " +
                                dateContractReceived + ", " +
                                insuranceCertificateRequired + ", " +
                                insuranceCertificateExpiredDateA + ", " +
                                insuranceCertificateExpiredDateB + ", " +
                                insuranceCertificateExpiredDateC + ", " +
                                contractDate + ", " +
                                originalContract + ", " +
                                buyoutAmount + ", " +
                                lienWaiverFlag + ", " +
                                lienWaiverDate + ", " +
                                submittalRequiredFlag + ", " +
                                submittalReceivedDate + ", " +
                                "'" + sequenceNumber + "', " +
                                "'" + releaseNumber + "', " +
                                "'" + PONumber + "') " +
                    "SELECT @@IDENTITY";
            try
            {
                subcontractID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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
            string query = "";

            query = "Update tblSubcontract SET " +
                    " SubcontractNumber         = '" + subcontractNumber + "', " +
                    " MSA                       = " + MSA + ", " +
                    " VendorID                  = '" + vendorID + "', " +
                    " ContractDescription       = '" + contractDescription + "', " +
                    " RetainagePercent          = " + retainagePercent + ", " +
                    " PerformanceBondRequired   = " + performanceBondRequired + ", " +
                    " DateBondReceived          = " + dateBondReceived + ", " +
                    " ContractRequired          = " + contractRequired + ", " +
                    " DateContractReceived      = " + dateContractReceived + ", " +
                    " InsuranceCertificateRequired = " + insuranceCertificateRequired + ", " +
                    " InsuranceCertificateExpiredDateA = " + insuranceCertificateExpiredDateA + ", " +
                    " InsuranceCertificateExpiredDateB = " + insuranceCertificateExpiredDateB + ", " +
                    " InsuranceCertificateExpiredDateC = " + insuranceCertificateExpiredDateC + ", " +
                    " ContractDate              = " + contractDate + ", " +
                    " OriginalContract          = " + originalContract + ", " +
                    " BuyoutAmount              = " + buyoutAmount + ", " +
                    " LienWaiverFlag            = " + lienWaiverFlag + ", " +
                    " LienWaiverDate            = " + lienWaiverDate + ", " +
                    " SubmittalRequiredFlag     = " + submittalRequiredFlag + ", " +
                    " SubmittalReceivedDate     = " + submittalReceivedDate + ", " +
                    " SequenceNumber            = '" + sequenceNumber + "', " +
                    " ReleaseNumber             = '" + releaseNumber + "', " +
                    " PONumber                  = '" + PONumber + "' " +
                    " WHERE SubcontractID = " + subcontractID;
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
