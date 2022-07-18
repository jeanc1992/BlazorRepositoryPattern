using Blazor.Domain.Interfaces.Repositories;
using Blazor.Domain.Interfaces.Services;

namespace Blazor.Shared.Services
{
    public class AppDataService : IAppDataService
    {
        public IClientRepository Client { get; }


        public AppDataService(
            IClientRepository client)
        {
            Client = client;
        }
    }
}
