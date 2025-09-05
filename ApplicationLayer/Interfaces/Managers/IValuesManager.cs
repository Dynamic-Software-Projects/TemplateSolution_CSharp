using ServiceLayer.Models.Domain;

namespace ApplicationLayer.Interfaces.Managers
{
    public interface IValuesManager
    {
        Task<BaseProcessedValuesAction> CreateValuesObjectAsync(string input);
    }
}
