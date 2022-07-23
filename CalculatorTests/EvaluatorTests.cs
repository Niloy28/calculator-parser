namespace CalculatorTests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void SingleDigitOperandsEvaluateTest()
        {
            string input = "3+8*6";
            string expected = "51";

            ExpressionEvaluator expressionParser = new ExpressionEvaluator(input);
            string actual = expressionParser.Evaluate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleDigitOperandsEvaluateTest()
        {
            string input = "30+6*10/2";
            string expected = "60";

            ExpressionEvaluator expressionParser = new ExpressionEvaluator(input);
            string actual = expressionParser.Evaluate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideByZeroEvaluateTest()
        {
            string input = "30+6*10/0";
            string expected = "error";

            ExpressionEvaluator expressionParser = new ExpressionEvaluator(input);
            string actual = expressionParser.Evaluate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegativeOperandEvaluateTest()
        {
            string input = "30+(-6)*10/2";
            string expected = "0";

            ExpressionEvaluator expressionParser = new ExpressionEvaluator(input);
            string actual = expressionParser.Evaluate();

            Assert.AreEqual(expected, actual);
        }
    }
}