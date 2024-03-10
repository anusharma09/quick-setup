using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace JCCSwitchgear.BusinessLayer
{
    class ImportSwitchgear
    {
        private string jobID;
        public void Import(string fileName, string jobID)
        {
            Object obj;
            Excel.Application objExcelApp = new Excel.Application();
            Excel.Workbook objBook;
            Excel.Sheets objSheets;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            bool bLoop = false;
            string pageNumber = "";
            string itemNumber = "";
            string designation = "";
            string description = "";
            string quantity = "";
            string unitPrice = "";
            string extension = "";

            this.jobID = jobID;
            Exception ex;
            if (!File.Exists(fileName))
            {
                ex = new Exception("Switchgear File was not found");
                throw ex;
            }
            try
            {
                Switchgear switchgear;
                decimal temp = 0; 

                int i = 12;
                obj = System.Reflection.Missing.Value;
                objBook = objExcelApp.Workbooks.Open(fileName, obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj);

                objSheets = objBook.Sheets;
                objSheet = (Excel.Worksheet)objSheets["Switchgear"];
                bLoop = true;
                while (bLoop)
                {

                    objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                    if (objRange.Text.ToString().Trim().Length > 0 && objRange.Text.ToString().ToUpper().Trim() == "TOTALS")
                        bLoop = false;
                    else
                    {
                            objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                            pageNumber = objRange.Text.ToString().ToUpper().Trim();
                            if (pageNumber.Trim().Length > 5)
                                pageNumber = pageNumber.Substring(0, 5);
                            objRange = objSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                            itemNumber = objRange.Text.ToString();
                            if (itemNumber.Trim().Length > 5)
                                itemNumber = itemNumber.Substring(0, 5);

                            objRange = objSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                            designation = objRange.Text.ToString().ToUpper().Trim();
                            if (designation.Trim().Length > 35)
                                designation = designation.Substring(0, 35);

                            objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                            description = objRange.Text.ToString().ToUpper().Trim();
                            if (description.Trim().Length > 35)
                                description = description.Substring(0, 35);

                            objRange = objSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                            quantity = objRange.Text.ToString().ToUpper().Trim().Replace(",","");

                            temp = 0;
                            decimal.TryParse(quantity, out temp);
                            quantity = temp.ToString();
                            
                            objRange = objSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                            unitPrice = objRange.Text.ToString().ToUpper().Trim().Replace(",","").Replace("$","");

                            temp = 0;
                            decimal.TryParse(unitPrice, out temp);
                            unitPrice = temp.ToString();

                            objRange = objSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                            extension = objRange.Text.ToString().ToUpper().Trim().Replace(",", "").Replace("$", "");

                            temp = 0;
                            decimal.TryParse(extension, out temp);
                            extension = temp.ToString();
                        
                            switchgear = new Switchgear("",
                                        jobID,
                                        pageNumber,
                                        itemNumber,
                                        designation,
                                        description,
                                        quantity,
                                        unitPrice,
                                        extension,
                                        extension,
                                        "",
                                        "",quantity);
                                        
                                        
                            switchgear.Save(); 
                        }
                    
                    i++;
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
            }
        }
    }
}
