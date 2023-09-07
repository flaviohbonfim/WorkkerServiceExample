using Microsoft.EntityFrameworkCore;
using WorkerServiceExample.Data.Config;
using WorkerServiceExample.Data.Entities;

namespace WorkerServiceExample.Data.Contexts
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options) { }

        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.Name)
                .IsUnique(false);

            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSnakeCaseNamingConvention();
        }
        public override int SaveChanges()
        {
            // Antes de salvar as alterações, configure CreatedAt, ModifiedAt, DeletedAt, etc., conforme necessário.
            return base.SaveChanges();
        }
    }
}
