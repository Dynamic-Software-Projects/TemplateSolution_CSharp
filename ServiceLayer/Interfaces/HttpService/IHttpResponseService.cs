using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Models.Views;

namespace ServiceLayer.Interfaces.HttpService
{
    public interface IHttpResponseService
    {
        IActionResult GetHttpResponse<T>(ControllerBase controllerBase, HttpResponseView<T> httpResponseView) where T : class;
    }
}
