using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class MajorPO
    {
        private string jobMajorPOID;
        private string jobID;
        private string majorPONumber;
        private string vendorID;
        private string poType;
        private string poDate;
        private string phase;
        private string costCode;
        private string note;
        private string salesTaxPercent;
        private string subtotal;
        private string salesTax;
        private string total;
        private string subcontractorID;
        private string workDescription;
        private string subcontractAmount;
        private string jobVendorSubcontractID;
        private string status;
        private string shipTo;
        private string shipToAddress;
        private string shipToCity;
        private string shipToState;
        private string shipToZip;

        public string JobMajorPOID
        {
            get { return jobMajorPOID; }
        }

        public MajorPO()
        {
        }
        public MajorPO(string jobMajorPOID,
                       string jobID,
                       string majorPONumber,
                       string vendorID,
                       string poType,
                       string poDate,
                       string phase,
                       string costCode,
                       string note,
                       string salesTaxPercent,
                       string subtotal,
                       string salesTax,
                       string total,
                       string subcontractorID,
                       string workDescription,
                       string subcontractAmount,
                       string jobVendorSubcontractID,
                       string status,
                       string shipTo,
                       string shipToAddress,
                       string shipToCity,
                       string shipToState,
                       string shipToZip)
        {
            this.jobMajorPOID = jobMajorPOID;
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.majorPONumber = "'" + majorPONumber.Trim().Replace("'", "''") + "'";
            this.vendorID = "'" + vendorID.Trim().Replace("'", "''") + "'";
            this.poType = "'" + poType.Trim().Replace("'", "''") + "'";
            this.poDate = String.IsNullOrEmpty(poDate) ? "Null" : "'" + poDate + "'";
            this.phase = "'" + phase.Trim().Replace("'", "''") + "'";
            this.costCode = "'" + costCode.Trim().Replace("'", "''") + "'";
            this.note = "'" + note.Trim().Replace("'", "''") + "'";
            this.salesTaxPercent = String.IsNullOrEmpty(salesTaxPercent) ? "Null" : salesTaxPercent;
            this.subtotal = String.IsNullOrEmpty(subtotal) ? "Null" : subtotal;
            this.salesTax = String.IsNullOrEmpty(salesTax) ? "Null" : salesTax;
            this.total = string.IsNullOrEmpty(total) ? "Null" : total;
            this.subcontractorID = String.IsNullOrEmpty(subcontractorID) ? "Null" : subcontractorID;
            this.workDescription = "'" + workDescription.Trim().Replace("'", "''") + "'";
            this.subcontractAmount = "'" + subcontractAmount.Trim().Replace("'", "''") + "'";
            this.jobVendorSubcontractID = String.IsNullOrEmpty(jobVendorSubcontractID) ? "Null" : jobVendorSubcontractID;
            this.status = "'" + status.Trim().Replace("'", "''") + "'";
            this.shipTo = "'" + shipTo.Trim().Replace("'", "''") + "'";
            this.shipToAddress = "'" + shipToAddress.Trim().Replace("'", "''") + "'";
            this.shipToCity = "'" + shipToCity.Trim().Replace("'", "''") + "'";
            this.shipToState = "'" + shipToState.Trim().Replace("'", "''") + "'";
            this.shipToZip = "'" + shipToZip.Trim().Replace("'", "''") + "'";
        }
        //
        /* public static DataSet GetRFISheet(string jobRFIID)
         {
             string query = "";

             query = " SELECT " +
                     " Company = " +
                     " CASE c.LotusNotes " +
                     " WHEN 1 THEN cc.CompanyName " +
                     " ELSE dd.CompanyName " +
                     " End, " +
                     " CompanyTo = " +
                     " CASE c.LotusNotes " +
                     " WHEN 1 THEN  cc.FirstName + ' '  + cc.LastName " +
                     " ELSE dd.FirstName  + ' ' + dd.LastName " +
                     " End, " +
                     " RFISubject, " +
                     " JobRFINumber, " +
                     " RFIDate, " +
                     " JobNumber, " +
                     " JobName, " +
                     " CompanyFrom = " +
                     " CASE l.LotusNotes " +
                     " WHEN 1 THEN  mm.FirstName + ' '  + mm.LastName " +
                     " ELSE nn.FirstName  + ' ' + nn.LastName " +
                     " End, " +
                     " RFIText, " +
                     " DesignDetailRequired, " +
                     " DelayJob, " +
                     " DiscussedOnPhoneWith, " +
                     " PhoneDiscussionDate, " +
                     " AnsweredNeededBy, " +
                     " RFIResponse " +
                     " FROM tblJobRFI r " +
                     " LEFT Join tblJob j ON r.JobID = j.JobID " +
                     " LEFT JOIN tblJobContact c ON r.RFIToContactID = c.ContactID " +
                     " LEFT JOIN tblCompanyContact cc ON c.CompanyContactID = cc.CompanyContactID " +
                     " LEFT JOIN tblJobContactDetail dd ON c.CompanyContactID = dd.JobContactDetailID " +
                     " LEFT JOIN tblJobContact l ON r.RFIFromID = l.ContactID " +
                     " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                     " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                     " WHERE r.JobRFIID =  " + jobRFIID + " ";

             try
             {
                 return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         } */
        //
        /* public static DataSet GetRFI(string jobRFIID)
         {
             string query = "";

             query = " SELECT * FROM tblJobRFI WHERE JobRFIID = " + jobRFIID + " ";

             try
             {
                 return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }*/
        //
        public static bool IsPONumberDuplicate(string jobMajorPOID, string jobID, string poNumber)
        {
            bool ret = false;
            DataTable table;
            string query;
            if (jobMajorPOID == "0")
                jobMajorPOID = "";
            if (jobMajorPOID.Trim().Length > 0)
                query = "SELECT JobMajorPOID FROM tblJobMajorPO WHERE JobID = " + jobID +
                         " AND MajorPONumber = '" + poNumber + "' AND JobMajorPOID <> " + jobMajorPOID + " ";
            else
                query = "SELECT JobMajorPOID FROM tblJobMajorPO WHERE JobID = " + jobID +
                     " AND MajorPONumber = '" + poNumber + "' ";


            try
            {
                table = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count > 0)
                    ret = true;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetAttachmentMPO(string jobMajorPOID)
        {
            string query = "";

            query = " SELECT " +
                    " MajorPONumber = JobNumber + '-' + MajorPONumber, " +
                    " JobNumber , " +
                    " Name AS Vendor, " +
                    " PODate, " +
                    " [Foreman] = " +
                    " CASE LotusNotes " +
                    " WHEN 1 THEN ISNULL(c.FirstName, '') + ' ' + ISNULL(c.LastName, '') + ' at: '  + ISNULL(c.PhoneNumber, '') " +
                    " ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') + ' at: '  + ISNULL(d.PhoneNumber,'') " +
                    " END " +
                    " FROM tblJobMajorPO m " +
                    " LEFT JOIN tblJob j ON m.JobID = j.JobID " +
                    " LEFT JOIN tblVendor v ON m.VendorID = v.VendorID " +
                    " LEFT JOIN tblJobDefaultValues e ON m.JobID = e.JobID " +
                    " LEFT JOIN  tblJobContact jc ON e.JobForemanID = jc.ContactID " +
                    " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                    " WHERE JobMajorPOID = " + jobMajorPOID + " ";

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
        public static DataSet GetSubcontractAgreement(string jobMajorPOID)
        {
            string query = "";


            query = " SELECT JobID " +
                    " FROM tblJobMajorPO p " +
                    " WHERE p.JobMajorPOID = " + jobMajorPOID + " ";

            string jobID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
            query = string.Empty;
            if (!string.IsNullOrEmpty(jobID))
            {
                if (JCCBusinessLayer.Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    query = "SELECT TOP 1 " +
                      " MajorPONumber = JobNumber + ' - ' + MajorPONumber, " +
                      " PODate, " +
                      " [Subcontractor] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.CompanyName " +
                      " ELSE d.CompanyName " +
                      " END, " +
                      " [SubcontractorAddress] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.OfficeStreetAddress " +
                      " ELSE d.OfficeStreetAddress " +
                      " END, " +
                      " [SubcontractorCityStateZip] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN ISNULL(c.OfficeCity, '') + ', ' + ISNULL(c.OfficeState, '') + ' '  + ISNULL(c.OfficeZip, '') " +
                      " ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' '  + ISNULL(d.OfficeZip,'') " +
                      " END, " +
                      " [SubcontractorPhone] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.OfficePhoneNumber " +
                      " ELSE d.OfficePhoneNumber " +
                      " END, " +
                      " [SubcontractorFax] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.OfficeFaxPhoneNumber " +
                      " ELSE d.OfficeFaxPhoneNumber " +
                      " END, " +
                      " ContractorName, " +
                      " ContractorAddress = ISNULL(ContractorAddress1, '') + ' ' + ISNULL(ContractorAddress2, ''), " +
                      " ContractorCityStateZip = ISNull(ContractorCity, '') + ', ' + ISNULL(ContractorState, '') + ' ' + ISNull(ContractorZipCode, ''), " +
                      " Ownername, " +
                      " OwnerAddress = ISNULL(OwnerAddress1, '') + ' ' + ISNULL(OwnerAddress2, ''), " +
                      " OwnerCityStateZip = ISNull(OwnerCity, '') + ', ' + ISNULL(OwnerState, '') + ' ' + ISNull(OwnerZipCode, ''), " +
                      " JobName, " +   // Start here for PSA
                      " JobNumber, " +
                      " Phase," +
                      " CostCode, " +
                      " Subtotal, " +
                      " Total, " +
                      " MajorPONumberDetail = MajorPONumber, " +
                      " RevisionNumber, " +
                      " detail.RevisionDate, " +  // end
                      " WIPRequired, " +
                      " m.WorkDescription, " +
                      " detail.WorkDescription as WorkDescriptionDetail, " +
                      " SubcontractAmount, " +
                      " JobVendorSubcontract," +
                      " ISNULL(ShipTo,'-') AS ShipTo," +
                      " ISNULL(ShipToAddress,'-') AS ShipToAddress," +
                      " V.Name AS VendorName," +
                      " V.Address1 AS Address1," +
                      " ISNULL(v.address2,'-') AS address2," +
                      " ISNULL(v.City, '') + ', ' + ISNULL(v.State, '') + ' ' + ISNULL(v.ZipCode, '') AS VendorCityStateZip," +
                      " ISNULL(ShipToCity, '') +', ' + ISNULL(ShipToState, '') + ' ' + ISNULL(ShipToZip, '') AS CityStateZip, " +
                      " [Foreman] =CASE fc.LotusNotes  WHEN 1 THEN ISNULL(c.FirstName, '') + ' ' + ISNULL(c.LastName, '')  ELSE ISNULL ( d.FirstName, '') +' ' + ISNULL(d.LastName, '') END," +
                      " [ForemanPhoneNumber] = CASE fc.LotusNotes WHEN 1 THEN ISNULL ( c.PhoneNumber, '')  ELSE ISNULL ( d.PhoneNumber,'') END," +
                      " ms.MasterNumber," +
                      " ProjectManager = CASE o.LotusNotes WHEN 1 THEN pp.FirstName + ' ' + pp.LastName ELSE qq.FirstName + ' ' + qq.LastName END," +
                      " ProjectManagerNumber = CASE o.LotusNotes WHEN 1 THEN pp.PhoneNumber ELSE qq.PhoneNumber END," +
                      " j.JobCertifiedFlag," +
                      " p.Description AS InsuranceProgram, " +
                      " m.SalesTax " +
                      " FROM tblJobMajorPO m " +
                      " LEFT JOIN tblJobMajorPODetail detail ON m.JobMajorPOID = detail.JobMajorPOID " +
                      " LEFT JOIN tblJob j ON m.JobID = j.JobID " +
                      " LEFT JOIN tblVendor v ON m.VendorID = v.VendorID " +
                      " LEFT JOIN tblJobContact jc ON m.SubcontractorID = jc.ContactID" +
                      " LEFT JOIN tblJobDefaultValues jv" +
                      " ON jv.JobID = m.JobID" +
                      " LEFT JOIN tblJobContact fc" +
                      " ON jv.JobForemanID = fc.ContactID" +
                      " LEFT JOIN tblGlobalContact c ON jc.CompanyContactID = c.GlobalContactID " +
                      " LEFT JOIN tblJobContactDetail d ON fc.CompanyContactID = d.JobContactDetailID " +
                      " LEFT JOIN tblJobVendorSubcontract s on m.JobVendorSubcontractID = s.JobVendorSubcontractID " +
                      " LEFT JOIN tblMasterAgreement ms ON ms.Company=v.Name " +
                      " LEFT JOIN tblInsuranceProgram p ON p.InsuranceProgramID=j.InsuranceProgramID" +
                      " LEFT JOIN tblJobContact o  ON jv.JobDefaultFromID = o.ContactID" +
                      " LEFT JOIN tblCompanyContact pp  ON o.CompanyContactID = pp.CompanyContactID" +
                      " LEFT JOIN tblJobContactDetail qq  ON o.CompanyContactID = qq.JobContactDetailID" +
                      " LEFT JOIN tblForeman f ON j.ForemanID=f.ForemanID" +
                      " LEFT JOIN tblProjectManager pm ON pm.ProjectManagerID = j.ProjectManagerID" +
                      " WHERE m.JobMajorPOID = " + jobMajorPOID + " ";
                }
                else
                {
                    query = "SELECT TOP 1 " +
                      " MajorPONumber = JobNumber + ' - ' + MajorPONumber, " +
                      " PODate, " +
                      " [Subcontractor] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.CompanyName " +
                      " ELSE d.CompanyName " +
                      " END, " +
                      " [SubcontractorAddress] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.OfficeStreetAddress " +
                      " ELSE d.OfficeStreetAddress " +
                      " END, " +
                      " [SubcontractorCityStateZip] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN ISNULL(c.OfficeCity, '') + ', ' + ISNULL(c.OfficeState, '') + ' '  + ISNULL(c.OfficeZip, '') " +
                      " ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' '  + ISNULL(d.OfficeZip,'') " +
                      " END, " +
                      " [SubcontractorPhone] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.OfficePhoneNumber " +
                      " ELSE d.OfficePhoneNumber " +
                      " END, " +
                      " [SubcontractorFax] = " +
                      " CASE jc.LotusNotes " +
                      " WHEN 1 THEN c.OfficeFaxPhoneNumber " +
                      " ELSE d.OfficeFaxPhoneNumber " +
                      " END, " +
                      " ContractorName, " +
                      " ContractorAddress = ISNULL(ContractorAddress1, '') + ' ' + ISNULL(ContractorAddress2, ''), " +
                      " ContractorCityStateZip = ISNull(ContractorCity, '') + ', ' + ISNULL(ContractorState, '') + ' ' + ISNull(ContractorZipCode, ''), " +
                      " Ownername, " +
                      " OwnerAddress = ISNULL(OwnerAddress1, '') + ' ' + ISNULL(OwnerAddress2, ''), " +
                      " OwnerCityStateZip = ISNull(OwnerCity, '') + ', ' + ISNULL(OwnerState, '') + ' ' + ISNull(OwnerZipCode, ''), " +
                      " JobName, " +   // Start here for PSA
                      " JobNumber, " +
                      " Phase," +
                      " CostCode, " +
                      " Subtotal, " +
                      " Total, " +
                      " MajorPONumberDetail = MajorPONumber, " +
                      " RevisionNumber, " +
                      " detail.RevisionDate, " +  // end
                      " WIPRequired, " +
                      " m.WorkDescription, " +
                      " detail.WorkDescription as WorkDescriptionDetail, " +
                      " SubcontractAmount, " +
                      " JobVendorSubcontract," +
                      " ISNULL(ShipTo,'-') AS ShipTo," +
                      " ISNULL(ShipToAddress,'-') AS ShipToAddress," +
                      " V.Name AS VendorName," +
                      " V.Address1 AS Address1," +
                      " ISNULL(v.address2,'-') AS address2," +
                      " ISNULL(v.City, '') + ', ' + ISNULL(v.State, '') + ' ' + ISNULL(v.ZipCode, '') AS VendorCityStateZip," +
                      " ISNULL(ShipToCity, '') +', ' + ISNULL(ShipToState, '') + ' ' + ISNULL(ShipToZip, '') AS CityStateZip, " +
                      " [Foreman] =CASE fc.LotusNotes  WHEN 1 THEN ISNULL(c.FirstName, '') + ' ' + ISNULL(c.LastName, '')  ELSE ISNULL ( d.FirstName, '') +' ' + ISNULL(d.LastName, '') END," +
                      " [ForemanPhoneNumber] = CASE fc.LotusNotes WHEN 1 THEN ISNULL ( c.PhoneNumber, '')  ELSE ISNULL ( d.PhoneNumber,'') END," +
                      " ms.MasterNumber," +
                      " ProjectManager = CASE o.LotusNotes WHEN 1 THEN pp.FirstName + ' ' + pp.LastName ELSE qq.FirstName + ' ' + qq.LastName END," +
                      " ProjectManagerNumber = CASE o.LotusNotes WHEN 1 THEN pp.PhoneNumber ELSE qq.PhoneNumber END," +
                      " j.JobCertifiedFlag," +
                      " p.Description AS InsuranceProgram, " +
                      " m.SalesTax " +
                      " FROM tblJobMajorPO m " +
                      " LEFT JOIN tblJobMajorPODetail detail ON m.JobMajorPOID = detail.JobMajorPOID " +
                      " LEFT JOIN tblJob j ON m.JobID = j.JobID " +
                      " LEFT JOIN tblVendor v ON m.VendorID = v.VendorID " +
                      " LEFT JOIN tblJobContact jc ON m.SubcontractorID = jc.ContactID" +
                      " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID" +
                      " LEFT JOIN tblJobContactDetail d ON c.CompanyContactID = d.JobContactDetailID" +
                      " LEFT JOIN tblJobDefaultValues jv" +
                      " ON jv.JobID = m.JobID LEFT JOIN tblJobContact fc" +
                      " ON jv.JobForemanID = fc.ContactID" +                     
                      " LEFT JOIN tblJobVendorSubcontract s on m.JobVendorSubcontractID = s.JobVendorSubcontractID " +
                      " LEFT JOIN tblMasterAgreement ms ON ms.Company=v.Name " +
                      " LEFT JOIN tblInsuranceProgram p ON p.InsuranceProgramID=j.InsuranceProgramID" +
                      " LEFT JOIN tblJobContact o  ON jv.JobDefaultFromID = o.ContactID" +
                      " LEFT JOIN tblCompanyContact pp  ON o.CompanyContactID = pp.CompanyContactID" +
                      " LEFT JOIN tblJobContactDetail qq  ON o.CompanyContactID = qq.JobContactDetailID" +
                      " LEFT JOIN tblForeman f ON j.ForemanID=f.ForemanID" +
                      " LEFT JOIN tblProjectManager pm ON pm.ProjectManagerID = j.ProjectManagerID" +
                      " WHERE m.JobMajorPOID = " + jobMajorPOID + " ";
                }
            }

            //jobMajorPOID = "09";


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
        public static DataSet GetJobMajorPOCostCodes(string jobID)
        {
            string query = "";

            query = " SELECT " +
                    " JobCostCodePhaseID, " +
                    " JobCostCodeType AS Type, " +
                    " JobCostCodePhase AS Phase, " +
                    " CostCode AS Code, " +
                    " UserDescription AS Description" +
                    " FROM tblJobCostCodePhase  " +
                    " WHERE JobID = " + jobID + " " +
                    " AND (JobCostCodeType = 'S' OR JobCostCodeType = 'M') " +
                    " ORDER BY JobCostCodeType, JobCostCodePhase, CostCode ";

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
        public static DataSet GetJobMajorPONote(string jobID)
        {
            string query = "";

            query = " SELECT " +
                    " MajorPONote " +
                    " FROM tblJobDefaultValues p " +
                    " WHERE p.JobID = " + jobID + " ";
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
        public static DataSet GetJobMajorPO(string jobID)
        {
            string query = "";

            query = " SELECT " +
                    " JobMajorPOID, " +
                    " MajorPONumber AS [PO Number], " +
                    " p.VendorID	AS [Vendor ID], " +
                    " Name		AS [Vendor Name], " +
                    " PODate		AS [PO Date], " +
                    " POType AS [PO Type], " +
                    " Phase, " +
                    " CostCode	AS [Cost Code], " +
                    " SalesTaxPercent AS [Tax Percent], " +
                    " Subtotal, " +
                    " SalesTax	    AS [Sales Tax], " +
                    " Total, " +
                    " Status " +
                    " FROM tblJobMajorPO p " +
                    " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                    " WHERE p.JobID = " + jobID + " ";
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

        public static DataSet GetJobMajorPOReport(string jobMajorPOID)
        {
            string query = "";

            query = " SELECT DISTINCT " +
                    " JobNumber + ' - ' + MajorPONumber AS PONumber, " +
                    " d.*, p.*, " +
                    " ISNULL(ShipToCity, '') + ', ' + ISNULL(ShipToState, '') + ' ' + ISNULL(ShipToZip, '') AS CityStateZip, " +
                    " V.Name, " +
                    " v.Address1, " +
                    " v.address2, " +
                    " ISNULL(v.City,'') + ', ' + ISNULL(v.State,'') + ' ' + ISNULL(v.ZipCode, '') AS VendorCityStateZip, " +
                    " JobName, " +
                    " JobAddress1, " +
                    " JobAddress2 " +
                    " FROM tblJobMajorPO p " +
                    " LEFT JOIN tblJobMajorPODetail d ON p.JobMajorPOID = d.JobMajorPOID " +
                    // " LEFT JOIN tbl
                    " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                    " LEFT JOIN tblJob j ON p.JobID = j.JobID " +
                    " WHERE p.JobMajorPOID = " + jobMajorPOID + " ";
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
        public static DataSet GetJobMajorPODetail(string jobMajorPOID)
        {
            string query = "";

            query = " SELECT * " +
                    " FROM tblJobMajorPO p " +
                    " WHERE p.JobMajorPOID = " + jobMajorPOID + " ";
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
            if (jobMajorPOID == "" || jobMajorPOID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobMajorPO(" +
                    " JobID, " +
                    " MajorPONumber, " +
                    " VendorID, " +
                    " POType, " +
                    " PODate, " +
                    " Phase, " +
                    " CostCode, " +
                    " Note, " +
                    " SalesTaxPercent, " +
                    " Subtotal, " +
                    " SalesTax, " +
                    " SubcontractorID, " +
                    " JobVendorSubcontractID, " +
                    " WorkDescription, " +
                    " SubcontractAmount, " +
                    " Status, " +
                    " ShipTo, " +
                    " ShipToAddress, " +
                    " ShipToCity, " +
                    " ShipToState, " +
                    " ShipToZip, " +
                    " Total) VALUES (" +
                    jobID + ", " +
                    majorPONumber + ", " +
                    vendorID + ", " +
                    poType + ", " +
                    poDate + ", " +
                    phase + ", " +
                    costCode + ", " +
                    note + ", " +
                    salesTaxPercent + ", " +
                    subtotal + ", " +
                    salesTax + ", " +
                    subcontractorID + ", " +
                    jobVendorSubcontractID + ", " +
                    workDescription + ", " +
                    subcontractAmount + ", " +
                    status + ", " +
                    shipTo + ", " +
                    shipToAddress + ", " +
                    shipToCity + ", " +
                    shipToState + ", " +
                    shipToZip + ", " +
                    total + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobMajorPOID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobMajorPO SET " +
                    " JobID                 = " + jobID + ", " +
                    " MajorPONumber         = " + majorPONumber + ", " +
                    " VendorID              = " + vendorID + ", " +
                    " POType                = " + poType + ", " +
                    " PODate                = " + poDate + ", " +
                    " Phase                 = " + phase + ", " +
                    " CostCode              = " + costCode + ", " +
                    " Note                  = " + note + ", " +
                    " SalesTaxPercent       = " + salesTaxPercent + ", " +
                    " Subtotal              = " + subtotal + ", " +
                    " SalesTax              = " + salesTax + ", " +
                    " SubcontractorID       = " + subcontractorID + ", " +
                    " JobVendorSubcontractID       = " + jobVendorSubcontractID + ", " +
                    " WorkDescription       = " + workDescription + ", " +
                    " SubcontractAmount     = " + subcontractAmount + ", " +
                    " Status                = " + status + ", " +
                    " ShipTo                = " + shipTo + ", " +
                    " ShipToAddress         = " + shipToAddress + ", " +
                    " ShipToCity            = " + shipToCity + ", " +
                    " ShipToState           = " + shipToState + ", " +
                    " ShipToZip             = " + shipToZip + ", " +
                    " Total                 = " + total + " " +
                    " WHERE JobMajorPOID  = " + jobMajorPOID;
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

        public static DataSet GetJobMajorPORevisionDetail(string jobMajorPOID)
        {
            string query = "";

            query = " SELECT " +
                    " RevisionNumber, " +
                    " WorkDescription, " +
                    " RevisionDate, " +
                    " Amount " +
                    " FROM tblJobMajorPODetail" +
                    " WHERE JobMajorPOID = " + jobMajorPOID;
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
