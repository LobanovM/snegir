using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Snegir.Core.Entities;

namespace Snegir.DAL
{
    public class EFApplicationContext: DbContext
    {
        public DbSet<Content> Contents { get; set; } = null!;
        public DbSet<Storage> Storages { get; set; } = null!;

        public EFApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }
    }
}
