using System.Data.Entity;
using RapidMountain.Core.Models;

namespace RapidMountain.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Picture> Pictures { get; set; }

        DbSet<Specification> Specifications { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Cart> Carts { get; set; }
    }
}