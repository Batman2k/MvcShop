using System.Collections.Generic;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}