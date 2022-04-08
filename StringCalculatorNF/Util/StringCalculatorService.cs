using StringCalculatorNF.Global;
using StringCalculatorNF.Interfaces;
using StringCalculatorNF.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Util
{
    public class StringCalculatorService
    {
        private readonly ILogger _logger = null;
        private readonly CustomLogger _customLogger = null;

        public StringCalculatorService(ILogger logger)
        {
            _logger = logger;
            _customLogger = new CustomLogger(logger);
        }
        private string CalculateAndReturn(string input)
        {
            //find for last open bracket and first close bracket
            int lastIndexOfOpenBracket = input.LastIndexOf(OperatorSymbol.OpenBracket);
            int indexOfCorrespondingCloseBracket = StringUtil.GetIndexOfCorrespondingCloseBracket(input);

            string extractedInput;
            string remainderInput = string.Empty;
            string frontBalanceInput = string.Empty;
            if (lastIndexOfOpenBracket >= 0 && indexOfCorrespondingCloseBracket >= 0)
            {
                extractedInput = input.Substring(lastIndexOfOpenBracket + 1, indexOfCorrespondingCloseBracket - lastIndexOfOpenBracket - 1);  
                var splited = extractedInput.Split(OperatorSymbol.AllowedOperators);
                bool needAddParenthesis = false;
                if (splited.Length > 2)
                {
                    needAddParenthesis = true;
                }

                //_customLogger.WriteLog(string.Format("Extracted --> {0}", extractedInput));
                frontBalanceInput = input.Substring(0, lastIndexOfOpenBracket);
                remainderInput = input.Substring(indexOfCorrespondingCloseBracket + 1);

                if (needAddParenthesis)
                {
                    frontBalanceInput += OperatorSymbol.OpenBracket;
                    remainderInput += OperatorSymbol.CloseBracket;
                }
            }
            else
            {
                extractedInput = input;
            }

            var finalExactedInput = extractedInput;
            char useOperator = FindOperator(extractedInput);
            var counted = this.CalculateString(finalExactedInput, useOperator, remainderInput);
            finalExactedInput = frontBalanceInput + counted;
            return finalExactedInput;
        } 

        private string CalculateString(string extractedInput, char operation, string backBalanceInput)
        {
            if (string.IsNullOrEmpty(extractedInput)) return "0";

            bool isOperandANegative = false;

            int operationIndex = extractedInput.IndexOf(operation);
            if (extractedInput.IndexOf(OperatorSymbol.Subtraction) == 0)
            {
                isOperandANegative = true;
            }

            var operandA = string.Empty;
            var operandB = string.Empty;
            var frontBalanceInput = string.Empty;
            var unProcessRemainder = string.Empty;

            if (isOperandANegative)
            {
                string tmp = extractedInput.Substring(1);
                int nextIndex = tmp.IndexOf(operation);
                string tmpA = extractedInput.Substring(0, nextIndex + 1);
                operandA = tmpA;

                var removedOperandAInput = extractedInput.Substring(nextIndex + 1);
                operandB = removedOperandAInput.Substring(0);

            }
            else
            {

                operandA = extractedInput.Substring(0, operationIndex);
                int nextOperationIndex = operandA.LastIndexOfAny(OperatorSymbol.AllowedOperators);
                if (nextOperationIndex >= 0)
                {
                    frontBalanceInput = operandA.Substring(0, nextOperationIndex + 1);
                    operandA = operandA.Substring(nextOperationIndex + 1);
                }
                else
                {

                }

                var removedOperandAInput = extractedInput.Substring(operationIndex + 1);
                int secondOperationIndex = removedOperandAInput.IndexOfAny(OperatorSymbol.AllowedOperators);
                if (secondOperationIndex < 0)
                {
                    operandB = removedOperandAInput.Substring(0);
                }
                else
                {
                    operandB = removedOperandAInput.Substring(0, secondOperationIndex);
                    unProcessRemainder = removedOperandAInput.Substring(secondOperationIndex);
                }


            }

            double b = Convert.ToDouble(operandB);
            double a = Convert.ToDouble(operandA);
            double result = CalculatorEngine.DoCountByOperation(operation, a, b);

            string finalExactedInput;
            if (unProcessRemainder.Length <= 1)
            {
                finalExactedInput = result.ToString();
            }
            else
            {
                finalExactedInput = result + unProcessRemainder;
            }
            finalExactedInput = frontBalanceInput + finalExactedInput + backBalanceInput;

            return finalExactedInput;
        }

        public double CalculateNow(string input)
        {
            try
            {
                var cleanedInput = StringUtil.CleanUpSpaces(input);
                var result = StringUtil.ValidateInput(cleanedInput);
                _customLogger.WriteLog(string.Format("{0} validated: {1}", cleanedInput, result));

                var balanceInput = cleanedInput;
                if (result)
                {
                    bool run = true;
                    do
                    {
                        balanceInput = this.CalculateAndReturn(balanceInput);
                        if (!StringUtil.HasAnyOperator(balanceInput)) run = false;
                    } while (run);
                    _customLogger.WriteLog(string.Format("results: {0}", balanceInput));
                    return Convert.ToDouble(balanceInput);
                }
                else
                {
                    throw new Exception("failed validation on input, unable to calculate");
                }
            }
            catch 
            {
                throw;
            }
        }

        private char FindOperator(string extractedInput)
        {
            char useOperator = '\0';
            if (extractedInput.Contains(OperatorSymbol.Divide))
            {
                useOperator = OperatorSymbol.Divide;
            }
            else if (extractedInput.Contains(OperatorSymbol.Multiply))
            {
                useOperator = OperatorSymbol.Multiply;
            }
            else if (extractedInput.Contains(OperatorSymbol.Addition) || extractedInput.Contains(OperatorSymbol.Subtraction))
            {
                //check for which one to do first;
                int indexForAdd = extractedInput.IndexOf(OperatorSymbol.Addition);
                int indexForSubtract = extractedInput.IndexOf(OperatorSymbol.Subtraction);

                if (indexForAdd < 0)
                {
                    useOperator = OperatorSymbol.Subtraction;
                }
                else
                {
                    if (indexForSubtract < indexForAdd && indexForSubtract > 0)
                    {
                        useOperator = OperatorSymbol.Subtraction;
                    }
                    else
                    {
                        useOperator = OperatorSymbol.Addition;
                    }
                }
            }

            return useOperator;
        }


    }
}
