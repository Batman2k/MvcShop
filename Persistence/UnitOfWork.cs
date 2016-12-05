using RapidMountain.Core;
using RapidMountain.Core.Repositories;
using RapidMountain.Persistence.Repositories;

namespace RapidMountain.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new CategoryRepository(context);
            Products = new ProductRepository(context);
            Reviews = new ReviewRepository(context);
            Carts = new CartRepository(context);
            Orders = new OrderRepository(context);
            CustomerInfos = new CustomerInfoRepository(context);
        }

        public IOrderRepository Orders { get; set; }
        public ICustomerInfoRepository CustomerInfos { get; set; }
        public IProductRepository Products { get; set; }
        public ICategoryRepository Categories { get; set; }
        public IReviewRepository Reviews { get; set; }
        public ICartRepository Carts { get; set; }

        public void Finish()
        {
            _context.SaveChanges();
        }
    }
}