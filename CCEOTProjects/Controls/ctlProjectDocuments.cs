using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CCEOTProjects.BusinessLayer;



namespace CCEOTProjects.Controls
{
    public partial class ctlProjectDocuments : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable documentTable; 
        DataRow documentRow;
        private string otProjectID = "0";
        private int totalNumber = 0;
        //
        public ctlProjectDocuments()
        {
            InitializeComponent();

        }
        //
        public string OTProjectID
        {
            set
            {
                //if (otProjectID != value)
                {
                    otProjectID = value;
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
            string projectServer;
            string projectLocation;

            if (otProjectID == "" )   
                id = "0";
            else
                id = otProjectID;
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

                DataTable projectInfo = new DataTable();

                string otProjectNumber = "";
                string otProjectName = "";
                //
                projectInfo = OTProject.GetProjectInfo(otProjectID).Tables[0];
                if (projectInfo.Rows.Count == 0)
                {
                    UpdateGrid();
                    return;
                }
                otProjectNumber     = projectInfo.Rows[0]["OTProjectNumber"].ToString();
                otProjectName       = projectInfo.Rows[0]["OTProjectName"].ToString();
                projectServer       = OTProject.GetServerName(); 
                projectLocation = CCEApplication.ProjectOpportunityLocation + 
                                    otProjectNumber + " " + otProjectName + "";
                //
                GetDocumentsList(projectLocation);
                UpdateGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateGrid()
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdDocumentView, "ctlProjectDocuments");
            }

            grdDocument.DataSource = documentTable;
            grdDocumentView.Columns["Size"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdDocumentView.Columns["Size"].DisplayFormat.FormatString = "{0:n0}";
            grdDocumentView.BestFitColumns();
            grdDocumentView.Columns["Folder"].Group();
            grdDocumentView.Columns[1].Visible = false;
            grdDocumentView.Columns["Type"].Visible = false;
            grdDocumentView.Columns["Completed"].Visible = false;
            Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdDocumentView, "ctlProjectDocuments");

        }
        //
        private void GetDocumentsList(string location)
        {
            
            DirectoryInfo dir = new DirectoryInfo(@location);
            if (dir.Exists)
            {
                bool completed = false;
                int folders = 1;
                int i = 0;

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

        private void grdDocumentView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
