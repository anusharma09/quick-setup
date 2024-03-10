using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;
namespace JCCContactManagement.BusinessLayer
{
    class LotusNotes
    {

        public static DataTable GetLotusContacts()
        {
            string query = " SELECT " +
             " CMContactLastName, " +
             " CMContactFirstName, " +
             " CMContactInitial, " +
             " CMContactSalutation, " +  // -- Suffix 
             " CMContactEmail, " +
             " CMCompanyName, " +
             " CMTitleDescription, " +  // -- Job Tilte 
             " CMContactAddress, " +
             " CMContactCity, " +
             " CMContactState, " +
             " CMContactZip, " +
             " CMContactPhone, " +
             " CMContactFax, " +
             " CMContactMobile " +
             " FROM tblCMContact c " +
             " LEFT JOIN tblCMCOmpany cc ON c.CMCompanyID = cc.CMCompanyID " +
             " LEFT JOIN tblCMTitle t ON c.CMContactTitle = t.CMTitleID " +
             " WHERE CMLotusNotes = 1 ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
