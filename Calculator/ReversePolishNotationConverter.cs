using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorParser
{
    internal class ReversePolishNotationConverter
    {
        public Queue<string> Convert(string expression)
        {
            Queue<string> rpn = new Queue<string>();
            Stack<string> operators = new Stack<string>();

            string operand = "";
            foreach (char token in expression)
            {
                if (char.IsDigit(token))
                {
                    // if token is a digit, add to the back of operand
                    operand += token;
                }
                else if (IsOperator(token.ToString()))
                {
                    // if an operator is found, the operand is finished
                    rpn.Enqueue(operand);

                    if (operators.Count != 0 && IsOperator(operators.Peek()))
                    {
                        var currentOperator = token;
                        var oldOperator = operators.Peek();

                        if (currentOperator > oldOperator)
                        {
                            rpn.Enqueue(operators.Pop());
                        }
                    }
                    operators.Push(token.ToString());
                }
                else if (token.Equals("("))
                {
                    operators.Push(token.ToString());
                }
                else if (token.Equals(")"))
                {
                    while (operators.Count != 0 && !operators.Peek().Equals("("))
                    {
                        // Until the top token (from the stack) is left parenthesis, pop from the stack to the output buffer
                        rpn.Enqueue(operators.Pop());
                    }
                    // remove left parentheses
                    operators.Pop();
                }
            }

            while (operators.Count != 0)
            {
                rpn.Enqueue(operators.Pop());
            }

            return rpn;
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "%";
        }

        private static int Precedence(string leftOp, string rightOp)
        {
            return 0;
        }
    }
}
