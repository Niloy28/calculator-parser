namespace CalculatorTests
{
    [TestClass]
    public class CalculatorOutputTests
    {
        [TestMethod]
        public void SingleDigitOperandsOutputTest()
        {
            string input = "3+8*6";
            string expected = "3+8*6 51";

            Calculator calculator = new Calculator(input);
            string actual = calculator.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleDigitOperandsOutputTest()
        {
            string input = "35*5/5 + 65 - 45";
            string expected = "35*5/5 + 65 - 45 55";

            Calculator calculator = new Calculator(input);
            string actual = calculator.Solve();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FloatOperandsOutputTest()
        {
            string input = "3+8.0*6";
            string expected = "3+8.0*6 error";

            Calculator calculator = new Calculator(input);
            string actual = calculator.Solve();

            Assert.AreEqual(expected, actual);
        }
    }
}