using System.Linq;
using RapidMountain.Core.Models;
using RapidMountain.Core.Repositories;

namespace RapidMountain.Persistence.Repositories
{
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        private readonly IApplicationDbContext _context;

        public CustomerInfoRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public CustomerInfo GetCustomerInfoByUserId(string userId)
        {
            return _context.CustomerInfos.FirstOrDefault(ci => ci.UserId == userId);
        }

        public void Add(CustomerInfo customerInfo)
        {
            _context.CustomerInfos.Add(customerInfo);
        }
    }
}