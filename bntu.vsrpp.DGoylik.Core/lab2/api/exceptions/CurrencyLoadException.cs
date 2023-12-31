﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace bntu.vsrpp.DGoylik.Core.lab2.api.exceptions
{
    public class CurrencyLoadException : Exception
    {
        public CurrencyLoadException()
        {
        }

        public CurrencyLoadException(string? message) : base(message)
        {
        }

        public CurrencyLoadException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CurrencyLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
