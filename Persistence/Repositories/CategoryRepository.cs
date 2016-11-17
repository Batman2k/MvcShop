using System.Collections.Generic;
using System.Linq;
using RapidMountain.Core.Models;
using RapidMountain.Core.Repositories;

namespace RapidMountain.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IApplicationDbContext _context;

        public CategoryRepository(IApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }

        public List<Category> GetCategories()
        {
            var categories = new List<Category>();

            var products = _context.Products
                .Where(p => p.IsVisible)
                .Select(p => new
                {
                    p.Category,
                    p.SubCategory
                })
                .ToList();
            
            foreach (var product in products)
            {
                var cat = categories.FirstOrDefault(c => c.Name == product.Category);

                if (cat == null)
                {
                    categories.Add(new Category
                    {
                        Name = product.Category,
                        SubCategories = new List<SubCategory>
                        {
                            new SubCategory
                            {
                                Name = product.SubCategory,
                                Amount = 1
                            }
                        }
                    });
                    continue;
                }

                var subcat = cat.SubCategories.FirstOrDefault(sb => sb.Name == product.SubCategory);

                if (subcat == null)
                {
                    categories.FirstOrDefault(p => p.Name == product.Category)?
                        .SubCategories.Add(new SubCategory
                        {
                            Name = product.SubCategory,
                            Amount = 1
                        });
                    continue;
                }

                categories.First(p => p.Name == product.Category)
                    .SubCategories.First(sb => sb.Name == product.SubCategory)
                    .Amount++;
            }

            return categories;
        }
    }
}