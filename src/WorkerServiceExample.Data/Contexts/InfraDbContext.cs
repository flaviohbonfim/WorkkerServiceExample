using Microsoft.EntityFrameworkCore;
using WorkerServiceExample.Data.Config;
using WorkerServiceExample.Data.Entities;

namespace WorkerServiceExample.Data.Contexts
{
    public class InfraDbContext : DbContext
    {
        public InfraDbContext(DbContextOptions<InfraDbContext> options) : base(options) { }

        public DbSet<Test> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasIndex(i => i.Number)
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
