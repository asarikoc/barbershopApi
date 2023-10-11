using barbershopApi.Data;
using barbershopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace barbershopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly BarberShopContext _context;

        public ReviewController(BarberShopContext context)
        {
            _context = context;
        }
        // Define API endpoints for managing Reviews
        // GET: api/reviews
        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetReviews()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        // GET: api/reviews/{id}
        [HttpGet("{id}")]
        public ActionResult<Review> GetReview(int id)
        {
            var review = _context.Reviews.Find(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // POST: api/reviews
        [HttpPost]
        public ActionResult<Review> PostReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetReview), new { id = review.ReviewID }, review);
        }

        // PUT: api/reviews/{id}
        [HttpPut("{id}")]
        public ActionResult PutReview(int id, Review review)
        {
            if (id != review.ReviewID)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/reviews/{id}
        [HttpDelete("{id}")]
        public ActionResult<Review> DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);

            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();

            return Ok(review);
        }
    }
}
