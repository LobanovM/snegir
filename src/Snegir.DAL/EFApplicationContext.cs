using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Snegir.Core.Entities;
using Snegir.Core.Interfaces;
using Snegir.Core.Services;

namespace Snegir.DAL
{
    public class EFApplicationContext: DbContext
    {
        public DbSet<Content> Contents { get; set; } = null!;
        public DbSet<Storage> Storages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Snegir;Username=postgres;Password=db-admin");
            optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }
    }
}
