using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces.HttpService;
using ServiceLayer.Models.Views;
using System.Net;
namespace ServiceLayer.HttpService
{
    public class HttpResponseService :IHttpResponseService  
    {
        private const int error500 = 500; 
        public IActionResult GetHttpResponse<T>(ControllerBase controllerBase , HttpResponseView<T> httpResponseView ) where T : class
        {
            switch (httpResponseView.StatusCode )
            {
                #region 2xx: Success
 
                case HttpStatusCode.OK:
                    return controllerBase.Ok(httpResponseView);

                case HttpStatusCode.Created:
                    return controllerBase.Created(httpResponseView.Uri, httpResponseView.Payload);
                #endregion 2xx: Success

                #region 3xx: Redirection

                case HttpStatusCode.Redirect:
                    return controllerBase.Redirect(httpResponseView.Uri);

                #endregion 3xx: Redirection

                #region 4xx: Client Error
    
                case HttpStatusCode.BadRequest:
                    return controllerBase.BadRequest(httpResponseView);

                case HttpStatusCode.Unauthorized:
                    return controllerBase.Unauthorized();
                  

                case HttpStatusCode.Forbidden:
                    return controllerBase.Forbid();
                  

                    case HttpStatusCode.NotFound:
                        return controllerBase.NotFound();

                #endregion 4xx: Client Error

                #region 5xx: Server Error
                case HttpStatusCode.InternalServerError:
                    return controllerBase.StatusCode(error500, httpResponseView);

                default:
                    return controllerBase.StatusCode(error500, httpResponseView);

                #endregion 5xx: Server Error
            }
        }
    }
}
