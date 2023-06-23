using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNet.Utils;

namespace WaterNet.Basic
{
    public static class BasicTypes
    {
        public static byte[] UShortToBytes(ushort value)
        {
            return EndianUtils.LittleEndianToBigEndian(BitConverter.GetBytes(value));
        }

        public static ushort BytesToUShort(byte[] bytes)
        {
            return BitConverter.ToUInt16(EndianUtils.Reverse(bytes), 0);
        }

        public static byte[] UShortToBytes_Bit(ushort value)
        {
            byte[] bytes = new byte[2]; 
            bytes[0] = (byte)(value >> 8); // get High
            bytes[1] = (byte)(value & 0xff); // get Low
            return bytes;
        }

        public static ushort BytesToUShort_Bit(byte[] bytes)
        {
            ushort value = 0; // create a ushort value
            value |= (ushort)(bytes[0] << 8); // set the high byte
            value |= (ushort)(bytes[1]); // set the low byte
            return value; // return the ushort value
        }


    }
}
