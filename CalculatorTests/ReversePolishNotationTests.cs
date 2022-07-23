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

            string actual = string.Join("", ReversePolishNotationConverter.Convert(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RPNTestWithSingleDigitOperandMultiplication()
        {
            string input = "3+5*8-6";
            string expected = "358*6-+";

            string actual = string.Join("", ReversePolishNotationConverter.Convert(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RPNTestWithMultipleDigitOperandMultiplication()
        {
            string input = "30+5*10-6";
            string expected = "30510*6-+";

            string actual = string.Join("", ReversePolishNotationConverter.Convert(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RPNTestWithSpacedInput()
        {
            string input = "10 + 10 * 4 / 2";
            string expected = "10104*2/+";

            string actual = string.Join("", ReversePolishNotationConverter.Convert(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RPNTestWithNegativeOperands()
        {
            string input = "1+2*-(4/2)";
            string expected = "12-42/*+";

            string actual = string.Join("", ReversePolishNotationConverter.Convert(input));

            Assert.AreEqual(expected, actual);
        }
    }
}