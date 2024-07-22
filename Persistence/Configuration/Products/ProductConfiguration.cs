using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.Products
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p=>p.ProductName).HasMaxLength(150).IsRequired();

            builder.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(p => p.CurrencyCode).HasMaxLength(3);
            });

        }
    }
}
