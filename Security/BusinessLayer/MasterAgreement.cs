using ContraCostaElectric.DatabaseUtil;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Security.BusinessLayer
{
    public class MasterAgreement
    {
        private string masterAgreementID;
        private readonly string company;
        private readonly string masterNumber;
        private readonly string contractDate;
        private readonly string signedDate;

        public string MasterAgreementID => masterAgreementID;

        public MasterAgreement ()
        {
        }
        public MasterAgreement ( string masterAgreementID,
                       string company,
                       string masterNumber,
                       string contractDate,
                       string signedDate)
        {
            this.masterAgreementID = masterAgreementID;
            this.company = company.Trim().Replace("'", "''");
            this.masterNumber = masterNumber.Trim().Replace("'", "''");
            this.contractDate = String.IsNullOrEmpty(contractDate) ? contractDate : Convert.ToDateTime(contractDate).ToShortDateString().Trim().Replace("'", "''");
            this.signedDate = String.IsNullOrEmpty(signedDate) ? signedDate : Convert.ToDateTime(signedDate).ToShortDateString().Trim().Replace("'", "''");
        }
        //
        public static DataSet GetMasterAgreements ()
        {
            string query = "";
            query = " SELECT " +
                    " MasterAgreementID, " +
                    " Company,  " +
                    " MasterNumber, " +
                    " ContractDate, " +
                    " DateSigned " +
                    " FROM tblMasterAgreement";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Save ()
        {
            if (masterAgreementID == "" || masterAgreementID == "0")
            {
                Insert();
            }
            else
            {
                Update();
            }
        }
        //
        private void Insert ()
        {
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@company", company);
            par[1] = new SqlParameter("@masterNumber", masterNumber);
            par[2] = new SqlParameter("@contractDate", contractDate);
            par[3] = new SqlParameter("@signedDate", signedDate);
            try
            {
                DataSet ds = DataBaseUtil.ExecuteParDataset("dbo.up_InsertMasterAgreement", Security.Connection, CommandType.StoredProcedure, par);
                if (ds.Tables[0].Columns.Count > 0)
                {
                    masterAgreementID = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        private bool Update ()
        {
            string query = "";

            query = "Update tblMasterAgreement SET " +
                    " Company                 = '" + company + "', " +
                    " MasterNumber    = '" + masterNumber + "', " +
                    " contractDate                 = '" + contractDate + "', " +
                    " DateSigned                 = '" + signedDate + "'" +
                    " WHERE MasterAgreementID  = " + masterAgreementID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static void Delete ( string masterAgreementID )
        {
            string query = "";
            try
            {
                query = "DELETE FROM tblMasterAgreement WHERE MasterAgreementID = " + masterAgreementID + " ";
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
