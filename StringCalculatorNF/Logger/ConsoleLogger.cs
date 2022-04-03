using StringCalculatorNF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(object message)
        {
            string fullMessage = string.Format("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
            Console.WriteLine(fullMessage);
        }

    }
}
