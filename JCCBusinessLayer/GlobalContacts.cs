using ContraCostaElectric.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace JCCBusinessLayer
{
    public class GlobalContacts
    {
        public static string ContactId { get; set; }
        private readonly string firstName;
        private readonly string lastName;
        private readonly string middleName;
        private readonly string title;
        private readonly string email;
        private readonly string webSite;
        private readonly string companyName;
        private readonly string categories;
        private readonly string phoneNumber;
        private readonly string cellPhoneNumber;
        private readonly string officeStreetAddress;
        private readonly string officeCity;
        private readonly string officeState;
        private readonly string officeZip;
        private readonly string officeCountry;
        private readonly string officePhoneNumber;
        private readonly string officeFAXPhoneNumber;
        private readonly string extension;
        public int i = 2;

        public GlobalContacts ()
        {

        }

        public GlobalContacts ( string firstName,
            string lastName,
            string middleName,
            string title,
            string email,
            string companyName,
            string categories,
            string phoneNumber,
            string cellPhoneNumber,
            string officeStreetAddress,
            string officeCity,
            string officeState,
            string officeZip,
            string officeCountry,
            string officePhoneNumber,
            string officeFAXPhoneNumber,
            string extension )
        {
            this.firstName = firstName.Trim();
            this.lastName = lastName.Trim();
            this.middleName = middleName.Trim();
            this.title = title.Trim();
            this.email = email.Trim();
            this.companyName = companyName.Trim();
            this.categories = categories.Trim();
            this.phoneNumber = phoneNumber.Trim();
            this.cellPhoneNumber = cellPhoneNumber.Trim();
            this.officeStreetAddress = officeStreetAddress.Trim();
            this.officeCity = officeCity.Trim();
            this.officeState = officeState.Trim();
            this.officeZip = officeZip.Trim();
            this.officeCountry = officeCountry.Trim();
            this.officePhoneNumber = officePhoneNumber.Trim();
            this.officeFAXPhoneNumber = officeFAXPhoneNumber.Trim();
            this.extension = extension.Trim();
        }

        public bool SaveDetail ()
        {
            if (ContactId == "" || ContactId == "0")
            {
                return InsertDetail();
            }
            else
            {
                return UpdateDetail();
            }
        }

        public void Upsert ()
        {
            if (!contactExists(firstName, middleName, lastName))
            {
                InsertDetail();
            }
            else
            {
                UpdateDetail();
            }
        }
        //
        private bool InsertDetail ()
        {
            string query = "";

            query = "INSERT INTO tblGlobalContact(" +
                    " FirstName, " +
                    " LastName, " +
                    " MiddleName, " +
                    " Title, " +
                    " Email, " +
                    " CompanyName, " +
                    " Categories, " +
                    " PhoneNumber, " +
                    " CellPhoneNumber, " +
                    " OfficeStreetAddress, " +
                    " OfficeCity, " +
                    " OfficeState, " +
                    " OfficeZip, " +
                    " OfficeCountry, " +
                    " OfficePhoneNumber, " +
                    " OfficePhoneNumberExtension, " +
                    " OfficeFAXPhoneNumber) Values(" +
                    "'" + firstName + "', " +
                    "'" + lastName + "', " +
                    "'" + middleName + "', " +
                    "'" + title + "', " +
                    "'" + email + "', " +
                    "'" + companyName + "', " +
                    "'" + categories + "', " +
                    "'" + phoneNumber + "', " +
                    "'" + cellPhoneNumber + "', " +
                    "'" + officeStreetAddress + "', " +
                    "'" + officeCity + "', " +
                    "'" + officeState + "', " +
                    "'" + officeZip + "', " +
                    "'" + officeCountry + "', " +
                    "'" + officePhoneNumber + "', " +
                    "'" + extension + "', " +
                    "'" + officeFAXPhoneNumber + "') " +
                    "Select @@IDENTITY ";
            try
            {
                ContactId = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool UpdateDetail ()
        {
            string query = "";
            string fieldUpdated = fieldsUpdated();
            query = "UPDATE tblGlobalContact SET " +
                    " FirstName         = '" + firstName + "', " +
                    " LastName          = '" + lastName + "', " +
                    " MiddleName        = '" + middleName + "', " +
                    " Title             = '" + title + "', " +
                    " Email             = '" + email + "', " +
                    " CompanyName       = '" + companyName + "', " +
                    " Categories        = '" + categories + "', " +
                    " PhoneNumber       = '" + phoneNumber + "', " +
                    " CellPhoneNumber   = '" + cellPhoneNumber + "', " +
                    " OfficeStreetAddress = '" + officeStreetAddress + "', " +
                    " OfficeCity        = '" + officeCity + "', " +
                    " OfficeState       = '" + officeState + "', " +
                    " OfficeZip         = '" + officeZip + "', " +
                    " OfficeCountry     = '" + officeCountry + "', " +
                    " OfficePhoneNumber = '" + officePhoneNumber + "', " +
                    " OfficePhoneNumberExtension = '" + extension + "', " +
                    " OfficeFAXPhoneNumber = '" + officeFAXPhoneNumber + "', " +
                    " UpdatedColumns = '" + fieldUpdated + "' " +
                    " WHERE GlobalContactID = " + ContactId + " ";

            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                if (!string.IsNullOrEmpty(fieldUpdated))
                {
                    updateJobContact();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //

        private string fieldsUpdated ()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                DataSet dsContact = GetGlobalContact(ContactId);
                if (firstName.ToUpper() != dsContact.Tables[0].Rows[0]["FirstName"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("First name");
                    }
                    else
                    {
                        sb.Append(", First name");
                    }
                }
                if (lastName.ToUpper() != dsContact.Tables[0].Rows[0]["LastName"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Last name");
                    }
                    else
                    {
                        sb.Append(", Last name");
                    }
                }
                if (middleName.ToUpper() != dsContact.Tables[0].Rows[0]["MiddleName"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Middle name");
                    }
                    else
                    {
                        sb.Append(", Middle name");
                    }
                }
                if (title.ToUpper() != dsContact.Tables[0].Rows[0]["Title"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Title");
                    }
                    else
                    {
                        sb.Append(", Title");
                    }
                }
                if (email.ToUpper() != dsContact.Tables[0].Rows[0]["Email"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Email");
                    }
                    else
                    {
                        sb.Append(", Email");
                    }
                }
                if (companyName.ToUpper() != dsContact.Tables[0].Rows[0]["CompanyName"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("CompanyName");
                    }
                    else
                    {
                        sb.Append(", CompanyName");
                    }
                }
                if (categories.ToUpper() != dsContact.Tables[0].Rows[0]["Categories"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Categories");
                    }
                    else
                    {
                        sb.Append(", Categories");
                    }
                }
                if (phoneNumber.ToUpper() != dsContact.Tables[0].Rows[0]["PhoneNumber"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Phone Number");
                    }
                    else
                    {
                        sb.Append(", Phone Number");
                    }
                }
                if (cellPhoneNumber.ToUpper() != dsContact.Tables[0].Rows[0]["CellPhoneNumber"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Cell Phone Number");
                    }
                    else
                    {
                        sb.Append(", Cell Phone Number");
                    }
                }
                if (officeStreetAddress.ToUpper() != dsContact.Tables[0].Rows[0]["OfficeStreetAddress"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office Street Address");
                    }
                    else
                    {
                        sb.Append(", Office Street Address");
                    }
                }
                if (officeCity.ToUpper() != dsContact.Tables[0].Rows[0]["OfficeCity"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office City");
                    }
                    else
                    {
                        sb.Append(", Office City");
                    }
                }
                if (officeState.ToUpper() != dsContact.Tables[0].Rows[0]["OfficeState"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office State");
                    }
                    else
                    {
                        sb.Append(", Office State");
                    }
                }
                if (officeZip.ToUpper() != dsContact.Tables[0].Rows[0]["OfficeZIP"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office ZIP");
                    }
                    else
                    {
                        sb.Append(", Office ZIP");
                    }
                }
                if (officeCountry.ToUpper() != dsContact.Tables[0].Rows[0]["OfficeCountry"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office Country");
                    }
                    else
                    {
                        sb.Append(", Office Country");
                    }
                }
                if (officePhoneNumber.ToUpper() != dsContact.Tables[0].Rows[0]["OfficePhoneNumber"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office Phone Number");
                    }
                    else
                    {
                        sb.Append(", Office Phone Number");
                    }
                }
                if (extension.ToUpper() != dsContact.Tables[0].Rows[0]["OfficePhoneNumberExtension"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office PhoneNumber Extension");
                    }
                    else
                    {
                        sb.Append(", Office PhoneNumber Extension");
                    }
                }
                if (officeFAXPhoneNumber.ToUpper() != dsContact.Tables[0].Rows[0]["OfficeFAXPhoneNumber"].ToString().ToUpper())
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append("Office FAX PhoneNumber");
                    }
                    else
                    {
                        sb.Append(", Office FAX PhoneNumber");
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void updateJobContact ()
        {
            string query = "UPDATE tblJobContact SET IsContactUpdated = 1 WHERE CompanyContactID =" + ContactId;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete ( string contactID )
        {
            string query = "";

            query = "Delete FROM tblGlobalContact WHERE GlobalContactID = " + contactID + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception)
            {
                Exception e = new Exception("Contact is used and can't be deleted");
                throw e;
            }
        }

        public static DataSet getContactList ( string where )
        {
            string query = "";

            query = "SELECT GlobalContactID,FirstName, LastName,Title, CompanyName, Email, CellPhoneNumber, OfficePhoneNumber, OfficePhoneNumberExtension AS Extension FROM tblGlobalContact a " +
                    where + " ORDER BY a.GlobalContactID ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetGlobalContact ( string globalContactID )
        {
            string query = "";
            query = "SELECT * FROM tblGlobalContact WHERE GlobalContactID = " + globalContactID + " ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetCompany ()
        {
            string query = "";

            query = "SELECT '--None--' as CompanyName from tblGlobalContact Union SELECT DISTINCT CompanyName FROM tblGlobalContact WHERE CompanyName <> '' ORDER BY CompanyName; ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContactList> Import ( string fileName )
        {
            Object obj;
            Excel.Application objExcelApp = new Excel.Application();
            Excel.Workbook objBook;
            Excel.Sheets objSheets;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            bool bLoop = false;
            // LogFilePath = logPath;
            Exception ex;

            if (!File.Exists(fileName))
            {
                ex = new Exception("Contact File was not found");
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
                List<ContactList> lstContact = new List<ContactList>();
                while (bLoop)
                {
                    ContactList contact = new ContactList();
                    objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                    if (objRange.Text.ToString().Trim().ToUpper() == "END OF FILE")
                    {
                        bLoop = false;
                    }
                    else
                    {
                        objRange = objSheet.get_Range("A" + i.ToString().Trim(), "A" + i.ToString());
                        contact.FirstName = objRange.Text.ToString().Trim().Replace("'","''");

                        objRange = objSheet.get_Range("B" + i.ToString().Trim(), "B" + i.ToString());
                        contact.MiddleName = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("C" + i.ToString().Trim(), "C" + i.ToString());
                        contact.LastName = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("D" + i.ToString().Trim(), "D" + i.ToString());
                        contact.JobTitle = objRange.Text.ToString().Replace("'", "''");

                        objRange = objSheet.get_Range("E" + i.ToString().Trim(), "E" + i.ToString());
                        contact.EmailAddress = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("F" + i.ToString().Trim(), "F" + i.ToString());
                        contact.Company = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("G" + i.ToString().Trim(), "G" + i.ToString());
                        contact.Street = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("H" + i.ToString().Trim(), "H" + i.ToString());
                        contact.City = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("I" + i.ToString().Trim(), "I" + i.ToString());
                        contact.State = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("J" + i.ToString().Trim(), "J" + i.ToString());
                        contact.PostalCode = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("K" + i.ToString().Trim(), "K" + i.ToString());
                        contact.Country = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("L" + i.ToString().Trim(), "L" + i.ToString());
                        contact.MobilePhone = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("M" + i.ToString().Trim(), "M" + i.ToString());
                        contact.BusinessPhone = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("N" + i.ToString().Trim(), "N" + i.ToString());
                        contact.Extension = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("O" + i.ToString().Trim(), "O" + i.ToString());
                        contact.Fax = objRange.Text.ToString().Trim().Replace("'", "''");

                        objRange = objSheet.get_Range("P" + i.ToString().Trim(), "P" + i.ToString());
                        contact.Category = objRange.Text.ToString().Trim().Replace("'", "''");
                        lstContact.Add(contact);
                    }
                    i++;
                }
                obj = false;
                objBook.Close(obj, obj, obj);
                return lstContact;
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

        public static DataTable convertListTodataTable ( List<ContactList> lstContact )
        {
            try
            {
                return GlobalContacts.ToDataTable(lstContact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ToDataTable<T> ( List<T> items )
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                object[] values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static DataTable getDuplicateContacts ( DataTable dtContacts )
        {
            try
            {
                DataTable dtDuplicate = new DataTable();
                if (dtContacts != null)
                {
                    if (dtContacts.AsEnumerable().GroupBy(x => new
                    {
                        FirstName = x.Field<string>("FirstName"),
                        MiddleName = x.Field<string>("MiddleName"),
                        Lastname = x.Field<string>("Lastname")
                    })
                     .Where(gr => gr.Count() > 1).Count() > 0)
                    {
                        dtDuplicate = dtContacts.AsEnumerable().GroupBy(x => new
                        {
                            FirstName = x.Field<string>("FirstName"),
                            MiddleName = x.Field<string>("MiddleName"),
                            Lastname = x.Field<string>("Lastname")
                        })
                         .Where(gr => gr.Count() > 1).SelectMany(dupRec => dupRec).CopyToDataTable();
                    }
                }
                return dtDuplicate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getUniqueContacts ( DataTable dtContacts )
        {
            try
            {
                DataTable dtUnique = new DataTable();
                if (dtContacts != null)
                {
                    dtUnique = dtContacts.AsEnumerable().GroupBy(x => new
                    {
                        FirstName = x.Field<string>("FirstName"),
                        MiddleName = x.Field<string>("MiddleName"),
                        Lastname = x.Field<string>("Lastname")
                    })
                     .Where(gr => gr.Count() == 1).SelectMany(dupRec => dupRec).CopyToDataTable();
                }
                return dtUnique;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getExistingContacts ( DataTable dtContacts )
        {
            try
            {
                DataTable dtExisting = new DataTable();
                dtExisting = dtContacts.Clone();
                foreach (DataRow dataRow in dtContacts.Rows)
                {
                    bool isExists = checkContact(dataRow);
                    if (isExists)
                    {
                        dtExisting.ImportRow(dataRow);
                    }
                }

                return dtExisting;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool checkContact ( DataRow row )
        {
            string query = "";
            bool exists = false;
            query = "SELECT GlobalContactID FROM tblGlobalContact where FirstName= '" + row["FirstName"].ToString() + "' AND MiddleName = '" + row["MiddleName"].ToString() + "' AND LastName= '" + row["LastName"].ToString() + "'";
            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    exists = true;
                }

                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static bool contactExists ( string firstName, string middleName, string lastName )
        {
            string query = "SELECT GlobalContactID FROM tblGlobalContact where FirstName= '" + firstName + "' AND MiddleName = '" + middleName + "' AND LastName= '" + lastName + "'";
            bool exists = false;
            if (!string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName) || !string.IsNullOrEmpty(middleName))
            {
                try
                {
                    DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        exists = true;
                        ContactId = Convert.ToString(ds.Tables[0].Rows[0]["GlobalContactID"]);
                    }
                    return exists;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(middleName))
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    exists = true;
                    ContactId = Convert.ToString(ds.Tables[0].Rows[0]["GlobalContactID"]);
                }
                return exists;
            }
            else
            {
                return false;
            }
        }

        public static DataTable getContactsNotInDatabase ( DataTable dtAll, DataTable dtDuplicate )
        {
            try
            {
                DataTable dtUnique = new DataTable();
                //Merger 2 dataTables
                dtAll.Merge(dtDuplicate);
                //Get contacts that are not duplicate
                if (dtAll != null)
                {
                    IEnumerable<DataRow> varUnique = dtAll.AsEnumerable().GroupBy(x => new
                    {
                        FirstName = x.Field<string>("FirstName"),
                        MiddleName = x.Field<string>("MiddleName"),
                        Lastname = x.Field<string>("Lastname")
                    })
                      .Where(gr => gr.Count() == 1).SelectMany(dupRec => dupRec);
                    if (varUnique.Any())
                    {
                        dtUnique = varUnique.CopyToDataTable();
                    }
                    else
                    {
                        dtUnique = dtAll.Clone();
                    }
                }
                return dtUnique;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class ContactList
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string MobilePhone { get; set; }
        public string BusinessPhone { get; set; }
        public string Extension { get; set; }
        public string Fax { get; set; }
        public string Category { get; set; }
    }

}
