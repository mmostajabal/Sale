using Domain.OrderItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.OrderItems
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.Quantity, quantityBuilder =>
            {
                quantityBuilder.Property(p => p.QuantityCode).HasMaxLength(3);
            });

            builder.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(p=>p.CurrencyCode).HasMaxLength(3);   
            });

        }
    }
}
