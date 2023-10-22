using barbershopApi.Models;
using Newtonsoft.Json;
using System.Text;

namespace barbershopApi.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HttpClient _httpClient;

        public ReviewRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(string barberId)
        {
            // Make an HTTP GET request to fetch reviews for a specific barber
            var response = await _httpClient.GetAsync($"api/reviews?barberId={barberId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var reviews = JsonConvert.DeserializeObject<IEnumerable<Review>>(content);
                return reviews;
            }

            // Handle the error response or throw an exception if needed
            throw new Exception("Failed to retrieve reviews.");
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            // Make an HTTP GET request to fetch a specific review by ID
            var response = await _httpClient.GetAsync($"api/reviews/{reviewId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var review = JsonConvert.DeserializeObject<Review>(content);
                return review;
            }

            // Handle the error response or throw an exception if needed
            throw new Exception("Failed to retrieve the review.");
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            // Make an HTTP POST request to create a new review
            var reviewJson = JsonConvert.SerializeObject(review);
            var content = new StringContent(reviewJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/reviews", content);

            if (response.IsSuccessStatusCode)
            {
                var createdReviewJson = await response.Content.ReadAsStringAsync();
                var createdReview = JsonConvert.DeserializeObject<Review>(createdReviewJson);
                return createdReview;
            }

            // Handle the error response or throw an exception if needed
            throw new Exception("Failed to create a review.");
        }

        public async Task<Review> UpdateReviewAsync(int reviewId, Review review)
        {
            // Make an HTTP PUT request to update an existing review
            var reviewJson = JsonConvert.SerializeObject(review);
            var content = new StringContent(reviewJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/reviews/{reviewId}", content);

            if (response.IsSuccessStatusCode)
            {
                var updatedReviewJson = await response.Content.ReadAsStringAsync();
                var updatedReview = JsonConvert.DeserializeObject<Review>(updatedReviewJson);
                return updatedReview;
            }

            // Handle the error response or throw an exception if needed
            throw new Exception("Failed to update the review.");
        }

        public async Task<Review> DeleteReviewAsync(int reviewId)
        {
            // Make an HTTP DELETE request to delete a specific review by ID
            var response = await _httpClient.DeleteAsync($"api/reviews/{reviewId}");

            if (response.IsSuccessStatusCode)
            {
                var deletedReviewJson = await response.Content.ReadAsStringAsync();
                var deletedReview = JsonConvert.DeserializeObject<Review>(deletedReviewJson);
                return deletedReview;
            }

            // Handle the error response or throw an exception if needed
            throw new Exception("Failed to delete the review.");
        }
    }
}