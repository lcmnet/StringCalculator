using StringCalculatorNF.Interfaces;
using StringCalculatorNF.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Util
{
    public class StringCalculator
    {
        private readonly ILogger _logger = null;

        public StringCalculator(ILogger logger)
        {
            _logger = logger;
        }

        public double Calculate(string sum)
        {
            try
            {
                StringCalculatorService util = new StringCalculatorService(_logger);
                var result = util.CalculateNow(sum);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
