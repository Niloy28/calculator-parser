namespace CalculatorTests
{
    [TestClass]
    public class ReversePolishNotationTests
    {
        [TestMethod]
        public void RPNTestWithSingleDigitOperandAddition()
        {
            string input = "3+4+5";
            string expected = "34+5+";

            ReversePolishNotationConverter converter = new ReversePolishNotationConverter();
            string actual = string.Join("", converter.Convert(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RPNTestWithSingleDigitOperandMultiplication()
        {
            string input = "3+5*8-6";
            string expected = "358*6-+";

            ReversePolishNotationConverter converter = new ReversePolishNotationConverter();
            string actual = string.Join("", converter.Convert(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RPNTestWithMultipleDigitOperandMultiplication()
        {
            string input = "30+5*10-6";
            string expected = "30510*6-+";

            ReversePolishNotationConverter converter = new ReversePolishNotationConverter();
            string actual = string.Join("", converter.Convert(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RPNTestWithSpacedInput()
        {
            string input = "10 + 10 * 4 / 2";
            string expected = "10104*2/+";

            ReversePolishNotationConverter converter = new ReversePolishNotationConverter();
            string actual = string.Join("", converter.Convert(input));

            Assert.AreEqual(expected, actual);
        }
    }
}