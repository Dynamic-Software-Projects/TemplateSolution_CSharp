
using ApplicationLayer.Interfaces.Adapters;
using ApplicationLayer.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces.HttpService;
using ServiceLayer.Models.Domain;
using ServiceLayer.Models.Views;

namespace ProjectWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        private readonly IHttpResponseService _httpResponseService;
        private readonly IValuesAdapter _valuesAdapter;
      
        public ValuesController(IHttpResponseService httpResponseService , IValuesAdapter valuesAdapter)
        {
            _httpResponseService = httpResponseService;
            _valuesAdapter = valuesAdapter; 
        }



        [Route("success")]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            //string input = "It Works!";
            string input = "";
            var response = await _valuesAdapter.ProcessRequestAsync<object>(ServiceLayer.Enumerations.APIActionType.SavePayloadtoDatabase, input);

            IActionResult actionResult = _httpResponseService.GetHttpResponse(this, response);

            return await Task.FromResult(actionResult);

        }
    }
}
