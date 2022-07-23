namespace CalculatorParser
{
    public class Calculator
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
                return string.Format("{0} error", _expression);
            }

            ExpressionEvaluator expressionEvaluator = new ExpressionEvaluator(_expression);
            return string.Format("{0} {1}", _expression, expressionEvaluator.Evaluate());
        }
    }
}