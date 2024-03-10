using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class JobCost
    {
        private string jobCostCodeID; 
        private string jobChangeOrderID;
        private string jobCostCodePhaseID;
        private string jobChangeOrderNumber;
        private string description;
        private string unit;
        private string quantity;
        private string hours;
        private string cost;
        // 
        // Phase Variables for new Phase Record
        //
        private string jobID;
        private string jobCostCodeType;
        private string jobCostCodePhase;
        private string costCode;
        private string costCodeTitle;
        private string costCodeDescription;
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
            this.description = description.Trim().ToUpper().Replace("'","''");
            this.unit = unit;
            this.quantity = String.IsNullOrEmpty(quantity) ? "Null" : quantity;
            this.hours = String.IsNullOrEmpty(hours) ? "Null" : hours;
            this.cost = String.IsNullOrEmpty(cost) ? "Null" : cost;
            this.jobID = jobID;
            this.jobCostCodeType = jobCostCodeType;
            this.jobCostCodePhase = jobCostCodePhase;
            this.costCode = costCode;
            this.costCodeTitle = costCodeTitle.Trim().ToUpper().Replace("'","''");
            this.costCodeDescription = costCodeDescription.Trim().ToUpper().Replace("'", "''");
            
        }
        public static DataSet GetCostCode(string jobChangeOrderID , string jobID)
        {
            if (jobChangeOrderID == "")
                jobChangeOrderID = "0";
            if (jobID == "")
                jobID = "0";

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
                jobID = "0";

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

        public static DataSet GetJobPurchaseDetail(string jobNumber, int queryType)
        {
            string query1 = "";
            string query2 = "";
            if(queryType == 0 || queryType == 1 || queryType == 3)
                query1 = "SELECT JobNumber, " +
                     " Category = " +
                          " CASE Category " +
                          " WHEN 'E'	THEN 'Equipment' " +
                          " WHEN  'R'	THEN 'Rental' " +
                          " WHEN  'S'	THEN  'SubContract' " +
                          " WHEN  'T'	THEN  'Tools' " +
                          " WHEN  'O'	THEN  'Other' " +
                          " WHEN  'C'	THEN  'Capital' " +
                          " WHEN  'W'	THEN  'Wharehouse' " +
                          " WHEN  'A'	THEN  'Automotive' " +
                          " WHEN  'M'	THEN  'Material' " +
                          " WHEN  'I'	THEN 'Instrument'" +
                          " ELSE 'Material' " +
                          " END, " +
                    
                    " PO, [Vendor Name], [Gross Amt], [Net Amt], [Ship Date], [Ship Name], [Invoices Total], Variance, [Remaining Balance], [Work Order] FROM tblJobPO WHERE JobNumber =  '" + jobNumber + "' AND PO Not Like 'N/A%'" +
                     " Order by PO ";
            if (queryType == 2)
                query1 = "SELECT j.JobNumber, " +

                    " Category = " +
                          " CASE Category " +
                          " WHEN 'E'	THEN 'Equipment' " +
                          " WHEN  'R'	THEN 'Rental' " +
                          " WHEN  'S'	THEN  'SubContract' " +
                          " WHEN  'T'	THEN  'Tools' " +
                          " WHEN  'O'	THEN  'Other' " +
                          " WHEN  'C'	THEN  'Capital' " +
                          " WHEN  'W'	THEN  'Wharehouse' " +
                          " WHEN  'A'	THEN  'Automotive' " +
                          " WHEN  'M'	THEN  'Material' " +
                          " WHEN  'I'	THEN 'Instrument'" +
                          " ELSE 'Material' " +
                          " END, " +
                    
                    "j.PO, [Vendor Name], j.[Gross Amt], j.[Net Amt], [Ship Date], [Ship Name], [Invoices Total], Variance, [Remaining Balance], [Work Order]  FROM tblJobPO j   " +
                    " LEFT JOIN tblJobPOInvoice b  " +
                    " ON j.PO = b.PO " +
                    " WHERE j.JobNumber =  '" + jobNumber + "' AND j.PO NOT LIKE 'N/A%'" +
                    " AND b.PO is Null " +
                    " Order by j.PO ";
    

             if (queryType == 1)
                 query2 = "SELECT a.JobNumber As [Job], b.JobNumber,  b.PO AS [PO], b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " + 
                          " b.[Gross Pay Amt], " +
                          " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date] " +
                          " FROM tblJobPOInvoice b " + 	
                          " INNER JOIN tblJobPO a ON b.PO = a.PO " + 
						  " LEFT JOIN tblJobPOInvoicePayment p " +
						  " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber " +	
                         " WHERE a.JobNumber = '" + jobNumber + "' AND a.PO NOT LIKE 'N/A%' ";

             if (queryType == 3)
                 query2 = "SELECT  b.PO AS [PO], b.LineNumber AS [Line No], ISNULL(CatNo, '') + ' - ' + ISNULL(MatName, '') AS [Desc],  b.QuantityReceived As [Qty Recvd], b.Price, TotalPrice AS [Total], DateReceived as Date " +
                        " FROM tblJobPOItemReceived b " +
                        " LEFT JOIN tblJobPOItem t ON b.JobNumber = t.JobNumber AND b.PO = t.PO AND b.LineNumber = t.LineNumber " +
                        " INNER JOIN tblJobPO a ON b.PO = a.PO " +
                           " WHERE a.JobNumber =  '" + jobNumber + "' AND a.PO NOT LIKE 'N/A%' " +
                       " ORDER BY b.LineNumber, DateReceived ";

             if (queryType == 4)
                 query1 = " SELECT " +
                          " Category = " +
		                  " CASE Category " +
			              " WHEN 'E'	THEN 'Equipment' " +
			              " WHEN  'R'	THEN 'Rental' " +
			              " WHEN  'S'	THEN  'SubContract' " +
			              " WHEN  'T'	THEN  'Tools' " +
			              " WHEN  'O'	THEN  'Other' " +
			              " WHEN  'C'	THEN  'Capital' " +
			              " WHEN  'W'	THEN  'Wharehouse' " +
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

             if (queryType == 5)
                 query1 = " SELECT Category = " +
                        " CASE Category  " +
                        " WHEN 'E'	THEN 'Equipment' " +
                        " WHEN 'R'	THEN 'Rental' " +
                        " WHEN 'S'	THEN  'SubContract' " +
                        " WHEN 'T'	THEN  'Tools' " +
                        " WHEN 'O'	THEN  'Other' " +
                        " WHEN 'C'	THEN  'Capital' " +
                        " WHEN 'W'	THEN  'Wharehouse' " +
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
             if (queryType == 6)
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
            try
            {
                if (queryType == 1 || queryType == 3)
                    return DataBaseUtil.ExecuteDatasetRelation(query1, query2, "", "PO", CCEApplication.Connection, CommandType.Text);
                else
                    return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
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
        public static DataSet GetJobARInvoiceDetail(string jobID, bool includePayment)
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
            if (includePayment)
                query2 = "Select CustomerID AS Cust_Id, InvoiceNumber AS [Inv No], LineNumber AS Line_No, " +
                            " CheckNumber AS [Check No], PaymentDescription AS [Desc], CheckDate AS [Check Date], " +
                            " CheckAmount AS [Amount] " +
                            " FROM tblJobInvoicePayment  " +
                            " WHERE JobID = " + jobID + " ";
            else
                query2 = "SELECT * FROM tblJobInvoiceComment WHERE JobID = " + jobID + " ";
                
            try
            {
                if (includePayment)
                    return DataBaseUtil.ExecuteDatasetRelation(query1,query2,"", "Inv No", CCEApplication.Connection, CommandType.Text);
                else
                    return DataBaseUtil.ExecuteDatasetRelation(query1, query2, "", "JobInvoiceID", CCEApplication.Connection, CommandType.Text);
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

            query = " SELECT DISTINCT b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " +
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
        public static DataSet GetJobAPInvoiceDetail(string jobID)
        {
            string query = "";

            query = " SELECT b.[Inv No], b.VendorID + ' - ' + [Name] as Vendor, InvoiceDescription as [Desc],  b.[Gross Amt], " + 
                          " b.[Gross Pay Amt], " +
                          " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date], b.[Gross Amt] - Payment As Variance " +
                          " FROM tblJobPOInvoice b " + 	
                          " INNER JOIN tblJobPO a ON b.PO = a.PO " + 
						  " LEFT JOIN tblJobPOInvoicePayment p " +
						  " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber " +	
                          " LEFT JOIN tblJob j ON b.JobNumber = j.JobNumber " +
                        " WHERE j.JobID = " + jobID + " AND b.PO like 'N/A%' " +
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
        public static bool Remove(string jobCostCodeID )
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
        //
        public bool Save()
        {
            string commentQuery = "";
            if (jobCostCodePhaseID == "")
            {
                string query = "";

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
                            query = "Update tblJobCostCodePhase SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "'  WHERE JobCostCodePhaseID = " + jobCostCodePhaseID  + " ";
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
                string query = "Update tblJobCostCodePhase SET Unit = '" + unit + "', AuditUserID = '" + Security.Security.LoginID + "' WHERE JobCostCodePhaseID = " + jobCostCodePhaseID + " ";
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
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobCostCode(JobChangeOrderID, JobCostCodePhaseID, Description, Unit, Quantity, Hours, Cost, Selected, AuditUserID) Values(" +
                    jobChangeOrderID + ", " + jobCostCodePhaseID + ", '" + description + "', '" + unit + "', " + quantity + ", " + hours + ", " + cost + ", 1, '" + Security.Security.LoginID + "')";
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
    }
}
