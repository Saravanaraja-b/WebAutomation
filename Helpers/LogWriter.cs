using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class LogWriter
    {
        private static string m_exePath = string.Empty;
        public static void Write(string logMessage, string methodName)
        {
            LogWrite(logMessage,methodName);
        }
        public static void LogWrite(string logMessage , string MethodName)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage,MethodName, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void Log(string logMessage,string methodName, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine(methodName);
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }

    }
}
