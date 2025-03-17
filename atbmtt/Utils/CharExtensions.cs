using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atbmtt.Utils
{
    public static class CharExtensions
    {
        public static bool IsUpperCase(this char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        public static bool IsLowerCase(this char c)
        {
            return c >= 'a' && c <= 'z';
        }

        public static bool IsLetter(this char c)
        {
            return c.IsUpperCase() || c.IsLowerCase();
        }

        public static bool IsDigit(this char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
