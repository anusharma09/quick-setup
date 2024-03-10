using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Security.BusinessLayer
{
    public class ImportMasterAgreement
    {
        public void Import ( string fileName )
        {
            Object obj;
            Excel.Application objExcelApp = new Excel.Application();
            Excel.Workbook objBook;
            Excel.Sheets objSheets;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            bool bLoop = false;
            string company = "";
            string masterNumber = "";
            string contractDate = "";
            string signedDate = "";
            List<int> rowNumbers = new List<int>();
            Exception ex;
            if (!File.Exists(fileName))
            {
                ex = new Exception("Master Agreement File was not found");
                throw ex;
            }
            try
            {
                int i = 5;
                obj = System.Reflection.Missing.Value;
                objBook = objExcelApp.Workbooks.Open(fileName, obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj);
                objSheets = objBook.Sheets;
                objSheet = (Excel.Worksheet)objSheets["Dyna Master Agreements"];
                bLoop = true;
                string expression = string.Empty;
                string specId = string.Empty;
                string submittalStatusId = string.Empty;

                while (bLoop)
                {
                    try
                    {
                        objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                        company = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                        masterNumber = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                        contractDate = objRange.Text.ToString().Trim();

                        objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                        signedDate = objRange.Text.ToString().Trim();

                        if (company.Length == 0 && masterNumber.Length == 0 && contractDate.Length == 0 && signedDate.Length == 0)
                        {
                            bLoop = false;
                        }
                        else
                        {

                            if (String.IsNullOrEmpty(company) || String.IsNullOrEmpty(masterNumber))
                            {
                                rowNumbers.Add(i);
                                i++;
                                continue;
                            }
                            MasterAgreement masterAgreement = new MasterAgreement(
                                                     "0",
                                                     company,
                                                     masterNumber,
                                                     contractDate,
                                                     signedDate);

                            masterAgreement.Save();
                        }
                        i++;
                    }
                    catch (Exception)
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
                MessageBox.Show("File format is incorrect.", "Master Agreement Number");
            }
            finally
            {
                objExcelApp.Quit();
                objExcelApp = null;
                GC.GetTotalMemory(true);
                if (rowNumbers.Count() > 0)
                {
                    MessageBox.Show("Invalid data entries in the spreadsheet. Check the format of row -" + String.Join(",", rowNumbers) + ".", "Master Agreement Number");
                }                   
            }
        }
    }
}
