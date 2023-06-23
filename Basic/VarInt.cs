using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNet.Basic
{
    public static class VarInt
    {
        // Encode an int to a varint and return it as a byte array
        public static byte[] Encode(int value)
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

        // Decode a varint to an int and return it
        public static int Decode(byte[] bytes)
        {
            int result = 0;
            int shift = 0;
            foreach (byte b in bytes)
            {
                result |= (b & 127) << shift;
                if ((b & 128) != 128) break;
                shift += 7;
            }
            return result;
        }
    }
}
