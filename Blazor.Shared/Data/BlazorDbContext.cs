using Blazor.Domain.Entities;
using Blazor.Domain.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Shared.Data
{
    public class BlazorDbContext : DbContext
    {
        public BlazorDbContext(DbContextOptions<BlazorDbContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }

        public override int SaveChanges()
        {
            AddMissingValues();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddMissingValues();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddMissingValues()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

           

            foreach (var entry in modifiedEntries)
            {
                if (!(entry.Entity is IBaseEntity))
                    continue;

                var entity = entry.Entity as IBaseEntity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }
        }
    }
}
