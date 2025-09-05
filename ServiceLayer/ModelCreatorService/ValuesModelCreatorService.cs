using ServiceLayer.Interfaces.ModelCreatorService;
using ServiceLayer.Models.Views;

namespace ServiceLayer.ModelCreatorService
{
    public class ValuesModelCreatorService : IValuesModelCreatorService
    {
        public ValuesObjectView CreateValuesObjectView(string input)
        {
            return new ValuesObjectView()
            {
                ValueObjectID = Guid.NewGuid(),
                ValueName = input,
                ValueExpirationDateTimeUTC = DateTime.UtcNow
            };
        }
    }
}
