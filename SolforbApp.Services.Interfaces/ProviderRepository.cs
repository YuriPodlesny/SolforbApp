using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using SolforbApp.Infrastructure.Data;
using SolforbApp.Infrastructure.Data.Repository;

namespace SolforbApp.Services.Repository
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(SolforbDbContext context) : base(context)
        {
        }
    }
}
