using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skinet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImageUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(b => b.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(t => t.ProductTypeId);
        }
    }
}
