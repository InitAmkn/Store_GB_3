using Microsoft.EntityFrameworkCore;
using Store_GB_3.Models;

namespace Store_GB_3
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public AppDbContext()
        {

        }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        /*
         dotnet ef migrations add InitialCreate --context AppDbContext
         dotnet ef database update
        */
        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString);
        }
           

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(x => x.Id).HasName("ProductID");
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Cost)
                .HasColumnName("Cost")
                .IsRequired();


                entity.HasOne(x => x.Category)
                .WithMany(c => c.Products).HasForeignKey(x => x.Id).HasConstraintName("CategoryToProduct");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
                entity.Property(e => e.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(255)
                .IsRequired();
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");
                entity.HasKey(x => x.Id).HasName("StorageID");

                entity.Property(x => x.Name)
                .HasColumnName("StorageName");

                entity.Property(e => e.Count)
                .HasColumnName("ProductCount");

                entity.HasMany(x => x.Products)
                .WithMany(m => m.Storages)
                .UsingEntity(j => j.ToTable("StorageProduct"));
            });
        }
    }
}
