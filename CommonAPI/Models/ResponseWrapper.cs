using System;

namespace CommonAPI.Models
{
    public class ResponseWrapper
    {
        public bool IsSuccess { get; set; }

        public TimeSpan ProcessingTime { get; set; }

        public ResponseError Error { get; set; }
    }

    public class ResponseWrapper<T> : ResponseWrapper
    {
        public T Data { get; set; }
    }

    public class ResponseError
    {
        public string Message { get; set; }

        public bool IsLogicError { get; set; }
    }
}
