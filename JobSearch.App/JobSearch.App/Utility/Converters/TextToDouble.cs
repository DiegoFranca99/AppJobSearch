using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearch.App.Utility.Converters
{
    public class TextToDouble
    {
        public static Double ToDouble(string value)
        {
            if (value != null)
            {
                value = RemoveExtraText(value);
                return Double.Parse(value);
            }
            return 0;

        }

        private static string RemoveExtraText(string value)
        {
            var allowedChars = "0123456789.,";
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
        }

    }
}
