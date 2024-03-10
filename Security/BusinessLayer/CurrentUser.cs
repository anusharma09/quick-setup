using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;

namespace Security.BusinessLayer
{
    class CurrentUser
    {
        //
        public CurrentUser()
        {
        }
        public static void GetCurrentUser()
        {
            //
            // Get UserID
            Security.LoginID = WindowsIdentity.GetCurrent().Name;
            // Change Login ID For Testing Purposes
            // the following line is used for testing purposes only
            // Security.LoginID = "EDUDLEY";
            // This is where we can change the Login-ID for different
            // users and replace Windows LoginID
            if (Security.LoginID.Contains("\\"))
            {
                Security.LoginID = Security.LoginID.Remove(0, Security.LoginID.LastIndexOf("\\") + 1);
            }
            //
            DataTable table;
            table = UserAccess.GetUsrID(Security.LoginID).Tables[0];
            if (table.Rows.Count > 0)
            {
                int titleID = 0;
                Security.UserID = int.Parse(table.Rows[0][0].ToString());
                int.TryParse(table.Rows[0][1].ToString(), out titleID);
                Security.UserAccessTitle = (Security.AccessTitle)titleID;
            }
            else
            {
                Security.UserID = 0;
                Security.UserAccessTitle = Security.AccessTitle.NoTitle;
            }
            table = UserAccess.GetUserProgramAccess(Security.LoginID).Tables[0];
            if (table.Rows.Count > 0)
            {
                foreach (DataRow r in table.Rows)
                {
                    switch ((Security.Access)r["AccessID"])
                    {
                        case Security.Access.ApplicationAdministrator:
                        case Security.Access.JCCAdministrator:
                        case Security.Access.JCCSuperUser:
                        case Security.Access.JCCOffice:
                        case Security.Access.JCCDepartment:
                        case Security.Access.JCCOfficeDepartment:
                        case Security.Access.JCCUser:
                            Security.UserJCCAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        case Security.Access.JCCDashboardSuperUser:
                        case Security.Access.JCCDashboardOffice:
                        case Security.Access.JCCDashboardDepartment:
                        case Security.Access.JCCDashboardOfficeDepartment:
                        case Security.Access.JCCDashboardUser:
                            Security.UserJCCDashboardAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCDashboardAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        case Security.Access.JCCPurchasing:
                            Security.UserJCCPurchasingAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCPurchasingAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;

                       /* case Security.Access.JCCEquipment:
                        case Security.Access.JCCEquipmentAdministrator:
                            Security.UserJCCEquipmentAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCEquipmentAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        
                        case Security.Access.JCCTMAdministrator:
                        case Security.Access.JCCTMUser:
                            Security.UserJCCTMBillingAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCTMBillingAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        case Security.Access.JCCToolWatch:
                        case Security.Access.JCCToolWatchAdmin:
                        case Security.Access.JCCToolWatchOffice:
                           Security.UserJCCToolWatchAccess = (Security.Access)r["AccessID"];
                           Security.UserJCCToolWatchAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                           Security.hasAccess = true;
                            break;
                        case Security.Access.JCCInvoiceApproval:
                            Security.UserJCCInvoiceApprovalAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCInvoiceApprovalAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            break;
                        case Security.Access.JCCJobCost:
                            Security.UserJCCJobCostAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCJobCostAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break; */
                        case Security.Access.JCCProjectOpportunity5MApproval:
                        case Security.Access.JCCProjectOpportunityDepartment:
                        case Security.Access.JCCProjectOpportunityDepartmentApproval:
                        case Security.Access.JCCProjectOpportunityDepartmentCC:
                        case Security.Access.JCCProjectOpportunityOffice:
                        case Security.Access.JCCProjectOpportunityOfficeApproval:
                        case Security.Access.JCCProjectOpportunityOfficeCC:
                        case Security.Access.JCCProjectOpportunityOfficeDepartment:
                        case Security.Access.JCCProjectOpportunityOfficeDepartmentApproval:
                        case Security.Access.JCCProjectOpportunityOfficeDepartmentCC:
                        case Security.Access.JCCProjectOpportunitySuperUser:
                        case Security.Access.JCCProjectOpportunitySuperUserApproval:
                        case Security.Access.JCCProjectOpportunitySuperUserCC:
                        case Security.Access.JCCProjectOpportunityUser:
                        case Security.Access.JCCProjectOpportunityWorktype:
                            Security.UserJCCProjectOpportunityAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCProjectOpportunityAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        case Security.Access.JCCInvoicePayment:
                            Security.UserJCCInvoicePaymentAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCInvoicePaymentAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;

                     /*   case Security.Access.JCCContactManagementAdmin:
                        case Security.Access.JCCContactManagementUser:
                            Security.UserJCCContactManagementAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCContactManagementAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        */
                        case Security.Access.JCCEquipmentRentalAdmin:
                        case Security.Access.JCCEquipmentRentalAdminMail:
                        case Security.Access.JCCEquipmentRentalUser:
                            Security.UserJCCEquipmentRentalAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCEquipmentRentalAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        case Security.Access.JCCSmallPOAdmin:
                        case Security.Access.JCCSmallPOUser:
                            Security.UserJCCSmallPOAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCSmallPOAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;

                        case Security.Access.JCCImportStarbuilderJobs:
                            Security.UserJCCImportStarbuilderJobsAccess = (Security.Access)r["AccessID"];
                            Security.UserJCCImportStarbuilderJobsAccessLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        case Security.Access.JCCFieldOperation:
                            Security.UserJCCFieldOperation = (Security.Access)r["AccessID"];
                            Security.UserJCCFieldOperationLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                        case Security.Access.JCCGlobalContact:
                            Security.UserJCCGlobalContact = (Security.Access)r["AccessID"];
                            Security.UserJCCGlobalContactLevel = (Security.AccessLevel)r["AccessLevelID"];
                            Security.hasAccess = true;
                            break;
                    }
               }
            }
        }
        //
        public static bool UtilitiesAccess()
        {
            string query = "";
            bool utilitiesAccess = false;
            DataTable dt;
            query = "SELECT * FROM tblUser WHERE UserLANID = '" + Security.LoginID + "' ";
            try
            {
                dt = DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text).Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        utilitiesAccess = Convert.ToBoolean(dt.Rows[0]["Utilities"].ToString());
                    else
                        utilitiesAccess = false;
                }
                return utilitiesAccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
