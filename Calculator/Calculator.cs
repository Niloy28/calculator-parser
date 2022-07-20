using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorParser
{
    internal class Calculator
    {
        private string _expression;

        public Calculator(string expression)
        {
            _expression = expression;
        }


        public string Solve()
        {
            // resolve edge cases first
            if (_expression.Contains('.'))
            {
                return "error";
            }

            return "";
        }
    }
}
