using System;

namespace RapidMountain.Core.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public decimal TotalSum { get; set; }

        public string TrackingNumber { get; set; }

        public string OrderStatus { get; set; }

        public DateTime DatePlaced { get; set; }
    }
}