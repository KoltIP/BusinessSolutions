using BusinessSolutions.ProviderServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.ProviderServices.BusinessLogic
{
    public class ProviderService : IProviderService
    {
        public Task<ProviderModel> AddProvider(AddProviderModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProvider(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProviderModel> GetProvider(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProviderModel>> GetProviders(int offset = 0, int limit = 1000)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProvider(int id, UpdateProviderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
