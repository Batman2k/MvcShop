using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidMountain.Core.Models
{
    public class OrderProduct
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }
    }
}