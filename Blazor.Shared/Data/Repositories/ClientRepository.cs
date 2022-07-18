using Blazor.Domain.Entities;
using Blazor.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Shared.Data.Repositories
{
    internal class ClientRepository : RepositoryBase<Client, BlazorDbContext>, IClientRepository
    {
        public ClientRepository(IDbContextFactory<BlazorDbContext> context) : base(context)
        {
        }
    }
}
