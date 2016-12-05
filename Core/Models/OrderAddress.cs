namespace RapidMountain.Core.Models
{
    public class OrderAddress
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public bool IsJustBilling { get; set; }
    
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }
        
        public string City { get; set; }
        
        public string Province { get; set; }
        
        public string Country { get; set; }

        public string ZipCode { get; set; }
        
        public string PhoneNumber { get; set; }
        
    }
}