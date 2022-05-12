using BookStore.Core.Application.Contracts;
using System.Collections.Generic;

namespace BookStore.API.REST.Models
{
    public class RestResponse : IBaseResponse
    {
        public string URL { get; set; }
        public string Method { get; set; }
        public bool Status { get; set; }
        public object Result { get; set; }
    }
    public class RestErrorResponse
    {
        public string URL { get; set; }
        public string Method { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
