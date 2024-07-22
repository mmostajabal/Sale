using Domain.Customers;
using Domain.OrderItems;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.Orders
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.TotalPrice, totalPriceBuilder => {
                totalPriceBuilder.Property(p => p.CurrencyCode).HasMaxLength(3);
            });

        }
    }
}
