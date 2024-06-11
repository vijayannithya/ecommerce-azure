using System.Linq;
using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions options) : base(options) { }

        //Products
        public DbSet<CatalogItem> Catalogs { get; set; }
       
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            builder.Entity<CatalogItem>(ConfigureCatalogItem);
        }
        void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            //builder.ToTable("products");

            builder.HasKey(ci => ci.Id);
               

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Description)
               .IsRequired(false)
               .HasMaxLength(80);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.Qty)
                .IsRequired(false);

            
            

            
        }

    }
}