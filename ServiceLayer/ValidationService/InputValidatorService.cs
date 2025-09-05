using ServiceLayer.Interfaces.ValidationService;
using ServiceLayer.Models.Views;

namespace ServiceLayer.ValidationService
{
    public class InputValidatorService : IInputValidatorService
    {
        public InputValidationReportView ResolveInputValidation(string input)
        {
            var report = new InputValidationReportView();
           
            if(string.IsNullOrWhiteSpace(input))
            {
                report.InputErrorMessage = "input is Null or Empty";
                report.ErrorCounter++;
            }

            return report;
        }
    }
}
