using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobSubmittalStatus
    {
       
        public JobSubmittalStatus()
        {
        }
        //
        public static DataSet GetJobSubmittalStatus()
        {
            string query = "";

            query = " SELECT * FROM tblJobSubmittalStatus ";

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
