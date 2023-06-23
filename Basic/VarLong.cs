using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNet.Basic
{
    public static class VarLong
    {
        // Encode a long to a varlong and return it as a byte array
        public static byte[] Encode(long value)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                while ((value & -128) != 0)
                {
                    stream.WriteByte((byte)((value & 127) | 128));
                    value >>= 7;
                }
                stream.WriteByte((byte)value);
                return stream.ToArray();
            }
        }

        // Decode a varlong to a long and return it
        public static long Decode(byte[] bytes)
        {
            long result = 0;
            int shift = 0;
            foreach (byte b in bytes)
            {
                result |= (long)(b & 127) << shift;
                if ((b & 128) != 128) break;
                shift += 7;
            }
            return result;
        }


    }
}
