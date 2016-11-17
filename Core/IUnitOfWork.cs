using RapidMountain.Core.Repositories;

namespace RapidMountain.Core
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; set; }
        ICategoryRepository Categories { get; set; }
        IReviewRepository Reviews { get; set; }
        ICartRepository Carts { get; set; }
        void Finish();
    }
}