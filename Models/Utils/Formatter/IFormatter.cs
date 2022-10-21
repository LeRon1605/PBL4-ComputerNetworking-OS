using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Utils.Formatter
{
    public interface IFormatter
    {
        string Format(object value);
    }
}
