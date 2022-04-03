using StringCalculatorNF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Logger
{
    public class CustomLogger
    {
        private readonly ILogger _logger = null;

        public CustomLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteLog(object message)
        {
            _logger.WriteLog(message);
        }
    }
}
