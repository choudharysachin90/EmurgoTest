

using System;
using System.IO;

namespace TestFrameworkSetup
{
    /// <summary>
    /// Logger - Class that support basic logging for any test case
    /// </summary>
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

        /// <summary>
        /// InitializeLogger - Function to intitalize directory and testcase 
        /// log file for current test case
        /// </summary>
        /// <param name="testCaseName"></param>
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

                fileToWriteLogs = File.Create(recentExecutionDirectory.FullName + "\\" + testCaseName + ".log");
                fileToWriteLogs.Close();
                textWriter = new StreamWriter(fileToWriteLogs.Name, true);
            }
            catch (Exception e)
            {
                //
            }
            finally { }
        }
        /// <summary>
        /// LogStepInfo - Log current test step info to log file
        /// </summary>
        /// <param name="messageType">Enum - Warning , info , error type</param>
        /// <param name="message">Your actual message to log</param>
        public void LogStepInfo(MessageType messageType, string message)
        {
            try
            {
                textWriter.WriteLine(string.Format("\n{0} {1} : {2}",DateTime.Now.ToString(), messageType.ToString(), message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DisposeLogger - Function to dispose logger object
        /// </summary>
        public void DisposeLogger()
        {
            if (textWriter != null)
            {
                textWriter.Close();
            }
            if (fileToWriteLogs != null)
            {
                fileToWriteLogs.Close();
            }
        }

    }
}
