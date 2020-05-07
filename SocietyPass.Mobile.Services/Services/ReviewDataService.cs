using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Services
{
    public class ReviewDataService : IReviewDataService
    {
        private readonly IReviewRepository _reviewRespository;

        public ReviewDataService(IReviewRepository reviewRespository)
        {
            _reviewRespository = reviewRespository;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsForRestaurant(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _reviewRespository.GetAllReviewsForRestaurant(cancellationToken);
        }

        public async Task<Review> GetReviewById(int reviewId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _reviewRespository.GetReviewById(reviewId, cancellationToken);
        }
        public async Task<IEnumerable<Review>> GetReviewByRestId(int restId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _reviewRespository.GetReviewByRestId(restId, cancellationToken);
        }
    }
}
