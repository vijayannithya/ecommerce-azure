using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Models;

namespace ProductAPI { 
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

                builder.Property(ci => ci.product_id)
                    .IsRequired();

                builder.Property(ci => ci.product_name)
                    .IsRequired(true)
                    .HasMaxLength(50);

                builder.Property(ci => ci.price)
                    .IsRequired(true);

                builder.Property(ci => ci.qty)
                    .IsRequired(false);

                //builder.HasOne(ci => ci.Categories)
                //    .WithMany()
                //    .HasForeignKey(ci => ci.category_id);
            }



        void ConfigureCatalogType(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            //builder.HasKey(ci => ci.category_id);

            builder.Property(ci => ci.category_id)
              // .ForSqlServerUseSequencehilo("Categories_hilo")
               .IsRequired();

            builder.Property(cb => cb.category_name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
    }

