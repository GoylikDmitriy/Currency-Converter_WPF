using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace bntu.vsrpp.DGoylik.Core.lab1.xml.exceptions
{
    public class XmlContentException : Exception
    {
        public XmlContentException()
        {
        }

        public XmlContentException(string? message) : base(message)
        {
        }

        public XmlContentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected XmlContentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
