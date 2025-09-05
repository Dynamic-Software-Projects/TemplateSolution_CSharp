using ServiceLayer.Models.Views;

namespace ServiceLayer.Interfaces.ModelCreatorService
{
    public interface IValuesModelCreatorService
    {
        ValuesObjectView CreateValuesObjectView(string input);
    }
}
