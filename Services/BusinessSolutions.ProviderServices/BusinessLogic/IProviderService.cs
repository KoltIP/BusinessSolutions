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
        Task<IEnumerable<ProviderModel>> GetProviders(int offset = 0, int limit = 1000);
    }
}
