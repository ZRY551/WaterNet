using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNet.Utils
{
    public static class ZLibUtils
    {
        // Use System.IO.Compression for Deflate compression
        public static byte[] Compress(byte[] data)//Microsoft
        {
            MemoryStream uncompressed = new MemoryStream(data); // Here we use data in memory as an example; if you need to compress text, use FileStream
            MemoryStream compressed = new MemoryStream();
            DeflateStream deflateStream = new DeflateStream(compressed, CompressionMode.Compress); // Note: the first parameter here is where the compressed data should be output
            uncompressed.CopyTo(deflateStream); // Use CopyTo to input the data to be compressed at once; you can also use Write for partial input
            deflateStream.Close();  // In Close, the Finish and Flush operations are performed in turn.
            byte[] result = compressed.ToArray();
            return result;
        }
        // Use System.IO.Compression for Deflate decompression
        public static byte[] Decompress(byte[] data)//Microsoft
        {
            MemoryStream compressed = new MemoryStream(data);
            MemoryStream decompressed = new MemoryStream();
            DeflateStream deflateStream = new DeflateStream(compressed, CompressionMode.Decompress); // Note: the first parameter here is also the compressed data, but this time it is as input data
            deflateStream.CopyTo(decompressed);
            byte[] result = decompressed.ToArray();
            return result;
        }

    }
}
