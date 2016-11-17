using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RapidMountain.Core.Models
{
    public class Product
    {
        public Product()
        {
            Pictures = new Collection<Picture>();
            Reviews = new Collection<Review>();
            Specifications = new Collection<Specification>();
        }
        
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

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<Specification> Specifications { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}