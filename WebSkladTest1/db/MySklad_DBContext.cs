using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class MySklad_DBContext : DbContext
    {
        public MySklad_DBContext()
        {
        }

        public MySklad_DBContext(DbContextOptions<MySklad_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CrossOrderOut> CrossOrderOuts { get; set; }
        public virtual DbSet<CrossProductOrder> CrossProductOrders { get; set; }
        public virtual DbSet<CrossProductRack> CrossProductRacks { get; set; }
        public virtual DbSet<OrderIn> OrderIns { get; set; }
        public virtual DbSet<OrderOut> OrderOuts { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Rack> Racks { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<WriteOffRegister> WriteOffRegisters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2KIP198\\SQLEXPRESS;Initial Catalog=MySklad_DB;Trusted_Connection=True; User=dbo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image).HasMaxLength(50).IsUnicode(false);

                entity.Property(e => e.NameOfCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Registration_Date");
            });

            modelBuilder.Entity<CrossOrderOut>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderOutId });

                entity.ToTable("CrossOrderOut");

                entity.HasOne(d => d.OrderOut)
                    .WithMany(p => p.CrossOrderOuts)
                    .HasForeignKey(d => d.OrderOutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrossOrderOut_OrderOut");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CrossOrderOuts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrossOrderOut_Products");
            });

            modelBuilder.Entity<CrossProductOrder>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderInId });

                entity.ToTable("CrossProductOrder");

                entity.HasOne(d => d.OrderIn)
                    .WithMany(p => p.CrossProductOrders)
                    .HasForeignKey(d => d.OrderInId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrossProductOrder_OrederIn");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CrossProductOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrossProductOrder_Products");
            });

            modelBuilder.Entity<CrossProductRack>(entity =>
            {
                entity.HasKey(e => new { e.RackId, e.ProductId });

                entity.ToTable("CrossProductRack");

                entity.Property(e => e.DeletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Deletion_Date");

                entity.Property(e => e.PlacementDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Placement_Date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CrossProductRacks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrossProductRack_Product");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.CrossProductRacks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrossProductRack_Rack");
            });

            modelBuilder.Entity<OrderIn>(entity =>
            {
                entity.ToTable("OrderIn");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOrderIn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.OrderIns)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_OrederIn_Supplier");
            });

            modelBuilder.Entity<OrderOut>(entity =>
            {
                entity.ToTable("OrderOut");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOrderOut).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.OrderOuts)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_OrderOut_Shop");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.OrderOuts)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_OrderOut_Supplier");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateEndWork).HasColumnType("datetime");

                entity.Property(e => e.DateStartWork).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patronimyc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Personal_Status");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BestBeforeDateEnd).HasColumnType("datetime");

                entity.Property(e => e.BestBeforeDateStart).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Products_ProductType");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_Products_Unit");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rack>(entity =>
            {
                entity.ToTable("Rack");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.Racks)
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK_Rack_Personal");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Supplier_Company");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WriteOffRegister>(entity =>
            {
                entity.ToTable("WriteOffRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeltedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Delted_at");

                entity.Property(e => e.ReasonDelete)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WriteOffRegisters)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_WriteOffRegister_Product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
