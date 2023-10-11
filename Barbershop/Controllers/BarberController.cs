using barbershopApi.Data;
using barbershopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace barbershopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        private readonly BarberShopContext _context;

        public BarberController(BarberShopContext context)
        {
            _context = context;
        }

        // Define API endpoints for managing Barbers
        // GET: api/barbers
        [HttpGet]
        public ActionResult<IEnumerable<Barber>> GetBarbers()
        {
            var barbers = _context.Barbers.ToList();
            return Ok(barbers);
        }

        // GET: api/barbers/{id}
        [HttpGet("{id}")]
        public ActionResult<Barber> GetBarber(int id)
        {
            var barber = _context.Barbers.Find(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        // POST: api/barbers
        [HttpPost]
        public ActionResult<Barber> PostBarber(Barber barber)
        {
            _context.Barbers.Add(barber);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBarber), new { id = barber.BarberID }, barber);
        }

        // PUT: api/barbers/{id}
        [HttpPut("{id}")]
        public ActionResult PutBarber(int id, Barber barber)
        {
            if (id != barber.BarberID)
            {
                return BadRequest();
            }

            _context.Entry(barber).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/barbers/{id}
        [HttpDelete("{id}")]
        public ActionResult<Barber> DeleteBarber(int id)
        {
            var barber = _context.Barbers.Find(id);

            if (barber == null)
            {
                return NotFound();
            }

            _context.Barbers.Remove(barber);
            _context.SaveChanges();

            return Ok(barber);
        }

        }
}
