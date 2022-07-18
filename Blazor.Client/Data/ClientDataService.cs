using Blazor.Domain.Dto.Clients.Request;
using Blazor.Domain.Dto.Clients.Response;
using Blazor.Domain.Interfaces.Services;

namespace Blazor.Client.Data
{
    public class ClientDataService
    {
        private readonly IClientService _clientService;
        public List<ClientResponseDto> ListClients { get; private set; } = new List<ClientResponseDto>();
        public bool hasSaved = false;
        public bool sAddClient = false;
        public ClientDataService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public event Action OnChange;


        public void ShowAddClient()
        {
            sAddClient = !sAddClient;
            NotifyStateChanged();
        }

        public async void AddClient(AddClientRequestDto client)
        {
           var response = await _clientService.AddClient(client);
            if (response.Succeed)
            {
                hasSaved = true;
                GetClients();
            }
            else
            {
                hasSaved = false;
            }
        }

        public async void GetClients()
        {
            ListClients.Clear();
            var response = await _clientService.GetAll();
            if (response.Succeed)
            {
                ListClients.AddRange(response.Result);
                NotifyStateChanged();
            }
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
