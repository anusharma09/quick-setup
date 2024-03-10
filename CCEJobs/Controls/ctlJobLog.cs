using System;
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
    public partial class ctlJobLog : UserControl
    {
        DataTable jobLogTable = new DataTable();
        private string jobID;
        private string filter = "";
        //
        public ctlJobLog()
        {
            InitializeComponent();
        }
        //
        public string JobID
        {
           
            set
            {
                if (jobID != value)
                {
                    jobID = value;
                    GetJobLog();
                }
            }
        }
        //
        public DataTable JobLogTable
        {
            get { return jobLogTable; }
        }
        //
        public string Filter
        {
            get { return filter; }
        }
        //
        private void GetJobLog()
        {
            string id;
            if (jobID == "" )   
                id = "0";
            else
                id = jobID;
            try
            {
                jobLogTable = Security.BusinessLayer.JobLog.GetJobLog(jobID).Tables[0];
                grdJobLog.DataSource = jobLogTable;
                grdJobLogView.BestFitColumns();
                grdJobLogView.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdJobLogView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                filter = grdJobLogView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobLogView.Columns)
                {
                    if (col.FilterInfo.FilterCriteria != null)
                    {
                        if (col.FilterInfo.FilterCriteria.ToString().Length > 0)
                        {
                            criteria += col.FilterInfo.FilterCriteria.ToString();
                            criteria += " AND ";
                        }
                    }
                }
                if (criteria.Length > 0)
                    criteria = criteria.Substring(0, criteria.Length - 4);
                jobLogTable.DefaultView.RowFilter = criteria;

            }
            catch (Exception ex)
            {
            }
        }
    }
}
