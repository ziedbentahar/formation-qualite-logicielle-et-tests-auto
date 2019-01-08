using NUnit.Framework;

namespace RomanNumerals.Tests
{
    public class RomanNumeralTests
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        public void Should_produce_roman_numeral_when_the_imput_in_arabic_is_inferior_4(int arabicNumber, string expected)
        {
            string actual = new RomanNumeralConverter().ToRoman(arabicNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(30, "XXX")]
        [TestCase(502, "DII")]
        public void Should_produce_roman_numeral_when_the_imput_in_arabic_is_inferior_1000(int arabicNumber, string expected)
        {
            string actual = new RomanNumeralConverter().ToRoman(arabicNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1003, "MIII")]
        [TestCase(1990, "MCMXC")]
        [TestCase(1903, "MCMIII")]
        public void Should_produce_roman_numeral_when_the_imput_in_arabic_the_imput_roman_numeral_in_arabic_is_equal_or_greater_than_1000(int arabicNumber, string expected)
        {
            string actual = new RomanNumeralConverter().ToRoman(arabicNumber);
            Assert.AreEqual(expected, actual);
        }
    }
}