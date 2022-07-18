using Blazor.Domain.Interfaces.Repositories;

namespace Blazor.Domain.Interfaces.Services
{
    public interface IAppDataService
    {
        IClientRepository Client { get; }
    }
}
