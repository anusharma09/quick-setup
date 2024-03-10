using System;
using System.Collections.Generic;
using System.Text;
using ContraCostaElectric.DatabaseUtil;
using System.Data;

namespace JCCDailyLog.BusinessLayer
{
    class DailyLog
    {
        private string jobDailyLogID;
        private string jobID;
        private string logDate;
        private string weatherCondition;
        private string numberOfElectricians;
        private string rental1;
        private string rental2;
        private string rental3;
        private string inspectionToday;
        private string inspectionTodayDescription;
        private string progressPicturesTaken;
        private string progressPicturesTakenDescription;
        private string accidentOnJob;
        private string accidentOnJobDescription;
        private string accidentReportFiled;
        private string safetyMeetingToday;
        private string safetyMeetingTodayDescription;
        private string extraWorkRequested;
        private string extraWorkRequestedDescription;
        private string backChargeRequired;
        private string backChargeRequiredDescription;
        private string scheduledWorkDelayed;
        private string scheduledWorkDelayedDescription;
        private string delayedCausedByOthers;
        private string delayedCausedByOthersDescription;
        private string disruptionReportFiled;
        private string disruptionReportFiledDescription;
        private string productiveNarrative;
        //
        public DailyLog()
        {
        }
        //
        public DailyLog(string jobDailyLogID,
                        string jobID,
                        string logDate,
                        string weatherCondition,
                        string numberOfElectricians,
                        string rental1,
                        string rental2,
                        string rental3,
                        string inspectionToday,
                        string inspectionTodayDescription,
                        string progressPicturesTaken,
                        string progressPicturesTakenDescription,
                        string accidentOnJob,
                        string accidentOnJobDescription,
                        string accidentReportFiled,
                        string safetyMeetingToday,
                        string safetyMeetingTodayDescription,
                        string extraWorkRequested,
                        string extraWorkRequestedDescription,
                        string backChargeRequired,
                        string backChargeRequiredDescription,
                        string scheduledWorkDelayed,
                        string scheduledWorkDelayedDescription,
                        string delayedCausedByOthers,
                        string delayedCausedByOthersDescription,
                        string disruptionReportFiled,
                        string disruptionReportFiledDescription,
                        string productiveNarrative)
        {
            this.jobDailyLogID                          = jobDailyLogID;
            this.jobID                                  = jobID;
            this.logDate                                = String.IsNullOrEmpty(logDate) ? "null" : "'" + logDate + "'";
            this.weatherCondition                       = "'" + weatherCondition.Trim().Replace("'","''") + "'";
            this.numberOfElectricians                   = String.IsNullOrEmpty(numberOfElectricians) ? "null" : numberOfElectricians;
            this.rental1                                = "'" + rental1.Trim().Replace("'","''") + "'";
            this.rental2                                = "'" + rental2.Trim().Replace("'","''") + "'";
            this.rental3                                = "'" + rental3.Trim().Replace("'","''") + "'";
            this.inspectionToday                        = inspectionToday == "True" ? "1" : "0";
            this.inspectionTodayDescription             = "'" + inspectionTodayDescription.Trim().Replace("'","''") + "'";
            this.progressPicturesTaken                  = progressPicturesTaken == "True" ? "1" : "0";
            this.progressPicturesTakenDescription       = "'" + progressPicturesTakenDescription.Trim().Replace("'","''") + "'";
            this.accidentOnJob                          = accidentOnJob == "True" ? "1" : "0";
            this.accidentOnJobDescription               = "'" + accidentOnJobDescription.Trim().Replace("'","''") + "'";
            this.accidentReportFiled                    = accidentReportFiled == "True" ? "1" : "0";
            this.safetyMeetingToday                     = safetyMeetingToday == "True" ? "1" : "0";
            this.safetyMeetingTodayDescription          = "'" + safetyMeetingTodayDescription.Trim().Replace("'","''") + "'";
            this.extraWorkRequested                     = extraWorkRequested == "True" ? "1" : "0";
            this.extraWorkRequestedDescription          = "'" + extraWorkRequestedDescription.Trim().Replace("'","''") + "'";
            this.backChargeRequired                     = backChargeRequired == "True" ? "1" : "0";
            this.backChargeRequiredDescription          = "'" + backChargeRequiredDescription.Trim().Replace("'","''") + "'";
            this.scheduledWorkDelayed                   = scheduledWorkDelayed == "True" ? "1" : "0";
            this.scheduledWorkDelayedDescription        = "'" + scheduledWorkDelayedDescription.Trim().Replace("'","''") + "'";
            this.delayedCausedByOthers                  = delayedCausedByOthers == "True" ? "1" : "0";
            this.delayedCausedByOthersDescription       = "'" + delayedCausedByOthersDescription.Trim().Replace("'","''") + "'";
            this.disruptionReportFiled                  = disruptionReportFiled == "True" ? "1" : "0";
            this.disruptionReportFiledDescription       = "'" + disruptionReportFiledDescription.Trim().Replace("'","''") + "'";
            this.productiveNarrative                    = "'" + productiveNarrative.Trim().Replace("'", "''") + "'";
        }
        //
        public string JobDailyLogID
        {
            get { return jobDailyLogID; }
        }
        //
        public static DataSet GetDailyLogForm(string jobDailyLogID)
        {
            if (jobDailyLogID == "")
                jobDailyLogID = "0";

            string query = " SELECT " +
	                       "     JobNumber, " +
	                       "     JobName, " +
	                       "     DailyLogNumber, " +
	                       "     LogDate, " +
	                       "     NumberOfElectricians, " +
	                       "     WeatherCondition, " +
	                       "     Rental1, " +
	                       "     Rental2, " +
	                       "     Rental3, " +
	                       "     SafetyMeetingToday = " + 
		                   "         CASE  SafetyMeetingToday " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         End, " +
	                       "     SafetyMeetingTodayDescription, " +
	                       "     AccidentOnJob =  " +
		                   "         CASE AccidentOnJob " + 
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     AccidentOnJobDescription, " +
	                       "     AccidentReportFiled =  " +
		                   "         CASE AccidentReportFiled " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     ProgressPicturesTaken = " +
		                   "         CASE ProgressPicturesTaken " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     ProgressPicturesTakenDescription, " +
	                       "     InspectionToday = " +
		                   "         CASE InspectionToday " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     InspectionTodayDescription, " +
	                       "     ScheduledWorkDelayed = " +
		                   "         CASE ScheduledWorkDelayed " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     ScheduledWorkDelayedDescription, " +
	                       "     ExtraWorkRequested = " +
		                   "         CASE ExtraWorkRequested " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     ExtraWorkRequestedDescription, " +
	                       "     BackChargeRequired = " +
		                   "         CASE BackChargeRequired " + 
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     BackChargeRequiredDescription, " +
	                       "     DelayedCausedByOthers = " +
		                   "         CASE DelayedCausedByOthers " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     DelayedCausedByOthersDescription, " +
	                       "     DisruptionReportFiled = " +
		                   "         CASE DisruptionReportFiled " +
		                   "         WHEN 1 THEN 'Yes' " +
		                   "         ELSE 'No' " +
		                   "         END, " +
	                       "     DisruptionReportFiledDescription, " +
	                       "     ProductiveNarrative " +
                           " FROM tblJobDailyLog l " +
                           " LEFT JOIN tblJob j ON l.jobID = j.JobID " +
                           " WHERE JobDailyLogID = " + jobDailyLogID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetDailyLog(string jobDailyLogID)
        {
            if (jobDailyLogID == "")
                jobDailyLogID = "0";

            string query = " SELECT * " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobDailyLogID = " + jobDailyLogID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetDailyLogNumber(string jobDailyLogID)
        {
            if (jobDailyLogID == "")
                jobDailyLogID = "0";

            string query = "SELECT DailyLogNumber " +
                " FROM tblJobDailyLog " +
                " WHERE JobDailyLogID = " + jobDailyLogID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static bool IsDateUsed(string jobID, string logDate)
        {
            if (jobID == "")
                jobID = "0";
            bool isDateUsed = false;

            string query = "SELECT JobDailyLogID " +
                " FROM tblJobDailyLog " +
                " WHERE JobID = " + jobID + " AND LogDate = '" + logDate + "' ";

            try
            {
                DataTable t;
                t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    isDateUsed = true;
                return isDateUsed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobDailyLog(string jobID, int selection)
        {
            if (jobID == "")
                jobID = "0";
            string query = "";
            switch (selection)
            {
                case 0:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " InspectionToday AS [Inspection], " +
                           " ProgressPicturesTaken AS [Pictures], " +
                           " AccidentOnJob AS [Accident], " +
                           " AccidentReportFiled AS [Report Filed], " +
                           " SafetyMeetingToday AS [Safety Meeting], " +
                           " ExtraWorkRequested AS [Extra Work], " +
                           " BackChargeRequired AS [Back Charge], " +
                           " ScheduledWorkDelayed AS [Work Delayed], " +
                           " DelayedCausedByOthers AS [Delay By Others], " +
                           " DisruptionReportFiled AS [Disruption Report] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " ";
                    break;
                case 1:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " InspectionToday AS [Inspection], " +
                           " InspectionTodayDescription AS [Description]" +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND InspectionToday = 1";
                    break;
                case 2:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " ProgressPicturesTaken AS [Pictures], " +
                           " ProgressPicturesTakenDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND ProgressPicturesTaken = 1";
                    break;
                case 3:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " AccidentOnJob AS [Accident], " +
                           " AccidentOnJobDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND AccidentOnJob = 1";
                    break;
                case 4:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " SafetyMeetingToday AS [Safety Meeting], " +
                           " SafetyMeetingTodayDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND SafetyMeetingToday = 1 ";
                    break;
                case 5:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " ExtraWorkRequested AS [Extra Work], " +
                           " ExtraWorkRequestedDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND ExtraWorkRequested = 1 ";
                    break;
                case 6:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " BackChargeRequired AS [Back Charge], " +
                           " BackChargeRequiredDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND BackChargeRequired = 1";
                    break;
                case 7:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " ScheduledWorkDelayed AS [Work Delayed], " +
                           " ScheduledWorkDelayedDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND ScheduledWorkDelayed = 1 ";
                    break;
                case 8:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " DelayedCausedByOthers AS [Delay By Others], " +
                           " DelayedCausedByOthersDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND DelayedCausedByOthers = 1";
                    break;
                case 9:
                   query = " SELECT " +
                           " JobDailyLogID, " +
                           " DailyLogNumber AS [Log No], " +
                           " LogDate AS [Log Date]," +
                           " DisruptionReportFiled AS [Disruption Report], " +
                           " DisruptionReportFiledDescription AS [Description] " +
                           " FROM tblJobDailyLog  " +
                           " WHERE JobID = " + jobID + " AND DisruptionReportFiled = 1";
                    break;
            }

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static DataSet GetJobDailyLog(string jobID, int selection, string search)
        {
            if (jobID == "")
                jobID = "0";
            string query = "";
            string date = string.Empty;
            try
            {
                var dateOfDailyLog = Convert.ToDateTime(search);
                if (dateOfDailyLog != null && dateOfDailyLog.Year > 1900)
                {
                    date = " OR LogDate = '" + dateOfDailyLog.Month + "/" + dateOfDailyLog.Day + "/" + dateOfDailyLog.Year + "'";
                }

            }
            catch (Exception ex)
            {
                date = string.Empty;
            }
            switch (selection)
            {
                case 0:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " InspectionToday AS [Inspection], " +
                            " ProgressPicturesTaken AS [Pictures], " +
                            " AccidentOnJob AS [Accident], " +
                            " AccidentReportFiled AS [Report Filed], " +
                            " SafetyMeetingToday AS [Safety Meeting], " +
                            " ExtraWorkRequested AS [Extra Work], " +
                            " BackChargeRequired AS [Back Charge], " +
                            " ScheduledWorkDelayed AS [Work Delayed], " +
                            " DelayedCausedByOthers AS [Delay By Others], " +
                            " DisruptionReportFiled AS [Disruption Report] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND " +
                            "( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +                                                     
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 1:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " InspectionToday AS [Inspection], " +
                            " InspectionTodayDescription AS [Description]" +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND InspectionToday = 1" +
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 2:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " ProgressPicturesTaken AS [Pictures], " +
                            " ProgressPicturesTakenDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND ProgressPicturesTaken = 1"+
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 3:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " AccidentOnJob AS [Accident], " +
                            " AccidentOnJobDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND AccidentOnJob = 1" +
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                           " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 4:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " SafetyMeetingToday AS [Safety Meeting], " +
                            " SafetyMeetingTodayDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND SafetyMeetingToday = 1 " +
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 5:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " ExtraWorkRequested AS [Extra Work], " +
                            " ExtraWorkRequestedDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND ExtraWorkRequested = 1 "+
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 6:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " BackChargeRequired AS [Back Charge], " +
                            " BackChargeRequiredDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND BackChargeRequired = 1"+
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 7:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " ScheduledWorkDelayed AS [Work Delayed], " +
                            " ScheduledWorkDelayedDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND ScheduledWorkDelayed = 1 "+
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 8:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " DelayedCausedByOthers AS [Delay By Others], " +
                            " DelayedCausedByOthersDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND DelayedCausedByOthers = 1"+
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
                case 9:
                    query = " SELECT " +
                            " JobDailyLogID, " +
                            " DailyLogNumber AS [Log No], " +
                            " LogDate AS [Log Date]," +
                            " DisruptionReportFiled AS [Disruption Report], " +
                            " DisruptionReportFiledDescription AS [Description] " +
                            " FROM tblJobDailyLog  " +
                            " WHERE JobID = " + jobID + " AND DisruptionReportFiled = 1"+
                            " AND ( Rental1 like '%" + search + "%'" +
                            " OR DailyLogNumber like '%" + search + "%'" +
                            " OR NumberOfElectricians like '%" + search + "%'" +
                            " " + date + " " +
                            " OR WeatherCondition like '%" + search + "%'" +
                            " OR Rental2 like '%" + search + "%'" +
                            " OR Rental3 like '%" + search + "%'" +
                            " OR InspectionTodayDescription like '%" + search + "%'" +
                            " OR ProgressPicturesTakenDescription like '%" + search + "%'" +
                            " OR AccidentOnJobDescription like '%" + search + "%'" +
                            " OR SafetyMeetingTodayDescription like '%" + search + "%'" +
                            " OR ExtraWorkRequestedDescription like '%" + search + "%'" +
                            " OR BackChargeRequiredDescription like '%" + search + "%'" +
                            " OR ScheduledWorkDelayedDescription like '%" + search + "%'" +
                            " OR DelayedCausedByOthersDescription like '%" + search + "%'" +
                            " OR DisruptionReportFiledDescription like '%" + search + "%'" +
                            " OR ProductiveNarrative like '%" + search + "%' )";
                    break;
            }

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static bool Remove(string jobDailyLogID)
        {
            string query = "";

            query = "DELETE FROM tblJobDailyLog WHERE JobDailyLogID = " + jobDailyLogID;
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
        //
        public bool Save()
        {
            if (jobDailyLogID == "" || jobDailyLogID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobDailyLog(" +
                    " JobID, " +
                    " LogDate, " +
                    " WeatherCondition, " +
                    " NumberOfElectricians, " +
                    " Rental1, " +
                    " Rental2, " +
                    " Rental3, " +
                    " InspectionToday, " +
                    " InspectionTodayDescription, " +
                    " ProgressPicturesTaken, " +
                    " ProgressPicturesTakenDescription, " +
                    " AccidentOnJob, " +
                    " AccidentOnJobDescription, " +
                    " AccidentReportFiled, " +
                    " SafetyMeetingToday, " +
                    " SafetyMeetingTodayDescription, " +
                    " ExtraWorkRequested, " +
                    " ExtraWorkRequestedDescription, " +
                    " BackChargeRequired, " +
                    " BackChargeRequiredDescription, " +
                    " ScheduledWorkDelayed, " +
                    " ScheduledWorkDelayedDescription, " +
                    " DelayedCausedByOthers, " +
                    " DelayedCausedByOthersDescription, " +
                    " DisruptionReportFiled, " +
                    " DisruptionReportFiledDescription, " +
                    " ProductiveNarrative " +
                    " ) VALUES ( " +
                    jobID + ", " +
                    logDate + ", " +
                    weatherCondition + ", " +
                    numberOfElectricians + ", " +
                    rental1 + ", " +
                    rental2 + ", " +
                    rental3 + ", " +
                    inspectionToday + ", " +
                    inspectionTodayDescription + ", " +
                    progressPicturesTaken + ", " +
                    progressPicturesTakenDescription + ", " +
                    accidentOnJob + ", " +
                    accidentOnJobDescription + ", " +
                    accidentReportFiled + ", " +
                    safetyMeetingToday + ", " +
                    safetyMeetingTodayDescription + ", " +
                    extraWorkRequested + ", " +
                    extraWorkRequestedDescription + ", " +
                    backChargeRequired + ", " +
                    backChargeRequiredDescription + ", " +
                    scheduledWorkDelayed + ", " +
                    scheduledWorkDelayedDescription + ", " +
                    delayedCausedByOthers + ", " +
                    delayedCausedByOthersDescription + ", " +
                    disruptionReportFiled + ", " +
                    disruptionReportFiledDescription + ", " +
                    productiveNarrative + ") " +                  
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobDailyLogID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool Update()
        {
            string query = "";

            query = "Update tblJobDailyLog SET " +
                    " LogDate                           = " + logDate + ", " +
                    " WeatherCondition                  = " + weatherCondition + ", " +
                    " NumberOfElectricians              = " + numberOfElectricians + ", " +
                    " Rental1                           = " + rental1 + ", " +
                    " Rental2                           = " + rental2 + ", " +
                    " Rental3                           = " + rental3 + ", " +
                    " InspectionToday                   = " + inspectionToday + ", " +
                    " InspectionTodayDescription        = " + inspectionTodayDescription + ", " +
                    " ProgressPicturesTaken             = " + progressPicturesTaken + ", " +
                    " ProgressPicturesTakenDescription  = " + progressPicturesTakenDescription + ", " +
                    " AccidentOnJob                     = " + accidentOnJob + ", " +
                    " AccidentOnJobDescription          = " + accidentOnJobDescription + ", " +
                    " AccidentReportFiled               = " + accidentReportFiled + ", " +
                    " SafetyMeetingToday                = " + safetyMeetingToday + ", " +
                    " SafetyMeetingTodayDescription     = " + safetyMeetingTodayDescription + ", " +
                    " ExtraWorkRequested                = " + extraWorkRequested + ", " +
                    " ExtraWorkRequestedDescription     = " + extraWorkRequestedDescription + ", " +
                    " BackChargeRequired                = " + backChargeRequired + ", " +
                    " BackChargeRequiredDescription     = " + backChargeRequiredDescription + ", " +
                    " ScheduledWorkDelayed              = " + scheduledWorkDelayed + ", " +
                    " ScheduledWorkDelayedDescription   = " + scheduledWorkDelayedDescription + ", " +
                    " DelayedCausedByOthers             = " + delayedCausedByOthers + ", " +
                    " DelayedCausedByOthersDescription  = " + delayedCausedByOthersDescription + ", " +
                    " DisruptionReportFiled             = " + disruptionReportFiled + ", " +
                    " DisruptionReportFiledDescription  = " + disruptionReportFiledDescription + ", " +
                    " ProductiveNarrative               = " + productiveNarrative + " " +                 
                    " WHERE JobDailyLogID        = " + jobDailyLogID;
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
    }
}
