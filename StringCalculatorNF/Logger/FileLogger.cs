using StringCalculatorNF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Logger
{   
    public class FileLogger : ILogger
    {
        private readonly string _path = string.Empty;

        public FileLogger(string path)
        {
            _path = path;
        }
        public void WriteLog(object message)
        {
            string fullMessage;
            if (System.IO.File.Exists(_path))
            {
                fullMessage = string.Format("{0}{1} - {2}", System.Environment.NewLine, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
            }
            else
            {
                fullMessage = string.Format("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
            }

            System.IO.File.AppendAllText(_path, fullMessage);
        }
    }


}
