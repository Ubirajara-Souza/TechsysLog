using Bira.App.TechsysLog.Domain.Entities;
using Bira.App.TechsysLog.Domain.Interfaces.Repositories;
using Bira.App.TechsysLog.Infra.Repositories.BaseContext;

namespace Bira.App.TechsysLog.Infra.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApiDbContext _context) : base(_context) { }
    }
}
