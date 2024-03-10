
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
namespace JCCBusinessLayer
{
    public class WordDocuments
    {
        public static void PrintSubcontractAgreement ( string jobMajorPOID )
        {
            string fileName = "";
            DataTable table;
            DataRow r;

            string[] dayName = {"","first","second","third","fourth","fifth","sixth","seventh","eighth","ninth","tenth",
        "eleventh","twelfth","thirteenth","fourteenth","fifteenth","sixteenth","seventeenth","eighteenth","nineteenth",
        "twentieth","twenty-first","twenty-second","twenty-third","twenty-fourth","twenty-fifth","twenty-sixth","twenty-seventh",
        "twenty-eighth","twenty-ninth","thirtieth","thirty-first"};
            string[] monthName = {"","January", "February", "March","April","May","June","July","August","September",
                               "October","November","December"};


            Object obj = false;
            Word.Application objWordApp = new Microsoft.Office.Interop.Word.Application();
            objWordApp.Visible = false;
            Word.Document objBill;
            Object objFileName;
            Exception ex;


            table = MajorPO.GetSubcontractAgreement(jobMajorPOID).Tables[0];
            if (table.Rows.Count == 0 || table == null)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }
            r = table.Rows[0];

            fileName = r["JobVendorSubcontract"].ToString();
           // fileName = "SubcontractAgreement.doc"; // added by anu to generate dummy report
            if (String.IsNullOrEmpty(fileName))
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }

            //
            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
            string tempLocation = Environment.CurrentDirectory;
            if (!File.Exists(CCEApplication.ExcelTemplatesLocation + fileName))
            {
                ex = new Exception("Subcontract Agreement file " + fileName + "  not found");
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex;
            }
            if (File.Exists(tempLocation + "\\" + fileName))
            {
                File.Delete(tempLocation + "\\" + fileName);
            }

            try
            {

                File.Copy(CCEApplication.ExcelTemplatesLocation + fileName,
                    tempLocation + "\\" + fileName,
                    true);
                obj = System.Reflection.Missing.Value;
                objFileName = tempLocation + "\\" + fileName;
                // This is for 2003
                // objBill = objWordApp.Documents.Open(ref objFileName, ref obj,
                //             ref obj, ref obj, ref obj, ref obj, ref obj,
                //             ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);

                // This is for 2007
                objBill = objWordApp.Documents.Open(ref objFileName, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);

            }
            catch (Exception ex1)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
            Object index;
            Word.Bookmark bookmark;
            try
            {
                try
                {
                    index = "SubcontractNumber";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["MajorPONumber"].ToString();

                }
                catch { }

                if (r["WIPRequired"].ToString() == "True")
                {
                    try
                    {
                        index = "WIPRequired";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = "X";

                        index = "WIPNotRequired";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = "_";
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        index = "WIPRequired";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = "_";

                        index = "WIPNotRequired";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = "X";
                    }
                    catch { }
                }

                try
                {
                    index = "TextDate";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = dayName[DateTime.Parse(r["PODate"].ToString()).Day].ToString();
                }
                catch { }
                try
                {
                    index = "Month";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = monthName[DateTime.Parse(r["PODate"].ToString()).Month].ToString();
                }
                catch { }


                try
                {
                    index = "Year";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = DateTime.Parse(r["PODate"].ToString()).Year.ToString();
                }
                catch { }

                //
                // Start here for new items
                //

                try
                {
                    index = "JobNumber";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["MajorPONumber"].ToString();
                }
                catch { }


                try
                {
                    index = "Phase";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["Phase"].ToString();
                }
                catch { }


                try
                {
                    index = "CostCode";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["CostCode"].ToString();
                }
                catch { }

                try
                {
                    index = "SubTotal";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["SubTotal"].ToString();
                }
                catch { }

                try
                {
                    index = "SubTotal1";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = string.Format("{0:C}", Convert.ToDecimal(r["SubTotal"]));
                }
                catch { }
                try
                {
                    index = "Subcontractor1";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["Subcontractor"].ToString();
                }
                catch { }
                try
                {
                    index = "Total";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = string.Format("{0:C}", Convert.ToDecimal(r["Total"]));
                }
                catch { }

                try
                {
                    index = "RevisionNumber";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["RevisionNumber"].ToString();
                }
                catch { }

                try
                {
                    index = "MajorPONumber";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["MajorPONumberDetail"].ToString();
                }
                catch { }

                try
                {
                    index = "PODate";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = ((DateTime)r["PODate"]).ToShortDateString();
                }
                catch { }

                try
                {
                    index = "WorkDescriptionDetail";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["WorkDescriptionDetail"].ToString();
                }
                catch { }

                // WorkDescriptionDetail
                // End
                //
                try
                {
                    index = "Subcontractor";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["Subcontractor"].ToString();
                }
                catch { }
                try
                {
                    index = "SubcontractorAddress";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["SubcontractorAddress"].ToString();
                }
                catch { }
                try
                {
                    index = "SubcontractorCityStateZip";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["SubcontractorCityStateZip"].ToString().Trim();// == "," ? "" : r["SubcontractorCityStateZip"].ToString();
                }
                catch { }
                try
                {
                    index = "GeneralContractor";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["ContractorName"].ToString();
                }
                catch { }
                try
                {
                    index = "GeneralContractorAddress";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["ContractorAddress"].ToString();
                }
                catch { }
                try
                {
                    index = "GeneralContractorCityStateZip";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["ContractorCityStateZip"].ToString().Trim();// == "," ? "" : r["ContractorCityStateZip"].ToString().Trim();
                }
                catch { }
                try
                {
                    index = "Owner";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["OwnerName"].ToString();
                }
                catch { }
                try
                {
                    index = "OwnerAddress";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["OwnerAddress"].ToString();
                }
                catch { }
                try
                {
                    index = "OwnerCityStateZip";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["OwnerCityStateZip"].ToString().Trim() == "," ? "" : r["OwnerCityStateZip"].ToString();
                }
                catch { }
                try
                {
                    index = "JobName";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["JobName"].ToString();
                }
                catch { }
                try
                {
                    index = "WorkDescription";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["WorkDescription"].ToString();
                }
                catch { }
                try
                {
                    index = "TextMoney";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["subcontractAmount"].ToString();
                }
                catch { }

                /*
                index = "DollarMoney";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = "$1,000.00"; 
                */
                 try
                 {
                     index = "Subcontract1";
                     bookmark = objBill.Bookmarks.get_Item(ref index);
                     bookmark.Range.Text = r["Subcontractor"].ToString();
                 }
                 catch { }
                 try
                 {
                     index = "Subcontract1Address";
                     bookmark = objBill.Bookmarks.get_Item(ref index);
                     bookmark.Range.Text = r["SubcontractorAddress"].ToString();
                 }
                 catch { }

                 try
                 {
                     index = "Subcontract1CityStateZip";
                     bookmark = objBill.Bookmarks.get_Item(ref index);
                     bookmark.Range.Text = r["SubcontractorCityStateZip"].ToString();
                 }
                 catch { }
                
                try
                {
                    index = "Subcontract1Phone";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["SubcontractorPhone"].ToString();
                }
                catch { }
                try
                {
                    index = "Subcontract1Fax";
                    bookmark = objBill.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["SubcontractorFax"].ToString();
                }
                catch { }
                //If its PSA document
                if (fileName.ToUpper() == "PSA.DOC")
                {
                    try
                    {
                        index = "Foreman";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["Foreman"].ToString());
                    }
                    catch { }
                    try
                    {
                        index = "ForemanPhoneNumber";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = r["ForemanPhoneNumber"].ToString();
                    }
                    catch { }
                    try
                    {
                        index = "PurchaseOrderNumber";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = r["MajorPONumber"].ToString();
                    }
                    catch { }

                    try
                    {
                        index = "ShipName";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = r["ShipTo"].ToString();
                    }
                    catch { }
                    try
                    {
                        index = "ShipAddress";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = r["ShipToAddress"].ToString();
                    }
                    catch { }
                    try
                    {
                        index = "ShipCityStateZip";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = r["CityStateZip"].ToString().Trim() == "," ? "" : r["CityStateZip"].ToString();
                    }
                    catch { }
                    try
                    {
                        index = "VName";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["VendorName"].ToString());
                    }
                    catch { }
                    try
                    {
                        index = "VAddress1";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["Address1"].ToString());
                    }
                    catch { }

                    try
                    {
                        index = "VendorAddress2";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["address2"].ToString());
                    }
                    catch { }
                    try
                    {
                        index = "VendorCityStateZip";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["VendorCityStateZip"].ToString());
                    }
                    catch { }
                    try
                    {
                        index = "RevisionDate";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = string.IsNullOrEmpty(r["RevisionDate"].ToString()) ? "-" : r["RevisionDate"].ToString();
                    }
                    catch { }
                    try
                    {
                        index = "MasterAgreementNumber";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = string.IsNullOrEmpty(r["MasterNumber"].ToString()) ? "__________________" : r["MasterNumber"].ToString();
                    }
                    catch { }
                    try
                    {
                        index = "ProjectManager";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["ProjectManager"].ToString());
                    }
                    catch { }
                    try
                    {
                        index = "BuyerManager";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["ProjectManager"].ToString());
                    }
                    catch { }
                    try
                    {
                        index = "SalesTax";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = string.IsNullOrEmpty(r["SalesTax"].ToString()) ? "0.00" : string.Format("{0:C}", Convert.ToDecimal(r["SalesTax"]));
                    }
                    catch { }
                    try
                    {
                        index = "SubcontractorAmount";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = string.IsNullOrEmpty(r["Total"].ToString()) ? "0.00" : string.Format("{0:C}", Convert.ToDecimal(r["Total"]));
                    }
                    catch { }
                    try
                    {
                        index = "ProjectManagerPhoneNumber";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = Convert.ToString(r["ProjectManagerNumber"]);
                    }
                    catch { }
                    try
                    {

                        #region Create Table
                        Word.Table newTable;

                        index = "TableRevision";
                        obj = System.Reflection.Missing.Value;
                        Word.Range wrdRng = objBill.Bookmarks.get_Item(ref index).Range;
                        newTable = objBill.Tables.Add(wrdRng, 1, 4, ref obj, ref obj);
                        newTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        newTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Borders.Enable = 0;
                        DataSet dsMajorPODetailRevision = MajorPO.GetJobMajorPORevisionDetail(jobMajorPOID);
                        //newTable.AllowAutoFit = true;
                        //Create Header column
                        newTable.Cell(newTable.Rows.Count, 1).Range.Text = "Rev #";
                        newTable.Cell(newTable.Rows.Count, 1).Range.Font.Bold = 0;
                        newTable.Cell(newTable.Rows.Count, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed;

                        newTable.Cell(newTable.Rows.Count, 1).Column.AutoFit();
                        newTable.Cell(newTable.Rows.Count, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        //newTable.Cell(newTable.Rows.Count, 1).Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 1).Range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 1).Range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 1).Range.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        newTable.Cell(newTable.Rows.Count, 2).Range.Text = "Description";
                        newTable.Cell(newTable.Rows.Count, 2).Range.Font.Bold = 0;
                        newTable.Cell(newTable.Rows.Count, 2).Column.SetWidth(280, Word.WdRulerStyle.wdAdjustSameWidth);
                        newTable.Cell(newTable.Rows.Count, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        newTable.Cell(newTable.Rows.Count, 2).Range.Font.Color = Word.WdColor.wdColorDarkRed;
                        //newTable.Cell(newTable.Rows.Count, 2).Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 2).Range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 2).Range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 2).Range.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        newTable.Cell(newTable.Rows.Count, 3).Range.Text = "Rev. Date";
                        newTable.Cell(newTable.Rows.Count, 3).Column.SetWidth(80, Word.WdRulerStyle.wdAdjustSameWidth);
                        newTable.Cell(newTable.Rows.Count, 3).Range.Font.Bold = 0;
                        newTable.Cell(newTable.Rows.Count, 3).Range.Font.Color = Word.WdColor.wdColorDarkRed;
                        //newTable.Cell(newTable.Rows.Count, 3).Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 3).Range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 3).Range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        // newTable.Cell(newTable.Rows.Count, 3).Range.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        newTable.Cell(newTable.Rows.Count, 4).Range.Text = "Amount";
                        newTable.Cell(newTable.Rows.Count, 4).Range.Font.Bold = 0;
                        newTable.Cell(newTable.Rows.Count, 4).Range.Font.Color = Word.WdColor.wdColorDarkRed;
                        newTable.Cell(newTable.Rows.Count, 4).Column.SetWidth(80, Word.WdRulerStyle.wdAdjustSameWidth);
                        //newTable.Cell(newTable.Rows.Count, 4).Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 4).Range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 4).Range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //newTable.Cell(newTable.Rows.Count, 4).Range.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        if (dsMajorPODetailRevision.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in dsMajorPODetailRevision.Tables[0].Rows)
                            {
                                newTable.Rows.Add();
                                newTable.Cell(newTable.Rows.Count, 1).Range.Text = dr["RevisionNumber"].ToString();
                                newTable.Cell(newTable.Rows.Count, 1).Range.Font.Color = Word.WdColor.wdColorBlack;
                                //newTable.Cell(newTable.Rows.Count, 1).Range.Borders.Enable = 0;
                                newTable.Cell(newTable.Rows.Count, 2).Range.Text = dr["WorkDescription"].ToString();
                                newTable.Cell(newTable.Rows.Count, 2).Range.Font.Color = Word.WdColor.wdColorBlack;
                                //newTable.Cell(newTable.Rows.Count, 2).Range.Borders.Enable = 0;
                                DateTime datetime;
                                if (!string.IsNullOrEmpty(dr["RevisionDate"].ToString()))
                                {
                                    datetime = Convert.ToDateTime(dr["RevisionDate"]).Date;
                                    newTable.Cell(newTable.Rows.Count, 3).Range.Text = datetime.ToString("d");
                                }
                                else
                                {
                                    newTable.Cell(newTable.Rows.Count, 3).Range.Text = "";
                                }

                                newTable.Cell(newTable.Rows.Count, 3).Range.Font.Color = Word.WdColor.wdColorBlack;
                                // newTable.Cell(newTable.Rows.Count, 3).Range.Borders.Enable = 0;
                                if (!String.IsNullOrEmpty(dr["Amount"].ToString()))
                                {
                                    newTable.Cell(newTable.Rows.Count, 4).Range.Text = string.Format("{0:C}", Convert.ToDecimal(dr["Amount"]));
                                }
                                else
                                {
                                    newTable.Cell(newTable.Rows.Count, 4).Range.Text = "";
                                }

                                newTable.Cell(newTable.Rows.Count, 4).Range.Font.Color = Word.WdColor.wdColorBlack;
                                // newTable.Cell(newTable.Rows.Count, 4).Range.Borders.Enable = 0;
                            }
                        }
                        #endregion
                    }
                    catch { }

                    try
                    {
                        object index2;
                        if (Convert.ToBoolean(r["JobCertifiedFlag"]))
                        {
                            index = "CertifiedRequired";
                            index2 = "PrevailingWageReq";
                        }
                        else
                        {
                            index = "CertifiedNotRequired";
                            index2 = "PrevailingWageNotReq";
                        }
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        objBill.FormFields[ref index].CheckBox.Value = true;
                        bookmark = objBill.Bookmarks.get_Item(ref index2);
                        objBill.FormFields[ref index2].CheckBox.Value = true;
                    }
                    catch { }
                    try
                    {
                        if (Convert.ToString(r["InsuranceProgram"]).ToUpper() == "CONTRACTOR CONTROLLED" || Convert.ToString(r["InsuranceProgram"]).ToUpper() == "OWNER CONTROLLED")
                        {
                            index = "OCIPReq";
                            bookmark = objBill.Bookmarks.get_Item(ref index);
                            objBill.FormFields[ref index].CheckBox.Value = true;
                        }
                    }
                    catch { }
                    try
                    {
                        index = "AmountInWord";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = string.IsNullOrEmpty(r["Total"].ToString()) || r["Total"].ToString() == "0.00" ? "" : "(" + Convert.ToDouble(r["Total"]).ToWords() + ")";
                    }
                    catch { }
                    try
                    {
                        index = "ContractAmountInWord";
                        bookmark = objBill.Bookmarks.get_Item(ref index);
                        bookmark.Range.Text = string.IsNullOrEmpty(r["Total"].ToString()) || r["Total"].ToString() == "0.00" ? "" : ", " + Convert.ToDouble(r["Total"]).ToWords();
                    }
                    catch { }
                }
                objBill.Application.Visible = true;
            }
            catch (Exception ex1)
            {
                objBill.Close(ref obj, ref obj, ref obj);
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
        }
        
        //
        //
        public static void PrintAttachmentMPO ( string jobMajorPOID )
        {
            string fileName = "";
            DataTable table;
            DataRow r;

            Object obj = false;
            Word.Application objWordApp = new Microsoft.Office.Interop.Word.Application();
            objWordApp.Visible = false;
            Word.Document objBill;
            Object objFileName;
            Exception ex;

            fileName = "AttachmentMPO.doc";
            if (String.IsNullOrEmpty(fileName))
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }
            table = MajorPO.GetAttachmentMPO(jobMajorPOID).Tables[0];
            if (table.Rows.Count == 0 || table == null)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }
            r = table.Rows[0];

            //
            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
            string tempLocation = Environment.CurrentDirectory;
            if (!File.Exists(CCEApplication.ExcelTemplatesLocation + fileName))
            {
                ex = new Exception("Attachment MPO file " + fileName + "  not found");
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex;
            }
            if (File.Exists(tempLocation + "\\" + fileName))
            {
                File.Delete(tempLocation + "\\" + fileName);
            }

            try
            {

                File.Copy(CCEApplication.ExcelTemplatesLocation + fileName,
                    tempLocation + "\\" + fileName,
                    true);
                obj = System.Reflection.Missing.Value;
                objFileName = tempLocation + "\\" + fileName;
                // This is for 2003
                // objBill = objWordApp.Documents.Open(ref objFileName, ref obj,
                //             ref obj, ref obj, ref obj, ref obj, ref obj,
                //             ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);

                // This is for 2007
                objBill = objWordApp.Documents.Open(ref objFileName, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);

            }
            catch (Exception ex1)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
            try
            {
                object index = "PurchaseOrderNumber";
                Word.Bookmark bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = r["MajorPONumber"].ToString();

                index = "JobNumber";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = r["JobNumber"].ToString();

                index = "Vendor";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = r["Vendor"].ToString();

                index = "PODate";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = DateTime.Parse(r["PODate"].ToString()).ToLongDateString();

                index = "ForemanWithPhone";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = r["Foreman"].ToString(); // r["InvoiceNumber"].ToString();

                index = "Vendor1";
                bookmark = objBill.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = r["Vendor"].ToString(); // r["InvoiceNumber"].ToString();

                objBill.Application.Visible = true;


            }
            catch (Exception ex1)
            {
                objBill.Close(ref obj, ref obj, ref obj);
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
        }

        public static void PrintSubAttachmentA ( string jobId )
        {
            string fileName = "";
            DataTable table;
            DataRow r;

            Object obj = false;
            Word.Application objWordApp = new Microsoft.Office.Interop.Word.Application();
            objWordApp.Visible = false;
            Word.Document objdoc;
            Object objFileName;
            Exception ex;

            fileName = "SubAttachmentA.doc";
            if (String.IsNullOrEmpty(fileName))
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }
            table = Job.GetSubAttachmentADetails(jobId).Tables[0];
            if (table.Rows.Count == 0 || table == null)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }
            r = table.Rows[0];

            //
            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
            string tempLocation = Environment.CurrentDirectory;
            if (!File.Exists(CCEApplication.ExcelTemplatesLocation + fileName))
            {
                ex = new Exception("Sub Attachment A file " + fileName + "  not found");
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex;
            }
            if (File.Exists(tempLocation + "\\" + fileName))
                File.Delete(tempLocation + "\\" + fileName);
            try
            {

                File.Copy(CCEApplication.ExcelTemplatesLocation + fileName,
                    tempLocation + "\\" + fileName,
                    true);
                obj = System.Reflection.Missing.Value;
                objFileName = tempLocation + "\\" + fileName;
                // This is for 2007
                objdoc = objWordApp.Documents.Open(ref objFileName, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);

            }
            catch (Exception ex1)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
            try
            {
                object index = "ProjectNumber";
                Word.Bookmark bookmark = objdoc.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = r["JobNumber"].ToString();

                index = "CurrentDate";
                bookmark = objdoc.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = DateTime.Now.ToShortDateString();

                index = "ProjectName";
                bookmark = objdoc.Bookmarks.get_Item(ref index);
                bookmark.Range.Text = r["JobName"].ToString();

                index = "AdditionalInsured12e";
                bookmark = objdoc.Bookmarks.get_Item(ref index);
                string additionalInsured = "";
                string additionalInsuredFull = Convert.ToString(r["AdditionalInsured"]);
                //if (additionalInsuredFull.IndexOf("INC.") > 0)
                // additionalInsured = additionalInsuredFull.Substring(additionalInsuredFull.IndexOf("INC.") + 4, (additionalInsuredFull.Length - (additionalInsuredFull.IndexOf("INC.") + 4))).Trim();
                if (additionalInsuredFull.IndexOf("Dynalectric Company, EMCOR GROUP INC.") == 0)
                {
                    if (additionalInsuredFull.Length > 37)
                        additionalInsured = additionalInsuredFull.Substring(additionalInsuredFull.IndexOf("Dynalectric Company, EMCOR GROUP INC.") + 38, (additionalInsuredFull.Length - (additionalInsuredFull.IndexOf("Dynalectric Company, EMCOR GROUP INC.") + 38))).Trim();
                    else
                        additionalInsured = "";
                }
                else
                    additionalInsured = additionalInsuredFull;
                bookmark.Range.Text = additionalInsured;

                objdoc.Application.Visible = true;
            }
            catch (Exception ex1)
            {
                objdoc.Close(ref obj, ref obj, ref obj);
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
        }

        public static void PrintPrelimInfoReport ( string jobId )
        {
            string fileName = "";
            DataTable table;
            DataRow r;

            Object obj = false;
            Word.Application objWordApp = new Microsoft.Office.Interop.Word.Application();
            objWordApp.Visible = false;
            Word.Document objdoc;
            Object objFileName;
            Exception ex;

            fileName = "PrelimInformation.doc";
            if (String.IsNullOrEmpty(fileName))
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }
            table = Job.GetJobPrelimInfo(jobId).Tables[0];
            if (table.Rows.Count == 0 || table == null)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                return;
            }
            r = table.Rows[0];

            //
            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
            string tempLocation = Environment.CurrentDirectory;
            if (!File.Exists(CCEApplication.ExcelTemplatesLocation + fileName))
            {
                ex = new Exception("Prelim Information " + fileName + "  not found");
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex;
            }
            if (File.Exists(tempLocation + "\\" + fileName))
            {
                File.Delete(tempLocation + "\\" + fileName);
            }

            try
            {

                File.Copy(CCEApplication.ExcelTemplatesLocation + fileName,
                    tempLocation + "\\" + fileName,
                    true);
                obj = System.Reflection.Missing.Value;
                objFileName = tempLocation + "\\" + fileName;
                // This is for 2007
                objdoc = objWordApp.Documents.Open(ref objFileName, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj,
                            ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);

            }
            catch (Exception ex1)
            {
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
            try
            {
                object index;
                Word.Bookmark bookmark;
                try
                {
                    index = "JobName";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["JobName"].ToString();
                }
                catch { }

                try
                {
                    index = "JobNumber";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = r["JobNumber"].ToString();
                }
                catch { }

                try
                {
                    index = "CustomerName";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["ContractorName"].ToString()) ? "" : r["ContractorName"].ToString();
                }
                catch { }

                try
                {
                    index = "CustomerAddress1";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["ContractorAddress1"].ToString()) ? "" : r["ContractorAddress1"].ToString();
                }
                catch { }

                try
                {
                    index = "CustomerAddress2";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["ContractorAddress2"].ToString()) ? "" : r["ContractorAddress2"].ToString();
                }
                catch { }

                try
                {
                    index = "CustomerCityStateZip";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["ContractorCityStateZip"].ToString()) ? "" : r["ContractorCityStateZip"].ToString();
                }
                catch { }

                try
                {
                    index = "OwnerName";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["OwnerName"].ToString()) ? "" : r["OwnerName"].ToString();
                }
                catch { }

                try
                {
                    index = "OwnerAddress1";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["OwnerAddress1"].ToString()) ? "" : r["OwnerAddress1"].ToString();
                }
                catch { }

                try
                {
                    index = "OwnerAddress2";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["OwnerAddress2"].ToString()) ? "" : r["OwnerAddress2"].ToString();
                }
                catch { }

                try
                {
                    index = "OwnerCityStateZip";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["OwnerCityStateZip"].ToString()) ? "" : r["OwnerCityStateZip"].ToString();
                }
                catch { }

                try
                {
                    index = "JobAddress";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["JobAddress1"].ToString()) ? "" : r["JobAddress1"].ToString();
                }
                catch { }

                try
                {
                    index = "JobCityStateZip";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    bookmark.Range.Text = String.IsNullOrEmpty(r["JobCityStateZip"].ToString()) ? "" : r["JobCityStateZip"].ToString();
                }
                catch { }

                try
                {
                    index = "BondingInfo";
                    bookmark = objdoc.Bookmarks.get_Item(ref index);
                    if (Convert.ToString(r["BondingInfoName"]) == "N/A")
                    {
                        bookmark.Range.Text = "N/A";
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("ALLIANT INSURANCE SERVICES, INC.");
                        sb.Append(Environment.NewLine);
                        sb.Append("333 EARLE OVINGTON BOULEVARD, SUITE 700");
                        sb.Append(Environment.NewLine);
                        sb.Append("UNIONDALE, NY 11553");
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);
                        sb.Append("TRAVELERS CASUALTY & SURETY OF AMERICA & FEDERAL INS. CO.");
                        sb.Append(Environment.NewLine);
                        sb.Append("ONE TOWER SQ. (TR)");
                        sb.Append(Environment.NewLine);
                        sb.Append("HARTFORD, CT 06183 (TR) &");
                        sb.Append(Environment.NewLine);
                        sb.Append("15 MOUNTAIN VIEW RD. (FE)");
                        sb.Append(Environment.NewLine);
                        sb.Append("WARREN, NJ 07059 (FE)");
                        bookmark.Range.Text = sb.ToString();
                    }
                }
                catch { }
                objdoc.Application.Visible = true;
            }
            catch (Exception ex1)
            {
                objdoc.Close(ref obj, ref obj, ref obj);
                objWordApp.Quit(ref obj, ref obj, ref obj);
                throw ex1;
            }
        }
    }
}
