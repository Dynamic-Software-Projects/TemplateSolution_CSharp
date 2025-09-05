using ServiceLayer.Models.Views;

namespace ServiceLayer.Interfaces.ValidationService
{
    public interface IInputValidatorService
    {
        InputValidationReportView ResolveInputValidation(string input);
    }
}
