using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public bool Succeed { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public GenericResponse() { }
        public GenericResponse(T data, string message = null)
        {
            Data = data;
            Succeed = true;
            Message = message;
        }
        public GenericResponse(string message, int statusCode)
        {
            Succeed = false;
            Message = message;
            StatusCode = statusCode;
        }
        public GenericResponse(IEnumerable<string> errors, int statusCode)
        {
            Succeed = false;
            Errors = errors;
            StatusCode = statusCode;
        }
    }
}
