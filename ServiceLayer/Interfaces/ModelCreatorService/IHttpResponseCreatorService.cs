using ServiceLayer.Models.Views;
using System.Net;

namespace ServiceLayer.Interfaces.ModelCreatorService
{
    public interface IHttpResponseCreatorService
    {
        HttpResponseView<T> CreateHttpResponseView<T>(HttpStatusCode statusCode, string message, T payload) where T : class;
    }
}
