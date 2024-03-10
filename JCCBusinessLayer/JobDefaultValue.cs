using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;


namespace JCCBusinessLayer
{
    public class JobDefaultValues
    {
        private string jobID;
        private string changeOrderStipulationsParagraph1;
        private string changeOrderStipulationsParagraph2;
        private string majorPONote;
        private string smallPONote;
        private string sundriesPercentOfMaterial;
        private string salesTaxPercent;
        private string asBuiltsEngineeringPercent;
        private string storagePercent;
        private string smallToolsPercent;
        private string cartigeHandlingPercent;
        private string foremanPercentOfLabor;
        private string generalForemanPercentOfLabor;
        private string superintendentPercentOfLabor;
        private string projectManagerPercentOfLabor;
        private string projectEngineerPercentOfLabor;
        private string safetyMeetingPercent;
        private string fringeBenefitsPercent;
        private string overheadPercent;
        private string profitPercent;
        private string subcontractAdministrationPercent;
        private string warrantyPercent;
        private string bondPercent;
        private string BIMRate;
        private string apprenticeLaborRate;
        private string electricianLaborRate;
        private string foremanLaborRate;
        private string generalForemanLaborRate;
        private string superintendentLaborRate;
        private string projectManagerLaborRate;
        private string projectEngineerLaborRate;
        private string safetyMeetingsLaborRate;
        private string premiumTimeLaborRate;
        private string jobDefaultRFIContactID;
        private string jobDefaultChangeOrderContactID;
        private string jobDefaultFromID;
        private string jobForemanID;

        private string BIMRateOT;
        private string apprenticeLaborRateOT;
        private string electricianLaborRateOT;
        private string foremanLaborRateOT;
        private string generalForemanLaborRateOT;
        private string superintendentLaborRateOT;
        private string projectManagerLaborRateOT;
        private string projectEngineerLaborRateOT;
        private string safetyMeetingsLaborRateOT;
        private string premiumTimeLaborRateOT;

        private string BIMRateDT;
        private string apprenticeLaborRateDT;
        private string electricianLaborRateDT;
        private string foremanLaborRateDT;
        private string generalForemanLaborRateDT;
        private string superintendentLaborRateDT;
        private string projectManagerLaborRateDT;
        private string projectEngineerLaborRateDT;
        private string safetyMeetingsLaborRateDT;
        private string premiumTimeLaborRateDT;


        private string BIMRate_Label;
        private string apprenticeLaborRate_Label;
        private string electricianLaborRate_Label;
        private string foremanLaborRate_Label;
        private string generalForemanLaborRate_Label;
        private string superintendentLaborRate_Label;
        private string projectManagerLaborRate_Label;
        private string projectEngineerLaborRate_Label;
        private string safetyMeetingsLaborRate_Label;
        private string premiumTimeLaborRate_Label;
        private string FringeBenefitsPercent_Label;
        private string SafetyMeetingPercent_Label;
        //
        public JobDefaultValues()
        {
        }
        //
        public JobDefaultValues(
            string jobID,
            string changeOrderStipulationsParagraph1,
            string changeOrderStipulationsParagraph2,
            string majorPONote,
            string smallPONote,
            string sundriesPercentOfMaterial,
            string salesTaxPercent,
            string asBuiltsEngineeringPercent,
            string storagePercent,
            string smallToolsPercent,
            string cartigeHandlingPercent,
            string foremanPercentOfLabor,
            string generalForemanPercentOfLabor,
            string superintendentPercentOfLabor,
            string projectManagerPercentOfLabor,
            string projectEngineerPercentOfLabor,
            string safetyMeetingPercent,
            string fringeBenefitsPercent,
            string overheadPercent,
            string profitPercent,
            string subcontractAdministrationPercent,
            string warrantyPercent,
            string bondPercent,
            string BIMRate,
            string apprenticeLaborRate,
            string electricianLaborRate,
            string foremanLaborRate,
            string generalForemanLaborRate,
            string superintendentLaborRate,
            string projectManagerLaborRate,
            string projectEngineerLaborRate,
            string safetyMeetingsLaborRate,
            string premiumTimeLaborRate,
            string jobDefaultRFIContactID,
            string jobDefaultChangeOrderContactID,
            string jobDefaultFromID,
            string jobForemanID,

            string BIMRateOT,
            string apprenticeLaborRateOT,
            string electricianLaborRateOT,
            string foremanLaborRateOT,
            string generalForemanLaborRateOT,
            string superintendentLaborRateOT,
            string projectManagerLaborRateOT,
            string projectEngineerLaborRateOT,
            string safetyMeetingsLaborRateOT,
            string premiumTimeLaborRateOT,

            string BIMRateDT,
            string apprenticeLaborRateDT,
            string electricianLaborRateDT,
            string foremanLaborRateDT,
            string generalForemanLaborRateDT,
            string superintendentLaborRateDT,
            string projectManagerLaborRateDT,
            string projectEngineerLaborRateDT,
            string safetyMeetingsLaborRateDT,
            string premiumTimeLaborRateDT,

            string BIMRate_Label,
        string apprenticeLaborRate_Label,
        string electricianLaborRate_Label,
        string foremanLaborRate_Label,
        string generalForemanLaborRate_Label,
        string superintendentLaborRate_Label,
        string projectManagerLaborRate_Label,
        string projectEngineerLaborRate_Label,
        string safetyMeetingsLaborRate_Label,
        string premiumTimeLaborRate_Label,
        string FringeBenefitsPercent_Label,
        string SafetyMeetingPercent_Label
            )
        {
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.changeOrderStipulationsParagraph1 = changeOrderStipulationsParagraph1.Replace("'", "''").Trim();
            this.changeOrderStipulationsParagraph2 = changeOrderStipulationsParagraph2.Replace("'", "''").Trim();
            this.majorPONote = majorPONote.Replace("'", "''").Trim();
            this.smallPONote = smallPONote.Replace("'", "''").Trim();
            this.sundriesPercentOfMaterial = String.IsNullOrEmpty(sundriesPercentOfMaterial) ? "Null" : sundriesPercentOfMaterial;
            this.salesTaxPercent = String.IsNullOrEmpty(salesTaxPercent) ? "Null" : salesTaxPercent;
            this.asBuiltsEngineeringPercent = String.IsNullOrEmpty(asBuiltsEngineeringPercent) ? "Null" : asBuiltsEngineeringPercent;
            this.storagePercent = String.IsNullOrEmpty(storagePercent) ? "Null" : storagePercent;
            this.smallToolsPercent = String.IsNullOrEmpty(smallToolsPercent) ? "Null" : smallToolsPercent;
            this.cartigeHandlingPercent = String.IsNullOrEmpty(cartigeHandlingPercent) ? "Null" : cartigeHandlingPercent;
            this.foremanPercentOfLabor = String.IsNullOrEmpty(foremanPercentOfLabor) ? "Null" : foremanPercentOfLabor;
            this.generalForemanPercentOfLabor = String.IsNullOrEmpty(generalForemanPercentOfLabor) ? "Null" : generalForemanPercentOfLabor;
            this.superintendentPercentOfLabor = String.IsNullOrEmpty(superintendentPercentOfLabor) ? "Null" : superintendentPercentOfLabor;
            this.projectManagerPercentOfLabor = String.IsNullOrEmpty(projectManagerPercentOfLabor) ? "Null" : projectManagerPercentOfLabor;
            this.projectEngineerPercentOfLabor = String.IsNullOrEmpty(projectEngineerPercentOfLabor) ? "Null" : projectEngineerPercentOfLabor;
            this.safetyMeetingPercent = String.IsNullOrEmpty(safetyMeetingPercent) ? "Null" : safetyMeetingPercent;
            this.fringeBenefitsPercent = String.IsNullOrEmpty(fringeBenefitsPercent) ? "Null" : fringeBenefitsPercent;
            this.overheadPercent = String.IsNullOrEmpty(overheadPercent) ? "Null" : overheadPercent;
            this.profitPercent = String.IsNullOrEmpty(profitPercent) ? "Null" : profitPercent;
            this.subcontractAdministrationPercent = String.IsNullOrEmpty(subcontractAdministrationPercent) ? "Null" : subcontractAdministrationPercent;
            this.warrantyPercent = String.IsNullOrEmpty(warrantyPercent) ? "Null" : warrantyPercent;
            this.bondPercent = String.IsNullOrEmpty(bondPercent) ? "Null" : bondPercent;

            this.BIMRate = String.IsNullOrEmpty(BIMRate) ? "Null" : BIMRate;

            this.apprenticeLaborRate = String.IsNullOrEmpty(apprenticeLaborRate) ? "Null" : apprenticeLaborRate;
            this.electricianLaborRate = String.IsNullOrEmpty(electricianLaborRate) ? "Null" : electricianLaborRate;
            this.foremanLaborRate = String.IsNullOrEmpty(foremanLaborRate) ? "Null" : foremanLaborRate;
            this.generalForemanLaborRate = String.IsNullOrEmpty(generalForemanLaborRate) ? "Null" : generalForemanLaborRate;
            this.superintendentLaborRate = String.IsNullOrEmpty(superintendentLaborRate) ? "Null" : superintendentLaborRate;
            this.projectManagerLaborRate = String.IsNullOrEmpty(projectManagerLaborRate) ? "Null" : projectManagerLaborRate;
            this.projectEngineerLaborRate = String.IsNullOrEmpty(projectEngineerLaborRate) ? "Null" : projectEngineerLaborRate;
            this.safetyMeetingsLaborRate = String.IsNullOrEmpty(safetyMeetingsLaborRate) ? "Null" : safetyMeetingsLaborRate;
            this.premiumTimeLaborRate = String.IsNullOrEmpty(premiumTimeLaborRate) ? "Null" : premiumTimeLaborRate;
            this.jobDefaultRFIContactID = String.IsNullOrEmpty(jobDefaultRFIContactID) ? "Null" : jobDefaultRFIContactID;
            this.jobDefaultChangeOrderContactID = String.IsNullOrEmpty(jobDefaultChangeOrderContactID) ? "Null" : jobDefaultChangeOrderContactID;
            this.jobDefaultFromID = String.IsNullOrEmpty(jobDefaultFromID) ? "Null" : jobDefaultFromID;
            this.jobForemanID = String.IsNullOrEmpty(jobForemanID) ? "Null" : jobForemanID;

            this.BIMRateOT = String.IsNullOrEmpty(BIMRateOT) ? "Null" : BIMRateOT;

            this.apprenticeLaborRateOT = String.IsNullOrEmpty(apprenticeLaborRateOT) ? "Null" : apprenticeLaborRateOT;
            this.electricianLaborRateOT = String.IsNullOrEmpty(electricianLaborRateOT) ? "Null" : electricianLaborRateOT;
            this.foremanLaborRateOT = String.IsNullOrEmpty(foremanLaborRateOT) ? "Null" : foremanLaborRateOT;
            this.generalForemanLaborRateOT = String.IsNullOrEmpty(generalForemanLaborRateOT) ? "Null" : generalForemanLaborRateOT;
            this.superintendentLaborRateOT = String.IsNullOrEmpty(superintendentLaborRateOT) ? "Null" : superintendentLaborRateOT;
            this.projectManagerLaborRateOT = String.IsNullOrEmpty(projectManagerLaborRateOT) ? "Null" : projectManagerLaborRateOT;
            this.projectEngineerLaborRateOT = String.IsNullOrEmpty(projectEngineerLaborRateOT) ? "Null" : projectEngineerLaborRateOT;
            this.safetyMeetingsLaborRateOT = String.IsNullOrEmpty(safetyMeetingsLaborRateOT) ? "Null" : safetyMeetingsLaborRateOT;
            this.premiumTimeLaborRateOT = String.IsNullOrEmpty(premiumTimeLaborRateOT) ? "Null" : premiumTimeLaborRateOT;


            this.BIMRateDT = String.IsNullOrEmpty(BIMRateDT) ? "Null" : BIMRateDT;

            this.apprenticeLaborRateDT = String.IsNullOrEmpty(apprenticeLaborRateDT) ? "Null" : apprenticeLaborRateDT;
            this.electricianLaborRateDT = String.IsNullOrEmpty(electricianLaborRateDT) ? "Null" : electricianLaborRateDT;
            this.foremanLaborRateDT = String.IsNullOrEmpty(foremanLaborRateDT) ? "Null" : foremanLaborRateDT;
            this.generalForemanLaborRateDT = String.IsNullOrEmpty(generalForemanLaborRateDT) ? "Null" : generalForemanLaborRateDT;
            this.superintendentLaborRateDT = String.IsNullOrEmpty(superintendentLaborRateDT) ? "Null" : superintendentLaborRateDT;
            this.projectManagerLaborRateDT = String.IsNullOrEmpty(projectManagerLaborRateDT) ? "Null" : projectManagerLaborRateDT;
            this.projectEngineerLaborRateDT = String.IsNullOrEmpty(projectEngineerLaborRateDT) ? "Null" : projectEngineerLaborRateDT;
            this.safetyMeetingsLaborRateDT = String.IsNullOrEmpty(safetyMeetingsLaborRateDT) ? "Null" : safetyMeetingsLaborRateDT;
            this.premiumTimeLaborRateDT = String.IsNullOrEmpty(premiumTimeLaborRateDT) ? "Null" : premiumTimeLaborRateDT;

            this.BIMRate_Label = String.IsNullOrEmpty(BIMRate_Label) ? string.Empty : BIMRate_Label.Trim();
            this.apprenticeLaborRate_Label = String.IsNullOrEmpty(apprenticeLaborRate_Label) ? string.Empty : apprenticeLaborRate_Label.Trim();
            this.electricianLaborRate_Label = String.IsNullOrEmpty(electricianLaborRate_Label) ? string.Empty : electricianLaborRate_Label.Trim();
            this.foremanLaborRate_Label = String.IsNullOrEmpty(foremanLaborRate_Label) ? string.Empty : foremanLaborRate_Label.Trim();
            this.generalForemanLaborRate_Label = String.IsNullOrEmpty(generalForemanLaborRate_Label) ? string.Empty : generalForemanLaborRate_Label.Trim();
            this.superintendentLaborRate_Label= String.IsNullOrEmpty(superintendentLaborRate_Label) ? string.Empty : superintendentLaborRate_Label.Trim();
            this.projectManagerLaborRate_Label = String.IsNullOrEmpty(projectManagerLaborRate_Label) ? string.Empty : projectManagerLaborRate_Label.Trim();
            this.projectEngineerLaborRate_Label = String.IsNullOrEmpty(projectEngineerLaborRate_Label) ? string.Empty : projectEngineerLaborRate_Label.Trim();
            this.safetyMeetingsLaborRate_Label = String.IsNullOrEmpty(safetyMeetingsLaborRate_Label) ? string.Empty : safetyMeetingsLaborRate_Label.Trim();
            this.premiumTimeLaborRate_Label = String.IsNullOrEmpty(premiumTimeLaborRate_Label) ? string.Empty : premiumTimeLaborRate_Label.Trim();
            this.FringeBenefitsPercent_Label = String.IsNullOrEmpty(FringeBenefitsPercent_Label) ? string.Empty : FringeBenefitsPercent_Label.Trim();
            this.SafetyMeetingPercent_Label = String.IsNullOrEmpty(SafetyMeetingPercent_Label) ? string.Empty : SafetyMeetingPercent_Label.Trim();

        }
        //
        public static int GetJobDefaultFrom(string jobID)
        {
            string query = "";
            int defaultFromID = 0;
            DataTable t;
            query = " SELECT " +
                    " JobDefaultFromID " +
                    " FROM tblJobDefaultValues   " +
                    " WHERE JobID = " + jobID + " ";
            try
            {
                t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    int.TryParse(t.Rows[0]["JobDefaultFromID"].ToString(), out defaultFromID);
                return defaultFromID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static int GetJobDefaultRFIContact(string jobID)
        {
            string query = "";
            int defaultRFIContactID = 0;
            DataTable t;
            query = " SELECT " +
                    " JobDefaultRFIContactID " +
                    " FROM tblJobDefaultValues   " +
                    " WHERE JobID = " + jobID + " ";
            try
            {
                t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    int.TryParse(t.Rows[0]["JobDefaultRFIContactID"].ToString(), out defaultRFIContactID);
                return defaultRFIContactID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetJobDefaultChangeOrderContact(string jobID)
        {
            string query = "";
            int defaultChangeOrderContactID = 0;
            DataTable t;
            query = " SELECT " +
                    " JobDefaultChangeOrderContactID " +
                    " FROM tblJobDefaultValues   " +
                    " WHERE JobID = " + jobID + " ";
            try
            {
                t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    int.TryParse(t.Rows[0]["JobDefaultChangeOrderContactID"].ToString(), out defaultChangeOrderContactID);
                return defaultChangeOrderContactID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static DataSet GetJobDefaultValues(string jobID)
        {
            string query = "";
            if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
            {
                query = " SELECT v.*, " +
                                    " RFIDefaultContactCompany =  " +
                                    " CASE c.LotusNotes " +
                                    " WHEN 1 THEN gc.CompanyName " +
                                    " ELSE dd.CompanyName " +
                                    " End, " +
                                    " RFIDefaultContact = " +
                                    " CASE c.LotusNotes " +
                                    " WHEN 1 THEN  gc.FirstName + ' '  + gc.LastName " +
                                    " ELSE dd.FirstName  + ' ' + dd.LastName " +
                                    " End, " +
                                    " ChangeOrderDefaultContactCompany = " +
                                    " CASE l.LotusNotes " +
                                    " WHEN 1 THEN gcc.CompanyName " +
                                    " ELSE nn.CompanyName " +
                                    " End, " +
                                    " ChangeOrderDefaultContact = " +
                                    " CASE l.LotusNotes " +
                                    " WHEN 1 THEN  gcc.FirstName + ' '  + gcc.LastName " +
                                    " ELSE nn.FirstName  + ' ' + nn.LastName " +
                                    " End, " +
                                    " JobDefaultFrom = " +
                                    " CASE o.LotusNotes " +
                                    " WHEN 1 THEN  gccc.FirstName + ' '  + gccc.LastName " +
                                    " ELSE qq.FirstName  + ' ' + qq.LastName " +
                                    " End, " +
                                    " JobForeman = " +
                                    " CASE r.LotusNotes " +
                                    " WHEN 1 THEN  gcccc.FirstName + ' '  + gcccc.LastName " +
                                    " ELSE tt.FirstName  + ' ' + tt.LastName " +
                                    " End " +

                                    " FROM tblJobDefaultValues v " +
                                    " LEFT JOIN tblJobContact c ON v.JobDefaultRFIContactID = c.ContactID " +
                                    " LEFT JOIN tblGlobalContact gc ON c.CompanyContactID = gc.GlobalContactID " +
                                    " LEFT JOIN tblCompanyContact cc ON c.CompanyContactID = cc.CompanyContactID " +
                                    " LEFT JOIN tblJobContactDetail dd ON c.CompanyContactID = dd.JobContactDetailID " +
                                    " LEFT JOIN tblJobContact l ON v.JobDefaultChangeOrderContactID = l.ContactID " +
                                    " LEFT JOIN tblGlobalContact gcc ON l.CompanyContactID = gcc.GlobalContactID  " +
                                    " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                                    " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                                    " LEFT JOIN tblJobContact o ON v.JobDefaultFromID = o.ContactID " +
                                    " LEFT JOIN tblGlobalContact gccc ON o.CompanyContactID = gccc.GlobalContactID " +
                                    " LEFT JOIN tblCompanyContact pp ON o.CompanyContactID = pp.CompanyContactID " +
                                    " LEFT JOIN tblJobContactDetail qq ON o.CompanyContactID = qq.JobContactDetailID " +
                                    " LEFT JOIN tblJobContact r ON v.JobForemanID = r.ContactID " +
                                    "  LEFT JOIN tblGlobalContact gcccc ON r.CompanyContactID = gcccc.GlobalContactID " +
                                    " LEFT JOIN tblCompanyContact ss ON r.CompanyContactID = ss.CompanyContactID " +
                                    " LEFT JOIN tblJobContactDetail tt ON r.CompanyContactID = tt.JobContactDetailID " +


                                    " WHERE v.JobID = " + jobID + " ";
            }
            else
            {
                query = " SELECT v.*, " +
       " RFIDefaultContactCompany =  " +
       " CASE c.LotusNotes " +
       " WHEN 1 THEN cc.CompanyName " +
       " ELSE dd.CompanyName " +
       " End, " +
       " RFIDefaultContact = " +
       " CASE c.LotusNotes " +
       " WHEN 1 THEN  cc.FirstName + ' '  + cc.LastName " +
       " ELSE dd.FirstName  + ' ' + dd.LastName " +
       " End, " +
       " ChangeOrderDefaultContactCompany = " +
       " CASE l.LotusNotes " +
       " WHEN 1 THEN mm.CompanyName " +
       " ELSE nn.CompanyName " +
       " End, " +
       " ChangeOrderDefaultContact = " +
       " CASE l.LotusNotes " +
       " WHEN 1 THEN  mm.FirstName + ' '  + mm.LastName " +
       " ELSE nn.FirstName  + ' ' + nn.LastName " +
       " End, " +
       " JobDefaultFrom = " +
       " CASE o.LotusNotes " +
       " WHEN 1 THEN  pp.FirstName + ' '  + pp.LastName " +
       " ELSE qq.FirstName  + ' ' + qq.LastName " +
       " End, " +
       " JobForeman = " +
       " CASE r.LotusNotes " +
       " WHEN 1 THEN  ss.FirstName + ' '  + ss.LastName " +
       " ELSE tt.FirstName  + ' ' + tt.LastName " +
       " End " +

       " FROM tblJobDefaultValues v " +
       " LEFT JOIN tblJobContact c ON v.JobDefaultRFIContactID = c.ContactID " +
       " LEFT JOIN tblCompanyContact cc ON c.CompanyContactID = cc.CompanyContactID " +
       " LEFT JOIN tblJobContactDetail dd ON c.CompanyContactID = dd.JobContactDetailID " +
       " LEFT JOIN tblJobContact l ON v.JobDefaultChangeOrderContactID = l.ContactID " +
       " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
       " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
       " LEFT JOIN tblJobContact o ON v.JobDefaultFromID = o.ContactID " +
       " LEFT JOIN tblCompanyContact pp ON o.CompanyContactID = pp.CompanyContactID " +
       " LEFT JOIN tblJobContactDetail qq ON o.CompanyContactID = qq.JobContactDetailID " +

       " LEFT JOIN tblJobContact r ON v.JobForemanID = r.ContactID " +
       " LEFT JOIN tblCompanyContact ss ON r.CompanyContactID = ss.CompanyContactID " +
       " LEFT JOIN tblJobContactDetail tt ON r.CompanyContactID = tt.JobContactDetailID " +


       " WHERE v.JobID = " + jobID + " ";
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
        public bool Save()
        {
            return Update();
        }
        //
        private bool Update()
        {
            string query = "UPDATE tblJobDefaultValues SET " +
                        " ChangeOrderStipulationsParagraph1  = '" + changeOrderStipulationsParagraph1 + "', " +
                        " ChangeOrderStipulationsParagraph2  = '" + changeOrderStipulationsParagraph2 + "', " +
                        " MajorPONote                        = '" + majorPONote + "', " +
                        " SmallPONote                        = '" + smallPONote + "', " +
                        " SundriesPercentOfMaterial          =  " + sundriesPercentOfMaterial + ", " +
                        " SalesTaxPercent                    =  " + salesTaxPercent + ", " +
                        " AsBuiltsEngineeringPercent         =  " + asBuiltsEngineeringPercent + ", " +
                        " StoragePercent                     =  " + storagePercent + ", " +
                        " SmallToolsPercent                  =  " + smallToolsPercent + ", " +
                        " CartigeHandlingPercent             =  " + cartigeHandlingPercent + ", " +
                        " ForemanPercentOfLabor              =  " + foremanPercentOfLabor + ", " +
                        " GeneralForemanPercentOfLabor       =  " + generalForemanPercentOfLabor + ", " +
                        " SuperintendentPercentOfLabor       =  " + superintendentPercentOfLabor + ", " +
                        " ProjectManagerPercentOfLabor       =  " + projectManagerPercentOfLabor + ", " +
                        " ProjectEngineerPercentOfLabor      =  " + projectEngineerPercentOfLabor + ", " +
                        " SafetyMeetingPercent               =  " + safetyMeetingPercent + ", " +
                        " FringeBenefitsPercent              =  " + fringeBenefitsPercent + ", " +
                        " OverheadPercent                    =  " + overheadPercent + ", " +
                        " ProfitPercent                      =  " + profitPercent + ", " +
                        " SubcontractAdministrationPercent   =  " + subcontractAdministrationPercent + ", " +
                        " WarrantyPercent                    =  " + warrantyPercent + ", " +
                        " BondPercent                        =  " + bondPercent + ", " +
                        " BIMRate                            =  " + BIMRate + ", " +

                        " ApprenticeLaborRate                =  " + apprenticeLaborRate + ", " +
                        " ElectricianLaborRate               =  " + electricianLaborRate + ", " +
                        " ForemanLaborRate                   =  " + foremanLaborRate + ", " +
                        " GeneralForemanLaborRate            =  " + generalForemanLaborRate + ", " +
                        " SuperintendentLaborRate            =  " + superintendentLaborRate + ", " +
                        " ProjectManagerLaborRate            =  " + projectManagerLaborRate + ", " +
                        " ProjectEngineerLaborRate           =  " + projectEngineerLaborRate + ", " +
                        " SafetyMeetingsLaborRate            =  " + safetyMeetingsLaborRate + ", " +
                        " PremiumTimeLaborRate               =  " + premiumTimeLaborRate + ", " +
                        " JobDefaultRFIContactID             =  " + jobDefaultRFIContactID + ", " +
                        " JobDefaultChangeOrderContactID     =  " + jobDefaultChangeOrderContactID + ", " +
                        " JobDefaultFromID                   =  " + jobDefaultFromID + ", " +
                        " JobForemanID                       =  " + jobForemanID + ", " +

                        " BIMRateOT                          =  " + BIMRateOT + ", " +

                        " ApprenticeLaborRateOT                =  " + apprenticeLaborRateOT + ", " +
                        " ElectricianLaborRateOT               =  " + electricianLaborRateOT + ", " +
                        " ForemanLaborRateOT                   =  " + foremanLaborRateOT + ", " +
                        " GeneralForemanLaborRateOT            =  " + generalForemanLaborRateOT + ", " +
                        " SuperintendentLaborRateOT            =  " + superintendentLaborRateOT + ", " +
                        " ProjectManagerLaborRateOT            =  " + projectManagerLaborRateOT + ", " +
                        " ProjectEngineerLaborRateOT           =  " + projectEngineerLaborRateOT + ", " +
                        " SafetyMeetingsLaborRateOT            =  " + safetyMeetingsLaborRateOT + ", " +
                        " PremiumTimeLaborRateOT               =  " + premiumTimeLaborRateOT + ", " +

                        " BIMRateDT                            =  " + BIMRateDT + ", " +
                        " ApprenticeLaborRateDT                =  " + apprenticeLaborRateDT + ", " +
                        " ElectricianLaborRateDT               =  " + electricianLaborRateDT + ", " +
                        " ForemanLaborRateDT                   =  " + foremanLaborRateDT + ", " +
                        " GeneralForemanLaborRateDT            =  " + generalForemanLaborRateDT + ", " +
                        " SuperintendentLaborRateDT            =  " + superintendentLaborRateDT + ", " +
                        " ProjectManagerLaborRateDT            =  " + projectManagerLaborRateDT + ", " +
                        " ProjectEngineerLaborRateDT           =  " + projectEngineerLaborRateDT + ", " +
                        " SafetyMeetingsLaborRateDT            =  " + safetyMeetingsLaborRateDT + ", " +
                        " PremiumTimeLaborRateDT               =  " + premiumTimeLaborRateDT + " ," +


                        " BIMRate_Label                            =  '" + BIMRate_Label.Trim() + "'," +
                        " ApprenticeLaborRate_Label                = '" + apprenticeLaborRate_Label.Trim() + "'," +
                        " ElectricianLaborRate_Label               =  '" + electricianLaborRate_Label.Trim() + "'," +
                        " ForemanLaborRate_Label                  = '" + foremanLaborRate_Label.Trim() + "', " +
                        " GeneralForemanLaborRate_Label            = '" + generalForemanLaborRate_Label.Trim() + "'," +
                        " SuperintendentLaborRate_Label           =  '" + superintendentLaborRate_Label.Trim() + "'," +
                        " ProjectManagerLaborRate_Label            = '" + projectManagerLaborRate_Label.Trim() + "'," +
                        " ProjectEngineerLaborRate_Label           = '" + projectEngineerLaborRate_Label.Trim() + "'," +
                        " SafetyMeetingsLaborRate_Label            =  '" + safetyMeetingsLaborRate_Label.Trim() + "'," +
                        " PremiumTimeLaborRate_Label               =  '" + premiumTimeLaborRate_Label.Trim() + "'," +
                        " FringeBenefitsPercent_Label               =  '" + FringeBenefitsPercent_Label.Trim() + "'," +
                        " SafetyMeetingPercent_Label               =  '" + SafetyMeetingPercent_Label.Trim() + "'" +



                        " WHERE JobID                        =  " + jobID + " ";
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
