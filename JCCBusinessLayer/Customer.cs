using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;


namespace JCCBusinessLayer
{
    public class Customer
    {
        public Customer()
        {
        }
   
        public static DataSet GetCustomer(string customerID)
        {
            string query = "";

            query = "SELECT * FROM tblCustomer WHERE CustomerID = '" + customerID + "' ";
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
