using ContraCostaElectric.DatabaseUtil;
using System;
using System.Data;
using System.Data.SqlClient;


namespace JCCBusinessLayer
{
    public class JobCost
    {
        private string jobCostCodeID;
        private string jobCostCodeRevID;
        private readonly string jobChangeOrderID;
        private string jobCostCodePhaseID;
        private string jobCostCodeRevPhaseID = "";
        private readonly string jobChangeOrderNumber;
        private readonly string description;
        private readonly string unit;
        private readonly string quantity;
        private readonly string hours;
        private readonly string cost;
        // 
        // Phase Variables for new Phase Record
        //
        private readonly string jobID;
        private readonly string jobCostCodeType;
        private readonly string jobCostCodePhase;
        private readonly string costCode;
        private readonly string costCodeTitle;
        private readonly string costCodeDescription;
        //
        public string JobCostCodeID => jobCostCodeID;
        //
        public JobCost()
        {
        }
        public JobCost(string jobCostCodeID,
                        string jobChangeOrderID,
                        string jobChangeOrderNumber,
                        string jobCostCodePhaseID,
                        string description,
                        string unit,
                        string quantity,
                        string hours,
                        string cost,
                        string jobID,
                        string jobCostCodeType,
                        string jobCostCodePhase,
                        string costCode,
                        string costCodeTitle,
                        string costCodeDescription)
        {

            this.jobCostCodeID = jobCostCodeID;
            this.jobChangeOrderID = jobChangeOrderID;
            this.jobCostCodePhaseID = jobCostCodePhaseID;
            this.jobChangeOrderNumber = jobChangeOrderNumber;
            this.description = description.Trim().ToUpper().Replace("'", "''");
            this.unit = unit;
            this.quantity = String.IsNullOrEmpty(quantity) ? "Null" : quantity;
            this.hours = String.IsNullOrEmpty(hours) ? "Null" : hours;
            this.cost = String.IsNullOrEmpty(cost) ? "Null" : cost;
            this.jobID = jobID;
            this.jobCostCodeType = jobCostCodeType;
            this.jobCostCodePhase = jobCostCodePhase;
            this.costCode = costCode;
            this.costCodeTitle = costCodeTitle.Trim().ToUpper().Replace("'", "''");
            this.costCodeDescription = costCodeDescription.Trim().ToUpper().Replace("'", "''");

        }
        //
        public static DataSet GetCostCodeRev(string jobChangeOrderID, string jobID, string revision)
        {
            if (jobChangeOrderID == "")
            {
                jobChangeOrderID = "0";
            }

            if (jobID == "")
            {
                jobID = "0";
            }

            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);
            par[1] = new SqlParameter("@JobID", jobID);
            par[2] = new SqlParameter("@Revision", revision);


            try
            {
                return DataBaseUtil.ExecuteParDataset("up_JCGetJobCostCodeByJobChangeOrderRev", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetCostCode(string jobChangeOrderID, string jobID)
        {
            if (jobChangeOrderID == "")
            {
                jobChangeOrderID = "0";
            }

            if (jobID == "")
            {
                jobID = "0";
            }

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);
            par[1] = new SqlParameter("@JobID", jobID);


            try
            {
                return DataBaseUtil.ExecuteParDataset("up_JCGetJobCostCodeByJobChangeOrder", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetCostCodeLaborFeedback(string jobID, string weekEnd)
        {
            if (jobID == "")
            {
                jobID = "0";
            }

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobID", jobID);
            par[1] = new SqlParameter("@SelectedDate", weekEnd);


            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_JCGetJobLaborFeedback", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobTemplate(string jobNumber)
        {
            string query = "";

            query = " DECLARE @JobChangeOrderID INT " +
                    " DECLARE @JobID  INT " +
                    " SELECT @JobID = JobID FROM tblJob WHERE JobNumber = '" + jobNumber + "' " +
                    " SELECT  @JobChangeOrderID = JobChangeOrderID " +
                    " FROM tblJobChangeOrder WHERE jobID = @JobID  and JobChangeOrderNumber = 0 " +
                    " SELECT JobCostCodeType, JobCostCodePhase, CostCode, f.Unit, UserDescription " +
                    " FROM tblJobCostCodePhase f " +
                    " INNER JOIN tblJobCostCode c " +
                    " ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                    " WHERE JobChangeOrderID = @JobChangeOrderID ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPhases(string jobID)
        {
            string query = "";

            query = " Select* FROM(SELECT  PhaseID, Phase + ' - ' + PhaseDescription as PhaseDesc, null as Job, Phase  FROM tblPhase " +
                "UNION ALL SELECT[PhaseId], Phase + ' - ' + PhaseDescription as PhaseDesc, JobId, Phase " +
                "FROM tblJobPhase WHERE JobId = " + jobID + ") RESULT ORDER BY Phase";

            //query = " Select * FROM(SELECT  PhaseID, Phase + ' - ' + PhaseDescription as PhaseDesc, Phase  FROM tblPhase" +
            //        " UNION ALL  SELECT[PhaseId] , Phase + ' - ' + PhaseDescription as PhaseDesc, Phase " +
            //        "FROM tblJobPhase WHERE JobId = "+ jobID + ") RESULT ORDER BY Phase ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //
        public static DataSet GetOriginalPhaseCodes(string jobID)
        {
            string query = "";

            query = " DECLARE @Selected             BIT  " +
                    " DECLARE @JobCostCodeID        INT  " +
                    " DECLARE @JobChangeOrderID     INT  " +
                    " DECLARE @JobCostCodePhaseID   INT  " +
                    " DECLARE @UserDescription      VARCHAR(100) " +
                    " DECLARE @Unit					varchar(2)  " +
                    " DECLARE @Quantity				FLOAT  " +
                    " DECLARE @Hours				FLOAT   " +
                    " DECLARE @Cost					FLOAT  " +
                    " SET @Selected = 0  " +
                    " SELECT  " +
                    " @JobCostCodeID AS [JobCostCodeID], " +
                    " @JobChangeOrderID AS [JobChangeOrderID], " +
                    " @JobCostCodePhaseID AS [JobCostCodePhaseID], " +
                    " @Selected AS [Selected],  " +
                    " c.JobCostCodeType AS [Type], " +
                    " c.JobCostCodePhase AS [Phase], " +
                    " c.CostCode AS [Code],  " +
                    " c.CostCodeTitle AS [Title], " +
                    " c.CostCodeDescription AS [Description], " +
                    " c.UserDescription AS [User Description], " +
                    " @Unit AS [Unit],  " +
                    " @Quantity AS [Quantity], " +
                    " @Hours AS [Hours],  " +
                    " @Cost AS [Cost $]  " +
                    " FROM tblJobCostCodePhase c WHERE JobID = " + jobID + " ";

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
        //
        public static DataSet GetPhaseCodes(string phaseID, string jobid, string phase)
        {
            string query = "";


            query = " DECLARE @Selected             BIT " +
                    " DECLARE @JobCostCodeID        INT " +
                    " DECLARE @JobChangeOrderID     INT " +
                    " DECLARE @JobCostCodePhaseID   INT " +
                    " DECLARE @UserDescription      VARCHAR(100) " +
                    " DECLARE @Unit					varchar(2)  " +
                    " DECLARE @Quantity				FLOAT " +
                    " DECLARE @Hours				FLOAT " +
                    " DECLARE @Cost					FLOAT " +
                    " SET @Selected = 0 " +
                    " SELECT " +
                    " @JobCostCodeID AS [JobCostCodeID], " +
                    " @JobChangeOrderID AS [JobChangeOrderID], " +
                    " @JobCostCodePhaseID AS [JobCostCodePhaseID], " +
                    " @Selected AS [Selected], " +
                    " c.[Type], " +
                    " p.[Phase], " +
                    " c.[Code], " +
                    " c.[Title], " +
                    " c.[Description], " +
                    " @UserDescription AS [User Description], " +
                    " @Unit AS [Unit], " +
                    " @Quantity AS [Quantity], " +
                    " @Hours AS [Hours], " +
                    " @Cost AS [Cost $] " +
                    " FROM tblPhaseCode c " +
                    " INNER Join tblPhase p ON c.Phase = 	p.PhaseCode " +
                    " WHERE p.PhaseID = " + phaseID + " " +
                    " Union all " +
                    "Select null, null, null, 0 as selected , Type, Phase, Code, Title, Description ,null,null,null,null,null " +
                    "from tblJobPhaseCode where JobId = " + jobid + " and Phase = " + phase;
            //            else
            //            {
            //                query = " DECLARE @Selected  BIT DECLARE @JobCostCodeID  INT  DECLARE @JobChangeOrderID " +
            //      "INT DECLARE @JobCostCodePhaseID " +
            //      "INT  DECLARE @UserDescription " +

            //       "  VARCHAR(100)  DECLARE @Unit" +

            //        " varchar(2)   DECLARE @Quantity" +

            //             "        FLOAT DECLARE @Hours " +
            //                      "     FLOAT  DECLARE @Cost" +

            //                        "    FLOAT SET @Selected = 0 " +
            //"SELECT @JobCostCodeID AS[JobCostCodeID],  @JobChangeOrderID AS " +
            //"[JobChangeOrderID], @JobCostCodePhaseID AS[JobCostCodePhaseID], " +
            //" @Selected AS[Selected], c.[Type],  p.[Phase],  c.[Code],  c.[Title],  c.[Description]," +
            //  " @UserDescription AS[User Description], @Unit AS[Unit],  @Quantity AS[Quantity]," +
            //  "@Hours AS[Hours],  @Cost AS[Cost $]  FROM tblJobPhaseCode c INNER Join tbljobPhase p ON c.Phase =" +
            //     "	p.Phase WHERE p.PhaseID = " + phaseID;
            //            }
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
        public static DataSet GetLaborPerformanceFactor(string jobID, string weekEnd)
        {
            string query = "";

            query = "SELECT JobLaborPerformanceFactorWeekly  FROM tblJobLaborPerformanceFactorWeekly " +
                    " WHERE JobID = " + jobID + "  AND Weekend = '" + weekEnd + "' ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetLaborAnalysis(string jobID)
        {
            string query = "";

            query = " DECLARE @JobNumber VARCHAR(10) " +
                    " SELECT @JobNumber = JobNumber FROM tblJob WHERE JobID = " + jobID + " " +
                    "SELECT  Type, Phase, Code , Description,  EmpName As [Emp Name] ,  Hours , Day1, Day2, Day3, Day4, Day5, Day6, Day7,  HoursType AS [Hours Type], Craft,  CAST(Convert(VARCHAR(20),weekend, 1) AS SMALLDATETIME) as [Weekend]  " +
                    " FROM  tblJobHour " +
                    " WHERE jobNumber =  @JobNumber  " +
                    " Order by Phase, Code, weekend, empName  ";
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
        public static DataSet GetLaborAnalysisFourDigit(string jobNumber)
        {
            string query = "";

            query = " SELECT  Type, Phase, Code , Description,  EmpName As [Emp Name] ,  Hours , Day1, Day2, Day3, Day4, Day5, Day6, Day7,  HoursType AS [Hours Type], Craft,  CAST(Convert(VARCHAR(20),weekend, 1) AS SMALLDATETIME) as [Weekend]  " +
                    " FROM  tblJobHour " +
                    " WHERE jobNumber = '" + jobNumber + "' " +
                    " Order by Phase, Code, weekend, empName  ";
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
        public static DataSet GetCostAnalysis(string jobID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobID", jobID);


            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_JCGetJobCostAnalysis", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetCostAnalysisFourDigit(string jobNumber)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobNumber", jobNumber);


            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_JCGetJobCostAnalysisFourDigits", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobPurchaseDetail(string jobNumber, int queryType)
        {
            string query1 = "";
            string query2 = "";
            if (queryType == 0 || queryType == 1 || queryType == 3)
            {
                query1 = "SELECT JobPOID, JobNumber, " +
                     " Category = " +
                          " CASE Category " +
                          " WHEN 'E'	THEN 'Equipment' " +
                          " WHEN  'R'	THEN 'Rental' " +
                          " WHEN  'S'	THEN  'SubContract' " +
                          " WHEN  'T'	THEN  'Tools' " +
                          " WHEN  'O'	THEN  'Other' " +
                          " WHEN  'C'	THEN  'Capital' " +
                          " WHEN  'W'	THEN  'Warehouse' " +
                          " WHEN  'A'	THEN  'Automotive' " +
                          " WHEN  'M'	THEN  'Material' " +
                          " WHEN  'I'	THEN 'Instrument'" +
                          " ELSE 'Material' " +
                          " END, " +

                    " PO, [Vendor Name], [Gross Amt], [Net Amt], [Ship Date], [Ship Name], [Invoices Total], Variance, [Remaining Balance], [Work Order], CommentFlag, Comment FROM tblJobPO WHERE JobNumber =  '" + jobNumber + "' AND PO Not Like 'N/A%'" +
                     " Order by PO ";
            }

            if (queryType == 2)
            {
                query1 = "SELECT JobPOID, j.JobNumber, " +

                    " Category = " +
                          " CASE Category " +
                          " WHEN 'E'	THEN 'Equipment' " +
                          " WHEN  'R'	THEN 'Rental' " +
                          " WHEN  'S'	THEN  'SubContract' " +
                          " WHEN  'T'	THEN  'Tools' " +
                          " WHEN  'O'	THEN  'Other' " +
                          " WHEN  'C'	THEN  'Capital' " +
                          " WHEN  'W'	THEN  'Warehouse' " +
                          " WHEN  'A'	THEN  'Automotive' " +
                          " WHEN  'M'	THEN  'Material' " +
                          " WHEN  'I'	THEN 'Instrument'" +
                          " ELSE 'Material' " +
                          " END, " +

                    "j.PO, [Vendor Name], j.[Gross Amt], j.[Net Amt], [Ship Date], [Ship Name], [Invoices Total], Variance, [Remaining Balance], [Work Order], CommentFlag, Comment  FROM tblJobPO j   " +
                    " LEFT JOIN tblJobPOInvoice b  " +
                    " ON j.PO = b.PO " +
                    " WHERE j.JobNumber =  '" + jobNumber + "' AND j.PO NOT LIKE 'N/A%'" +
                    " AND b.PO is Null " +
                    " Order by j.PO ";
            }

            if (queryType == 1)
            {
                query2 = "SELECT a.JobNumber As [Job], b.JobNumber,  b.PO AS [PO], b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " +
                         " b.[Gross Pay Amt], " +
                         " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date] " +
                         " FROM tblJobPOInvoice b " +
                         " INNER JOIN tblJobPO a ON b.PO = a.PO " +
                         " LEFT JOIN tblJobPOInvoicePayment p " +
                         " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber " +
                        " WHERE a.JobNumber = '" + jobNumber + "' AND a.PO NOT LIKE 'N/A%' ";
            }

            if (queryType == 3)
            {
                query2 = "SELECT  b.PO AS [PO], b.LineNumber AS [Line No], ISNULL(CatNo, '') + ' - ' + ISNULL(MatName, '') AS [Desc],  b.QuantityReceived As [Qty Recvd], b.Price, TotalPrice AS [Total], DateReceived as Date " +
                       " FROM tblJobPOItemReceived b " +
                       " LEFT JOIN tblJobPOItem t ON b.JobNumber = t.JobNumber AND b.PO = t.PO AND b.LineNumber = t.LineNumber " +
                       " INNER JOIN tblJobPO a ON b.PO = a.PO " +
                          " WHERE a.JobNumber =  '" + jobNumber + "' AND a.PO NOT LIKE 'N/A%' " +
                      " ORDER BY b.LineNumber, DateReceived ";
            }

            if (queryType == 4)
            {
                query1 = " SELECT " +
                         " Category = " +
                         " CASE Category " +
                         " WHEN 'E'	THEN 'Equipment' " +
                         " WHEN  'R'	THEN 'Rental' " +
                         " WHEN  'S'	THEN  'SubContract' " +
                         " WHEN  'T'	THEN  'Tools' " +
                         " WHEN  'O'	THEN  'Other' " +
                         " WHEN  'C'	THEN  'Capital' " +
                         " WHEN  'W'	THEN  'Warehouse' " +
                         " WHEN  'A'	THEN  'Automotive' " +
                         " WHEN  'M'	THEN  'Material' " +
                         " WHEN  'I'	THEN 'Instrument'" +
                         " ELSE 'Material' " +
                         " END, " +
                         " p.PO AS PONumber, " +
                         " t.LineNumber, " +
                         " ISNULL(CatNo, '') + ' - ' + ISNULL(MatName, '') AS CatNo, " +
                         " UM, " +
                         " QuantityOrdered, " +
                         " QuantityReceived, " +
                         " QuantityBackOrder, " +
                         " Price, " +
                         " ExtGross " +
                         " FROM  tblJobPO p " +
                         " LEFT JOIN tblJobPOItem t ON p.JobNumber = t.JobNumber AND p.PO = t.PO " +
                         " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                         " WHERE j.JobNumber = '" + jobNumber + "'  and  LineNumber is Not Null  AND p.PO Not Like 'N/A' ";
            }

            if (queryType == 5)
            {
                query1 = " SELECT Category = " +
                       " CASE Category  " +
                       " WHEN 'E'	THEN 'Equipment' " +
                       " WHEN 'R'	THEN 'Rental' " +
                       " WHEN 'S'	THEN  'SubContract' " +
                       " WHEN 'T'	THEN  'Tools' " +
                       " WHEN 'O'	THEN  'Other' " +
                       " WHEN 'C'	THEN  'Capital' " +
                       " WHEN 'W'	THEN  'Warehouse' " +
                       " WHEN 'A'	THEN  'Automotive' " +
                       " WHEN 'M'	THEN  'Material' " +
                       " WHEN 'I'	THEN 'Instrument' " +
                       " ELSE 'Material' " +
                       " END, " +
                       " SUM([Gross Amt]) AS [Gross Amt], " +
                       " SUM([Net Amt]) AS [Net Amt], " +
                       " SUM([Invoices Total]) AS [Invoices Total], " +
                       " SUM(Variance) AS Variance, " +
                       " SUM([Remaining Balance]) AS [Remaining Balance] " +
                       " FROM tblJobPO WHERE JobNumber =  '" + jobNumber + "' AND PO Not Like 'N/A%' " +
                       " GROUP BY Category ";
            }

            if (queryType == 6)
            {
                query1 = " SELECT  [Inv No], " +
                       "           PO, " +
                       "           VendorID + ' - ' + Name AS Vendor,  " +
                       "           InvoiceDescription AS [Desc], " +
                       "           [Gross Amt], " +
                       "           [Gross Pay Amt],  " +
                       "           [Inv Date], " +
                       "           [Due Date] " +
                       " FROM tblJobPOInvoice WHERE JobNumber =  '" + jobNumber + "'  " +
                       " ORDER BY [Inv No] ";
            }

            try
            {
                if (queryType == 1 || queryType == 3)
                {
                    return DataBaseUtil.ExecuteDatasetRelation(query1, query2, "", "PO", CCEApplication.Connection, CommandType.Text);
                }
                else
                {
                    return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetJobARInvoiceDetailAging(string where)
        {
            string query = " SELECT " +
                            " JobNumber, " +
                            " JobName, " +
                            " Description AS ProjectManager, " +
                            " Customer, " +
                            " InvoiceNumber, " +
                            " InvoiceDate, " +
                            " InvoiceDescription, " +
                            " InvoiceAmount, " +
                            " RetentionHeld, " +
                            " RetentionDraw, " +
                            " NetAmount," +
                            " ReceivedAmount, " +
                            " NetDueAmount, " +
                            " [Current] = " +
                            " CASE " +
                            " WHEN  DATEDIFF(Day,INVOICEDATE, GETDATE()) Between 0 AND 30 THEN NetDueAmount " +
                            " ELSE	0 " +
                            " END, " +
                            " [Over30] = " +
                            " CASE " +
                            " WHEN  DATEDIFF(Day,INVOICEDATE, GETDATE()) BETWEEN 31 AND 60 THEN NetDueAmount " +
                            " ELSE	0 " +
                            " END, " +
                            " [Over60] = " +
                            " CASE " +
                            " WHEN  DATEDIFF(Day,INVOICEDATE, GETDATE()) BETWEEN 61 AND 90 THEN NetDueAmount " +
                            " ELSE	0 " +
                            " END, " +
                            " [Over90] = " +
                            " CASE " +
                            " WHEN  DATEDIFF(Day,INVOICEDATE, GETDATE()) BETWEEN 91 AND 120 THEN NetDueAmount " +
                            " ELSE	0 " +
                            " END, " +
                            " [Over120] = " +
                            " CASE " +
                            " WHEN  DATEDIFF(Day,INVOICEDATE, GETDATE()) BETWEEN 121 AND 180 THEN NetDueAmount " +
                            " ELSE	0 " +
                            " END, " +
                            " [Over180] = " +
                            " CASE " +
                            " WHEN  DATEDIFF(Day,INVOICEDATE, GETDATE()) > 180 THEN NetDueAmount " +
                            " ELSE	0 " +
                            " END " +
                            " FROM tblJobInvoice n " +
                            " LEFT JOIN tblJob j ON n.JobID = j.JobID " +
                            " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " +
                            where + "  AND NetDueAmount > 0 ";

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
        public static DataSet GetJobARInvoiceDetail(string jobID, int selectedView)
        {

            string query1 = "";
            string query2 = "";


            query1 = "SELECT JobInvoiceID, InvoiceNumber AS [Inv No], Customer, InvoiceDescription AS [Inv Desc], " +
                    "InvoiceAmount AS [Inv Amt]," +
                    " RetentionHeld AS [Ret Held], " +
                    " RetentionDraw AS [Ret Draw], " +
                    " NetAmount AS [Net Amt], " +
                    " Discount, ReceivedAmount AS [Rec Amt], " +
                    " NetDueAmount AS [Open Bal], " +
                    "  InvoiceDate AS [Inv Date], DueDate AS [Due Date] " +
                    " FROM tblJobInvoice r " +
                    " WHERE JobID = " + jobID + " " +
                    " Order by InvoiceNumber ";

            switch (selectedView)
            {
                case 1:
                    query2 = "Select CustomerID AS Cust_Id, InvoiceNumber AS [Inv No], LineNumber AS Line_No, " +
                                " CheckNumber AS [Check No], PaymentDescription AS [Desc], CheckDate AS [Check Date], " +
                                " CheckAmount AS [Amount] " +
                                " FROM tblJobInvoicePayment  " +
                                " WHERE JobID = " + jobID + " ";
                    break;
                case 3:
                    query2 = "SELECT * FROM tblJobInvoiceComment WHERE JobID = " + jobID + " ";
                    break;
            }

            try
            {
                DataSet dt = new DataSet();
                switch (selectedView)
                {
                    case 0:
                        dt = DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
                        break;
                    case 1:
                        dt = DataBaseUtil.ExecuteDatasetRelation(query1, query2, "", "Inv No", CCEApplication.Connection, CommandType.Text);
                        break;
                    case 3:
                        dt = DataBaseUtil.ExecuteDatasetRelation(query1, query2, "", "JobInvoiceID", CCEApplication.Connection, CommandType.Text);
                        break;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobAPSubcontractsInvoices(string jobID)
        {
            string query = "";

            /* query = " SELECT DISTINCT b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " +
                           " b.[Gross Pay Amt], " +
                           " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date], b.[Gross Amt] - Payment As Variance " +
                           " FROM tblJobPOInvoice b " +
                           " INNER JOIN tblJobPO a ON b.PO = a.PO " +
                           " INNER JOIN tblJobPOInvoiceDetail d  " +
                           " ON b.JobNumber = d.JobNumber and b.[Inv NO] = d.InvoiceNumber " +
                           " LEFT JOIN tblJobPOInvoicePayment p " +
                           " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber " +
                           " LEFT JOIN tblJob j ON b.JobNumber = j.JobNumber " +
                         " WHERE j.JobID = " + jobID + " AND Phase Like '4%' " +
                         " Order by b.[Inv No] ";
             */

            /* A new change for subcontracts */

            query = " SELECT DISTINCT b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " +
              " b.[Gross Pay Amt], " +
              " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date], b.[Gross Amt] - Payment As Variance " +
              " FROM tblJobPOInvoice b " +
              " LEFT JOIN tblJobPO a ON b.PO = a.PO " +
              " LEFT JOIN tblJobPOInvoiceDetail d  " +
              " ON b.JobNumber = d.JobNumber and b.[Inv NO] = d.InvoiceNumber " +
              " LEFT JOIN tblJobPOInvoicePayment p " +
              " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber  AND b.VendorID = p.VendorID" +
              " LEFT JOIN tblJob j ON b.JobNumber = j.JobNumber " +
            " WHERE j.JobID = " + jobID + " AND PSFlag = 'S' " +
            " Order by b.[Inv No] ";



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
        public static DataSet GetJobAPInvoiceDetail(string jobNumber)
        {
            string query = "";

            /*  query = " SELECT b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " + 
                            " b.[Gross Pay Amt], " +
                            " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date], b.[Gross Amt] - Payment As Variance " +
                            " FROM tblJobPOInvoice b " + 	
                            " INNER JOIN tblJobPO a ON b.PO = a.PO " + 
                            " LEFT JOIN tblJobPOInvoicePayment p " +
                            " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber " +	
                          " WHERE b.JobNumber = '" + jobNumber + "' AND b.PO like 'N/A%' " +
                          " Order by b.[Inv No] ";

              */
            query = " SELECT b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " +
              " b.[Gross Pay Amt], " +
              " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date], b.[Gross Amt] - Payment As Variance " +
              " FROM tblJobPOInvoice b " +
              " LEFT JOIN tblJobPO a ON b.PO = a.PO " +
              " LEFT JOIN tblJobPOInvoicePayment p " +
              " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber  AND b.VendorID = p.VendorID " +
            " WHERE b.JobNumber = '" + jobNumber + "' AND b.PO like 'N/A%' " +
            " Order by b.[Inv No] ";


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
        public static bool Remove(string jobCostCodeID)
        {
            string query = "";

            query = "DELETE FROM tblJobCostCode WHERE JobCostCodeID = " + jobCostCodeID;
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

        public static bool RemoveRevisionCostCode(string jobCostCodeID, string rev)
        {
            string query = "";

            query = "DELETE FROM tblJobCostCodeRev WHERE Rev = '" + rev + "' AND  JobCostCodeID = " + jobCostCodeID;
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

        public static bool RemoveAllCostCodeFromChangeOrder(string jobChangeOrderID)
        {
            string query = "";

            query = "DELETE FROM tblJobCostCode WHERE JobChangeOrderID = " + jobChangeOrderID;
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

        public static bool RemoveAllCostCodeFromChangeOrderRev(string jobChangeOrderID, string version)
        {
            string query = "";

            query = "DELETE FROM tblJobCostCodeRev WHERE JobChangeOrderID = " + jobChangeOrderID + " AND Rev='" + version + "'";
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

        public static string GetLatestChangeOrderRevision(string jobChangeOrderID)
        {
            string query = "";
            string rev = "";
            query = " select  MAX(rev) as Rev from tblJobChangeOrderRev where   JobChangeOrderID=" + jobChangeOrderID;
            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                return rev = Convert.ToString(ds.Tables[0].Rows[0]["Rev"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save(string revision = "", bool changeOrderStatus = false)
        {
            string commentQuery = "";
            string query = "";
            if (changeOrderStatus)
            {
                // First remove all cost codes related to JobChangeOrder
                string latestRevision = GetLatestChangeOrderRevision(jobChangeOrderID);
                if (latestRevision != revision)
                {
                    string costQuery = "";
                    // RemoveAllCostCodeFromChangeOrder(jobChangeOrderID);
                    if (!string.IsNullOrEmpty(JobCostCodeID))
                    {
                        costQuery = " SELECT JobCostCodeID FROM tblJobCostCode WHERE JobCostCodeID =" + jobCostCodeID;
                        jobCostCodeID = DataBaseUtil.ExecuteScalar(costQuery, CCEApplication.Connection, CommandType.Text).ToString();
                    }
                    if (!string.IsNullOrEmpty(jobCostCodePhaseID))
                    {
                        costQuery = " SELECT jobCostCodePhaseID FROM tblJobCostCodePhase WHERE jobCostCodePhaseID =" + jobCostCodePhaseID + " AND JobID = " + jobID;
                        jobCostCodePhaseID = DataBaseUtil.ExecuteScalar(costQuery, CCEApplication.Connection, CommandType.Text).ToString();
                    }
                }
            }
            if (jobCostCodePhaseID == "")
            {
                try
                {
                    query = "Select jobCostCodePhaseID FROM tblJobCostCodePhase WHERE JobID = " + jobID + "  AND " +
                            " JobCostCodeType = '" + jobCostCodeType + "' AND " +
                            " JobCostCodePhase = '" + jobCostCodePhase + "' AND " +
                            " CostCode = '" + costCode + "' ";

                    jobCostCodePhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    if (jobCostCodePhaseID.Trim() == "")
                    {
                        query = "INSERT INTO tblJobCostCodePhase (JobID, " +
                            " JobCostCodeType, " +
                            " JobCostCodePhase, " +
                            " CostCode, " +
                            " CostCodeTitle, " +
                            " CostCodeDescription, " +
                            " userDescription, " +
                            " Unit, " +
                            " Selected, " +
                            " AuditUserID) VALUES (" +
                            jobID + ",'" +
                            jobCostCodeType + "', '" +
                            jobCostCodePhase + "', '" +
                            costCode + "', '" +
                            costCodeTitle + "', '" +
                            costCodeDescription + "', '" +
                            description + "', '" +
                            unit + "', " +
                            " 0,'" +
                            Security.Security.LoginID + "') " +
                            "Select @@IDENTITY ";
                        jobCostCodePhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    }
                    else
                    {
                        //if (!string.IsNullOrEmpty(unit))
                        //{
                        query = "Update tblJobCostCodePhase SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "'  WHERE JobCostCodePhaseID = " + jobCostCodePhaseID + " ";
                        DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                        // }
                    }


                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                //if (!string.IsNullOrEmpty(unit))
                //{
                query = "Update tblJobCostCodePhase SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "' WHERE JobCostCodePhaseID = " + jobCostCodePhaseID + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                //}

                if (jobChangeOrderNumber == "0")
                {
                    //if (!string.IsNullOrEmpty(description))
                    //{
                    query = "UPDATE  tblJobCostCodePhase SET userDescription = '" + description + "', AuditUserID = '" + Security.Security.LoginID + "'  WHERE jobCostCodePhaseID = " + jobCostCodePhaseID;
                    DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                    //}
                }
            }

            // Create the comment Item
            commentQuery = "Select JobCostCodePhaseID FROM tblJobCostCodePhaseComment WHERE  JobCostCodePhaseID  = " + jobChangeOrderID + "   " +
                    " IF @@ROWCOUNT = 0 " +
                    " INSERT INTO tblJobCostCodePhaseComment(JobCostCodePhaseID) VALUES(" + jobCostCodePhaseID + ") ";
            DataBaseUtil.ExecuteNonQuery(commentQuery, CCEApplication.Connection, CommandType.Text);


            if (jobCostCodeID == "")
            {
                return Insert();
            }
            else
            {
                return Update();
            }
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobCostCode(JobChangeOrderID, JobCostCodePhaseID, Description, Unit, Quantity, Hours, Cost, Selected, AuditUserID) Values(" +
                    jobChangeOrderID + ", " + jobCostCodePhaseID + ", '" + description + "', '" + unit + "', " + quantity + ", " + hours + ", " + cost + ", 1, '" + Security.Security.LoginID + "')   Select @@IDENTITY";
            try
            {
                jobCostCodeID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobCostCode SET " +
                    " Description       = '" + description + "', " +
                    " Unit              = '" + unit + "', " +
                    " Quantity          = " + quantity + ", " +
                    " Hours             = " + hours + ", " +
                    " cost              = " + cost + ", " +
                    " AuditUserID       = '" + Security.Security.LoginID + "' " +
                    " WHERE JobCostCodeID = " + jobCostCodeID;
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

        private bool InsertRevisionCostCode(string rev)
        {
            bool isSuccess = false;
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);
            par[1] = new SqlParameter("@Revision", rev);
            par[2] = new SqlParameter("@JobCostCodeID", jobCostCodeID);
            try
            {
                DataRow r = DataBaseUtil.ExecuteParDataset("dbo.[up_JCCSaveJobCostCodes]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0].Rows[0];
                if (r != null)
                {
                    isSuccess = Convert.ToBoolean(r[0]);
                }

                return isSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool InsertRevisionCostCodePhase(string rev)
        {
            bool isSuccess = false;
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);
            par[1] = new SqlParameter("@Revision", rev);
            par[2] = new SqlParameter("@JobCostCodePhaseID", jobCostCodePhaseID);
            try
            {
                DataRow r = DataBaseUtil.ExecuteParDataset("dbo.[up_JCCSaveJobCostCodePhase]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0].Rows[0];
                if (r != null)
                {
                    isSuccess = Convert.ToBoolean(r[0]);
                }

                return isSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool UpdateRevisionCostCode(string rev)
        {
            string query = "";

            query = "Update tblJobCostCodeRev SET " +
                    " Description       = '" + description + "', " +
                    " Unit              = '" + unit + "', " +
                    " Quantity          = " + quantity + ", " +
                    " Hours             = " + hours + ", " +
                    " cost              = " + cost + ", " +
                    " AuditUserID       = '" + Security.Security.LoginID + "' " +
                    " WHERE JobCostCodeID = " + jobCostCodeRevID + "AND Rev = '" + rev + "'";
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

        public bool SaveRevisionCostCode(string revision)
        {
            string commentQuery = "";
            if (string.IsNullOrEmpty(jobCostCodeRevPhaseID))
            {
                string query = "";
                try
                {
                    query = "Select jobCostCodePhaseID FROM tblJobCostCodePhaseRev WHERE JobID = " + jobID + "  AND " +
                            " jobCostCodePhaseID = " + jobCostCodePhaseID + " AND " +
                            "Rev ='" + revision + "'";

                    jobCostCodeRevPhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    if (jobCostCodeRevPhaseID.Trim() == "")
                    {
                        InsertRevisionCostCodePhase(revision);
                    }
                    else
                    {
                        query = "Update tblJobCostCodePhaseRev SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "'  WHERE JobCostCodePhaseID = " + jobCostCodeRevPhaseID + " AND Rev = '" + revision + "' ";
                        DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                string query = "Update tblJobCostCodePhaseRev SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "' WHERE JobCostCodePhaseID = " + jobCostCodeRevPhaseID + " AND Rev = '" + revision + "' ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);

                if (jobChangeOrderNumber == "0")
                {
                    query = "UPDATE  tblJobCostCodePhaseRev SET userDescription = '" + description + "', AuditUserID = '" + Security.Security.LoginID + "'  WHERE jobCostCodePhaseID = " + jobCostCodeRevPhaseID + " AND Rev = '" + revision + "' ";
                    DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                }
            }

            // Create the comment Item
            commentQuery = "Select JobCostCodePhaseID FROM tblJobCostCodePhaseComment WHERE  JobCostCodePhaseID  = " + jobChangeOrderID + "   " +
                    " IF @@ROWCOUNT = 0 " +
                    " INSERT INTO tblJobCostCodePhaseComment(JobCostCodePhaseID) VALUES(" + jobCostCodePhaseID + ") ";
            DataBaseUtil.ExecuteNonQuery(commentQuery, CCEApplication.Connection, CommandType.Text);

            string costQuery = " SELECT JobCostCodeID FROM tblJobCostCodeRev WHERE JobCostCodeID ='" + jobCostCodeID + "'  AND Rev='" + revision + "'";
            jobCostCodeRevID = DataBaseUtil.ExecuteScalar(costQuery, CCEApplication.Connection, CommandType.Text).ToString();
            if (jobCostCodeRevID == "")
            {
                return InsertRevisionCostCode(revision);
            }
            else
            {
                return UpdateRevisionCostCode(revision);
            }
        }
        public bool SaveCostCodeAfterRevision()
        {
            string commentQuery = "";
            string query = "";

            string costQuery = "";
            // RemoveAllCostCodeFromChangeOrder(jobChangeOrderID);
            if (!string.IsNullOrEmpty(JobCostCodeID))
            {
                costQuery = " SELECT JobCostCodeID FROM tblJobCostCode WHERE JobCostCodeID =" + jobCostCodeID;
                jobCostCodeID = DataBaseUtil.ExecuteScalar(costQuery, CCEApplication.Connection, CommandType.Text).ToString();
            }
            if (!string.IsNullOrEmpty(jobCostCodePhaseID))
            {
                costQuery = " SELECT jobCostCodePhaseID FROM tblJobCostCodePhase WHERE jobCostCodePhaseID =" + jobCostCodePhaseID + " AND JobID = " + jobID;
                jobCostCodePhaseID = DataBaseUtil.ExecuteScalar(costQuery, CCEApplication.Connection, CommandType.Text).ToString();
            }
            if (jobCostCodePhaseID == "")
            {
                try
                {
                    query = "Select jobCostCodePhaseID FROM tblJobCostCodePhase WHERE JobID = " + jobID + "  AND " +
                            " JobCostCodeType = '" + jobCostCodeType + "' AND " +
                            " JobCostCodePhase = '" + jobCostCodePhase + "' AND " +
                            " CostCode = '" + costCode + "' ";

                    jobCostCodePhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    if (jobCostCodePhaseID.Trim() == "")
                    {
                        query = "INSERT INTO tblJobCostCodePhase (JobID, " +
                            " JobCostCodeType, " +
                            " JobCostCodePhase, " +
                            " CostCode, " +
                            " CostCodeTitle, " +
                            " CostCodeDescription, " +
                            " userDescription, " +
                            " Unit, " +
                            " Selected, " +
                            " AuditUserID) VALUES (" +
                            jobID + ",'" +
                            jobCostCodeType + "', '" +
                            jobCostCodePhase + "', '" +
                            costCode + "', '" +
                            costCodeTitle + "', '" +
                            costCodeDescription + "', '" +
                            description + "', '" +
                            unit + "', " +
                            " 0,'" +
                            Security.Security.LoginID + "') " +
                            "Select @@IDENTITY ";
                        jobCostCodePhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                    }
                    else
                    {
                        query = "Update tblJobCostCodePhase SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "'  WHERE JobCostCodePhaseID = " + jobCostCodePhaseID + " ";
                        DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                    }


                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                query = "Update tblJobCostCodePhase SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "' WHERE JobCostCodePhaseID = " + jobCostCodePhaseID + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);

                if (jobChangeOrderNumber == "0")
                {
                    query = "UPDATE  tblJobCostCodePhase SET userDescription = '" + description + "', AuditUserID = '" + Security.Security.LoginID + "'  WHERE jobCostCodePhaseID = " + jobCostCodePhaseID;
                    DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                }
            }

            // Create the comment Item
            commentQuery = "Select JobCostCodePhaseID FROM tblJobCostCodePhaseComment WHERE  JobCostCodePhaseID  = " + jobChangeOrderID + "   " +
                    " IF @@ROWCOUNT = 0 " +
                    " INSERT INTO tblJobCostCodePhaseComment(JobCostCodePhaseID) VALUES(" + jobCostCodePhaseID + ") ";
            DataBaseUtil.ExecuteNonQuery(commentQuery, CCEApplication.Connection, CommandType.Text);


            if (jobCostCodeID == "")
            {
                return Insert();
            }
            else
            {
                return Update();
            }
        }


        public static void UpdateJobPO(string jobPOID, string commentFlag, string comment)
        {
            string query = "";

            query = "Update tblJobPO SET " +
                    " commentFlag       = " + commentFlag + ", " +
                    " comment           = '" + comment + "' " +
                    " WHERE JobPOID     = " + jobPOID;
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
