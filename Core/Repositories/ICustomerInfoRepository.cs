using RapidMountain.Core.Models;

namespace RapidMountain.Core.Repositories
{
    public interface ICustomerInfoRepository
    {
        CustomerInfo GetCustomerInfoByUserId(string userId);
        void Add(CustomerInfo customerInfo);
    }
}