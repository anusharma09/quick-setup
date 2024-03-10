using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using ContraCostaElectric.DatabaseUtil;
using System.IO;
namespace JCCBusinessLayer
{
    public class ExcelReport : IDisposable
    {
        private bool disposed = false;
        public static Excel.Application oXl;
        private Excel.Workbook oBook;
        private Excel.Sheets oSheets;
        private Excel.Worksheet oSheet;
        private Excel.Range oRange;
        private Excel.Range oRangeTotal;
        private Excel.Range oRangeLastEstimate;
        private Excel.Range oRangeRemaining;
        private Excel.Range oChangeOrder;
        private Excel.Range oChangeOrderPercent;
        private Excel.Range oRangeOriginalApproved;
        private Excel.Range oMU;
        private string jobID;
        private string jobNumber;
        private string jobName;
        private string contractorName;
        private Hashtable excelCol = new Hashtable();
        private string excelFileName;
        private int startingColumnL = 0;
        private int startingColumnR = 0;
        private string startingColumn;
        private string reportQuery;
        private string perid;
        //
        private enum ExcelFile
        {
            JobQuantity,
            JobHours
        }
        //
        public ExcelReport()
        {

        }
        //
        public ExcelReport(string jobID, string jobNumber, string jobName, string contractorName, string perid)
        {
            this.jobID = jobID;
            this.jobNumber = jobNumber;
            this.jobName = jobName;
            this.contractorName = contractorName;
            if (jobID == "")
                jobID = "0";
            this.perid = perid;
        }
        //
        public void JobQuantityReport()
        {
            CreateExcelFile(ExcelFile.JobQuantity);
        }
        //
        public void JobHoursReport()
        {
            CreateExcelFile(ExcelFile.JobHours);
        }
        //
        public void LaborProdReport()
        {
            string periodDate = "";
            CreateExcelFileLaborProd(periodDate);
        }
        //
        public void JobWeeklyTimeSheet(string jobID, string jobNumber, string endDate, string jobName, DataSet dataSet)
        {
            DataTable table;
            try
            {
                table = Job.GetJobOffice(jobID).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (oXl == null)
                oXl = new Microsoft.Office.Interop.Excel.Application();
            excelFileName = "FieldTimeSheet.xls";
            CopyExcelFile(excelFileName);
            oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["Time"];
            oRangeTotal = oSheet.get_Range("A19", "Z19");
            int i = 5;
            oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, jobNumber);
            oRange = oSheet.get_Range("W" + i.ToString().Trim(), "W" + i.ToString());
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, endDate);
            i = 7;
            oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, jobName);
            i = 20;
            foreach (DataRow r in dataSet.Tables[0].Rows)
            {
                if (r["Selected"].ToString() == "True")
                {
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "Z" + i.ToString());
                    oRange.Rows.Insert(Type.Missing, Type.Missing);
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "Z" + i.ToString());
                    oRangeTotal.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r[3].ToString());
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r[1].ToString());
                    oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r[2].ToString());
                    i++;
                }
            }
            oXl.Visible = true;
            oXl.UserControl = true;
        }
        //
        public  void JobWeeklyQuantitySheet(string jobID, string jobNumber, string endDate, string jobName, DataSet dataSet)
        {           
            DataTable table;
            try
            {
                table = Job.GetJobOffice(jobID).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (oXl == null)
                oXl = new Microsoft.Office.Interop.Excel.Application();
            excelFileName = "QuantitySheet.xls";
            CopyExcelFile(excelFileName);
            oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["Quantity"];
            oRangeTotal = oSheet.get_Range("L14", "L14");
            int i;
            if (table.Rows.Count > 0)
            {
                i = 1;
                oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, 
                                                table.Rows[0]["Address"].ToString() + " " +
                                            table.Rows[0]["City"].ToString() + ", " +
                                                table.Rows[0]["State"].ToString() + " " +
                                                table.Rows[0]["ZipCode"].ToString());
                i = 2;
                oRange = oSheet.get_Range("J" + i.ToString().Trim(), "J" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, 
                                    "Phone: " + table.Rows[0]["Phone"].ToString());

                i = 3;
                oRange = oSheet.get_Range("J" + i.ToString().Trim(), "J" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, 
                                "Fax: " + table.Rows[0]["Fax"].ToString());
            }
            i = 7;
            oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, jobNumber);
            oRange = oSheet.get_Range("K" + i.ToString().Trim(), "K" + i.ToString());
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, endDate);
            i = 8;
            oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, jobName);
            i = 15;
            foreach (DataRow r in dataSet.Tables[0].Rows)
            {
                if (r["Selected"].ToString() == "True")
                {
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "L" + i.ToString());
                    oRange.Rows.Insert(Type.Missing, Type.Missing);
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r[3].ToString());
                    oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r[1].ToString());
                    oRange = oSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r[2].ToString());
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r[4].ToString());
                    oRange = oSheet.get_Range("L" + i.ToString().Trim(), "L" + i.ToString());
                    oRangeTotal.Columns.Copy(oRange);
                    i++;
                }
            }
            oXl.Visible = true;
            oXl.UserControl = true;
        }
        //
        private void CreateExcelFile(ExcelFile reportName)
        {
            DataTable dataTable;
            string query;
            string range;
            string reportType = "";

            if (oXl == null)
                oXl = new Microsoft.Office.Interop.Excel.Application();

            switch (reportName)
            {
                case ExcelFile.JobHours:
                    excelFileName = "Hours.xls";
                    reportType = "H";
                    reportQuery = "SELECT CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], Unit , SUM(Hours) AS Value,Weekend , ";
                    break;
                case ExcelFile.JobQuantity:
                    excelFileName = "Quantities.xls";
                    reportQuery = "SELECT CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], Unit, SUM(Quantity) AS Value,Weekend, ";
                    reportType = "Q";
                    break;

                default:
                    break;
            }
            reportQuery = reportQuery + " dbo.GetJobCodeActual(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode, p.JobCostCodeType) AS Actual, " +
                          " dbo.GetJobCodeOriginalBudget(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode, p.JobCostCodeType) AS Budget, " +
                          " dbo.GetJobCodeBudgetApproved(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode, p.JobCostCodeType) AS Approved, " +
                          " dbo.GetJobCodeBudgetPendingWithProceed(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode,p.JobCostCodeType) AS Pending " +
                          " FROM tblJobCostCodePhase p " +
                          " LEFT JOIN tblJobCostCodesWeekly w ON p.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                          " WHERE JobID = " + jobID + " AND (JobCostCodeType = 'L' OR JobCostCodeType = 'O')" +
                          " GROUP BY CostCode, JobCostCodePhase, UserDescription, weekend, Unit, " +
                          " dbo.GetJobCodeActual(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode, p.jobCostCodeType), " +
                          " dbo.GetJobCodeOriginalBudget(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode, p.JobCostCodeType), " +
                          " dbo.GetJobCodeBudgetApproved(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode, p.JobCostCodeType), " +
                          " dbo.GetJobCodeBudgetPendingWithProceed(" + jobID + ", '" + reportType + "', p.JobCostCodePhase, p.CostCode, p.JobCostCodeType)" +
                          " Order BY JobCostCodePhase + CostCode DESC ";
            query = "SELECT DISTINCT weekend " +
                    " FROM tblJobCostCodePhase p " +
                    " INNER JOIN tblJobCostCodesWeekly w ON p.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                    " WHERE JobID = " + jobID + " " +
                    " ORDER BY weekend DESC ";

            startingColumnR = 75;                // ASCII for the column title 
            try
            {
                dataTable = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                CopyExcelFile(excelFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            oSheets = oBook.Sheets;
            switch (reportName)
            {
                case ExcelFile.JobHours:
                    oSheet = (Excel.Worksheet)oSheets["HRS"];
                    break;
                case ExcelFile.JobQuantity:
                    oSheet = (Excel.Worksheet)oSheets["Quantities"];
                    break;
                default:
                    break;
            }
            oRangeTotal = oSheet.get_Range("F5", "F5");
            oRangeLastEstimate = oSheet.get_Range("H3", "H3");
            oRangeOriginalApproved = oSheet.get_Range("F3", "F3");
            oRangeRemaining = oSheet.get_Range("J3", "J3");
            UpdateHeader();
            foreach (DataRow r in dataTable.Rows)
            {
                if (startingColumnR > 90)
                {
                    startingColumnR = 65;
                    if (startingColumnL != 0)
                    {
                        startingColumnL++;
                    }
                    else
                    {
                        startingColumnL = 65;
                    }
                }
                if (startingColumnL > 0)
                    startingColumn = Convert.ToChar(startingColumnL).ToString() + Convert.ToChar(startingColumnR);
                else
                    startingColumn = Convert.ToChar(startingColumnR).ToString();
                excelCol.Add(r["weekend"].ToString(), startingColumn);
                range = startingColumn + "1";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["weekend"].ToString());
                oRange.Columns.AutoFit();
                range = startingColumn + "5";
                oRange = oSheet.get_Range(range, range);
                oRangeTotal.Columns.Copy(oRange);
                startingColumnR++;
            }
            dataTable = DataBaseUtil.ExecuteDataset(reportQuery, CCEApplication.Connection, CommandType.Text).Tables[0];
            int i = 4;
            string code = "";
            string phase = "";

            foreach (DataRow r in dataTable.Rows)
            {
                if (code != r["CostCode"].ToString() || phase != r["JobCostCodePhase"].ToString())
                {
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), startingColumn + i.ToString());
                    oRange.Rows.Insert(Type.Missing, Type.Missing);
                    code = r["CostCode"].ToString();
                    phase = r["JobCostCodePhase"].ToString();
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CostCodeTitle"].ToString());
                    oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["JobCostCodePhase"].ToString());
                    oRange = oSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["CostCode"].ToString());
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Budget"].ToString());
                    oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Approved"].ToString());
                    oRange = oSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                    oRangeOriginalApproved.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Pending"].ToString());
                    oRange = oSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                    oRangeLastEstimate.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Actual"].ToString());
                    oRange = oSheet.get_Range("J" + i.ToString().Trim(), "J" + i.ToString());
                    oRangeRemaining.Columns.Copy(oRange);
                }
                if (!String.IsNullOrEmpty(r["weekend"].ToString()))
                {
                    range = excelCol[r["weekend"].ToString()].ToString() + i.ToString().Trim();
                    oRange = oSheet.get_Range(range, range);
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Value"].ToString());
                }
            }
            oXl.Visible = true;
            oXl.UserControl = true;
        }
        //
        public void TotalCost()
        {
            DataTable dataTable;
            int i = 0;
            string query;
            string range;
            excelFileName = "TotalCost.xls";
            // //////////////////////////////////
            // Total Cost Worksheet
            // //////////////////////////////////
            if (oXl == null)
                oXl = new Microsoft.Office.Interop.Excel.Application();
            if (perid == "")
            reportQuery = " SELECT JobCostCodeType, CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], TotalBudgetCost, p.Cost, c.Cost AS [Value], P.CostThisMonth , JobChangeOrderNumber " +
                          "  FROM tblJobCostCodePhase p " +
                          "  LEFT JOIN tblJobCostCode c ON p.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                          " LEFT JOIN tblJobChangeOrder d ON c.JobChangeOrderID = d.JobChangeOrderID " +
                          "  WHERE p.JobID = " + jobID + " ORDER BY JobCostCodePhase Desc, CostCode Desc ";
            else
                reportQuery = " SELECT CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], TotalBudgetCost, p.Cost, c.Cost AS [Value], P.CostThisMonth , JobChangeOrderNumber " +
                        "  FROM tblJobCostCodePhaseHistory p " +
                        "  LEFT JOIN tblJobCostCode c ON p.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " LEFT JOIN tblJobChangeOrder d ON c.JobChangeOrderID = d.JobChangeOrderID " +
                        "  WHERE p.JobID = " + jobID + " AND p.period = '" + perid + "' ORDER BY JobCostCodePhase Desc, CostCode Desc ";
            query = "SELECT JobChangeOrderID, JobChangeOrderNumber, JobChangeOrderStatus, JobChangeOrderDescription, " +
                    " ISNULL(JobChangeOrderOwnerNumber,'') AS ChangeOrderOwnerNumber,  " +
                    " ISNULL(JobChangeOrderCCENumber,'')   AS ChangeOrderCCENumber,  " +
                    " ISNULL(JobChangeOrderUserDescription, '') AS JobChangeOrderUserDescription, " +
                	" ChangeOrderAmount =  " +
		            " CASE SUBSTRING(JobChangeOrderDescription,1,2) " +
			        " WHEN 'OR' THEN JobChangeOrderApprovedAmount " +
			        " WHEN 'B~' THEN JobChangeOrderApprovedAmount " +
			        " WHEN 'E~' THEN JobChangeOrderApprovedAmount " +
			        " WHEN 'G~' THEN JobChangeOrderApprovedAmount " +
			        " WHEN 'M~' THEN JobChangeOrderApprovedAmount " +
			        " WHEN 'C~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'F~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'H~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'J~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'K~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'N~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'D~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'L~' THEN JobChangeOrderRequestedAmount " +
			        " WHEN 'X~' THEN JobChangeOrderRequestedAmount " +
			        " ELSE 0 " +
		            " END " +
                    " FROM tblJobChangeOrder  " +
                    " WHERE JobID = " + jobID + " " +
                    " ORDER BY JobChangeOrderNumber ASC ";

            startingColumnR = 74;                //  72 -- ASCII for the column title 
            try
            {
                dataTable = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                CopyExcelFile(excelFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (perid == "")
                perid = "Current";
            oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["TotalCost"];
            oRange = oSheet.get_Range("D2", "D2");
            oRange.Formula = perid;
            oRangeRemaining = oSheet.get_Range("G8", "G8");
            oChangeOrder = oSheet.get_Range("I8", "I8");
            oChangeOrderPercent = oSheet.get_Range("H8", "H8");
            oRangeTotal = oSheet.get_Range("E10", "E10");
            UpdateHeader();           
            foreach (DataRow r in dataTable.Rows)
            {
                if (startingColumnR > 90)
                {
                    startingColumnR = 65;
                    if (startingColumnL != 0)
                    {
                        startingColumnL++;
                    }
                    else
                    {
                        startingColumnL = 65;
                    }
                }
                if (startingColumnL > 0)
                    startingColumn = Convert.ToChar(startingColumnL).ToString() + Convert.ToChar(startingColumnR);
                else
                    startingColumn = Convert.ToChar(startingColumnR).ToString();
                //
                // Flag for MAX
                //
                //if (startingColumn == "IV")
                //{
                //    int myName = 0;
                //    myName = 3;
                //    break;
                //}
                excelCol.Add(r["JobChangeOrderNumber"].ToString(), startingColumn);
                range = startingColumn + "1";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderUserDescription"].ToString());
                range = startingColumn + "2";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderOwnerNumber"].ToString());
                range = startingColumn + "3";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderCCENumber"].ToString());
                range = startingColumn + "4";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderAmount"].ToString());
                range = startingColumn + "5";
               // oRange = oSheet.get_Range(range, range);
               // oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderDescription"].ToString().Trim().Substring(0,2));
                range = startingColumn + "6";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault,  r["JobChangeOrderNumber"].ToString());
                range = startingColumn + "9";
                oRange = oSheet.get_Range(range, range);
                oRangeTotal.Columns.Copy(oRange);
                startingColumnR++;
            }
            dataTable = DataBaseUtil.ExecuteDataset(reportQuery, CCEApplication.Connection, CommandType.Text).Tables[0];
             i = 9 ;  
            string code = "";
            string phase = "";
            foreach (DataRow r in dataTable.Rows)
            {
                if (code != r["CostCode"].ToString() || phase != r["JobCostCodePhase"].ToString())
                {
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), startingColumn + i.ToString());
                    oRange.Rows.Insert(Type.Missing, Type.Missing);
                    code = r["CostCode"].ToString();
                    phase = r["JobCostCodePhase"].ToString();
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CostCodeTitle"].ToString());
                    oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["JobCostCodePhase"].ToString());
                    oRange = oSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["CostCode"].ToString());
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["TotalBudgetCost"].ToString());
                    oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Cost"].ToString());
                    oRange = oSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CostThisMonth"].ToString());
                    oRange = oSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                    oRangeRemaining.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                    oChangeOrderPercent.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                    oChangeOrder.Columns.Copy(oRange);
                }
                if (!String.IsNullOrEmpty(r["JobChangeOrderNumber"].ToString()))
                {
                    try
                    {
                        range = excelCol[r["JobChangeOrderNumber"].ToString()].ToString() + i.ToString().Trim();
                        oRange = oSheet.get_Range(range, range);
                        oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Value"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            // //////////////////////////////////
            // Total Hours Worksheet
            // //////////////////////////////////
            //if (oXl == null)
            //    oXl = new Microsoft.Office.Interop.Excel.Application();
            excelCol.Clear();
            if (perid == "Current")
                perid = "";
            if (perid == "")
                reportQuery = "   SELECT JobCostCodeType, CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], TotalBudgetHours, " +
                              " p.CommittedHours, ISNULL(c.Hours, 0) AS [Value], P.CostThisMonth , JobChangeOrderNumber " +
                              " FROM tblJobCostCodePhase p " +
                              " LEFT JOIN tblJobCostCode c ON p.JobCostCodePhaseID = c.JobCostCodePhaseID "+ 
                              " LEFT JOIN tblJobChangeOrder d ON c.JobChangeOrderID = d.JobChangeOrderID " +
                              "  WHERE p.JobID = " + jobID + " ORDER BY JobCostCodePhase Desc, CostCode Desc ";
            else
                reportQuery = " SELECT CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], TotalBudgetHours, " + 
                              " p.CommittedHours, ISNULL(c.Hours, 0) AS [Value], P.CostThisMonth , JobChangeOrderNumber " +
                              "  FROM tblJobCostCodePhaseHistory p " +
                              "  LEFT JOIN tblJobCostCode c ON p.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                              " LEFT JOIN tblJobChangeOrder d ON c.JobChangeOrderID = d.JobChangeOrderID " +
                              "  WHERE p.JobID = " + jobID + " AND p.period = '" + perid + "' ORDER BY JobCostCodePhase Desc, CostCode Desc ";
            query = "SELECT JobChangeOrderID, JobChangeOrderNumber, JobChangeOrderStatus, JobChangeOrderDescription, " +
                    " ISNULL(JobChangeOrderOwnerNumber,'') AS ChangeOrderOwnerNumber,  " +
                    " ISNULL(JobChangeOrderCCENumber,'')   AS ChangeOrderCCENumber,  " +
                    " ISNULL(JobChangeOrderUserDescription, '') AS JobChangeOrderUserDescription, " +
                    " ChangeOrderAmount =  " +
                    " CASE SUBSTRING(JobChangeOrderDescription,1,2) " +
                    " WHEN 'OR' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'B~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'E~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'G~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'M~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'C~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'F~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'H~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'J~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'K~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'N~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'D~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'L~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'X~' THEN JobChangeOrderRequestedAmount " +
                    " ELSE 0 " +
                    " END " +
                    " FROM tblJobChangeOrder  " +
                    " WHERE JobID = " + jobID + " " +
                    " ORDER BY JobChangeOrderNumber ASC ";

            startingColumnR = 74;
            startingColumnL = 0;
            //  72 -- ASCII for the column title 
            try
            {
                dataTable = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                //CopyExcelFile(excelFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (perid == "")
                perid = "Current";
            //oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["TotalHours"];
            oRange = oSheet.get_Range("D2", "D2");
            oRange.Formula = perid;
            oRangeRemaining = oSheet.get_Range("G8", "G8");
            oChangeOrder = oSheet.get_Range("I8", "I8");
            oChangeOrderPercent = oSheet.get_Range("H8", "H8");
            oRangeTotal = oSheet.get_Range("E10", "E10");
            UpdateHeader();
            foreach (DataRow r in dataTable.Rows)
            {
                if (startingColumnR > 90)
                {
                    startingColumnR = 65;
                    if (startingColumnL != 0)
                    {
                        startingColumnL++;
                    }
                    else
                    {
                        startingColumnL = 65;
                    }
                }
                if (startingColumnL > 0)
                    startingColumn = Convert.ToChar(startingColumnL).ToString() + Convert.ToChar(startingColumnR);
                else
                    startingColumn = Convert.ToChar(startingColumnR).ToString();
                
                // Flag for MAX
                // if (startingColumn == "IV")
                //    break;
                excelCol.Add(r["JobChangeOrderNumber"].ToString(), startingColumn);
                range = startingColumn + "1";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderUserDescription"].ToString());
                range = startingColumn + "2";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderOwnerNumber"].ToString());
                range = startingColumn + "3";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderCCENumber"].ToString());
                range = startingColumn + "4";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderAmount"].ToString());
                range = startingColumn + "5";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderDescription"].ToString().Trim().Substring(0, 2));
                range = startingColumn + "6";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderNumber"].ToString());
                range = startingColumn + "9";
                oRange = oSheet.get_Range(range, range);
                oRangeTotal.Columns.Copy(oRange);
                startingColumnR++;
            }
            dataTable = DataBaseUtil.ExecuteDataset(reportQuery, CCEApplication.Connection, CommandType.Text).Tables[0];
            i = 9;
             code = "";
             phase = "";
            foreach (DataRow r in dataTable.Rows)
            {
                if (code != r["CostCode"].ToString() || phase != r["JobCostCodePhase"].ToString())
                {
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), startingColumn + i.ToString());
                    oRange.Rows.Insert(Type.Missing, Type.Missing);
                    code = r["CostCode"].ToString();
                    phase = r["JobCostCodePhase"].ToString();
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CostCodeTitle"].ToString());
                    oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["JobCostCodePhase"].ToString());
                    oRange = oSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["CostCode"].ToString());
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["TotalBudgetHours"].ToString());
                    oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CommittedHours"].ToString());
                    //oRange = oSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                    //oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CostThisMonth"].ToString());
                    oRange = oSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                    oRangeRemaining.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                    oChangeOrderPercent.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                    oChangeOrder.Columns.Copy(oRange);
                }
                if (!String.IsNullOrEmpty(r["JobChangeOrderNumber"].ToString()))
                {
                    try
                    {
                        range = excelCol[r["JobChangeOrderNumber"].ToString()].ToString() + i.ToString().Trim();
                        oRange = oSheet.get_Range(range, range);
                        oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Value"].ToString());
                    }
                    catch (Exception ex) { }
                }
            }
            // //////////////////////////////////
            // Total Quantity Worksheet
            // //////////////////////////////////
            //if (oXl == null)
            //    oXl = new Microsoft.Office.Interop.Excel.Application();
            excelCol.Clear();
            if (perid == "Current")
                perid = "";
            if (perid == "")
                reportQuery = "   SELECT JobCostCodeType, CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], TotalBudgetQuantity, " +
                              " p.CommittedQuantity, ISNULL(c.Quantity, 0) AS [Value], P.CostThisMonth , JobChangeOrderNumber " +
                              " FROM tblJobCostCodePhase p " +
                              " LEFT JOIN tblJobCostCode c ON p.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                              " LEFT JOIN tblJobChangeOrder d ON c.JobChangeOrderID = d.JobChangeOrderID " +
                              "  WHERE p.JobID = " + jobID + " ORDER BY JobCostCodePhase Desc, CostCode Desc ";
            else
                reportQuery = " SELECT CostCode, JobCostCodePhase, UserDescription AS [CostCodeTitle], TotalBudgetQuantity, " +
                              " p.CommittedQuantity, ISNULL(c.Quantity, 0) AS [Value], P.CostThisMonth , JobChangeOrderNumber " +
                              "  FROM tblJobCostCodePhaseHistory p " +
                              "  LEFT JOIN tblJobCostCode c ON p.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                              " LEFT JOIN tblJobChangeOrder d ON c.JobChangeOrderID = d.JobChangeOrderID " +
                              "  WHERE p.JobID = " + jobID + " AND p.period = '" + perid + "' ORDER BY JobCostCodePhase Desc, CostCode Desc ";
            query = "SELECT JobChangeOrderID, JobChangeOrderNumber, JobChangeOrderStatus, JobChangeOrderDescription, " +
                    " ISNULL(JobChangeOrderOwnerNumber,'') AS ChangeOrderOwnerNumber,  " +
                    " ISNULL(JobChangeOrderCCENumber,'')   AS ChangeOrderCCENumber,  " +
                    " ISNULL(JobChangeOrderUserDescription, '') AS JobChangeOrderUserDescription, " +
                    " ChangeOrderAmount =  " +
                    " CASE SUBSTRING(JobChangeOrderDescription,1,2) " +
                    " WHEN 'OR' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'B~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'E~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'G~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'M~' THEN JobChangeOrderApprovedAmount " +
                    " WHEN 'C~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'F~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'H~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'J~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'K~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'N~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'D~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'L~' THEN JobChangeOrderRequestedAmount " +
                    " WHEN 'X~' THEN JobChangeOrderRequestedAmount " +
                    " ELSE 0 " +
                    " END " +
                    " FROM tblJobChangeOrder  " +
                    " WHERE JobID = " + jobID + " " +
                    " ORDER BY JobChangeOrderNumber ASC ";

            startingColumnR = 74;
            startingColumnL = 0;//  72 -- ASCII for the column title 
            try
            {
                dataTable = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
               // CopyExcelFile(excelFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (perid == "")
                perid = "Current";
            //oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["TotalQuantity"];
            oRange = oSheet.get_Range("D2", "D2");
            oRange.Formula = perid;
            oRangeRemaining = oSheet.get_Range("G8", "G8");
            oChangeOrder = oSheet.get_Range("I8", "I8");
            oChangeOrderPercent = oSheet.get_Range("H8", "H8");
            oRangeTotal = oSheet.get_Range("E10", "E10");
            UpdateHeader();
            foreach (DataRow r in dataTable.Rows)
            {
                if (startingColumnR > 90)
                {
                    startingColumnR = 65;
                    if (startingColumnL != 0)
                    {
                        startingColumnL++;
                    }
                    else
                    {
                        startingColumnL = 65;
                    }
                }
                if (startingColumnL > 0)
                    startingColumn = Convert.ToChar(startingColumnL).ToString() + Convert.ToChar(startingColumnR);
                else
                    startingColumn = Convert.ToChar(startingColumnR).ToString();
                //
                // Flag for MAX
                //
                // if (startingColumn == "IV")
                //    break;
                excelCol.Add(r["JobChangeOrderNumber"].ToString(), startingColumn);
                range = startingColumn + "1";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderUserDescription"].ToString());
                range = startingColumn + "2";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderOwnerNumber"].ToString());
                range = startingColumn + "3";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderCCENumber"].ToString());
                range = startingColumn + "4";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ChangeOrderAmount"].ToString());
                range = startingColumn + "5";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderDescription"].ToString().Trim().Substring(0, 2));
                range = startingColumn + "6";
                oRange = oSheet.get_Range(range, range);
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["JobChangeOrderNumber"].ToString());
                range = startingColumn + "9";
                oRange = oSheet.get_Range(range, range);
                oRangeTotal.Columns.Copy(oRange);
                startingColumnR++;
            }
            dataTable = DataBaseUtil.ExecuteDataset(reportQuery, CCEApplication.Connection, CommandType.Text).Tables[0];
            i = 9;
            code = "";
            phase = "";
            foreach (DataRow r in dataTable.Rows)
            {
                if (code != r["CostCode"].ToString() || phase != r["JobCostCodePhase"].ToString())
                {
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), startingColumn + i.ToString());
                    oRange.Rows.Insert(Type.Missing, Type.Missing);
                    code = r["CostCode"].ToString();
                    phase = r["JobCostCodePhase"].ToString();
                    oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CostCodeTitle"].ToString());
                    oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["JobCostCodePhase"].ToString());
                    oRange = oSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["CostCode"].ToString());
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["TotalBudgetQuantity"].ToString());
                    oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CommittedQuantity"].ToString());
                    //oRange = oSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                    //oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["CostThisMonth"].ToString());
                    oRange = oSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                    oRangeRemaining.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                    oChangeOrderPercent.Columns.Copy(oRange);
                    oRange = oSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                    oChangeOrder.Columns.Copy(oRange);
                }
                if (!String.IsNullOrEmpty(r["JobChangeOrderNumber"].ToString()))
                {
                    try
                    {
                        range = excelCol[r["JobChangeOrderNumber"].ToString()].ToString() + i.ToString().Trim();
                        oRange = oSheet.get_Range(range, range);
                        oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Value"].ToString());
                    }
                    catch (Exception ex) { }
                }
            }


            oXl.Visible = true;
            oXl.UserControl = true;
        }

        private void CreateExcelFileLaborProd(string periodDate)
        {
            DataTable dataTable;

            if (oXl == null)
                oXl = new Microsoft.Office.Interop.Excel.Application();
            excelFileName = "BudgetWorksheet.xls";
            reportQuery = " SELECT  JobNumber, JobName, Description As [ProjectManager], j.CustomerID, [Name] As [CustomerName]," +
                        " ContractNumber, ContractStartDate, ContractEstComplDate  FROM tblJob j " +
                        " LEFT Join tblProjectManager m " +
                        " ON j.ProjectManagerID = m.ProjectManagerID " +
                        " LEFT Join tblCustomer c " +
                        " ON j.CustomerID = c.CustomerID " +
                        " WHERE JobID = " + jobID + " ";

            
            try
            {
                dataTable = DataBaseUtil.ExecuteDataset(reportQuery, CCEApplication.Connection, CommandType.Text).Tables[0];
                CopyExcelFile(excelFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["Orig. Budget"];           
            oRange = oSheet.get_Range("e1", "e1");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["JobNumber"].ToString());
            oRange = oSheet.get_Range("e2" , "e2");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["JobName"].ToString());
            oRange = oSheet.get_Range("e3" , "e3");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["ProjectManager"].ToString());
            oRange = oSheet.get_Range("e4" , "e4");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["CustomerName"].ToString());
            oRange = oSheet.get_Range("e6" , "e6");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["ContractStartDate"].ToString());
            oRange = oSheet.get_Range("e7" , "e7");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["ContractEstComplDate"].ToString());
            oRange = oSheet.get_Range("k3" , "k3");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["ContractNumber"].ToString());
            oRange = oSheet.get_Range("k4" , "k4");
            oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, dataTable.Rows[0]["CustomerID"].ToString());
            oXl.Visible = true;
            oXl.UserControl = true;
        }
        //
        public void CostToCompletion(string summaryTemplate)
        {
            DataTable dataTable;
            Excel.Range oCurrentCost;
            Excel.Range oStaticA;
            Excel.Range oStaticB;
            Excel.Range oStaticAA;
            Excel.Range oStaticBB;
            Excel.Range oStaticAAA;
            int labor = 10;
            int material = 15;
            int rental = 20;
            int subcontract = 25;
            int prefab = 30;
            int djc = 35;
            int i = 0;

            if (summaryTemplate == "True")
            {
                excelFileName = "CostToCompleteSummary.xls";
            }
            else
            {
                if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
                Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
                    excelFileName = "CostToComplete3.xls";
                else
                    excelFileName = "CostToCompleteNoWIP2.xls";
            }
            if (oXl == null)
                oXl = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (perid.Trim().Length > 0)
                    dataTable = CostCode.GetJobProgressForExcelHistory(jobID,perid).Tables[0];
                else
                    dataTable = CostCode.GetJobProgressForExcel(jobID).Tables[0];
                CopyExcelFile(excelFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["Cost At Completion"];
            oSheet.Unprotect("atefbakir");
            oCurrentCost = oSheet.get_Range("k10", "M10");
            oStaticA = oSheet.get_Range("q10", "x10");
            oStaticB = oSheet.get_Range("A10", "AH10");
            oStaticAA = oSheet.get_Range("w14", "x14");
            oStaticAAA = oSheet.get_Range("w14", "x14");
            oStaticBB = oSheet.get_Range("AA14", "AE14");
            UpdateHeader();
            foreach (DataRow r in dataTable.Rows)
            {
                switch (r["Type"].ToString())
                {
                    case "100 - LABOR":
                        i = labor;
                        material++;
                        rental++;
                        subcontract++;
                        prefab++;
                        djc++;
                        break;
                    
                    case "200 - MATERIAL":
                        i = material;
                        rental++;
                        subcontract++;
                        prefab++;
                        djc++;
                        break;
                    case "300 - RENTAL":
                        i = rental;
                        subcontract++;
                        prefab++;
                        djc++;
                        break;
                    case "400 - SUBCONTRACT":
                        i = subcontract;
                        prefab++;
                        djc++;
                        break;
                    case "500 - PREFAB":
                        i = prefab;
                        djc++;
                        break;
                    case "800 - DJC":
                        i = djc;
                        break;
                    default:
                        i = djc;
                        break;

                }
                oRange = oSheet.get_Range("A" + i.ToString(), "AN" + i.ToString());
                oRange.Rows.Insert(Type.Missing, Type.Missing);
                oRange = oSheet.get_Range("k" + i.ToString().Trim(), "m" + i.ToString());
                oCurrentCost.Columns.Copy(oRange);
                oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Phase"].ToString());
                oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Code"].ToString());
                oRange = oSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Description"].ToString());
                if (summaryTemplate == "True")
                {
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Total Budget Cost"].ToString());
                    oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Committed Cost"].ToString());
                    oRange = oSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Open Commitment"].ToString());
                    oRange = oSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Projected CAC"].ToString());
                    oRange = oSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Projected Over/Under"].ToString());
                    oRange = oSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Value Adjustment"].ToString());
                    oRange = oSheet.get_Range("J" + i.ToString().Trim(), "J" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Revised CAC"].ToString());
                    oRange = oSheet.get_Range("K" + i.ToString().Trim(), "K" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Revised Over/Under"].ToString());
                }
                else
                {
                    oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Original Contract Qty"].ToString());
                    oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Original Contract Hrs"].ToString());
                    oRange = oSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Original Contract Cost"].ToString());
                    oRange = oSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Approved Change Order Qty"].ToString());
                    oRange = oSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Approved Change Order Hrs"].ToString());
                    oRange = oSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Approved Change Order Cost"].ToString());
                    oRange = oSheet.get_Range("j" + i.ToString().Trim(), "j" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Pending W. Proceed Hrs"].ToString());
                    oRange = oSheet.get_Range("k" + i.ToString().Trim(), "k" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Pending W. Proceed Qty"].ToString());
                    oRange = oSheet.get_Range("l" + i.ToString().Trim(), "l" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Pending W. Proceed Cost"].ToString());
                    oRange = oSheet.get_Range("M" + i.ToString().Trim(), "M" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Qty Adjustment"].ToString());
                    oRange = oSheet.get_Range("N" + i.ToString().Trim(), "N" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Total Budget Hrs"].ToString());
                    oRange = oSheet.get_Range("O" + i.ToString().Trim(), "O" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Total Budget Qty"].ToString());
                    oRange = oSheet.get_Range("P" + i.ToString().Trim(), "P" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Total Budget Cost"].ToString());
                    oRange = oSheet.get_Range("Q" + i.ToString().Trim(), "Q" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Committed Hrs"].ToString());
                    oRange = oSheet.get_Range("R" + i.ToString().Trim(), "R" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Committed Qty"].ToString());
                    oRange = oSheet.get_Range("S" + i.ToString().Trim(), "S" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Committed Cost"].ToString());
                    oRange = oSheet.get_Range("T" + i.ToString().Trim(), "T" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Budget Labor Unit"].ToString());
                    oRange = oSheet.get_Range("U" + i.ToString().Trim(), "U" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Actual Labor Unit"].ToString());
                    oRange = oSheet.get_Range("V" + i.ToString().Trim(), "V" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Open Commitment"].ToString());
                    oRange = oSheet.get_Range("W" + i.ToString().Trim(), "W" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["% Used Hrs"].ToString());
                    oRange = oSheet.get_Range("X" + i.ToString().Trim(), "X" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["% Used Qty"].ToString());
                    oRange = oSheet.get_Range("Y" + i.ToString().Trim(), "Y" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["EarnedHours"].ToString());
                    oRange = oSheet.get_Range("Z" + i.ToString().Trim(), "Z" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Estimated Perf. Factor"].ToString());
                    oRange = oSheet.get_Range("AA" + i.ToString().Trim(), "AA" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Differential Hrs"].ToString());
                    oRange = oSheet.get_Range("AB" + i.ToString().Trim(), "AB" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["EstimatedCrewRate"].ToString());
                    oRange = oSheet.get_Range("AC" + i.ToString().Trim(), "AC" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Current Perf. Hrs"].ToString());
                    oRange = oSheet.get_Range("AD" + i.ToString().Trim(), "AD" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Projected Total Hrs"].ToString());
                    oRange = oSheet.get_Range("AE" + i.ToString().Trim(), "AE" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Projected CAC"].ToString());
                    oRange = oSheet.get_Range("AF" + i.ToString().Trim(), "AF" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Projected Over/Under"].ToString());
                    oRange = oSheet.get_Range("AG" + i.ToString().Trim(), "AG" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Value Adjustment"].ToString());
                    oRange = oSheet.get_Range("AH" + i.ToString().Trim(), "AH" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Revised CAC"].ToString());
                    oRange = oSheet.get_Range("AI" + i.ToString().Trim(), "AI" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Revised Over/Under"].ToString());
                    oRange = oSheet.get_Range("AJ" + i.ToString().Trim(), "AJ" + i.ToString());
                    oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Revised Perf. Factor"].ToString());
                    if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
                        Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
                    {
                        oRange = oSheet.get_Range("AK" + i.ToString().Trim(), "AK" + i.ToString());
                        oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["ActualCostPlusCommitment"].ToString());
                        oRange = oSheet.get_Range("AL" + i.ToString().Trim(), "AL" + i.ToString());
                        oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Monthend CAC"].ToString());
                        oRange = oSheet.get_Range("AM" + i.ToString().Trim(), "AM" + i.ToString());
                        oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Monthend Value Adjustment"].ToString());
                        oRange = oSheet.get_Range("AN" + i.ToString().Trim(), "AN" + i.ToString());
                        oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Revised Monthend CAC"].ToString());
                    }
                }
            }
            oXl.Visible = true;
            oXl.UserControl = true;
        }
        //
        public void CostToCompletionWIP()
        {
            DataTable dataTable;
            Excel.Range oCurrentCost;
            Excel.Range oStaticA;
            Excel.Range oStaticB;
            Excel.Range oStaticAA;
            Excel.Range oStaticBB;
            Excel.Range oStaticAAA;
            int labor = 10;
            int material = 15;
            int rental = 20;
            int subcontract = 25;
            int prefab = 30;
            int djc = 35;
            int i = 0;
            excelFileName = "CostToCompleteWIP.xls";
            if (oXl == null)
                oXl = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (perid.Trim().Length > 0)
                    dataTable = CostCode.GetJobProgressForExcelHistory(jobID, perid).Tables[0];
                else
                    dataTable = CostCode.GetJobProgressForExcel(jobID).Tables[0];
                CopyExcelFile(excelFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            oSheets = oBook.Sheets;
            oSheet = (Excel.Worksheet)oSheets["Cost At Completion"];
            oSheet.Unprotect("atefbakir");
            oCurrentCost = oSheet.get_Range("k10", "M10");
            oStaticA = oSheet.get_Range("q10", "x10");
            oStaticB = oSheet.get_Range("z10", "Af10");
            oStaticAA = oSheet.get_Range("w14", "x14");
            oStaticAAA = oSheet.get_Range("w14", "x14");
            oStaticBB = oSheet.get_Range("z14", "Ac14");
            UpdateHeader();
            foreach (DataRow r in dataTable.Rows)
            {
                switch (r["Type"].ToString())
                {
                    case "100 - LABOR":
                        i = labor;
                        material++;
                        rental++;
                        subcontract++;
                        prefab++;
                        djc++;
                        break;
                    case "200 - MATERIAL":
                        i = material;
                        rental++;
                        subcontract++;
                        prefab++;
                        djc++;
                        break;
                    case "300 - RENTAL":
                        i = rental;
                        subcontract++;
                        prefab++;
                        djc++;
                        break;
                    case "400 - SUBCONTRACT":
                        i = subcontract;
                        prefab++;
                        djc++;
                        break;
                    case "500 - PREFAB":
                        i = prefab;
                        djc++;
                        break;
                    case "800 - DJC":
                        i = djc;
                        break;
                    default:
                        i = djc;
                        break;

                }
                oRange = oSheet.get_Range("A" + i.ToString(), "AL" + i.ToString());
                oRange.Rows.Insert(Type.Missing, Type.Missing);
                oRange = oSheet.get_Range("k" + i.ToString().Trim(), "m" + i.ToString());
                oCurrentCost.Columns.Copy(oRange);
                oRange = oSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Phase"].ToString());
                oRange = oSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Code"].ToString());
                oRange = oSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, " " + r["Description"].ToString());
                oRange = oSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Total Budget Hrs"].ToString());
                oRange = oSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Total Budget Cost"].ToString());
                oRange = oSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Committed Hrs"].ToString());
                oRange = oSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Committed Cost"].ToString());
                oRange = oSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Open Commitment"].ToString());
                oRange = oSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                oRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, r["Revised Monthend CAC"].ToString());
            }
            oXl.Visible = true;
            oXl.UserControl = true;
        }
        //
        private void UpdateHeader()
        {
            oSheet.PageSetup.RightHeader = "Job Name: " + jobName + "\n" + "Job Number: " + jobNumber + "\n" + "GC Name: " + contractorName;
        }
        //
        private void CopyExcelFile(string fileName)
        {
            Exception ex;
            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
            string tempLocation = Environment.CurrentDirectory;  
            
            if (!File.Exists(CCEApplication.ExcelTemplatesLocation + fileName))
            {
                ex = new Exception("Excel Template file " + fileName + "  not found");
                throw ex;
            }
            if (File.Exists(tempLocation + "\\" + fileName))
                File.Delete(tempLocation + "\\" + fileName);
            try
            {
                File.Copy(CCEApplication.ExcelTemplatesLocation + fileName,
                    tempLocation + "\\" + fileName,
                    true);
                oBook = oXl.Workbooks._Open(tempLocation + "\\" + fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
        }
        //
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    oXl = null;
                    //Components.Dispose();
                }
            }
            disposed = true;
        }
        //
        ~ExcelReport()
        {
            Dispose(true);
        }
    }
}
