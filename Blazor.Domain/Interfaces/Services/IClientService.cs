using Blazor.Domain.Dto;
using Blazor.Domain.Dto.Clients.Request;
using Blazor.Domain.Dto.Clients.Response;

namespace Blazor.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<ApiListResponseDto<ClientResponseDto>> GetAll();

        Task<EmptyResponseDto> AddClient(AddClientRequestDto dto);

        Task<ApiResponseDto<ClientResponseDto>> Get(int Id);
    }
}
