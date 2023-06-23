using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNet.Errors
{
    internal class Errors
    {
    }

    public class PackageParsingException : Exception {
        public PackageParsingException() { }
        public PackageParsingException(string message) : base(message) { }
        public PackageParsingException(string message, Exception inner) : base(message, inner) { }
    }

    public class CompressionParsingException : Exception
    {
        public CompressionParsingException() { }
        public CompressionParsingException(string message) : base(message) { }
        public CompressionParsingException(string message, Exception inner) : base(message, inner) { }
    }



}
