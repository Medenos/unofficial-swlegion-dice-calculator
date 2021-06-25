using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.Extensions
{
    static public class ExtensionClass
    {
        static public string PadCenter(this string sSource, int iLength)
        {
            int spaces = iLength - sSource.Length;
            int padLeft = spaces / 2 + sSource.Length;
            return sSource.PadLeft(padLeft).PadRight(iLength);
        }

        static public string PadCenter(this string sSource, int iLength, char cPaddingChar)
        {
            int spaces = iLength - sSource.Length;
            int padLeft = spaces / 2 + sSource.Length;
            return sSource.PadLeft(padLeft, cPaddingChar).PadRight(iLength, cPaddingChar);
        }
    }
}
