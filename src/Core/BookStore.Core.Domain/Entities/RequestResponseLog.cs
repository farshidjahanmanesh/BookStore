using BookStore.Core.Domain.Common;

namespace BookStore.Core.Domain.Entities
{
    public class RequestResponseLog : Entity<int>
    {
        protected RequestResponseLog(string url, string requestData, string responseData)
        {
            Url = url;
            RequestData = requestData;
            ResponseData = responseData;
        }
        public string Url { get; private set; }
        public string RequestData { get; private set; }
        public string ResponseData { get; private set; }
        public static RequestResponseLog Create(string url, string requestData, string responseData) => new RequestResponseLog(url, requestData, responseData);
    }
}
