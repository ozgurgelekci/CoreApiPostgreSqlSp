using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgreSQL.ModelBuilders
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .HasConversion(typeof(string))
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasConversion(typeof(double))
                .IsRequired();
                
        }
    }
}
