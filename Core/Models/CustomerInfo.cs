using System.ComponentModel.DataAnnotations;
using RapidMountain.Controllers;

namespace RapidMountain.Core.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string AddressOne { get; set; }

        [StringLength(150)]
        public string AddressTwo { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Province { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public void Update(CheckoutViewModel checkoutViewModel)
        {
            FirstName = checkoutViewModel.FirstName;
            LastName = checkoutViewModel.LastName;
            AddressOne = checkoutViewModel.AddressOne;
            AddressTwo = checkoutViewModel.AddressTwo;
            City = checkoutViewModel.City;
            Province = checkoutViewModel.Province;
            Country = checkoutViewModel.Country;
            ZipCode = checkoutViewModel.ZipCode;
            PhoneNumber = checkoutViewModel.PhoneNumber;
        }
    }
}