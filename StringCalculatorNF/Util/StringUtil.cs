using StringCalculatorNF.Global;
using StringCalculatorNF.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Util
{
    public static class StringUtil
    {
        public static string CleanUpSpaces(string input)
        {
            //trim the spaces
            input = input.Trim();
            input = input.Replace(" ", "");
            return input;
        }

        public static bool ValidateInput(string input)
        {
            try
            {
                //check for bracket comes in pair
                if (input.Contains(OperatorSymbol.OpenBracket) || input.Contains(OperatorSymbol.CloseBracket))
                {
                    var openBracketCount = input.Count(f => (f == OperatorSymbol.OpenBracket));
                    var closeBracketCount = input.Count(f => (f == OperatorSymbol.CloseBracket));
                    if (openBracketCount != closeBracketCount)
                    {
                        return false;
                    }
                }

                //find for last open bracket and corresponding close bracket
                int lastIndexOfOpenBracket = input.LastIndexOf(OperatorSymbol.OpenBracket);
                int indexOfCorrespondingCloseBracket = GetIndexOfCorrespondingCloseBracket(input);

                if (lastIndexOfOpenBracket < 0 && indexOfCorrespondingCloseBracket >= 0)
                {
                    return false;
                }

                if (indexOfCorrespondingCloseBracket < lastIndexOfOpenBracket)
                {
                    return false;
                }

                if (input.IndexOfAny(OperatorSymbol.AllowedOperators) < 0)
                    return false;

                return true;
            }
            catch 
            {
                throw;
            }
            
        }

        public static bool HasAnyOperator(string input)
        {
            int foundIndex = input.LastIndexOfAny(OperatorSymbol.AllowedOperators);

            if (foundIndex > 0)
                return true;
            else
                return false;
        }

        public static int GetIndexOfCorrespondingCloseBracket(string input)
        {
            try
            {
                //find for last open bracket and corresponding close bracket
                int lastIndexOfOpenBracket = input.LastIndexOf(OperatorSymbol.OpenBracket);
                int indexOfCorrespondingCloseBracket = input.IndexOf(OperatorSymbol.CloseBracket);

                int nextIndexOfCloseBracket = indexOfCorrespondingCloseBracket;
                while (nextIndexOfCloseBracket < lastIndexOfOpenBracket)
                {
                    string tmp = input.Substring(lastIndexOfOpenBracket + 1);
                    int i = tmp.IndexOf(OperatorSymbol.CloseBracket);
                    string tmp2 = tmp.Substring(0, i);

                    nextIndexOfCloseBracket = nextIndexOfCloseBracket + tmp2.Length + 2 + 1;
                }
                indexOfCorrespondingCloseBracket = nextIndexOfCloseBracket;

                return indexOfCorrespondingCloseBracket;
            }
            catch 
            {
                throw;
            }
            
        }
    }




}
