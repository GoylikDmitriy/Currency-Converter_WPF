using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace bntu.vsrpp.DGoylik.Core.lab1.xml.exceptions
{
    internal class XmlIOException : Exception
    {
        public XmlIOException()
        {
        }

        public XmlIOException(string? message) : base(message)
        {
        }

        public XmlIOException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected XmlIOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
