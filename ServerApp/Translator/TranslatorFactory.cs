using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Translator
{
    public static class TranslatorFactory
    {
        private static ITranslator vietnamTranslator;
        private static ITranslator engLishTranslator;
        private static ITranslator spanishTranslator;
        private static ITranslator frenchTranslator;
        public static ITranslator GetInstance(string lang)
        {
            if (lang == "vi")
            {
                if (vietnamTranslator == null)
                {
                    vietnamTranslator = new VietnameseTranslator();
                }
                return vietnamTranslator;
            }
            else if (lang == "en")
            {
                if (engLishTranslator == null)
                {
                    engLishTranslator = new EnglishTranslator();
                }
                return engLishTranslator;
            }
            else if (lang == "sp")
            {
                if (spanishTranslator == null)
                {
                    spanishTranslator = new SpanishTranslator();
                }
                return spanishTranslator;
            }
            else if (lang == "fr")
            {
                if (frenchTranslator == null)
                {
                    frenchTranslator = new FrenchTranslator();
                }
                return frenchTranslator;
            }
            return null;
        }
    }
}
