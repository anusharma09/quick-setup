using System;
using System.Collections.Generic;
using System.Text;
using Security.BusinessLayer;

namespace Security
{
    public class Security
    {
        public static bool currentJobReadOnly = false;
        public static bool hasAccess = false;
        public static string Connection;
        public static string ApplicationName = "Security";
        public static Security.Access UserJCCAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCAccessLevel = AccessLevel.NoAccess;
        public static Security.Access UserJCCDashboardAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCDashboardAccessLevel = AccessLevel.NoAccess;
        public static Security.Access UserJCCPurchasingAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCPurchasingAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCEquipmentAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCEquipmentAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCTMBillingAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCTMBillingAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCToolWatchAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCToolWatchAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCInvoiceApprovalAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCInvoiceApprovalAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCJobCostAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCJobCostAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCProjectOpportunityAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCProjectOpportunityAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCInvoicePaymentAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCInvoicePaymentAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCContactManagementAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCContactManagementAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCEquipmentRentalAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCEquipmentRentalAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCSmallPOAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCSmallPOAccessLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCImportStarbuilderJobsAccess = Access.NoAccess;
        public static Security.AccessLevel UserJCCImportStarbuilderJobsAccessLevel = AccessLevel.NoAccess;
        public static Security.Access UserJCCFieldOperation = Access.NoAccess;
        public static Security.AccessLevel UserJCCFieldOperationLevel = AccessLevel.NoAccess;

        public static Security.Access UserJCCGlobalContact = Access.NoAccess;
        public static Security.AccessLevel UserJCCGlobalContactLevel = AccessLevel.NoAccess;


        public static string LoginID;
        public static int UserID;
        public static AccessTitle UserAccessTitle;
        //
        public enum JobCaller
        {
            NoAccess,
            JCCDashboard,
            JCCJob
        }
        //
        public enum Access
        {
            NoAccess,
            ApplicationAdministrator,
            JCCAdministrator,
            JCCSuperUser,
            JCCOffice,
            JCCDepartment,
            JCCOfficeDepartment,
            JCCUser,
            JCCDashboardSuperUser,
            JCCDashboardOffice,
            JCCDashboardDepartment,
            JCCDashboardOfficeDepartment,
            JCCDashboardUser,
            JCCPurchasing,
            JCCEquipment,
            JCCTMAdministrator,
            JCCTMUser,
            JCCToolWatch,
            JCCEquipmentAdministrator,
            JCCInvoiceApproval,
            JCCJobCost,
            JCCProjectOpportunitySuperUser,
            JCCProjectOpportunitySuperUserApproval,
            JCCProjectOpportunitySuperUserCC,
            JCCProjectOpportunity5MApproval,
            JCCProjectOpportunityOffice,
            JCCProjectOpportunityOfficeApproval,
            JCCProjectOpportunityOfficeCC,
            JCCProjectOpportunityDepartment,
            JCCProjectOpportunityDepartmentApproval,
            JCCProjectOpportunityDepartmentCC,
            JCCProjectOpportunityOfficeDepartment,
            JCCProjectOpportunityOfficeDepartmentApproval,
            JCCProjectOpportunityOfficeDepartmentCC,
            JCCProjectOpportunityUser,
            JCCProjectOpportunityWorktype,
            JCCInvoicePayment,
            JCCToolWatchOffice,
            JCCToolWatchAdmin,
            JCCContactManagementUser,
            JCCContactManagementAdmin,
            JCCEquipmentRentalUser,
            JCCEquipmentRentalAdmin,
            JCCEquipmentRentalAdminMail,
            JCCSmallPOUser,
            JCCSmallPOAdmin,
            JCCImportStarbuilderJobs,
            JCCFieldOperation,
            JCCGlobalContact
        }
        public enum AccessLevel
        {
            NoAccess,
            ReadOnly,
            ReadWrite,
            ReadWriteCreate,
            RedWriteCreateSB
        }
        public enum AccessTitle
        {
            NoTitle,
            Foreman,
            WIPPreparation
        }

        public static void SetCurrentJobReadOnly(string status)
        {
            string s = "";
            s = String.IsNullOrEmpty(status) ? "" : status;
            if (s == "True")
                currentJobReadOnly = true;
            else
                currentJobReadOnly = false;
        }


        public static void GetUserAccess()
        {
            CurrentUser.GetCurrentUser();
        }
        public static bool StartSecurity()
        {
            if (Security.UserJCCAccess == Access.ApplicationAdministrator)
            {
                StaticTables.PopulateStaticTables();
                frmSecurityMaintenance frm = new frmSecurityMaintenance();
                frm.ShowDialog();
                return true;
            }
            else
                return false;
        }

        public static bool StartMasterAgreement ()
        {
            if (Security.UserJCCAccess == Access.ApplicationAdministrator)
            {
                frmMasterAgreementNumber frm = new frmMasterAgreementNumber();
                frm.ShowDialog();
                return true;
            }
            else
                return false;
        }
    }
}
