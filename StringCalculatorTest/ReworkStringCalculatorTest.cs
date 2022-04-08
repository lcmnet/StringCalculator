using NUnit.Framework;
using StringCalculatorNF.Interfaces;
using StringCalculatorNF.Logger;
using StringCalculatorNF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTest
{
    public class ReworkStringCalculatorTest
    {
        StringCalculator _stringCalculator = null;

        [SetUp]
        public void Setup()
        {
            ILogger consoleLogger = new ConsoleLogger();
            _stringCalculator = new StringCalculator(consoleLogger);
        }

        [Test]
        public void TestForPassOnSelfMadeQuestions()
        {
            string sum1 = "( 1.1 - 1 ) + ( ( 1 + 1 ) * ( 1.1 * 1 ) )";
            var result1 = _stringCalculator.Calculate(sum1);
            Assert.AreEqual(2.3, result1);

            string sum2 = "( ( 1.1 - 1 ) + ( ( 1 + 1 ) * ( 1.1 * 1 ) ) ) * 5";
            var result2 = _stringCalculator.Calculate(sum2);
            Assert.AreEqual(11.5, result2);

            string sum3 = "( ( ( 1.1 - 1 ) + 3 ) + ( ( 1 + 1 ) * ( 1.1 * 1 ) ) ) * 5";
            var result3 = _stringCalculator.Calculate(sum3);
            Assert.AreEqual(26.5, result3);

            string sum4 = "( ( ( 1.1 - 1 ) + 3 ) + ( ( 1 + 1.22 ) * ( 1.1 * 1 ) ) ) * 5";
            var result4 = _stringCalculator.Calculate(sum4);
            Assert.AreEqual(27.71, result4);
        }




    }
}
