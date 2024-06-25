using AutoMapper;
using Bira.App.TechsysLog.Application.Validators;
using Bira.App.TechsysLog.Domain.DTOs.Request;
using Bira.App.TechsysLog.Domain.DTOs.Response;
using Bira.App.TechsysLog.Domain.Entities;
using Bira.App.TechsysLog.Domain.Interfaces.Repositories;
using Bira.App.TechsysLog.Service.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bira.App.TechsysLog.Service.Services
{
    public class RequestService : BaseService, IRequestService
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger _logger;

        public RequestService
        (
            IRequestRepository requestRepository,
            IAddressRepository addressRepository,
            INotifier notifier,
            IMapper mapper,
            ILogger<RequestService> logger
        ) : base(notifier)
        {
            _requestRepository = requestRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Add(RequestDto requestDto)
        {
            var cepConsultado = await ConsultarCepAsync(requestDto.Address);
            if (!cepConsultado)
            {
                Notify("CEP inválido ou não encontrado");
                return;
            }

            var request = _mapper.Map<Request>(requestDto);

            if (!RunValidation(new RequestValidators(), request)
                || !RunValidation(new AddressValidators(), request.Address)) return;

            await _requestRepository.Add(request);
        }
        public async Task<IEnumerable<RequestResponse>> GetAll()
        {
            return _mapper.Map<IEnumerable<RequestResponse>>(await _requestRepository.GetAll());
        }
        public async Task<RequestResponse?> FinalizeDelivery(Guid id)
        {
            var request = await _requestRepository.GetById(id);
            if (request is null)
            {
                Notify("Pedido não encontrado");
                return null;
            }

            if (request.DateDelivery is not null)
            {
                Notify($"O pedido já foi entregue na data {request.DateDelivery.Value.ToString("dd/MM/yyyy")}");
                return null;
            }

            request.DataUpdate = DateTime.Now;
            request.DateDelivery = DateTime.Now;

            await _requestRepository.Update(request);

            // O ideal aqui era ter um Command usando o imediator para disparar para fila
            // o processo de atualizar em tempo real que o pedido foi entregue, não deu tempo desenvolver.

            return _mapper.Map<RequestResponse>(request);
        }
        private async Task<bool> ConsultarCepAsync(AddressDto addressDto)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://viacep.com.br/ws/{addressDto.ZipCode}/json/";

                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var address = JsonConvert.DeserializeObject<ViaCepResponse>(content);

                        if (address is not null)
                        {
                            addressDto.Street = address.Logradouro;
                            addressDto.Neighborhood = address.Bairro;
                            addressDto.City = address.Localidade;
                            addressDto.State = address.Uf;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro ao consultar CEP: {ex.Message}");
            }

            return false;
        }
        public void Dispose()
        {
            _addressRepository.Dispose();
        }
    }
}
