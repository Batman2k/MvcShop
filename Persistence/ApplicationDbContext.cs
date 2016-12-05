using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RapidMountain.Core.Models;
using RapidMountain.Persistence.Repositories;

namespace RapidMountain.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Cart> Carts { get; set; }




        public DbSet<CustomerInfo> CustomerInfos { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<OrderAddress> OrderAddress { get; set; }




        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

          ////TODO Keep..?
          // modelBuilder.Entity<Review>().HasRequired(r => r.Product).WithMany(p => p.Reviews).WillCascadeOnDelete(true);
         



            base.OnModelCreating(modelBuilder);
        }
    }
}