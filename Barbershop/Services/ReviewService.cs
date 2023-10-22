using barbershopApi.Models;
using barbershopApi.Repositories;

namespace barbershopApi.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(string barberId)
        {
            return await _reviewRepository.GetReviewsAsync(barberId);
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _reviewRepository.GetReviewByIdAsync(reviewId);
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            return await _reviewRepository.CreateReviewAsync(review);
        }

        public async Task<Review> UpdateReviewAsync(int reviewId, Review review)
        {
            return await _reviewRepository.UpdateReviewAsync(reviewId, review);
        }

        public async Task<Review> DeleteReviewAsync(int reviewId)
        {
            return await _reviewRepository.DeleteReviewAsync(reviewId);
        }
    }
}
