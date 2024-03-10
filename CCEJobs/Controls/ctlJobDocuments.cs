using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;


namespace CCEJobs.Controls
{
    public partial class ctlJobDocuments : UserControl
    {
        DataTable documentTable; 
        DataRow documentRow;
        private string jobID = "0";
        private int totalNumber = 0;
        //
        public ctlJobDocuments()
        {
            InitializeComponent();

        }
        //
        public string JobID
        {
            set
            {
                //if (jobID != value)
                {
                    jobID = value;
                    GetDocuments();
                }
            }
        }
        public DataTable DocumentTable
        {
            get { return documentTable; }
        }

 
        //
        private void GetDocuments()
        {
            string id;
            if (jobID == "" )   
                id = "0";
            else
                id = jobID;
            try
            {
                
                documentTable = new DataTable("DocumentTable");
                documentTable.Columns.Add("Folder", typeof(string));
                documentTable.Columns.Add("Full Name", typeof(string));
                documentTable.Columns.Add("File Name", typeof(string));
                documentTable.Columns.Add("Size", typeof(string));
                documentTable.Columns.Add("Last Read", typeof(string));
                documentTable.Columns.Add("Last Write", typeof(string));
                documentTable.Columns.Add("Type", typeof(string));
                documentTable.Columns.Add("Completed", typeof(string));

                DataTable jobInfo = new DataTable();

                string estimatorID = "";
                string estimateServer = "";
                string officeID = "";
                string jobServer = "";
                string estimateLocation = "";
                string estimateLocationArchive = "";
                string jobLocation = "";
                string jobLocationArchive = "";
                string jobCreatedDate = "";
                string jobCreatedDateA = "";
                string departmentName = "";
                string officeName = "";
                string estimateNumber = "";
                string jobNumber = "";
                string jobName = "";
                //
                jobInfo = Job.GetJobDocumentInfo(jobID).Tables[0];
                if (jobInfo.Rows.Count == 0)
                {
                    UpdateGrid();
                    return;
                }
                estimatorID = jobInfo.Rows[0]["EstimatorID"].ToString();
                officeID = jobInfo.Rows[0]["OfficeID"].ToString();
                officeName = jobInfo.Rows[0]["OfficeName"].ToString();
                departmentName = jobInfo.Rows[0]["DepartmentName"].ToString();
                jobCreatedDate = jobInfo.Rows[0]["CreatedDate"].ToString();
                jobCreatedDateA = jobInfo.Rows[0]["JobCreatedDate"].ToString();
                estimateNumber = jobInfo.Rows[0]["EstimateNumber"].ToString();
                jobNumber = jobInfo.Rows[0]["JobNumber"].ToString();
                jobName = jobInfo.Rows[0]["JobName"].ToString();
                //
                estimateServer  = JCCBusinessLayer.Utilities.GetEstimatorServer(estimatorID);
                jobServer       = JCCBusinessLayer.Utilities.GetJobServer(officeID);
                //
                if (jobCreatedDate.Trim().Length > 0)
                {
                    estimateLocation = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Active\\" +
                                            officeName + "\\" +
                                            Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                                            estimateNumber + " " + jobName.Trim() + "";
                    estimateLocationArchive = estimateServer + "\\" + CCEApplication.EstimatesLocation + "Archive\\" +
                                           officeName + "\\" +
                                           Convert.ToString(Convert.ToDateTime(jobCreatedDate).Year).Trim() + "\\" +
                                           estimateNumber + " " + jobName.Trim() + "";
                }
                if (jobCreatedDateA.Trim().Length > 0)
                {
                    jobLocation = jobServer + "\\" + CCEApplication.JobsLocation + departmentName + "\\" + "Active\\" +
                                        Convert.ToString(Convert.ToDateTime(jobCreatedDateA).Year).Trim() + "\\" +
                                        jobNumber + " " + estimateNumber + " " + jobName + "";
                    jobLocationArchive = jobServer + "\\" + CCEApplication.JobsLocation + departmentName + "\\" + "Archive\\" +
                    Convert.ToString(Convert.ToDateTime(jobCreatedDateA).Year).Trim() + "\\" +
                    jobNumber + " " + estimateNumber + " " + jobName.Trim() + "";
                }
                //
                // Get Documnets
                //
                if (jobCreatedDate.Trim().Length > 0)
                    GetDocumentsList(estimateLocation);
                if (jobCreatedDateA.Trim().Length > 0)
                    GetDocumentsList(jobLocation);
                if (jobCreatedDate.Trim().Length > 0)
                    GetDocumentsList(estimateLocationArchive);
                if (jobCreatedDateA.Trim().Length > 0)
                    GetDocumentsList(jobLocationArchive);
                UpdateGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        private void UpdateGrid()
        {
            grdDocument.DataSource = documentTable;
            grdDocumentView.Columns["Size"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdDocumentView.Columns["Size"].DisplayFormat.FormatString = "{0:n0}";
            grdDocumentView.BestFitColumns();
            grdDocumentView.Columns["Folder"].Group();
            grdDocumentView.Columns[1].Visible = false;
            grdDocumentView.Columns["Type"].Visible = false;
            grdDocumentView.Columns["Completed"].Visible = false;

            

        }
        private void GetDocumentsList(string location)
        {
            
            DirectoryInfo dir = new DirectoryInfo(@location);
            if (dir.Exists)
            {
                bool completed = false;
                int folders = 1;
                int i = 0;
                //
               /* documentRow = documentTable.NewRow();
                documentRow[0] = dir.FullName;
                documentRow[1] = dir.FullName;            
                documentRow[2] = "....";
                documentRow[4] = "";
                documentRow[5] = "";
                documentRow["Type"] = "D";
                documentRow["Completed"] = "Y";
                documentTable.Rows.Add(documentRow);*/


                documentRow = documentTable.NewRow();
                documentRow[0] = dir.FullName.Trim();
                documentRow[1] = dir.FullName.Trim();
                documentRow[2] = "....";
                documentRow[4] = "";
                documentRow[5] = "";
                documentRow["Type"] = "D";
                documentRow["Completed"] = "N";
                documentTable.Rows.Add(documentRow); 
                //
                while (!completed )
                {
                    try
                    {
                        completed = true;
                        foreach (DataRow r in documentTable.Rows)
                        {
                            if (r["Type"].ToString() == "D" && r["Completed"].ToString() == "N")
                            {
                                DirectoryInfo dir1 = new DirectoryInfo(@r["Folder"].ToString());
                                foreach (FileInfo f in dir1.GetFiles())
                                {
                                    documentRow = documentTable.NewRow();
                                    try
                                    { 
                                        documentRow[0] = f.DirectoryName.Trim();
                                        documentRow[1] = f.FullName;            // Not Visible
                                        documentRow[2] = f.Name;
                                        documentRow[3] = f.Length;
                                        documentRow[4] = f.LastAccessTime;
                                        documentRow[5] = f.LastWriteTime;
                                        documentRow["Type"] = "F";
                                        documentTable.Rows.Add(documentRow);
                                        totalNumber += 1;
                                    }
                                    catch 
                                    {
                                       // documentTable.Rows.Remove(documentRow);
                                    }
                                }
                                i = i - 1;
                                foreach (DirectoryInfo f in dir1.GetDirectories())
                                {
                                    documentRow = documentTable.NewRow();
                                    try
                                    {
                                        documentRow[0] = f.FullName.Trim();
                                        documentRow[1] = f.FullName.Trim();            // Not Visible
                                        documentRow[2] = "....";
                                        documentRow[4] = "";
                                        documentRow[5] = "";
                                        documentRow["Type"] = "D";
                                        documentRow["Completed"] = "N";
                                        documentTable.Rows.Add(documentRow);
                                        i = i + 1;
                                        completed = false;
                                        totalNumber += 1;
                                    }
                                    catch 
                                    {
                                       // documentTable.Rows.Remove(documentRow);
                                    }
                                }
                                r["Completed"] = "Y";
                                r.AcceptChanges();
                                totalNumber += 1;

                            }
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        completed = false;
                    }
                }
            }
        }
        //
        private void grdEstimateDocumentView_DoubleClick(object sender, EventArgs e)
        {
            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadWrite ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadWriteCreate ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.RedWriteCreateSB)
            {
                try
                {
                    DataRow r;

                    if (grdDocumentView.SelectedRowsCount > 0)
                    {
                        r = grdDocumentView.GetDataRow(grdDocumentView.GetSelectedRows()[0]);
                        if (r != null)
                        {
                            if (r["Full Name"].ToString().Length > 0 && r["Type"].ToString() != "D")
                            {
                                System.Diagnostics.Process proc = new System.Diagnostics.Process();

                                proc.StartInfo.FileName = r["Full Name"].ToString();
                                proc.Start();
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        //
    
    }
}
