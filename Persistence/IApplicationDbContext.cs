using System.Data.Entity;
using RapidMountain.Core.Models;
using RapidMountain.Persistence.Repositories;

namespace RapidMountain.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Picture> Pictures { get; set; }

        DbSet<Specification> Specifications { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Cart> Carts { get; set; }

        DbSet<CustomerInfo> CustomerInfos { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderProduct> OrderProducts { get; set; }

        DbSet<OrderAddress> OrderAddress { get; set; }
    }
}