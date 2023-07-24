using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Name).HasMaxLength(255).IsRequired();
            builder.Property(product => product.Description).HasMaxLength(500).IsRequired();
            builder.Property(product => product.CategoryId).HasMaxLength(255).IsRequired();
            builder.Property(product => product.price).HasMaxLength(55).IsRequired();
        }
    }
}
