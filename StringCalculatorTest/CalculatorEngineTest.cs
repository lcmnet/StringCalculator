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
    public class CalculatorEngineTest
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestForPassOnAddOperation()
        {
            var result = CalculatorEngine.DoCountByOperation(OperatorSymbol.Addition, 99.99, 222.22);

            Assert.AreEqual(322.21, result);
        }

        [Test]
        public void TestForPassOnNegativeOperandAOnAddOperation()
        {
            var result = CalculatorEngine.DoCountByOperation(OperatorSymbol.Addition, -99.99, 222.22);

            Assert.AreEqual(122.23, result);
        }

        [Test]
        public void TestForPassOnNegativeOperandAOnSubtractOperation()
        {
            var result = CalculatorEngine.DoCountByOperation(OperatorSymbol.Subtraction, -1, -9);

            Assert.AreEqual(-10, result);
        }
    }
}
