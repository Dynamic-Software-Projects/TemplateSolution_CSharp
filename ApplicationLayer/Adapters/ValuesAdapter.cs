using ApplicationLayer.Interfaces.Adapters;
using ApplicationLayer.Interfaces.Managers;
using ServiceLayer.Enumerations;
using ServiceLayer.Interfaces.ModelCreatorService;
using ServiceLayer.Models.Domain;
using ServiceLayer.Models.Views;
using System.Net;

namespace ApplicationLayer.Adapters
{
    public class ValuesAdapter :IValuesAdapter
    {

        private const string errorMessage = "Unexpected response type";
        private const string exceptionMessage = "An error occurred while processing the request.";

        private readonly IValuesManager _valuesManager;
        private readonly IHttpResponseCreatorService _httpResponseCreatorService;

        public ValuesAdapter(IValuesManager valuesManager , IHttpResponseCreatorService httpResponseCreatorService)
        {
            _valuesManager = valuesManager;
            _httpResponseCreatorService = httpResponseCreatorService;
        }

        public async Task<HttpResponseView<T>> ProcessRequestAsync<T>(APIActionType apiActionType, string input) where T : class
        {
            try
            {
                BaseProcessedValuesAction baseProcessedValuesAction = await ResolveApiActionTypeAsync(apiActionType, input);
               
                if(baseProcessedValuesAction is InputValidationReportView inputValidationReportView)
                {
                    HttpResponseView<T> badRequestResponse = _httpResponseCreatorService.CreateHttpResponseView(HttpStatusCode.BadRequest,HttpStatusCode.BadRequest.ToString(), inputValidationReportView as T);

                    return await Task.FromResult( badRequestResponse);
                }

                if (baseProcessedValuesAction is ValuesObjectView valuesObjectView)
                {
                    HttpResponseView<T> valuesObjectResponse = _httpResponseCreatorService.CreateHttpResponseView(HttpStatusCode.OK, HttpStatusCode.OK.ToString(), valuesObjectView as T);

                    return await Task.FromResult(valuesObjectResponse);
                }
               
                var errorResponse = _httpResponseCreatorService.CreateHttpResponseView<T>(HttpStatusCode.InternalServerError, errorMessage, null);
        
                return errorResponse;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.Error.WriteLine($"Error in ProcessRequestAsync: {ex.Message}");                
                var exceptionResponse = _httpResponseCreatorService.CreateHttpResponseView<T>( HttpStatusCode.InternalServerError, exceptionMessage, null );

                return exceptionResponse;
            }
        }



        #region Private Methods
        private async Task<BaseProcessedValuesAction> ResolveApiActionTypeAsync(APIActionType apiActionType , string input)
        {
            BaseProcessedValuesAction processedValuesAction = null;
            switch (apiActionType)
            {
                case APIActionType.SavePayloadtoDatabase:
                    processedValuesAction = await _valuesManager.CreateValuesObjectAsync(input);
                    break;
            }

            return processedValuesAction;
        }


        #endregion Private Methods 
    }
}
