using BakirAndAssociates.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCCBusinessLayer
{
    public class ProjectProposalPricing
    {
        private readonly string BaseBid;
        private readonly string Price;
        private readonly string REV;
        private readonly string User;

        private string pricingID;
        //public string PricingID { get { return PricingID; } }
        public string ProposalID { get; }

        public ProjectProposalPricing(string BaseBid, string Price, string pricingID, string ProposalID, string rev, string user)
        {
            this.pricingID = pricingID;
            this.ProposalID = ProposalID;
            this.BaseBid = "'" + BaseBid.Trim().Replace("'", "''") + "'";
            this.Price = String.IsNullOrEmpty(Price) ? "Null" : "'" + Price + "'";
            this.REV = String.IsNullOrEmpty(rev) ? "Null" : "'" + rev + "'";
            this.User = String.IsNullOrEmpty(user) ? "Null" : "'" + user + "'";
        }

        public bool Save()
        {
            if (pricingID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";
            query = "INSERT INTO tblMasterProposalPricing(BaseBid, Price, ProposalID, REV,[User]) VALUES (" +
                    BaseBid + ", " + Price + ", " + ProposalID + "," + REV + "," + User + ")" +
                    " Select @@IDENTITY ";
            try
            {
                pricingID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Delete(string pricingID, int proposalID, int rev, int user)
        {
            try
            {
                string query = "";

                query = " DELETE FROM tblMasterProposalPricing WHERE PricingID=  " + pricingID + " and  ProposalID = " + proposalID + " and REV=" + rev + " and [user]=" + user + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
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

            query = "Update tblEmployeeClassification     SET " +
                    " BaseBid                 = " + BaseBid + ", " +
                    " Price                  = " + Price + " " +
                    " WHERE PricingID=  " + pricingID + " and  ProposalID = " + ProposalID + " and REV=" + REV + " and [user]=" + User + " ";
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
