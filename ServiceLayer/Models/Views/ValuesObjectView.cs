using ServiceLayer.Models.Domain;

namespace ServiceLayer.Models.Views
{
    public class ValuesObjectView : BaseProcessedValuesAction
    {
        public Guid ValueObjectID { get; set; }
        public string ValueName { get; set; } = string.Empty;

        public DateTime ValueExpirationDateTimeUTC { get; set; }
    }
}
