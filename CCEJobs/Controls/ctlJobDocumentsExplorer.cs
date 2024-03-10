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
using DevExpress.XtraTreeList.Nodes;


namespace CCEJobs.Controls
{
    public partial class ctlJobDocumentsExplorer : UserControl
    {
        private string jobID = "0";
        private string node;
        private string nodetype;
        bool loadDrives = false;
        //
        public ctlJobDocumentsExplorer()
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
                    loadDrives = false;
                    treeListDocument.DataSource = new object();
                }
            }
        }
        //
        private void treeListDocument_DoubleClick(object sender, EventArgs e)
        {
            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadWrite ||
               Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadWriteCreate ||
               Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.RedWriteCreateSB)
            {
                if (nodetype == "File")
                {
                    try
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();

                        proc.StartInfo.FileName = node;
                        proc.Start();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        //
        private void treeListDocument_VirtualTreeGetChildNodes(object sender, DevExpress.XtraTreeList.VirtualTreeGetChildNodesInfo e)
        {
            if (!loadDrives)
            { // create drives
                //string[] root = Directory.GetLogicalDrives();


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

                DataTable jobInfo = new DataTable();

                try
                {
                    string id;
                    if (jobID == "")
                        id = "0";
                    else
                        id = jobID;

                    jobInfo = Job.GetJobDocumentInfo(jobID).Tables[0];
                    if (jobInfo.Rows.Count == 0)
                    {
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
                    estimateServer = JCCBusinessLayer.Utilities.GetEstimatorServer(estimatorID);
                    jobServer = JCCBusinessLayer.Utilities.GetJobServer(officeID);
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
                    // string [] root = { estimateLocation, jobLocation, estimateLocationArchive };

                    string [] root = new string[3];
                    if (estimateLocation.Length > 10)
                        root[0] = estimateLocation;  
                    if (jobLocation.Length > 10)
                        root[1] = jobLocation;  
                    if (estimateLocationArchive.Length > 10)
                        root[2] = estimateLocationArchive;
                    
                    
                    e.Children = root;
                    loadDrives = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }

            }
            else
            {
                try
                {
                    string path = (string)e.Node;
                    if (Directory.Exists(path))
                    {
                        string[] dirs = Directory.GetDirectories(path);
                        string[] files = Directory.GetFiles(path);
                        string[] arr = new string[dirs.Length + files.Length];
                        dirs.CopyTo(arr, 0);
                        files.CopyTo(arr, dirs.Length);
                        e.Children = arr;
                    }
                    else e.Children = new object[] { };
                }
                catch { e.Children = new object[] { }; }
            }

        }
        //
        private void treeListDocument_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            nodetype = e.Node.GetDisplayText(treeListColumn2);
            node = e.Node.GetDisplayText(treeListColumn4);
        }
        //
        private void treeListDocument_VirtualTreeGetCellValue(object sender, DevExpress.XtraTreeList.VirtualTreeGetCellValueInfo e)
        {
            DirectoryInfo di = new DirectoryInfo((string)e.Node);
            if (e.Column == treeListColumn4)
                e.CellData = di.FullName;
            if (e.Column == treeListColumn1)
            {
                if (!IsFile(di))
                    e.CellData = di.FullName;
                else
                    e.CellData = di.Name;
            }
            if (e.Column == treeListColumn2)
            {
                if (!IsFile(di))
                    e.CellData = "Folder";
                else
                    e.CellData = "File";
            }
            if (e.Column == treeListColumn3)
            {
                if (IsFile(di))
                {
                    e.CellData = new FileInfo((string)e.Node).Length;
                }
                else e.CellData = null;
            }
        }
        //
        bool IsFile(DirectoryInfo info)
        {
            return (info.Attributes & FileAttributes.Directory) == 0;
        }
        //
    }
}
