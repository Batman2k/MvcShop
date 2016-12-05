using RapidMountain.Core.Repositories;
using RapidMountain.Persistence.Repositories;

namespace RapidMountain.Core
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; set; }
        ICategoryRepository Categories { get; set; }
        IReviewRepository Reviews { get; set; }
        ICartRepository Carts { get; set; }
        IOrderRepository Orders { get; set; }
        ICustomerInfoRepository CustomerInfos { get; set; }

        void Finish();
    }
}