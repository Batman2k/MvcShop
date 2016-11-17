using System.Collections.Generic;

namespace RapidMountain.Core.Models
{
    public class Category
    {
        public string Name { get; set; }

        public List<SubCategory> SubCategories { get; set; }
    }
}