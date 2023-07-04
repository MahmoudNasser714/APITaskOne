using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace API_TASKS.ShopStoreEF
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Arabic_name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.English_name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Cate_ID);

            modelBuilder.Entity<Product>()
                .Property(e => e.Arabic_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.English_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Manufacturer)
                .IsUnicode(false);
            modelBuilder.Entity<Product>()
               .Property(e => e.State)
               .IsUnicode(false);



            modelBuilder.Entity<User>()
                .Property(e => e.arabic_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.English_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}
