using ContraCostaElectric.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace JCCBusinessLayer
{
    public class Employee
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string middleName;
        private readonly string nickName;
        private readonly string emailAddress;
        private readonly string apprenticeshipCompleted;
        private readonly string apprenticeshipNotes;
        private readonly string employeeStatus;
        private readonly string hireDate;
        private readonly string primaryContact;
        private readonly string dynaAssignedPhone;
        private readonly string employeeNumber;
        private readonly string ssn;
        private readonly string shirtSize;
        private readonly string unionNumber;
        private readonly string classification;
        private readonly string classificationDate;
        private readonly string turnoutDate;
        private readonly string terminationReason;
        private readonly string terminationDate;
        private readonly string profilePic;
        private readonly string generalNotes;
        private readonly string apprenticeshipLocation;
        private readonly string color;

        public static string EmployeeId { get; set; }
        public static string ProfilePicDestinationPath { get; set; }
        public string TargetProfilePicPath { get; set; }
        public static string OldProfilePic { get; set; }
        public static string oldClassification { get; set; }
        public static string oldTermination { get; set; }
        public Employee ( string firstName,
                        string lastName,
                        string middleName,
                        string nickname,
                        string emailAddress,
                        string apprenticeshipCompleted,
                        string apprenticeshipNotes,
                        string employeeStatus,
                        string hireDate,
                        string primaryContact,
                        string dynaAssigned,
                        string employeeNumber,
                        string SSN,
                        string shirtSize,
                        string unionNumber,
                        string classification,
                        string classificationDate,
                        string turnoutDate,
                        string terminationReason,
                        string terminationDate,
                        string profilePic,
                        string generalNotes,
                        string apprenticeshipLocation,
                        string color )
        {
            this.firstName = "'" + firstName.Trim().Replace("'", "''") + "'";
            this.lastName = "'" + lastName.Trim().Replace("'", "''") + "'";
            this.middleName = "'" + middleName.Trim().Replace("'", "''") + "'";
            nickName = "'" + nickname.Trim().Replace("'", "''") + "'";
            this.emailAddress = "'" + emailAddress.Trim().Replace("'", "''") + "'";
            this.apprenticeshipCompleted = apprenticeshipCompleted == "1" ? apprenticeshipCompleted : "0";
            this.apprenticeshipNotes = "'" + apprenticeshipNotes.Trim().Replace("'", "''") + "'";
            this.employeeStatus = employeeStatus == "1" ? employeeStatus : "0";
            this.hireDate = String.IsNullOrEmpty(hireDate) ? "Null" : "'" + hireDate + "'";
            this.primaryContact = "'" + primaryContact.Trim().Replace("'", "''") + "'";
            dynaAssignedPhone = "'" + dynaAssigned.Trim().Replace("'", "''") + "'";
            this.employeeNumber = "'" + employeeNumber.Trim().Replace("'", "''") + "'";
            ssn = "'" + SSN.Trim().Replace("'", "''") + "'";
            this.shirtSize = "'" + shirtSize.Trim().Replace("'", "''") + "'";
            this.unionNumber = "'" + unionNumber.Trim().Replace("'", "''") + "'";
            this.classification = "'" + classification.Trim().Replace("'", "''") + "'";
            this.classificationDate = String.IsNullOrEmpty(classificationDate) ? "Null" : "'" + classificationDate + "'";
            this.turnoutDate = String.IsNullOrEmpty(turnoutDate) ? "Null" : "'" + turnoutDate + "'";
            this.terminationReason = "'" + terminationReason.Trim().Replace("'", "''") + "'";
            this.terminationDate = String.IsNullOrEmpty(terminationDate) ? "Null" : "'" + terminationDate + "'";
            this.profilePic = "" + profilePic.Trim().Replace("'", "''") + "";
            this.generalNotes = "'" + generalNotes.Trim().Replace("'", "''") + "'";
            this.apprenticeshipLocation = "'" + apprenticeshipLocation.Trim().Replace("'", "''") + "'";
            this.color = String.IsNullOrEmpty(color) ? "Null" : "'" + color + "'";
        }

        public bool Save ()
        {
            if (string.IsNullOrEmpty(EmployeeId) || EmployeeId == "0")
            {
                //SaveProfilePicToFolder();
                return Insert();
            }
            else
            {
                //SaveProfilePicToFolder();
                return Update();
            }
        }

        private bool Insert ()
        {
            string query = "";

            query = "INSERT INTO tblDynaEmployee(" +
                    " FirstName, " +
                    " MiddleName, " +
                    " LastName, " +
                    " NickName, " +
                    " EmailAddress, " +
                    " PrimaryContactNumber, " +
                    " DynaAssignedPhone, " +
                    " HireDate, " +
                    " DynaEmployeeNumber, " +
                    " SocialSecurityNumber, " +
                    " UnionMemberNumber, " +
                    " TurnOutDate, " +
                    " ApprenticeshipCompleted, " +
                    " ApprenticeshipLocation, " +
                    " ShirtSize, " +
                    " IsEmployeeActive,Notes,ProfilePic,Color) VALUES (" +
                    firstName + ", " +
                    middleName + ", " +
                    lastName + ", " +
                    nickName + ", " +
                    emailAddress + ", " +
                    primaryContact + ", " +
                    dynaAssignedPhone + ", " +
                    hireDate + ", " +
                    employeeNumber + ", " +
                    ssn + ", " +
                    unionNumber + ", " +
                    turnoutDate + ", " +
                    apprenticeshipCompleted + ", " +
                    apprenticeshipLocation + ", " +
                    shirtSize + ", " +
                    employeeStatus + ", " +
                    generalNotes + ", " +
                    "'" + profilePic + "', " +
                    color + ") " +
                    "Select @@IDENTITY ";
            try
            {
                EmployeeId = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                if (!string.IsNullOrEmpty(EmployeeId))
                {
                    if (classification != "''" && classificationDate != "NULL")
                    {
                        InsertClassification(Convert.ToInt32(EmployeeId));
                    }

                    if (terminationReason != "''" && terminationDate != "NULL")
                    {
                        InsertTermination(Convert.ToInt32(EmployeeId));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Update ()
        {
            string query = "";

            query = "Update tblDynaEmployee SET " +
                    " FirstName                 = " + firstName + ", " +
                    " MiddleName          = " + middleName + ", " +
                    " LastName       = " + lastName + ", " +
                    " NickName      = " + nickName + ", " +
                    " EmailAddress        = " + emailAddress + ", " +
                    " PrimaryContactNumber            = " + primaryContact + ", " +
                    " DynaAssignedPhone             = " + dynaAssignedPhone + ", " +
                    " HireDate               = " + hireDate + ", " +
                    " DynaEmployeeNumber               = " + employeeNumber + ", " +
                    " SocialSecurityNumber      = " + ssn + ", " +
                    " UnionMemberNumber  = " + unionNumber + ", " +
                    " TurnOutDate              = " + turnoutDate + ", " +
                    " ApprenticeshipCompleted  = " + apprenticeshipCompleted + ", " +
                    " ApprenticeshipLocation   = " + apprenticeshipLocation + ", " +
                    " ProfilePic      = '" + profilePic + "', " +
                    " IsEmployeeActive      = " + employeeStatus + ", " +
                    " Notes      = " + generalNotes + ", " +
                    " ShirtSize       = " + shirtSize + ", " +
                    " Color       = " + color + " " +
                    " WHERE EmployeeID  = " + Convert.ToInt32(EmployeeId);
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                if (classification != "''" && classificationDate != "NULL")
                {
                    if (classification != "'" + oldClassification + "'")
                    {
                        string classificationID = InsertClassification(Convert.ToInt32(EmployeeId));
                        if (!string.IsNullOrEmpty(classificationID))
                        {
                            UpdateClassificationActiveStatus(Convert.ToInt32(classificationID));
                            oldClassification = classification.Replace("'", "");
                        }
                    }
                    else
                    {
                        UpdateClassification(Convert.ToInt32(EmployeeId));
                    }
                }
                else
                    UpdateCurrentClassificationStatus(Convert.ToInt32(EmployeeId));

                if (terminationReason != "''" && terminationDate != "NULL")
                {
                    if (terminationReason != "'" + oldTermination + "'")
                    {
                        string terminationID = InsertTermination(Convert.ToInt32(EmployeeId));
                        if (!string.IsNullOrEmpty(terminationID))
                        {
                            UpdateTerminationActiveStatus(Convert.ToInt32(terminationID));
                            oldTermination = terminationReason.Replace("'", "");
                        }
                    }
                    else
                    {
                        UpdateTermination(Convert.ToInt32(EmployeeId));
                    }
                }
                else
                    UpdateCurrentTerminationStatus(Convert.ToInt32(EmployeeId));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Delete ()
        {
            SqlParameter[] par;
            try
            {
                par = new SqlParameter[1];
                par[0] = new SqlParameter("@EmployeeID", Convert.ToInt32(EmployeeId));
                DataBaseUtil.ExecuteParDataset("up_DeleteEmployee", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        private string InsertClassification ( int Id )
        {
            string query = "";
            string id = "";
            query = "INSERT INTO tblEmployeeClassification(" +
                    " Classification, " +
                    " ClassificationDate, " +
                    " EmployeeID, " +
                    " IsCurrentClassification ) VALUES (" +
                    classification + ", " +
                    classificationDate + ", " +
                    Id + ", " +
                    "1) " +
                    "Select @@IDENTITY ";
            try
            {
                id = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }
        private string InsertTermination ( int Id )
        {
            string query = "";
            string id = "";
            query = "INSERT INTO tblEmployeeTermination(" +
                    " Reason, " +
                    " TerminationDate, " +
                    " EmployeeID, " +
                    " IsCurrentTermination ) VALUES (" +
                    terminationReason + ", " +
                    terminationDate + ", " +
                    Id + ", " +
                    "1) " +
                    "Select @@IDENTITY ";
            try
            {
                id = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public string RtfToPlainText ( string rtf )
        {
            try
            {
                System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
                // Convert the RTF to plain text.
                rtBox.Rtf = rtf;
                return rtBox.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        private bool UpdateClassification ( int ID )
        {
            string query = "";

            query = "Update tblEmployeeClassification SET " +
                    " Classification                 = " + classification + ", " +
                    " ClassificationDate       = " + classificationDate + " " +
                    " WHERE EmployeeID  = " + ID + "AND IsCurrentClassification=1";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool UpdateCurrentClassificationStatus ( int ID )
        {
            string query = "";

            query = "Update tblEmployeeClassification SET " +
                    " IsCurrentClassification                 = 0 " +
                    " WHERE EmployeeID  = " + ID + "AND IsCurrentClassification=1";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void UpdateClassificationActiveStatus ( int ID )
        {
            SqlParameter[] par;
            try
            {
                par = new SqlParameter[2];
                par[0] = new SqlParameter("@ClassificationID", ID);
                par[1] = new SqlParameter("@EmployeeID", EmployeeId);
                DataBaseUtil.ExecuteParDataset("up_UpdateClassificationStatus", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateTerminationActiveStatus ( int ID )
        {
            SqlParameter[] par;
            try
            {
                par = new SqlParameter[2];
                par[0] = new SqlParameter("@TerminationID", ID);
                par[1] = new SqlParameter("@EmployeeID", EmployeeId);
                DataBaseUtil.ExecuteParDataset("up_UpdateTerminationStatus", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool UpdateTermination ( int ID )
        {
            string query = "";

            query = "Update tblEmployeeTermination SET " +
                    " Reason                 = " + terminationReason + ", " +
                    " TerminationDate       = " + terminationDate + " " +
                    " WHERE EmployeeID  = " + ID + "AND IsCurrentTermination=1";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool UpdateCurrentTerminationStatus ( int ID )
        {
            string query = "";

            query = "Update tblEmployeeTermination SET " +
                    " IsCurrentTermination                 = 0" +
                    " WHERE EmployeeID  = " + ID + "AND IsCurrentTermination=1";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetEmployeeDetail ( int employeeID )
        {
            SqlParameter[] par;
            DataSet emp = new DataSet();
            try
            {
                par = new SqlParameter[1];
                par[0] = new SqlParameter("@EmployeeID", employeeID);
                emp = DataBaseUtil.ExecuteParDataset("up_GetEmployeeDetail", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }

        public static DataSet GetPastClassification ()
        {
            SqlParameter[] par;
            DataSet ds;
            try
            {
                par = new SqlParameter[1];
                par[0] = new SqlParameter("@EmployeeID", Convert.ToInt32(EmployeeId));
                ds = DataBaseUtil.ExecuteParDataset("up_GetPastClassification", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        

        public static DataSet GetPastTermination ()
        {
            SqlParameter[] par;
            DataSet ds;
            try
            {
                par = new SqlParameter[1];
                par[0] = new SqlParameter("@EmployeeID", Convert.ToInt32(EmployeeId));
                ds = DataBaseUtil.ExecuteParDataset("up_GetPastTermination", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet GetEmployeeTrainingData (string condition)
        {
            string query = "";
            query = "SELECT ROW_NUMBER() OVER(ORDER BY TrainingID) AS num_row,B.DynaEmployeeNumber," +
                    " CASE WHEN MiddleName <> '' THEN FirstName+' '+MiddleName+' '+LastName ELSE FirstName+' '+LastName END  AS EmployeeName,"+
                    " TrainingID,TrainingDescription,TrainingDate,ExpirationDate,HoursOfTraining,AttachmentName,AttachmentPath,'' AS AddAttachment, '' AS Preview FROM tblEmployeeTraining A " +
                    " INNER JOIN tblDynaEmployee B ON A.EmployeeID = B.EmployeeID " +
                    condition + " Order By TrainingID";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetEmployeeEvaluationData ( string employeeID )
        {
            string query = "";
            query = "SELECT " +
                    " EvaluationID,Classification,EvaluationDate,AttachmentName,AttachmentPath,Comments,'' AS AddAttachment, '' AS Preview FROM tblEmployeeEvaluation " +
                    " WHERE EmployeeID = " + employeeID +
                    " Order By EvaluationID";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetEmployeeBadgingData ( string employeeID )
        {
            string query = "";
            query = "SELECT " +
                    " BadgeID,BadgeType,IssueDate,ExpirationDate,AttachmentName,AttachmentPath,Notes,'' AS [AddAttachment], '' AS Preview FROM tblEmployeeBadging " +
                    " WHERE EmployeeID = " + employeeID +
                    " Order By BadgeID";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetEmployeeSafetyNotesData ( string employeeID )
        {
            string query = "";
            query = "SELECT " +
                    " SafetyNoteID,InjuryType,InjuryDate,DoctorNotes,Comments FROM tblEmployeeSafetyNotes " +
                    " WHERE EmployeeID = " + employeeID +
                    " Order By SafetyNoteID";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetEmployeeSafetyNotesAttachments ( string SafetyNoteID )
        {
            string query = "";
            query = "SELECT " +
                    " AttchmentID,AttachmentName,AttachmentPath,'' AS [AddAttachment], '' AS Preview FROM tblEmployeeSafetyNotesAttachments " +
                    " WHERE SafetyNoteID = " + SafetyNoteID +
                    " Order By AttchmentID";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetEmployeeTrainingReport (string id)
        {
            SqlParameter[] par;
            DataSet ds;
            try
            {
                par = new SqlParameter[1];
                par[0] = new SqlParameter("@EmployeeID", Convert.ToInt32(id));
                ds = DataBaseUtil.ExecuteParDataset("up_getUserTrainingsReport", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        private void SaveProfilePicToFolder ()
        {
            DirectoryInfo dir;
            try
            {
                dir = new DirectoryInfo(ProfilePicDestinationPath);
                if (!dir.Exists)
                {
                    Directory.CreateDirectory(ProfilePicDestinationPath);
                }

                string fileName = getfileName();
                List<string> lsFiles = searchFile(ProfilePicDestinationPath, fileName);
                //if(lsFiles.Count>0)
                TargetProfilePicPath = System.IO.Path.Combine(ProfilePicDestinationPath, fileName);
                if (profilePic != TargetProfilePicPath)
                {
                    File.Copy(profilePic, TargetProfilePicPath, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string getfileName ()
        {
            string picName = string.Empty;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(profilePic);
                picName = dir.Name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return picName;
        }

        private List<string> searchFile ( string location, string filename )
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
    }
}
