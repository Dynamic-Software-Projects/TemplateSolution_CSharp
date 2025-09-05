using System.Net;

namespace ServiceLayer.Models.Views
{
    public class HttpResponseView<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public T Payload { get; set; }

        public string Uri { get; set; }
    }
}
