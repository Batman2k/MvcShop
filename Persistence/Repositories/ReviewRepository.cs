using RapidMountain.Core;
using RapidMountain.Core.Models;
using RapidMountain.Core.Repositories;

namespace RapidMountain.Persistence.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IApplicationDbContext _context;

        public ReviewRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
        }
    }
}