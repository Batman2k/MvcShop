using AutoMapper;
using RapidMountain.Controllers;
using RapidMountain.Core.Models;
using RapidMountain.Core.ViewModels;

namespace RapidMountain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();


            
            CreateMap<CheckoutViewModel, CustomerInfo>();
            CreateMap<CustomerInfo, CheckoutViewModel>();

            CreateMap<CheckoutViewModel, OrderAddress>();

            //TODO needed?
            CreateMap<ProductViewModel, Product>();
        }
    }
}