using System;
using System.Data;
using CCEOTProjects.BusinessLayer;
using CCEOTProjects.Controls;
using DevExpress.XtraReports.UI;
namespace CCEOTProjects.Reports
{
    public static class Reports
    {
        public static void OpportunityEstimateJobStatistics(string where)
        {
            rptOpportunityEstimateJobStatistics report = new rptOpportunityEstimateJobStatistics();
            try
            {
                report.DataSource = OTProject.GetOpportunityEstimateJobReport(where).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void EstimateOpportunityHouursTracking(string oppotunityQuery)
        {
            DataTable myTabe = new DataTable();


            rptEstimateOpportunityHoursTracking report = new rptEstimateOpportunityHoursTracking();
            try
            {
                report.DataSource = OTProject.GetEstimateOpportunityHoursTrackingReport(oppotunityQuery).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void EstimateOpportunityTracking(string oppotunityQuery, string estimateQuery)
        {
            DataTable myTabe = new DataTable();


            rptEstimateOpportunityTracking report = new rptEstimateOpportunityTracking();
            try
            {
                report.DataSource = OTProject.GetEstimateOpportunityTrackingReport(oppotunityQuery,estimateQuery).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ProjectOpportunitiesAnalysis(string where)
        {
            rptAdHocProjctOpportunitiesAnalysis report = new rptAdHocProjctOpportunitiesAnalysis();
            try
            {
                report.DataSource = OTProject.GetAnalysisReport(where).Tables[0];
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ProjectDocumentsList(string otProjectNumber, string otProjectName, DataTable documentTable)
        {
            try
            {

                rptProjectDocumentList report = new rptProjectDocumentList();

                if (documentTable == null || documentTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Documents to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = documentTable;
                    report.txtNumber.Text = otProjectNumber;
                    report.txtName.Text = otProjectName;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ProjectWebLinks(string otProjectNumber, string otProjectName, DataTable webLinksTable)
        {
            try
            {

                rptProjectWebLinks report = new rptProjectWebLinks();

                if (webLinksTable == null || webLinksTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Web Links to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = webLinksTable;
                    report.txtNumber.Text = otProjectNumber;
                    report.txtName.Text = otProjectName;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ProjectNotes(string otProjectNumber, string otProjectName, DataTable notesTable,
                                        string sort, string filter)
        {
            try
            {

                rptProjectNotes report = new rptProjectNotes();

                if (notesTable == null || notesTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Notes to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = notesTable;
                    report.txtNumber.Text = otProjectNumber;
                    report.txtName.Text = otProjectName;
                    report.txtFilter.Text = filter;
                    report.txtSort.Text = sort;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ProjectAssignments(string otProjectID, string otProjectNumber, string otProjectName, DataTable assignmentsTable,
                                        string sort, string filter, string sortField, string filterField)
        {
            try
            {

                rptProjectAssignments report = new rptProjectAssignments();

                if (assignmentsTable == null || assignmentsTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Assignments to Print!");
                    throw ex;
                }
                else
                {
                    DataTable table = Assignment.GetAssignmentReport(otProjectID).Tables[0];
                    table.DefaultView.RowFilter = filterField;
                    table.DefaultView.Sort = sortField;
                    report.DataSource = table;
                    report.txtNumber.Text = otProjectNumber;
                    report.txtName.Text = otProjectName;
                    report.txtFilter.Text = filter;
                    report.txtSort.Text = sort;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ProjectAudit(string otProjectNumber, string otProjectName, DataTable auditTable,
                                        string sort, string filter)
        {
            try
            {

                rptProjectAudit report = new rptProjectAudit();

                if (auditTable == null || auditTable.Rows.Count == 0)
                {
                    Exception ex = new Exception("No Audit to Print!");
                    throw ex;
                }
                else
                {
                    report.DataSource = auditTable;
                    report.txtNumber.Text = otProjectNumber;
                    report.txtName.Text = otProjectName;
                    report.txtFilter.Text = filter;
                    report.txtSort.Text = sort;
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void AdHocReport(DataTable table, ProjectListView view,string query, string reportFilter, string reportSort)
        {
            try
            {
                switch (view)
                {
                    case ProjectListView.List:
                        rptAdHocProjctOpportunitiesList report = new rptAdHocProjctOpportunitiesList();
                        report.DataSource = table;
                        report.filter.Text = reportFilter;
                        report.SortOrder.Text = reportSort;
                        report.ShowPreviewDialog();
                        break;
                    case ProjectListView.Department:
                        rptAdHocProjctOpportunitiesListByDepartment report1 = new rptAdHocProjctOpportunitiesListByDepartment();
                        report1.DataSource = table;
                        report1.filter.Text = reportFilter;
                        report1.SortOrder.Text = reportSort;
                        report1.ShowPreviewDialog();
                        break;
                    case ProjectListView.Office:
                        rptAdHocProjctOpportunitiesListByOffice report2 = new rptAdHocProjctOpportunitiesListByOffice();                                
                        report2.DataSource = table;
                        report2.filter.Text = reportFilter;
                        report2.SortOrder.Text = reportSort;
                        report2.ShowPreviewDialog();
                        break;
                    case ProjectListView.ProjectStatus:
                        rptAdHocProjctOpportunitiesListByStatus report3 = new rptAdHocProjctOpportunitiesListByStatus();
                        report3.DataSource = table;
                        report3.filter.Text = reportFilter;
                        report3.SortOrder.Text = reportSort;
                        report3.ShowPreviewDialog();
                        break;
                    case ProjectListView.WorkType:
                        rptAdHocProjctOpportunitiesListByWorkType report4 = new rptAdHocProjctOpportunitiesListByWorkType();
                        report4.DataSource = table;
                        report4.filter.Text = reportFilter;
                        report4.SortOrder.Text = reportSort;
                        report4.ShowPreviewDialog();
                        break;
                  //  case ProjectListView.AssignedTo:
                  //      rptAdHocProjctOpportunitiesListByAssignedTo report5 = new rptAdHocProjctOpportunitiesListByAssignedTo();
                  //      report5.DataSource = table;
                  //      report5.filter.Text = reportFilter;
                  //      report5.SortOrder.Text = reportSort;
                  //      report5.ShowPreviewDialog();
                  //      break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void ProjectSheet(string projectID)
        {
            try
            {
                rptProjectSheet report = new rptProjectSheet();
                report.DataSource = OTProject.GetProjectSheetReport(projectID);
                report.ShowPreviewDialog();  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
