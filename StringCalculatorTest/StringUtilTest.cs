using NUnit.Framework;
using StringCalculatorNF.Global;
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
    public class StringUtilTest
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestForPassOnCleanedInput()
        {
            string input = "    1 1 1  444 565 7  77 8 ";
            string cleaned = StringUtil.CleanUpSpaces(input);

            int c = string.Compare("1114445657778", cleaned);

            Assert.AreEqual(0, c);
        }

        [Test]
        public void TestForPassOnValidateInput()
        {
            string input = "1 + 1 + 232";
            var validate = StringUtil.ValidateInput(input);

            Assert.IsTrue(validate);
        }

        [Test]
        public void TestForFailOnValidateInput()
        {
            string input = "1 1 1  444 565 7  77 8 ";
            var validate = StringUtil.ValidateInput(input);

            Assert.IsFalse(validate);
        }

        [Test]
        public void TestForPassOnInputHasOperators()
        {
            string input = "1 + 1";
            var validate = StringUtil.HasAnyOperator(input);

            Assert.IsTrue(validate);
        }

        [Test]
        public void TestForFailOnInputHasOperators()
        {
            string input = "1121";
            var validate = StringUtil.HasAnyOperator(input);

            Assert.IsFalse(validate);
        }

        [Test]
        public void TestForPassOnIndexOfCorrespondingCloseBracket()
        {
            string input = "1 + ( ( 2 + 44 ) + 1 )";
            var index = StringUtil.GetIndexOfCorrespondingCloseBracket(input);

            Assert.AreEqual(index, 15);
        }
    }
}
