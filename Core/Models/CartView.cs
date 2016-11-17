using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace RapidMountain.Core.Models
{
    public class CartView
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        
        public int ProductId { get; set; }
        
        public int Amount { get; set; }
        
        public string Name { get; set; }
        
        public int PictureId { get; set; }

        public decimal Price { get; set; }
    }
}