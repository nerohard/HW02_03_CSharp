using System;

namespace HW02_03.Exceptions
{
    class InvalidAgeException : Exception
    {
        private string _Message = "Error! The age is not valid!";

        public InvalidAgeException() { }
        public InvalidAgeException(string message) : base(message) { _Message = message; }
        public InvalidAgeException(string message, Exception inner) : base(message, inner) { _Message = message; }

        public override string Message
        {
            get { return _Message; }
        }
    }
}
