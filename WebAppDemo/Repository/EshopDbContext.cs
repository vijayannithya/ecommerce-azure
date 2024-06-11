using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Respository {

    public partial class EshopDbContext : DbContext
    {
        public EshopDbContext()
        {
        }

        public EshopDbContext(DbContextOptions<EshopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=eshopdbserver.database.windows.net;Initial Catalog=EShopDB;Persist Security Info=False;User ID=sqluser;Password=user123#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.HasKey(e => e.CategoryId).HasName("PK__Categori__D54EE9B4BEB9114E");

            //    entity.Property(e => e.CategoryId).HasColumnName("category_id");
            //    entity.Property(e => e.CategoryName)
            //        .HasMaxLength(255)
            //        .IsUnicode(false)
            //        .HasColumnName("category_name");
            //});

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.HasKey(e => e.ProductId).HasName("PK__Products__47027DF5F901DCB6");

            //    entity.Property(e => e.ProductId).HasColumnName("product_id");
            //    entity.Property(e => e.CategoryId).HasColumnName("category_id");
            //    entity.Property(e => e.Price)
            //        .HasColumnType("decimal(10, 2)")
            //        .HasColumnName("price");
            //    entity.Property(e => e.ProductName)
            //        .HasMaxLength(255)
            //        .IsUnicode(false)
            //        .HasColumnName("product_name");

            //    entity.HasOne(d => d.Category).WithMany(p => p)
            //        .HasForeignKey(d => d.CategoryId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__Products__catego__5EBF139D");
            //});

            //OnModelCreatingPartial(modelBuilder);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EshopDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}