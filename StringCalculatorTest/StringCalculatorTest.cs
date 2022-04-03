using NUnit.Framework;
using StringCalculatorNF.Interfaces;
using StringCalculatorNF.Logger;
using StringCalculatorNF.Util;
using System;

namespace StringCalculatorTest
{
    public class StringCalculatorTest
    {
        StringCalculator _stringCalculator = null;

        [SetUp]
        public void Setup()
        {
            ILogger consoleLogger = new ConsoleLogger();
            _stringCalculator = new StringCalculator(consoleLogger);
        }

        [Test]
        public void TestForPassOnNoBracketQuestions()
        {
            string sum1 = "1 + 1";
            var result1 = _stringCalculator.Calculate(sum1);
            Assert.AreEqual(2.0, result1);

            string sum2 = "2 * 2";
            var result2 = _stringCalculator.Calculate(sum2);
            Assert.AreEqual(4.0, result2);

            string sum3 = "1 + 2 + 3";
            var result3 = _stringCalculator.Calculate(sum3);
            Assert.AreEqual(6, result3);

            string sum4 = "6 / 2";
            var result4 = _stringCalculator.Calculate(sum4);
            Assert.AreEqual(3.0, result4);

            string sum5 = "11 + 23";
            var result5 = _stringCalculator.Calculate(sum5);
            Assert.AreEqual(34.0, result5);

            string sum6 = "11.1 + 23";
            var result6 = _stringCalculator.Calculate(sum6);
            Assert.AreEqual(34.1, result6);

            string sum7 = "1 + 1 * 3";
            var result7 = _stringCalculator.Calculate(sum7);
            Assert.AreEqual(4.0, result7);
        }

        [Test]
        public void TestForPassOnBracketQuestions()
        {
            string sum1 = "( 11.5 + 15.4 ) + 10.1";
            var result1 = _stringCalculator.Calculate(sum1);
            Assert.AreEqual(37.0, result1);

            string sum2 = "23 - ( 29.3 - 12.5 )";
            var result2 = _stringCalculator.Calculate(sum2);
            Assert.AreEqual(6.2, result2);

            string sum3 = "( 1 / 2 ) - 1 + 1";
            var result3 = _stringCalculator.Calculate(sum3);
            Assert.AreEqual(0.5, result3);
        }

        [Test]
        public void TestForPassOnNestedBracketQuestions()
        {
            string sum1 = "10 - ( 2 + 3 * ( 7 - 5 ) )";
            var result1 = _stringCalculator.Calculate(sum1);
            Assert.AreEqual(2.0, result1);
        }

        [Test]
        public void TestForPassOnSelfMadeQuestions()
        {
            string sum1 = "10 - ( 2 + 3 * ( 7 - 5 ) * ( 3 - 1 ) )";
            var result1 = _stringCalculator.Calculate(sum1);
            Assert.AreEqual(-4.0, result1);

            string sum2 = "1 - ( 2 + 3 ) * ( 7 - 5 ) * ( 3 - 1 )";
            var result2 = _stringCalculator.Calculate(sum2);
            Assert.AreEqual(-19.0, result2);

            string sum3 = "1 - ( ( 2 + 3 ) * ( 7 - 5 ) + ( 3 - 1 ) - 1 )";
            var result3 = _stringCalculator.Calculate(sum3);
            Assert.AreEqual(-10.0, result3);
        }

        [Test]
        public void TestForFailOnInvalidOperation()
        {
            string sum1 = "10 ? 3";
            Assert.Throws<Exception>(() => _stringCalculator.Calculate(sum1));

            string sum2 = "( ( 10  3 )";
            Assert.Throws<Exception>(() => _stringCalculator.Calculate(sum2));
        }

        [Test]
        public void TestForFailOnMissingCloseBracket()
        {
            string sum1 = "( ( 10  3 )";
            Assert.Throws<Exception>(() => _stringCalculator.Calculate(sum1));
        }
    }
}