using Bira.App.TechsysLog.Domain.DTOs.Request;
using Bira.App.TechsysLog.Domain.DTOs.Response;

namespace Bira.App.TechsysLog.Service.Interfaces
{
    public interface IRequestService : IDisposable
    {
        Task Add(RequestDto requestDto);
        Task<RequestResponse?> FinalizeDelivery(Guid id);
        Task<IEnumerable<RequestResponse>> GetAll();
    }
}
