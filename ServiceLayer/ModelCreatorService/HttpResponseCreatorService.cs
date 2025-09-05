using ServiceLayer.Interfaces.ModelCreatorService;
using ServiceLayer.Models.Views;
using System.Net;

namespace ServiceLayer.ModelCreatorService
{
    public class HttpResponseCreatorService : IHttpResponseCreatorService
    {

        public HttpResponseView<T> CreateHttpResponseView<T>(HttpStatusCode statusCode, string message, T payload) where T : class
        {
            return new HttpResponseView<T>()
            {
                StatusCode = statusCode,
                Message = message,
                Payload = payload
            };
        }
    }
}
