using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace JCCLightFixture.BusinessLayer
{
    class ImportLightFixture
    {
        private string jobID;
        public void Import ( string fileName, string jobID )
        {
            Object obj;
            Excel.Application objExcelApp = new Excel.Application();
            Excel.Workbook objBook;
            Excel.Sheets objSheets;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            bool bLoop = false;
            string type = "";
            string quantity = "";
            string lenght = "";
            string MFGR = "";
            string description = "";
            string unitPrice = "";
            string extension = "";

            this.jobID = jobID;
            Exception ex;
            if (!File.Exists(fileName))
            {
                ex = new Exception("Light Fixture File was not found");
                throw ex;
            }
            try
            {
                JobLightFixture light;
                decimal temp = 0;

                int i = 11;
                obj = System.Reflection.Missing.Value;
                objBook = objExcelApp.Workbooks.Open(fileName, obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj, obj,
                                                                obj, obj);

                objSheets = objBook.Sheets;
                objSheet = (Excel.Worksheet)objSheets["LightFixture"];
                bLoop = true;
                while (bLoop)
                {

                    objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    if (objRange.Text.ToString().Trim().Length > 0 && objRange.Text.ToString().ToUpper().Trim() == "GRAND TOTAL")
                        bLoop = false;
                    else
                    {
                        objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                        type = objRange.Text.ToString().ToUpper().Trim();

                        if (type.Trim().Length > 0)
                        {
                            if (type.Trim().Length > 10)
                                type = type.Substring(0, 10);

                            objRange = objSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                            quantity = objRange.Text.ToString().ToUpper().Trim().Replace(",", "");

                            objRange = objSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                            lenght = objRange.Text.ToString().ToUpper().Trim().Replace(",", "");

                            objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                            MFGR = objRange.Text.ToString();

                            //Sprint-9-Dyn-158: As per Dyna team they require n number of characters to get saved.
                            /* if (MFGR.Trim().Length > 10)
                                 MFGR = MFGR.Substring(0, 10);*/

                            objRange = objSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                            description = objRange.Text.ToString().ToUpper().Trim();

                            //Sprint-9-Dyn-158: As per Dyna team they require n number of characters to get saved.
                            /*
                            if (description.Trim().Length > 35)
                                description = description.Substring(0, 35);
                                */

                            temp = 0;
                            decimal.TryParse(quantity, out temp);
                            quantity = temp.ToString();

                            temp = 0;
                            decimal.TryParse(lenght, out temp);
                            lenght = temp.ToString();


                            objRange = objSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                            unitPrice = objRange.Text.ToString().ToUpper().Trim().Replace(",", "").Replace("$", "");

                            temp = 0;
                            decimal.TryParse(unitPrice, out temp);
                            unitPrice = temp.ToString();

                            objRange = objSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                            extension = objRange.Text.ToString().ToUpper().Trim().Replace(",", "").Replace("$", "");

                            temp = 0;
                            decimal.TryParse(extension, out temp);
                            extension = temp.ToString();

                            light = new JobLightFixture("",
                                        jobID,
                                        type,
                                        "",
                                        quantity,
                                        "",
                                        lenght,
                                        "",
                                        MFGR,
                                        description, "", unitPrice, extension, "", quantity, lenght);
                            light.Save();
                        }
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
