using barbershopApi.Models;
using barbershopApi.Repositories;

namespace barbershopApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync(string barberId)
        {
            return await _appointmentRepository.GetAppointmentsAsync(barberId);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(appointmentId);
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            return await _appointmentRepository.CreateAppointmentAsync(appointment);
        }

        public async Task<Appointment> UpdateAppointmentAsync(int appointmentId, Appointment appointment)
        {
            appointment.AppointmentID = appointmentId; // Make sure the appointment ID matches the parameter
            return await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task<Appointment> DeleteAppointmentAsync(int appointmentId)
        {
            return await _appointmentRepository.DeleteAppointmentAsync(appointmentId);
        }
    }
}
