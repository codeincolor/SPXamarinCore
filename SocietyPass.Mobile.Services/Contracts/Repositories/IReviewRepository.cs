using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Contracts.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsForRestaurant(CancellationToken cancellationToken = default(CancellationToken));
        Task<Review> GetReviewById(int reviewId, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<Review>> GetReviewByRestId(int restId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
