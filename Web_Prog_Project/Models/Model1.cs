using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web_Prog_Project.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Catagory> Catagories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_Name)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_Email)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_Password)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_Contact)
                .IsFixedLength();

            modelBuilder.Entity<Catagory>()
                .Property(e => e.Catagory_Name)
                .IsFixedLength();

            modelBuilder.Entity<Catagory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Catagory)
                .HasForeignKey(e => e.Catagory_F_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Product_Name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Product_Description)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Product_Picture)
                .IsFixedLength();
        }
    }
}
