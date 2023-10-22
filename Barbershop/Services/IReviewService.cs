using barbershopApi.Models;

namespace barbershopApi.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsAsync(string barberId); // Get reviews for a specific barber
        Task<Review> GetReviewByIdAsync(int reviewId); // Get a specific review by ID
        Task<Review> CreateReviewAsync(Review review); // Create a new review
        Task<Review> UpdateReviewAsync(int reviewId, Review review); // Update an existing review
        Task<Review> DeleteReviewAsync(int reviewId); // Delete a specific review by ID
    }
}
