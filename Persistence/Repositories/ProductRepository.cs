using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RapidMountain.Core.Models;
using RapidMountain.Core.Repositories;

namespace RapidMountain.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        //public Product GetProductById(int id)
        //{
        //    return _context.Products
        //        .Include(p => p.Reviews)
        //        .Include(p => p.Pictures)
        //        .Include(p => p.Specifications)
        //        .FirstOrDefault(p => p.Id == id);

        //}

        //TODO try and not use where
        public Product GetProductById(int id)
        {
            var product = _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Reviews)
                .Include(p => p.Specifications)
                .Include(p => p.Pictures)
                .FirstOrDefault();

            if (product != null)
            {
                var pictureIds = _context.Pictures
                    .Where(p => p.ProductId == id)
                    .Select(p =>  p.Id)
                    .ToList();
                
                foreach (var pictureId in pictureIds)
                {
                    product.Pictures.Add(new Picture {Id = pictureId});
                }

                return product;
            }

            return null;
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            return _context.Products
                .Where(p =>
                    p.IsVisible &&
                    (p.Name.Contains(searchTerm) ||
                     p.Description.Contains(searchTerm) ||
                     p.Category.Contains(searchTerm) ||
                     p.SubCategory.Contains(searchTerm) ||
                     p.SerialNumber.Contains(searchTerm)))
                .Include(p => p.Pictures)
                //.Select(p => new
                //{
                //  AmountInStock = p.AmountInStock,
                  
                //  Category = p.Category,
                //  Description = p.Description,
                //  Discount = p.Discount,
                //  Id = p.Id,
                //  IsVisible = p.IsVisible,
                //  LimitedOffer = p.LimitedOffer,
                //  Name = p.Name,
                //  Pictures = new List<Picture>
                //  {
                //      p.Pictures.FirstOrDefault() 
                      
                //  }
                // })
                //TODO include only first picture // add mainpicture in productmodel....
                .ToList();

        }

        public List<Product> GetAllVisibleProductBySubCategory(string category, string subCategory)
        {
            return _context.Products
                .Where(p =>
                    p.IsVisible &&
                    p.Category.Contains(category) &&
                    p.SubCategory.Contains(subCategory))
                //TODO include only first picture // add mainpicture in productmodel....
                .Include(p => p.Pictures)
                .ToList();
        }

        public List<Product> GetProductsByIds(List<int> ids)
        {
            return _context.Products
                .Where(p => ids.Contains(p.Id))
                .ToList();
        }
    }
}