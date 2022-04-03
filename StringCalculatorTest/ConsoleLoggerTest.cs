using NUnit.Framework;
using StringCalculatorNF.Interfaces;
using StringCalculatorNF.Logger;
using StringCalculatorNF.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTest
{
    public class ConsoleLoggerTest
    {
        private CustomLogger _customLogger = null;

        [SetUp]
        public void Setup()
        {
            ILogger consoleLogger = new ConsoleLogger();
            _customLogger = new CustomLogger(consoleLogger);
        }

        [Test]
        public void TestForPassOnWriteLog()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string expected = "I am testing if I write correctly";
                _customLogger.WriteLog(expected);

                string extractLog = sw.ToString();
                int foundIndex = extractLog.IndexOf(expected);

                Assert.IsTrue(foundIndex > 0);
            }
            
        }
    }
}
