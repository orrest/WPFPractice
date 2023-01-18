using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LocalSQLDBDemo.Models;

namespace LocalSQLDBDemo.Services
{
    class ProductEntityConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(o => o.CategoryId);
        }
    }
}
