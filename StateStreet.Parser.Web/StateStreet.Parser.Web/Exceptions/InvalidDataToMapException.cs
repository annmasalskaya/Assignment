﻿using System;

namespace StateStreet.Parser.Web.Exceptions
{
    public class InvalidDataToMapException : Exception
    {
        public InvalidDataToMapException()
        {
        }

        public InvalidDataToMapException(string message) : base(message)
        {
        }

        public InvalidDataToMapException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}