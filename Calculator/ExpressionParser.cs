using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorParser
{
    internal class ExpressionParser
    {
        private string _expression;

        ExpressionParser(string expression)
        {
            _expression = expression;
        }
        
        public Queue<string> Parse()
        {
            Queue<string> parsedResult = new Queue<string>();



            return parsedResult;
        }
    }
}
