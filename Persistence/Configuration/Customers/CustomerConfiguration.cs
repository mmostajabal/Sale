using Domain.Customers;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);

            builder.OwnsOne(p=>p.Address, addressBuilder=> 
            {
                addressBuilder.Property(p => p.PostalCode).HasMaxLength(10);
                addressBuilder.Property(p => p.Address).HasMaxLength(200);
                
            });


          
        }
    }
}
