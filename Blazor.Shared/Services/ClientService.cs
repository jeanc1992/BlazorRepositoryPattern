using Blazor.Domain.Dto;
using Blazor.Domain.Dto.Clients.Request;
using Blazor.Domain.Dto.Clients.Response;
using Blazor.Domain.Entities;
using Blazor.Domain.Interfaces.Services;

namespace Blazor.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IAppDataService _appDataService;
        public ClientService(IAppDataService appDataService)
        {
            _appDataService = appDataService;
        }

        public async Task<EmptyResponseDto> AddClient(AddClientRequestDto dto)
        {

            var client = new Client()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                CreatedAt = DateTime.Now
            };

            var result = await  _appDataService.Client.Add(client);
            return new EmptyResponseDto(result);
        }

        public async Task<ApiResponseDto<ClientResponseDto>> Get(int id)
        {
            var clientResponse = new ApiResponseDto<ClientResponseDto>();

            var client = await _appDataService.Client.FirstOrDefaultAsync(r => r.Id == id);

            clientResponse.Result = new ClientResponseDto
            {
                Id = client.Id,
                CreatedAt = client.CreatedAt,
                Email =client.Email,
                Name = client.Name,
                Phone = client.Phone
            };

            return clientResponse;

        }

        public async Task<ApiListResponseDto<ClientResponseDto>> GetAll()
        {
            var response = new ApiListResponseDto<ClientResponseDto>();

            var clients = await _appDataService.Client.GetAllAsync();
            response.Result.AddRange(
                clients.Select(item => new ClientResponseDto
                {
                    CreatedAt = item.CreatedAt,
                    Email = item.Email,
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone
                }));

            return response;
        }
    }
}
