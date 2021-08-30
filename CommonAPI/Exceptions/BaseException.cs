using System;

namespace CommonAPI.Exceptions
{
    public class BaseException : ApplicationException
    {
        public BaseException() : base()
        {
        }
        public BaseException(string message) : base(message)
        {
        }
        public BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
