using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNet.Utils
{
    public static class ByteArrayUtils
    {
        // Concatenate two byte arrays and return the result
        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] bytes = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, bytes, 0, first.Length);
            Buffer.BlockCopy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }

        // Remove first n bytes from a byte array and return the result
        public static byte[] RemoveFirstBytes(byte[] bytes, int n)
        {
            if (n >= bytes.Length) return new byte[0]; // Nothing to return
            byte[] result = new byte[bytes.Length - n];
            Buffer.BlockCopy(bytes, n, result, 0, result.Length);
            return result;
        }

        // Take first n bytes from a byte array and return the result
        public static byte[] TakeFirstBytes(byte[] bytes, int n)
        {
            if (n >= bytes.Length) return bytes; // Nothing to take
            return bytes.Take(n).ToArray();
        }
    }
}
