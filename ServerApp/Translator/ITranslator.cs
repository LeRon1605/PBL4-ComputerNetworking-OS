using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Translator
{
    public interface ITranslator
    {
        string Translate(string number);
    }
}
