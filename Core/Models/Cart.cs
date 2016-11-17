using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidMountain.Core.Models
{
    public class Cart
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        
        public int Amount { get; set; }
    }
}