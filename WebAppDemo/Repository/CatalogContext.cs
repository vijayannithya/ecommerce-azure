using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Respository;

namespace Repository
{
        public class CatalogContext : DbContext
        {
            public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
            {
            }
            public DbSet<Product> CatalogItems { get; set; }
            public DbSet<Category> CatalogType { get; set; }
            
            protected override void OnModelCreating(ModelBuilder builder)
            {
                //builder.Entity<CatalogBrand>(ConfigureCatalogBrand);
                builder.Entity<Category>(ConfigureCatalogType);
                builder.Entity<Product>(ConfigureCatalogItem);
            }

            void ConfigureCatalogItem(EntityTypeBuilder<Product> builder)
            {
                builder.ToTable("Products");

                builder.Property(ci => ci.ProductId)
                    .IsRequired();

                builder.Property(ci => ci.ProductName)
                    .IsRequired(true)
                    .HasMaxLength(50);

                builder.Property(ci => ci.Price)
                    .IsRequired(true);

                builder.Property(ci => ci.Qty)
                    .IsRequired(false);

                builder.HasOne(ci => ci.Category)
                    .WithMany()
                    .HasForeignKey(ci => ci.CategoryId);
            }



        void ConfigureCatalogType(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(ci => ci.CategoryId);

            builder.Property(ci => ci.CategoryId)
              // .ForSqlServerUseSequencehilo("Categories_hilo")
               .IsRequired();

            builder.Property(cb => cb.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
    }

