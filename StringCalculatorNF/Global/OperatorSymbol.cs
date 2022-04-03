using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF.Global
{
    public static class OperatorSymbol
    {
        public const char Multiply = '*';
        public const char Divide = '/';
        public const char Addition = '+';
        public const char Subtraction = '-';

        public const char OpenBracket = '(';
        public const char CloseBracket = ')';

        public static char[] AllowedOperators = new char[]
            { OperatorSymbol.Multiply, OperatorSymbol.Divide, OperatorSymbol.Addition, OperatorSymbol.Subtraction };

        //public static char[] BracketSymbols = new char[]
        //    { OperatorSymbol.OpenBracket, OperatorSymbol.CloseBracket };
    }
}
