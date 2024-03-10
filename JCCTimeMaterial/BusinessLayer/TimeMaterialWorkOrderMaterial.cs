using System;
using System.Collections.Generic;
using System.Text;
using ContraCostaElectric.DatabaseUtil;
using System.Data;

namespace JCCTimeMaterial.BusinessLayer
{
    class TimeMaterialWorkOrderMaterial
    {
        private string jobTimeMaterialWorkOrderMaterialID;
        private string jobTimeMaterialWorkOrderID;
        private string materialQuantity;
        private string materialDescription;
        //
        public TimeMaterialWorkOrderMaterial()
        {
        }
        //
        public TimeMaterialWorkOrderMaterial(string jobTimeMaterialWorkOrderMaterialID,
                                     string jobTimeMaterialWorkOrderID,
                                     string materialQuantity,
                                     string materialDescription)
        {
            this.jobTimeMaterialWorkOrderMaterialID = jobTimeMaterialWorkOrderMaterialID;
            this.jobTimeMaterialWorkOrderID = jobTimeMaterialWorkOrderID;
            this.materialQuantity = "'" + materialQuantity.Trim().Replace("'", "''") + "'";
            this.materialDescription = "'" + materialDescription.Trim().Replace("'", "''") + "'";
        }
        //
        public string JobTimeMaterialWorkOrderMaterialID
        {
            get { return jobTimeMaterialWorkOrderMaterialID; }
        }
        //
        public static DataSet GetJobTimeMaterialWorkOrderMaterial(string jobTimeMaterialWorkOrderID)
        {
            if (jobTimeMaterialWorkOrderID == "")
                jobTimeMaterialWorkOrderID = "0";

            string query = " SELECT * " +
                          " FROM tblJobTimeMaterialWorkOrderMaterial  " +
                          " WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " ";

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
        public static bool Remove(string jobTimeMaterialWorkOrderMaterialID)
        {
            string query = "";

            try
            {
                query = "DELETE FROM tblJobTimeMaterialWorkOrderMaterial WHERE JobTimeMaterialWorkOrderMaterialID = " + jobTimeMaterialWorkOrderMaterialID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobTimeMaterialWorkOrderMaterialID == "" || jobTimeMaterialWorkOrderMaterialID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobTimeMaterialWorkOrderMaterial(" +
                    " JobTimeMaterialWorkOrderID, " +
                    " MaterialQuantity, " +
                    " MaterialDescription " +
                    " ) VALUES ( " +
                    jobTimeMaterialWorkOrderID + ", " +
                    materialQuantity + ", " +
                    materialDescription + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobTimeMaterialWorkOrderMaterialID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobTimeMaterialWorkOrderMaterial SET " +
                    " JobTimeMaterialWorkOrderID            = " + jobTimeMaterialWorkOrderID + ", " +
                    " MaterialQuantity                      = " + materialQuantity + ", " +
                    " MaterialDescription                   = " + materialDescription + " " +
                    " WHERE JobTimeMaterialWorkOrderMaterialID = " + jobTimeMaterialWorkOrderMaterialID;
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
