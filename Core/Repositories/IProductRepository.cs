using System.Collections.Generic;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductById(int id);
        List<Product> SearchProducts(string searchTerm);
        List<Product> GetAllVisibleProductBySubCategory(string category, string subCategory);
        List<Product> GetProductsByIds(List<int> cartlist);
    }
}