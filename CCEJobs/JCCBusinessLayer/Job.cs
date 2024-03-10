using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using ContraCostaElectric.DatabaseUtil;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace JCCBusinessLayer
{
    public class Job
    {
        private string jobID;
        private string officeID;
        private string departmentID;
        private string estimateNumber;
        private string jobNumber;
        private string jobName;
        private string jobDescription;
        private string jobAddress1;
        private string jobAddress2;
        private string jobCity;
        private string jobState;
        private string jobZip;
        private string jobPhone;
        private string customerID;
        private string billingAsCustomer;
        private string billingAddress1;
        private string billingAddress2;
        private string billingCity;
        private string billingState;
        private string billingZipCode;
        private string billingPhone;
        private string billingRep;
        private string ownerClassID;
        private string contractorAsCustomer;
        private string contractorName;
        private string contractorAddress1;
        private string contractorAddress2;
        private string contractorCity;
        private string contractorState;
        private string contractorZipCode;
        private string contractorPhone;
        private string contractorRep;
        private string ownerAsCustomer;
        private string ownerName;
        private string ownerAddress1;
        private string ownerAddress2;
        private string ownerCity;
        private string ownerState;
        private string ownerZipCode;
        private string ownerPhone;
        private string ownerRep;
        private string ownerContractor;
        private string laborRates;
        private string alphaCodes;
        private string otherLabor;
        private string materialMU;
        private string otherMaterial;
        private string releaseNumber;
        private string cceEquip;
        private string outsideRentalMU;
        private string subcontractMU;
        private string otherMU;
        private string workTypeID;
        private string contractTypeID;
        private string projectManagerID;
        private string estimatorID;
        private string superintendentID;
        private string foremanID;
        private string contractNumber;
        private string originalContractAmount;
        private string jobFinalContractAmount;
        private string copyOfVendorInvoicesNeeded;
        private string subcontractors;
        private string certifiedPayRoll;
        private string bondID;
        private string bondDate;
        private string bondNumber;
        private string poNumber;
        private string contractStartDate;
        private string contractEstCompldate;
        private string jurisdiction;
        private string masterJobNumber;
        private string retainageID;
        private string insuranceProgramID;
        private string totalCLPUAmount;
        private string GLIABName;
        private string UMBRLName;
        private string preliminaryNotice;
        private string preliminaryDateMailed;
        private string preliminaryMailedBy;
        private string comment;
        private string postedToFileDate;
        private string postedToFileBy;
        private string jobStatusID;
        private string customerIsSubcontractor;
        private string customerSubcontractors;
        private string WIPRequired;
        private string WIPStatus;
        private string WIPEntryID;
        private string trade;
        private string lenderID;
        private string lenderName;
        private string lenderAddress;
        private string lenderCity;
        private string lenderState;
        private string lenderZip;
        private string releaseToCustomer;
        private string signedDaily;
        private string signedWorkOrder;
        private string timeSheetSigned;
        private string subcontractorInvoicesRequired;
        private string customerAuthorizedForm;
        private string trackingSpreadsheets;
        private string multipleCopies;
        private string billingFrequency;
        private string clientPercentNotification;
        private string lienRelease;
        private string cutOffDate;
        private string bidDate;
        private string bidTime;
        private string preBidAmount;
        private string finalBidAmount;
        private string designBuild;
        private string drawingReceived;
        private string quotesRequired;
        private string bidForm;
        private string bidWalkDate;
        private string bidWalkTime;
        private string deliveryMethod;
        private string architectEngineer;
        private string addendumReceived;
        private string jobEmail;
        private string jobFax;
        private string bidTo;
        private string jobCreatedBy;
        private string jobUpdatedBy;
        private string wonLostDate;
        private string meetingDate;
        private string meetingTime;
        private string reviewDate;
        private string reviewTime;
        private string over250K;
        private string over1M;
        private string voided;
        private string archived;
        private string revisionJobID;
        private string revisionID;
        private string bidBondID;
        private string jobCreatedDate;
        private string departmentName;
        private string officeName;
        private string bidBondName;
        private string contractTypeName;
        private string estimateHandoff;
        private string estimateHandoffGrade;
        private string pmHandoff;
        private string pmHandoffGrade;
        private string projectStartupMeeting;
        private string salesRepID;
        private string jobTechID;
        private string jobCostLevelCode;
        private string billingLevelCode;
        private string jobCertifiedFlag;
        private string jobTaxFlag;
        private string jobValidationCode;
        private string jobGLAccount;
        private string jobOverheadEquipment;
        private string jobOverheadLabor;
        private string jobOverheadMaterial;
        private string jobOverheadSubcontractor;
        private string jobOverheadOther;
        private string jobPercentCompletion;
        private string jobOwnerCompletion;
        private string jobBurdenPercent;
        private string jobSalesTaxPercent;
        private string jobBillingType;
        private string jobSaveHistoryFlag;
        private string jobCertifiedReportType;
        private string printStatementOfCompliance;
        private string printAlwaysPrintReport;
        private string printDeductionDetail;
        private string certifiedContractorOrSubcontractor;
        private string certifiedWeekNumber;
        private string lastReportNumber;
        private string nextReportNumber;
        private string WIPComments;
        private string dropOffComplianceReport;
        private string projectCloseoutMeeting;
        private string duration;
        private string dashboard;
        private string trackChangeOrder;
        private string insuranceRequiredToBeReviewed;
        private string jobNameOld;
        private string OCIPClosedDate;
        private string OCIPClosed;
        private string competitive;
        private string customerComment;
        private string scopeOfWork;
        //
        public string JobID
        {
            get { return jobID; }
        }
        //
        public string EstimateNumber
        {
            get { return estimateNumber; }
        }
        //
        public string JobNumber
        {
            get { return jobNumber; }
        }
        //
        public Job()
        {
        }
        //
        public Job(string jobID,
                    string officeID,
                    string departmentID,
                    string estimateNumber,
                    string jobNumber,
                    string jobName,
                    string jobDescription,
                    string jobAddress1,
                    string jobAddress2,
                    string jobCity,
                    string jobState,
                    string jobZip,
                    string jobPhone,
                    string customerID,
                    string billingAsCustomer,
                    string billingAddress1,
                    string billingAddress2,
                    string billingCity,
                    string billingState,
                    string billingZipCode,
                    string billingPhone,
                    string billingRep,
                    string ownerClassID,
                    string contractorAsCustomer,
                    string contractorName,
                    string contractorAddress1,
                    string contractorAddress2,
                    string contractorCity,
                    string contractorState,
                    string contractorZipCode,
                    string contractorPhone,
                    string contractorRep,
                    string ownerAsCustomer,
                    string ownerName,
                    string ownerAddress1,
                    string ownerAddress2,
                    string ownerCity,
                    string ownerState,
                    string ownerZipCode,
                    string ownerPhone,
                    string ownerRep,
                    string ownerContractor,
                    string laborRates,
                    string alphaCodes,
                    string otherLabor,
                    string materialMU,
                    string otherMaterial,
                    string releaseNumber,
                    string cceEquip,
                    string outsideRentalMU,
                    string subcontractMU,
                    string otherMU,
                    string workTypeID,
                    string contractTypeID,
                    string projectManagerID,
                    string estimatorID,
                    string superintendentID,
                    string foremanID,
                    string contractNumber,
                    string originalContractAmount,
                    string jobFinalContractAmount,
                    string copyOfVendorInvoicesNeeded,
                    string subcontractors,
                    string certifiedPayRoll,
                    string bondID,
                    string bondDate,
                    string bondNumber,
                    string poNumber,
                    string contractStartDate,
                    string contractEstCompldate,
                    string jurisdiction,
                    string masterJobNumber,
                    string retainageID,
                    string insuranceProgramID,
                    string totalCLPUAmount,
                    string GLIABName,
                    string UMBRLName,
                    string preliminaryNotice,
                    string preliminaryDateMailed,
                    string preliminaryMailedBy,
                    string comment,
                    string postedToFileDate,
                    string postedToFileBy,
                    string jobStatusID,
                    string customerIsSubcontractor,
                    string customerSubcontractors,
                    string WIPRequired,
                    string WIPStatus,
                    string WIPEntryID,
                    string trade,
                    string lenderID,
                    string lenderName,
                    string lenderAddress,
                    string lenderCity,
                    string lenderState,
                    string lenderZip,
                    string releaseToCustomer,
                    string signedDaily,
                    string signedWorkOrder,
                    string timeSheetSigned,
                    string subcontractorInvoicesRequired,
                    string customerAuthoerizedForm,
                    string trackingSpreadsheets,
                    string multipleCopies,
                    string billingFrequency,
                    string clientPercentNotification,
                    string lienRelease,
                    string cutOffDate,
                    string bidDate,
                    string bidTime,
                    string preBidAmount,
                    string finalBidAmount,
                    string designBuild,
                    string drawingReceived,
                    string quotesRequired,
                    string bidForm,
                    string bidWalkDate,
                    string bidWalkTime,
                    string deliveryMethod,
                    string architectEngineer,
                    string addendumReceived,
                    string jobEmail,
                    string jobFax, 
                    string bidTo, 
                    string wonLostDate,
                    string meetingDate,
                    string meetingTime,
                    string reviewDate,
                    string reviewTime,
                    string over250K,
                    string over1M,
                    string voided,
                    string archived,
                    string revisionJobID,
                    string revisionID,
                    string bidBondID,
                    string estimateHandoff,
                    string estimateHandoffGrade,
                    string pmHandoff,
                    string pmHandoffGrade,
                    string projectStartupMeeting,
                    string salesRepID,
                    string jobTechID,
                    string jobCostLevelCode,
                    string billingLevelCode,
                    string jobCertifiedFlag,
                    string jobTaxFlag,
                    string jobValidationCode,
                    string jobGLAccount,
                    string jobOverheadEquipment,
                    string jobOverheadLabor,
                    string jobOverheadMaterial,
                    string jobOverheadSubcontractor,
                    string jobOverheadOther,
                    string jobPercentCompletion,
                    string jobOwnerCompletion,
                    string jobBurdenPercent,
                    string jobSalesTaxPercent,
                    string jobBillingType,
                    string jobSaveHistoryFlag,
                    string jobCertifiedReportType,
                    string printStatementOfCompliance,
                    string printAlwaysPrintReport,
                    string printDeductionDetail,
                    string certifiedContractorOrSubcontractor,
                    string certifiedWeekNumber,
                    string lastReportNumber,
                    string nextReportNumber,
                    string dropOffComplianceReport,
                    string projectCloseoutMeeting,
                    string WIPComments, 
                    string duration,
                    string dashboard,
                    string trackChangeOrder,
                    string insuranceRequiredToBeReviewed,
                    string OCIPClosedDate,
                    string OCIPClosed,
                    string competitive,
                    string customerComment,
                    string scopeOfWork) 
        {
            this.jobID                  = jobID;
            this.estimateNumber         = estimateNumber;
            this.jobNumber              = jobNumber;
            this.officeID               = String.IsNullOrEmpty(officeID) ? "Null" : officeID;
            this.departmentID           = String.IsNullOrEmpty(departmentID) ? "Null" : departmentID ;
            this.jobName = String.IsNullOrEmpty(jobName) ? "" : jobName.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32).Replace("\\", "").Replace("/", "").Replace("*", "").Replace(":", "").Replace("?", "").Replace(">", "").Replace("<", "").Replace("|", "");
            this.jobDescription         = String.IsNullOrEmpty(jobDescription) ? "" : jobDescription.ToUpper().Trim().Replace("'","''").Replace((char)34, (char)32);
            this.jobAddress1            = String.IsNullOrEmpty(jobAddress1) ? "" : jobAddress1.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobAddress2            = String.IsNullOrEmpty(jobAddress2) ? "" : jobAddress2.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobCity                = String.IsNullOrEmpty(jobCity) ? "" : jobCity.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobState               = String.IsNullOrEmpty(jobState) ? "" : jobState.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobZip                 = String.IsNullOrEmpty(jobZip) ? "" : jobZip.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobPhone               = String.IsNullOrEmpty(jobPhone) ? "" : jobPhone.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.customerID             = String.IsNullOrEmpty(customerID) ? "Null" :  "'" + customerID + "'" ;
            this.billingAsCustomer      = billingAsCustomer == "True" ? "1" : "0";
            this.billingAddress1        = String.IsNullOrEmpty(billingAddress1) ? "" : billingAddress1.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.billingAddress2        = String.IsNullOrEmpty(billingAddress2) ? "" : billingAddress2.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.billingCity            = String.IsNullOrEmpty(billingCity) ? "" : billingCity.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.billingState           = String.IsNullOrEmpty(billingState) ? "" : billingState.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.billingZipCode         = String.IsNullOrEmpty(billingZipCode) ? "" : billingZipCode.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.billingPhone           = String.IsNullOrEmpty(billingPhone) ? "" : billingPhone.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.billingRep             = String.IsNullOrEmpty(billingRep) ? "" : billingRep.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.ownerClassID           = String.IsNullOrEmpty(ownerClassID) ? "Null" : ownerClassID;
            this.contractorAsCustomer   = String.IsNullOrEmpty(contractorAsCustomer) ? "0" : contractorAsCustomer == "True" ? "1" : "0";
            this.contractorName         = String.IsNullOrEmpty(contractorName) ? "" : contractorName.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.contractorAddress1     = String.IsNullOrEmpty(contractorAddress1) ? "" : contractorAddress1.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.contractorAddress2     = String.IsNullOrEmpty(contractorAddress2) ? "" : contractorAddress2.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.contractorCity         = String.IsNullOrEmpty(contractorCity) ? "" : contractorCity.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.contractorState        = String.IsNullOrEmpty(contractorState) ? "" : contractorState.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.contractorZipCode      = String.IsNullOrEmpty(contractorZipCode) ? "" : contractorZipCode.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.contractorPhone        = String.IsNullOrEmpty(contractorPhone) ? "" : contractorPhone.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.contractorRep          = String.IsNullOrEmpty(contractorRep) ? "" : contractorRep.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.ownerAsCustomer        = ownerAsCustomer == "True" ? "1" : "0";
            this.ownerName              = String.IsNullOrEmpty(ownerName) ? "" : ownerName.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerAddress1          = String.IsNullOrEmpty(ownerAddress1) ? "" : ownerAddress1.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerAddress2          = String.IsNullOrEmpty(ownerAddress2) ? "" : ownerAddress2.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerCity              = String.IsNullOrEmpty(ownerCity) ? "" : ownerCity.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerState             = String.IsNullOrEmpty(ownerState) ? "" : ownerState.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerZipCode           = String.IsNullOrEmpty(ownerZipCode) ? "" : ownerZipCode.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerPhone             = String.IsNullOrEmpty(ownerPhone) ? "" : ownerPhone.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerRep               = String.IsNullOrEmpty(ownerRep) ? "" : ownerRep.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.ownerContractor        = String.IsNullOrEmpty(ownerContractor) ? "" : ownerContractor.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);            
            this.laborRates             = laborRates == "True" ? "1" : "0";
            this.alphaCodes             = String.IsNullOrEmpty(alphaCodes) ? "" : alphaCodes;
            this.otherLabor             = otherLabor.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.materialMU             = String.IsNullOrEmpty(materialMU) ? "Null" : materialMU;
            this.otherMaterial          = otherLabor.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.releaseNumber          = String.IsNullOrEmpty(releaseNumber) ? "" : releaseNumber.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.cceEquip               = String.IsNullOrEmpty(cceEquip) ? "" : cceEquip;
            this.outsideRentalMU        = String.IsNullOrEmpty( outsideRentalMU) ? "Null" : outsideRentalMU;
            this.subcontractMU          = String.IsNullOrEmpty(subcontractMU) ? "Null" : subcontractMU;
            this.otherMU                = String.IsNullOrEmpty(otherMU) ? "Null" : otherMU == "True" ? "1" : "0";
            this.workTypeID             = String.IsNullOrEmpty(workTypeID) ? "Null" : workTypeID;
            this.contractTypeID         = String.IsNullOrEmpty(contractTypeID) ? "Null" : contractTypeID;
            this.projectManagerID       = String.IsNullOrEmpty(projectManagerID) ? "Null" : projectManagerID;
            this.estimatorID            = String.IsNullOrEmpty(estimatorID) ? "Null" : estimatorID;
            this.superintendentID       = String.IsNullOrEmpty(superintendentID) ? "Null" : superintendentID;
            this.foremanID              = String.IsNullOrEmpty(foremanID) ? "Null" : foremanID;
            this.contractNumber         = String.IsNullOrEmpty(contractNumber) ? "" : contractNumber.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.originalContractAmount = String.IsNullOrEmpty(originalContractAmount) ? "Null" : originalContractAmount;
            this.jobFinalContractAmount   = String.IsNullOrEmpty(jobFinalContractAmount) ? "Null" : jobFinalContractAmount;
            this.copyOfVendorInvoicesNeeded = copyOfVendorInvoicesNeeded == "True" ? "1" : "0";
            this.subcontractors         = subcontractors == "True" ? "1" : "0";
            this.certifiedPayRoll       = certifiedPayRoll == "True" ? "1" : "0";
            this.bondID                 = String.IsNullOrEmpty(bondID) ? "Null" : bondID;
            this.bondDate               = String.IsNullOrEmpty(bondDate) ? "null" : "'" + bondDate + "'";
            this.bondNumber             = String.IsNullOrEmpty(bondNumber) ? "" : bondNumber.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.poNumber               = String.IsNullOrEmpty(poNumber) ? "" : poNumber.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.contractStartDate      = String.IsNullOrEmpty(contractStartDate) ? "null" : "'" + contractStartDate + "'";
            this.contractEstCompldate   = String.IsNullOrEmpty(contractEstCompldate) ? "null" : "'" + contractEstCompldate + "'";
            this.jurisdiction           = String.IsNullOrEmpty(jurisdiction) ? "" : jurisdiction.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.masterJobNumber        = String.IsNullOrEmpty(masterJobNumber) ? "" : masterJobNumber.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.retainageID            = String.IsNullOrEmpty(retainageID) ? "Null" : retainageID;
            this.insuranceProgramID     = String.IsNullOrEmpty(insuranceProgramID) ? "Null" : insuranceProgramID;
            this.totalCLPUAmount        = String.IsNullOrEmpty(totalCLPUAmount) ? "Null" : totalCLPUAmount;
            this.GLIABName              = String.IsNullOrEmpty(GLIABName) ? "" : GLIABName.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.UMBRLName              = String.IsNullOrEmpty(UMBRLName) ? "" : UMBRLName.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.preliminaryNotice      = preliminaryNotice == "True" ? "1" : "0";
            this.preliminaryDateMailed  = String.IsNullOrEmpty(preliminaryDateMailed) ? "null" : "'" + preliminaryDateMailed + "'";
            this.preliminaryMailedBy    = String.IsNullOrEmpty(preliminaryMailedBy) ? "" : preliminaryMailedBy.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.comment                = String.IsNullOrEmpty(comment) ? "" : comment.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.postedToFileDate       = String.IsNullOrEmpty(postedToFileDate)? "null" : "'" + postedToFileDate + "'";
            this.postedToFileBy         = String.IsNullOrEmpty(postedToFileBy) ? "" : postedToFileBy.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.jobStatusID            = String.IsNullOrEmpty(jobStatusID) ? "Null" : jobStatusID;
            this.customerIsSubcontractor = customerIsSubcontractor == "True" ? "1" : "0";
            this.customerSubcontractors = String.IsNullOrEmpty(customerSubcontractors) ? "" : customerSubcontractors.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.WIPRequired            = WIPRequired == "True" ? "1" : "0";
            this.WIPStatus              = String.IsNullOrEmpty(WIPStatus) ? "" : WIPStatus.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.WIPEntryID             = String.IsNullOrEmpty(WIPEntryID) ? "Null" : WIPEntryID;
            this.trade                  = String.IsNullOrEmpty(trade) ? "" : trade;
            this.lenderID               = String.IsNullOrEmpty(lenderID) ? "Null" : lenderID;
            this.lenderName             = String.IsNullOrEmpty(lenderName) ? "" : lenderName.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.lenderAddress          = String.IsNullOrEmpty(lenderAddress) ? "" : lenderAddress.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.lenderCity             = String.IsNullOrEmpty(lenderCity) ? "" : lenderCity.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.lenderState            = String.IsNullOrEmpty(lenderState) ? "" : lenderState.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.lenderZip              = String.IsNullOrEmpty(lenderZip) ? "" : lenderZip.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.releaseToCustomer      = String.IsNullOrEmpty(releaseToCustomer) ? "" : releaseToCustomer.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.signedDaily            = signedDaily == "True" ? "1" : "0";
            this.signedWorkOrder        = signedWorkOrder == "True" ? "1" : "0";
            this.timeSheetSigned        = timeSheetSigned == "True" ? "1" : "0";
            this.subcontractorInvoicesRequired = subcontractorInvoicesRequired == "True" ? "1" : "0";
            this.customerAuthorizedForm = customerAuthoerizedForm == "True" ? "1" : "0";
            this.trackingSpreadsheets   = trackingSpreadsheets == "True" ? "1" : "0";
            this.multipleCopies         = multipleCopies == "True" ? "1" : "0";
            this.billingFrequency       = billingFrequency == "True" ? "1" : "0";
            this.clientPercentNotification = clientPercentNotification == "True" ? "1" : "0";
            this.lienRelease            = lienRelease == "True" ? "1" : "0";
            this.cutOffDate             = String.IsNullOrEmpty(cutOffDate) ? "null" :  "'" + cutOffDate + "'";
            this.bidDate                = String.IsNullOrEmpty(bidDate) ? "null" : "'" + bidDate + "'";
            this.bidTime                = String.IsNullOrEmpty(bidTime) ? "" : bidTime;
            this.preBidAmount           = String.IsNullOrEmpty(preBidAmount) ? "null" : preBidAmount;
            this.finalBidAmount         = String.IsNullOrEmpty(finalBidAmount) ? "null" : finalBidAmount;
            this.designBuild            = designBuild == "True" ? "1" : "0";
            this.drawingReceived        = drawingReceived == "True" ? "1" : "0";
            this.quotesRequired         = quotesRequired == "True" ? "1" : "0";
            this.bidForm                = bidForm == "True" ? "1" : "0";
            this.bidWalkDate            = String.IsNullOrEmpty(bidWalkDate) ? "null" : "'" + bidWalkDate + "'";
            this.bidWalkTime            = String.IsNullOrEmpty(bidWalkTime) ? "" : bidWalkTime;
            this.deliveryMethod         = String.IsNullOrEmpty(deliveryMethod) ? "" : deliveryMethod.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.architectEngineer      = String.IsNullOrEmpty(architectEngineer) ? "" : architectEngineer.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.addendumReceived       = String.IsNullOrEmpty(addendumReceived) ? "" : addendumReceived.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobEmail               = String.IsNullOrEmpty(jobEmail) ? "" : jobEmail.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobFax                 = String.IsNullOrEmpty(jobFax) ? "" : jobFax.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.bidTo                  = String.IsNullOrEmpty(bidTo) ? "" : bidTo.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 

            this.jobCreatedBy           = Security.Security.LoginID;
            this.jobUpdatedBy           = Security.Security.LoginID;
            this.wonLostDate            = String.IsNullOrEmpty(wonLostDate) ? "null" : "'" + wonLostDate + "'";
            this.meetingDate            = String.IsNullOrEmpty(meetingDate) ? "null" : "'" + meetingDate + "'";
            this.meetingTime            = String.IsNullOrEmpty(meetingTime) ? "" : meetingTime.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.reviewDate             = String.IsNullOrEmpty(reviewDate) ? "null" : "'" + reviewDate + "'";
            this.reviewTime             = String.IsNullOrEmpty(reviewTime) ? "" : reviewTime.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.over250K               = over250K == "True" ? "1" : "0";
            this.over1M                 = over1M == "True" ? "1" : "0";
            this.voided                 = voided == "True" ? "1" : "0";
            this.archived               = archived == "True" ? "1" : "0";
            this.revisionJobID          = String.IsNullOrEmpty(revisionJobID) ? "Null" : revisionJobID;
            this.revisionID             = String.IsNullOrEmpty(revisionID) ? "Null" : revisionID;
            this.bidBondID              = String.IsNullOrEmpty(bidBondID) ? "Null" : bidBondID;
            this.estimateHandoff        = estimateHandoff == "True" ? "1" : "0";
            this.estimateHandoffGrade   = String.IsNullOrEmpty(estimateHandoffGrade) ? "" : estimateHandoffGrade;
            this.pmHandoff              = pmHandoff == "True" ? "1" : "0";
            this.pmHandoffGrade         = String.IsNullOrEmpty(pmHandoffGrade) ? "" : pmHandoffGrade;
            this.projectStartupMeeting = projectStartupMeeting == "True" ? "1" : "0";  
            this.salesRepID             = String.IsNullOrEmpty(salesRepID) ? "Null" : salesRepID;
            this.jobTechID              = String.IsNullOrEmpty(jobTechID) ? "Null" : jobTechID;
            this.jobCostLevelCode       = String.IsNullOrEmpty(jobCostLevelCode) ? "" : jobCostLevelCode.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.billingLevelCode       = String.IsNullOrEmpty(billingLevelCode) ? "" : billingLevelCode.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.jobCertifiedFlag        = jobCertifiedFlag == "True" ? "1" : "0";
            this.jobTaxFlag             = jobTaxFlag == "True" ? "1" : "0";
            this.jobValidationCode      = String.IsNullOrEmpty(jobValidationCode) ? "" : jobValidationCode.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.jobGLAccount           = String.IsNullOrEmpty(jobGLAccount) ? "" : jobGLAccount.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);       
            this.jobOverheadEquipment   = String.IsNullOrEmpty(jobOverheadEquipment) ? "null" : jobOverheadEquipment;
            this.jobOverheadLabor       = String.IsNullOrEmpty(jobOverheadLabor) ? "null" : jobOverheadLabor;
            this.jobOverheadMaterial    = String.IsNullOrEmpty(jobOverheadMaterial) ? "null" : jobOverheadMaterial;
            this.jobOverheadSubcontractor    = String.IsNullOrEmpty(jobOverheadSubcontractor) ? "null" : jobOverheadSubcontractor;
            this.jobOverheadOther       = String.IsNullOrEmpty(jobOverheadOther) ? "null" : jobOverheadOther;        
            this.jobPercentCompletion   = String.IsNullOrEmpty(jobPercentCompletion) ? "null" : jobPercentCompletion;     
            this.jobOwnerCompletion     = String.IsNullOrEmpty(jobOwnerCompletion) ? "null" : jobOwnerCompletion;     
            this.jobBurdenPercent       = String.IsNullOrEmpty(jobBurdenPercent) ? "null" : jobBurdenPercent;    
            this.jobSalesTaxPercent     = String.IsNullOrEmpty(jobSalesTaxPercent) ? "null" : jobSalesTaxPercent;
            this.jobBillingType         = String.IsNullOrEmpty(jobBillingType) ? "" : jobBillingType.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);     
            this.jobSaveHistoryFlag     = jobSaveHistoryFlag == "True" ? "1" : "0";
            this.jobCertifiedReportType = String.IsNullOrEmpty(jobCertifiedReportType) ? "" : jobCertifiedReportType.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);       
            this.printStatementOfCompliance = printStatementOfCompliance == "True" ? "1" : "0";
            this.printAlwaysPrintReport = printAlwaysPrintReport == "True" ? "1" : "0";
            this.printDeductionDetail   = printDeductionDetail == "True" ? "1" : "0";
            this.certifiedContractorOrSubcontractor = String.IsNullOrEmpty(certifiedContractorOrSubcontractor) ? "" : certifiedContractorOrSubcontractor.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.certifiedWeekNumber    = String.IsNullOrEmpty(certifiedWeekNumber) ? "0" : certifiedWeekNumber;
            this.lastReportNumber       = String.IsNullOrEmpty(lastReportNumber) ? "0" : lastReportNumber;
            this.nextReportNumber       = String.IsNullOrEmpty(nextReportNumber) ? "0" : nextReportNumber;
            this.WIPComments            = String.IsNullOrEmpty(WIPComments) ? "" : WIPComments.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32); 
            this.jobAddress2            = jobCity.Trim() + ", " + jobState + " " + jobZip.Trim();
            this.dropOffComplianceReport = dropOffComplianceReport == "True" ? "1" : "0";
            this.projectCloseoutMeeting = projectCloseoutMeeting == "True" ? "1" : "0";
            this.duration               = String.IsNullOrEmpty(duration) ? "" : duration.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.dashboard              = dashboard == "True" ? "1" : "0";
            this.trackChangeOrder       = trackChangeOrder == "True" ? "1" : "0";
            this.insuranceRequiredToBeReviewed  = insuranceRequiredToBeReviewed == "True" ? "1" : "0";
            this.OCIPClosedDate         = String.IsNullOrEmpty(OCIPClosedDate) ? "null" : "'" + OCIPClosedDate + "'";
            this.OCIPClosed             = OCIPClosed == "True" ? "1" : "0";
            this.competitive            = competitive == "True" ? "1" : "0";
            this.customerComment        = String.IsNullOrEmpty(customerComment) ? "" : customerComment.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32);
            this.scopeOfWork            = String.IsNullOrEmpty(scopeOfWork) ? "" : scopeOfWork.Trim().Replace("'", "''").Replace((char)34, (char)32); 
        }
        //
        public static float TMRecommendedAmount(string contractAmount)
        {
            float recommendedAmount = 0;
            string query  = " SELECT RecommendedAmount FROM tblTMRecommendedAmount WHERE " + contractAmount + " BETWEEN StartRange AND EndRange ";
            recommendedAmount = Convert.ToSingle( DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0]["RecommendedAmount"].ToString());
            return recommendedAmount;
        }
        //
        public static bool IsNoQuantity(string jobID)
        {
            string query = "SELECT COUNT(*) AS flag " +
                " FROM tblJobcostCodePhase WHERE JobID = " + jobID + 
                " AND CommittedQuantity = 0 AND CommittedHours > 0 AND JobCostCodeType = 'L'";
            try
            {
                bool retValue = false;
                if (Convert.ToInt16(DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0]["Flag"].ToString()) > 0)
                    retValue = true;
                return retValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobsWithLaborActivityByWeek(string date)
        {
            string query = "";

            query = " SELECT JobID, OfficeName AS Office, DepartmentName AS Department, JobNumber, JobName, Description AS Foreman " +
                    " FROM tblJob j " +
                    " LEFT JOIN tblOffice o ON j.OfficeID = o.OfficeID " +
                    " LEFT JOIN tblDepartment d ON j.DepartmentID = d.DepartmentID " +
                    " LEFT JOIN tblSuperintendent f ON j.SuperintendentID = f.SuperintendentID " +
                    " WHERE " +
                    " j.JobNumber > '' AND " +
                    " [dbo].[GetUserJobAccess] (JobID, '" + Security.Security.LoginID + " ') = 1 AND " +
                    " (SELECT COUNT(h.JobNumber) FROM tblJobHour h WHERE h.JobNumber = j.JobNumber AND weekend =  '" + date + "') > 0 " +
                    " ORDER BY Foreman ";

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
        public static DataSet GetJobList(string where)
        {
            string query = "";

            query = "SELECT b.JobID as RecordNo, EstimateNumber as [Estimate No], JobNumber AS [Job No], JobName AS [Job Name], aaa.Description As [Contract Type], AdjustmentPercent, CurrentBudgetLabor, CommittedCostToDateLabor, BidDate As [Bid Date]," +
                    " ContractStartDate AS [Job Start Date], ContractEstComplDate AS [Est. Compl. Date], WONLostDate as [W/L Date], " +
                    " s.JobStatus As [Job Status],  o.OfficeName as [Office], " + 
                    " DepartmentName AS [Department],  c.Name As [Customer], " +
                    " m.Description AS [Project Manager], t.Description AS [Estimator], u.Description AS [Foreman], " +
                    " f.Description AS [Superintendent] " +
                    " FROM tblJob b " + 
                    " LEFT JOIN tblJobBalance bb ON b.JobID = bb.JobID " +
                    " LEFT JOIN tblJobStatus s ON b.JobStatusID = s.JobStatusID " +
                    " LEFT JOIN tblOffice o ON b.OfficeID = o.OfficeID " +
                    " LEFT JOIN tblDepartment d ON b.DepartmentID = d.DepartmentID " +
                    " LEFT JOIN tblCustomer c ON b.CustomerID = c.CustomerID " +
                    " LEFT JOIN tblProjectManager m ON b.ProjectManagerID = m.ProjectManagerID " +
                    " LEFT JOIN tblEstimator t ON b.EstimatorID = t.EstimatorID " +
                    " LEFT JOIN tblSuperintendent u ON b.SuperintendentID = u.SuperintendentID " +
                    " LEFT JOIN tblForeman f ON b.ForemanID = f.ForemanID " +
                     "LEFT Join tblContractType aaa ON b.ContractTypeID = aaa.ContractTypeID " +

                    where + " ORDER BY JobNumber ";   
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
        public static DataSet GetJobListDashboard(string where)
        {
            string query = "";

            query = "SELECT b.JobID as RecordNo, JobNumber AS [Job No], aaa.Description As [Contract Type], ContractStartDate AS [Job Start Date], " +
                    " ContractEstComplDate AS [Est. Compl. Date], JobName AS [Job Name], ISNULL(TrackChangeOrder, 0) AS TrackChangeOrder, " +
                    " o.OfficeName as [Office],  DepartmentName AS [Department],  c.Name As [Customer], " +
                    " m.Description AS [Project Manager], t.Description AS [Estimator], " +
                    " ss.Description AS [Foreman], " +
                    " ISNULL(z.CurrentContract, 0) AS [Current Contract], " +
                    " ISNULL(z.CommittedCostToDate, 0) AS [Cost To Date], " +
                    " ISNULL(z.ProjectedProfit, 0) AS [Projected Profit Amount], " +
                    " ISNULL(z.AmountBilled, 0) AS [Amount Billed], " +
                    " ISNULL(z.AmountPaid, 0) As [Amount Paid], " +
                    " ISNULL(z.JobPerformanceFactor, 0) AS [Performance Factor], " +
                    " ISNULL(z.ProfitGainFade, 0) AS [Profit Fade], " +
                    " ISNULL(z.ProjectedProfitPercentage,0) AS [Profit Percentage], " +
                    " ISNULL(z.CostPerformanceFactor, 0) AS [Cost Performance Factor], " +
                    " ISNULL(z.LaborPercentage, 0) AS [Labor Percentage], " +
                    " ISNULL(z.MaterialPercentage, 0) AS [Material Percentage], " +
                    " Dashboard " +
                    " FROM tblJob b " +
                    " LEFT JOIN tblJobStatus s ON b.JobStatusID = s.JobStatusID " +
                    " LEFT JOIN tblOffice o ON b.OfficeID = o.OfficeID " +
                    " LEFT JOIN tblDepartment d ON b.DepartmentID = d.DepartmentID " +
                    " LEFT JOIN tblCustomer c ON b.CustomerID = c.CustomerID " +
                    " LEFT JOIN tblProjectManager m ON b.ProjectManagerID = m.ProjectManagerID " +
                    " LEFT JOIN tblEstimator t ON b.EstimatorID = t.EstimatorID " +
                    " LEFT JOIN tblSuperintendent ss ON b.SuperintendentID = ss.SuperintendentID " +
                    " LEFT Join tblJobBalance z ON b.JobID = z.JobID " +
                     "LEFT Join tblContractType aaa ON b.ContractTypeID = aaa.ContractTypeID " +
                    " WHERE (jobStatus = 'WON') AND (LTRIM(RTRIM(JobNumber)) > '') " +
                    where + " ORDER BY JobNumber ";
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
        public static DataSet GetJobSummaryListDashboard(string where)
        {
            string query = "";

            query = " SELECT JobNumber AS [Job No], aaa.Description As [Contract Type], " +
	                " JobName AS [Job Name], " +  
                    " o.OfficeName as [Office],  DepartmentName AS [Department], " + 
                    " m.Description AS [Project Manager], " +
	                " OriginalContract as [Original Contract], " +
	                " ApprovedCO AS [Approved COs], " +
	                " PendingCO AS [Pending With Proceed], " +
	                " NotApprovedCO AS [Pending No Proceed], " +
                    " CurrentContract AS [Current Contract], " +
	                " CurrentBudget AS [Current Budget], " +
	                " OriginalBudget AS [Original Budget], " +
	                " ApprovedBudget AS [Approved CO], " +
	                " PendingBudget AS [Pending Proceed CO], " +
	                " CommittedCostToDate AS [Actual To Date], " +
	                " OpenCommit AS [Open Commit], " +
	                " CostToCommit AS [Cost To Complete], " +
	                " CostToComplete AS [Revised CAC], " +
	                " Variance, " +
	                " WIPCostToComplete AS [WIP Month End CAC], " +
                    " ProjectedProfit AS [Projected Profit], " +
	                " AmountBilled AS [Amount Billed], " +
	                " AmountPaid AS [Amount Paid], " +
	                " Retention, " +
	                " CashCost AS [Cash/Cost], " +
	                " BilledCost AS [Billed/Cost], " +
	                " MaterialPOTotal AS [Material PO Total], " +
	                " CostThisMonth AS [Cost This Month], " +
	                " BillingThisMonth AS [Billing This Month], " +
                    " SubString(CONVERT(VARCHAR(10), Period,101),1,3) +  SubString(CONVERT(VARCHAR(10), Period,101),6,5) AS Period" +
                    " FROM tblJob b " + 
                    " LEFT JOIN tblJobStatus s ON b.JobStatusID = s.JobStatusID " + 
                    " LEFT JOIN tblOffice o ON b.OfficeID = o.OfficeID " + 
                    " LEFT JOIN tblDepartment d ON b.DepartmentID = d.DepartmentID " + 
                    " LEFT JOIN tblProjectManager m ON b.ProjectManagerID = m.ProjectManagerID " + 
                    " LEFT Join tblJobBalanceHistory z ON b.JobID = z.JobID " + 
                    " LEFT Join tblContractType aaa ON b.ContractTypeID = aaa.ContractTypeID " + 
                    " WHERE (jobStatus = 'WON') AND (LTRIM(RTRIM(JobNumber)) > '') " +
                    where + " ORDER BY JobNumber, Period ";
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

        public static DataSet GetJobCostListDashboard(string where)
        {
            string query = "";

            query = " SELECT " +
	                " JobNumber, " +
	                " JobName, " +
	                " Department = " + 
	                "     CASE DepartmentID " +
		            "         WHEN 0 THEN 'Martinez' " +
		            "         WHEN 1 THEN 'Industrial' " +
		            "         WHEN 2 THEN 'Utility' " +
		            "         WHEN 3 THEN 'Commercial' " +
		            "         WHEN 4 THEN 'Technology' " +
                    "         WHEN 5 THEN 'San Jose'  " +
		            "         WHEN 6 THEN 'Bakersfield' " +
		            "         WHEN 7 THEN 'Fresno'  " + 
	                "      END, " +
	                " OriginalContractAmount, " +
	                " CommittedCostToDate,  " +
	                " AmountBilled, " +
                    " Archived " +
                    " FROM tblJobCost j " +
                    where + " ORDER BY LEN(JobNumber), JobNumber ";
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

        public static void UpdateAdjustmentPercent(string jobID, string percent)
        {
            string query = "";

            query = "Update tblJob SET AdjustmentPercent =  " + percent + " Where JobID = " + jobID + " ";
                    
            try
            {
                 DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobListDashboardSummary(string where)
        {

            string query = "SELECT  " +
             " o.OfficeName as [Office],  DepartmentName AS [Department],  m.Description AS [Project Manager], c.Name AS Customer," +
             " SUM(ISNULL(z.CurrentContract, 0)) AS [Current Contract], " +
             " SUM(ISNULL(z.CommittedCostToDate, 0)) AS [Cost To Date], " +
             " SUM(ISNULL(z.ProjectedProfit, 0)) AS [Projected Profit], " +
             " SUM(ISNULL(z.AmountBilled, 0)) AS [Amount Billed], " +
             " SUM(ISNULL(z.AmountPaid, 0)) As [Amount Paid], Count(JobNumber) AS [Number of Jobs] " +
             " FROM tblJob b " +
             " LEFT JOIN tblJobStatus s ON b.JobStatusID = s.JobStatusID " +
             " LEFT JOIN tblOffice o ON b.OfficeID = o.OfficeID " +
             " LEFT JOIN tblDepartment d ON b.DepartmentID = d.DepartmentID " +
             " LEFT JOIN tblCustomer c ON b.CustomerID = c.CustomerID " +
             " LEFT JOIN tblProjectManager m ON b.ProjectManagerID = m.ProjectManagerID " +
             " LEFT JOIN tblEstimator t ON b.EstimatorID = t.EstimatorID " +
             " LEFT Join tblJobBalance z ON b.JobID = z.JobID " +
             " LEFT Join tblContractType aaa ON b.ContractTypeID = aaa.ContractTypeID " +  

            " WHERE (jobStatus = 'WON') AND (JobNumber is Not Null) " +
            where + " " +
            " GROUP BY o.OfficeName, DepartmentName, m.description, c.Name ";

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
        public static DataSet GetDashboardFlags()
        {
            string query = "SELECT * FROM tblDashboardFlags";
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
        public static string GetLastJobSummaryPeriod()
        {
            DataTable dt;
            string lastJobSummaryPeriod = "";

            string query = "SELECT MAX(Period) AS [LastPeriod] FROM tblJobBalanceHistory "; 
            try
            {
                dt =  DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (dt.Rows.Count > 0)
                    lastJobSummaryPeriod = dt.Rows[0]["LastPeriod"].ToString();
                return lastJobSummaryPeriod;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet ArchiveJobSummary(string period, string payrollDate)
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@Period", period);
            par[1] = new SqlParameter("@PayrollDate", @payrollDate);
            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_DMArchiveJobSummary", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void UpdateJobBalance(string jobNumber)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Job", jobNumber);
            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.up_DMJobBalanceUpdate", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobSummary(string jobID)
        {
            string query = "SELECT b.*, c.Description AS ContractType, m.Description As [ProjectManager], " +
                            " CommentStatus = " +
                            " CASE ISNULL(b.Comment,'') " +
                            " WHEN '' THEN 0 " +
                            " ELSE 1 " +
                            " END " +

                            " FROM tblJobBalance b " +
                            " LEFT JOIN tblJob j " +
                            " ON b.JobID = j.JobID " +
                            " LEFT JOIN tblContractType c " +
                            " ON j.ContractTypeID = c.ContractTypeID " +
                            " Left Join tblProjectManager m " +
                            " ON j.ProjectManagerID = m.ProjectManagerID        " +
                            " WHERE b.JobID =  " + jobID + "";

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
        public static DataSet GetJobSummaryHistory(string jobID, string period)
        {
            string query = "SELECT b.*, c.Description AS ContractType, m.Description As [ProjectManager], " +
                            " CommentStatus = " +
                            " CASE ISNULL(b.Comment,'') " +
                            " WHEN '' THEN 0 " +
                            " ELSE 1 " +
                            " END " +
                            " FROM tblJobBalanceHistory b " +
                            " LEFT JOIN tblJob j " +
                            " ON b.JobID = j.JobID " +
                            " LEFT JOIN tblContractType c " +
                            " ON j.ContractTypeID = c.ContractTypeID " +
                            " Left Join tblProjectManager m " +
                            " ON j.ProjectManagerID = m.ProjectManagerID        " +
                            " WHERE b.JobID =  " + jobID + " AND b.Period = '" + period + "' ";

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
        public static bool UpdateJobSummary(string jobID, string approved,  string jobCompleted, string approvedBy, string comment)
        {
            if (jobCompleted == "True")
                jobCompleted = "1";
            else
                jobCompleted = "0";
            if (approved == "True")
                approved = "1";
            else
                approved = "0";
            string query = "UPDATE tblJobBalance SET " +
                            " JobCompleted  = " + jobCompleted + ", " + 
                            " Approved      = " + approved + ", " +
                            " ApprovedBy    = '" + approvedBy + "', " +
                            " Comment       = '" + comment.Replace("'", "") + "'" +
                            " WHERE JobID   = " + jobID;
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
        //
        public static DataSet GetJobPeformanceFactorHistory(string jobID)
        {
            string query = "SELECT JobLaborPerformanceFactorWeekly, Weekend FROM tblJobLaborPerformanceFactorWeekly WHERE  JobID = " + jobID + " ORDER BY Weekend";

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
        public static DataSet GetJobDocumentInfo(string jobID)
        {
            string query = "SELECT Archived, EstimatorID, EstimateNumber, JobNumber, JobName, j.OfficeID, OfficeName, CreatedDate, DepartmentName " +
                            " FROM tblJob j " +
                            " LEFT JOIN tblDepartment d ON j.DepartmentID = d.DepartmentID " +
                            " LEFT JOIN tblOffice o ON j.OfficeID = o.OfficeID " +
                            " WHERE j.JobID = " + jobID + " ";
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
        public static DataSet GetJobOffice(string jobID)
        {
            string query = "SELECT o.* FROM tblJob j " +
                            " LEFT JOIN tblOffice o " +
                            " ON j.OfficeID = o.OfficeID " +
                            " WHERE JobID =  " + jobID + "";

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
        public static DataSet GetJobSetupSheetData(string jobID)
        {
            string query = "";

            query = " dbo.up_JCJobSheetReport  " + jobID;
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobPrequalSheetData(string where)
        {
            string query = "";

            query = " SELECT  DISTINCT" +
                    " j.JobNumber, " +
                    " j.JobName, " +
                    " j.JobDescription, " +
                    " j.JobAddress1, " +
                    " j.JobAddress2, " +
                    " LTRIM(RTRIM(j.JobCity)) + ' '  + LTRIM(RTRIM(j.JobState)) + ' ' +  LTRIM(RTRIM(j.JobZip))  AS JobCityStateZip, " +
                    " j.CustomerID, " +
                    " c.Name AS BillingName, " +
                    " j.BillingAddress1 AS BillingAddr1, " +
                    " j.BillingAddress2 AS BillingAddr2, " +
                    " j.BillingCity, " +
                    " j.BillingState, " +
                    " j.BillingZipCode, " +
                    " j.BillingPhone, " +
                    " j.BillingRep, " +
                    " j.BillingAsCustomer, " +
                    " aa.Description AS [CustomerClass], " +
                    " j.CustomerIsSubcontractor, " +
                    " j.OwnerName, " +
                    " LTRIM(RTRIM(ISNULL(j.OwnerAddress1,''))) + ' ' + LTRIM(RTRIM(ISNULL(j.OwnerAddress2,''))) AS [OwnerAddress], " +
                    " j.OwnerCity, " +
                    " j.OwnerState, " +
                    " j.OwnerZipCode, " +
                    " j.OwnerPhone, " +
                    " j.OwnerRep, " +
                    " j.OwnerAsCustomer, " +
                    " bb.Description AS [WorkType], " +
                    " cc.Description AS [ContractType], " +
                    " m.Description AS Manager, " +
                    " j.ContractStartDate, " +
                    " j.ContractEstComplDate, " +
                    " j.OriginalContractAmount, " +
                    " j.JobFinalContractAmount, " +
                    " j.DesignBuild, " +
                    " dbo.GetJobPrequalKeywords(j.JobID) +  " +
                    " ISNULL(j.ScopeOfWork, '') AS ScopeOfWork, " +
                    " CommittedCostToDateLaborHours100, " +
                    " CostToCostCompletePercentage, " +
                    " DepartmentName " +
                    " FROM tblJOB j " +
                    " LEFT JOIN tblProjectManager m on j.ProjectManagerID = m.ProjectManagerID " +
                    " LEFT JOIN tblCustomer c ON j.CustomerID = c.CustomerID " +
                    " LEFT JOIN tblOwnerClass aa ON j.OwnerClassID = aa.OwnerClassID " +
                    " LEFT JOIN tblWorkType bb ON j.WorkTypeID = bb.WorkTypeID " +
                    " LEFT JOIN tblContractType cc ON j.ContractTypeID = cc.ContractTypeID " +
                    " LEFT JOIN tblJobBalance b ON j.JobID = b.JobID " +
                    " LEFT JOIN tblDepartment d ON j.DepartmentID = d.DepartmentID " +
                    " LEFT JOIN tblJobPrequalKeyword p ON j.JobID = p.JobID " +
                    " LEFT JOIN tblPrequalKeyword pp ON p.PrequalKeywordID = pp.PrequalKeywordID " +
                    where;
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void UpdateJobStatistics(string jobNumber, string period)
        {
            if (period.Trim().Length == 0)
            {
                try
                {
                    SqlParameter[] par = new SqlParameter[1];

                    par[0] = new SqlParameter("@SelectedJob", jobNumber);
                    DataBaseUtil.ExecuteParDataset("up_DMJobCostCodeUpdateNewVersion", CCEApplication.Connection, CommandType.StoredProcedure, par);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (period.Trim().Length == 0)
            {
                try
                {
                    SqlParameter[] par = new SqlParameter[1];

                    par[0] = new SqlParameter("@Job", jobNumber);
                    DataBaseUtil.ExecuteParDataset("up_DMJobBalanceUpdate", CCEApplication.Connection, CommandType.StoredProcedure, par);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    SqlParameter[] par = new SqlParameter[2];

                    par[0] = new SqlParameter("@Job", jobNumber);
                    par[1] = new SqlParameter("@PeriodDate", period);
                    DataBaseUtil.ExecuteParDataset("up_DMJobBalanceUpdateHistory", CCEApplication.Connection, CommandType.StoredProcedure, par);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            if (period.Trim().Length == 0)
            {
                try
                {
                    SqlParameter[] par = new SqlParameter[1];

                    par[0] = new SqlParameter("@JobNumber", jobNumber);
                    DataBaseUtil.ExecuteParDataset("dbo.up_DMJobUpdate", CCEApplication.Connection, CommandType.StoredProcedure, par);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //
        public static DataSet GetJobBalance(string jobID)
        {
            string query = "";

            query = " SELECT *, dbo.GetJobBaselineProfit('" + jobID + "') AS [CalcBaseLineProfit] FROM tblJobBalance WHERE JobID = " + jobID;
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
        public static DataSet GetJobTemplate(string jobNumber)
        {
            string query = "";

            if (jobNumber.Trim().Length == 0)
                jobNumber = "0";
            query = "SELECT  j.* " +
                    " FROM tblJob j " +
                    " WHERE j.JobNumber =  '" + jobNumber + "' ";
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
        public static DataSet GetEstimateTemplate(string estimateNumber)
        {
            string query = "";

            if (estimateNumber.Trim().Length == 0)
                estimateNumber = "0";
            query = "SELECT  j.* " +
                    " FROM tblJob j " +
                    " WHERE j.EstimateNumber =  '" + estimateNumber + "' ";
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
        public static DataSet GetJob(string jobID)
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@UserID", Security.Security.LoginID);
            par[1] = new SqlParameter("@JobID", jobID);

            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_JCGetJobByJobID", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetRevision(string jobID)
        {
            string query = "";

            if (jobID.Trim().Length == 0)
                jobID = "0";
            query = "SELECT  EstimateNumber,  JobNumber " +
                    " FROM tblJob j " +
                    " WHERE j.JobID =  " + jobID;
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
            bool ret;
            DataTable dt;
            string query = "";

            jobNameOld = "";
            if (jobID == "")
            {
                jobNameOld = "";
                ret = Insert();
            }
            else
            {
                query = "SELECT JobName FROM tblJob WHERE JobID = " + jobID + " ";
                dt = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (dt.Rows.Count > 0)
                    jobNameOld = dt.Rows[0]["JobName"].ToString();
                ret = Update();
            }
            try
            {
                query = "SELECT EstimateNumber, JobNumber, CreatedDate, OfficeName, DepartmentName, t.Description as [ContractTypeName], b.Description as [BidBondName] " +
                            " FROM tblJob j " +
                            " LEFT JOIN tblOffice o ON j.OfficeID = o.OfficeID " +
                            " LEFT JOIN tblDepartment d ON j.DepartmentID = d.DepartmentID " +
                            " LEFT JOIN tblBidBond b ON j.BidBondID = b.BidBondID " +
                            " LEFT JOIN tblContractType t ON j.ContractTypeID = t.ContractTypeID " +
                            " WHERE JobID = " + jobID + "";
                dt = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    estimateNumber = dt.Rows[0]["EstimateNumber"].ToString();
                    jobNumber = dt.Rows[0]["JobNumber"].ToString();
                    jobCreatedDate = dt.Rows[0]["CreatedDate"].ToString();
                    officeName = dt.Rows[0]["OfficeName"].ToString();
                    departmentName = dt.Rows[0]["DepartmentName"].ToString();
                    bidBondName = dt.Rows[0]["BidBondName"].ToString();
                    contractTypeName = dt.Rows[0]["ContractTypeName"].ToString();
                    query = "Select * FROM tblJobChangeOrder WHERE JobID = " + jobID + " ";
                    dt = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        query = " INSERT INTO tblJobChangeOrder(JobID, JobChangeOrderNumber, JobChangeOrderStatus, JobChangeOrderDescription, JobChangeOrderLastUpdate, AuditUserID) " +
                                 " VALUES('" + jobID + "', 0, 'PENDING','ORIGINAL CONTRACT',GETDATE(), '" + Security.Security.LoginID + "')";
                        DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                    }
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.RedWriteCreateSB)
                    {
                        if (jobNumber.Trim().Length > 0)
                        {
                            SqlParameter[] par = new SqlParameter[1];

                            par[0] = new SqlParameter("@JobNumber", jobNumber);
                            DataBaseUtil.ExecuteParDataset("up_DMJobUpdateStarbuilderJob", CCEApplication.Connection, CommandType.StoredProcedure, par);
                        }
                    }
                }
                UpdateForms();
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool Insert()
        {
            string query = "INSERT INTO tblJob( officeID, departmentID, EstimateNumber, JobNumber," +
                            " jobName, " +
                            " jobDescription, " +
                            " jobAddress1, " +
                            " jobAddress2, " +
                            " jobCity, " +
                            " jobState, " +
                            " jobZip, " +
                            " jobPhone, " +
                            " customerID, " +
                            " billingAsCustomer, " +
                            " billingAddress1, " +
                            " billingAddress2, " +
                            " billingCity, " +
                            " billingState, " +
                            " billingZipcode, "+
                            " billingPhone, " +
                            " billingRep, " +
                            " ownerClassID, " +
                            " contractorAsCustomer, " +
                            " contractorName, " +
                            " contractorAddress1, " +
                            " contractorAddress2, " +
                            " contractorCity, " +
                            " contractorState, " +
                            " contractorZipCode, " +
                            " contractorPhone, " +
                            " contractorRep, " +
                            " ownerAsCustomer, " +
                            " ownerName, " +
                            " ownerAddress1, " +
                            " ownerAddress2, " +
                            " ownerCity, " +
                            " ownerState, " +
                            " ownerZipCode, " +
                            " ownerPhone, " +
                            " ownerRep, " +
                            " OwnerContractor, " +
                            " laborRates, " +
                            " alphaCodes, " +
                            " otherLabor, " +
                            " materialMU, " +
                            " otherMaterial, " +
                            " releaseNumber, " +
                            " cceEquip, " +
                            " outsideRentalMU, " +
                            " subcontractMU, " +
                            " otherMU, " +
                            " workTypeID, " +
                            " contractTypeID, " +
                            " projectManagerID, " +
                            " estimatorID, " +
                            " superintendentID, " +
                            " foremanID, " +
                            " contractNumber, " +
                            " originalContractAmount, " +
                            " jobFinalContractAmount, " +
                            " copyOfVendorInvoicesNeeded, " +
                            " subcontractors, " +
                            " certifiedPayRoll, " +
                            " bondID, " +
                            " bondDate, " +
                            " bondNumber, " +
                            " poNumber, " +
                            " contractStartDate, " +
                            " contractEstCompldate, " +
                            " jurisdiction, " +
                            " masterJobNumber, " +
                            " retainageID, " +
                            " insuranceProgramID, " +
                            " totalCLPUAmount, " +
                            " GLIABName, " +
                            " UMBRLName, " +
                            " preliminaryNotice, " +
                            " preliminaryDateMailed, " +
                            " preliminaryMailedBy, " +
                            " comment, " +
                            " postedToFileDate, " +
                            " postedToFileBy, " +
                            " jobStatusID, " +
                            " CustomerIsSubcontractor, " +
                            " customerSubcontractors, " +
                            " WIPRequired, " +
                            " WIPStatus, " +
                            " WIPEntryID, " +
                            " trade, " +
                            " lenderID, " +
                            " lenderName, " +
                            " lenderAddress, " +
                            " lenderCity, " +
                            " lenderState, " +
                            " lenderZip, " +
                            " releaseToCustomer, " +
                            " signedDaily, " +
                            " signedWorkOrder, " +
                            " TimeSheetSigned, " +
                            " SubcontractorInvoicesRequired, " +
                            " customerAuthorizedForm, " +
                            " trackingSpreadsheets, " +
                            " multipleCopies, " +
                            " billingFrequency, " +
                            " clientPercentNotification, " +
                            " lienRelease, " +
                            " cutOffDate, " +
                            " bidDate, " +
                            " BidTime, " +
                            " PreBidAmount, " +
                            " FinalBidAmount, " +
                            " DesignBuild, " +
                            " DrawingReceived, " +
                            " QuotesRequired, " +
                            " BidForm, " +
                            " bidWalkDate, " +
                            " bidWalkTime, " +
                            " DeliveryMethod, " +
                            " architectEngineer, " +
                            " AddendumReceived, " +
                            " jobEmail, " +
                            " jobFax, " + 
                            " bidTo, " +
                            " JobCreatedBy, " +
                            " jobUpdatedBy, " +
                            " wonLostDate, " +
                            " meetingDate, " +
                            " meetingTime, " +
                            " reviewDate, " +
                            " reviewTime, " +
                            " over250K, " +
                            " over1M, " +
                            " void, " +
                            " archived, " +
                            " revisionJobID, " +
                            " revisionID, " +
                            " bidBondID, " +
                            " EstimateHandoff, " +
                            " EstimateHandoffGrade, " +
                            " PMHandoff, " +
                            " PMHandoffGrade, " +
                            " ProjectStartupMeeting, " +
                            " salesRepID, " +
                            " jobTechID, " +
                            " jobCostLevelCode, " +
                            " billingLevelCode, " +
                            " jobCertifiedFlag, " +
                            " jobTaxFlag, " +
                            " jobValidationCode, " +
                            " jobGLAccount, " +
                            " jobOverheadEquipment, " +
                            " JobOverheadLabor, " +
                            " jobOverheadMaterial, " +
                            " jobOverheadSubcontractor, " +
                            " jobOverheadOther, " +
                            " jobPercentCompletion, " +
                            " jobOwnerCompletion, " +
                            " jobBurdenPercent, " +
                            " jobSalesTaxPercent, "  +
                            " jobBillingType, " +
                            " jobSaveHistoryFlag, " +
                            " jobCertifiedReportType, " +
                            " printStatementOfCompliance, " +
                            " printAlwaysPrintReport, " +
                            " printDeductionDetail, " +
                            " certifiedContractorOrSubcontractor, " +
                            " CertifiedWeekNumber, " +
                            " LastReportNumber, " +
                            " NextReportNumber, " +
                            " DropOffComplianceReport, " +
                            " ProjectCloseoutMeeting, " +
                            " AuditUserID, " +
                            " Duration, " +
                            " Dashboard, " +
                            " TrackChangeOrder, " +
                            " InsuranceRequiredToBeReviewed, " +
                            " OCIPClosedDate, " +
                            " OCIPClosed, " +
                            " Competitive, " +
                            " CustomerComment, " +
                            " ScopeOfWork, " +
                            " WIPComments) VALUES ( " +
                            officeID + ", " +
                            departmentID + ", " +
                            "'" + estimateNumber + "', " +
                            "'" + jobNumber + "', " +
                            "'" + jobName + "', " +
                            "'" + jobDescription + "', " +
                            "'" + jobAddress1 + "', " +
                            "'" + jobAddress2 + "', " +
                            "'" + jobCity + "', " +
                            "'" + jobState + "', " +
                            "'" + jobZip + "', " +
                            "'" + jobPhone + "', " +
                            " " + customerID + ", " +
                            " " + billingAsCustomer + ", " +
                            " '" + billingAddress1 + "', " +
                            " '" + billingAddress2 + "', " +
                            " '" + billingCity + "', " +
                            " '" + billingState + "', " +
                            " '" + billingZipCode + "', " +
                            " '" + billingPhone + "', " +
                            " '" + billingRep + "', " +
                            " " + ownerClassID + ", " +
                             contractorAsCustomer + ", " +
                            "'" + contractorName + "', " +
                            "'" + contractorAddress1 + "', " +
                            "'" + contractorAddress2 + "', " +
                            "'" + contractorCity + "', " +
                            "'" + contractorState + "', " +
                            "'" + contractorZipCode + "', " +
                            "'" + contractorPhone + "', " +
                            "'" + contractorRep + "', " +
                            ownerAsCustomer + ", " +
                            "'" + ownerName + "', " +
                            "'" + ownerAddress2 + "', " +
                            "'" + ownerAddress1 + "', " +
                            "'" + ownerCity + "', " +
                            "'" + ownerState + "', " +
                            "'" + ownerZipCode + "', " +
                            "'" + ownerPhone + "', " +
                            "'" + ownerRep + "', " +
                            "'" + ownerContractor + "', " +
                            laborRates + ", " +
                            "'" + alphaCodes + "', " +
                            "'" + otherLabor + "', " +
                            materialMU + ", " +
                            "'" + otherMaterial + "', " +
                            "'" + releaseNumber + "', " +
                            "'" + cceEquip + "', " +
                            outsideRentalMU + ", " +
                            subcontractMU + ", " +
                            "" + otherMU + ", " +
                            workTypeID + ", " +
                            contractTypeID + ", " +
                            projectManagerID + ", " +
                            estimatorID + ", " +
                            superintendentID + ", " +
                            foremanID + ", " +
                            "'" + contractNumber + "', " +
                            originalContractAmount + ", " +
                             jobFinalContractAmount + ", " +
                            copyOfVendorInvoicesNeeded + ", " +
                            subcontractors + ", " +
                            certifiedPayRoll + ", " +
                            bondID + ", " +
                            "" + bondDate + ", " +
                            "'" + bondNumber + "', " +
                            "'" + poNumber + "', " +
                            "" + contractStartDate + ", " +
                            "" + contractEstCompldate + ", " +
                            "'" + jurisdiction + "', " +
                            "'" + masterJobNumber + "', " +
                            retainageID + ", " +
                            insuranceProgramID + ", " +
                            totalCLPUAmount + ", " +
                            "'" + GLIABName + "', " +
                            "'" + UMBRLName + "', " +
                            preliminaryNotice + ", " +
                            "" + preliminaryDateMailed + ", " +
                            "'" + preliminaryMailedBy + "', " +
                            "'" + comment + "', " +
                            "" + postedToFileDate + ", " +
                            "'" + postedToFileBy + "', " +
                            jobStatusID + ", " +
                            customerIsSubcontractor + ", " +
                            "'" + customerSubcontractors + "', " +
                            WIPRequired + ", " +
                            "'" + WIPStatus + "', " +
                            WIPEntryID + ", " +
                            "'" + trade + "', " +
                            lenderID + ", " +
                            "'" + lenderName + "', " +
                            "'" + lenderAddress + "', " +
                            "'" + lenderCity + "', " +
                            "'" + lenderState + "', " +
                            "'" + lenderZip + "', " +
                            "'" + releaseToCustomer + "', " +
                            signedDaily + ", " +
                            signedWorkOrder + ", " +
                            timeSheetSigned + ", " +
                            subcontractorInvoicesRequired + ", " +
                            customerAuthorizedForm + ", " +
                            trackingSpreadsheets + ", " +
                            multipleCopies + ", " +
                            billingFrequency + ", " +
                            clientPercentNotification + ", " +
                            lienRelease + ", " +
                            "" + cutOffDate + ", " +
                            "" + bidDate + ", " +
                            "'" + bidTime + "', " +
                            preBidAmount + ", " +
                            finalBidAmount + ", " +
                            designBuild + ", " +
                            drawingReceived + ", " +
                            quotesRequired + ", " +
                            bidForm + ", " +
                            "" + bidWalkDate + ", " +
                            "'" + bidWalkTime + "', " +
                            "'" + deliveryMethod + "', " +
                            "'" + architectEngineer + "', " +
                            "'" + addendumReceived + "', " +
                            "'" + jobEmail + "', " +
                            "'" + jobFax + "', " + 
                            "'" + bidTo + "', " +
                            "'" + jobCreatedBy + "', " +
                            "'" + jobUpdatedBy + "', " +
                            "" + wonLostDate + ", " +
                            "" +  meetingDate + ", " +
                            "'" + meetingTime + "', " +
                            "" + reviewDate + ", " +
                            "'" + reviewTime + "', " +
                            over250K + ", " +
                            over1M + ", " +
                            voided + ", " +
                            archived + ", " +
                            revisionJobID + ", " +
                            revisionID + ", " +
                            bidBondID + ", " +
                            estimateHandoff + ", " +
                            "'" + estimateHandoffGrade + "', " +
                            pmHandoff + ", " +
                            "'" + pmHandoffGrade + "', " +
                            projectStartupMeeting + ", " + 
                            salesRepID + ", " +
                            jobTechID + ", " +
                            "'" + jobCostLevelCode + "', " +
                            "'" + billingLevelCode + "', " +
                            jobCertifiedFlag + ", " +
                            jobTaxFlag + ", " +
                            "'" + jobValidationCode + "', " +
                            "'" + jobGLAccount + "', " +
                            jobOverheadEquipment + ", " +
                            jobOverheadLabor + ", " +
                            jobOverheadMaterial + ", " +
                            jobOverheadSubcontractor + ", " +
                            jobOverheadOther + ", " +
                            jobPercentCompletion + ", " +
                            jobOwnerCompletion + ", " +
                            jobBurdenPercent + ", " +
                            jobSalesTaxPercent + ", " +
                            "'" + jobBillingType + "', " +
                            jobSaveHistoryFlag + ", " +
                            "'" + jobCertifiedReportType + "', " +
                            printStatementOfCompliance + ", " +
                            printAlwaysPrintReport + ", " +
                            printDeductionDetail + ", " + 
                            "'" + certifiedContractorOrSubcontractor + "', " + 
                            certifiedWeekNumber + ", " +
                            lastReportNumber + ", " +
                            nextReportNumber + ", " +
                            dropOffComplianceReport + ", " +
                            projectCloseoutMeeting + ", " +
                            "'" + Security.Security.LoginID + "', " +
                            "'" + duration + "', " +
                            dashboard + ", " +
                            trackChangeOrder + ", " +
                            insuranceRequiredToBeReviewed + ", " +
                            OCIPClosedDate + ", " +
                            OCIPClosed + ", " +
                            competitive + ", " +
                            "'" + customerComment + "', " +
                            "'" + scopeOfWork + "', " +
                            "'" + WIPComments + "') " + 
                            " Select @@IDENTITY ";
            try
            {
                jobID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                if (jobID.Length != 0)
                {
                    query = " INSERT INTO tblJobChangeOrder(JobID, JobChangeOrderNumber, JobChangeOrderStatus, JobChangeOrderDescription, JobChangeOrderLastUpdate, AuditUserID) " +
                             " VALUES('" + jobID + "', 0, 'PENDING','ORIGINAL CONTRACT',GETDATE(), '" + Security.Security.LoginID + "')";
                    DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                }
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
            string query = "UPDATE tblJob SET " +
                            " OfficeID = " + officeID + ", " +
                            " departmentID = " + departmentID + ", " +
                            " estimateNumber = '" + estimateNumber + "'," +
                            " jobNumber = '" + jobNumber + "', " +
                            " jobName = '" + jobName + "', " +
                            " jobDescription = '" + jobDescription + "', " +
                            " jobAddress1 = '" + jobAddress1 + "', " +
                            " jobAddress2 = '" + jobAddress2 + "', " +
                            " jobCity = '" + jobCity + "', " +
                            " jobState = '" + jobState + "', " +
                            " jobZip = '" + jobZip + "', " +
                            " jobPhone = '" + jobPhone + "', " +
                            " customerID = " + customerID + ", " +
                            " billingAsCustomer = " + billingAsCustomer + ", " +
                            " billingAddress1 = '" + billingAddress1 + "', " +
                            " billingAddress2 = '" + billingAddress2 + "', " +
                            " billingCity = '" + billingCity + "', " +
                            " billingState = '" + billingState + "', " +
                            " billingZipCode = '" + billingZipCode + "', " +
                            " billingPhone = '" + billingPhone + "', " +
                            " billingRep = '" + billingRep + "', " +
                            " ownerClassID = " + ownerClassID + ", " +
                            " contractorAsCustomer = " + contractorAsCustomer + ", " +
                            " contractorName = '" + contractorName + "', " +
                            " contractorAddress1 = '" + contractorAddress1 + "', " +
                            " contractorAddress2 = '" + contractorAddress2 + "', " +
                            " contractorCity = '" + contractorCity + "', " +
                            " contractorState = '" + contractorState + "', " +
                            " contractorZipCode = '" + contractorZipCode + "', " +
                            " contractorPhone = '" + contractorPhone + "', " +
                            " contractorRep = '" + contractorRep + "', " +
                            " ownerAsCustomer = " + ownerAsCustomer + ", " +
                            " ownerName = '" + ownerName + "', " +
                            " ownerAddress1 = '" + ownerAddress1 + "', " +
                            " ownerAddress2 = '" + ownerAddress2 + "', " +
                            " ownerCity = '" + ownerCity + "', " +
                            " ownerState = '" + ownerState + "', " +
                            " ownerZipCode = '" + ownerZipCode + "', " +
                            " ownerPhone = '" + ownerPhone + "', " +
                            " ownerRep = '" + ownerRep + "', " +
                            " ownerContractor = '" + ownerContractor + "', " +
                            " laborRates = " + laborRates + ", " +
                            " alphaCodes = '" + alphaCodes + "', " +
                            " otherLabor = '" + otherLabor + "', " +
                            " materialMU = " + materialMU + ", " +
                            " otherMaterial = '" + otherMaterial + "', " +
                            " releaseNumber = '" + releaseNumber + "', " +
                            " cceEquip = '" + cceEquip + "', " +
                            " outsideRentalMU = " + outsideRentalMU + ", " +
                            " subcontractMU = " + subcontractMU + ", " +
                            " otherMU = '" + otherMU + "', " +
                            " workTypeID = " + workTypeID + ", " +
                            " contractTypeID = " + contractTypeID + ", " +
                            " projectManagerID = " + projectManagerID + ", " +
                            " estimatorID = " + estimatorID + ", " +
                            " superintendentID = " + superintendentID + ", " +
                            " foremanID = " + foremanID + ", " +
                            " contractNumber = '" + contractNumber + "', " +
                            " originalContractAmount = " + originalContractAmount + ", " +
                            " jobFinalContractAmount = " + jobFinalContractAmount + ", " +
                            " copyOfVendorInvoicesNeeded = " + copyOfVendorInvoicesNeeded + ", " +
                            " subcontractors = " + subcontractors + ", " +
                            " certifiedPayRoll = " + certifiedPayRoll + ", " +
                            " bondID = " + bondID + ", " +
                            " bondDate = " + bondDate + ", " +
                            " bondNumber = '" + bondNumber + "', " +
                            " poNumber = '" + poNumber + "', " +
                            " contractStartDate = " + contractStartDate + ", " +
                            " contractEstCompldate = " + contractEstCompldate + ", " +
                            " jurisdiction = '" + jurisdiction + "', " +
                            " masterJobNumber = '" + masterJobNumber + "', " +
                            " retainageID = " + retainageID + ", " +
                            " insuranceProgramID = " + insuranceProgramID + ", " +
                            " totalCLPUAmount = " + totalCLPUAmount + ", " +
                            " GLIABName = '" + GLIABName + "', " +
                            " UMBRLName = '" + UMBRLName + "', " +
                            " preliminaryNotice = " + preliminaryNotice + ", " +
                            " preliminaryDateMailed = " + preliminaryDateMailed + ", " +
                            " preliminaryMailedBy = '" + preliminaryMailedBy + "', " +
                            " comment = '" + comment + "', " +
                            " postedToFileDate = " + postedToFileDate + ", " +
                            " postedToFileBy = '" + postedToFileBy + "', " +
                            " jobStatusID  = " + jobStatusID + ", " +
                            " customerIsSubcontractor = " + customerIsSubcontractor + ", " +
                            " customerSubcontractors = '" + customerSubcontractors + "', " +
                            " WIPRequired = " + WIPRequired + ", " +
                            " WIPStatus = '" + WIPStatus + "', " +
                            " WIPEntryID = " + WIPEntryID + ", " +
                            " trade = '" + trade + "', " +
                            " lenderID = " + lenderID + ", " +
                            " lenderName = '" + lenderName + "', " +
                            " lenderAddress = '" + lenderAddress + "', " +
                            " lenderCity = '" + lenderCity + "', " +
                            " lenderState = '" + lenderState + "', " +
                            " lenderZip = '" + lenderZip + "', " +
                            " releaseToCustomer = '" + releaseToCustomer + "', " +
                            " signedDaily = " + signedDaily + ", " +
                            " SignedWorkOrder = " + signedWorkOrder + ", " +
                            " timeSheetSigned = " + timeSheetSigned + ", " +
                            " subcontractorInvoicesRequired = " + subcontractorInvoicesRequired + ", " +
                            " customerAuthorizedForm = " + customerAuthorizedForm + ", " +
                            " TrackingSpreadsheets = " + trackingSpreadsheets + ", " +
                            " multipleCopies = " + multipleCopies + ", " +
                            " billingFrequency = " + billingFrequency + ", " +
                            " clientPercentNotification = " + clientPercentNotification + ", " +
                            " lienRelease = " + lienRelease + ", " +
                            " cutOffDate = " + cutOffDate + ", " +
                            " bidDate = " + bidDate + ", " +
                            " bidTime = '" + bidTime + "', " +
                            " preBidAmount = " + preBidAmount + ", " +
                            " finalBidAmount = " + finalBidAmount + ", " +
                            " designBuild = " + designBuild + ", " +
                            " drawingReceived = " + drawingReceived + ", " +
                            " QuotesRequired = " + quotesRequired + ", " +
                            " bidForm = " + bidForm + ", " +
                            " bidWalkDate = " + bidWalkDate + ", " +
                            " bidWalkTime = '" + bidWalkTime + "', " +
                            " deliveryMethod = '" + deliveryMethod + "', " +
                            " architectEngineer = '" + architectEngineer + "', " +
                            " addendumreceived = '" + addendumReceived + "', " +
                            " jobEmail = '" + jobEmail + "', " +
                            " jobFax = '" + jobFax + "', " +
                            " bidTo = '" + bidTo + "', " +
                            " JobCreatedBy = '" + jobCreatedBy + "', " +
                            " jobUpdatedBy = '" + jobUpdatedBy + "', " +
                            " wonLostDate = " + wonLostDate + ", " +
                            " meetingDate = " + meetingDate + ", " +
                            " meetingTime = '" + meetingTime + "', " +
                            " reviewDate = " + reviewDate + ", " +
                            " reviewTime = '" + reviewTime + "', " +
                            " over250K = " + over250K + ", " +
                            " over1M = " + over1M + ", " +
                            " void = " + voided + ", " +
                            " archived = " + archived + ", " +
                            " revisionJobID = " + revisionJobID + ", " +
                            " revisionID = " + revisionID + ", " +
                            " bidBondID = " + bidBondID + ", " +
                            " EstimateHandoff = " + estimateHandoff + ", " +
                            " EstimateHandoffGrade = '" + estimateHandoffGrade + "', " +
                            " PMHandoff = " + pmHandoff + ", " +
                            " PMHandoffGrade = '" + pmHandoffGrade + "', " +
                            " ProjectStartupMeeting = " + projectStartupMeeting + ", " +
                            " salesRepID = " + salesRepID + ", " +
                            " jobTechID = " + jobTechID + ", " +
                            " jobCostLevelCode = '" + jobCostLevelCode + "', " + 
                            " billingLevelCode = '" + billingLevelCode + "', " +
                            " jobCertifiedFlag = " + jobCertifiedFlag + ", " +
                            " jobTaxFlag = " + jobTaxFlag + ", " +
                            " jobValidationCode = '" + jobValidationCode + "', " +
                            " jobGLAccount = '" + jobGLAccount + "', " +
                            " jobOverheadEquipment = " + jobOverheadEquipment + ", " +
                            " JobOverheadLabor = " + jobOverheadLabor + ", " +
                            " jobOverheadMaterial = " + jobOverheadMaterial + ", " +
                            " jobOverheadSubcontractor = " + jobOverheadSubcontractor + ", " +
                            " jobOverheadOther = " + jobOverheadOther + ", " +
                            " jobPercentCompletion = " + jobPercentCompletion + ", " +
                            " jobOwnerCompletion = " + jobOwnerCompletion + ", " +
                            " jobBurdenPercent = " + jobBurdenPercent + ", " +
                            " jobSalesTaxPercent = " + jobSalesTaxPercent + ", " +
                            " jobBillingType = '" + jobBillingType + "', " +
                            " jobSaveHistoryFlag = " + jobSaveHistoryFlag + ", " +
                            " jobCertifiedReportType = '" + jobCertifiedReportType + "', " +
                            " printStatementOfCompliance = " + printStatementOfCompliance + ", " +
                            " printAlwaysPrintReport = " + printAlwaysPrintReport + ", " +
                            " printDeductionDetail = " + printDeductionDetail + ", " +
                            " certifiedContractorOrSubcontractor = '" + certifiedContractorOrSubcontractor + "', " +
                            " CertifiedWeekNumber = " + certifiedWeekNumber + ", " +
                            " LastReportNumber = " + lastReportNumber + ", " +
                            " NextReportNumber = " + nextReportNumber + ", " +
                            " DropOffComplianceReport = " + dropOffComplianceReport + ", " +
                            " ProjectCloseoutMeeting = " + projectCloseoutMeeting + ", " +
                            " WIPComments       = '"  + WIPComments + "', " +
                            " CustomerComment   = '" + customerComment + "', " +
                            " ScopeOfWork       = '" + scopeOfWork + "', " +
                            " AuditUserId       = '" + Security.Security.LoginID + "', " +
                            " Duration          = '" + duration + "', " +
                            " Dashboard         = " + dashboard + ", " +
                            " TrackChangeOrder  = " + trackChangeOrder + ", " +
                            " InsuranceRequiredToBeReviewed = " + insuranceRequiredToBeReviewed + ", " +
                            " OCIPClosedDate                = " + OCIPClosedDate + ", " +
                            " OCIPClosed                    = " + OCIPClosed + ", " +
                            " Competitive                   = " + competitive + " " +
                            " WHERE JobID = " + jobID;
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
        //
        private string GetEstimatorServer()
        {
            DataSet ds;
            string estimatorServer = "";
            if (String.IsNullOrEmpty(estimatorID) || estimatorID == "Null")
                estimatorID = "0";
            string query = "SELECT  ServerName as [ServerName] from tblEstimator e " + 
                            " INNER JOIN tblUser u ON e.Description = u.UserName " +
                            " INNER JOIN tblOffice o ON u.OfficeID = o.OfficeID " +
                            " WHERE e.EstimatorID = " + estimatorID ;
            try
            {
                ds =  DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    query = "SELECT  ServerName AS [ServerName] from tblOffice WHERE OfficeName = 'MARTINEZ'";
                    ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                }
                else
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                return estimatorServer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private string GetJobServer()
        {
            DataSet ds;
            string estimatorServer = "";
            string query = "SELECT  ServerName as [ServerName] from tblOffice " +
                            " WHERE OfficeID = " + officeID;
            try
            {
                ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    query = "SELECT  ServerName AS [ServerName] from tblOffice WHERE OfficeName = 'MARTINEZ'";
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                }
                else
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                return estimatorServer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private void UpdateForms()
        {
            string estimateServer = GetEstimatorServer();
            string jobServer = GetJobServer();
            string sourceEstimateLocationOld = "";
            string archiveEstimateLocationOld = "";
            string sourceEstimateLocation = "";
            string archiveEstimateLocation = "";
            string sourceJobLocationOld = "";
            string archiveJobLocationOld = "";
            string sourceJobLocation = "";
            string archiveJobLocation = "";
            DirectoryInfo dir;
            //
            try
            {
                archiveEstimateLocation = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Archive\\" +
                         officeName + "\\" +
                         Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\";
                sourceEstimateLocation = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Active\\" +
                                        officeName + "\\" +
                                        Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\";
                archiveJobLocation = jobServer + "\\" + CCEApplication.JobsLocation + departmentName + "\\" + "Archive\\" +
                                    Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\";
                sourceJobLocation = jobServer + "\\" + CCEApplication.JobsLocation + departmentName + "\\" + "Active\\" +
                                    Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\";
                dir = new DirectoryInfo(@archiveEstimateLocation);
                if (!dir.Exists)
                    dir.Create();
                dir = new DirectoryInfo(@sourceEstimateLocation);
                if (!dir.Exists)
                    dir.Create();
                dir = new DirectoryInfo(@archiveJobLocation);
                if (!dir.Exists)
                    dir.Create();
                dir = new DirectoryInfo(@sourceJobLocation);
                if (!dir.Exists)
                    dir.Create();
                // 
                // Change Job Name 
                // 
                if (jobNameOld.Length > 0 && jobName != jobNameOld)
                {
                    archiveEstimateLocationOld = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Archive\\" +
                        officeName + "\\" +
                        Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                        estimateNumber + " " + jobNameOld + "\\";
                    sourceEstimateLocationOld = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Active\\" +
                                            officeName + "\\" +
                                            Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                                            estimateNumber + " " + jobNameOld + "\\";
                    archiveJobLocationOld = jobServer + "\\" + CCEApplication.JobsLocation + departmentName + "\\" + "Archive\\" +
                                        Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                                         JobNumber + " " + estimateNumber + " " + jobNameOld + "\\";
                    sourceJobLocationOld = jobServer + "\\" + CCEApplication.JobsLocation + departmentName + "\\" + "Active\\" +
                                        Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                                         JobNumber + " " + estimateNumber + " " + jobNameOld + "\\";
                }
                //
                if (!String.IsNullOrEmpty(estimateNumber))
                {
                    archiveEstimateLocation = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Archive\\" +
                        officeName + "\\" +
                        Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                        estimateNumber + " " + jobName + "\\";
                    sourceEstimateLocation = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Active\\" +
                                            officeName + "\\" +
                                            Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                                            estimateNumber + " " + jobName + "\\";
                }
                //
                if (!String.IsNullOrEmpty(jobNumber))
                {
                    sourceJobLocation = jobServer + "\\" + CCEApplication.JobsLocation + departmentName + "\\" + "Active\\" +
                                        Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                                         JobNumber + " " + estimateNumber + " " + jobName + "\\";

                }
                //
                // Create Estimate Folder
                //
                if (!String.IsNullOrEmpty(estimateNumber) && String.IsNullOrEmpty(jobNumber))
                {
                    if (!FileSystem.DirectoryExists(@sourceEstimateLocation))
                    {
                        if (jobNameOld.Length > 0 && jobName != jobNameOld)
                        {
                            if (FileSystem.DirectoryExists(@sourceEstimateLocationOld))
                            {
                                FileSystem.CopyDirectory(@sourceEstimateLocationOld, @sourceEstimateLocation);
                                FileSystem.DeleteDirectory(@sourceEstimateLocationOld, DeleteDirectoryOption.DeleteAllContents);
                            }
                        }
                        else
                        {
                            CopyFiles(CCEApplication.FormsLocation, sourceEstimateLocation, false);
                        }
                    }
                }
                //
                // Create a Job Folder without Estimate Number
                //
                if (!String.IsNullOrEmpty(jobNumber) && String.IsNullOrEmpty(estimateNumber))
                {
                    if (!FileSystem.DirectoryExists(@sourceJobLocation))
                    {
                        if (jobNameOld.Length > 0 && jobName != jobNameOld)   // Copying from an old Job
                        {
                            if (FileSystem.DirectoryExists(@sourceJobLocationOld))
                            {
                                FileSystem.CopyDirectory(@sourceJobLocationOld, @sourceJobLocation);
                                FileSystem.DeleteDirectory(@sourceJobLocationOld, DeleteDirectoryOption.DeleteAllContents);
                            }
                        }
                        else
                        {
                            // New Location
                            CopyFiles(CCEApplication.FormsLocation, sourceJobLocation + "Estimate DOCS\\", false);
                        }
                    }
                }
                //
                // Create a Job Folder with Estimate Number
                //
                if (!String.IsNullOrEmpty(jobNumber) && !String.IsNullOrEmpty(estimateNumber))
                {
                    if (!FileSystem.DirectoryExists(@sourceEstimateLocation))
                    {
                        if (jobNameOld.Length > 0 && jobName != jobNameOld)
                        {
                            if (FileSystem.DirectoryExists(@sourceEstimateLocationOld))
                            {
                                FileSystem.CopyDirectory(@sourceEstimateLocationOld, @sourceEstimateLocation);
                                FileSystem.DeleteDirectory(@sourceEstimateLocationOld, DeleteDirectoryOption.DeleteAllContents);
                            }
                        }
                        else
                        {
                            CopyFiles(CCEApplication.FormsLocation, sourceEstimateLocation , false);
                        }
                    }
                    if (!FileSystem.DirectoryExists(@sourceJobLocation))
                    {
                        if (jobNameOld.Length > 0 && jobName != jobNameOld)
                        {
                            if (FileSystem.DirectoryExists(@sourceJobLocationOld))
                            {
                                FileSystem.CopyDirectory(@sourceJobLocationOld, @sourceJobLocation);
                                FileSystem.DeleteDirectory(@sourceJobLocationOld, DeleteDirectoryOption.DeleteAllContents);
                            }
                        }
                        else
                        {
                            if (FileSystem.DirectoryExists(@sourceEstimateLocation))
                            {
                                FileSystem.CopyDirectory(@sourceEstimateLocation, @sourceJobLocation + "Estimate DOCS\\");
                                FileSystem.CopyDirectory(@sourceEstimateLocation, @archiveEstimateLocation );
                                FileSystem.DeleteDirectory(@sourceEstimateLocation, DeleteDirectoryOption.DeleteAllContents);
                            }
                            else
                            {
                                CopyFiles(CCEApplication.FormsLocation, sourceJobLocation + "Estimate DOCS\\",false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }           
        }
        // The Process of copying the files is here
        private void CopyFiles(string source, string destination, bool origFolder)
        {
            try
            {
                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);
                if (source != destination)
                {
                    DirectoryInfo dir = new DirectoryInfo(@source);
                    foreach (FileInfo f in dir.GetFiles())
                    {
                        File.Copy(source + f.Name, destination + f.Name, true);
                    }
                }
                if (over250K == "1" && archived != "1")
                {
                    if (!File.Exists(@destination + "\\" + "Prop Schedule.xls"))
                        File.Copy(@CCEApplication.FormsLocation + "Prop Schedule.xls", @destination + "\\" + "Prop Schedule.xls");
                }
                else
                {
                    if (over250K != "1" && archived != "1")
                    {
                        if (File.Exists(destination + "\\" + "Prop Schedule.xls"))
                            File.Delete(destination + "\\" + "Prop Schedule.xls");
                    }
                }
                if (over1M == "1" && archived != "1")
                {
                    if (!File.Exists(destination + "\\" + "Over 1 Million Form.xls"))
                        File.Copy(CCEApplication.FormsLocation + "Over 1 Million Form.xls", destination + "\\" + "Over 1 Million Form.xls");
                }
                else
                {
                    if (over250K != "1" && archived != "1")
                    {
                        if (File.Exists(destination + "\\" + "Over 1 Million Form.xls"))
                            File.Delete(destination + "\\" + "Over 1 Million Form.xls");
                    }

                }
                if (bidBondName != "" && bidBondName != "NONE" && archived != "1")
                {
                    if (!File.Exists(destination + "\\" + "Bid Bond Request Form.xls"))
                        File.Copy(CCEApplication.FormsLocation + "Bid Bond Request Form.xls", destination + "\\" + "Bid Bond Request Form.xls");
                }
                else
                {
                    if ((bidBondName == "" || bidBondName == "NONE") && archived != "1")
                    {
                        if (File.Exists(destination + "\\" + "Bid Bond Request Form.xls"))
                            File.Delete(destination + "\\" + "Bid Bond Request Form.xls");
                    }

                }
                if (contractTypeName == "FIXED PRICE" && archived != "1" && jobNumber.Length > 0)
                {
                    if (!File.Exists(destination + "\\" + "EST COST BREAKDOWN.xls"))
                        File.Copy(CCEApplication.FormsLocation + "EST COST BREAKDOWN.xls", destination + "\\" + "EST COST BREAKDOWN.xls");
                }
                else
                {
                    if (contractTypeName != "FIXED PRICE" && archived != "1")
                    {
                        if (File.Exists(destination + "\\" + "EST COST BREAKDOWN.xls"))
                            File.Delete(destination + "\\" + "EST COST BREAKDOWN.xls");
                    }
                }
                if (certifiedPayRoll == "1" && archived != "1" && jobNumber.Length > 0)
                {
                    if (!File.Exists(destination + "\\" + "CERTIFIED PAYROLL.doc"))
                        File.Copy(CCEApplication.FormsLocation + "CERTIFIED PAYROLL.doc", destination + "\\" + "CERTIFIED PAYROLL.doc");
                }
                else
                {
                    if (certifiedPayRoll != "1" && archived != "1")
                    {
                        if (File.Exists(destination + "\\" + "CERTIFIED PAYROLL.doc"))
                            File.Delete(destination + "\\" + "CERTIFIED PAYROLL.doc");
                    }
                }
                if (archived == "1" && !origFolder)
                {
                    if (Directory.Exists(source))
                        Directory.Delete(source, true);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
