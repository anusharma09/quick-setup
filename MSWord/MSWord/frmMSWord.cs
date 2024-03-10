using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;


using Microsoft.Office.Interop;
namespace MSWord
{
    public partial class frmMSWord : Form
    {

        public frmMSWord()
        {
            InitializeComponent();
        }

        private void btnProcessDocument_Click(object sender, EventArgs e)
        {
            openFile.FileName = "*.xls";
            openFile.Filter = "Excel Files|*.xls";

            if (openFile.ShowDialog() == DialogResult.OK)
                ProcessExcelFile(@openFile.FileName);
        }


        private void ProcessExcelFile(string fileName)
        {
            Object obj;
            Excel.Application objExcelApp = new Excel.Application();
            Excel.Workbook objBook;
            Excel.Sheets objSheets;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            bool bLoop = false;

            Exception ex;

        
            // Check for the file Name
            if (!File.Exists(fileName))
            {
                ex = new Exception("Labor Rate File was not found");
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
                objSheet = (Excel.Worksheet)objSheets[2];
                bLoop = true;
                while (bLoop)
                {
                    
                    objRange = objSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                    MessageBox.Show(objRange.Text.ToString());
                    if (objRange.Text.ToString().Trim().Length > 0 &&  objRange.Text.ToString().ToUpper().Trim() == "END")
                        bLoop = false;
                    else
                    {
                        if (objRange.Text.ToString().Trim().Length > 0 && objRange.Text.ToString().ToUpper().Trim() != "END"
                            && objRange.Text.ToString().ToUpper().Trim() != "UNION"
                            )
                        {
                            //Classification description
                            objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                            MessageBox.Show(objRange.Text.ToString());
                            //Abbrv
                            //objRange = objSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                            //MessageBox.Show(objRange.Text.ToString());
                            //ST Time
                            //objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                            //MessageBox.Show(objRange.Text.ToString());
                            //OT Time
                            //objRange = objSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                            //MessageBox.Show(objRange.Text.ToString());
                            //DT Time
                            //objRange = objSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                            //MessageBox.Show(objRange.Text.ToString());
                            //Shit
                            //objRange = objSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                            //MessageBox.Show(objRange.Text.ToString());
                            //Union
                            //objRange = objSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                            //MessageBox.Show(objRange.Text.ToString());

                        }
                    }
                    i++;
                  //  if (!bLoop)
                  //  {
                  //  }
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


        public void PrintBill(string fileName)
        {

            Object obj;
            Word.Application objWordApp;
            Word.Document objBill;
            Object objFileName;
            Exception ex;

            obj = System.Reflection.Missing.Value;


            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
            string tempLocation = Environment.CurrentDirectory;
            if (!File.Exists( fileName))
            {
                ex = new Exception("Bill Template file " + fileName + "  not found");
                throw ex;
            }
            if (File.Exists(tempLocation + "\\" + fileName))
                File.Delete(tempLocation + "\\" + fileName);
            try
            {

                File.Copy( fileName,
                    tempLocation + "\\" + fileName,
                    true);
                obj = System.Reflection.Missing.Value;
                objFileName = tempLocation + "\\" + fileName;
                objWordApp = new Microsoft.Office.Interop.Word.Application();

                objBill = objWordApp.Documents.Open(ref objFileName, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);

            }
            catch (Exception ex1)
            {
                objWordApp = new Microsoft.Office.Interop.Word.Application();
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }

            try
            {
                // Print Bill
                object index = "InvoiceNumber";
                Word.Bookmark bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "8110121";

                index = "InvoiceDate";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "11/01/2008";

                index = "JobNumber";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "71009";

                index = "CustomerName";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "LURGI, INC.";

                index = "CustomerAddress";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "1790 KIRBY PARKWAY";

                index = "CustomerCityStateZip";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "MEMPHIS, TN 38138";

                index = "CustomerNumber";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "171623";

                index = "CustomerPONumber";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "3143-71292";

                index = "JobName";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "LURGI PIXLEY ETHANOL";

                index = "LaborAmount";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "$1,000.00";

                index = "MaterialAmount";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "$2,000.00";

                index = "EquipmentAmount";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "$3,000.00";

                index = "OtherAmount";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "$4,000.00";

                index = "TotalAmount";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "$10,000.00";

                objBill.PrintOut(ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj,
                          ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj,
                          ref obj, ref obj, ref obj, ref obj);
                objBill.Close(ref obj, ref obj, ref obj);
                objWordApp.Quit(ref obj, ref obj, ref obj);
            }
            catch (Exception ex1)
            {
                objBill.Close(ref obj, ref obj, ref obj);
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
        }
    }
}