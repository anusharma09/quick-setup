using ContraCostaElectric.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace JCCBusinessLayer
{
    public class FieldOperation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HireDate { get; set; }
        public string SSN { get; set; }
        public string Classification { get; set; }
        public string PastClassification1 { get; set; }
        public string PastClassification1Date { get; set; }
        public string PastClassification2 { get; set; }
        public string PastClassification2Date { get; set; }
        public string Union { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string TerminationReason { get; set; }
        public string TerminationDate { get; set; }
        public string Phone { get; set; }
        public string LogFilePath { get; set; }
        public int EmployeeID { get; set; }
        public string DestLocationPic { get; set; }
        public string Active { get; set; }

        public int i = 2;
        public static DataSet getOperationFieldList ( string where )
        {
            string query = "";

            query = "SELECT distinct a.EmployeeID, FirstName AS [First Name], LastName AS [Last Name], MiddleName AS [Middle Name], NickName AS [Nick Name]," +
                    " IsEmployeeActive AS [Active],EmailAddress AS [Email Address], PrimaryContactNumber AS [Primary Contact Phone],DynaAssignedPhone AS [Dyna Assigned Phone], " +
                    " b.Classification, b.ClassificationDate AS [Classification Date] " +
                    " FROM tblDynaEmployee a LEFT JOIN tblEmployeeClassification b ON a.EmployeeID=b.EmployeeID  AND b.IsCurrentClassification=1" +
                    " LEFT JOIN tblEmployeeTermination c  ON a.EmployeeID = c.EmployeeID AND c.IsCurrentTermination=1 " +
                    " LEFT JOIN tblEmployeeSafetyNotes d ON a.EmployeeID = d.EmployeeID " +
                    " LEFT JOIN tblEmployeeBadging e ON a.EmployeeID = e.EmployeeID " +
                    where + " ORDER BY a.EmployeeID ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Import ( string fileName, string picLocation, string logPath, string destLocation )
        {
            Object obj;
            Excel.Application objExcelApp = new Excel.Application();
            Excel.Workbook objBook;
            Excel.Sheets objSheets;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            bool bLoop = false;
            LogFilePath = logPath;
            Exception ex;
           
            DestLocationPic = destLocation;
            if (!File.Exists(fileName))
            {
                ex = new Exception("Employee File was not found");
                throw ex;
            }
            try
            {
                obj = System.Reflection.Missing.Value;
                objBook = objExcelApp.Workbooks.Open(fileName, obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj);
                objSheets = objBook.Sheets;
                objSheet = (Excel.Worksheet)objSheets["Sheet1"];
                bLoop = true;
                while (bLoop)
                {

                    objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    if (objRange.Text.ToString().Trim().ToUpper() == "END OF FILE")
                    {
                        bLoop = false;
                    }
                    else
                    {
                        objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                        LastName = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                        FirstName = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                        HireDate = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                        SSN = objRange.Text.ToString();

                        objRange = objSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                        Classification = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                        PastClassification1 = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                        PastClassification2 = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                        Union = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                        Email = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("J" + i.ToString().Trim(), "J" + i.ToString());
                        Notes = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("L" + i.ToString().Trim(), "L" + i.ToString());
                        PastClassification1Date = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("M" + i.ToString().Trim(), "M" + i.ToString());
                        PastClassification2Date = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("P" + i.ToString().Trim(), "P" + i.ToString());
                        TerminationReason = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("Q" + i.ToString().Trim(), "Q" + i.ToString());
                        TerminationDate = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("R" + i.ToString().Trim(), "R" + i.ToString());
                        Phone = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("S" + i.ToString().Trim(), "S" + i.ToString());
                        Active = objRange.Text.ToString().Trim();
                        if (Active.Trim().ToUpper() == "YES")
                            Active = "1";
                        else
                            Active = "0";

                        EmployeeID = Insert();
                        //  createEmployeeFolder();
                        migrateProfilePics(picLocation, i);
                    }
                    i++;
                }
                obj = false;
                objBook.Close(obj, obj, obj);
            }
            catch (Exception ex1)
            {
                string logText = "Excel Row Number - " + i + "----FirstName - " + FirstName + "----lastName - " + LastName + "----HireDate - " + HireDate + "----SSN - " + SSN + "====== Execption -" + ex1;
                ErrorLogger.MigrationErrorLog(logText, LogFilePath);
            }
            finally
            {
                objExcelApp.Quit();
                objExcelApp = null;
                GC.GetTotalMemory(true);
            }
        }

        public int Insert ()
        {
            string query = "";

            query = "INSERT INTO tblDynaEmployee(" +
                    " FirstName, " +
                    " LastName, " +
                    " EmailAddress, " +
                    " PrimaryContactNumber, " +
                    " HireDate, " +
                    " SocialSecurityNumber, " +
                    " UnionMemberNumber, " +
                    " Notes," +
                    " IsEmployeeActive " +
                    " ) VALUES ( '" +
                    FirstName.Replace("'","''") + "', '" +
                    LastName.Replace("'", "''") + "', '" +
                    Email + "',' " +
                    Phone + "', '" +
                    HireDate + "', '" +
                    SSN + "', '" +
                    Union + "', '" +
                    Notes.Replace("'", "''") + "', '" +
                    Active + "') " +
                    "Select SCOPE_IDENTITY()  ";
            string EmployeeId = null;
            try
            {
                EmployeeId = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                insertClassification(Convert.ToInt32(EmployeeId));
                insertTermination(Convert.ToInt32(EmployeeId));
                
            }
            catch (Exception ex)
            {
                string logText = "Excel Row Number - " + i + "----FirstName - " + FirstName + "----lastName - " + LastName + "----HireDate - " + HireDate + "----SSN - " + SSN + "====== Execption -" + ex;
                ErrorLogger.MigrationErrorLog(logText, LogFilePath);
            }
            return Convert.ToInt32(EmployeeId);
        }

        private void insertClassification ( int EmployeeID )
        {
            string query = "";
            EmployeeClassification empClassification;
            List<EmployeeClassification> lsClassification = new List<EmployeeClassification>();
            try
            {
                if (!string.IsNullOrEmpty(Classification))
                {
                    empClassification = new EmployeeClassification();
                    empClassification.Classification = Classification;
                    empClassification.IsCurrentClassification = true;
                    empClassification.ClassificationDate = null;
                    lsClassification.Add(empClassification);
                }
                if (!string.IsNullOrEmpty(PastClassification1))
                {
                    empClassification = new EmployeeClassification();
                    empClassification.Classification = PastClassification1;
                    empClassification.IsCurrentClassification = false;
                    if (!string.IsNullOrEmpty(PastClassification1Date))
                    {
                        empClassification.ClassificationDate = PastClassification1Date;
                    }
                    else
                    {
                        empClassification.ClassificationDate = null;
                    }

                    lsClassification.Add(empClassification);
                }
                if (!string.IsNullOrEmpty(PastClassification2))
                {
                    empClassification = new EmployeeClassification();
                    empClassification.Classification = PastClassification2;
                    empClassification.IsCurrentClassification = false;
                    if (!string.IsNullOrEmpty(PastClassification2Date))
                    {
                        empClassification.ClassificationDate = PastClassification2Date;
                    }
                    else
                    {
                        empClassification.ClassificationDate = null;
                    }

                    lsClassification.Add(empClassification);
                }
                foreach (EmployeeClassification cls in lsClassification)
                {
                    string isCurrent = cls.IsCurrentClassification == true ? "1" : "0";
                    if (!String.IsNullOrEmpty(cls.ClassificationDate))
                        query = "INSERT INTO tblEmployeeClassification(" +
                        " Classification, " +
                        " ClassificationDate, " +
                        " IsCurrentClassification, " +
                        " EmployeeID " +
                        " ) VALUES ( '" +
                        cls.Classification.Replace("'", "''") + "',' " +
                        cls.ClassificationDate + "' , " +
                        isCurrent + ", " +
                         EmployeeID + ") ";
                    else
                        query = "INSERT INTO tblEmployeeClassification(" +
                       " Classification, " +
                       " IsCurrentClassification, " +
                       " EmployeeID " +
                       " ) VALUES ( '" +
                       cls.Classification.Replace("'", "''") + "', " +
                       isCurrent + ", " +
                        EmployeeID + ") ";
                    try
                    {
                        DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        string logText = "Excel Row Number - " + i + "----FirstName - " + FirstName + "----lastName - " + LastName + "----HireDate - " + HireDate + "----SSN - " + SSN + "====== Execption -" + ex;
                        ErrorLogger.MigrationErrorLog(logText, LogFilePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void insertTermination ( int EmployeeID )
        {
            string query = "";

            query = "INSERT INTO tblEmployeeTermination(" +
                    " Reason, " +
                    " TerminationDate, " +
                    " IsCurrentTermination, " +
                    " EmployeeID " +
                    " ) VALUES ( '" +
                    TerminationReason.Replace("'", "''") + "', '" +
                     TerminationDate + "', '" +
                      "0', " +
                     EmployeeID + ") ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                string logText = "Excel Row Number - " + i + "----FirstName - " + FirstName + "----lastName - " + LastName + "----HireDate - " + HireDate + "----SSN - " + SSN + "====== Execption -" + ex;
                ErrorLogger.MigrationErrorLog(logText, LogFilePath);
            }
        }

        public void updateProfilePicPath ( string path )
        {
            SqlParameter[] par;
            try
            {
                par = new SqlParameter[2];
                par[0] = new SqlParameter("@employeeId", EmployeeID);
                par[1] = new SqlParameter("@picPath", path);
                DataBaseUtil.ExecuteParDataset("up_UpdateProfilePicPath", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void createEmployeeFolder ()
        {
            DirectoryInfo dir;
            try
            {
                //string sourceLocation = GetJobServer() + "\\Employee" + "\\" + FirstName + "-" + LastName;
                string sourceLocation = "E:\\Amrit_backup\\Amrit\\Dynalectric\\Employee" + "\\" + FirstName + "-" + LastName;
                dir = new DirectoryInfo(@sourceLocation);
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetJobServer ()
        {
            DataSet ds;
            string server = "";
            string query = "SELECT  ServerName as [ServerName] from tblOffice ";
            try
            {
                ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                server = ds.Tables[0].Rows[0]["ServerName"].ToString();
                return server;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void migrateProfilePics ( string picLocation, int rowNumber )
        {
            try
            {
                DateTime hire = DateTime.Parse(HireDate);
                String formattedHireDate = hire.Month + "-" + hire.Day + "-" + hire.ToString("yy");

                string filename = FirstName + " " + LastName + " " + formattedHireDate;
                List<string> lsFiles = searchFile(picLocation, filename);
                if (lsFiles.Count > 1 || lsFiles.Count == 0)
                {
                    string logText = "Excel Row Number - " + rowNumber + "----FirstName - " + FirstName + "----lastName - " + LastName + "----HireDate - " + HireDate + "----SSN - " + SSN;
                    ErrorLogger.PicNotFoundLog(logText, LogFilePath);
                }
                if (lsFiles.Count == 1)
                {
                    // moveProfilePic(picLocation, lsFiles[0], rowNumber, out string destFile);
                    string picPath = System.IO.Path.Combine(picLocation, lsFiles[0]);
                    updateProfilePicPath(picPath);
                }
            }
            catch (Exception)
            {

                //throw ex;
            }
        }

        public static List<string> searchFile ( string location, string filename )
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(location);
            List<string> lsFiles = new List<string>();
            if (directoryInfo.Exists)
            {
                FileInfo[] filesInDir = directoryInfo.GetFiles("*" + filename + "*.*");
                foreach (FileInfo foundFile in filesInDir)
                {
                    lsFiles.Add(foundFile.Name);
                }
            }
            return lsFiles;
        }

        private void moveProfilePic ( string source, string fileName, int rowNumber, out string destFile )
        {
            destFile = string.Empty;
            try
            {
                // string destination = GetJobServer() + "\\Employee" + "\\" + FirstName + "-" + LastName + "\\ProfilePic\\";
               // string destination = "E:\\Amrit_backup\\Amrit\\Dynalectric\\Employee" + "\\" + FirstName + "-" + LastName + "\\ProfilePic\\";
                string sourceFile = System.IO.Path.Combine(source, fileName);
                destFile = System.IO.Path.Combine(DestLocationPic, fileName);
                System.IO.Directory.CreateDirectory(DestLocationPic);
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            catch (Exception)
            {
                string logText = "Excel Row Number - " + rowNumber + "----FirstName - " + FirstName + "----lastName - " + LastName + "----HireDate - " + HireDate + "----SSN - " + SSN;
                ErrorLogger.PicNotFoundLog(logText, LogFilePath);
            }
        }
    }
}
