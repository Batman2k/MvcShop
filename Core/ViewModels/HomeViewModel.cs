using System.Collections.Generic;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }

        public string Title { get; set; }

        public string SearchTerm { get; set; }
    }
}