namespace CalculatorParser
{
    public class ReversePolishNotationConverter
    {
        public Queue<string> Convert(string expression)
        {
            Queue<string> rpn = new Queue<string>();
            Stack<string> mathSymbols = new Stack<string>();

            string operand = "";
            foreach (char c in expression)
            {
                string token = c.ToString();
                if (char.IsDigit(c))
                {
                    // if token is a digit, add to the back of operand
                    operand += token;
                }
                else if (Operator.Operators.ContainsKey(token))
                {
                    // if an operator is found, the operand is finished
                    rpn.Enqueue(operand);
                    operand = "";

                    if (mathSymbols.Count != 0 && Operator.Operators.ContainsKey(mathSymbols.Peek()))
                    {
                        var currentOperator = Operator.Operators[token];
                        var oldOperator = Operator.Operators[mathSymbols.Peek()];

                        if ((currentOperator.Associativity == Associativity.LEFT && currentOperator.Precedence <= oldOperator.Precedence) || 
                            (currentOperator.Associativity == Associativity.RIGHT && currentOperator.Precedence < oldOperator.Precedence))
                        {
                            rpn.Enqueue(mathSymbols.Pop());
                        }
                    }
                    mathSymbols.Push(token);
                }
                else if (token.Equals("("))
                {
                    mathSymbols.Push(token);
                }
                else if (token.Equals(")"))
                {
                    while (mathSymbols.Count != 0 && !mathSymbols.Peek().Equals("("))
                    {
                        // Until the top token (from the stack) is left parenthesis, pop from the stack to the output buffer
                        rpn.Enqueue(mathSymbols.Pop());
                    }
                    // remove left parentheses
                    mathSymbols.Pop();
                }
            }
            // enqueue last operand into rpn
            rpn.Enqueue(operand);

            while (mathSymbols.Count != 0)
            {
                rpn.Enqueue(mathSymbols.Pop());
            }

            return rpn;
        }
    }
}
