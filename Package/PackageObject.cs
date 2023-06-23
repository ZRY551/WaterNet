using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNet.Basic;
using WaterNet.Utils;

namespace WaterNet.Package
{
    public class PackageObject
    {
        private int package_long = 0;

        public int package_id = 0x00;

        public byte[] package_data = new byte[] { };

        public bool compress = false;

        public PackageObject(int id, byte[] data) { 
            this.package_id = id;
            this.package_data = data;
            this.compress = false;
        }

        public PackageObject(int id, byte[] data,bool compress)
        {
            this.package_id = id;
            this.package_data = data;
            this.compress = compress;
        }

        public byte[] ToBytesArray() {
            if (!this.compress){
                byte[] pkg_id = VarInt.Encode(this.package_id);
                byte[] id_with_data = ByteArrayUtils.Combine(pkg_id,this.package_data);
                byte[] pkg_long = VarInt.Encode(id_with_data.Length);
                byte[] data = ByteArrayUtils.Combine(pkg_long, id_with_data);

                return data;

            }
            else {

                byte[] pkg_id = VarInt.Encode(this.package_id);
                byte[] id_with_data = ByteArrayUtils.Combine(pkg_id, this.package_data);

                byte[] compress_data = ZLibUtils.Compress(id_with_data);
                byte[] compress_long = VarInt.Encode(id_with_data.Length);

                byte[] compress_long_with_data = ByteArrayUtils.Combine(compress_long, compress_data);

                byte[] package_long = VarInt.Encode(compress_long_with_data.Length);
                byte[] data = ByteArrayUtils.Combine(package_long, compress_long_with_data);

                return data;


            }

        }


        public ByteObject ToByteObject() {
            return new ByteObject(this.ToBytesArray());
        }


    }
}
