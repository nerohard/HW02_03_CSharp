using System;

namespace HW02_03.Exceptions
{
    class InvalidEmailException : Exception
    {
        private string _Message = "Error! The email is not valid!";

        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { _Message = message; }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { _Message = message; }

        public override string Message
        {
            get { return _Message; }
        }
    }
}
