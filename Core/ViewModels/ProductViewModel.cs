using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Pictures = new List<Picture>();
            Specifications = new List<Specification>();
            Reviews = new List<Review>();
        }

        public string Title { get; set; }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal Discount { get; set; }

        public decimal Price { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string SubCategory { get; set; }

        public bool IsVisible { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public string SerialNumber { get; set; }

        public int AmountInStock { get; set; }

        public DateTime? LimitedOffer { get; set; }

        public int AverageScore { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<Specification> Specifications { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}