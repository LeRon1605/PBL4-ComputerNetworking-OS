using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.TranslatorTest
{
    public interface ITranslatorTest
    {
        void GivenSimpleNumber_WhenTranslate_ThenShouldWork(string number, string expected);
        void GivenLargeNumber_WhenTranslate_ThenShouldWork(string number, string expected);
        void GivenInvalidNumber_WhenTranslate_ThenShouldReturnNull(string number);
        void GivenLeadZeroNumber_WhenTranslate_ThenShouldWork(string number, string expected);
        void GivenTailZeroNumber_WhenTranslate_ThenShouldWork(string number, string expected);
    }
}
