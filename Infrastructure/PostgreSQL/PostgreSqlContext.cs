using Domain.Entities;
using Infrastructure.PostgreSQL.ModelBuilders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PostgreSQL
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new ProductEntityTypeConfiguration().Configure(builder.Entity<Product>());
        }

    }
}
