using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNet.Basic;
using WaterNet.Utils;

namespace WaterNet.Package
{
    public class ByteObject
    {
        private byte[] data = new byte[] { };

        public ByteObject()
        {
            this.data = new byte[] { };
        }

        public ByteObject(byte[] data) { 
            this.data = data;
        }

        public byte[] Data { get { return data;} }


        public PackageObject ToPackageObject(int id) { 
            return new PackageObject(id, this.data);
        }

        public PackageObject ToPackageObject(int id, bool compress)
        {
            return new PackageObject(id, this.data,compress);
        }







        public int NextVarInt() {
            int value = VarInt.Decode(data);
            int value_long = VarInt.Encode(value).Length;
            this.data = ByteArrayUtils.RemoveFirstBytes(data, value_long);
            return value;
        }

        public long NextVarLong()
        {
            long value = VarLong.Decode(data);
            int value_long = VarLong.Encode(value).Length;
            this.data = ByteArrayUtils.RemoveFirstBytes(data, value_long);
            return value;
        }

        public string NextVarString() {
            string value = VarString.Decode(data);
            int value_long = VarString.Encode(value).Length;
            this.data = ByteArrayUtils.RemoveFirstBytes(data, value_long);
            return value;
        }

        public ushort NextUShort()
        {
            byte[] ushort_data = ByteArrayUtils.TakeFirstBytes(this.data, 2);
            this.data = ByteArrayUtils.RemoveFirstBytes(data, 2);
            return BasicTypes.BytesToUShort(ushort_data);
        }






        public void AddVarInt(int value)
        {
            this.data = ByteArrayUtils.Combine(this.data,VarInt.Encode(value));
        }

        public void AddVarLong(long value)
        {
            this.data = ByteArrayUtils.Combine(this.data, VarLong.Encode(value));
        }

        public void AddVarString(string value)
        {
            this.data = ByteArrayUtils.Combine(this.data, VarString.Encode(value));
        }

        public void AddUShort(ushort value)
        {
            this.data = ByteArrayUtils.Combine(this.data, BasicTypes.UShortToBytes(value));
        }










    }
}
