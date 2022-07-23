namespace CalculatorParser
{
    public class Operator
    {
        public static readonly Dictionary<string, Operator> Operators = new Dictionary<string, Operator>()
        {
            { "+", new Operator("+", 0, Associativity.LEFT) },
            { "-", new Operator("-", 0, Associativity.RIGHT) },
            { "*", new Operator("*", 5, Associativity.LEFT) },
            { "/", new Operator("/", 5, Associativity.LEFT) },
        };

        public string Symbol { get; private set; }
        public int Precedence { get; private set; }
        public Associativity Associativity { get; private set; }

        private Operator(string symbol, int precedence, Associativity associativity)
        {
            Symbol = symbol;
            Precedence = precedence;
            Associativity = associativity;
        }
    }
}