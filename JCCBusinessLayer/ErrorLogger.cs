using System;
using System.IO;

namespace JCCBusinessLayer
{
    public static class ErrorLogger
    {
        // *************************************************************

        //NAME:          WriteToErrorLog

        //PURPOSE:       Open or create an error log and submit error message

        //PARAMETERS:    msg - message to be written to error file

        //               stkTrace - stack trace from error message

        //               title - title of the error file entry

        //               logFilePath - path of directory to save log file

        //RETURNS:       Nothing

        //*************************************************************
        public static void WriteToErrorLog ( Exception objException, string logFilePath )
        {
            FileStream fs = null;
            if (!(Directory.Exists(logFilePath)))
            {
                Directory.CreateDirectory(logFilePath);
            }
            string filename = logFilePath + "ErrorLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";
            FileInfo fileInfo = new FileInfo(filename);
            if (!fileInfo.Exists)
            {
                fs = fileInfo.Create();
            }
            else
            {
                fs = new FileStream(filename, FileMode.Append);
            }

            StreamWriter s = new StreamWriter(fs);

            //  FileStream fs1 = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.Append, FileAccess.Write);
            s.WriteLine("Source        : " +
                    objException.Source.ToString().Trim() + "\r\n");
            s.WriteLine("Method        : " +
                    objException.TargetSite.Name.ToString() + "\r\n");
            s.WriteLine("Date        : " +
                    DateTime.Now.ToLongTimeString() + "\r\n");
            s.WriteLine("Time        : " +
                    DateTime.Now.ToShortDateString() + "\r\n");
            s.WriteLine("Error        : " +
                    objException.Message.ToString().Trim() + "\r\n");
            s.WriteLine("Stack Trace    : " +
                    objException.StackTrace.ToString().Trim() + "\r\n");
            s.Write("============================================" + "\r\n");

            s.Write("============================================" + "\r\n");

            s.Close();

            fs.Close();
        }

        public static void PicNotFoundLog ( string text, string logFilePath )
        {
            FileStream fs = null;
            if (!(Directory.Exists(logFilePath)))
            {
                Directory.CreateDirectory(logFilePath);
            }
            string filename = logFilePath + "PicNotFoundLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";
            FileInfo fileInfo = new FileInfo(filename);
            if (!fileInfo.Exists)
            {
                fs = fileInfo.Create();
            }
            else
            {
                fs = new FileStream(filename, FileMode.Append);
            }
            StreamWriter s = new StreamWriter(fs);
            s.WriteLine(text + "\r\n");
            s.Close();
            fs.Close();
        }

        public static void MigrationErrorLog ( string text, string logFilePath )
        {
            FileStream fs = null;
            if (!(Directory.Exists(logFilePath)))
            {
                Directory.CreateDirectory(logFilePath);
            }
            string filename = logFilePath + "MigrationErrorLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";
            FileInfo fileInfo = new FileInfo(filename);
            if (!fileInfo.Exists)
            {
                fs = fileInfo.Create();
            }
            else
            {
                fs = new FileStream(filename, FileMode.Append);
            }
            StreamWriter s = new StreamWriter(fs);
            s.WriteLine(text + "\r\n");
            s.Close();
            fs.Close();
        }
    }
}
