using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Contracts.Services
{
    public interface IReviewDataService
    {
        Task<IEnumerable<Review>> GetAllReviewsForRestaurant(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Review> GetReviewById(int reviewId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<Review>> GetReviewByRestId(int restId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
