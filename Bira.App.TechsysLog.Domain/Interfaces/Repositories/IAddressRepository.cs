using Bira.App.TechsysLog.Domain.Entities;
using Bira.App.TechsysLog.Domain.Package;

namespace Bira.App.TechsysLog.Domain.Interfaces.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address?> GetAddressByRequest(Guid requestId);
    }
}
