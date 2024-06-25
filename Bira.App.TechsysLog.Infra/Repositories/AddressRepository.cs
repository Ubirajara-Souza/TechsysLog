using Bira.App.TechsysLog.Domain.Entities;
using Bira.App.TechsysLog.Domain.Interfaces.Repositories;
using Bira.App.TechsysLog.Infra.Repositories.BaseContext;
using Microsoft.EntityFrameworkCore;

namespace Bira.App.TechsysLog.Infra.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApiDbContext _context) : base(_context) { }
        public async Task<Address?> GetAddressByRequest(Guid requestId)
        {
            return await Context.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(p => p.RequestId == requestId);

        }
    }
}
