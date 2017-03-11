using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapTileSupport.Services.Interfaces;

namespace MapTileSupport.Services
{
    class BinHexOctService
    {
        static int HexadecimalToDecimal(string origin)
        {
            return int.Parse(origin, System.Globalization.NumberStyles.HexNumber);
        }

        static string DecimalToHexadecimal(int origin, int digit)
        {
            return origin.ToString("X" + digit);
        }

        static double BinaryToDecimal(int digit) {
            return Double.MinValue;
        }

        static double DecimalToBinary(int digit)
        {
            return Double.MinValue;
        }

        static double OctonaryToDecimal(int digit)
        {
            return Double.MinValue;
        }

        static double DecimalToOctonary(int digit)
        {
            return Double.MinValue;
        }     
    }
}
