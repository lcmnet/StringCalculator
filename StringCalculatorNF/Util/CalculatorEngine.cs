using StringCalculatorNF.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Util
{
    public static class CalculatorEngine
    {
        private static double DoCountByOperation(char operation, double operandA, double operandB, bool operandAIsNegative)
        {
            try
            {
                double result = 0;
                switch (operation)
                {
                    case OperatorSymbol.Multiply:
                        result = Math.Multiply(operandA, operandB);
                        break;
                    case OperatorSymbol.Addition:
                        result = Math.Add(operandA, operandB);
                        break;
                    case OperatorSymbol.Divide:
                        result = Math.Divide(operandA, operandB);
                        break;
                    case OperatorSymbol.Subtraction:
                        if (operandAIsNegative)
                        {
                            result = Math.Add(operandA, operandB);
                        }
                        else
                        {
                            result = Math.Subtract(operandA, operandB);
                        }
                        break;
                }

                return result;
            }
            catch
            {
                throw;
            }
            

            
        }

        public static double DoCountByOperation(char operation, double operandA, double operandB)
        {
            try
            {
                bool operandAIsNegative = false;
                if (operandA < 0) operandAIsNegative = true;

                return DoCountByOperation(operation, operandA, operandB, operandAIsNegative);
            }
            catch
            {
                throw;
            }



        }
    }
}
