using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCPurchasing.BusinessLayer
{
    public class PO
    {
        public static DataSet GetPOInvoicesWithDifferentJobNumber(string where)
        {
            string query = "";

            query = " SELECT a.JobNumber As [POJob], JobName, b.JobNumber AS [InvoiceJob],  b.PO AS [PO], " +
                    " b.[Inv No], m.Description AS [ProjectManager], b.VendorID + ' - ' + [Name] as Vendor, " +
                    " InvoiceDescription as [Desc],  b.[Gross Amt], " +  
	                " b.[Gross Pay Amt], " + 
                    " b.[Inv Date], b.[Due Date], Payment, PaymentDate AS [Pay Date] " + 
                    " FROM tblJobPOInvoice b " + 
                    " INNER JOIN tblJobPO a ON b.PO = a.PO " +
                    " LEFT JOIN tblJobPOInvoicePayment p " +
                    " ON b.[Inv No] = p.InvoiceNumber AND a.JobNumber = p.JobNumber " + 
                    " LEFT JOIN tblJob j ON a.JobNumber = j.JobNumber " +
                    " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " + 	
                    where + 
                    " ORDER BY PO ";
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
        public static DataSet GetPOList(string where)
        {
            string query = "";

            query = "SELECT p.PO, " +
	                " p.JobNumber AS [Job Number], " +
	                " J.JobName AS [JobName], " +  
	                " Category = " + 
	                " Case Category " +
	                " WHEN  'E' THEN 'Equipment' " +
	                " WHEN  'R' THEN 'Rental' " +
	                " WHEN  'S' THEN 'Sub Contract' " +
	                " WHEN  'T' THEN 'Tools' " +
	                " WHEN  'O' THEN 'Other' " +
	                " WHEN  'C' THEN 'Capital' " +
	                " WHEN  'W' THEN 'Wharehouse' " +
	                " WHEN  'A' THEN 'Automotive' " +
	                " WHEN  'M' THEN 'Material' " +
	                " WHEN  'I' THEN 'Instrument' " +							
	                " ELSE 'Material' " +
	                " END, " +  
	                " v.Name AS Vendor, " +
	                " [Ship Date] AS [Issue Date], " + 
	                " [Gross Amt], " +
	                " [Tax], " +
                    " Freight, " +
	                " [Net Amt], " +
	                " PurchasingAgent AS [PurchasingAgent], " +
                    " m.Description  AS [ProjectManager], " +
                    " s.Description AS [PO Status], " +
                    " LastInvoiceDate AS [Last Inv Date], " +
                    " Variance, " +
                    " [Remaining Balance], " +
                    " [Work Order], " +
                    " NoActivityFlag AS [No Activity] " +
                    " FROM  tblJobPO p " + 
                    " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " + 
                    " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                    " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " +
                    " LEFT JOIN tblPOStatus s ON p.POStatus = s.POStatus " +
                    where; 
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
        public static DataSet GetPO(string jobNumber, string poNumber)
        {
            string query = " SELECT " +
                             " p.JobNumber + ' - ' + Category + ' - ' + p.PO AS PONumber, " +
                             " p.VendorID, " +
                             " [Ship Date], " +
                             " [Work Order], " +
                             " ShipVia, " +
                             " FOB, " +
                             " PrintDate, " +
                             " Attention, " +
                             " ShipToName, " +
                             " ShipToAddress, " +
                             " ShipToCity, " +
                             " ShipToState," +
                             " ShipToZip, " +
                             " Note, " +
                             " NoteInternal, " +
                             " PurchasingAgent, " +
                             " VendorAttn, " +
                             " [Net Amt] AS Net, " +
                             " Tax, " +
                             " Freight, " +
                             " [Gross Amt] AS Gross, " +
                             " LineNumber, " +
                             " ISNULL(CatNo, '') + ' - ' + ISNULL(MatName, '') AS [Description], " +
                             " UM, " +
                             " QuantityOrdered, " +
                             " QuantityReceived, " +
                             " Price, " +
                             " ExtGross, " +
                             " [Name] AS VendorName, " +
                             " Address1 AS VendorAddress, " +
                             " City	AS VendorCity, " +
                             " State	As VendorState, " +
                             " ZipCode	As VendorZipCode, " +
                             " Phone	AS VendorPhone, " +
                             " Fax		AS VendorFax, " +
                             " JobName " +
                             " FROM  tblJobPO p " +
                             " LEFT JOIN tblJobPOItem t ON p.JobNumber = t.JobNumber AND p.PO = t.PO " +
                             " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                             " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                             " WHERE p.PO = '" + poNumber + "' AND p.JobNumber = '" + jobNumber + "' "; 
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
        public static DataSet GetPOAll(string query)
        {
            string query1 = " SELECT " +
                             " p.JobNumber + ' - ' + Category + ' - ' + p.PO AS PONumber, " +
                             " p.VendorID, " +
                             " [Ship Date], " +
                             " [Work Order], " +
                             " ShipVia, " +
                             " FOB, " +
                             " PrintDate, " +
                             " Attention, " +
                             " ShipToName, " +
                             " ShipToAddress, " +
                             " ShipToCity, " +
                             " ShipToState," +
                             " ShipToZip, " +
                             " Note, " +
                             " NoteInternal, " +
                             " PurchasingAgent, " +
                             " VendorAttn, " +
                             " [Net Amt] AS Net, " +
                             " Tax, " +
                             " Freight, " +
                             " [Gross Amt] AS Gross, " +
                             " LineNumber, " +
                             " ISNULL(CatNo, '') + ' - ' + ISNULL(MatName, '') AS [Description], " +
                             " UM, " +
                             " QuantityOrdered, " +
                             " QuantityReceived, " +
                             " Price, " +
                             " ExtGross, " +
                             " [Name] AS VendorName, " +
                             " Address1 AS VendorAddress, " +
                             " City	AS VendorCity, " +
                             " State	As VendorState, " +
                             " ZipCode	As VendorZipCode, " +
                             " Phone	AS VendorPhone, " +
                             " Fax		AS VendorFax, " +
                             " JobName " +
                             " FROM  tblJobPO p " +
                             " LEFT JOIN tblJobPOItem t ON p.JobNumber = t.JobNumber AND p.PO = t.PO " +
                             " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                             " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                             query;
            try
            {
                return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetPurchaseOrder(string poNumber)
        {
            string query = " SELECT " +
                             " p.JobNumber + ' - ' + Category + ' - ' + p.PO AS PONumber, " +
                             " p.VendorID, " +
                             " [Ship Date], " +
                             " [Work Order], " +
                             " ShipVia, " +
                             " FOB, " +
                             " PrintDate, " +
                             " Attention, " +
                             " ShipToName, " +
                             " ShipToAddress, " +
                             " ShipToCity, " +
                             " ShipToState," +
                             " ShipToZip, " +
                             " Note, " +
                             " NoteInternal, " +
                             " PurchasingAgent, " +
                             " VendorAttn, " +
                             " [Net Amt] AS Net, " +
                             " Tax, " +
                             " Freight, " +
                             " [Gross Amt] AS Gross, " +
                             " LineNumber, " +
                             " ISNULL(CatNo, '') + ' - ' + ISNULL(MatName, '') AS [Description], " +
                             " UM, " +
                             " QuantityOrdered, " +
                             " QuantityReceived, " +
                             " Price, " +
                             " ExtGross, " +
                             " [Name] AS VendorName, " +
                             " Address1 AS VendorAddress, " +
                             " City	AS VendorCity, " +
                             " State	As VendorState, " +
                             " ZipCode	As VendorZipCode, " +
                             " Phone	AS VendorPhone, " +
                             " Fax		AS VendorFax, " +
                             " JobName " +
                             " FROM  tblJobPO p " +
                             " LEFT JOIN tblJobPOItem t ON p.JobNumber = t.JobNumber AND p.PO = t.PO " +
                             " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                             " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                             " WHERE p.PO = '" + poNumber + "' ";
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
        public static DataSet GetJobPurchaseOrdersList(string jobNumber)
        {
            string query = "";

            query = "SELECT p.PO, " +
                    " p.JobNumber AS [Job Number], " +
                    " J.JobName AS [Job Name], " +
                    " Category = " +
                    " Case Category " +
                    " WHEN  'E' THEN 'Equipment' " +
                    " WHEN  'R' THEN 'Rental' " +
                    " WHEN  'S' THEN 'Sub Contract' " +
                    " WHEN  'T' THEN 'Tools' " +
                    " WHEN  'O' THEN 'Other' " +
                    " WHEN  'C' THEN 'Capital' " +
                    " WHEN  'W' THEN 'Wharehouse' " +
                    " WHEN  'A' THEN 'Automotive' " +
                    " WHEN  'M' THEN 'Material' " +
                    " WHEN  'I' THEN 'Instrument' " +
                    " ELSE 'Material' " +
                    " END, " +
                    " WorkOrder = " +
                    " CASE ISNULL([Work Order], '') " +
                    " WHEN '' THEN 'No Assigned Number' " +
                    " ELSE [Work Order] " +
                    " END, " +
                    " v.Name AS Vendor, " +
                    " [Ship Date] AS [Issue Date], " +
                    " [Gross Amt], " +
                    " [Tax], " +
                    " [Net Amt], " +
                    " PurchasingAgent AS [Purchasing Agent] " +
                    " FROM  tblJobPO p " +
                    " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                    " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                    " WHERE p.JobNumber = '" + jobNumber + "'  AND p.PO NOT LIKE 'N/A%'";
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
        public static DataSet GetJobPurchaseOrdersListByWorkOrder(string jobNumber, string startDate, string endDate)
        {
            string query = "";

            query = "SELECT p.PO, " +
                    " p.JobNumber AS [Job Number], " +
                    " J.JobName AS [Job Name], " +
                    " Category = " +
                    " Case Category " +
                    " WHEN  'E' THEN 'Equipment' " +
                    " WHEN  'R' THEN 'Rental' " +
                    " WHEN  'S' THEN 'Sub Contract' " +
                    " WHEN  'T' THEN 'Tools' " +
                    " WHEN  'O' THEN 'Other' " +
                    " WHEN  'C' THEN 'Capital' " +
                    " WHEN  'W' THEN 'Wharehouse' " +
                    " WHEN  'A' THEN 'Automotive' " +
                    " WHEN  'M' THEN 'Material' " +
                    " WHEN  'I' THEN 'Instrument' " +
                    " ELSE 'Material' " +
                    " END, " +
                    " WorkOrder = " +
                    " CASE ISNULL([Work Order], '') " +
                    " WHEN '' THEN 'No Assigned Number' " +
                    " ELSE [Work Order] " +
                    " END, " +
                    " v.Name AS Vendor, " +
                    " [Ship Date] AS [Issue Date], " +
                    " [Gross Amt], " +
                    " [Tax], " +
                    " [Net Amt], " +
                    " PurchasingAgent AS [Purchasing Agent] " +
                    " FROM  tblJobPO p " +
                    " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                    " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                    " WHERE p.JobNumber = '" + jobNumber + "'  AND ([Ship Date] BETWEEN '" + startDate + "' AND '" + endDate + "') AND p.PO NOT LIKE 'N/A%' " ;
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
        public static DataSet GetNotUsedPONumbers(string startDate, string endDate)
        {
            string query = "";

            query = "SELECT * FROM tblJobPOMissing ";
            if (startDate.Length > 0 && endDate.Length > 0)
                query += " WHERE Period BETWEEN '" + startDate + "' AND '" + endDate + "' ";
            else if (startDate.Length > 0)
                query += " WHERE Period  = '" + startDate + "' ";
            else if (endDate.Length > 0)
                query += " WHERE Period  = '" + endDate + "' ";
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
        public static DataSet GetJobPurchaseOrdersList5000(string startDate, string endDate)
        {
            string query = "";

            query = "SELECT p.PO, " +
                    " p.JobNumber AS [Job Number], " +
                    " J.JobName AS [Job Name], " +
                    " Category = " +
                    " Case Category " +
                    " WHEN  'E' THEN 'Equipment' " +
                    " WHEN  'R' THEN 'Rental' " +
                    " WHEN  'S' THEN 'Sub Contract' " +
                    " WHEN  'T' THEN 'Tools' " +
                    " WHEN  'O' THEN 'Other' " +
                    " WHEN  'C' THEN 'Capital' " +
                    " WHEN  'W' THEN 'Wharehouse' " +
                    " WHEN  'A' THEN 'Automotive' " +
                    " WHEN  'M' THEN 'Material' " +
                    " WHEN  'I' THEN 'Instrument' " +
                    " ELSE 'Material' " +
                    " END, " +
                    " WorkOrder = " +
            " CASE ISNULL([Work Order], '') " +
            " WHEN '' THEN 'No Assigned Number' " +
            " ELSE [Work Order] " +
            " END, " +
            " v.Name AS Vendor, " +
            " [Ship Date] AS [Issue Date], " +
            " [Gross Amt], " +
            " [Tax], " +
            " [Net Amt], " +
            " PurchasingAgent AS [Purchasing Agent], " +
            " Description AS [ProjectManager] " +
            " FROM  tblJobPO p " +
            " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
            " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
            " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " +
            " WHERE ([Ship Date] BETWEEN '" + startDate + "' AND '" + endDate + "')  AND [Gross Amt] >= 5000 AND p.PO NOT LIKE 'N/A%'";
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
        public static DataSet GetPurchaseOrderReceivedItems(string poNumber)
        {
            string query = "";

            query = "SELECT " +
                  " p.JobNumber + ' - ' + Category + ' - ' + p.PO AS PONumber, " + 
                  " p.VendorID, " +
                  " [Ship Date], " +
                  " [Work Order], " +
                  " ShipVia, " +
                  " FOB, " +
                  " PrintDate, " + 
                  " Attention, " +
                  " ShipToName, " +
                  " ShipToAddress, " +
                  " ShipToCity, " +
                  " ShipToState, " +
                  " ShipToZip, " +
                  " Note, " +
                  " NoteInternal, " + 
                  " PurchasingAgent, " +
                  " VendorAttn, " + 
                  " [Net Amt] AS Net, " + 
                  " p.Tax, " +
                  " [Gross Amt] AS Gross, " + 
                  " t.LineNumber, " +
                  " ISNULL(CatNo, '') + ' - ' + ISNULL(MatName, '') AS [Description], " + 
                  " UM, " +
                  " QuantityOrdered, " + 
                  " r.QuantityReceived, " +
                  " r.Price, " +
                  " r.TotalPrice, " +
				  " r.DateReceived,	" + 
                  " [Name] AS VendorName, " + 
                  " Address1 AS VendorAddress, " + 
                  " City	AS VendorCity, " +
                  " State	As VendorState, " +
                  " ZipCode	As VendorZipCode, " +
                  " Phone	AS VendorPhone, " +
                  " Fax		AS VendorFax, " +
                  " JobName " +
                  " FROM  tblJobPO p " + 
                  " LEFT JOIN tblJobPOItem t ON p.JobNumber = t.JobNumber AND p.PO = t.PO " + 
                  " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                  " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
				  " LEFT JOIN tblJobPOItemReceived r ON t.JobNumber = r.JobNumber AND t.PO = r.PO AND t.LineNumber = r.LineNumber " +	
                  " WHERE p.PO = '" + poNumber + "' ";

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
        public static DataSet GetPurchaseOrderInvoices(string poNumber)
        {
            string query = "";

            query =  " SELECT p.JobNumber + ' - ' + Category + ' - ' + p.PO AS PONumber, " +
                   " p.VendorID, " + 
                   " [Ship Date], " +
                   " [Work Order], " +
                   " ShipVia, " +
                   " FOB, " +
                   " PrintDate, " +  
                   " Attention, " + 
                   " ShipToName, " +
                   " ShipToAddress, " + 
                   " ShipToCity, " + 
                   " ShipToState, " + 
                   " ShipToZip, " + 
                   " Note, " +
                   " NoteInternal, " +  
                   " PurchasingAgent, " +
                   " VendorAttn, " +
                   " v.[Name] AS VendorName, " +
                   " Address1 AS VendorAddress, " +
                   " City	AS VendorCity, " +
                   " State	As VendorState, " +
                   " ZipCode	As VendorZipCode, " +
                   " Phone	AS VendorPhone, " +
                   " Fax		AS VendorFax, " +
                   " JobName, " +
                   " [Net Amt] AS Net, " +   
                   " p.Tax, " +
                   " p.[Gross Amt] AS Gross, " +
				 	" [Inv No], " +
					" InvoiceDescription as [Desc], " +
					" i.[Gross Amt] As [Gross Amt], " +
					" i.[Gross Pay Amt], " +
					" [Inv Date], " +
					" [Due Date], " +
					" Payment, " +
					" PaymentDate as [Pay Date] " +	
                   " FROM  tblJobPO p " +
                   " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " + 
                   " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " + 
				   " LEFT JOIN tblJobPOInvoice i ON p.JobNumber = i.JobNumber AND p.PO = i.PO " +
				   " LEFT JOIN tblJobPOInvoicePayment pp ON i.JobNumber = pp.JobNumber AND i.[Inv No] = pp.InvoiceNumber " +
                  " WHERE p.PO = '" + poNumber + "' ";

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
        public static DataSet GetJobPurchaseOrderListBySupplier(string jobNumber)
        {
            string query = "";

            query = "SELECT p.PO, " +
                    " p.JobNumber AS [Job Number], " +
                    " J.JobName AS [Job Name], " +
                    " Category = " +
                    " Case Category " +
                    " WHEN  'E' THEN 'Equipment' " +
                    " WHEN  'R' THEN 'Rental' " +
                    " WHEN  'S' THEN 'Sub Contract' " +
                    " WHEN  'T' THEN 'Tools' " +
                    " WHEN  'O' THEN 'Other' " +
                    " WHEN  'C' THEN 'Capital' " +
                    " WHEN  'W' THEN 'Wharehouse' " +
                    " WHEN  'A' THEN 'Automotive' " +
                    " WHEN  'M' THEN 'Material' " +
                    " WHEN  'I' THEN 'Instrument' " +
                    " ELSE 'Material' " +
                    " END, " +
                    " WorkOrder = " +
                    " CASE ISNULL([Work Order], '') " +
                    " WHEN '' THEN 'No Assigned Number' " +
                    " ELSE [Work Order] " +
                    " END, " +
                    " v.Name AS Vendor, " +
                    " [Ship Date] AS [Issue Date], " +
                    " [Gross Amt], " +
                    " [Tax], " +
                    " [Net Amt], " +
                    " PurchasingAgent AS [Purchasing Agent] " +
                    " FROM  tblJobPO p " +
                    " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                    " LEFT JOIN tblJob j ON p.JobNumber = j.JobNumber " +
                    " WHERE p.JobNumber = '" + jobNumber + "' AND p.PO NOT LIKE 'N/A%' ";

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
        public static DataSet GetPOsWithNoInvoce(string where)
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@Where", where);

                return DataBaseUtil.ExecuteParDataset("up_JCPOsWithNoInvoceReport", CCEApplication.Connection, CommandType.StoredProcedure, par);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
