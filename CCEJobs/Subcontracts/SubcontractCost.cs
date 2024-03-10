using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;
using JCCBusinessLayer;


namespace CCEJobs.Subcontracts
{
    class SubcontractCost
    {
        private string subcontractCostCodeID; 
        private string subcontractChangeOrderID;
        private string subcontractCostCodePhaseID;
        private string subcontractChangeOrderNumber;
        private string description;
        private string cost;
        // 
        // Phase Variables for new Phase Record
        //
        private string subcontractID;
        private string subcontractCostCodeType;
        private string subcontractCostCodePhase;
        private string costCode;
        private string costCodeTitle;
        private string costCodeDescription;
        //
        public SubcontractCost()
        {
        }
        public SubcontractCost(string subcontractCostCodeID,
                        string subcontractChangeOrderID,
                        string subcontractChangeOrderNumber,
                        string subcontractCostCodePhaseID,
                        string description,
                        string cost,
                        string subcontractID,
                        string subcontractCostCodeType,
                        string subcontractCostCodePhase,
                        string costCode,
                        string costCodeTitle,
                        string costCodeDescription)
        {
            
            this.subcontractCostCodeID = subcontractCostCodeID;
            this.subcontractChangeOrderID = subcontractChangeOrderID;
            this.subcontractCostCodePhaseID = subcontractCostCodePhaseID;
            this.subcontractChangeOrderNumber = subcontractChangeOrderNumber;
            this.description = description.Trim().ToUpper().Replace("'","''");
            this.cost = String.IsNullOrEmpty(cost) ? "Null" : cost;
            this.subcontractID = subcontractID;
            this.subcontractCostCodeType = subcontractCostCodeType;
            this.subcontractCostCodePhase = subcontractCostCodePhase;
            this.costCode = costCode;
            this.costCodeTitle = costCodeTitle.Trim().ToUpper().Replace("'","''");
            this.costCodeDescription = costCodeDescription.Trim().ToUpper().Replace("'", "''");
            
        }
       
        public static bool Remove(string subcontractCostCodeID )
        {
            string query = "";

            query = "DELETE FROM tblSubcontractCostCode WHERE SubcontractCostCodeID = " + subcontractCostCodeID;
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
        
        public bool Save()
        {
            string commentQuery = "";
            if (subcontractCostCodePhaseID == "")
            {
                string query = "";

                try
                {
                    query = "Select SubcontractCostCodePhaseID FROM tblSubcontractCostCodePhase WHERE subcontractID = " + subcontractID + "  AND " +
                            " SubcontractCostCodeType = '" + subcontractCostCodeType + "' AND " +
                            " SubcontractCostCodePhase = '" + subcontractCostCodePhase + "' AND " +
                            " CostCode = '" + costCode + "' ";

                    subcontractCostCodePhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    if (subcontractCostCodePhaseID.Trim() == "")
                    {
                        query = "INSERT INTO tblSubcontractCostCodePhase (SubcontractID, SubcontractCostCodeType, SubcontractCostCodePhase, CostCode, CostCodeTitle, CostCodeDescription, userDescription) VALUES (" +
                            subcontractID + ",'" + subcontractCostCodeType + "', '" + subcontractCostCodePhase + "', '" + costCode + "', '" + costCodeTitle + "', '" + costCodeDescription + "', '" + description +  "') " +
                            "Select @@IDENTITY ";
                        subcontractCostCodePhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    }

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                if (subcontractChangeOrderNumber == "0")
                {
                   string query = "UPDATE  tblSubcontractCostCodePhase SET userDescription = '" + description + "'  WHERE subcontractCostCodePhaseID = " + subcontractCostCodePhaseID;
                    DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                }
            }

            // Create the comment Item
           // commentQuery = "Select SubcontractCostCodePhaseID FROM tblSubcontractCostCodePhaseComment WHERE  SubcontractCostCodePhaseID  = " + subcontractChangeOrderID + "   " +
           //         " IF @@ROWCOUNT = 0 " +
           //         " INSERT INTO tblSubcontractCostCodePhaseComment(SubcontractCostCodePhaseID) VALUES(" + subcontractCostCodePhaseID + ") ";
           // DataBaseUtil.ExecuteNonQuery(commentQuery, CCEApplication.Connection, CommandType.Text);


            if (subcontractCostCodeID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblSubcontractCostCode(SubcontractChangeOrderID, SubcontractCostCodePhaseID, Description, Cost, Selected) Values(" +
                    subcontractChangeOrderID + ", " + subcontractCostCodePhaseID + ", '" + description + "', "  + cost + ", 1)";
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

        private bool Update()
        {
            string query = "";

            query = "Update tblSubcontractCostCode SET " +
                    " Description               = '" + description + "', " +
                    " cost                      = " + cost + " " +
                    " WHERE SubcontractCostCodeID = " + subcontractCostCodeID;
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




