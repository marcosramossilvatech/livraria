using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Livraria.Infrastructure.Context
{
    public class LivrariaDbContext : DbContext
    {
        public LivrariaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Categoria> Categories { get; set; }
        public DbSet<Livro> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivrariaDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
