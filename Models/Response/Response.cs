using System;
namespace invert_api.Models.Response
{
    public class Response
    {
        public Response(string error)
        {
            Success = false;
            Error = error;
        }
        public Response()
        {
            Success = true;
            Error = null;
        }
        public bool Success { get; set; }
        public string Error { get; set; }

        public static implicit operator Response(void v)
        {
            throw new NotImplementedException();
        }
    }

    public class Response<T>
    {
        public Response(string error)
        {
            Data = default(T);
            Success = false;
            Error = error;
        }

        public Response(T data)
        {
            Data = data;
            Success = true;
            Error = null;
        }
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }

        public static implicit operator Response<T>(void v)
        {
            throw new NotImplementedException();
        }
    }
}
