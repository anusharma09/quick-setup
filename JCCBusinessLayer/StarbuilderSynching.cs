using BakirAndAssociates.DatabaseUtil;
using System;
using System.Data;
using System.Threading.Tasks;

namespace JCCBusinessLayer
{
    public class StarbuilderSynching
    {

        public static bool? isActive = null;

        public static bool IsSynchingActiveWithStarbuilder
        {
            get
            {
                return Convert.ToBoolean(StarbuilderSynching.IsSynchingOnWithStarbuilder().Tables[0].Rows[0].ItemArray[0]);
            }
        }
        public static DataSet IsSynchingOnWithStarbuilder()
        {
            string query = "";

            query = "SELECT ACTIVE FROM Synchronization";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateSynching(bool value)
        {
            string query = "";
            query = "UPDATE Synchronization SET Active ='" + value + "'";
            //query = "EXEC DMUpdate";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                isActive = value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async void syncChangeOrders()
        {
            await Task.Run(new Action(StartSynchingwithStarbuilder));

        }
        public static void StartSynchingwithStarbuilder()
        {
            string query = "";
            query = "Exec SyncChangeOrdersWithStarBuilder";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
