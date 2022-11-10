using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace logInHW.Models3
{
    public partial class api212796Context : DbContext
    {
        public api212796Context()
        {
        }

        public api212796Context(DbContextOptions<api212796Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameCategorie> GameCategories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategorie> ProductCategories { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=api212796;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.Property(e => e.ProdId).HasColumnName("prod_Id");

                entity.Property(e => e.CategorieId).HasColumnName("Categorie_Id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Image)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("FK_Games_GameCategorie");
            });

            modelBuilder.Entity<GameCategorie>(entity =>
            {
                entity.HasKey(e => e.CategoresId);

                entity.ToTable("GameCategorie");

                entity.Property(e => e.CategoresId).HasColumnName("Categores_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("ORDER_DATE");

                entity.Property(e => e.OrderSum).HasColumnName("ORDER_SUM");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Item");

                entity.Property(e => e.OrderItemId).HasColumnName("ORDER_ITEM_ID");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.ProuductId).HasColumnName("PROUDUCT_ID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Orders_id");

                entity.HasOne(d => d.Prouduct)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProuductId)
                    .HasConstraintName("FK_PROUDUCT_ID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.Property(e => e.ProdId).HasColumnName("prod_Id");

                entity.Property(e => e.CategorieId).HasColumnName("Categorie_Id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Image)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("FK_Products_ProductsCategorie");
            });

            modelBuilder.Entity<ProductCategorie>(entity =>
            {
                entity.HasKey(e => e.CategoresId);

                entity.ToTable("ProductCategorie");

                entity.Property(e => e.CategoresId).HasColumnName("Categores_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("HOST");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("PATH");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("REFERER");

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL")
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME")
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
