using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            ValidationErrors = new List<string>();
            Status = true;
        }
        public BaseResponse(string message) : base()
        {
            this.Message = message;
        }
        public BaseResponse(bool status, string message = default)
        {
            this.Status = status;
            this.Message = message;
            ValidationErrors = new List<string>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
        public string URL { get; set; }
        public string Method { get; set; }
    }
}
