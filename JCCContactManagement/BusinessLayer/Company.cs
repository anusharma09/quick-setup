using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMCompany
    {
        private string cmCompanyID;
        private string cmCompanyParentID;
        private string cmCompanyName;
        private string cmContactAddress;
        private string cmContactAddress2;
        private string cmContactCity;
        private string cmContactState;
        private string cmContactZip;
        private string cmContactCountry;
        private string cmContactPhone;
        private string cmContactFax;
        private string cmContactTollFree;
        private string cmContactWebSite;
        private string cmCompanyStatus;
        private string cmCompanyReferredBy;
        private string cmCompanyDivision;
        private string cmCompanyIndustry;
        private string cmCompanyRevenue;
        private string cmCompanyNumberOfEmployees;
        private string cmCompanyRegion;
        private string cmCompanyTerritory;
        private string cmCompanyDescription;
        private string cmCompanyCreateDate;
        private string cmCompanyCreateBy;
        private string cmCompanyEditDate;
        private string cmCompanyEditBy;





        private string cmContactCreateDate;
        private string cmContactCreateBy;
        private string cmContactEditDate;
        private string cmContactEditBy;


        //
        public string CMContactID
        {
            get { return cmContactID; }
        }
        //
        public CMCompany()
        {
        }
        //
        public CMCompany(string cmContactID,
                         string cmCompanyID,
                         string cmContact,
                         string cmContactSalutation,
                         string cmContactKeyContact,
                         string cmContactTitle,
                         string cmContactDepartment,
                         string cmContactStatus,
                         string cmContactReferredBy,
                         string cmContactPhone,
                         string cmContactPhoneExtension,
                         string cmContactMobile,
                         string cmContactFax,
                         string cmContactEmail,
                         string cmContactWebSite,
                         string cmContactAddress,
                         string cmContactAddress2,
                         string cmContactCity,
                         string cmContactState,
                         string cmContactZip,
                         string cmContactCountry,
                         string cmContactCreateDate,
                         string cmContactCreateBy,
                         string cmContactEditDate,
                         string cmContactEditBy)
        {
            this.cmContactID = String.IsNullOrEmpty(cmContactID) ? "" : cmContactID;
            this.cmCompanyID = String.IsNullOrEmpty(cmCompanyID) ? "null" : cmCompanyID;
            this.cmContact = cmContact.Trim().Replace("'", "''");
            this.cmContactSalutation = cmContactSalutation.Trim("'", "''");
            this.cmContactKeyContact = cmContactKeyContact == "True" ? "1" : "0";
            this.cmContactTitle = String.IsNullOrEmpty(cmContactTitle) ? "null" : cmContactTitle;
            this.cmContactDepartment = String.IsNullOrEmpty(cmContactDepartment) ? "null" : cmContactDepartment;
            this.cmContactStatus = String.IsNullOrEmpty(cmContactStatus) ? "null" : cmContactStatus;
            this.cmContactReferredBy = String.IsNullOrEmpty(cmContactReferredBy) ? "null" : cmContactReferredBy;
            this.cmContactPhone = cmContactPhone.Trim().Replace("'", "''");
            this.cmContactPhoneExtension = cmContactPhoneExtension.Trim().Replace("'", "''");
            this.cmContactMobile = cmContactMobile.Trim().Replace("'", "''");
            this.cmContactFax = cmContactFax.Trim().Replace("'", "''");
            this.cmContactEmail = cmContactEmail.Trim().Replace("'", "''");
            this.cmContactWebSite = cmContactWebSite.Trim().Replace("'", "''");
            this.cmContactAddress = cmContactAddress.Trim().Replace("'", "''");
            this.cmContactAddress2 = cmContactAddress2.Trim().Replace("'", "''");
            this.cmContactCity = cmContactCity.Trim().Replace("'", "''");
            this.cmContactState = cmContactState.Trim().Replace("'", "''");
            this.cmContactZip = cmContactZip.Trim().Replace("'", "''");
            this.cmContactCountry = cmContactCountry.Trim().Replace("'", "''");
            this.cmContactCreateDate = String.IsNullOrEmpty(cmContactCreateDate) ? "null" : "'" + cmContactCreateDate + "'";
            this.cmContactCreateBy = cmContactCreateBy.Trim().Replace("'", "''");
            this.cmContactEditDate = String.IsNullOrEmpty(cmContactEditDate) ? "null" : "'" + cmContactEditDate + "'";
            this.cmContactEditBy = cmContactEditBy.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmContactID == "" || cmContactID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = " INSERT INTO tblCMContact( " +
                    " CMCompanyID, " +
                    " CMContact, " +
                    " CMContactSalutation, " +
                    " CMContactKeyContact, " +
                    " CMContactTitle, " +
                    " CMContactDepartment, " +
                    " CMContactStatus, " +
                    " CMContactReferredBy, " +
                    " CMContactPhone, " +
                    " CMContactPhoneExtension, " +
                    " CMContactMobile, " +
                    " CMContactFax, " +
                    " CMContactEmail, " +
                    " CMContactWebSite, " +
                    " CMContactAddress, " +
                    " CMContactAddress2, " +
                    " CMContactCity, " +
                    " CMContactState, " +
                    " CMContactZip, " +
                    " CMContactCountry, " +
                    " CMContactCreateDate, " +
                    " CMContactCreateBy, " +
                    " CMContactEditDate, " +
                    " CMContactEditBy) VALUES ( " +
                    cmCompanyID + ", " +
                    "'" + cmContact + ", " +
                    "'" + cmContactSalutation + "', " +
                    cmContactKeyContact + ", " +
                    cmContactTitle + ", " +
                    cmContactDepartment + ", " +
                    cmContactStatus + ", " +
                    cmContactReferredBy + ", " +
                    "'" + cmContactPhone + "', " +
                    "'" + cmContactPhoneExtension + "', " +
                    "'" + cmContactMobile + "', " +
                    "'" + cmContactFax + "', " +
                    "'" + cmContactEmail + "', " +
                    "'" + cmContactWebSite + "', " +
                    "'" + cmContactAddress + "', " +
                    "'" + cmContactAddress2 + "', " +
                    "'" + cmContactCity + "', " +
                    "'" + cmContactState + "', " +
                    "'" + cmContactZip + "', " +
                    "'" + cmContactCountry + "', " +
                    cmContactCreateDate + ", " +
                    "'" + cmContactCreateBy + "', " +
                    cmContactEditDate + ", " +
                    "'" + cmContactEditBy + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmContactID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMContact SET " +
                    " CMCompanyID               =  " + cmCompanyID + ", " +
                    " CMContact                 = '" + cmContact + ", " +
                    " CMContactSalutation       = '" + cmContactSalutation + "', " +
                    " CMContactKeyContact       =  " + cmContactKeyContact + ", " +
                    " CMContactTitle            =  " + cmContactTitle + ", " +
                    " CMContactDepartment       =  " + cmContactDepartment + ", " +
                    " CMContactStatus           =  " + cmContactStatus + ", " +
                    " CMContactReferredBy       =  " + cmContactReferredBy + ", " +
                    " CMContactPhone            = '" + cmContactPhone + "', " +
                    " CMContactPhoneExtension   = '" + cmContactPhoneExtension + "', " +
                    " CMContactMobile           = '" + cmContactMobile + "', " +
                    " CMContactFax              = '" + cmContactFax + "', " +
                    " CMContactEmail            = '" + cmContactEmail + "', " +
                    " CMContactWebSite          = '" + cmContactWebSite + "', " +
                    " CMContactAddress          = '" + cmContactAddress + "', " +
                    " CMContactAddress2         = '" + cmContactAddress2 + "', " +
                    " CMContactCity             = '" + cmContactCity + "', " +
                    " CMContactState            = '" + cmContactState + "', " +
                    " CMContactZip              = '" + cmContactZip + "', " +
                    " CMContactCountry          = '" + cmContactCountry + "', " +
                    " CMContactCreateDate       =  " + cmContactCreateDate + ", " +
                    " CMContactCreateBy         = '" + cmContactCreateBy + "', " +
                    " CMContactEditDate         =  " + cmContactEditDate + ", " +
                    " CMContactEditBy           = '" + cmContactEditBy + "' " +
                    " WHERE CMContactID            = " + cmContactID;

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
        public static void Delete(string cmContactID)
        {
            string query = "Delete FROM tblCMContact WHERE CMContactID = " + cmContactID;
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
        public static DataSet GetCMContactList()
        {
            string query = "";

            query = " SELECT CMContactID, " +
                    " CMCompanyID               AS [Company], " +
                    " CMContact                 AS [Contact], " +
                    " CMContactSalutation       AS [Salutation], " +
                    " CMContactKeyContact       AS [Key Contact], " +
                    " CMContactTitle            AS [Title], " +
                    " CMContactDepartment       AS [Department], " +
                    " CMContactStatus           AS [Status], " +
                    " CMContactReferredBy       AS [Referred By], " +
                    " CMContactPhone            AS [Phone], " +
                    " CMContactPhoneExtension   AS [Ext.], " +
                    " CMContactMobile           AS [Mobile], " +
                    " CMContactFax              AS [Fax], " +
                    " CMContactEmail            AS [Email], " +
                    " CMContactWebSite          AS [Web Site], " +
                    " CMContactAddress          AS [Address], " +
                    " CMContactAddress2         AS [Address2], " +
                    " CMContactCity             AS [City], " +
                    " CMContactState            AS [Statue], " +
                    " CMContactZip              AS [Zip], " +
                    " CMContactCountry          AS [Country], " +
                    " CMContactCreateDate       AS [Create Date], " +
                    " CMContactCreateBy         AS [Create By], " +
                    " CMContactEditDate         AS [Edit Date], " +
                    " CMContactEditBy           AS [Edit By] " +
                    " FROM  tblCMContact  " +
                    " ORDER BY CMContact ";
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
