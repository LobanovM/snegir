using Microsoft.EntityFrameworkCore;
using Snegir.Core.Entities;

namespace Snegir.DAL
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Content> Contents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Snegir;Username=postgres;Password=db-admin");
        }
    }
}
