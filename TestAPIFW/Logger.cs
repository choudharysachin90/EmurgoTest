

using System;
using System.IO;

namespace TestAPIFW
{
    public class Logger
    {
        public enum MessageType
        { 
            Info,
            Error,
            Warning
        }


        string logFileDirPath = "D:\\C#Selenium\\Logs";
        DirectoryInfo recentExecutionDirectory;
        string filePath;
        FileStream fileToWriteLogs;
        TextWriter textWriter;

        public void InitializeLogger(string testCaseName)
        {
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(logFileDirPath))
                {
                    Directory.CreateDirectory(logFileDirPath);
                }

                // Try to create the directory.
                if (!Directory.Exists(recentExecutionDirectory?.FullName))
                {
                    recentExecutionDirectory = Directory
                    .CreateDirectory(logFileDirPath + "\\ExecutionLog_" + DateTime.Now.ToFileTime().ToString());
                }

                fileToWriteLogs = File.Create(recentExecutionDirectory.FullName +"\\"+ testCaseName + ".log");
                fileToWriteLogs.Close();
                textWriter = new StreamWriter(fileToWriteLogs.Name, true);
            }
            catch (Exception e)
            {
               //
            }
            finally { }
        }

        public void LogStepInfo(MessageType messageType, string message)
        {
            try
            {
                textWriter.WriteLine(string.Format("\nSTEP {0} : {1}", messageType.ToString(), message));               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisposeLogger()
        {
            try
            {
                textWriter.Close();
                fileToWriteLogs.Close();
            }
            catch
            {
                textWriter.Dispose();
                fileToWriteLogs.Dispose();
            }
        }

    }
}
