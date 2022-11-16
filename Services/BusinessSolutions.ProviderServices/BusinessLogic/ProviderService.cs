using AutoMapper;
using BusinessSolutions.Data.Context;
using BusinessSolutions.ProviderServices.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessSolutions.ProviderServices.BusinessLogic;

public class ProviderService : IProviderService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dbContext;

    public ProviderService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }       

    public async Task<IEnumerable<ProviderModel>> GetProviders(int offset = 0, int limit = 1000)
    {
        var providers = _dbContext.Providers.AsQueryable();
        providers = providers
                    .Distinct()
                    .Skip(Math.Max(offset, 0))
                    .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await providers.ToListAsync()).Select(order => _mapper.Map<ProviderModel>(order));
        return data;
    }
}
