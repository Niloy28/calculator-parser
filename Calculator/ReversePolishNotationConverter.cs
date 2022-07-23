namespace CalculatorParser
{
    public class ReversePolishNotationConverter
    {
        public static Queue<string> Convert(string expression)
        {
            Queue<string> rpn = new Queue<string>();
            Stack<string> mathSymbols = new Stack<string>();

            bool isNegativeOperand = false;
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
                    // unary operator handling
                    if (operand.Length == 0)
                    {
                        isNegativeOperand = true;
                    }
                    else
                    {
                        // if an operator is found, the operand is finished
                        EnqueueOperand(ref operand, ref isNegativeOperand, ref rpn);

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
                }
                else if (token.Equals("("))
                {
                    mathSymbols.Push(token);
                }
                else if (token.Equals(")"))
                {
                    while (mathSymbols.Count != 0 && !mathSymbols.Peek().Equals("("))
                    {
                        // Until the top token (from the stack) is left parenthesis, first add the operand and then the math operators to the rpn
                        EnqueueOperand(ref operand, ref isNegativeOperand, ref rpn);
                        rpn.Enqueue(mathSymbols.Pop());
                    }
                    // remove left parentheses
                    mathSymbols.Pop();
                }
            }
            // enqueue last operand into rpn
            EnqueueOperand(ref operand, ref isNegativeOperand, ref rpn);

            // enqueue all leftover operators
            while (mathSymbols.Count != 0)
            {
                rpn.Enqueue(mathSymbols.Pop());
            }

            return rpn;
        }

        private static void EnqueueOperand(ref string operand, ref bool isNegativeOperand, ref Queue<string> rpn)
        {
            if (operand.Length == 0) return;

            if (isNegativeOperand)
            {
                operand = String.Format("-{0}", operand);
                isNegativeOperand = false;
            }
            rpn.Enqueue(operand);
            operand = "";
        }
    }
}
