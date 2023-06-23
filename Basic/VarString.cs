using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNet.Utils;

namespace WaterNet.Basic
{
    public static class VarString
    {
        public static byte[] Encode(string value)
        {
            byte[] string_long = VarInt.Encode(value.Length);
            byte[] string_data = Encoding.UTF8.GetBytes(value);
            return ByteArrayUtils.Combine(string_long,string_data);
        }


        public static string Decode(byte[] bytes) {
            int string_long = VarInt.Decode(bytes);
            int bytes_long = VarInt.Encode(string_long).Length;
            byte[] data = ByteArrayUtils.RemoveFirstBytes(bytes,bytes_long);
            byte[] data_string = ByteArrayUtils.TakeFirstBytes(data, string_long);
            return Encoding.UTF8.GetString(data_string);

        }

    }
}
