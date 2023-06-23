using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNet
{
    public static class Debug
    {
        public static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 3 + 5);
            hex.Append("[Hex] ");
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString().ToUpper();
        }

        public static void PrintByteArray(byte[] bytes)
        {
            String hex_string = ByteArrayToString(bytes);
            Console.WriteLine(hex_string);

        }


    }
}
