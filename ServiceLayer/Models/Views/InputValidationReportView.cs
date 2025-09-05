using ServiceLayer.Models.Domain;

namespace ServiceLayer.Models.Views
{
    public class InputValidationReportView : BaseProcessedValuesAction
    {
        public int ErrorCounter { get; set; }
        public string InputErrorMessage { get; set; } = string.Empty;
    }
}
