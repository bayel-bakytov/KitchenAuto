using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using kitchen.Repository.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository
{
    public partial class KitchenDbContext : DbContext
    {
        public KitchenDbContext()
        {
        }

        public KitchenDbContext(DbContextOptions<KitchenDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Budget> Budget { get; set; }
         public virtual DbSet<Employees> Employees { get; set; }
         //public virtual DbSet<Ingr> Ingr { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<ProductionView> ProductionView { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<PurchaseMaterials> PurchaseMaterials { get; set; }
         public virtual DbSet<PurchaseMaterialsView> PurchaseMaterialsView { get; set; }

         public virtual DbSet<SaleProducts> SaleProducts { get; set; }
         public virtual DbSet<SaleProductsView> SaleProductsView { get; set; }
        public virtual DbSet<UnitsOfMeasurement> UnitsOfMeasurement { get; set; }
        //===========================
        public virtual DbSet<Salary> Salary { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=HOME-PC;Initial Catalog=FinishKitchen;Integrated Security=True;User ID = sa;Password=1111;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Phone).IsUnicode(false);

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Post)
                    .HasConstraintName("FK_Employees_Positions");
            });

            modelBuilder.Entity<Ingr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ingr");
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Material)
                    .HasConstraintName("FK_Ingredients_Materials");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Ingredients_Products");
            });
            //понт
            modelBuilder.Entity<Materials>(entity =>
            {
               // entity.Property(e => e.Cost).HasComputedColumnSql("(case when [count]=(0) then (0) else round([price]/[count],(2)) end)");

                entity.HasOne(d => d.UnitOfMeasurementNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.UnitOfMeasurement)
                    .HasConstraintName("FK_Materials_UnitsOfMeasurement");
            });
           /* modelBuilder.Entity<Salary>(entity =>
            {
                // entity.Property(e => e.Cost).HasComputedColumnSql("(case when [count]=(0) then (0) else round([price]/[count],(2)) end)");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.UnitOfMeasurement)
                    .HasConstraintName("FK_Materials_UnitsOfMeasurement");
            });*/

            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Production_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Production_Products");
            });

            modelBuilder.Entity<ProductionView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductionView");
            });
            //понт
            /*modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Sum).HasComputedColumnSql("(round([count]*[price],(2)))");

                entity.HasOne(d => d.UnitOfmeasurementNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitOfmeasurement)
                    .HasConstraintName("FK_Products_UnitsOfMeasurement");
            });*/

            modelBuilder.Entity<PurchaseMaterials>(entity =>
            {
                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.PurchaseMaterials)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Purchase_materials_Employees");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.PurchaseMaterials)
                    .HasForeignKey(d => d.Material)
                    .HasConstraintName("FK_Purchase_materials_Materials");
            });

            modelBuilder.Entity<PurchaseMaterialsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Purchase_materialsView");
            });

            modelBuilder.Entity<SaleProducts>(entity =>
            {
                //entity.Property(e => e.Price).HasComputedColumnSql("([dbo].[ProductCost]([product]))");

                //entity.Property(e => e.Sum).HasComputedColumnSql("([count]*[dbo].[ProductCost]([product]))");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.SaleProducts)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Sale_products_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.SaleProducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Sale_products_Products");
            });

            modelBuilder.Entity<SaleProductsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sale_productsView");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
