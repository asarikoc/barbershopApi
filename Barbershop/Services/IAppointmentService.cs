using barbershopApi.Models;

namespace barbershopApi.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync(string barberId); // Get appointments for a specific barber
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId); // Get a specific appointment by ID
        Task<Appointment> CreateAppointmentAsync(Appointment appointment); // Create a new appointment
        Task<Appointment> UpdateAppointmentAsync(int appointmentId, Appointment appointment); // Update an existing appointment
        Task<Appointment> DeleteAppointmentAsync(int appointmentId); // Delete a specific appointment by ID
    }
}
