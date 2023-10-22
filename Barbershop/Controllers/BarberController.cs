using barbershopApi.Data;
using barbershopApi.Models;
using barbershopApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace barbershopApi.Controllers
{
    [Route("api/barbers")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        private readonly IBarberService _barberService;

        public BarberController(IBarberService barberService)
        {
            _barberService = barberService;
        }

        // GET: api/barbers
        [HttpGet]
        public async Task<IActionResult> GetBarbers()
        {
            var barbers = await _barberService.GetBarbersAsync();
            return Ok(barbers);
        }

        // GET: api/barbers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarber(string id)
        {
            var barber = await _barberService.GetBarberByIdAsync(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        // POST: api/barbers
        [HttpPost]
        public async Task<IActionResult> CreateBarber([FromBody] Barber barber)
        {
            if (barber == null)
            {
                return BadRequest();
            }

            var createdBarber = await _barberService.CreateBarberAsync(barber);

            return CreatedAtAction("GetBarber", new { id = createdBarber.BarberID }, createdBarber);
        }

        // PUT: api/barbers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarber(string id, [FromBody] Barber barber)
        {
            if (id != barber.BarberID)
            {
                return BadRequest();
            }

            var updatedBarber = await _barberService.UpdateBarberAsync(id, barber);

            if (updatedBarber == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/barbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarber(string id)
        {
            var deletedBarber = await _barberService.DeleteBarberAsync(id);

            if (deletedBarber == null)
            {
                return NotFound();
            }

            return Ok(deletedBarber);
        }
    }
}