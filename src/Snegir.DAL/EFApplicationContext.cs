using Microsoft.EntityFrameworkCore;
using Snegir.Core.Entities;
using Snegir.Core.Interfaces;

namespace Snegir.DAL
{
    public class EFApplicationContext: DbContext
    {
        public DbSet<Content> Contents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Snegir;Username=postgres;Password=db-admin");
        }
    }
}
