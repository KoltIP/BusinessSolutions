using BusinessSolutions.ProviderServices.Models;

namespace BusinessSolutions.ProviderServices.BusinessLogic;

public interface IProviderService
{
    Task<IEnumerable<ProviderModel>> GetProviders(int offset = 0, int limit = 1000);
}
