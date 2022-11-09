using BusinessSolutions.ProviderServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.ProviderServices.BusinessLogic
{
    public interface IProviderService
    {
        Task<ProviderModel> GetProvider(int id);
        Task<IEnumerable<ProviderModel>> GetProviders(int offset = 0, int limit = 1000);
        Task<ProviderModel> AddProvider(AddProviderModel model);
        Task UpdateProvider(int id, UpdateProviderModel model);
        Task DeleteProvider(int id);
    }
}
