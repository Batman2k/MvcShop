using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RapidMountain.Core.Models
{
    public class Order
    {
        public Order()
        {
            OrderProducts = new Collection<OrderProduct>();
            OrderAddresses = new Collection<OrderAddress>();
        }

        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public DateTime DatePlaced { get; set; }

        public string OrderStatus { get; set; }

        public string PaymentMethod { get; set; }

        public string TrackingNumber { get; set; }

        public decimal ShippingCost { get; set; }

        public bool IsPaid { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        public ICollection<OrderAddress> OrderAddresses { get; set; }
    }
}