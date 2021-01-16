using Microsoft.EntityFrameworkCore;
using project.Data.Models;

namespace project.Data.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {}

        public virtual DbSet<Customer> Customer {get; set;}
        public virtual DbSet<Product> Product {get; set;}
        public virtual DbSet<Store> Stores {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);
                entity.Property(e =>e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e =>e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);
                entity.Property(e =>e.Description)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e =>e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Price)
                .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);
                entity.Property(e =>e.StoreName)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e =>e.Street1)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e =>e.Suburb)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e =>e.State)
                .IsRequired()
                .HasMaxLength(50);

               entity.Property(e =>e.Country)
                .IsRequired()
                .HasMaxLength(50);
            });

        }
    }
}