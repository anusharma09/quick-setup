using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JCCBusinessLayer
{
    public class ImportSubmittal
    {
        public void Import(string fileName, string jobID)
        {
            Object obj;
            Excel.Application objExcelApp = new Excel.Application();
            Excel.Workbook objBook;
            Excel.Sheets objSheets;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            bool bLoop = false;
            string spec = "";           
            string description = "";
            string revNo = "";
            string status = "";
            string submittedDate = "";
            string receivedDate = "";
            string Notes = "";
            List<int> rowNumbers = new List<int>();
            Exception ex;
            if (!File.Exists(fileName))
            {
                ex = new Exception("Submittal File was not found");
                throw ex;
            }
            try
            {
                int i = 6;                
                obj = System.Reflection.Missing.Value;
                objBook = objExcelApp.Workbooks.Open(fileName, obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj);
                objSheets = objBook.Sheets;
                objSheet = (Excel.Worksheet)objSheets["Submittal"];
                bLoop = true;
                var specifications = JobSubmittalSpec.GetJobSubmittalSpec(jobID).Tables[0];
                var SubmittalStatuses = JobSubmittalStatus.GetJobSubmittalStatus().Tables[0];
                string expression = string.Empty;
                string specId = string.Empty;
                string submittalStatusId = string.Empty;

                while (bLoop)
                {
                    try
                    {                      
                        objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                        spec = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                        description = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                        revNo = objRange.Text.ToString().Trim(); 

                        objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                        status = objRange.Text.ToString().Trim();

                        if (spec.Length == 0 && description.Length==0 && revNo.Length==0 && status.Length == 0)
                            bLoop = false;
                        else
                        {                                                      
                               
                                if (String.IsNullOrEmpty(spec) || String.IsNullOrEmpty(description) || String.IsNullOrEmpty(revNo) || String.IsNullOrEmpty(status))
                                {
                                    rowNumbers.Add(i);
                                    i++;
                                    continue;
                                }
                             spec = Convert.ToInt32(spec).ToString();
                             revNo = Convert.ToInt32(revNo).ToString();

                                objRange = objSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                                submittedDate =  !String.IsNullOrWhiteSpace(objRange.Text.ToString()) ?  Convert.ToDateTime(objRange.Text).ToString().Trim(): string.Empty;

                                objRange = objSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                                receivedDate = !String.IsNullOrWhiteSpace(objRange.Text.ToString()) ?Convert.ToDateTime(objRange.Text).ToString().Trim() : string.Empty;

                                objRange = objSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                                Notes = objRange.Text.ToString().Trim();


                                expression = "JobSubmittalSpecSection='" + spec.Trim() + "' AND  JobSubmittalSpecDescription='" + description.Trim() + "'";
                                specId = specifications.Select(expression).Length >0 && specifications.Select(expression)[0].ItemArray[0] != null ? specifications.Select(expression)[0].ItemArray[0].ToString() : "";

                                if (String.IsNullOrEmpty(specId))
                                {
                                    var JobSubmittalSpec = new JobSubmittalSpec(
                                                         "0",
                                                         jobID,
                                                         spec,
                                                         description);

                                    JobSubmittalSpec.Save();
                                    specifications = JobSubmittalSpec.GetJobSubmittalSpec(jobID).Tables[0];
                                    specId = specifications.Select(expression)[0].ItemArray[0].ToString();
                                }

                                JobSubmittal submittal = new JobSubmittal("0",
                                            jobID, specId,"");                                                          

                                expression = "JobSubmittalStatusDescription='" + status.Trim() + "'";
                                submittalStatusId = SubmittalStatuses.Select(expression)[0].ItemArray[0].ToString();
                              
                                submittal.Save();
                                var submittalDetail = new JobSubmittalDetail(
                                                         "",
                                                         submittal.JobSubmittalID,
                                                         revNo,
                                                         submittalStatusId,
                                                         submittedDate,
                                                         receivedDate,
                                                         Notes);
                                submittalDetail.Save();                                                     
                        }
                        i++;
                    }
                    catch (Exception e)
                    {
                        rowNumbers.Add(i);
                        i++;
                        continue;
                   
                    }
                }
                
            obj = false;
                objBook.Close(obj, obj, obj);
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            finally
            {
                objExcelApp.Quit();
                objExcelApp = null;
                GC.GetTotalMemory(true);
                if (rowNumbers.Count() > 0)
                {
                    MessageBox.Show("Invalid data entries in the spreadsheet. Check the format of row -" + String.Join(",", rowNumbers) + ".", CCEApplication.ApplicationName);
                }            
            }
        }
    }
}
