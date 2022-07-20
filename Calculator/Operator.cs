using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorParser
{
    public class Operator : IComparable<Operator>
    {
        public String Symbol { get; private set; }
        public Associativity Associativity { get; private set; }
        public int Precedence { get; private set; }

        public Operator(string symbol, Associativity associativity, int precedence)
        {
            Associativity = associativity;
            Symbol = symbol;
            Precedence = precedence;
        }

        public int CompareTo(Operator? @operator)
        {
            if (@operator == null) throw new ArgumentNullException(nameof(@operator));

            return this.Precedence.CompareTo(@operator.Precedence);
        }
    }
}
