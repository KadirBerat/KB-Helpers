using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Helpers
{
    public static class LogHelper
    {
        private static string source = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string folderName = "Log Records";
        private static string folderPath = $@"{source}\{folderName}";

        private static void DirectoryControl()
        {
            bool folderCheck = File.Exists(folderPath);
            if (folderCheck == false)
                Directory.CreateDirectory(folderPath);
        }

        private static string LogFileControl()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string filePath = $@"{folderPath}\{date}.log";
            bool fileCheck = File.Exists(filePath);
            if (fileCheck == false)
            {
                using (FileStream fs = File.Create(filePath))
                {
                    fs.Dispose();
                    fs.Close();
                }
            }
            return filePath;
        }

        public enum LogTypes
        {
            Information,
            Warning,
            Error,
            Success_Audit, //Security Log
            Failure_Audit //Security Log
        }

        public static void AddLog(LogTypes type, string data)
        {
            DirectoryControl();
            string filePath = LogFileControl();
            StreamWriter sw = File.AppendText(filePath);
            string log = $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} : {type.ToString()} : {data}";
            sw.WriteLine(log);
            sw.Dispose();
            sw.Close();
        }

    }
}
