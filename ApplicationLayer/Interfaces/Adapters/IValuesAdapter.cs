using ServiceLayer.Enumerations;
using ServiceLayer.Models.Views;

namespace ApplicationLayer.Interfaces.Adapters
{
    public interface IValuesAdapter
    {
        Task<HttpResponseView<T>> ProcessRequestAsync<T>(APIActionType apiActionType, string input) where T : class;
    }
}
