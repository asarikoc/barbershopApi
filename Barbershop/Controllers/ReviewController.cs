using barbershopApi.Data;
using barbershopApi.Models;
using barbershopApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace barbershopApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/reviews/{barberId}
        [HttpGet("{barberId}")]
        public async Task<IActionResult> GetReviews(string barberId)
        {
            var reviews = await _reviewService.GetReviewsAsync(barberId);
            return Ok(reviews);
        }

        // POST: api/reviews
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest();
            }

            var createdReview = await _reviewService.CreateReviewAsync(review);

            return CreatedAtAction("GetReview", new { id = createdReview.ReviewID }, createdReview);
        }

        // PUT: api/reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] Review review)
        {
            if (id != review.ReviewID)
            {
                return BadRequest();
            }

            var updatedReview = await _reviewService.UpdateReviewAsync(id, review);

            if (updatedReview == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var deletedReview = await _reviewService.DeleteReviewAsync(id);

            if (deletedReview == null)
            {
                return NotFound();
            }

            return Ok(deletedReview);
        }
    }
}