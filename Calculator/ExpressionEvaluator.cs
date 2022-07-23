namespace CalculatorParser
{
    public class ExpressionEvaluator
    {
        private readonly string _expression;

        public ExpressionEvaluator(string expression)
        {
            _expression = expression;
        }

        public string Evaluate()
        {
            var rpn = ReversePolishNotationConverter.Convert(_expression);

            Stack<int> operands = new Stack<int>();
            foreach (var item in rpn)
            {
                if (int.TryParse(item, out int operand))
                {
                    operands.Push(operand);
                }
                else
                {
                    var firstOperand = operands.Pop();
                    var secondOperand = operands.Pop();

                    switch (item)
                    {
                        case "+":
                            operands.Push(secondOperand + firstOperand);
                            break;

                        case "-":
                            operands.Push(secondOperand - firstOperand);
                            break;

                        case "*":
                            operands.Push(firstOperand * secondOperand);
                            break;

                        case "/":
                            try
                            {
                                operands.Push(secondOperand / firstOperand);
                            }
                            catch (DivideByZeroException)
                            {
                                return "error";
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            return operands.Pop().ToString();
        }
    }
}