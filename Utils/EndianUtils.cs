using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNet.Utils
{
    public static class EndianUtils
    {
        public static byte[] LittleEndianToBigEndian(byte[] bytes) {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }

        public static byte[] Reverse(byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }
    }
}
