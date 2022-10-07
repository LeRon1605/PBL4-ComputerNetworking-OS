using ServerApp.Translator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.TranslatorTest
{
    public class EnglishTranslatorTest : ITranslatorTest
    {
        private readonly ITranslator translator;
        public EnglishTranslatorTest()
        {
            translator = new EnglishTranslator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("1a3")]
        [InlineData("_12@3")]
        public void GivenInvalidNumber_WhenTranslate_ThenShouldReturnNull(string number)
        {
            string actual = translator.Translate(number);

            Assert.Null(actual);
        }

        [Theory]
        [InlineData("1234", "One thousand, Two hundred thirty-four")]
        [InlineData("1200200", "One million, Two hundred thousand, Two hundred")]
        [InlineData("1234567891", "One billion, Two hundred, Thirty-four million, Five hundred sixty-seven thousand, Eight hundred ninety-one")]
        [InlineData("1200000", "One million, Two hundred thousand")]
        [InlineData("1000002", "One million, Two")]
        public void GivenLargeNumber_WhenTranslate_ThenShouldWork(string number, string expected)
        {
            string actual = translator.Translate(number);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0", "Zero")]
        [InlineData("01", "One")]
        [InlineData("010", "Ten")]
        [InlineData("0000123456", "One hundred twenty-three thousand, Four hundred fifty-six")]
        public void GivenLeadZeroNumber_WhenTranslate_ThenShouldWork(string number, string expected)
        {
            string actual = translator.Translate(number);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1", "One")]
        [InlineData("12", "Twelve")]
        [InlineData("10", "Ten")]
        [InlineData("11", "Eleven")]
        [InlineData("15", "fifteen")]
        [InlineData("125", "One hundred twenty-five")]
        [InlineData("101", "One hundred one")]
        public void GivenSimpleNumber_WhenTranslate_ThenShouldWork(string number, string expected)
        {
            string actual = translator.Translate(number);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("10", "Ten")]
        [InlineData("100", "One hundred")]
        [InlineData("1000", "One thousand")]
        [InlineData("1000000", "One million")]
        [InlineData("1000000000", "One billion")]
        public void GivenTailZeroNumber_WhenTranslate_ThenShouldWork(string number, string expected)
        {
            string actual = translator.Translate(number);

            Assert.Equal(expected, actual);
        }
    }
}
