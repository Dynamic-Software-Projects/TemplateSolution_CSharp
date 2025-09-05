using ApplicationLayer.Interfaces.Managers;
using ServiceLayer.Interfaces.ModelCreatorService;
using ServiceLayer.Interfaces.ValidationService;
using ServiceLayer.Models.Domain;
using ServiceLayer.Models.Views;

namespace ApplicationLayer.Managers
{
    public class ValuesManager : IValuesManager
    {
        private readonly IInputValidatorService _inputValidator;
        private readonly IValuesModelCreatorService _valuesModelCreator;
        public ValuesManager(IInputValidatorService inputValidator , IValuesModelCreatorService valuesModelCreator)
        {
            _inputValidator = inputValidator;
            _valuesModelCreator = valuesModelCreator;
        }

        public HttpResponseView<InputValidationReportView> ResolveGetValues(string information)
        {
            var response = new HttpResponseView<InputValidationReportView>();  

            var report = _inputValidator.ResolveInputValidation(information);

            response.StatusCode = (report.ErrorCounter > 0) ?System.Net.HttpStatusCode.BadRequest : System.Net.HttpStatusCode.OK;
            response.Message = (report.ErrorCounter > 0 ) ? "Bad Reeuqest" : System.Net.HttpStatusCode.OK.ToString();
           
            response.Payload = new() { };


            return response;    
        }

        public async Task<BaseProcessedValuesAction> CreateValuesObjectAsync(string input)
        {
            InputValidationReportView inputValidationReport = _inputValidator.ResolveInputValidation(input);
            if(inputValidationReport.ErrorCounter > 0)
            {
                return inputValidationReport;
            }

            ValuesObjectView valuesObjectView = _valuesModelCreator.CreateValuesObjectView(input);

            return await Task.FromResult(valuesObjectView);
        } 


    }
}
