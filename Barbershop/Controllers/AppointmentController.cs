using barbershopApi.Data;
using barbershopApi.Models;
using barbershopApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace barbershopApi.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/appointments/{barberId}
        [HttpGet("{barberId}")]
        public async Task<IActionResult> GetAppointments(string barberId)
        {
            var appointments = await _appointmentService.GetAppointmentsAsync(barberId);
            return Ok(appointments);
        }

        // POST: api/appointments
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }

            var createdAppointment = await _appointmentService.CreateAppointmentAsync(appointment);

            return CreatedAtAction("GetAppointment", new { id = createdAppointment.AppointmentID }, createdAppointment);
        }

        // PUT: api/appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return BadRequest();
            }

            var updatedAppointment = await _appointmentService.UpdateAppointmentAsync(id, appointment);

            if (updatedAppointment == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var deletedAppointment = await _appointmentService.DeleteAppointmentAsync(id);

            if (deletedAppointment == null)
            {
                return NotFound();
            }

            return Ok(deletedAppointment);
        }
    }
}
