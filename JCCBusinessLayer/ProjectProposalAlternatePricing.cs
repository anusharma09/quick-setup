using BakirAndAssociates.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCCBusinessLayer
{
    public class ProjectProposalAlternatePricing
    {
        private readonly string Alternate;
        private readonly string AlternatePrice;
        private readonly string REV;
        private readonly string User;

        private string alternateID;
       public string AlternateID { get { return AlternateID; } }
        public string ProposalID { get; }

        public ProjectProposalAlternatePricing(string Alternate, string AlternatePrice, string AlternateID, string ProposalID, string user ,string rev )
        {
            this.alternateID = AlternateID;
            this.ProposalID = ProposalID;
            this.Alternate = "'" + Alternate.Trim().Replace("'", "''") + "'";
            this.AlternatePrice = String.IsNullOrEmpty(AlternatePrice) ? "Null" : "'" + AlternatePrice + "'";
            this.REV = String.IsNullOrEmpty(rev) ? "Null" : "'" + rev + "'";
            this.User = String.IsNullOrEmpty(user) ? "Null" : "'" + user + "'";
        }

        public bool Save()
        {
            if (string.IsNullOrEmpty(alternateID))
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";
            query = "INSERT INTO tblMasterProposalAlternate(Alternate, AlternatePrice, ProposalID, REV,[User]) VALUES (" +
                    Alternate + ", " + AlternatePrice + ", " + ProposalID + "," + REV + "," + User + ")" +
                    " Select @@IDENTITY ";
            try
            {
                alternateID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Delete(string alternateID, int proposalID, int rev, int user )
        {
            try
            {
                string query = "";

                query = " DELETE FROM tblMasterProposalAlternate WHERE AlternateID=  " + alternateID + " and  ProposalID = " + proposalID + " and REV=" + rev + " and [user]=" + user + " ";
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

            query = "Update tblMasterProposalAlternate     SET " +
                    " Alternate                 = " + Alternate + ", " +
                    " AlternatePrice                  = " + AlternatePrice + " " +
                    " WHERE AlternateID=  " + alternateID + " and  ProposalID = " + ProposalID + " and REV=" + REV + " and [user]=" + User + " ";
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
