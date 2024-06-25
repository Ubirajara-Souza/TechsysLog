using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bira.App.TechsysLog.Domain.Interfaces;
using Bira.App.TechsysLog.Service.Interfaces;
using Bira.App.TechsysLog.Domain.Extensions;
using Bira.App.TechsysLog.Domain.DTOs.Request;
using Bira.App.TechsysLog.Domain.DTOs.Response;

namespace Bira.App.TechsysLog.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RequestController : BaseController
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService, INotifier notifier, IUser user) : base(notifier, user)
        {
            _requestService = requestService;
        }

        // Rota para registrar um pedido
        [ClaimsAuthorize("Request", "Add")]
        [HttpPost]
        public async Task<ActionResult<RequestDto>> AddRequest(RequestDto requestDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _requestService.Add(requestDto);

            return CustomResponse(requestDto);
        }

        // Rota para listar todos os pedidos
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<RequestResponse>> GetAll()
            => CustomResponse(await _requestService.GetAll());

        // Rota para registrar a entrega do pedido
        [ClaimsAuthorize("Request", "Update")]
        [HttpPut("finalize/delivery")]
        public async Task<ActionResult<RequestResponse>> FinalizeDelivery([FromQuery] Guid requestId)
            => CustomResponse(await _requestService.FinalizeDelivery(requestId));
    }
}

// obs: poderia utilizar uma tabela de ligação entre entrega e o pedido com a data de entrega e o id do pedido.
// obs: poderia utilizar outros get para obter listas e filtros mais precisos de acordos com a necessidade da aplicação.